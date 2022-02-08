function menu::timelimit( %cl ) {
	menu::new("Change Time Limit", "changeTimeLimit", %cl);

	menu::add( "10 minutes", 10, %cl );
	menu::add( "15 minutes", 15, %cl );
	menu::add( "20 minutes", 20, %cl );
	menu::add( "25 minutes", 25, %cl );
	menu::add( "30 minutes", 30, %cl );
	menu::add( "45 minutes", 45, %cl );
	menu::add( "60 minutes", 60, %cl );
	menu::add( "No time limit", 0, %cl );	
}

function processMenuChangeTimeLimit( %cl, %opt ) {
	remoteSetTimeLimit( %cl, %opt );
}

function remoteSetTimeLimit( %cl, %time ) {
	%time = floor( %time );
	if( %time == $Server::timeLimit || (%time != 0 && %time < 1) )
		return;

	if ( !%cl.canChangeTimeLimit )
		return;

	log::add( %cl, "changed time limit to " @ %time, "", "", "TimeChanges" );
	
	$Server::timeLimit = %time;
	if(%time)
		message::all(0, Client::getName(%cl) @ " changed the time limit to " @ %time @ " minute(s).");
	else
		message::all(0, Client::getName(%cl) @ " disabled the time limit.");
}
