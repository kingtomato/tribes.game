// rez/oc3/brakeforce patch  

function OC3Patch() after Bootstrap::evalSearchPath
{
	$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath @ "rez;rez/missions;opencall3;opencall3/missions;brakeforce;brakeforce/missions;";
}