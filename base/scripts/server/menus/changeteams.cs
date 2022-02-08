function menu::changeteams( %cl ) {
    menu::new( "Change Teams", "changeteams", %cl );

	menu::add("Observer", -2, %cl);
	menu::add("Automatic", -1, %cl);
	
	if ( $Game::MissionType != "Rabbit" ) {
		for( %i = 0; %i < getNumTeams(); %i++ )
	   		menu::add( getTeamName(%i), %i, %cl );
	}
}

function processMenuChangeTeams( %cl, %team, %admincl ) {
	if ( $loadMission )
		return;

	checkPlayerCash( %cl );

    if ( ( %team != -1 && ( %team == Client::getTeam(%cl) || %team >= getNumTeams() ) ) )
         return;
    
    if ( $Game::MissionType == "Rabbit" && ( %team > -1 ) )
    	return;

    if( %cl.observerMode == "justJoined" ) {
         %cl.observerMode = "";
         message::centerprint(%cl, "");
    }

	if( ( !$matchStarted || !$Server::TourneyMode || %admincl ) && %team == -2 ) {
		if ( Observer::enterObserverMode(%cl) ) {
			%cl.notready = "";

			if(%admincl == "") 
				message::all(0, Client::getName(%cl) @ " became an observer.");
			else
				message::all(0, Client::getName(%cl) @ " was forced into observer mode by " @ Client::getName(%admincl) @ ".");

			Game::resetScores(%cl);	
			Game::refreshClientScore(%cl);
			ObjectiveMission::refreshTeamScores();
		}
		
		return;
	}

	//automatic team
	if (%team == -1) {
		%origteam = Client::getTeam( %cl );
		Game::assignClientTeam( %cl );
		%team = Client::getTeam( %cl );
		if ( %team == %origteam )
			return;
	}

    %player = Client::getOwnedObject( %cl );
	if ( %player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) ) {
		playNextAnim( %cl );
		Player::kill( %cl );
	}

    %cl.observerMode = "";

    if(%admincl == "")
         message::all(0, Client::getName(%cl) @ " changed teams.");
    else
         message::all(0, Client::getName(%cl) @ " was teamchanged by " @ Client::getName(%admincl) @ ".");

    GameBase::setTeam( %cl, %team );
    Event::Trigger( eventServerClientJoinTeam, %cl, %team );
    %cl.teamEnergy = 0;
	Client::clearItemShopping( %cl );
	if ( Client::getGuiMode(%cl) != 1 )
		 Client::setGuiMode( %cl,1 );
	Client::setControlObject( %cl, -1 );

    Game::playerSpawn( %cl, false );
	%team = Client::getTeam( %cl );
	if ( $TeamEnergy[%team] != "Infinite" )
		 $TeamEnergy[%team] += $InitialPlayerEnergy;
    if ( $Server::TourneyMode && !$CountdownStarted ) {
         message::bottomprint(%cl, "<f1><jc>Press FIRE when ready.", 0);
         %cl.notready = true;
    }

    ObjectiveMission::refreshTeamScores();
}
