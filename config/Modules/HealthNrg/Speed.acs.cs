function GSpeed::Init() {
	if($GSpeed:Loaded)
		return;
	$GSpeed:Loaded = true;
	
	HUD::New( "GSpeed::Container", 0, 0, 225, 15, GSpeed::Wake, GSpeed::Sleep );
	newObject("GSpeed::EB", FearGuiFormattedText, 40, 0, 180, 15);
	HUD::Add("GSpeed::Container","GSpeed::EB");
	newObject("GSpeed::ET", FearGuiFormattedText, 3, 0, 180, 15);
	HUD::Add("GSpeed::Container","GSpeed::ET");
	Control::SetValue("GSpeed::EB", "<B0,0:Modules/HealthNrg/speedbar.png>");
}

function GSpeed::Wake() { GSpeed::Update(); }
function GSpeed::Sleep() { Schedule::Cancel("GSpeed::Update();"); }

function GSpeed::Update() {
	Control::SetExtent("GSpeed::EB", $Speed*1.8, 15);
	Control::SetValue("GSpeed::ET", "<f2>" ~ $Speed);
	Schedule::Add("GSpeed::Update();",0.1);
}

GSpeed::Init();