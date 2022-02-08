$CtfHUD::Image[0, home] = "friendly.home.png";
$CtfHUD::Image[0, player] = "friendly.player.png";
$CtfHUD::Image[0, field] = "friendly.empty.png";

$CtfHUD::Image[1, home] = "enemy.home.png";
$CtfHUD::Image[1, player] = "enemy.player.png";
$CtfHUD::Image[1, field] = "enemy.empty.png";

function CtfHUD::Init() {
	if ( $CtfHUD::Loaded )
		return;
	$CtfHUD::Loaded = true;
	
	HUD::New::Shaded("CtfHUD::Container", 5, 80, 175, 40, CtfHUD::Wake, CtfHUD::Sleep);

	newObject("CtfHUD::Image0", FearGuiFormattedText, 0, 0, 20, 20); 
	newObject("CtfHUD::Image1", FearGuiFormattedText, 0, 20, 20, 20);

	newObject("CtfHUD::Status0", FearGuiFormattedText, 22, 0, 150, 20); 
	newObject("CtfHUD::Status1", FearGuiFormattedText, 22, 20, 150, 20);

	HUD::Add("CtfHUD::Container", "CtfHUD::Image0");
	HUD::Add("CtfHUD::Container", "CtfHUD::Image1");
	
	HUD::Add("CtfHUD::Container", "CtfHUD::Status0");
	HUD::Add("CtfHUD::Container", "CtfHUD::Status1");

	CtfHUD::Reset();
}

function CtfHUD::Wake() { CtfHUD::Update(); }
function CtfHUD::Sleep() { }

function CtfHUD::Reset() {
	Control::SetValue("CtfHUD::Image0", "<b3,3:Modules/CTFHud/friendly.home.png>");
	Control::SetValue("CtfHUD::Image1", "<b3,4:Modules/CTFHud/enemy.home.png>");

	CtfHUD::Update();
}

function CtfHUD::Update() {
	//friendly team goes in slot 0
	CtfHUD::SetTeamValue( 0, Team::Friendly() );
	//enemy team goes in slot 0
	CtfHUD::SetTeamValue( 1, Team::Enemy() );
}


function CtfHUD::SetTeamValue( %slot, %team ) {
	%score = Team::Score(%team);
	%loc = Team::Flag::Location(%team);
	
	switch ( %loc ) {
		case "home":
			%loc = "<f3>Home";
			%bmp = $CtfHUD::Image[%slot, "home"];
			break;
		case "field":
			%loc = "<f3>Dropped-><f2>" ~ Team::Flag::Timer(%team);
			%bmp = $CtfHUD::Image[%slot, "field"];
			break;
		default:
			%loc = "<f2>" ~ String::escapeFormatting(Client::GetName(%loc));
			%bmp = $CtfHUD::Image[%slot, "player"];
			break;
	}
	
	Control::SetValue( "CtfHUD::Image"~%slot, "<b3,3:Modules/CTFHud/"~%bmp~">" );
	Control::SetValue( "CtfHUD::Status"~%slot, "<f3>(<f2>"~%score~"<f3>)  "~%loc );

}

// if we change teams, the sides may need to be updated
function CtfHUD::SelfUpdate( %client, %team ) {
	if ( %client == getManagerId() )
		CtfHUD::Update();
}

Event::Attach( EventFlagUpdate, CtfHUD::Update );
Event::Attach( EventFlagTimerUpdate, CtfHUD::Update );
Event::Attach( EventClientChangeTeam, CtfHUD::SelfUpdate );

CtfHUD::Init();