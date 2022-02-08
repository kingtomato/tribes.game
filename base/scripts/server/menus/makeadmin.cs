function menu::makeadmin( %cl, %vic ) {
    menu::new("Bestow Admin", "makeadmin", %cl);

	for ( %i = 1; ( %i < $admin::levels ) && ( %i < %cl.adminLevel ); %i++ )
		menu::add( adminlevel::getname( %i ) @ " " @ Client::getName(%vic), "admin" @ " " @ %i @ " " @ %vic, %cl );
	menu::add( "Cancel ", "cancel " @ %vic, %cl );
}

function processMenuMakeAdmin( %cl, %opt ) {
	%action = getWord( %opt, 0 );
	%level = getWord( %opt, 1 );
	%vic = getWord( %opt, 2 );

	if ( %cl == %vic )
		return;

	if ( ( %action == "admin" ) && ( %cl.adminLevel > %level ) && ( %vic.adminLevel != %level ) ) {
		%vic.password = "NOPASSWORD";
		adminlevel::grant( %vic, %level );

		log::add( %cl, "Adminned", %vic, "", "Admins" );
		%adminabbrev = String::getSubStr( adminlevel::getname( %level ), 0, 1 ) @ "A";
		%vic.registeredName = %adminabbrev @ "." @ %cl.registeredName;

		%recipientMessage = "You are now an admin, courtesy of " @ Client::getName(%cl);
		%adminMessage = "Sent to " @ Client::getName(%vic) @ ": " @ %recipientMessage;

		message::bottomprint(%vic, "<jc>" @ %recipientMessage);
		message::bottomprint(%cl, "<jc>" @ %adminMessage);
		Client::sendMessage(%vic, $MSGTypeSystem, %recipientMessage);
	}

	Game::menuRequest(%cl);
}
