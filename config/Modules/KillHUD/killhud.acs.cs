$killHUD::Lines = 4;

function killHUD::Init() {
	if ( $killHUD::Loaded )
		return;
	$killHUD::Loaded = true;
	
	HUD::New("killHUD::Container", 40, 125, 500, 90, killHUD::Wake, killHUD::Sleep);
                  newObject("killHUD::Text", FearGuiFormattedText, 15, -1, 500, 350);
	HUD::Add("killHUD::Container", "killHUD::Text");
        killHUD::Clear();

}

function killHUD::Wake() { killHUD::Update(); }
function killHUD::Sleep() { }

function killHUD::Clear()
{
	for(%i=0;%i<=$killHUD::Lines;%i++)
		$killHUD::Row[%i] = "";

	killHUD::Update();
}

function killHUD::Rotate()
{
	for(%i=0;%i<$killHUD::Lines;%i++)
		$killHUD::Row[%i] = $killHUD::Row[%i+1];
}

function killHUD::Update()
{
	for(%i=0;%i<=$killHUD::Lines;%i++)
		%display = %display @ $killHUD::Row[%i] @ "\n";

	Control::SetValue("killHUD::Text", %display);
        Schedule::Add("killHUD::clear();", 5);
}

function killHUD::onClientTeamKilled(%killer, %victim, %damagetype)
{
                  %kname = String::escape(Client::GetName(%killer));
	%vname = String::escape(Client::GetName(%victim));
                  %font3 = "<f2>";  
	if(Client::GetTeam(%killer) == Team::Friendly())
		%font = "<f1>";
	else
		%font = "<f0>";
	
	if(Client::GetTeam(%victim) == Team::Friendly())
		%font2 = "<f1>";
	else
		%font2 = "<f0>";
  
	killHUD::Rotate();
	if((%killer == %victim) || (%kname == ""))
		$killHUD::Row[$killHUD::Lines] = %font@%vname@"<f1> : "@"[TEAMKILLED]";
	else
		$killHUD::Row[$killHUD::Lines] = %font@%kname@" "@%font3@"[TEAMKILLED]"@" "@%font2@%vname;
                killHUD::Update();
}

function killHUD::onClientKilled(%killer, %victim, %damagetype)
 {
                  %kname = String::escape(Client::GetName(%killer));
	%vname = String::escape(Client::GetName(%victim));
                  %font3 = "<f2>";  
	if(Client::GetTeam(%killer) == Team::Friendly())
		%font = "<f1>";
	else
		%font = "<f0>";
	
	if(Client::GetTeam(%victim) == Team::Friendly())
		%font2 = "<f1>";
	else
		%font2 = "<f0>";
  
	killHUD::Rotate();
	if((%killer == %victim) || (%kname == ""))
		$killHUD::Row[$killHUD::Lines] = %font@%vname@"<f1> : "@killhud::getname(%damageType);
	else
		$killHUD::Row[$killHUD::Lines] = %font@%kname@" "@%font3@killhud::getname(%damageType)@" "@%font2@%vname;
                killHUD::Update();
}

function killHUD::getname(%damageType) {
	if (%damagetype == "Blaster") { return "[BLASTER]"; }
	if (%damagetype == "Chaingun") { return "[CHAINGUN]"; }
	if (%damagetype == "Disc") { return "[DISC]"; }
	if (%damagetype == "ELF") { return "[ELF]"; }
	if (%damagetype == "Explosives") { return "[EXPLO]"; }
	if (%damagetype == "Explosive") { return "[EXPLO]"; }
	if (%damagetype == "Laser") { return "[LASER]"; }
	if (%damagetype == "Mortar") { return "[MORTAR]"; }
	if (%damagetype == "Plasma") { return "[PLASMA]"; }
	if (%damagetype == "Suicide") { return "[SUICIDE]"; }
	if (%damagetype == "Turret") { return "[TURRET]"; }
	return "[SUICIDE]";
}

event::Attach(eventClientKilled, killHUD::onClientKilled);
event::Attach(eventClientTeamKilled, killHUD::onClientTeamKilled );
event::Attach(eventClientSuicided, killHUD::onClientKilled );
event::Attach(eventConnectionAccepted, killHUD::Clear);
event::Attach(eventChangeMission, killHUD::Clear);

killHUD::Init();