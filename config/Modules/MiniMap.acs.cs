function MiniMap::onComputeWidthZoom( %canvasSize, %missionSize ) {
	%canvasWidth = getWord( %canvasSize, 0 );
	%canvasHeight = getWord( %canvasSize, 1 );
	%missionWidth = getWord( %missionSize, 0 );
	%missionHeight = getWord( %missionSize, 0 );
	
	$pref::MiniMapWidth = min( %canvasWidth, %canvasHeight ) * 0.28;
	$pref::MiniMapZoom = 1050 / min( %missionWidth, %missionHeight );
}

