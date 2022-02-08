////////////////////////////////////////////////////////////
// Boots 1.4 Pack
// File:	FOV.acs.cs
// Version:	1.0
// Author:	Zlex(Boots)
// Info:	Allows you to set FOV in-game
//
////////////////////////////////////////////////////////////

$FOV::interval = 1;

function FOV::GameBinds::Init()
  after GameBinds::Init
{
	$GameBinds::CurrentMapHandle = GameBinds::GetActionMap2( "actionMap.sae");
	$GameBinds::CurrentMap = "actionMap.sae";
	GameBinds::addBindCommand( "Decrease FOV", "FOV::set(0);");
	GameBinds::addBindCommand( "Increase FOV", "FOV::set(1);");
}





// CODE BELOW DON'T EDIT

function FOV::set(%x)
{
	%currentfov = $pref::playerfov;

	if (%x==1) {
		if ($pref::playerfov < 120) {
			%currentfov = %currentfov + $FOV::interval;
		}
	}
	if (%x==0) {
		if (%currentfov > 90) {
			%currentfov = %currentfov - $FOV::interval;
			$pref::playerfov = %currentfov;
		}
	}

	$pref::playerfov = %currentfov;
	remoteep("<f1> Current FOV is <f2>" @ $pref::playerfov @ " <f1>degrees.", 2, 1, 1, 20, 400);
}


