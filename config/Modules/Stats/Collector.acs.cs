Event::Attach( eventConnectionAccepted, Collector::Clear );
Event::Attach( eventMatchStarted, Collector::onStart );
Event::Attach( eventChangeMission, Collector::onStop );
Event::Attach( eventLeaveServer, Collector::onStop );

Event::Attach( eventClientJoin, Collector::onPlayerJoin );
Event::Attach( eventClientDrop, Collector::onPlayerDrop );
Event::Attach( eventClientChangeTeam, Collector::onPlayerChange );

Event::Attach( eventClientScoreAdd, Collector::onClientScoreAdd );

Event::Attach( eventFlagGrab, Collector::onFlagGrab );
Event::Attach( eventFlagPickup, Collector::onFlagPickup );
Event::Attach( eventFlagDrop, Collector::onFlagDrop );
Event::Attach( eventFlagReturn, Collector::onFlagReturn );
Event::Attach( eventFlagStandoffReturn, Collector::onFlagStandoffReturn );
Event::Attach( eventFlagCap, Collector::onFlagCap );
Event::Attach( eventFlagAssist, Collector::onFlagAssist );
Event::Attach( eventFlagDrop, Collector::onFlagDrop );
Event::Attach( eventFlagCarrierKill, Collector::onFlagCarrierKill );

Event::Attach( eventClientKilled, Collector::onClientKilled );
Event::Attach( eventClientTeamKilled, Collector::onClientTeamKilled );
Event::Attach( eventClientSuicided, Collector::onClientSuicided );

$Marker::Player = "playerteam";
$Marker::Flag = "statflag";

function Collector::Clear() {
	deleteVariables( "$Collector*" );
	stack::clear( "playerlist" );
	TimeC::Clear( $Marker::Flag );
	TimeC::Clear( $Marker::Player );
}

function Collector::onStart() {
	Collector::Clear();
	
	$Collecting = true;
	$Collector::Manager = Client::getName( getManagerId() );
	$Collector::Start = getSimTime();
	$Collector::MissionName = $ServerMission;
	$Collector::TeamScore[0] = 0;
	$Collector::TeamScore[1] = 0;
	
	TimeC::Update( $Marker::Flag ~ "0", $Marker::Home );
	TimeC::Update( $Marker::Flag ~ "1", $Marker::Home );
	Collector::InitPlayers();
}

function Collector::onStop() {
	if ( !$Collecting )
		return;
	
	$Collector::Stop = getSimTime();
	$Collector::Duration = ( $Collector::Stop - $Collector::Start );

	export( "$Collect*", "stats/collect.cs" );
	
	// finalize flag times
	TimeC::Update( $Marker::Flag ~ "0", $Marker::Home );
	TimeC::Update( $Marker::Flag ~ "1", $Marker::Home );

	Collector::ConstructFinalizeTeamLists();
	Exporter::ExportMap( $Collector::Manager );
	
	$Collecting = false;
	export( "$*", "stats/out.cs" );
}

function Collector::InitPlayers() {
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext( %cl ) ) {
		%name = Client::getName( %cl );
		$Collector::Score[ %name ] = 0;
		TimeC::Update( $Marker::Player@%name, Client::getTeam(%cl) );
		Stack::PushUnique( "playerlist", %name );
	}
}

function Collector::ConstructFinalizeTeamLists() {
	Stack::Clear( "teamlist-1");
	Stack::Clear( "teamlist0" );
	Stack::Clear( "teamlist1" );

	deleteVariables( "$Collector::time*" );

	// get home/field times
	for ( %team = 0; %team <= 1; %team++ ) {
		$Collector::timeflag[%team, $Marker::Home] = TimeC::Duration( $Marker::Flag @ ( %team ), $Marker::Home );
		$Collector::timeflag[%team, $Marker::Field] = TimeC::Duration( $Marker::Flag @ ( %team ), $Marker::Field );
	}

	// finalize all the player team/flag times
	Stack::Reset( "playerlist" );
	for ( %i = 0; %i < stack::count( "playerlist" ); %i++ ) {
		%name = Stack::GetNext( "playerlist" );

		// finalize the team time
		TimeC::Update( $Marker::Player@%name, -1 );

		echo( %name );
		for ( %team = -1; %team <= 1; %team++ ) {
			$Collector::timeplayer[%name, %team] = TimeC::Duration( $Marker::Player @ %name, %team );
			echo( $Collector::timeplayer[%name, %team] );
		}
		
		// See which team this player most likely belongs to based on time spent on the team
		%team = -1;
		if ( ( $Collector::timeplayer[%name, 0] * 50 ) > ( $Collector::timeplayer[%name, 1] * 50 ) )
			%team = 0;
		else if ( ( $Collector::timeplayer[%name, 1] * 50 ) > ( $Collector::timeplayer[%name, 0] * 50 ) )
			%team = 1;

		$Collector::timeflag[ %team ^ 1, %name ] = TimeC::Duration( $Marker::Flag @ ( %team ^ 1 ), %name );

		// add player time to team totals
		Stack::Push( "teamlist" @ %team, %name );
		for ( %j = 0; %j <= 1; %j++ ) {
			$Collector::timeplayer[$Marker::Home, %j] = "-";
			$Collector::timeplayer[$Marker::Field, %j] = "-";
			$Collector::timeplayer[Marker::Team(%team), %j] += $Collector::timeplayer[%name, %j];
			$Collector::timeflag[%j,Marker::Team(%team)] += TimeC::Duration( $Marker::Flag @ ( %j ), %name );
		}
	}
}


function Collector::onPlayerJoin( %cl) {
	%name = Client::getName( %cl );
	%team = Client::getTeam( %cl );
	
	$Collector::Score[ %name ] += 0;
	TimeC::Update( $Marker::Player @ %name, %team );
	Stack::PushUnique( "playerlist", %name );
}

function Collector::onPlayerDrop( %cl ) {
	TimeC::Update( $Marker::Player@Client::getName( %cl ), -2 );
}

function Collector::onPlayerChange( %cl, %newteam ) {
	TimeC::Update( $Marker::Player@Client::getName( %cl ), %newteam );
}


function Collector::onClientScoreAdd( %cl, %scoreAdd ) {
	%name = Client::getName( %cl );
	$Collector::Score[%name] += %scoreAdd;
	$Collector::Score[ Marker::Team( Client::getTeam( %cl ) ) ] += %scoreAdd;
}

function Collector::onFlagGrab( %team, %cl ) {
	%name = Client::getName( %cl );
	TimeC::Update( $Marker::Flag @ %team, %name );
	$Collector::Grabs[%name]++;
	$Collector::Grabs[Marker::Team( %team ^ 1 )]++;

}

function Collector::onFlagPickup( %team, %cl ) {
	%name = Client::getName( %cl );
	TimeC::Update( $Marker::Flag @ %team, %name );
	$Collector::Pickups[%name]++;
	$Collector::Pickups[Marker::Team( %team ^ 1 )]++;
}

function Collector::onFlagReturn( %team, %cl ) {
	TimeC::Update( $Marker::Flag @ %team, $Marker::Home );
	if ( !%cl )
		return;

	%name = Client::getName( %cl );
	$Collector::Returns[%name]++;
	$Collector::Returns[Marker::Team( %team )]++;
}

function Collector::onFlagStandoffReturn( %team, %cl ) {
	if ( !%cl )
		return;

	%name = Client::getName( %cl );
	$Collector::StandoffReturns[%name]++;
	$Collector::StandoffReturns[Marker::Team( %team )]++;
}

function Collector::onFlagCap( %team, %cl ) {
	%name = Client::getName( %cl );

	TimeC::Update( $Marker::Flag @ %team, $Marker::Home );

	$Collector::Caps[%name]++;
	$Collector::Caps[Marker::Team( %team ^ 1 )] += 1;
}


function Collector::onFlagAssist( %cl ) {
	%name = Client::getName( %cl );
	%team = Client::getTeam( %cl ) ^ 1;
	$Collector::Assists[%name]++;
	$Collector::Assists[Marker::Team( %team ^ 1 )] += 1;
}

function Collector::onFlagDrop( %team, %cl ) {
	%name = Client::getName( %cl );
	
	TimeC::Update( $Marker::Flag @ %team, $Marker::Field );

	$Collector::Drops[%name]++;
	$Collector::Drops[Marker::Team( %team ^ 1 )]++;
}

function Collector::onFlagCarrierKill( %killer ) {
	$Collector::CarrierKills[Client::getName( %killer )]++; 
	$Collector::CarrierKills[Marker::Team( Client::getTeam( %killer ) )]++;
}

function Collector::onClientKilled( %killer, %victim, %damageType ) {
	%killerteam = Client::getTeam( %killer );
	%victimteam = Client::getTeam( %victim );
	%killer = Client::getName( %killer );
	%victim = Client::getName( %victim );

	$Collector::Kills[ %killer ]++;
	$Collector::Kills[ %killer, %damageType ]++;
	$Collector::Kills[ %killer, %victim ]++;
	$Collector::Kills[ Marker::Team( %killerteam ) ]++;
	$Collector::Kills[ Marker::Team( %killerteam ), %damageType ]++;
	$Collector::Deaths[ %victim ]++;
	$Collector::Deaths[ %victim, %damageType ]++;
	$Collector::Deaths[ Marker::Team( %victimteam ) ]++;
	$Collector::Deaths[ Marker::Team( %victimteam ), %damageType ]++;
}

function Collector::onClientTeamKilled( %killer, %victim, %damageType ) {
	%killerteam = Client::getTeam( %killer );
	%victimteam = Client::getTeam( %victim );
	%killer = Client::getName( %killer );
	%victim = Client::getName( %victim );
	
	$Collector::TeamKills[ %killer ]++;
	$Collector::TeamKills[ Marker::Team( %killerteam ) ]++;
	$Collector::TeamDeaths[ %victim ]++;
	$Collector::TeamDeaths[ Marker::Team( %victimteam ) ]++;
}

function Collector::onClientSuicided( %victim, %damageType ) {
	%victimteam = Client::getTeam( %victim );
	%victim = Client::getName( %victim );

	$Collector::Suicides[ %victim ]++;
	$Collector::Suicides[ Marker::Team( %victimteam ) ]++;
}

$Collecting = false;