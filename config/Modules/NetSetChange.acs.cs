$NetSet::interval = 4;

function NetSet::GameBinds::Init()
  after GameBinds::Init
{
	$GameBinds::CurrentMapHandle = GameBinds::GetActionMap2( "actionMap.sae");
	$GameBinds::CurrentMap = "actionMap.sae";
	GameBinds::addBindCommand( "Decrease Interpolate", "Interpolate::set(0);");
	GameBinds::addBindCommand( "Increase Interpolate", "Interpolate::set(1);");
	GameBinds::addBindCommand( "Decrease PFT", "PFT::set(0);");
	GameBinds::addBindCommand( "Increase PFT", "PFT::set(1);");
}



// CODE BELOW DON'T EDIT

function Interpolate::set(%x)
{
	%currentterp = $net::interpolateTime;

	if (%x==1) {
		if ($net::interpolateTime < 160) {
			%currentterp = %currentterp + $NetSet::interval;
		}
	}
	if (%x==0) {
		if (%currentterp > 0) {
			%currentterp = %currentterp - $NetSet::interval;
			$net::interpolateTime = %currentterp;
		}
	}

	$net::interpolateTime = %currentterp;
	remoteEP("<f1> Current Interpolate is <f2>" @ $net::interpolateTime, 2, 1, 1, 20, 400);
}

function PFT::set(%x)
{
	%currentpft = $net::predictForwardTime;

	if (%x==1) {
		if ($net::predictForwardTime < 160) {
			%currentpft = %currentpft + $NetSet::interval;
		}
	}
	if (%x==0) {
		if (%currentpft > 0) {
			%currentpft = %currentpft - $NetSet::interval;
			$net::predictForwardTime = %currentpft;
		}
	}

	$net::predictForwardTime = %currentpft;
	remoteEP("<f1> Current PFT is <f2>" @ $net::predictForwardTime, 2, 1, 1, 20, 400);
}

