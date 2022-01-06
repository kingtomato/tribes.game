//-----------------------------------
//
// Tribes startup
//
//-----------------------------------

// test if this is a dedicated server
$dedicated = false;

$numExecFiles = 0;

for(%i = 1; $cargv[%i] != ""; %i++)
{
   if($cargv[%i] == "-mod")
   {
      %mod = $cargv[%i + 1];
      %i++;
      $modList = %mod @ " " @ $modList;
		$modCount++;
   }
   else if($cargv[%i] == "-dedicated")
   {
      $dedicated = true;
      %mission = $cargv[%i + 1];
      if(%mission != "")
      {
         $HostMission = %mission;
         %i++;
      }
   }
   else if($cargv[%i] == "+exec")
   {
      $execFile[$numExecFiles] = $cargv[%i+1];
      %i++;
      $numExecFiles++;
   }
   else if($cargv[%i] == "+connect")
   {
      $connectAddress = $cargv[%i+1];
      %i++;
   }
   else if($cargv[%i] == "+password")
   {
      $Server::JoinPassword = $cargv[%i+1];
      $Server::Password = $cargv[%i+1];
      %i++;
   }
   else if($cargv[%i] == "+record")
   {
      setupRecorderFile();
   }
   else if($cargv[%i] == "-host")
   {
      $HostMission = $cargv[%i+1];
      $HostingGame = true;
      %i++;
   }
   else if($cargv[%i] == "+maxplayers")
   {
      $HostPlayerCount = $cargv[%i+1];
      %i++;
   }
   else if($cargv[%i] == "-edit")
   {
      $EditingMission = true;
      $EditMission = $cargv[%i+1];
      %i++;
   }
}

$WinConsoleEnabled = $dedicated;
$Console::logBufferEnabled = !$dedicated; // turn off window scroll back
$Console::Prompt = "% ";

if($dedicated)
{
   newServer();
   focusServer();
}
else
{
   newClient();
   focusClient();
   $Console::LastLineTimeout = 0;
}

function EvalSearchPath()
{
   // search path always contains the config directory
   %searchPath = "config";
   if($modList == "")
      $modList = "base";
   else
   {
      for(%i = 0; (%word = getWord($modList, %i)) != -1; %i++)
         if(%word == "base")
            break;
      if(%word == -1)
         $modList = $modList @ " base";
   }
   for(%i = 0; (%word = getWord($modList, %i)) != -1; %i++)
   {
      %addPath = %word @ ";" @ %word @ "\\missions;" @ %word @ 
         "\\fonts;" @ %word @ "\\skins;" @ %word @ "\\voices;" @ %word @ "\\scripts";
      %searchPath = %searchPath @ ";" @ %addPath;
   }
   %searchPath = %searchPath @ ";recordings;temp";
   echo(%searchPath);

   $ConsoleWorld::DefaultSearchPath = %searchPath;

   // clear out the volumes:
   for(%i = 0; isObject(%vol = "VoiceVolume" @ %i); %i++)
      deleteObject(%vol);
   for(%i = 0; isObject(%vol = "SkinVolume" @ %i); %i++)
      deleteObject(%vol);

   // load all the volumes:
   %file = File::findFirst("voices\\*.vol");
   for(%i = 0; %file != ""; %file = File::findNext("voices\\*.vol"))
      if(newObject("VoiceVolume" @ %i, SimVolume, %file))
         %i++;

   %file = File::findFirst("skins\\*.vol");
   for(%i = 0; %file != ""; %file = File::findNext("skins\\*.vol"))
      if(newObject("SkinVolume" @ %i, SimVolume, %file))
         %i++;
}

function LoadModVolumes()
{
	// Load mod volumes in the order they were declared
   for(%i = $modCount - 1; %i >= 0; %i--)
   {
		%word = getWord($modList, %i);
		%vol = %word @ ".vol";
		if (isFile(%word @ "\\" @ %vol))
			newObject(%word @ "Volume", SimVolume, %vol);
   }
}

function ExecModScripts()
{
	// Exec mod scripts in the order they were declared
   for(%i = $modCount - 1; %i >= 0; %i--)
		exec(getWord($modList, %i) @ ".cs");
}

//
EvalSearchPath();
LoadModVolumes();
newObject(FontsVolume, SimVolume, "fonts.vol");
newObject(ScriptsVolume, SimVolume, "scripts.vol");
newObject(GuiVolume, SimVolume, "gui.vol");
newObject(EditVolume, SimVolume, "edit.vol");
newObject(EditorVolume, SimVolume, "editor.vol");
newObject(DarkstarVolume, SimVolume, "darkstar.vol");
newObject(InterfaceVolume, SimVolume, "interface.vol");
newObject(ShellVolume, SimVolume, "shell.vol");
newObject(ShellCommonVolume, SimVolume, "shellcommon.vol");
newObject(EntitiesVolume, SimVolume, "entities.vol");

$Console::GFXFont = "interface.pft";

////
// Default volumes and tags
//

exec("darkstar.strings.cs");
exec("editor.strings.cs");
exec("commonEditor.strings.cs");
exec("esf.strings.cs");
exec("fear.strings.cs");
exec("help.strings.cs");
exec("sfx.strings.cs");
exec("banlist.cs");
exec("missionList.cs");
exec("gui.cs");
exec("sae.cs");
exec("client.cs");
exec("server.cs");
exec("tsDefaultMatProps.cs");
exec("game.cs");
exec("GenericTriggers.cs");
exec("chatmenu.cs");
exec("menu.cs");
exec("observer.cs");
exec("PlayerSetup.cs");
exec("players.cs");

newObject("", IRCClient);
exec("IRCClient.cs");
exec("IRCServers.cs");

exec("Options.cs");
exec("commander.cs");

ExecModScripts();

//
// Default keys
//
bind(keyboard, make, control, o, to, "messageCanvasDevice(MainWindow, outline);");
bind(keyboard, make, sysreq, to, "screenShot(MainWindow);");
bind(keyboard, make, control, "-", to, "prevRes(MainWindow);");
bind(keyboard, make, control, "+",  to, "nextRes(MainWindow);");


// Load prefs and execute any autoexec commands...
exec("clientDefaults.cs");
exec("serverDefaults.cs");
exec("clientPrefs.cs");
exec("serverPrefs.cs");
exec("config.cs");
exec("badwords.cs");
exec("autoexec.cs");

for(%i = 0; %i < $numExecFiles; %i++)
   exec($execFile[%i]);

if($dedicated)
{
	if ($modCount && $MODInfo == "")
		$MODInfo = "This server is running the following mods: " @ $modList;

   if($HostPlayerCount > 0)
      $Server::MaxPlayers = $HostPlayerCount;
   createServer($HostMission, True);
	translateMasters();
	echo("Dedicated Server Initialized");
}
else
{
   newObject(ConsoleScheduler, SimConsoleScheduler);

   // Create the main window with a gui in it
   newObject(MainWindow, SimGui::Canvas, "Tribes", 640, 480, True, "512 384", "1024 768");

   exec("sound.cs");
   inputActivate(keyboard0);
   inputActivate(mouse0);

   if($pref::noIpx)
      newObject(clientDelegate, FearCSDelegate, false, "IP", 0, "LOOPBACK", 0);
   else
      newObject(clientDelegate, FearCSDelegate, false, "IP", 0, "IPX", 0, "LOOPBACK", 0);
   if(!$pref::lanOnly)
   	translateMasters();

   // Action map for flying cameras
   exec("move.cs");
   move();

   // Play the intro smacker file
   setCursor(MainWindow, "Cur_Empty.bmp");
   cursorOn(MainWindow);
   GuiLoadContentCtrl(MainWindow, "gui\\empty.gui");

   //all video initialization is now done in Options.cs
   OptionsVideo::validate();
   OptionsVideo::apply();

   if ($pref::cdMusic == "")
   	$pref::cdMusic = True;
   if ($pref::cdVolume == "")
   	$pref::cdVolume = 0.5;
   if ($pref::userCDOverride == "")
   	$pref::userCDOverride = False;
   if ($pref::cdMusic || $pref::userCDOverrride)
   {
   	newRedBook (CD, MainWindow);
   	rbSetVolume (CD, 1 - $pref::cdVolume);
   }
   if($HostingGame)
   {
      setCursor(MainWindow, "Cur_Arrow.bmp");
      cursorOn(MainWindow);
      if($HostPlayerCount > 0)
         $Server::MaxPlayers = $HostPlayerCount;
      createServer($HostMission, false);
      $quitOnDisconnect = true;
   }
   else if($connectAddress != "")
   {
      $Server::Address = $connectAddress;
      IRCLogin::AutoConnect();
      setCursor(MainWindow, "Cur_Arrow.bmp");
      cursorOn(MainWindow);
      JoinGame();
      $quitOnDisconnect = true;
   }
   else if($EditingMission)
   {
      setCursor(MainWindow, "Cur_Arrow.bmp");
      cursorOn(MainWindow);
      if($HostPlayerCount > 0)
         $Server::MaxPlayers = $HostPlayerCount;
      exec(editor);
      
      // check if creating or not
      %missionFile = "missions\\" @ $EditMission @ ".mis";
      if(File::FindFirst(%missionFile) == "")
      {
         GuiLoadContentCtrl(MainWindow, "gui\\mainmenu.gui");
         $NewMissionName = $EditMission;
         exec(newmission);
      }
      else
         createServer($EditMission, false);
      $quitOnDisconnect = false;
   }
   else
   {
      //translate all master server addressess - this function will eventually call startTheGame()
      if($pref::quickstart)
      {
         GuiLoadContentCtrl(MainWindow, "gui\\mainmenu.gui");
         Quickstart();
   	   translateMasters();
      }
      else
      {
         if (!$pref::skipIntro)
            GuiLoadContentCtrl(MainWindow, "gui\\intro.gui");
         else
   	      startMainMenuScreen();
      }

      //autologin to the irc client
      IRCLogin::AutoConnect();
   }
	echo("Client Initialized");
}


