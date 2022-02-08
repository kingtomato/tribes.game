function TV::Activate( %cl ) {
	if ( PSC::getControlMode() != "playing" )
		return;
	
	if( Client::getName(%cl) == "" ) {
		remoteBP( 2048, "<JC><F1>Illegal client, unable to observe!", 2 );
		return;
	}

	// Delete the entire CommandGui
	if( isObject( "CommandGui" ) )
		renameObject( "CommandGui", "_CommandGui" );

	// Add CMDObserve if it isn't there..
	if ( !isObject( "playGui/ObsTV" ) )
		addToSet( "playGui", newObject( "ObsTV", FearGui::CMDObserve, 0, 0, 1, 1 ) );
	CmdObserve::setFocus( "playGui/ObsTV" );

	// Go to CommandMode
	remoteEval( 2048, CommandMode );

	// Force full bandwidth
	RemoteEval( 2048, "scom", -1 );

	// Turn off the cursor
	Schedule::Add( "CursorOff(mainwindow);", 0.3 );

	// Enable observer mode
	Client::ToggleCmdObserver( "True" );

	// Observe flag-carrier or team-mate
	Client::cmdObservePlayer( %cl );

	// Show who we are obsing
	remoteBP( 2048, "<JC><F1>Observing: <F2>" @ String::escapeFormatting( Client::getName( %cl ) ), 999 );
}

function TV::DeActivate() {
	if ( PSC::getControlMode() != "commander" )
		return;

	Client::ToggleCmdObserver( "False" );
	remoteEval( 2048, PlayMode );

	if ( isObject( "playGui/ObsTV" ) )
		deleteObject( "playGui/ObsTV" );
	if ( isObject( "_CommandGui" ) )
		renameObject( "_CommandGui", "CommandGui" );

	remoteBP( 2048, "", 0 );
}

function TV::onFlagTaken( %team, %cl ) {
	%self = getManagerId();

	if ( ( %self != %cl ) && ( Client::getTeam( %self ) == Client::getTeam( %cl ) ) )
		$TV::Carrier = %cl;
}

Event::Attach( eventFlagGrab, TV::onFlagTaken );
Event::Attach( eventFlagPickup, TV::onFlagTaken );