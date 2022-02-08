Event::Attach( eventConnected, Demo::onConnected );
Event::Attach( eventLeaveServer, Demo::onLeaveServer );

$Demo::Count = -1;
$Demo::Scale[$Demo::Count++] = 0.000000000;
$Demo::Scale[$Demo::Count++] = 0.00390625;
$Demo::Scale[$Demo::Count++] = 0.0078125;
$Demo::Scale[$Demo::Count++] = 0.015625;
$Demo::Scale[$Demo::Count++] = 0.03125;
$Demo::Scale[$Demo::Count++] = 0.0625;
$Demo::Scale[$Demo::Count++] = 0.125;
$Demo::Scale[$Demo::Count++] = 0.25;
$Demo::Scale[$Demo::Count++] = 0.5;
$Demo::Scale[$Demo::Count++] = 1;
$Demo::NormalSpeed = $Demo::Count;
$Demo::Scale[$Demo::Count++] = 2;
$Demo::Scale[$Demo::Count++] = 3;
$Demo::Scale[$Demo::Count++] = 4;
$Demo::Scale[$Demo::Count++] = 5;
$Demo::Scale[$Demo::Count++] = 6;
$Demo::Scale[$Demo::Count++] = 8;
$Demo::Scale[$Demo::Count++] = 10;
$Demo::Scale[$Demo::Count++] = 12;
$Demo::Scale[$Demo::Count++] = 14;
$Demo::Scale[$Demo::Count++] = 16;
$Demo::Scale[$Demo::Count++] = 20;
$Demo::Scale[$Demo::Count++] = 24;
$Demo::Scale[$Demo::Count++] = 28;
$Demo::Scale[$Demo::Count++] = 32;
$Demo::Scale[$Demo::Count++] = 36;

function Demo::onConnected() {
	if ( !$playingDemo )
		return;
	
	Demo::SpeedControl( "normal" );
	pushActionMap( "demoMap.sae" );
}

function Demo::onLeaveServer() {
	if ( !$playingDemo )
		return;
	
	Demo::SpeedControl( "normal" );
	popActionMap( "demoMap.sae" );
}


function Demo::SpeedControl( %fn ) {
	if ( !$playingDemo )
		return;

	switch ( %fn ) {
		case "pause": $Demo::CurrentScale = 0; break;
		case "sd": $Demo::CurrentScale--; break;
		case "ff": $Demo::CurrentScale++; break;
		case "normal":
		default: $Demo::CurrentScale = $Demo::NormalSpeed; break;
	}

	$Demo::CurrentScale = clamp( $Demo::CurrentScale, 0, $Demo::Count );
	$SimGame::TimeScale = $Demo::Scale[ $Demo::CurrentScale ];
}
