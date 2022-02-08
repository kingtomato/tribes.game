function menu::admin( %cl ) {
	%waiting = $Server::TourneyMode && (!$CountdownStarted && !$matchStarted);

    menu::new( "Options", "admin", %cl );

	menu::add( "Change Teams", "changeteams", %cl, !$loadingMission );
    menu::add( "Change mission", "changeMission", %cl, %cl.canChangeMission );
	menu::add( "Disable team damage", "dtd", %cl, (%cl.canSwitchTeamDamage && $Server::TeamDamageScale == 1) );
	menu::add( "Enable team damage", "etd", %cl, (%cl.canSwitchTeamDamage && !$Server::TeamDamageScale == 1) );
	menu::add( "Change to FFA mode", "cffa", %cl, (%cl.canChangeGameMode && $Server::TourneyMode) );
	menu::add( "Start the match", "smatch", %cl, (%cl.canForceMatchStart && %waiting) );
	menu::add( "Change to Tournament mode", "ctourney", %cl, (%cl.canChangeGameMode && !$Server::TourneyMode) );
	menu::add( "Set Time Limit", "ctimelimit", %cl, %cl.canChangeTimeLimit );
	menu::add( "Announce Server Takeover", "takeovermes", %cl, %cl.canAnnounceTakeover );
	menu::add( "Server Toggles...", "serverToggles", %cl );
	menu::add( "Vote options...", "voteOptions", %cl );
}

function processMenuAdmin( %cl, %selection ) {
	if(%selection == "changeteams") {
		menu::changeteams( %cl );
		return;
	} else if(%selection == "cffa") {
        admin::setffamode(%cl);
    } else if(%selection == "ctourney") {
         admin::settourneymode(%cl);
    } else if(%selection == "smatch") {
         admin::startmatch(%cl);
    } else if(%selection == "changeMission") {
         %cl.madeVote = ""; //for admins initiating mission change votes.
         menu::ChangeMissionType(%cl, 0);
         return;         
    }
    else if(%selection == "ctimelimit") {    
		 menu::TimeLimit(%cl);
         return;		 
    }
    else if(%selection == "takeovermes") {
         menu::AnnounceServerTakeover(%cl);    
    	 return;
	}
	else if(%selection == "etd") {
         admin::setteamdamage(%cl, true);
    } else if(%selection == "dtd") {
         admin::setteamdamage(%cl, false);
    } else if(%selection == "voteOptions") { 
	     menu::Vote(%cl);
		 return;
 	} else if(%selection == "serverToggles") { 
	     menu::ServerToggles(%cl);
		 return;
 	}

    Game::menuRequest(%cl);
}
