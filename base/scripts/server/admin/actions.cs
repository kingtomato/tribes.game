function admin::startmatch( %cl ) {
	if ( ( %cl != -1 ) && ( !%cl.canForceMatchStart ) )
		return;
	
	if( $CountdownStarted || $matchStarted )
		return;
	
	if( %cl == -1 )
		message::all( 0, "Match start countdown forced by vote." );
	else
		message::all( 0, "Match start countdown forced by " @ Client::getName(%cl) );

	Game::ForceTourneyMatchStart();
}


function admin::setteamdamage( %cl, %enabled ) {
	if( %cl != -1 && !%cl.canSwitchTeamDamage )
		return;
	
	if ( %enabled ) {
		$Server::TeamDamageScale = 1;
		%status = "ENABLED";
	} else {
		$Server::TeamDamageScale = 0;
		%status = "DISABLED";
	}

	if ( %cl == -1 ) {
		message::all(0, "Team damage set to " @ %status @ " by consensus.");
	} else {
		message::all( 0, Client::getName(%cl) @ " " @ %status @ " team damage." );
		log::add( %cl, %status @ " Team Damage", "", "", "TeamDamage" );
	}
}

function admin::kick( %cl, %tgt, %ban ) {
	if ( ( %cl == %tgt ) || ( %cl != -1 && !%cl.adminLevel ) )
		return;
	
	%name = Client::getName(%tgt);
	%ip = Client::getTransportAddress(%tgt);
	if(%ip == "")
		return;

	if ( %ban && !%cl.canBan )
		return;
         
	if(%ban) {
		%word = "banned";
		%cmd = "BAN: ";
		%desc = " ban ";
	} else {
		%word = "kicked";
		%cmd = "KICK: ";
		%desc = " kick ";
	}

	if ( %tgt.adminLevel > 0 ) {
		if ( %cl == -1 && ( %tgt.adminLevel > adminlevel::get("Public Admin") ) ) {
			// only public admins can be kicked by vote
			message::all( 0, Client::getName(%tgt) @ "is an admin and can't be " @ %word @ " by vote." );
			return;
		} else if ( %cl.adminLevel <= %tgt.adminLevel ) {
			//you must be higher level than the other admin to kick/ban him
			Client::sendMessage( %cl, $MSGTypeSystem, "You do not have the power to" @ %desc @ Client::getName(%tgt)@"." );
			Client::sendMessage( %tgt, $MSGTypeGame, Client::getName(%cl) @ " just tried to" @ %desc @ "you." );
			log:add( %cl, "attempted to" @ %desc, %tgt, "", "KickBan" );
			return;
		}
	}

	BanList::add( %ip, ( %ban ) ? $Server::BanTime : $Server::KickTime );

    log::add( %cl, %word, %tgt, "", "KickBan" );
	log::add( %cl, %word, %tgt, "@", "KickBan" );

	if ( %cl == -1 ) {
		message::all(0, %name @ " was " @ %word @ " from vote.");
		Net::kick(%tgt, "You were " @ %word @ " by consensus.");
	} else {
		message::all(0, %name @ " was " @ %word @ " by " @ Client::getName(%cl) @ ".");
		Net::kick(%tgt, "You were " @ %word @ " by " @ Client::getName(%cl));
	}
}

function admin::setffamode( %cl ) {
	if ( !$Server::TourneyMode || ( %cl != -1 && !%cl.canChangeGameMode ) )
		return;

	if( %cl == -1 ) {
		message::all( 0, "Server switched to Free-For-All Mode." );
	} else {
		message::all( 0, "Server switched to Free-For-All Mode by " @ Client::getName(%cl) @ "." );
		log::addlog( %cl, "switched to FFA Mode.", "", "", "ModeChange" );
	}
	
	$Server::TourneyMode = ( false );
	message::centerprintall(); // clear the messages
	if( !$matchStarted && !$countdownStarted ) {
		if ( $Server::warmupTime )
			Server::Countdown($Server::warmupTime);
		else   
			Game::startMatch();
	}
}


function admin::settourneymode( %cl ) {
	if ( $Server::TourneyMode || ( %cl != -1 && !%cl.canChangeGameMode ) )
		return;

	$Server::TeamDamageScale = 1;
	
	if( %cl == -1 ) {
		message::all( 0, "Server switched to Tournament Mode." );
	} else {
		message::all(0, "Server switched to Tournament Mode by " @ Client::getName(%cl) @ ".");
		log::add( %cl, "switched to Tournament Mode.", "", "", "ModeChange" );
	}

	$Server::TourneyMode = true;
	Server::nextMission();
}
