function menu::vote(%cl) {
	%waiting = $Server::TourneyMode && (!$CountdownStarted && !$matchStarted);
	
	menu::new("Options", "vote", %cl);
	menu::add("Change Teams", "changeteams", %cl, (!$loadingMission) && (!$matchStarted || !$Server::TourneyMode) );
	menu::add("Vote to change mission", "vChangeMission", %cl);
	menu::add("Vote to enter FFA mode", "vcffa", %cl, $Server::TourneyMode );
	menu::add("Vote to start the match", "vsmatch", %cl, %waiting );
	menu::add("Vote to enter Tournament mode", "vctourney", %cl, !$Server::TourneyMode );
	menu::add("Admin Options...", "adminoptions", %cl, (%cl.adminLevel > 0) );
}

function processMenuVote( %cl, %selection ) {
	if(%selection == "changeteams") {
         menu::changeteams( %cl );
		 return;
	} else if(%selection == "vsmatch") {
         admin::startvote(%cl, "start the match", "smatch", 0);
    } else if(%selection == "vetd") {
         admin::startvote(%cl, "enable team damage", "etd", 0);
    } else if(%selection == "vdtd") {
         admin::startvote(%cl, "disable team damage", "dtd", 0);
    } else if(%selection == "vcffa") {
         admin::startvote(%cl, "change to Free For All mode", "ffa", 0);
    } else if(%selection == "vctourney") {
         admin::startvote(%cl, "change to Tournament mode", "tourney", 0);
    } else if(%selection == "vChangeMission") {
         %cl.madeVote = true;
         menu::changemissiontype( %cl, 0 );
         return;
    } else if(%selection == "adminoptions") {
	   //no need to add, falls through to Game::menu request anyway
    }

	Game::menuRequest(%cl);
}
