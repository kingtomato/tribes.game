// added Demo Drop bind for 1.40, AutoDemo and better demo namer

$AutoName::Recording = "";
$AutoName::AutoDemo = false;

// 1.40 hack to insert binds into the menu
function DemoDrop::addBindsToMenu() after GameBinds::Init
{
	$GameBinds::CurrentMap = "actionMap.sae";
	$GameBinds::CurrentMapHandle = GameBinds::GetActionMap2( "actionMap.sae" );
	GameBinds::addBindCommand( "Demo Drop", "DemoDrop::Start();");
}

function DemoDrop::Start()
{
	if ($PlayingDemo)
		return;
	Schedule::Add("DemoDrop::SetupDemo();", 1);
}

function DemoDrop::SetupDemo(%address)
{
	if ($PlayingDemo)
		return;

	$ConnectedToServer = FALSE;

	setCursor(MainWindow, "Cur_Arrow.bmp");

	disconnect();
	Event::Trigger(eventDisconnected);

	deleteObject(ConsoleScheduler);
	newObject(ConsoleScheduler, SimConsoleScheduler);

	cursorOn(MainWindow);

	$recordDemo = true;

	setupRecorderFile();
	myConnect($Server::Address, $Server::JoinPassword);
}

function setupRecorderFile()
{
	//returns time in global $time
	$f = AutoName::StripString("("@timestamp::format()@")-"@$PCFG::Name);
	$recorderFileName = "recordings\\" @ $f @ ".rec";

	//autoname stuff
	$AutoName::Stub = $f;
	$AutoName::Dummy = $recorderFileName;
	$AutoName::Recording = true;
	$AutoName::Maps = 0;
	
	echo("Recording to - " @ $recorderFileName);
}

function AutoName::Stop()
{
	if (!$AutoName::Recording || $PlayingDemo || $AutoName::Maps==0)
		return;

	%str = "";
	//build a list of the maps we played
	for (%i = 0; %i< $AutoName::Maps; %i++)
	{
		%m = $AutoName::MapList[%i];
		%map = $AutoName::Lookup[ %m ];
		
		if (%map == "")
		{
			//see if its an lt map
			%lttest = String::GetSubStr(%m, 0, String::Length(%m)-2);
			%map = $AutoName::Lookup[%lttest];
			if ( %map != "" )
				%map = %map @ "-lt";
			else
				%map = %m;
		}
		
		%str = %str @ "-" @ %map;
	}
	
	%dst = "Recordings\\" @ $AutoName::Stub @ %str @ ".rec";
	echo ("k/os: Trying to Copy... " @ $AutoName::Dummy @ " to " @ %dst);
	
	//try to copy the original demo to our new name
	if (File::copy($AutoName::Dummy, %dst))
	{
		echo("k/os: Deleting old recording");
		//delete the old
		File::delete($AutoName::Dummy);
	}

	if ($AutoName::AutoDemo)
		setupRecorderFile();
}

//add new map played
function AutoName::onMissionInfo(%server, %missionName, %ServerMissionType)
{
	if (!$AutoName::Recording)
		return;

	$AutoName::MapList[$AutoName::Maps++ - 1] = String::ToLower( String::Replace(%missionName, "_", "") );
}

//utility shit
function AutoName::StripString(%str)
{
	%str = string::replace(%str, "[",  "_");
	%str = string::replace(%str, "]",  "_");
	%str = string::replace(%str, "<",  "_");
	%str = string::replace(%str, ">",  "_");
	%str = string::replace(%str, "?",  "_");
	%str = string::replace(%str, ":",  "_");
	%str = string::replace(%str, "*",  "_");
	%str = string::replace(%str, "/",  "_");
	%str = string::replace(%str, "\\", "_");
	%str = string::replace(%str, "|",  "_");
	
	return %str;
}

function myConnect(%serverIp, %serverPw)
{
	$Server::Address = %serverIp;
	$Server::JoinPassword = %serverPw;
	connect(%serverIp);
}


//map abbreviations to shorten filenames
$AutoName::Lookup["acrophobia"] = "ac";
$AutoName::Lookup["arcticwolf"] = "aw";
$AutoName::Lookup["Avalanche"] = "av";
$AutoName::Lookup["basatinlt"] = "bs";
$AutoName::Lookup["bastardforge"] = "bf";
$AutoName::Lookup["bastardforgeday"] = "bfd";
$AutoName::Lookup["broadside"] = "bs";
$AutoName::Lookup["canyoncrusadedeluxe"] = "ccdx";
$AutoName::Lookup["canyoncrusade"] = "ccd";
$AutoName::Lookup["cloakofnight"] = "con";
$AutoName::Lookup["dayfall"] = "df";
$AutoName::Lookup["dangerouscrossing"] = "dx";
$AutoName::Lookup["desertofdeath"] = "dod";
$AutoName::Lookup["domino"] = "dm";
$AutoName::Lookup["emeraldvalley"] = "ev";
$AutoName::Lookup["hildebrand"] = "hb";
$AutoName::Lookup["icedagger"] = "id";
$AutoName::Lookup["iceridge"] = "ir";
$AutoName::Lookup["integration"] = "int";
$AutoName::Lookup["jaggedclaw"] = "jc";
$AutoName::Lookup["midnightmayhem"] = "mmd";
$AutoName::Lookup["midnightmayhemdeluxe"] = "mmdx";
$AutoName::Lookup["northernlights"] = "nl";
$AutoName::Lookup["obfuscation"] = "obf";
$AutoName::Lookup["raindance"] = "rd";
$AutoName::Lookup["reliquary"] = "rq";
$AutoName::Lookup["rollercoaster"] = "rc";
$AutoName::Lookup["runout"] = "ro";
$AutoName::Lookup["scarabrae"] = "scara";
$AutoName::Lookup["sidewinder"] = "sw";
$AutoName::Lookup["simoom"] = "sm";
$AutoName::Lookup["snowblind"] = "sb";
$AutoName::Lookup["spincycle"] = "sc";
$AutoName::Lookup["starfall"] = "sf";
$AutoName::Lookup["stonehenge"] = "sh";
$AutoName::Lookup["stonehengepub"] = "sh_pub";
$AutoName::Lookup["stonehengecluster"] = "sh_pub";
$AutoName::Lookup["tesseract"] = "tes";
$AutoName::Lookup["timberline"] = "tl";
$AutoName::Lookup["opensnare"] = "os";
$AutoName::Lookup["firenza"] = "fz";
$AutoName::Lookup["teamside"] = "ts";
$AutoName::Lookup["anthill"] = "ant";
$AutoName::Lookup["fogofwar"] = "fow";
$AutoName::Lookup["citadels"] = "cit";
$AutoName::Lookup["adishbestservedcold"] = "dish";
$AutoName::Lookup["hammerdown"] = "hd";
$AutoName::Lookup["bloodyvengeance"] = "bv";
$AutoName::Lookup["siege"] = "siege";


//patch a few things in to always record (covers almost every situation
if ($AutoName::AutoDemo)
{
	//record demo when clicking join button
	Event::Attach(eventJoinGame, setupRecorderfile);
	//demo drop on map change
	Event::Attach(eventChangeMission, DemoDrop::Start);

	function PlayerSetupNext()
	{
		if ($QuickStart == "TRUE")
			QuickStart();
		else
		{
			if ($PCFG::Name == "")
				OpenNewPlayerDialog();
			else
			GuiLoadContentCtrl(MainWindow, "gui\\Connect.gui");
		}
		
		setupRecorderFile();
	}

	setupRecorderFile();
	$recordDemo=true;
}

Event::Attach(eventMissionInfo, AutoName::onMissionInfo);

//make sure we stop/rename in every possible situation
Event::Attach(eventDisconnected, AutoName::Stop);
Event::Attach(eventConnectionLost, AutoName::Stop);
Event::Attach(eventConnectionTimeout, AutoName::Stop);
Event::Attach(eventExit, AutoName::Stop);