function GEnergy::Init() {
	if($GEnergy:Loaded)
		return;
	$GEnergy:Loaded = true;
	
	HUD::New( "GEnergy::Container", 0, 0, 225, 15, GEnergy::Wake, GEnergy::Sleep );
	newObject("GEnergy::EB", FearGuiFormattedText, 40, 0, 180, 15);
	HUD::Add("GEnergy::Container","GEnergy::EB");
	newObject("GEnergy::ET", FearGuiFormattedText, 3, 0, 180, 15);
	HUD::Add("GEnergy::Container","GEnergy::ET");
	Control::SetValue("GEnergy::EB", "<B0,0:Modules/HealthNrg/energybar.png>");
}

function GEnergy::Wake() { GEnergy::Update(); }
function GEnergy::Sleep() { Schedule::Cancel("GEnergy::Update();"); }

function GEnergy::Update() {
	Control::SetExtent("GEnergy::EB", $energy*1.8, 15 );
	Control::SetValue("GEnergy::ET", "<f2>" ~ $energy);
	Schedule::Add("GEnergy::Update();",0.1);
}

GEnergy::Init();