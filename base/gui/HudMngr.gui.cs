//--- export object begin ---//
instant SimGui::Control "HudMngrGui" {
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
	selectFillColor = "0.745098 0.811765 0.870588";
	ghostFillColor = "0.815686 0.192157 0.160784";
	border = "False";
	borderColor = "0 0 0";
	selectBorderColor = "0.976471 0.827451 0.662745";
	ghostBorderColor = "0.745098 0.811765 0.870588";
	visible = "True";
	tag = "";
	instant FearGui::FearGuiMenu {
		position = "160 80";
		extent = "320 320";
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
		ghostFillColor = "0.678431 0.764706 0.890196";
		border = "False";
		borderColor = "0 0 0";
		selectBorderColor = "0.509804 0.619608 0.843137";
		ghostBorderColor = "0.745098 0.811765 0.870588";
		visible = "True";
		tag = "IDCTG_GAME_SHELL";
		fixedSize = "320 320";
		instant FearGui::FearGuiSwitch {
			position = "160 80";
			extent = "24 18";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.713726 0.776471 0.760784";
			ghostFillColor = "0.745098 0.811765 0.870588";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0 0 0";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			active = "True";
			messageTag = "";
			targetTag = "IDCTG_HUD_CMD_DISPLAY";
			bmpOnTag = "IDBMP_BACKPACK_ON";
			bmpOffTag = "IDBMP_BACKPACK_OFF";
			transparent = "True";
		};
		instant FearGui::FearGuiSwitch {
			position = "40 40";
			extent = "24 18";
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
			ghostFillColor = "0.282353 0.870588 0.94902";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.419608 0.243137 0.152941";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			active = "True";
			messageTag = "";
			targetTag = "IDCTG_HUD_WEAPON";
			bmpOnTag = "IDBMP_WEAPON_ON";
			bmpOffTag = "IDBMP_WEAPON_OFF";
			transparent = "True";
		};
		instant FearGui::FearGuiSwitch {
			position = "80 40";
			extent = "24 18";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.537255 0.631373 0.85098";
			ghostFillColor = "0.015686 0.007843 0.003922";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.701961 0.780392 0.894118";
			ghostBorderColor = "0.537255 0.631373 0.85098";
			visible = "True";
			tag = "";
			active = "True";
			messageTag = "";
			targetTag = "IDCTG_HUD_CLOCK";
			bmpOnTag = "IDBMP_CLOCK_ON";
			bmpOffTag = "IDBMP_CLOCK_OFF";
			transparent = "True";
		};
		instant FearGui::FearGuiSwitch {
			position = "120 40";
			extent = "24 18";
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
			ghostFillColor = "0.360784 0.301961 0.192157";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0 0 0";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			active = "True";
			messageTag = "";
			targetTag = "IDCTG_HUD_COMPASS";
			bmpOnTag = "IDBMP_COMPASS_ON";
			bmpOffTag = "IDBMP_COMPASS_OFF";
			transparent = "True";
		};
		instant FearGui::FearGuiSwitch {
			position = "160 40";
			extent = "24 18";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.435294 0.423529 0.423529";
			ghostFillColor = "0 0 0.003922";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.533333 0.635294 0.607843";
			ghostBorderColor = "0.435294 0.423529 0.423529";
			visible = "True";
			tag = "";
			active = "True";
			messageTag = "";
			targetTag = "IDCTG_HUD_CROSSHAIR";
			bmpOnTag = "IDBMP_RETICLE_ON";
			bmpOffTag = "IDBMP_RETICLE_OFF";
			transparent = "True";
		};
		instant FearGui::FearGuiSwitch {
			position = "40 80";
			extent = "24 18";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.301961 0.082353 0.058824";
			ghostFillColor = "0 0 0";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0 0 0";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			active = "True";
			messageTag = "";
			targetTag = "IDCTG_HUD_HEALTH";
			bmpOnTag = "IDBMP_BACKPACK_ON";
			bmpOffTag = "IDBMP_BACKPACK_OFF";
			transparent = "True";
		};
		instant FearGui::FearGuiSwitch {
			position = "80 80";
			extent = "24 18";
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
			messageTag = "";
			targetTag = "IDCTG_HUD_JETPACK";
			bmpOnTag = "IDBMP_BACKPACK_ON";
			bmpOffTag = "IDBMP_BACKPACK_OFF";
			transparent = "True";
		};
		instant FearGui::FearGuiSwitch {
			position = "120 80";
			extent = "24 18";
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
			messageTag = "";
			targetTag = "IDCTG_HUD_CHAT_DISPLAY";
			bmpOnTag = "IDBMP_BACKPACK_ON";
			bmpOffTag = "IDBMP_BACKPACK_OFF";
			transparent = "True";
		};
		instant FearGui::FearGuiSwitch {
			position = "40 120";
			extent = "24 18";
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
			messageTag = "";
			targetTag = "IDBMP_E3_JOINUS";
			bmpOnTag = "IDBMP_BACKPACK_ON";
			bmpOffTag = "IDBMP_BACKPACK_OFF";
			transparent = "True";
		};
	};
};
//--- export object end ---//
