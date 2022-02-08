//--- export object begin ---//
instant SimGui::Control "NewFilterGui" {
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
	instant FearGui::FGDlgBox {
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
		instant FearGui::TestEdit {
			position = "40 96";
			extent = "140 19";
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
			tag = "IDCTG_NEW_FILTER_TEXT";
			active = "True";
			messageTag = "";
			fontNameTag = "IDFNT_10_STANDARD";
			fontNameTagHL = "IDFNT_10_SELECTED";
			fontNameTagDisabled = "IDFNT_10_DISABLED";
			textTag = "";
			text = "";
			align = "left";
			textVPosDelta = "-2";
			numbersOnly = "False";
			maxStrLen = "80";
		};
		instant FearGui::FGUniversalButton {
			position = "67 40";
			extent = "88 13";
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
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "TTL_NewFilter";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGUniversalButton "DialogEscapeButton" {
			position = "112 156";
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
		instant FearGui::FGUniversalButton "DialogReturnButton" {
			position = "51 156";
			extent = "45 19";
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
			messageTag = "IDCTG_NEW_FILTER";
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "BTN_DONE";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
	};
};
//--- export object end ---//
