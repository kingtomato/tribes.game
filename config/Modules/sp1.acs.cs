// Client fixes for Tribes 1.40.655
// Collected by Plasmatic
// www.annihilation.info
// More information at http://www.tribalwar.com/forums/showthread.php?t=630310
// and http://www.annihilation.info/forum/viewtopic.php?f=1&t=8595

echo("+++++++++++++++++++++++  Loading 1.40.655 Service Pack 1.0");


// Video Lag fix.
$pref::screensize = 1;

//Flag hud fix - Hunden/ Greyhound
function remoteTeamScore( %sv, %team, %score ) {
	$Team::Score[%team] = %score;
}

//Hud position fix - Hunden/ Greyhound
$HudMessupFix::DoExport = false;
function HudMessupFix::OnGuiOpen( %gui ) after Hud::OnGuiOpen {
	if ( %gui == "playGui" )
		$HudMessupFix::DoExport = true;
}
function HudMessupFix::OnExit() before Hud::OnExit 
{
	if($HudMessupFix::DoExport) //fine, don't halt
		return;	
	echo("Sucky behavior detected and prevented.");
	halt;
}

$pref:terrainlodamount = 0; 	// Default is 1. Decreases terrain warping at the expense of fps.
$pref::OpenGL::useMultiTexturing = "True"; 	// Increases fps on some cards.
$pref::OpenGL::flushAfterPasses = "False"; 	// Increases fps on some cards.