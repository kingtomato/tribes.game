$menu::maxitems = 7;

function menu::changemissiontype( %cl, %listStart ) {
	menu::new("Pick Mission Type", "changeMissionType", %cl);

	for ( %mTypeIndex = %listStart; %mTypeIndex < $MLIST::TypeCount; %mTypeIndex++ ) {
		if ( %lineNum++ > $menu::maxitems ) {
			menu::add("More mission types...", "moreTypes " @ %mTypeIndex, %cl );
			break;
		}
		else if ($MLIST::Type[%mTypeIndex] != "Training") {
			menu::add($MLIST::Type[%mTypeIndex], %mTypeIndex @ " 0", %cl );
		}
	}
}


function processMenuChangeMissionType( %cl, %option ) {
	%type = getWord(%option, 0);
	%index = getWord(%option, 1);

	if (%type == "moreTypes") {
		menu::ChangeMissionType(%cl, %index);   
	} else {
		menu::new("Change Mission", "changeMission", %cl);

		for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%type], %index + %i)) != -1; %i++) {
			if ((%i + 1) > $menu::maxitems) {
				menu::add("More missions...", "more " @ %index + %i @ " " @ %type, %cl );
				break;
			}
			menu::add($MLIST::EName[%misIndex], %misIndex @ " " @ %type, %cl);
		}
	}
}

function processMenuChangeMission( %cl, %option ) {
	if ( getWord(%option, 0) == "more" ) {
		%first = getWord(%option, 1);
		%type = getWord(%option, 2);
		processMenuChangeMissionType(%cl, %type @ " " @ %first);

		return;
	}

	%mi = getWord(%option, 0);
	%mt = getWord(%option, 1);

	%misName = $MLIST::EName[%mi];
	%misType = $MLIST::Type[%mt];

	// verify that this is a valid mission:
	if( %misType == "" || %misType == "Training" )
		return;

	for( %i = 0; true; %i++ ) {
		%misIndex = getWord($MLIST::MissionList[%mt], %i);
		if ( %misIndex == %mi )
			break;
		if ( %misIndex == -1 )
			return;
	}

	if( %cl.canChangeMission && !%cl.madeVote ) {
		log::add( %cl, "changed mission to " @ %misName, "", "", "MissionChange" );

		message::all(0, Client::getName(%cl) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		ObjectiveMission::missionComplete( %misName );
	} else {
		%cl.madeVote = "";
		admin::startvote(%cl, "change the mission to " @ %misName @ " (" @ %misType @ ")", "changeMission", %misName);
		Game::menuRequest(%cl);
	}
}
