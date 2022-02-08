function GameBinds::Clear() {
    deleteVariables( "$GameBinds::*" );
    
    // delete all the playmap tabs
    // %group = Control::getId( "OptionsGui::BindMaps" );
    // if ( %group != -1 ) {
    //  for( %i = 0; ( %obj = Group::getObject( %group, %i ) ) != -1; %i++ )
    //      deleteObject( %obj );
    // }
}

// not working!
function GameBinds::GetActionMap( %sae ) {
    if ( $GameBinds::Map[%sae] )
        return $GameBinds::Map[%sae];
    
    %display = String::Replace( %sae, ".sae", "" );
    %tab = "OptionsGui::" @ %display @ "Tab";
    %actionmap = "OptionsGui::" @ %display @ "Map";
    
    newObject( %tab, FearGui::FGTab );
    newObject( %actionmap, FearGui::ActionMapList, 20, 20, 300, 300 );
    
    addToSet( $GameBinds::Parent, %actionmap );
    addToSet( $GameBinds::Parent, %tab );
    
    $GameBinds::Map[%sae] = %actionmap;
    return ( %actionmap );
}

function GameBinds::GetActionMap2( %sae ) {
    %display = String::Replace( %sae, ".sae", "" );
    return ( "OptionsGui::" @ %display );
}

function GameBinds::SetMap( %sae ) {
    $GameBinds::CurrentMap = %sae;
    $GameBinds::CurrentMapHandle = GameBinds::GetActionMap2( %sae );
    ActionMapList::clearBinds( $GameBinds::CurrentMapHandle );
}

function GameBinds::addBindCommand( %desc, %make, %break ) {
	%cmd = sprintf( "ActionMapList::addBindableCommand( \"%1\", \"%2\", \"%3\", \"%4\"",
        $GameBinds::CurrentMapHandle, $GameBinds::CurrentMap, %desc, String::Escape( %make ) );
    if ( %break != "" )
    	%cmd = %cmd @ sprintf( ", \"%1\"", String::Escape( %break ) );
    eval( %cmd @ ");" );
}

function GameBinds::addBindAction( %desc, %p0, %p1, %p2, %p3, %p4, %p5, %p6 ) {
	%cmd = sprintf( "ActionMapList::addBindableAction( \"%1\", \"%2\", \"%3\"",
        $GameBinds::CurrentMapHandle, $GameBinds::CurrentMap, %desc );
    for ( %i = 0; %p[%i] != ""; %i++ )
    	%cmd = %cmd @ ", " @ %p[%i];
    eval( %cmd @ ");" );
}

function GameBinds::Init() {
    GameBinds::Clear();
    
    $GameBinds::Parent = Control::getId( "OptionsGui::BindMaps" );
    if ( $GameBinds::Parent == -1 )
      return;

    GameBinds::SetMap( "actionMap.sae" );
    GameBinds::addBindAction( "Score Screen", MAKE, IDACTION_MENU_PAGE, 1 );
    GameBinds::addBindAction( "HUD Config", MAKE, IDACTION_MENU_PAGE, 2 );
    GameBinds::addBindAction( "Global Chat", MAKE, IDACTION_CHAT, 0 );
    GameBinds::addBindAction( "Team Chat", MAKE, IDACTION_CHAT, 1 );
    GameBinds::addBindAction( "Chat HUD Size", MAKE, IDACTION_CHAT_DISP_SIZE, -1 );
    GameBinds::addBindAction( "Chat HUD Scroll UP", MAKE, IDACTION_CHAT_DISP_PAGE, -1 );
    GameBinds::addBindAction( "Chat HUD Scroll DOWN", MAKE, IDACTION_CHAT_DISP_PAGE, 1 );
    GameBinds::addBindCommand( "Buy/Select Loadout #1", "AutoBuy::SelectAndBuyLoadout(1);" );
    GameBinds::addBindCommand( "Buy/Select Loadout #2", "AutoBuy::SelectAndBuyLoadout(2);" );
    GameBinds::addBindCommand( "Buy/Select Loadout #3", "AutoBuy::SelectAndBuyLoadout(3);" );
    GameBinds::addBindCommand( "Buy/Select Loadout #4", "AutoBuy::SelectAndBuyLoadout(4);" );
    GameBinds::addBindCommand( "Buy/Select Loadout #5", "AutoBuy::SelectAndBuyLoadout(5);" );
    GameBinds::addBindCommand( "Play Mode", "remoteEval(2048, PlayMode);" );
    GameBinds::addBindCommand( "Mission Edit Mode", "MEMode();" );
    GameBinds::addBindCommand( "Objectives Mode", "remoteEval(2048, ToggleObjectivesMode);" );
    GameBinds::addBindCommand( "Inventory Mode", "remoteEval(2048, ToggleInventoryMode);" );
    GameBinds::addBindCommand( "Command Mode", "remoteEval(2048, ToggleCommandMode);" );
    GameBinds::addBindCommand( "Command: Acknowledge", "commandAck();" );
    GameBinds::addBindCommand( "Command: Decline", "commandDeclined();" );
    GameBinds::addBindCommand( "Command: Completed", "commandCompleted();" );
    GameBinds::addBindCommand( "Vote YES", "voteYes();" );
    GameBinds::addBindCommand( "Vote NO", "voteNo();" );
    GameBinds::addBindCommand( "Show In-Game Stats", "StatHUD::Show();", "StatHUD::Hide();" );

    GameBinds::SetMap( "playMap.sae" );
    GameBinds::addBindAction( "Left", MAKE, IDACTION_MOVELEFT, 1, BREAK, IDACTION_MOVELEFT, 0 );    
    GameBinds::addBindAction( "Right", MAKE, IDACTION_MOVERIGHT, 1, BREAK, IDACTION_MOVERIGHT, 0 );    
    GameBinds::addBindAction( "Forward", MAKE, IDACTION_MOVEFORWARD, 1, BREAK, IDACTION_MOVEFORWARD, 0 );    
    GameBinds::addBindAction( "Backward", MAKE, IDACTION_MOVEBACK, 1, BREAK, IDACTION_MOVEBACK, 0 );    
    GameBinds::addBindAction( "Jet", MAKE, IDACTION_JET, 1, BREAK, IDACTION_JET, 0 );
    GameBinds::addBindAction( "Fire", MAKE, IDACTION_FIRE1, BREAK, IDACTION_BREAK1 );
    GameBinds::addBindAction( "Crouch", MAKE, IDACTION_CROUCH, BREAK, IDACTION_STAND );
    GameBinds::addBindAction( "1st/3rd Toggle", MAKE, IDACTION_VIEW );
    GameBinds::addBindAction( "Jump/Ski", MAKE, IDACTION_MOVEUP, 1, BREAK, IDACTION_MOVEUP, 0 );
    
	GameBinds::addBindCommand( "Zoom", "Zoom::In();", "Zoom::Out();" );
	GameBinds::addBindCommand( "Zoom Cycle", "Zoom::Cycle();" );

    GameBinds::addBindCommand( "Quick Chat", "setCMMode(PlayChatMenu, 2);" );
    GameBinds::addBindCommand( "Use Beacon", "use(\"Beacon\");" );
    GameBinds::addBindCommand( "Use Mine", "throwStart();", "throwRelease(\"Mine\");" );
    GameBinds::addBindCommand( "Use Mine (FULL THROW)", "$throwStartTime=0; throwRelease(\"Mine\");" );
    GameBinds::addBindCommand( "Use Grenade", "throwStart();", "throwRelease(\"Grenade\");" );
    GameBinds::addBindCommand( "Use Grenade (FULL THROW)", "$throwStartTime=0; throwRelease(\"Grenade\");" );
    GameBinds::addBindCommand( "Use Grenade (WEAK THROW)", "throwStart(); throwRelease(\"Grenade\");" );
    GameBinds::addBindCommand( "Use Repair Kit", "use(\"Repair Kit\");" );
    GameBinds::addBindCommand( "Activate Pack", "use(\"BackPack\");" );
    
    GameBinds::addBindCommand( "Use Blaster", "use(\"Blaster\");" );
    GameBinds::addBindCommand( "Use Plasma Gun", "use(\"Plasma Gun\");" );
    GameBinds::addBindCommand( "Use Chaingun", "use(\"Chaingun\");" );
    GameBinds::addBindCommand( "Use Disc Launcher", "use(\"Disc Launcher\");" );
    GameBinds::addBindCommand( "Use Grenade Launcher", "use(\"Grenade Launcher\");" );
    GameBinds::addBindCommand( "Use Laser Rifle", "use(\"Laser Rifle\");" );
    GameBinds::addBindCommand( "Use ELF Gun", "use(\"ELF gun\");" );
    GameBinds::addBindCommand( "Use Mortar", "use(\"Mortar\");" );
    GameBinds::addBindCommand( "Use Targeting Laser", "use(\"Targeting Laser\");" );
    
    GameBinds::addBindAction( "Look Up", MAKE, IDACTION_LOOKUP, 0.1, BREAK, IDACTION_LOOKUP, 0 );
    GameBinds::addBindAction( "Look Down", MAKE, IDACTION_LOOKDOWN, 0.1, BREAK, IDACTION_LOOKDOWN, 0 );
    GameBinds::addBindAction( "Look Left", MAKE, IDACTION_TURNLEFT, 0.1, BREAK, IDACTION_TURNLEFT, 0 );
    GameBinds::addBindAction( "Look Right", MAKE, IDACTION_TURNRIGHT, 0.1, BREAK, IDACTION_TURNRIGHT, 0 );
    
    GameBinds::addBindCommand( "Drop Pack", "drop(BackPack);" );
    GameBinds::addBindCommand( "Drop Weapon", "drop(Weapon);" );
    GameBinds::addBindCommand( "Drop Ammo", "drop(Ammo);" );
    GameBinds::addBindCommand( "Drop Flag", "drop(Flag);" );
    GameBinds::addBindCommand( "Suicide", "kill();" );
    GameBinds::addBindCommand( "Next Weapon", "nextWeapon();" );
    GameBinds::addBindCommand( "Previous Weapon", "prevWeapon();" );
    
    GameBinds::addBindCommand( "Waypoint: Friendly Flag Stand", "remoteEval(2048,FlagstandWaypoint,Team::Friendly());" );
    GameBinds::addBindCommand( "Waypoint: Enemy Flag Stand", "remoteEval(2048,FlagstandWaypoint,Team::Enemy());" );
    GameBinds::addBindCommand( "Waypoint: Friendly Flag Carrier", "CarrierWaypoint::TargetFriendly();" );
    GameBinds::addBindCommand( "Waypoint: Enemy Flag Carrier", "CarrierWaypoint::TargetEnemy();" );
    
    GameBinds::addBindCommand( "TV Mode: Friendly Flag Carrier", "TV::Activate($TV::Carrier);", "TV::DeActivate();" );
    GameBinds::addBindCommand( "Drop Items Not In Cur. Loadout", "AutoBuy::DumpNonLoadoutItems();" );
    
    

    GameBinds::SetMap( "inventoryMap.sae" );
    GameBinds::addBindCommand( "Spew Repair Packs", "AutoBuy::litterItem( \"Repair Pack\" );" );
    GameBinds::addBindCommand( "Spew Turrets", "AutoBuy::litterItem( \"Turret\" );" );
    GameBinds::addBindCommand( "Spew Pulse Sensors", "AutoBuy::litterItem( \"Pulse Sensor\" );" );
    GameBinds::addBindCommand( "Spew Remote Invs", "AutoBuy::litterItem( \"Inventory Station\" );" );
}

