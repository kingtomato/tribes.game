// simple ammo display for 1.40

function AmmoHUD::Init() {
	if ($AmmoHUD::Loaded)
		return;
	$AmmoHUD::Loaded = true;

	$AmmoHUD::Awake = false;
	
	HUD::New( "AmmoHUD::Container", 0, 0, 225, 15, AmmoHUD::Wake, AmmoHUD::Sleep );
	newObject( "AmmoHUD::Text", FearGuiFormattedText, 3, 0, 180, 15);
	newObject( "AmmoHUD::Bar", FearGuiFormattedText, 40, 0, 180, 15);
	HUD::Add( "AmmoHUD::Container", "AmmoHUD::Text" );
	HUD::Add( "AmmoHUD::Container", "AmmoHUD::Bar" );
	Control::SetValue("AmmoHUD::Bar", "<B0,0:Modules/AmmoHud/ammobar.png>");
}

function AmmoHUD::Wake() {
	$AmmoHUD::Awake = true;
	AmmoHUD::Update();
}

function AmmoHUD::Sleep() {
	Schedule::Cancel("AmmoHUD::Update();");
	$AmmoHUD::Awake = false;
}

function AmmoHUD::Update() {
	if ( !$AmmoHUD::Awake )
		return;
	
	if($Weapon::Ammo < 0)
		%ammo = "~";
	else
		%ammo = $Weapon::Ammo;

        if(GetItemdesc(GetMountedItem(0)) == "Disc Launcher")
	Control::SetExtent("AmmoHUD::Bar", $Weapon::Ammo*12, 15 );
        if(GetItemdesc(GetMountedItem(0)) == "Grenade Launcher")
	Control::SetExtent("AmmoHUD::Bar", $Weapon::Ammo*18, 15 );
        if(GetItemdesc(GetMountedItem(0)) == "Chaingun")
	Control::SetExtent("AmmoHUD::Bar", $Weapon::Ammo*1.8, 15 );

	Control::SetValue( "AmmoHUD::Text", "<f2>"~%ammo );
	Schedule::Add("AmmoHUD::Update();", 0.1);
}

AmmoHUD::Init();
