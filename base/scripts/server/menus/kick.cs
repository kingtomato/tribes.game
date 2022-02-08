function menu::kickban( %cl, %vic ) {
    menu::new( "Boot " @ Client::getName(%vic), "kick", %cl );

	menu::add( "Kick " @ Client::getName(%vic), "kick " @ %vic, %cl, %cl.canKick );
	menu::add( "Ban " @ Client::getName(%vic), "ban " @ %vic, %cl, %cl.canBan );
	menu::add( "PermBan " @ admin::parseip(%vic, 4, 18, true), "fullIP " @ %vic, %cl, %cl.canPermanentBan );
	menu::add( "PermBan " @ admin::parseip(%vic, 3, 14, true), "threeOctet " @ %vic, %cl, %cl.canPermanentBan );
	menu::add( "PermBan " @ admin::parseip(%vic, 2, 10, true), "twoOctet " @ %vic, %cl, %cl.canPermanentBan );
	menu::add( "Cancel ", "cancel", %cl );
}

function processMenuKick( %cl, %opt ) {
	%action = getWord( %opt, 0 );
	%vic = getWord( %opt, 1 );
	 
	if (%action == "cancel") {
	   Game::menuRequest( %cl );
	   return;
	}
		
	menu::new( "Boot " @ Client::getName(%vic) @ ", you sure?", "kick4real", %cl );

	menu::add( "Kick " @ Client::getName(%vic), %opt @ " yes", %cl, %action == "kick" );
	menu::add( "Ban " @ Client::getName(%vic), %opt @ " yes", %cl, %action == "ban" );
	menu::add( "PermBan " @ admin::parseip(%vic, 4, 18, true), %opt @ " yes", %cl, %action == "fullIP" );
	menu::add( "PermBan " @ admin::parseip(%vic, 3, 14, true), %opt @ " yes", %cl, %action == "threeOctet" );
	menu::add( "PermBan " @ admin::parseip(%vic, 2, 10, true), %opt @ " yes", %cl, %action == "twoOctet" );
	menu::add( "Cancel ", %opt @ " cancel", %cl );
}

function processMenuKick4Real( %cl, %opt ) {
	%action = getWord( %opt, 0 );
	%recipient = getWord( %opt, 1 );
	%affirm = getWord( %opt, 2 );

	if ( %affirm != "yes" ) {
		Game::menuRequest(%cl);
		return;
	}

	if (%action == "kick")
		admin::kick( %cl, %recipient, false );
	else if(%action == "ban")
		admin::kick( %cl, %recipient, true );
	else if (%action == "fullIP")
		banlist::permaban( %cl, %recipient, 4, 18, false );
	else if (%action == "threeOctet")	   
		banlist::permaban( %cl, %recipient, 3, 14, false );
	else if (%action == "twoOctet")
		banlist::permaban( %cl, %recipient, 2, 10, false );

	Game::menuRequest(%cl);
}
