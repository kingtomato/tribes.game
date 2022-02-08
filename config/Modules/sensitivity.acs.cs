function Sense::GameBinds::Init()
  after GameBinds::Init
{
	$GameBinds::CurrentMapHandle = GameBinds::GetActionMap2( "actionMap.sae");
	$GameBinds::CurrentMap = "actionMap.sae";
	GameBinds::addBindCommand( "Increase Sensitivity", "s::sensBaseIncrease();");
	GameBinds::addBindCommand( "Decrease Sensitivity", "s::sensBaseDecrease();");
}


// dont touch this
$s::sensNumModes = 2;

// The current sensitivity mode setting
$s::sensMode = 1;

function s::sensCycle()
{
	$s::sensMode = ($s::sensMode % $s::sensNumModes) + 1;

                  s::sensSetMode($s::sensMode);
	
	if($s::sensMode == 1) {
		postAction(2048, IDACTION_MOVEUP, -0);
		s::SetSensitivity($sp::sensDefault, $sp::sensDefault);
	                  remoteEP("<f1> Sensitivity = NORMAL", 2, 1, 1, 20, 400);
                  }	
}

function s::SetSensitivity(%xSens,%ySens)
{	
	EditActionMap("playMap.sae");
	if(Client::getMouseXaxisFlip("playMap.sae"))
		bindAction(mouse0, xaxis0, TO, IDACTION_YAW, Scale, %xSens);
	else
		bindAction(mouse0, xaxis0, TO, IDACTION_YAW, Flip, Scale, %xSens);
		
	EditActionMap("playMap.sae");
	if(Client::getMouseYaxisFlip("playMap.sae"))
		bindAction(mouse0, yaxis0, TO, IDACTION_PITCH, Scale, %ySens);
	else
		bindAction(mouse0, yaxis0, TO, IDACTION_PITCH, Flip, Scale, %ySens);
}

function s::sensBaseIncrease()
{
	if($s::sensMode > 1) return;
	$sp::sensDefault += 0.000008;
	remoteEP("<f1> Current Mouse Sense = <f2>"@$sp::sensDefault, 2, 1, 1, 20, 400);
	s::SetSensitivity($sp::sensDefault, $sp::sensDefault);
}

function s::sensBaseDecrease()
{
	if($s::sensMode > 1) return;
	$sp::sensDefault -= 0.000008;
	if($sp::sensDefault < 0.000008) $sp::sensDefault = 0.000008;
	remoteEP("<f1> Current Mouse Sense = <f2>"@$sp::sensDefault, 2, 1, 1, 20, 400);
	s::SetSensitivity($sp::sensDefault, $sp::sensDefault);
}

function s::setBaseSensitivity()
{
	s::SetSensitivity($sp::sensDefault, $sp::sensDefault);
}

function s::WriteInGamePrefs()
{
	echo("exporting smalesHUD"@" in-game prefs...");
	export("$sp::*", "config\\core\\prefs.cs", false);
}

event::Attach(eventExit, s::WriteInGamePrefs);
event::Attach(eventConnected, s::setBaseSensitivity);