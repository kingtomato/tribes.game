//--- export object begin ---//
instant SimGui::Control "MessageDialogGui" {
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
	instant FearGui::FGDlgBox "MessageDialog" {
		position = "119 146";
		extent = "403 187";
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
		instant FearGui::FGUniversalButton "DialogCloseButton" {
			position = "179 156";
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
			messageTag = "IDDLG_CANCEL";
			isCheckbox = "False";
			radioTag = "";
			bitmapRoot = "BTN_Done";
			isSet = "False";
			mirrorConsoleVar = "False";
		};
		instant FearGui::FearGuiScrollCtrl {
			position = "40 36";
			extent = "320 100";
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
			ghostFillColor = "0.419608 0.247059 0.078431";
			border = "False";
			borderColor = "1 1 1";
			selectBorderColor = "0.596078 0.682353 0.866667";
			ghostBorderColor = "0 0 0";
			visible = "True";
			tag = "";
			pbaTag = "IDPBA_SCROLL2_SHELL";
			handleArrowKeys = "True";
			constantHeightThumb = "False";
			horizontalScrollBar = "off";
			verticalScrollBar = "dynamic";
			headerSize = "0 0";
			borderThickness = "1";
			instant SimGui::ScrollContentCtrl {
				position = "1 1";
				extent = "318 98";
				horizSizing = "right";
				vertSizing = "bottom";
				consoleVariable = "";
				consoleCommand = "";
				altConsoleCommand = "";
				deleteOnLoseContent = "True";
				ownObjects = "True";
				opaque = "False";
				fillColor = "0 0 0";
				selectFillColor = "0.14902 0.07451 0.019608";
				ghostFillColor = "0.14902 0.07451 0.019608";
				border = "False";
				borderColor = "1 1 1";
				selectBorderColor = "0.14902 0.07451 0.019608";
				ghostBorderColor = "0.14902 0.07451 0.019608";
				visible = "True";
				tag = "";
				instant FearGuiFormattedText "MessageDialogTextFormat" {
					position = "0 0";
					extent = "318 98";
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
				};
			};
		};
	};
};
//--- export object end ---//