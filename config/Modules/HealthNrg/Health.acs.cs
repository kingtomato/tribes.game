function GHealth::Init() {
	if($GHealth:Loaded)
		return;
	$GHealth:Loaded = true;

	HUD::New( "GHealth::Container", 0, 0, 225, 15, GHealth::Wake, GHealth::Sleep );
	newObject("GHealth::HB", FearGuiFormattedText, 40, 0, 180, 15);
	newObject("GHealth::HT", FearGuiFormattedText, 3, 0, 180, 15);
	HUD::Add("GHealth::Container","GHealth::HB");
	HUD::Add("GHealth::Container","GHealth::HT");
	Control::SetValue("GHealth::HB", "<B0,0:Modules/HealthNrg/healthbar.png>");
}

function GHealth::Wake() { GHealth::Update(); }
function GHealth::Sleep() { Schedule::Cancel("GHealth::Update();");}

function GHealth::Update() {
	Control::SetExtent("GHealth::HB", $health*1.8, 15 );
	Control::SetValue("GHealth::HT", "<f2>" ~ $health);

	Schedule::Add("GHealth::Update();",0.1);
}

Event::Attach(eventItemReceived, GHealth::Update);
Event::Attach(eventItemDropped, GHealth::Update);
Event::Attach(eventItemUsed, GHealth::Update);

GHealth::Init();

