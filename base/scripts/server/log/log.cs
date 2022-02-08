function log::add( %cl, %action, %recipient, %prefix, %type ) {
	if ( !$Server::Log[ %type ] )
		return;
	
	%action = " " @ %action;
	if ( %prefix == "" )
		%prefix = " ";

	switch( %cl ) {
		case "-1":
			%name = string::rpad("VOTERS", 16) @ "]";
			%sysname = " VOTERS";
			%ip = " {}";
			break;
		case "-2":
			%name = string::rpad("System", 16) @ "]";
			%sysname = " System";
			%ip = " {}";
			break;
		default:
			%name = string::rpad(%cl.registeredName, 16) @ "]";
			%sysname = " " @ Client::getName(%cl);
			%ip = " {" @ Client::getTransportAddress(%cl) @ "}";
			break;
	}

	if (%recipient) {
		%recipientName =	" " @ Client::getName(%recipient);
		%recipientIp = " {" @ Client::getTransportAddress(%recipient) @ "}";	  
	}

	$LogEntry = string::rpad("[" @ %prefix @ " " @ %name @ %sysname @ %action @ %recipientName, 100); 
	$LogEntry = $LogEntry @ string::rpad(":" @ %sysname @ %ip, 45); 
	$LogEntry = $LogEntry @ string::rpad("| " @ %recipientName @ %recipientIP, 45); 
	$LogEntry = "[" @ timestamp::format() @ "] " @ $LogEntry @ " : " @ $MissionName;

	export( "LogEntry", "serverlogs/" @ $Server::LogFile, true );
}