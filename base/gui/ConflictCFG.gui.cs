//--- export object begin ---//
instant SimGui::Control "ConflictCFGGui" {
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
		position = "190 146";
		extent = "259 187";
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
		active = "True";
		messageTag = "";
		instant FearGui::FGSimpleText {
			position = "30 30";
			extent = "181 17";
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
			selectBorderColor = "0.509804 0.509804 0.509804";
			ghostBorderColor = "0.243137 0.431373 0.223529";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_10_HILITE";
			fontNameTagHL = "IDFNT_10_SELECTED";
			fontNameTagDisabled = "IDFNT_10_DISABLED";
			textTag = "";
			text = "4 has already been bound to";
			align = "left";
			textVPosDelta = "0";
		};
		instant FearGui::FGSimpleText {
			position = "30 43";
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
			selectBorderColor = "0.509804 0.509804 0.509804";
			ghostBorderColor = "0.243137 0.431373 0.223529";
			visible = "True";
			tag = "";
			active = "True";
			messageTag = "";
			fontNameTag = "IDFNT_10_HILITE";
			fontNameTagHL = "IDFNT_10_SELECTED";
			fontNameTagDisabled = "IDFNT_10_DISABLED";
			textTag = "";
			text = "Chain Gun";
			align = "left";
			textVPosDelta = "0";
		};
		instant FearGui::FGSimpleText {
			position = "30 82";
			extent = "190 17";
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
			selectBorderColor = "0.509804 0.509804 0.509804";
			ghostBorderColor = "0.243137 0.431373 0.223529";
			visible = "True";
			tag = "";
			active = "False";
			messageTag = "";
			fontNameTag = "IDFNT_10_HILITE";
			fontNameTagHL = "IDFNT_10_SELECTED";
			fontNameTagDisabled = "IDFNT_10_DISABLED";
			textTag = "";
			text = "Do you still wish to continue?";
			align = "left";
			textVPosDelta = "0";
		};
		instant FearGui::FGUniversalButton {
			position = "128 156";
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
			tag = "IDCTG_OPTS_CTRL_CFG_CANCEL";
			active = "True";
			messageTag = "IDCTG_OPTS_CTRL_CFG_CANCEL";
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "BTN_Cancel";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FGUniversalButton {
			position = "67 156";
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
			tag = "IDCTG_OPTS_CTRL_CFG_DONE";
			active = "True";
			messageTag = "IDCTG_OPTS_CTRL_CFG_DONE";
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "BTN_Done";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
	};
};
//--- export object end ---//
