function menu::stripadmin( %cl, %vic ) {
	menu::new( "Strip Adminship", "stripadmin", %cl );

	menu::add( "Strip " @ Client::getName(%vic), "strip " @ %vic, %cl );
	menu::add( "Cancel", "no", %cl );
}

function processMenuStripAdmin( %cl, %opt ) {
	%action = getWord(%opt, 0);
	%vic = getWord(%opt, 1);

	if(%action == "strip") {
		if ( %cl.adminLevel > %vic.adminLevel ) {
			if ( %vic.adminLevel ) {
				adminlevel::grant( %vic, 0 );
				log::add( %cl, "Stripped Admin from", %vic, "", "Admins" );

				%vic.registeredName = "Stripped by " @ %cl.registeredName;	     
			}
		}
		else {
			log::add( %cl, "tried to strip Admin from", %vic, "", "Admins" );
			Client::sendMessage(%cl, $MSGTypeSystem, "You do not have the power to strip " @ Client::getName(%vic) @ ".");
			Client::sendMessage(%vic, $MSGTypeGame, Client::getName(%cl) @ " tried to strip your adminship.");
		}
	}
	Game::menuRequest(%cl);
}
