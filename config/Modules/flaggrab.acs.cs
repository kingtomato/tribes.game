function Flagpoop( %team, %cl ) {
	if ( %cl != getManagerId())
		return;
	remoteEval(2048, lmsg, "capobj");
	remoteBP( 2048, "<JC><F1>You Grabbed The Flag", 3 );
}

Event::Attach( eventFlagGrab, Flagpoop );
Event::Attach( eventFlagPickup, Flagpoop );
