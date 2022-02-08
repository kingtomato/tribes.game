// this has to be done in script because zoom events are saved to demos and we 
// can't alter how that's handled for backward compat reasons

Event::Attach( eventConnectionAccepted, Zoom::onJoin );
Event::Attach( eventClientDied, Zoom::onClientDied );

function Zoom::onJoin() {
	// T1 zoom defaults to at 5x
	$Zoom::Zoom = 1; 
	Zoom::Reset();
}

function Zoom::In() {
	postAction( 2048, IDACTION_SNIPER_FOV, 1 );
}

function Zoom::Out() {
	postAction( 2048, IDACTION_SNIPER_FOV, 0 );

	if( $pref::resetZoom )
		Zoom::Reset();
}

function Zoom::Cycle() {
	postAction( 2048, IDACTION_INC_SNIPER_FOV, 1 );
	if( $Zoom::Zoom < 3 )
		$Zoom::Zoom++;
	else
		$Zoom::Zoom = 0;
}

function Zoom::Reset() {
	if ( !$pref::resetZoom )
		return;

	$pref::defaultZoom = clamp( $pref::defaultZoom, 0, 3 );
	while( $Zoom::Zoom != $pref::defaultZoom )
		Zoom::Cycle();
}

function Zoom::onClientDied( %cl ) {
	if ( %cl == getManagerId() )
		Zoom::Reset();
}