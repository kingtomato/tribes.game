function CtfHUD::Init() {
	if ( $CtfHUD::Loaded )
		return;
	$CtfHUD::Loaded = true;
	
	HUD::New("CtfHUD::Container", 500, 8, 700, 23, CtfHUD::Wake, CtfHUD::Sleep);
	newObject("CtfHUD::Status0", FearGuiFormattedText, 2, 2, 150, 20); 
	newObject("CtfHUD::Status1", FearGuiFormattedText, 400, 2, 150, 20);
	newObject("CtfHUD::Score0", FearGuiFormattedText, 195, 2, 150, 20);
	newObject("CtfHUD::Score1", FearGuiFormattedText, 335, 2, 150, 20);

	
	HUD::Add("CtfHUD::Container", "CtfHUD::Status0");
	HUD::Add("CtfHUD::Container", "CtfHUD::Status1");
	HUD::Add("CtfHUD::Container", "CtfHUD::Score0");
	HUD::Add("CtfHUD::Container", "CtfHUD::Score1");

	CtfHUD::Reset();
}

function CtfHUD::Wake() { CtfHUD::Update(); }
function CtfHUD::Sleep() { }

function CtfHUD::Reset() {

	CtfHUD::Update();
}

function CtfHUD::Update() {
        %score0 = Team::Score(Team::Friendly());
        %score1 = Team::Score(Team::Enemy());
	CtfHUD::FriendlyTeamValue(%team);
	CtfHUD::EnemyTeamValue(%team);
	Control::SetValue( "CtfHUD::Score0", "<f2>[ <f1>" ~%score0 @ "<f2> ]");
	Control::SetValue( "CtfHUD::Score1", "<f2>[ <f0>" ~%score1 @ "<f2> ]");
}


function CtfHUD::FriendlyTeamValue(%team, %score0) {
        %team = Team::Friendly();
	%loc = Team::Flag::Location(Team::Friendly());
	
	switch ( %loc ) {
		case "home":
			%loc = "<f1> - Home -";
			break;
		case "field":
			%loc = "<f1>- Dropped -> <f2>" ~ Team::Flag::Timer(%team);
			break;
		default:
			%loc = "<f0>" ~ String::escapeFormatting(Client::GetName(%loc));
			break;
	}
	Control::SetValue( "CtfHUD::Status0", %loc );

}

function CtfHUD::EnemyTeamValue(%team, %score1) {
        %team = Team::Enemy();
	%loc = Team::Flag::Location(Team::Enemy());
	
	switch ( %loc ) {
		case "home":
			%loc = "<f0> - Home -";
			break;
		case "field":
			%loc = "<f0>- Dropped -> <f2>" ~ Team::Flag::Timer(%team);
			break;
		default:
			%loc = "<f1>" ~ String::escapeFormatting(Client::GetName(%loc));
			break;
	}
	Control::SetValue( "CtfHUD::Status1", %loc );

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