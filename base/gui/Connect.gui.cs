//--- export object begin ---//
instant SimGui::BitmapCtrl "ConnectGui" {
	position = "0 0";
	extent = "640 480";
	horizSizing = "width";
	vertSizing = "height";
	consoleVariable = "";
	consoleCommand = "";
	altConsoleCommand = "";
	deleteOnLoseContent = "True";
	ownObjects = "True";
	opaque = "False";
	fillColor = "0 0 0";
	selectFillColor = "0 0 0";
	ghostFillColor = "0 0 0";
	border = "False";
	borderColor = "0 0 0";
	selectBorderColor = "0 0 0";
	ghostBorderColor = "0 0 0";
	visible = "True";
	tag = "";
	active = "False";
	messageTag = "";
	bmpTag = "IDBMP_BG3";
	transparent = "False";
	instant FearGui::FGShellBorder {
		position = "0 0";
		extent = "640 480";
		horizSizing = "width";
		vertSizing = "height";
		consoleVariable = "";
		consoleCommand = "";
		altConsoleCommand = "";
		deleteOnLoseContent = "True";
		ownObjects = "True";
		opaque = "True";
		fillColor = "0 0 0";
		selectFillColor = "0 0 0";
		ghostFillColor = "0 0 0";
		border = "False";
		borderColor = "0 0 0";
		selectBorderColor = "0 0 0";
		ghostBorderColor = "0 0 0";
		visible = "True";
		tag = "";
		backgroundBitmap = "Background4.bmp";
		instant FearGui::FGUniversalButton {
			position = "520 430";
			extent = "81 23";
			horizSizing = "left";
			vertSizing = "top";
			consoleVariable = "";
			consoleCommand = "ConnectGui::ChooseGame();";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0 0 0";
			ghostFillColor = "0.533333 0.635294 0.607843";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.772549 0.796078 0.788235";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "IDCTG_SHELL_NEXT";
			active = "True";
			messageTag = "";
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "BTN_Next";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGUniversalButton {
			position = "40 430";
			extent = "82 23";
			horizSizing = "right";
			vertSizing = "top";
			consoleVariable = "";
			consoleCommand = "$QuickStart = FALSE;";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.956863 0.94902 0.772549";
			ghostFillColor = "0.737255 0.486275 0.039216";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.07451 0.086275 0.078431";
			ghostBorderColor = "0.6 0.372549 0.243137";
			visible = "True";
			tag = "";
			active = "True";
			messageTag = "IDGUI_PLAYER_SETUP";
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "BTN_Back";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGUniversalButton {
			position = "570 0";
			extent = "45 33";
			horizSizing = "left";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "onQuit();";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0 0 0";
			ghostFillColor = "0.894118 0.737255 0.690196";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.772549 0.796078 0.788235";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			active = "True";
			messageTag = "";
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "SBB_CmdQuit";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGUniversalButton {
			position = "157 0";
			extent = "67 33";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "$PlayGameGui =  \"gui/Connect.gui\";";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0 0 0";
			ghostFillColor = "0.592157 0.545098 0.498039";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.772549 0.796078 0.788235";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "IDGUI_OPTIONS";
			active = "True";
			messageTag = "IDGUI_OPTIONS";
			isCheckbox = "True";
			radioTag = "";
			bitmapRoot = "SBB_Options";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGUniversalButton {
			position = "91 0";
			extent = "66 33";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "$PlayGameGui =  \"gui/Connect.gui\";switchToChat();";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0 0 0";
			ghostFillColor = "0.537255 0.521569 0.211765";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.772549 0.796078 0.788235";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "IDGUI_IRC_CHAT";
			active = "True";
			messageTag = "";
			isCheckbox = "True";
			radioTag = "";
			bitmapRoot = "SBB_Chat";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGUniversalButton {
			position = "22 0";
			extent = "69 34";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.227451 0.239216 0.286275";
			ghostFillColor = "0.227451 0.239216 0.286275";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.227451 0.239216 0.286275";
			ghostBorderColor = "0.533333 0.545098 0.537255";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			isCheckbox = "True";
			radioTag = "";
			bitmapRoot = "SBB_Play";
			isSet = "True";
			mirrorConsoleVar = "False";
		};
		instant SimGui::Control {
			position = "223 4";
			extent = "351 32";
			horizSizing = "width";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0 0 0";
			ghostFillColor = "0.666667 0.247059 0.023529";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.745098 0.811765 0.870588";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			instant FearGui::FGUniversalButton {
				position = "99 15";
				extent = "152 19";
				horizSizing = "center";
				vertSizing = "bottom";
				consoleVariable = "";
				consoleCommand = "";
				altConsoleCommand = "";
				deleteOnLoseContent = "True";
				ownObjects = "True";
				opaque = "False";
				fillColor = "0 0 0";
				selectFillColor = "0 0 0";
				ghostFillColor = "0.407843 0.670588 0.2";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.745098 0.811765 0.870588";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "";
				active = "False";
				messageTag = "";
				isCheckbox = "False";
				radioTag = "";
				bitmapRoot = "TTL_ChooseGame";
				isSet = "False";
				mirrorConsoleVar = "False";
			};
		};
			instant SimGui::Control {
			position = "208 173";
			extent = "224 134";
			horizSizing = "center";
			vertSizing = "center";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.745098 0.811765 0.870588";
			ghostFillColor = "0.772549 0.831373 0.843137";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.454902 0.215686 0.023529";
			ghostBorderColor = "0.745098 0.811765 0.870588";
			visible = "True";
			tag = "";
			instant FearGui::FGUniversalButton {
				position = "10 56";
				extent = "201 26";
				horizSizing = "right";
				vertSizing = "bottom";
				consoleVariable = "";
				consoleCommand = "$pref::PlayGameMode = \"TRAIN\";";
				altConsoleCommand = "";
				deleteOnLoseContent = "True";
				ownObjects = "True";
				opaque = "False";
				fillColor = "0 0 0";
				selectFillColor = "0 0 0";
				ghostFillColor = "0.27451 0.556863 0.666667";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.188235 0.262745 0.141176";
				ghostBorderColor = "0.745098 0.811765 0.870588";
				visible = "True";
				tag = "IDGUI_TEMP";
				active = "True";
				messageTag = "IDCTG_GS_RADIO_1";
				isCheckbox = "True";
				radioTag = "IDCTG_CMD_BOX_0";
				bitmapRoot = "RAD_SinglePlayer";
				isSet = "False";
				mirrorConsoleVar = "False";
			};
			instant FearGui::FGUniversalButton {
				position = "10 98";
				extent = "163 23";
				horizSizing = "right";
				vertSizing = "bottom";
				consoleVariable = "";
				consoleCommand = "$pref::PlayGameMode = \"HOST\";";
				altConsoleCommand = "";
				deleteOnLoseContent = "True";
				ownObjects = "True";
				opaque = "False";
				fillColor = "0 0 0";
				selectFillColor = "0 0 0";
				ghostFillColor = "0.27451 0.556863 0.666667";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.188235 0.262745 0.141176";
				ghostBorderColor = "0.745098 0.811765 0.870588";
				visible = "True";
				tag = "IDGUI_CREATE_SERVER";
				active = "True";
				messageTag = "IDCTG_GS_RADIO_2";
				isCheckbox = "True";
				radioTag = "IDCTG_CMD_BOX_0";
				bitmapRoot = "RAD_HostMulti";
				isSet = "True";
				mirrorConsoleVar = "False";
			};
			instant FearGui::FGUniversalButton {
				position = "10 14";
				extent = "159 23";
				horizSizing = "right";
				vertSizing = "bottom";
				consoleVariable = "";
				consoleCommand = "$pref::PlayGameMode = \"JOIN\";";
				altConsoleCommand = "";
				deleteOnLoseContent = "True";
				ownObjects = "True";
				opaque = "False";
				fillColor = "0 0 0";
				selectFillColor = "0 0 0";
				ghostFillColor = "0.27451 0.556863 0.666667";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.188235 0.262745 0.141176";
				ghostBorderColor = "0.745098 0.811765 0.870588";
				visible = "True";
				tag = "IDGUI_JOIN_GAME";
				active = "True";
				messageTag = "IDCTG_GS_RADIO_3";
				isCheckbox = "True";
				radioTag = "IDCTG_CMD_BOX_0";
				bitmapRoot = "RAD_JoinMulti";
				isSet = "False";
				mirrorConsoleVar = "False";
			};
		};
	};
};
//--- export object end ---//
