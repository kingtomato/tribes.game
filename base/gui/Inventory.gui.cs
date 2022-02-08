//--- export object begin ---//
instant SimGui::Control "InventoryGui" {
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
	ghostFillColor = "0.611765 0.07451 0.015686";
	border = "False";
	borderColor = "0 0 0";
	selectBorderColor = "0.454902 0.215686 0.023529";
	ghostBorderColor = "0.352941 0.482353 0.360784";
	visible = "True";
	tag = "";
	instant FearGui::FearGuiMenu {
		position = "110 80";
		extent = "420 320";
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
		ghostFillColor = "0.811765 0.368627 0.34902";
		border = "False";
		borderColor = "0 0 0";
		selectBorderColor = "0 0 0";
		ghostBorderColor = "0 0 0";
		visible = "True";
		tag = "IDCTG_GAME_SHELL";
		fixedSize = "420 320";
		instant SimGui::MatrixCtrl {
			position = "211 24";
			extent = "189 220";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.745098 0.811765 0.870588";
			ghostFillColor = "0.560784 0.490196 0.411765";
			border = "False";
			borderColor = "0.180392 0.309804 0.521569";
			selectBorderColor = "0.180392 0.309804 0.521569";
			ghostBorderColor = "0.721569 0.537255 0.447059";
			visible = "True";
			tag = "";
			pbaTag = "IDPBA_SCROLL_HUD";
			handleArrowKeys = "False";
			constantHeightThumb = "False";
			horizontalScrollBar = "off";
			verticalScrollBar = "on";
			headerSize = "0 31";
			instant SimGui::ScrollContentCtrl {
				position = "0 0";
				extent = "170 220";
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
				ghostFillColor = "0.560784 0.478431 0.533333";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.388235 0.101961 0.090196";
				ghostBorderColor = "0.301961 0.082353 0.058824";
				visible = "True";
				tag = "";
				instant FearGui::FGHInventory {
					position = "0 0";
					extent = "170 181";
					horizSizing = "right";
					vertSizing = "bottom";
					consoleVariable = "";
					consoleCommand = "";
					altConsoleCommand = "";
					deleteOnLoseContent = "True";
					ownObjects = "True";
					opaque = "False";
					fillColor = "0 0 0";
					selectFillColor = "0.643137 0.705882 0.662745";
					ghostFillColor = "0.647059 0.733333 0.858824";
					border = "False";
					borderColor = "0 0 0";
					selectBorderColor = "0.682353 0.756863 0.886275";
					ghostBorderColor = "0.643137 0.705882 0.662745";
					visible = "True";
					tag = "IDCTG_INV_CURRENT";
					active = "True";
					messageTag = "";
				};
			};
		};
		instant SimGui::SimpleText {
			position = "18 24";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "IDSTR_INV_ARMOR";
			text = "ARMOR";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "18 42";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "IDSTR_INV_PACK";
			text = "PACK";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "18 60";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "IDSTR_INV_SENSOR";
			text = "SENSOR";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "18 96";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "IDSTR_INV_WEAPON_1";
			text = "WEAPON 1";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "18 114";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "IDSTR_INV_WEAPON_2";
			text = "WEAPON 2";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "18 132";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "IDSTR_INV_WEAPON_3";
			text = "WEAPON 3";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "18 150";
			extent = "80 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "IDSTR_INV_WEAPON_4";
			text = "WEAPON 4";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "110 24";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "IDCTG_INV_ARMOR";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "";
			text = "N/A";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "110 42";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "IDCTG_INV_PACK";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "";
			text = "N/A";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "110 60";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "IDCTG_INV_SENSOR";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "";
			text = "N/A";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "110 96";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "IDCTG_INV_WEAPON_1";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "";
			text = "N/A";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "110 114";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "IDCTG_INV_WEAPON_2";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "";
			text = "N/A";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "110 132";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "IDCTG_INV_WEAPON_3";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "";
			text = "N/A";
			align = "left";
			textVPosDelta = "0";
		};
		instant SimGui::SimpleText {
			position = "110 150";
			extent = "100 25";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.109804 0.976471 0.984314";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.580392 0.721569 0.717647";
			ghostBorderColor = "0.109804 0.976471 0.984314";
			visible = "True";
			tag = "IDCTG_INV_WEAPON_4";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_HUD_10_STANDARD";
			fontNameTagHL = "IDFNT_FONT_DEFAULT";
			fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
			textTag = "";
			text = "N/A";
			align = "left";
			textVPosDelta = "0";
		};
		instant FearGui::FGUniversalButton {
			position = "353 262";
			extent = "47 34";
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
			active = "True";
			messageTag = "IDACTION_ESCAPE_PRESSED";
			isCheckbox = "True";
			radioTag = "";
			bitmapRoot = "";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGUniversalButton {
			position = "282 262";
			extent = "29 21";
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
			tag = "IDCTG_INV_DROP";
			active = "True";
			messageTag = "IDCTG_INV_DROP";
			isCheckbox = "True";
			radioTag = "";
			bitmapRoot = "";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGUniversalButton {
			position = "211 262";
			extent = "29 21";
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
			tag = "IDCTG_INV_USE";
			active = "True";
			messageTag = "IDCTG_INV_USE";
			isCheckbox = "True";
			radioTag = "";
			bitmapRoot = "";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
	};
};
//--- export object end ---//