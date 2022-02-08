function ItemHUD::Init() {
	if ($ItemHUD::Loaded)
		return;
	$ItemHUD::Loaded = true;

	$ItemHUD::Awake = false;
	$ItemHUD::Mines = 0;
	$ItemHUD::Kits = 0;
	
	HUD::New( "ItemHUD::Container", 5, 200, 140, 12, ItemHUD::Wake, ItemHUD::Sleep );
	newObject( "ItemHUD::Text", FearGuiFormattedText, 0, 0, 140, 12 );
	HUD::Add( "ItemHUD::Container", "ItemHUD::Text" );
}

function ItemHUD::Wake() {
	$ItemHUD::Awake = true;
	ItemHUD::Update();
}

function ItemHUD::Sleep() {
	Schedule::Cancel("ItemHUD::Update();");
	$ItemHUD::Awake = false;
}

function ItemHUD::Update() {
	if ( !$ItemHUD::Awake )
		return;

	Schedule::Add("ItemHUD::Update();", 1);

	%text = "";
	%kits = getItemCount("Repair Kit");
	%mines = getItemCount("Mine");

	//dont bother updating if count hasnt changed
	if ( ( %kits == $ItemHUD::Kits ) && ( %mines == $ItemHUD::Mines ) )
		return;

	$ItemHUD::Kits = %kits;
	$ItemHUD::Mines = %mines;
 
	%kits = ( %kits > 0 ) ? "kitdot.png" : "blankdot.png";

	%text = "<B0,0:modules/itemhud/" @ %kits @ ">";
	for ( %i = 0; %i < %mines; %i++ )
		%text = %text @ "<B0,0:modules\\itemhud\\minedot.png>";
	
	Control::SetValue( "ItemHUD::Text", %text );
}

ItemHUD::Init();

Event::Attach(eventItemReceived, "Schedule::Add(\"ItemHUD::Update();\", 0);");
Event::Attach(eventItemDropped, "Schedule::Add(\"ItemHUD::Update();\", 0);");
Event::Attach(eventItemUsed, "Schedule::Add(\"ItemHUD::Update();\", 0);");
