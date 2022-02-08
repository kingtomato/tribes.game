function admins::reset() {
	deletevariables( "$admin::admins*" );
	$admin::admins = 0;
}

function admin::addadmin( %registeredname, %password, %level ) {
	$admin::admins[ %password ] = true;
	$admin::admins[ %password, level ] = adminlevel::get( %level );
	$admin::admins[ %password, name ] = %registeredname;
	
	$admin::adminlist[ $admin::admins ] = %password;
	$admin::admins++;
}

function admin::findduplicateusers( %cl ) {
	%list[ 0 ] = %cl;
	%count = 0;
	
	if ( %cl.password == "" || %cl.password == "NOPASSWORD" )
		return;

	for ( %cl2 = Client::getFirst(); %cl2 != -1; %cl2 = Client::getNext( %cl2 ) ) {
		if ( ( %cl == %cl2 ) || ( %cl.password != %cl2.password ) )
			continue;

		%list[ %count++ ] = %cl2;
	}

	if ( %count ) {
		%alert = %cl.registeredName @ "\'s password is in use by : " @ String::escapeFormatting(Client::getName(%cl));
		for ( %i = 1; %i < %count; %i++ )
			%alert = %alert @ " & " @ String::escapeFormatting(Client::getName( %list[ %i ] ));
		admin::alert( %alert );
		log::add( -2, %alert, "", "", "Admins" );
	}
}

// owner ips
deletevariables( "$admin::owner*" );
$admin::owner[ "IP:127" ] = true;
$admin::owner[ "LOOPBA" ] = true;

function remoteAdminPassword( %cl, %password ) {
	%oldLevel = %cl.adminLevel;

	%owner = $admin::owner[ string::getsubstr( Client::getTransportAddress( %cl ), 0, 6 ) ];
	%valid = ( ( %password != "" ) && ( $admin::admins[ %password ] != "" ) );
	if ( %owner && ( %password != "" ) && !%valid )
		%owner = false;

	if ( !%owner && !%valid ) {
		%cl.registeredName = "";
		%cl.password = "";
		adminlevel::grant( %cl, 0 );
		return;
	 }

	adminlevel::grant( %cl, $admin::admins[ %password, level ] );
	%cl.registeredName = $admin::admins[ %password, name ];
	%cl.password = %password;

	schedule( "admin::findduplicateusers(" @ %cl @ ");", 5 );  //wait 5 seconds so we don't override the "has logged in" message sent to Uadmins.

	if (%cl.canSeePlayerlist)
		admin::dumpplayerlist();

	// allow admin to relogin to see player list without broadcasting alert or logging
	if ( %oldLevel != %cl.adminLevel ) {
		admin::alert( String::escapeFormatting(Client::getName(%cl)) @ " has logged in as " @ adminlevel::getname( %cl.adminLevel ) @ " using " @ %cl.registeredName @ "\'s password." );
		log::add( %cl, "activated his/her " @ adminlevel::getname( %cl.adminLevel ) @ " account.", "", "+", "Admins" );
	}
}


exec( "Server/adminpasswords.cs" );