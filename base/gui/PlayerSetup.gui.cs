//--- export object begin ---//
instant SimGui::Control "PlayerSetupGui" {
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
	tag = "IDGUI_PLAYER_SETUP";
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
		instant FearGui::FearGuiBox {
			position = "42 72";
			extent = "556 347";
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
			ghostFillColor = "0.819608 0.945098 0.952941";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.772549 0.796078 0.788235";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			instant FearGui::FGSimpleText {
				position = "98 17";
				extent = "43 17";
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
				ghostFillColor = "0.219608 0.694118 0.090196";
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
				text = "Female";
				align = "left";
				textVPosDelta = "0";
			};
			instant FearGui::FGSimpleText {
				position = "34 17";
				extent = "29 17";
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
				ghostFillColor = "0.666667 0.619608 0";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "";
				active = "False";
				messageTag = "";
				fontNameTag = "IDFNT_10_HILITE";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "";
				text = "Male";
				align = "left";
				textVPosDelta = "0";
			};
			instant FearGui::FearGuiBox {
				position = "286 51";
				extent = "259 283";
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
				instant FearGui::SkinView {
					position = "5 4";
					extent = "251 274";
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
					ghostFillColor = "0.145098 0.329412 0.05098";
					border = "False";
					borderColor = "0 0 0";
					selectBorderColor = "0.772549 0.796078 0.788235";
					ghostBorderColor = "0 0 0";
					visible = "True";
					tag = "IDCTG_PLAYER_TS";
					active = "True";
					messageTag = "";
				};
			};
			instant SimGui::Control {
				position = "282 18";
				extent = "263 33";
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
				ghostFillColor = "0.992157 0.996078 0.992157";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "";
				instant FearGui::FGUniversalButton {
					position = "244 5";
					extent = "12 17";
					horizSizing = "left";
					vertSizing = "bottom";
					consoleVariable = "";
					consoleCommand = "FGCombo::selectNext(IDCTG_PLYR_CFG_SKIN);";
					altConsoleCommand = "";
					deleteOnLoseContent = "True";
					ownObjects = "True";
					opaque = "False";
					fillColor = "0 0 0";
					selectFillColor = "0.443137 0.360784 0.282353";
					ghostFillColor = "0.443137 0.360784 0.282353";
					border = "False";
					borderColor = "0 0 0";
					selectBorderColor = "0.529412 0.298039 0.054902";
					ghostBorderColor = "0.682353 0.321569 0.137255";
					visible = "True";
					tag = "";
					active = "True";
					messageTag = "";
					isCheckbox = "False";
					radioTag = "";
					bitmapRoot = "IRC_ScrollRight";
					isSet = "False";
					mirrorConsoleVar = "False";
				};
				instant FearGui::FGStandardComboBox {
					position = "17 5";
					extent = "227 19";
					horizSizing = "width";
					vertSizing = "bottom";
					consoleVariable = "";
					consoleCommand = "SelectPlayerSkin();";
					altConsoleCommand = "";
					deleteOnLoseContent = "True";
					ownObjects = "True";
					opaque = "False";
					fillColor = "0 0 0";
					selectFillColor = "0.709804 0.45098 0.160784";
					ghostFillColor = "0.709804 0.45098 0.160784";
					border = "False";
					borderColor = "0 0 0";
					selectBorderColor = "0.709804 0.45098 0.160784";
					ghostBorderColor = "0.709804 0.45098 0.160784";
					visible = "True";
					tag = "IDCTG_PLYR_CFG_SKIN";
					active = "True";
					messageTag = "";
					fontNameTag = "IDFNT_FONT_DEFAULT";
					fontNameTagHL = "IDFNT_FONT_DEFAULT";
					fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
					textTag = "";
					text = "base";
					align = "left";
					textVPosDelta = "0";
					comboTitle = "Skin";
				};
				instant FearGui::FGUniversalButton {
					position = "5 5";
					extent = "12 17";
					horizSizing = "right";
					vertSizing = "bottom";
					consoleVariable = "";
					consoleCommand = "FGCombo::selectPrev(IDCTG_PLYR_CFG_SKIN);";
					altConsoleCommand = "";
					deleteOnLoseContent = "True";
					ownObjects = "True";
					opaque = "False";
					fillColor = "0 0 0";
					selectFillColor = "0.443137 0.360784 0.282353";
					ghostFillColor = "0.443137 0.360784 0.282353";
					border = "False";
					borderColor = "0 0 0";
					selectBorderColor = "0.529412 0.298039 0.054902";
					ghostBorderColor = "0.682353 0.321569 0.137255";
					visible = "True";
					tag = "";
					active = "True";
					messageTag = "";
					isCheckbox = "False";
					radioTag = "";
					bitmapRoot = "IRC_ScrollLeft";
					isSet = "False";
					mirrorConsoleVar = "False";
				};
			};
			instant FearGui::FGUniversalButton {
				position = "14 18";
				extent = "18 15";
				horizSizing = "right";
				vertSizing = "bottom";
				consoleVariable = "";
				consoleCommand = "SwitchGender(\"MALE\");";
				altConsoleCommand = "";
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
				tag = "IDCTG_PLYR_CFG_GENDER_M";
				active = "True";
				messageTag = "";
				isCheckbox = "False";
				radioTag = "IDCTG_PLYR_CFG_GENDER_M";
				bitmapRoot = "BTN_CheckBox";
				isSet = "True";
				mirrorConsoleVar = "False";
			};
			instant FearGui::FGUniversalButton {
				position = "78 19";
				extent = "18 15";
				horizSizing = "right";
				vertSizing = "bottom";
				consoleVariable = "";
				consoleCommand = "SwitchGender(\"FEMALE\");";
				altConsoleCommand = "";
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
				tag = "IDCTG_PLYR_CFG_GENDER_F";
				active = "True";
				messageTag = "";
				isCheckbox = "False";
				radioTag = "IDCTG_PLYR_CFG_GENDER_M";
				bitmapRoot = "BTN_CheckBox";
				isSet = "False";
				mirrorConsoleVar = "False";
			};
			instant FearGui::FGSimpleText {
				position = "12 86";
				extent = "68 17";
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
				active = "False";
				messageTag = "";
				fontNameTag = "IDFNT_10_HILITE";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "IDSTR_062";
				text = "Real Name";
				align = "left";
				textVPosDelta = "0";
			};
			instant FearGui::FGSimpleText {
				position = "12 108";
				extent = "32 17";
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
				active = "False";
				messageTag = "";
				fontNameTag = "IDFNT_10_HILITE";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "IDSTR_064";
				text = "EMail";
				align = "left";
				textVPosDelta = "0";
			};
			instant FearGui::FGSimpleText {
				position = "12 130";
				extent = "33 17";
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
				active = "False";
				messageTag = "";
				fontNameTag = "IDFNT_10_HILITE";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "IDSTR_066";
				text = "Tribe";
				align = "left";
				textVPosDelta = "0";
			};
			instant FearGui::FGSimpleText {
				position = "12 152";
				extent = "64 17";
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
				active = "False";
				messageTag = "";
				fontNameTag = "IDFNT_10_HILITE";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "IDSTR_067";
				text = "Tribe URL";
				align = "left";
				textVPosDelta = "0";
			};
			instant FearGui::FGSimpleText {
				position = "12 174";
				extent = "68 17";
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
				active = "False";
				messageTag = "";
				fontNameTag = "IDFNT_10_HILITE";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "IDSTR_065";
				text = "Other Info";
				align = "left";
				textVPosDelta = "0";
			};
			instant FearGui::TestEdit {
				position = "109 86";
				extent = "160 19";
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
				ghostFillColor = "0.980392 0.862745 0.027451";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "IDCTG_PLYR_CFG_NAME";
				active = "True";
				messageTag = "IDHELP_PLAYER_REAL_NAME";
				fontNameTag = "IDFNT_10_STANDARD";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "";
				text = "";
				align = "left";
				textVPosDelta = "0";
				numbersOnly = "False";
				maxStrLen = "40";
			};
			instant FearGui::TestEdit {
				position = "109 108";
				extent = "160 19";
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
				ghostFillColor = "0.980392 0.862745 0.027451";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "IDCTG_PLYR_CFG_EMAIL";
				active = "True";
				messageTag = "IDHELP_PLAYER_EMAIL";
				fontNameTag = "IDFNT_10_STANDARD";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "";
				text = "";
				align = "left";
				textVPosDelta = "0";
				numbersOnly = "False";
				maxStrLen = "40";
			};
			instant FearGui::TestEdit {
				position = "109 130";
				extent = "160 19";
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
				ghostFillColor = "0.980392 0.862745 0.027451";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "IDCTG_PLYR_CFG_TRIBE";
				active = "True";
				messageTag = "IDHELP_PLAYER_TRIBE";
				fontNameTag = "IDFNT_10_STANDARD";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "";
				text = "";
				align = "left";
				textVPosDelta = "0";
				numbersOnly = "False";
				maxStrLen = "40";
			};
			instant FearGui::TestEdit {
				position = "109 152";
				extent = "160 19";
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
				ghostFillColor = "0.980392 0.862745 0.027451";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "IDCTG_PLYR_CFG_URL";
				active = "True";
				messageTag = "IDHELP_PLAYER_TRIBE_URL";
				fontNameTag = "IDFNT_10_STANDARD";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "";
				text = "";
				align = "left";
				textVPosDelta = "0";
				numbersOnly = "False";
				maxStrLen = "40";
			};
			instant FearGui::TestEdit {
				position = "109 174";
				extent = "160 19";
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
				ghostFillColor = "0.980392 0.862745 0.027451";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "IDCTG_PLYR_CFG_INFO";
				active = "True";
				messageTag = "IDHELP_PLAYER_OTHER_INFO";
				fontNameTag = "IDFNT_10_STANDARD";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "";
				text = "";
				align = "left";
				textVPosDelta = "0";
				numbersOnly = "False";
				maxStrLen = "40";
			};
			instant FearGui::FGSimpleText {
				position = "12 196";
				extent = "90 17";
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
				active = "False";
				messageTag = "";
				fontNameTag = "IDFNT_10_HILITE";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "";
				text = "Custom Script";
				align = "left";
				textVPosDelta = "0";
			};
			instant FearGui::TestEdit {
				position = "109 196";
				extent = "160 19";
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
				ghostFillColor = "0.980392 0.862745 0.027451";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "IDCTG_PLYR_CFG_SCRIPT";
				active = "True";
				messageTag = "IDHELP_PLAYER_SCRIPT";
				fontNameTag = "IDFNT_10_STANDARD";
				fontNameTagHL = "IDFNT_10_SELECTED";
				fontNameTagDisabled = "IDFNT_10_DISABLED";
				textTag = "";
				text = "";
				align = "left";
				textVPosDelta = "0";
				numbersOnly = "False";
				maxStrLen = "40";
			};
			instant FearGui::FGStandardComboBox {
				position = "9 51";
				extent = "189 19";
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
				ghostFillColor = "0.388235 0.666667 0.819608";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "IDCTG_PLYR_CFG_VOICE";
				active = "True";
				messageTag = "";
				fontNameTag = "IDFNT_FONT_DEFAULT";
				fontNameTagHL = "IDFNT_FONT_DEFAULT";
				fontNameTagDisabled = "IDFNT_FONT_DEFAULT";
				textTag = "";
				text = "female4";
				align = "left";
				textVPosDelta = "0";
				comboTitle = "Voice Set";
			};
			instant FearGui::FGUniversalButton {
				position = "218 51";
				extent = "17 21";
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
				tag = "IDCTG_PLYR_CFG_VOICE_TEST";
				active = "True";
				messageTag = "IDCTG_PLYR_CFG_VOICE_TEST";
				isCheckbox = "False";
				radioTag = "";
				bitmapRoot = "BTN_Hear";
				isSet = "False";
				mirrorConsoleVar = "False";
			};
		};
		instant FearGui::FGUniversalButton {
			position = "520 430";
			extent = "81 23";
			horizSizing = "left";
			vertSizing = "top";
			consoleVariable = "";
			consoleCommand = "PlayerSetupNext();";
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
			messageTag = "IDCTG_PLYR_CFG_WRITE";
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
			consoleCommand = "";
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
			messageTag = "IDGUI_MAIN_MENU";
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
			consoleCommand = "$PlayGameGui =  \"gui/PlayerSetup.gui\";";
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
			consoleCommand = "$PlayGameGui =  \"gui/PlayerSetup.gui\";switchToChat();";
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
			messageTag = "IDCTG_PLYR_CFG_WRITE";
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
		instant FearGui::FGStandardComboBox {
			position = "49 45";
			extent = "220 19";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "SelectedPlayerConfig();";
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
			tag = "IDCTG_PLYR_CFG_COMBO";
			active = "True";
			messageTag = "";
			fontNameTag = "IDFNT_9_STANDARD";
			fontNameTagHL = "IDFNT_9_SELECTED";
			fontNameTagDisabled = "IDFNT_9_DISABLED";
			textTag = "";
			text = "ARTICHOKE";
			align = "left";
			textVPosDelta = "0";
			comboTitle = "Player";
		};
		instant SimGui::Control {
			position = "257 418";
			extent = "125 37";
			horizSizing = "center";
			vertSizing = "top";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0 0 0";
			ghostFillColor = "0.466667 0.403922 0.258824";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.772549 0.796078 0.788235";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			instant FearGui::FGUniversalButton {
				position = "1 9";
				extent = "63 19";
				horizSizing = "right";
				vertSizing = "bottom";
				consoleVariable = "";
				consoleCommand = "GuiPushDialog(MainWindow,  \"gui/RemovePlayer.gui\");";
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
				tag = "IDCTG_REMOVE_PLAYER";
				active = "True";
				messageTag = "";
				isCheckbox = "False";
				radioTag = "";
				bitmapRoot = "BTN_Remove";
				isSet = "False";
				mirrorConsoleVar = "False";
			};
			instant FearGui::FGUniversalButton {
				position = "80 9";
				extent = "38 19";
				horizSizing = "right";
				vertSizing = "bottom";
				consoleVariable = "";
				consoleCommand = "OpenNewPlayerDialog();";
				altConsoleCommand = "";
				deleteOnLoseContent = "True";
				ownObjects = "True";
				opaque = "False";
				fillColor = "0 0 0";
				selectFillColor = "0 0 0";
				ghostFillColor = "0.768627 0.74902 0.74902";
				border = "False";
				borderColor = "0 0 0";
				selectBorderColor = "0.772549 0.796078 0.788235";
				ghostBorderColor = "0 0 0";
				visible = "True";
				tag = "IDDLG_ADD_PLAYER";
				active = "True";
				messageTag = "";
				isCheckbox = "False";
				radioTag = "";
				bitmapRoot = "BTN_New";
				isSet = "False";
				mirrorConsoleVar = "False";
			};
		};
	};
	instant SimGui::Control {
		position = "223 10";
		extent = "348 26";
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
		ghostFillColor = "0.360784 0.419608 0.560784";
		border = "False";
		borderColor = "0 0 0";
		selectBorderColor = "0.772549 0.796078 0.788235";
		ghostBorderColor = "0 0 0";
		visible = "True";
		tag = "";
		instant FearGui::FGUniversalButton {
			position = "122 9";
			extent = "104 13";
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
			bitmapRoot = "TTL_PlayerSetup";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
	};
};
//--- export object end ---//