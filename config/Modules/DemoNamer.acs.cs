Event::Attach( eventLeaveServer, DemoNamer::onLeaveServer );

function DemoNamer::onLeaveServer() {
	$recorderFileName = "";
}

function setupRecorderFile() {
	%str = timestamp();
	%time = String::GetSubStr(%str, 0, 4)@ "-" @String::GetSubStr(%str, 5, 2) @ "-" @String::GetSubStr(%str, 8, 2) @ "-" @String::GetSubStr(%str, 11, 2) @ "." @String::GetSubStr(%str, 14, 2) @ "." @String::GetSubStr(%str, 17, 2);

	//if ($ServerName != "")
	//	%time = %time @ "-" @ $ServerName;

	$recorderFileName = "recordings\\" @ %time @ ".rec";
	echo("Recording to - " @ $recorderFileName);
}
