Event::Attach( eventConnected, Station::Reset );
Event::Attach( eventChangeMission, Station::CheckExit );
Event::Attach( eventLeaveServer, Station::CheckExit );
//Event::Attach( eventClientDied, Station::onClientDied );

function remoteEnterStation( %sv, %type ) {
	$Station::Type = %type;
	Event::Trigger( eventEnterStation, %type );
	
	pushActionMap( "inventoryMap.sae" );
}

function remoteExitStation( %sv, %type ) {
	$Station::Type = "";
	Event::Trigger( eventExitStation );
	
	popActionMap( "inventoryMap.sae" );
}

function Station::CheckExit() {
	if ( $Station::Type != "" )
		remoteExitStation();
}

function Station::onClientDied( %cl ) {
	if ( %cl == getManagerId() )
		Station::CheckExit();
}

function Station::Reset() {
	deleteVariables( "$Station*" );
}
