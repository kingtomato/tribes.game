function menu::self( %cl ) {
	menu::new( "Options", "self", %cl );
	menu::add( "Change Teams", "changeteams", %cl, (!$loadingMission) && (!$matchStarted || !$Server::TourneyMode) );
	//menu::add( "Vote to admin yourself", "vadminself", %cl, !%cl.adminLevel );
}

function processMenuSelf( %cl, %selection ) {
    if(%selection == "changeteams") {
        menu::ChangeTeams(%cl);
    } else if ( %selection == "vadminself" ) {
         %cl.voteTarget = true;
         admin::startvote(%cl, "admin " @ Client::getName(%cl), "admin", %cl);
		 Game::menuRequest(%cl);
    }
}