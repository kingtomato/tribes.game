function iplog::getfile() {
	%date = string::getsubstr( timestamp::format(), 0, 10 );
	%name = "";
	for ( %i = 0; true; %i++ ) {
		%ch = string::getsubstr( $Server::HostName, %i, 1 );
		if ( %ch == "" )
			return ( "serverlogs/iplog-" @ %name @ "-" @ %date @ ".cs" );
		
		%res = string::icompare( %ch, "z" );
		if ( ( %res >= -42 && %res <= -33 ) || ( %res >= -25 && %res <= 0 ) )
			%name = %name @ %ch;
		else
			%name = %name @ "_";
	}
}

function iplog::add( %cl ) {
	%name = Client::getName( %cl );
	%ip = Client::getTransportAddress( %cl );
	if ( %name == "" )
		return;
	
	$iplog = string::rpad( timestamp::format(), 22 ) @ " Name: " @ string::rpad( %name, 22 ) @ " IP: " @ string::rpad( %ip, 30 );
	export( "$iplog", $iplog::file, true ); // append
}

$iplog::file = iplog::getfile();