function admin::alert( %message ) {
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) ) {
		if ( %cl.canReceiveAlerts )
			message::bottomprint( %cl, "<jc>" @ %message );
	}
}

function admin::formatip( %ip, %numWords, %stringSize, %fillEmptySlots ) {
	%words = %chars = 0;

	if ( String::findSubStr(%ip, "LOOPBACK") != -1 )
		return "LOOPBACK";

	%fmtip = "";
	while ( ( %words <= %numWords ) && ( %chars <= %stringSize ) ) {
		%char = String::getSubStr( %ip, %chars, 1 );
		if ( ( %char == "." ) || ( %char == ":" ) )
			%words++;
		
		%chars++;
	}
	%fmtip = String::getSubStr( %ip, 0, %chars );

	if ( %fillEmptySlots ) {
		%slots = ( 4 - %words );
		for ( %slot = 0; %slot <= %slots; %slot++ ) {
			%fmtip = %fmtip @ "xxx";
			if ( %slot < %slots )
				%fmtip = %fmtip @ ".";
		}
	}
	
	return ( %fmtip );
}

function admin::parseip( %cl, %numWords, %stringSize, %fillEmptySlots ) {
	return ( admin::formatip( Client::getTransportAddress(%cl), %numWords, %stringSize, %fillEmptySlots ) );
}

function admin::dumpplayerlist( %cl ) {
	%separator = String::Dup( "_", 70 );
	if ( %cl )
		Client::sendMessage( %cl, $MSGTypeCommand, %separator );
	else
		echo( %separator );

	for ( %cl2 = Client::getFirst(); %cl2 != -1; %cl2 = Client::getNext(%cl2) ) {
		if ( %cl2.adminLevel < 1 ) { 
			%admin = "##";
			%smurf = "";
		} else { 
			%admin = String::getSubStr(adminlevel::getname(%cl2.adminLevel), 0, 1) @ "A";
			%smurf = "/" @ %cl2.registeredName;
		}

		%clId = string::rpad(%cl2, 6);
		%admin = string::rpad(%admin, 4);
		%score = string::rpad("Score: " @ %cl2.score, 12);
		%tks = string::rpad("TKs: " @ %cl2.TKs, 9); 
		%ip = string::rpad(admin::parseip(%cl2, 4, 18, false), 19);
		%name = Client::getName(%cl2) @ %smurf;

		if ( %cl )
			Client::sendMessage( %cl, $MSGTypeCommand, %clId @ %admin @ %tks @ %score @ %ip @ %name );
		else
			echo( %admin @ %tks @ %score @ %ip @ %name );
	}

	if( %cl )
		Client::sendMessage( %cl , $MSGTypeCommand, %separator );
	else
		echo( %separator );
}