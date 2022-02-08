//--- export object begin ---//
instant SimGui::Control "TrainingGui" {
	position = "0 0";
	extent = "640 480";
	horizSizing = "right";
	vertSizing = "bottom";
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
		backgroundBitmap = "Background0.bmp";
		instant SimGui::Control {
			position = "0 0";
			extent = "50 50";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0 0 0";
			ghostFillColor = "1 1 1";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.772549 0.796078 0.788235";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
		};
		instant FearGui::FGUniversalButton {
			position = "490 430";
			extent = "109 24";
			horizSizing = "left";
			vertSizing = "top";
			consoleVariable = "";
			consoleCommand = "createTrainingServer();";
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
			tag = "";
			active = "True";
			messageTag = "";
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "BTN_Playgame2";
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
			messageTag = "IDGUI_CONNECT";
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
			consoleCommand = "$PlayGameGui =  \"gui/training.gui\";";
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
			consoleCommand = "$PlayGameGui =  \"gui/training.gui\";switchToChat();";
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
		instant FearGui::FearGuiBox {
			position = "211 47";
			extent = "382 367";
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
			instant FearGui::FearGuiScrollCtrl {
				position = "7 5";
				extent = "369 356";
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
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "";
				pbaTag = "IDPBA_SCROLL2_SHELL";
				handleArrowKeys = "True";
				constantHeightThumb = "False";
				horizontalScrollBar = "off";
				verticalScrollBar = "on";
				headerSize = "0 0";
				borderThickness = "0";
				instant SimGui::ScrollContentCtrl "DescBox" {
					position = "0 0";
					extent = "352 356";
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
					ghostFillColor = "0 0 0.003922";
					border = "False";
					borderColor = "0 0 0";
					selectBorderColor = "0.772549 0.796078 0.788235";
					ghostBorderColor = "0 0 0";
					visible = "True";
					tag = "";
					instant FearGuiFormattedText "MissionDescText" {
						position = "0 0";
						extent = "352 234";
						horizSizing = "right";
						vertSizing = "bottom";
						consoleVariable = "";
						consoleCommand = "";
						altConsoleCommand = "";
						deleteOnLoseContent = "True";
						ownObjects = "True";
						opaque = "False";
						fillColor = "0 0 0";
						selectFillColor = "0.788235 0.505882 0.278431";
						ghostFillColor = "0.788235 0.505882 0.278431";
						border = "False";
						borderColor = "0 0 0";
						selectBorderColor = "0.976471 0.827451 0.662745";
						ghostBorderColor = "0.976471 0.827451 0.662745";
						visible = "True";
						tag = "";
						active = "False";
						messageTag = "";
					};
				};
			};
		};
		instant FearGui::FearGuiBox {
			position = "42 47";
			extent = "162 217";
			horizSizing = "right";
			vertSizing = "bottom";
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
			instant FearGui::FearGuiScrollCtrl {
				position = "7 5";
				extent = "148 204";
				horizSizing = "right";
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
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "";
				pbaTag = "IDPBA_SCROLL2_SHELL";
				handleArrowKeys = "True";
				constantHeightThumb = "False";
				horizontalScrollBar = "off";
				verticalScrollBar = "dynamic";
				headerSize = "0 0";
				borderThickness = "0";
				instant SimGui::ScrollContentCtrl {
					position = "0 0";
					extent = "148 204";
					horizSizing = "right";
					vertSizing = "bottom";
					consoleVariable = "";
					consoleCommand = "";
					altConsoleCommand = "";
					deleteOnLoseContent = "True";
					ownObjects = "True";
					opaque = "False";
					fillColor = "0 0 0";
					selectFillColor = "0 0 0";
					ghostFillColor = "0 0 0.003922";
					border = "False";
					borderColor = "0 0 0";
					selectBorderColor = "0.772549 0.796078 0.788235";
					ghostBorderColor = "0 0 0";
					visible = "True";
					tag = "";
					instant FearGui::FGTextList "TrainingMissionTextList" {
						position = "0 0";
						extent = "640 136";
						horizSizing = "right";
						vertSizing = "bottom";
						consoleVariable = "$pref::LastTrainingMission";
						consoleCommand = "";
						altConsoleCommand = "";
						deleteOnLoseContent = "True";
						ownObjects = "True";
						opaque = "False";
						fillColor = "0 0 0";
						selectFillColor = "0 0 0";
						ghostFillColor = "0.678431 0.443137 0.282353";
						border = "False";
						borderColor = "0 0 0";
						selectBorderColor = "0.772549 0.796078 0.788235";
						ghostBorderColor = "0 0 0";
						visible = "True";
						tag = "";
						active = "True";
						messageTag = "";
						fontNameTag = "IDFNT_10_STANDARD";
						fontNameTagHL = "";
						textVPosDelta = "0";
						enumerateList = "False";
						noDuplicates = "True";
					};
				};
			};
		};
		instant FearGui::FGSimpleText {
			position = "65 270";
			extent = "86 17";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0 0 0";
			ghostFillColor = "0.639216 0.152941 0.035294";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.745098 0.811765 0.870588";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_10_HILITE";
			fontNameTagHL = "IDFNT_10_SELECTED";
			fontNameTagDisabled = "IDFNT_10_DISABLED";
			textTag = "";
			text = "Record Demo";
			align = "left";
			textVPosDelta = "0";
		};
		instant FearGui::FGUniversalButton "RecordDemo" {
			position = "45 271";
			extent = "18 15";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "$recordDemo";
			consoleCommand = "setupRecorderFile();";
			altConsoleCommand = "$recorderFileName = \"\";";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0 0 0";
			ghostFillColor = "0.772549 0.796078 0.788235";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.772549 0.796078 0.788235";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			active = "True";
			messageTag = "";
			isCheckbox = "True";
			radioTag = "";
			bitmapRoot = "BTN_CheckBox";
			isSet = "False";
			mirrorConsoleVar = "True";
		};
	};
	instant FearGui::FGPaletteCtrl {
		position = "223 0";
		extent = "350 34";
		horizSizing = "width";
		vertSizing = "bottom";
		consoleVariable = "";
		consoleCommand = "";
		altConsoleCommand = "";
		deleteOnLoseContent = "True";
		ownObjects = "True";
		opaque = "False";
		fillColor = "0 0 0";
		selectFillColor = "0.12549 0.105882 0.082353";
		ghostFillColor = "0.14902 0.07451 0.019608";
		border = "False";
		borderColor = "0 0 0";
		selectBorderColor = "0.419608 0.247059 0.078431";
		ghostBorderColor = "0.419608 0.247059 0.078431";
		visible = "True";
		tag = "";
		instant FearGui::FGUniversalButton {
			position = "138 19";
			extent = "74 11";
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
			bitmapRoot = "TTL_Training";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
	};
};
//--- export object end ---//
