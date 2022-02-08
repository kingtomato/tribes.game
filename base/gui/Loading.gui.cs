//--- export object begin ---//
instant SimGui::BitmapCtrl "LoadingGui" {
	position = "0 0";
	extent = "512 384";
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
	ghostFillColor = "0.454902 0.427451 0.329412";
	border = "False";
	borderColor = "0 0 0";
	selectBorderColor = "0.439216 0.576471 0.337255";
	ghostBorderColor = "0.745098 0.811765 0.870588";
	visible = "True";
	tag = "";
	active = "False";
	messageTag = "";
	bmpTag = "IDBMP_BG3";
	transparent = "False";
	instant FearGui::FGPaletteCtrl {
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
		selectFillColor = "0.745098 0.811765 0.870588";
		ghostFillColor = "0.345098 0.321569 0.286275";
		border = "False";
		borderColor = "0 0 0";
		selectBorderColor = "0 0.517647 0";
		ghostBorderColor = "0 0 0";
		visible = "True";
		tag = "";
	};
	instant FearGui::FGUniversalButton {
		position = "40 334";
		extent = "82 23";
		horizSizing = "right";
		vertSizing = "top";
		consoleVariable = "";
		consoleCommand = "endGame();";
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
		active = "True";
		messageTag = "";
		isCheckbox = "False";
		radioTag = "";
		bitmapRoot = "BTN_Back";
		isSet = "False";
		mirrorConsoleVar = "False";
	};
	instant SimGui::Control {
		position = "119 342";
		extent = "273 36";
		horizSizing = "center";
		vertSizing = "top";
		consoleVariable = "";
		consoleCommand = "";
		altConsoleCommand = "";
		deleteOnLoseContent = "True";
		ownObjects = "True";
		opaque = "False";
		fillColor = "0.172549 0.6 0.070588";
		selectFillColor = "0 0 0";
		ghostFillColor = "0 0 0";
		border = "False";
		borderColor = "0 0 0";
		selectBorderColor = "0 0 0";
		ghostBorderColor = "0 0 0";
		visible = "True";
		tag = "";
		instant FearGuiFormattedText "ProgressText" {
			position = "1 0";
			extent = "273 0";
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
			selectBorderColor = "0.643137 0.705882 0.662745";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
		};
	};
	instant SimGui::ProgressCtrl "ProgressSlider" {
		position = "136 323";
		extent = "240 16";
		horizSizing = "center";
		vertSizing = "top";
		consoleVariable = "";
		consoleCommand = "";
		altConsoleCommand = "";
		deleteOnLoseContent = "True";
		ownObjects = "True";
		opaque = "False";
		fillColor = "0.172549 0.6 0.070588";
		selectFillColor = "0 0 0";
		ghostFillColor = "1 0 1";
		border = "False";
		borderColor = "0 1 0";
		selectBorderColor = "0.596078 0.682353 0.866667";
		ghostBorderColor = "0 0 0";
		visible = "True";
		tag = "";
		active = "False";
		messageTag = "";
		rangeLow = "1";
		rangeHigh = "100";
		increment = "1";
	};
	instant SimGui::Control {
		position = "72 140";
		extent = "440 80";
		horizSizing = "center";
		vertSizing = "top";
		consoleVariable = "";
		consoleCommand = "";
		altConsoleCommand = "";
		deleteOnLoseContent = "True";
		ownObjects = "True";
		opaque = "False";
		fillColor = "1 0 1";
		selectFillColor = "0 0 0";
		ghostFillColor = "0.431373 0.341176 0.239216";
		border = "False";
		borderColor = "0 0 0";
		selectBorderColor = "0.772549 0.831373 0.843137";
		ghostBorderColor = "0 0 0";
		visible = "True";
		tag = "";
		instant FearGuiFormattedText "ModTextString" {
			position = "0 0";
			extent = "440 6";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "";
			altConsoleCommand = "";
			deleteOnLoseContent = "True";
			ownObjects = "True";
			opaque = "False";
			fillColor = "0 0 0";
			selectFillColor = "0.419608 0.247059 0.078431";
			ghostFillColor = "0.419608 0.247059 0.078431";
			border = "False";
			borderColor = "0 0 0";
			selectBorderColor = "0.419608 0.247059 0.078431";
			ghostBorderColor = "0.419608 0.247059 0.078431";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
		};
	};
};
//--- export object end ---//
