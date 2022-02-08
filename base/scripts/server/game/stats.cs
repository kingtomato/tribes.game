// StatLog::Push( Event, <playerid>, <position>, <subevent>, <target>, <value> )

Event::Attach( eventServerClientJoinTeam, Stats::onClientJoinTeam );
Event::Attach( eventServerClientConnect, Stats::onClientConnect );
Event::Attach( eventServerClientDisconnect, Stats::onClientDisconnect );
Event::Attach( eventServerMatchStarted, Stats::onMatchStarted );
Event::Attach( eventServerMissionComplete, Stats::onMissionComplete );

function Stats::Reset( %type, %teamcount ) {
	$Stats::recording = false;
	
	deleteVariables( "$Stats::timeBased*" );
	deleteVariables( "$*" @ Stats::Prefix() @ "*" );
	$Stats::teams = %teamcount;
	$Stats::mission = "Unknown";
	$Stats::NullState = "NULLSTATE";
	$Stats::type = %type;
}

function Stats::AdjustScore( %cl, %cat, %amt ) {
	// adjust score if needed
	%weight = $Stats::Scoring[%cat];
	%points = "UNDEFINED";
	if ( abs( %weight ) != 0 ) {
		// adjust score
		%points = ( %weight * %amt );
		%cl.score += %points;
	}
	return %points;
}

// RPC, don't really like having a specific kill/death one
function Stats::KillDeathRPC( %killer, %victim, %type ) {
	Stats::SubEvent( %killer, "Kills", %type, 1 );
	Stats::SubEvent( %victim, "Deaths", %type, 1 );
	Stats::AdjustScore( %killer, "Kills" ~ %type, 1 );
	Stats::AdjustScore( %victim, "Deaths" ~ %type, 1 );
	
	message::taggedall( "KD", sprintf( "%1/%2/%3", %type, $Stats::Scoring["Kills" ~ %type], $Stats::Scoring["Deaths" ~ %type] ), %killer, %victim );
}

function Stats::StatRPC( %cl, %cat, %amt, %p0, %p1, %p2, %p3, %p4 ) {
	Stats::Event( %cl, %cat, %amt );

	message::taggedall( "ST", sprintf( "%1/%2", %cat, $Stats::Scoring[%cat] ), %cl, %amt, %p0, %p1, %p2, %p3, %p4 );

	%points = Stats::AdjustScore( %cl, %cat, %amt );

	// do event messages
	%name = Client::getName( %cl );
	%self = $Stats::Scoring[%cat, "selfMsg"];
	if ( %self != "" )
		message::client( %cl, 0, sprintf( %self, %name, %points ) );

	%global = $Stats::Scoring[%cat, "globalMsg"];
	if ( %global != "" )
		message::all( 0, sprintf( %global, %name, %points ) );
}


// Category tracking

function Stats::Prefix( %group ) {
	return ( "stats::" @ %group );
}

function Stats::TeamPrefix( %group ) {
	return ( "stats::team::" @ %group );
}

function Stats::RegisterInternal( %cat, %subcat, %weight, %selfmsg, %globalmsg ) {
	%fullcat = %cat @ %subcat;
	L::PushUnique( Stats::Prefix( "fields" ), %fullcat );
	if ( %weight != "" ) {
		$Stats::Scoring[%fullcat] = %weight;
		$Stats::Scoring[%fullcat, "selfMsg"] = %selfmsg;
		$Stats::Scoring[%fullcat, "globalMsg"] = %globalmsg;
	}
}

function Stats::Register( %cat, %weight, %selfmsg, %globalmsg ) {
	Stats::RegisterInternal( %cat, "", %weight, %selfmsg, %globalmsg );
}

function Stats::RegisterTeam( %cat ) {
	L::Push( Stats::TeamPrefix( "fields" ), %cat );
}

function Stats::RegisterSubType( %cat, %subcat, %weight, %selfmsg, %globalmsg ) {
	Stats::RegisterInternal( %cat );
	Stats::RegisterInternal( %cat, %subcat, %weight, %selfmsg, %globalmsg );
}

function Stats::Identifier( %cl ) {
	// use ia guid here
	return Client::getGuid( %cl );
}

function Stats::Event( %cl, %cat, %amt ) {
	%amt = ( %amt == "" ) ? 1 : %amt;

	if ( !L::Find( Stats::Prefix( "fields" ), %cat ) ) {
		errorf( "STATS ERROR: %1 not a stats field!", %cat );
		return;
	}
	C::Inc( Stats::Prefix( Stats::Identifier(%cl) @ %cat ), %amt );
}

function Stats::TeamEvent( %team, %cat, %amt ) {
	if ( !L::Find( Stats::TeamPrefix( "fields" ), %cat ) ) {
		errorf( "STATS ERROR: %1 not a team stats field!", %cat );
		return;
	}
	C::Inc( Stats::TeamPrefix( Marker::Team( %team ) @ %cat ), %amt );
}

function Stats::SubEvent( %cl, %cat, %subcat, %amt ) {
	Stats::Event( %cl, %cat, %amt );
	Stats::Event( %cl, %cat @ %subcat, %amt );
}

function Stats::TimeEvent( %cl, %cat, %state ) {
	%prefix = Stats::Prefix();
	TimeC::Update( %prefix @ Stats::Identifier(%cl) @ %cat, %state );
	L::PushUnique( %prefix @ "cats::states" @ %cat, %state );
	$Stats::timeBasedCat[ %prefix @ %cat ] = true;
}

function Stats::TeamTimeEvent( %team, %cat, %state ) {
	%prefix = Stats::TeamPrefix();
	TimeC::Update( %prefix @ Marker::Team( %team ) @ %cat, %state );
	L::PushUnique( %prefix @ "cats::states" @ %cat, %state );
	$Stats::timeBasedCat[ %prefix @ %cat ] = true;
}

// Get thingers

function Stats::Get( %prefix, %ident, %cat ) {
	return C::Get( %prefix @ %ident @ %cat );
}

function Stats::GetTime( %prefix, %ident, %cat, %state ) {
	return TimeC::Duration( %prefix @ %ident @ %cat, %state );
}

// Trigger events

function Stats::onClientConnect( %cl ) {
	%ident = Stats::Identifier( %cl );
	Stats::ClearPlayer( %ident );
	L::PushUnique( Stats::Prefix( "playerlist" ), %ident );
}


function Stats::onClientJoinTeam( %cl, %team ) {
	%ident = Stats::Identifier( %cl );
	// if the client has current stats, save them to the old team
	if ( %cl.statExporting )
		Stats::ExportPlayer( %cl, %cl.statOldTeam );

	Stats::TimeEvent( %cl, "teamtime", %team );
	%cl.statExporting = true;
	%cl.statOldTeam = %team;
	
	StatLog::Push( JoinTeam, Stats::Identifier( %cl ), "", %team );
}

function Stats::onClientDisconnect( %cl ) {
	Stats::TimeEvent( %cl, "teamtime", $Stats::NullState );
	Stats::ExportPlayer( %cl, Client::getTeam( %cl ) );

	StatLog::Push( LeaveServer, Stats::Identifier( %cl ) );
}

function Stats::onMatchStarted( %mission ) {
	StatLog::Start( $Stats::type, %mission );
	
	$Stats::recording = true;
	$Stats::start = getSimTime();
	$Stats::mission = %mission;
	// echof( "Passed mission %1, Stats mission = %2", $Stats::Mission, %mission );

	deleteVariables( "$Stats::Totals*" );
	
	L::Clear( Stats::Prefix( "playerlist" ) );
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext( %cl ) ) {
		%ident = Stats::Identifier( %cl );
		Stats::ClearPlayer( %ident );
		Stats::onClientJoinTeam( %cl, Client::getTeam( %cl ) );
		L::Push( Stats::Prefix( "playerlist" ), %ident );
	}
}

function Stats::AllCatsCallback( %prefix, %ident, %type, %cat, %state, %team ) {
	if ( ( %state != $Stats::NullState ) && ( %type != "timecat" ) )
		L::Push( %prefix @ "allcats", %cat @ %state );
}

function Stats::onMissionComplete( %forcedMission ) {
	Schedule::Cancel( "statposthread" );
	
	if ( %forcedMission != "" )
		StatLog::Abort();
	else
		StatLog::Stop();
	
	$Stats::duration = ( getSimTime() - $Stats::start );
	
	L::Clear( Stats::Prefix() @ "allcats" );
	Stats::IterateFields( Stats::Prefix(), Stats::AllCatsCallback );
	L::Clear( Stats::TeamPrefix() @ "allcats" );
	Stats::IterateFields( Stats::TeamPrefix(), Stats::AllCatsCallback );

	Stats::Export();
	
	if ( $dedicated )
		Stats::ToStatSheet();
}


// Exporting

$Stats::IterateCallback = "%1( \"%2\", \"%3\", \"%4\", \"%5\", \"%6\", \"%7\" );";

function Stats::IterateFields( %prefix, %callback, %ident, %team ) {
	%count = L::Reset( %prefix @ "fields" );
	for ( %i = 0; %i < %count; %i++ ) {
		%cat = L::GetNext( %prefix @ "fields" );
		if ( $Stats::timeBasedCat[ %prefix @ %cat ] ) {
			evalf( $Stats::IterateCallback, %callback, %prefix, %ident, "timecat", %cat, %team );

			%count2 = L::Reset( %prefix @ "cats::states" @ %cat );
			for ( %states = 0; %states < %count2; %states++ ) {
				%state = L::GetNext( %prefix @ "cats::states" @ %cat );
				evalf( $Stats::IterateCallback, %callback, %prefix, %ident, "timecatstate", %cat, %state, %team );
			}
		} else {
			evalf( $Stats::IterateCallback, %callback, %prefix, %ident, "cat", %cat, "", %team );
		}
	}
}

// clears all stats associated with the player, but not the player's total stats
function Stats::ClearPlayer( %ident ) {
	C::Clear( Stats::Prefix( %ident ) ); 
	TimeC::Clear( Stats::Prefix( %ident ) ); 
}

function Stats::ExportPlayers() {
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext( %cl ) )
		Stats::ExportPlayer( %cl, Client::getTeam( %cl ) );
}

// dumps the players current stats in to the total stats, also totals in to
// %team totals as well
//
// this also resolves all cats to 0 if they haven't been scored yet
function Stats::ExportPlayerCallback( %prefix, %ident, %type, %cat, %state, %team ) {
	if ( %state == $Stats::NullState )
		return;

	if ( %type == "cat" ) {
		%amount = Stats::Get( %prefix, %ident, %cat );
		$Stats::Totals[ %ident, %cat ] += %amount;
		$Stats::Totals[ Marker::Team( %team ), %cat ] += %amount;
	} else if ( %type == "timecatstate" ) {
		TimeC::Update( %prefix @ %ident @ %cat, $Stats::NullState ); // finalize it
		%duration = Stats::GetTime( %prefix, %ident, %cat, %state );
		$Stats::Totals[ %ident, %cat @ %state ] += %duration;
		$Stats::Totals[ Marker::Team( %team ), %cat @ %state ] += %duration;
		// echof( "%1 = %2", %cat @ %state, %duration );
	}
}

function Stats::ExportPlayer( %cl, %team ) {
	%ident = Stats::Identifier( %cl );
	// echof( "Exporting %1 on team %2", %ident, %team );
	Stats::IterateFields( Stats::Prefix(), Stats::ExportPlayerCallback, %ident, %team );
	Stats::ClearPlayer( %ident );
}



function Stats::ExportTeamCallback( %prefix, %ident, %type, %cat, %state, %team ) {
	if ( %state == $Stats::NullState )
		return;

	if ( %type == "cat" ) {
		$Stats::Totals[ %ident, %cat ] += Stats::Get( %prefix, %ident, %cat );
	} else if ( %type == "timecatstate" ) {
		TimeC::Update( %prefix @ %ident @ %cat, $Stats::NullState ); // finalize it
		%duration = Stats::GetTime( %prefix, %ident, %cat, %state );
		$Stats::Totals[ %ident, %cat @ %state ] += %duration;
	}
}


function Stats::ExportTeams() {
	for ( %team = 0; %team < $Stats::teams; %team++ )
		Stats::IterateFields( Stats::TeamPrefix(), Stats::ExportTeamCallback, Marker::Team( %team ) );
}

function Stats::Export() {
	if ( !$Stats::Recording )
		return;

	Stats::ExportPlayers();
	Stats::ExportTeams();

	echof( "%1,%2", $Stats::type, $Stats::teams );

	%catcount = L::Reset( Stats::TeamPrefix() @ "allcats" );
	if ( %catcount ) {
		%fields = "team";
		for ( %i = 0; %i < %catcount; %i++ ) {
			%cats[%i] = L::GetNext( Stats::TeamPrefix() @ "allcats" );
			%fields = %fields @ "," @ %cats[%i];
		}
		echo( %fields );

		for ( %team = 0; %team < $Stats::teams; %team++ ) {
			%values = %team;
			%marker = Marker::Team( %team );
			for ( %j = 0; %j < %catcount; %j++ )
				%values = %values @ "," @ $Stats::Totals[ %marker, %cats[%j] ];
			echo( %values );
		}
	}

	%catcount = L::Reset( Stats::Prefix() @ "allcats" );
	if ( %catcount ) {
		%fields = "player";
		for ( %i = 0; %i < %catcount; %i++ ) {
			%cats[%i] = L::GetNext( Stats::Prefix() @ "allcats" );
			%fields = %fields @ "," @ %cats[%i];
		}
		echo( %fields );

		%count = L::Reset( Stats::Prefix( "playerlist" ) );
		for ( %i = 0; %i < %count; %i++ ) {
			%ident = L::GetNext( Stats::Prefix( "playerlist" ) );
			%values = %ident;
			for ( %j = 0; %j < %catcount; %j++ )
				%values = %values @ "," @ $Stats::Totals[ %ident, %cats[%j] ];
			echo( %values );
		}
	}
}



// Tribes specific crap

%cnt = -1;
$Convert::Weapons[ %cnt++ ] = "Chain";
$Convert::Weapons[ %cnt++ ] = "Blaster";
$Convert::Weapons[ %cnt++ ] = "ELF";
$Convert::Weapons[ %cnt++ ] = "Plasma";
$Convert::Weapons[ %cnt++ ] = "Disc";
$Convert::Weapons[ %cnt++ ] = "Explosive";
$Convert::Weapons[ %cnt++ ] = "Laser";
$Convert::Weapons[ %cnt++ ] = "Mortar";
$Convert::Weapons[ %cnt++ ] = "Turret";

%cnt = -1;
$Convert::Singles[ %cnt++ ] = "Suicide";
$Convert::Singles[ %cnt++ ] = "TeamKill";
$Convert::Singles[ %cnt++ ] = "TeamDeath";
$Convert::Singles[ %cnt++ ] = "CarrierKill";
$Convert::Singles[ %cnt++ ] = "Grab";
$Convert::Singles[ %cnt++ ] = "Pickup";
$Convert::Singles[ %cnt++ ] = "Drop";
$Convert::Singles[ %cnt++ ] = "Return";
$Convert::Singles[ %cnt++ ] = "StandoffReturn";
$Convert::Singles[ %cnt++ ] = "Assist";
$Convert::Singles[ %cnt++ ] = "Cap";

$Convert::Singles[ "CarrierKill" ] = "FlagCarrierKill";
$Convert::Singles[ "Grab" ] = "FlagGrab";
$Convert::Singles[ "Pickup" ] = "FlagPickup";
$Convert::Singles[ "Drop" ] = "FlagDrop";
$Convert::Singles[ "Return" ] = "FlagReturn";
$Convert::Singles[ "StandoffReturn" ] = "FlagStandoffReturn";
$Convert::Singles[ "Assist" ] = "FlagAssist";
$Convert::Singles[ "Cap" ] = "FlagCap";

function Stats::ToStatSheet::KillDeathPair( %ident, %type ) {
	$Collector::Kills[ %ident, %type ] = $Stats::Totals[ %ident, "Kills" @ %type ];
	$Collector::Kills[ %ident ] += $Stats::Totals[ %ident, "Kills" ];
	$Collector::Deaths[ %ident, %type ] = $Stats::Totals[ %ident, "Deaths" @ %type ];
	$Collector::Deaths[ %ident ] += $Stats::Totals[ %ident, "Deaths" ];
}

function Stats::ToStatSheet() {
	deleteVariables( "$Collector::*" );

	$Collector::missionName = $Stats::mission;
	$Collector::Duration = $Stats::duration;

	L::Clear( "teamlist-1" );
	L::Clear( "teamlist0" );
	L::Clear( "teamlist1" );

	%count = L::Reset( Stats::Prefix( "playerlist" ) );
	for ( %i = 0; %i < %count; %i++ ) {
		// playername
		%ident = L::GetNext( Stats::Prefix( "playerlist" ) );

		// get team and flag time
		for ( %team = -1; %team <= 1; %team++ ) {
			$Collector::timeplayer[ %ident, %team ] = $Stats::Totals[ %ident, "teamtime" @ %team ];
			$Collector::timeflag[ %team, %ident ] = $Stats::Totals[ %ident, "flagtime" @ %team ];
		}
		
		// figure out the main team
		%mainteam = -1;
		if ( $Collector::timeplayer[ %ident, 0 ] >  $Collector::timeplayer[ %ident, 1 ] )
			%mainteam = 0;
		else if ( $Collector::timeplayer[ %ident, 1 ] >  $Collector::timeplayer[ %ident, 0 ] )
			%mainteam = 1;
		L::Push( "teamlist" @ %mainteam, %ident );

		// single items
		for ( %i = 0; $Convert::Singles[%i] != ""; %i++ ) {
			%type = $Convert::Singles[%i];
			%map = $Convert::Singles[%type];
			if ( %map == "" )
				%map = %type;
			evalf( "$Collector::%1s[\"%2\"] = \"%3\";", %type, %ident, $Stats::Totals[ %ident, %map ] );
		}

		// kill/death pairs
		for ( %i = 0; $Convert::Weapons[%i] != ""; %i++ )
			Stats::ToStatSheet::KillDeathPair( %ident, $Convert::Weapons[%i] );
		
		for ( %team = -1; %team <= 1; %team++ )
			$Collector::timeplayer[ Marker::Team(%mainteam), %team] += $Collector::timeplayer[%ident, %team];
	}

	// team totals
	for ( %team = 0; %team <= 1; %team++ ) {
		%marker = Marker::Team( %team );
		
		%flagtime = $Stats::Totals[ Marker::Team(%team), "flagtimeplayer" ];
		%fieldtime = $Stats::Totals[ Marker::Team(%team), "flagtimefield" ];
		%hometime = ( $Stats::duration - ( %flagtime + %fieldtime ) );
		
		// time
		$Collector::timeplayer[$Marker::Home, %team] = "-";
		$Collector::timeplayer[$Marker::Field, %team] = "-";
		$Collector::timeflag[%team,Marker::Team(%team^1)] += %flagtime;
		$Collector::timeflag[%team,$Marker::Home] += %hometime;
		$Collector::timeflag[%team,$Marker::Field] += %fieldtime;

		// singles
		for ( %i = 0; $Convert::Singles[%i] != ""; %i++ )
			evalf( "$Collector::%1s[\"%2\"] = \"%3\";", $Convert::Singles[%i], %marker, $Stats::Totals[ %marker, $Convert::Singles[%i] ] );

		for ( %i = 0; $Convert::Weapons[%i] != ""; %i++ )
			Stats::ToStatSheet::KillDeathPair( %marker, $Convert::Weapons[%i] );
	}

	export( "$Collector*", "stats/server.cs" );
	export( "$Stats*", "stats/server.cs", true );
	Exporter::ExportMap( "Server" );
	
	Stats::Reset( 2 ); // 2 dummy teams
}
