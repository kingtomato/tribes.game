//--- export object begin ---//
instant SimGui::Control "RemovePlayerGui" {
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
	tag = "IDCTG_DIALOG";
	instant FearGui::FGDlgBox "RemovePlayerDialog" {
		position = "208 146";
		extent = "223 187";
		horizSizing = "center";
		vertSizing = "center";
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
		tag = "IDCTG_DIALOG";
		active = "True";
		messageTag = "";
		instant FearGui::FGUniversalButton "DialogReturnButton" {
			position = "59 156";
			extent = "29 19";
			horizSizing = "right";
			vertSizing = "bottom";
			consoleVariable = "";
			consoleCommand = "DeleteCurrentPlayerConfig();";
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
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "BTN_OK";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGUniversalButton "DialogEscapeButton" {
			position = "104 156";
			extent = "60 19";
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
			messageTag = "IDDLG_CANCEL";
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "BTN_Cancel";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGSimpleText {
			position = "34 64";
			extent = "155 17";
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
			ghostFillColor = "0.301961 0.082353 0.058824";
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
			text = "Remove Current Player?";
			align = "left";
			textVPosDelta = "0";
		};
	};
};
//--- export object end ---//
