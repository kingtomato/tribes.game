// SuperAdmin
Event::Attach(eventConnectionAccepted, SAD::onConnect);

function SAD( %pw ) {
	remoteEval( 2048, "AdminPassword", %pw );
}

function SAD::addServer( %ip, %pass, %servername ) {
	$SAD::Serverlist[ %ip, "SAD" ] = %pass;
	$SAD::Serverlist[ %ip, "Name" ] = %servername;
}

function SAD::addNick( %nick ) {
	$SAD::NickList[ %nick ] = %nick;
}

function SAD::onConnect() {
	$SAD::IP = String::Replace( $Server::Address, ":00", "" );
	$SAD::IP = String::Replace( $SAD::IP, ":01", "" );
	SAD::EnterSAD( true );
}

function SAD::EnterSAD( %enforceNick ) {
	if ( %enforceNick )
		if ( $SAD::NickList[$PCFG::Name] != $PCFG::Name )
			return;

	if ( $SAD::Serverlist[$SAD::IP, "Name"] != "" ) {
		echo("Logging into: " @ $SAD::ServerList[$SAD::IP, name] @ " with " @ $Sad::ServerList[$SAD::IP, sad]);
		SAD( $SAD::Serverlist[$SAD::IP, "SAD"] );
	}
}


// ADD YOUR SADS/VALID NICKS HERE
//SAD::addNick("YourNick");
//SAD::addServer("IP:127.0.0.1:28001", "YourPassword", "PlayTribes Dedicated");

