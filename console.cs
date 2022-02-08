// $console::logmode = 1; // log by default

//-----------------------------------
//
// Tribes startup
//
//-----------------------------------

//-----------------------------------------------------------------------------
// Bootstrap namespace
//-----------------------------------------------------------------------------
function Bootstrap::getModEvalPath( %modName )
{
   // Base directory
   %resultPath = %modName @ ";";
   
   // Missions 
   %resultPath = %resultPath @ %modName @ "/missions;";
   
   // Fonts 
   %resultPath = %resultPath @ %modName @ "/fonts;";
   
   // Skins 
   %resultPath = %resultPath @ %modName @ "/skins;";

   // Voice Packs
   %resultPath = %resultPath @ %modName @ "/voices;";
   
   // Custom Scripts
   %resultPath = %resultPath @ %modName @ "/scripts;";
   
   // Misc (to be moved to bootstrap?)
   %resultPath = %resultPath @ %modName @ "/shell;";
   %resultPath = %resultPath @ %modName @ "/interface;";
   
   // rdbnote: this is for dev purposes, remove when shipping
   %resultPath = %resultPath @ %modName @ "/alienDML;";
   %resultPath = %resultPath @ %modName @ "/alienTerrain;";
   %resultPath = %resultPath @ %modName @ "/alienWorld;";
   %resultPath = %resultPath @ %modName @ "/desertDML;";
   %resultPath = %resultPath @ %modName @ "/desertTerrain;";
   %resultPath = %resultPath @ %modName @ "/desertWorld;";
   %resultPath = %resultPath @ %modName @ "/edit;";
   %resultPath = %resultPath @ %modName @ "/Editor;";
   %resultPath = %resultPath @ %modName @ "/Entities;";
   %resultPath = %resultPath @ %modName @ "/guiToolbar;";
   %resultPath = %resultPath @ %modName @ "/human1DML;";
   %resultPath = %resultPath @ %modName @ "/huds;";
   %resultPath = %resultPath @ %modName @ "/iceDML;";
   %resultPath = %resultPath @ %modName @ "/iceTerrain;";
   %resultPath = %resultPath @ %modName @ "/iceWorld;";
   %resultPath = %resultPath @ %modName @ "/lushDML;";
   %resultPath = %resultPath @ %modName @ "/lushTerrain;";
   %resultPath = %resultPath @ %modName @ "/lushWorld;";
   %resultPath = %resultPath @ %modName @ "/marsDML;";
   %resultPath = %resultPath @ %modName @ "/marsTerrain;";
   %resultPath = %resultPath @ %modName @ "/marsWorld;";
   %resultPath = %resultPath @ %modName @ "/mudDML;";
   %resultPath = %resultPath @ %modName @ "/mudTerrain;";
   %resultPath = %resultPath @ %modName @ "/mudWorld;";
   %resultPath = %resultPath @ %modName @ "/prefabs;";
   %resultPath = %resultPath @ %modName @ "/savanaDML;";
   %resultPath = %resultPath @ %modName @ "/ShellCommon;";
   %resultPath = %resultPath @ %modName @ "/sound;";
   %resultPath = %resultPath @ %modName @ "/ted;";
   %resultPath = %resultPath @ %modName @ "/titanDML;";
   
   %resultPath = %resultPath @ "dox;";
   %resultPath = %resultPath @ "dox/missions;";
   %resultPath = %resultPath @ "lt;";
   %resultPath = %resultPath @ "lt/missions;";
   %resultPath = %resultPath @ "opencall;";
   %resultPath = %resultPath @ "opencall/missions;";
   %resultPath = %resultPath @ "opencall2;";
   %resultPath = %resultPath @ "opencall2/missions;";
   %resultPath = %resultPath @ "balanced;";
   %resultPath = %resultPath @ "balanced/missions;";
   %resultPath = %resultPath @ "opencall3;";
   %resultPath = %resultPath @ "opencall3/missions;";
   
   
   // built path   
   return %resultPath;
}

function Bootstrap::clearModList()
{
   $modList = "";
   $modCount = 0;
}

function Bootstrap::addMod( %modName )
{
   // Only add once
   if(string::findsubstr( $modList, %modName ) == -1)
   {
      $modCount++;
      $modList = %modName @ " " @ $modList;
   }
}

function Bootstrap::evalSearchPath()
{
   // search path always contains the config directory
   %searchPath = "config;recordings;temp;";
     
   // Append mod paths
   for(%i = 0; (%word = getWord($modList, %i)) != -1; %i++)
      %searchPath = %searchPath @ Bootstrap::getModEvalPath(%word);
   %searchPath = %searchPath @ Bootstrap::getModEvalPath("base");

   // Print search to console
   echo("SearchPath : " @ %searchPath);

   // Set path
   $ConsoleWorld::DefaultSearchPath = %searchPath;

   // clear out the volumes:
   for(%i = 0; isObject(%vol = "VoiceVolume" @ %i); %i++)
      deleteObject(%vol);
   for(%i = 0; isObject(%vol = "SkinVolume" @ %i); %i++)
      deleteObject(%vol);

   // load all the volumes:
   %file = File::findFirst("voices/*.zip");
   for(%i = 0; %file != ""; %file = File::findNext("voices/*.zip"))
      if(newObject("VoiceVolume" @ %i, SimVolume, %file))
         %i++;

   %file = File::findFirst("skins/*.zip");
   for(%i = 0; %file != ""; %file = File::findNext("skins/*.zip"))
      if(newObject("SkinVolume" @ %i, SimVolume, %file))
         %i++;
}

function Bootstrap::loadModVolumes()
{
	// Load mod volumes in the order they were declared
   for(%i = $modCount - 1; %i >= 0; %i--)
   {
		%word = getWord($modList, %i);
		%vol = %word @ ".zip";
		if (isFile(%word @ "/" @ %vol))
			newObject(%word @ "Volume", SimVolume, %vol);
   }
}

function Bootstrap::execModScripts()
{
	// Exec mod scripts in the order they were declared
   for(%i = $modCount - 1; %i >= 0; %i--)
		exec(getWord($modList, %i) @ ".cs");
}


// test if this is a dedicated server
$dedicated = false;

$numExecFiles = 0;

for(%i = 1; $cargv[%i] != ""; %i++)
{
   if($cargv[%i] == "-mod")
   {
      %mod = $cargv[%i + 1];
      %i++;
      Bootstrap::addMod( %mod );
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

//
Bootstrap::evalSearchPath();
Bootstrap::loadModVolumes();
newObject(FontsVolume, SimVolume, "fonts.zip");
newObject(ScriptsVolume, SimVolume, "scripts.zip");
newObject(GuiVolume, SimVolume, "gui.zip");
newObject(EditVolume, SimVolume, "edit.zip");
newObject(EditorVolume, SimVolume, "editor.zip");
newObject(InterfaceVolume, SimVolume, "Interface.zip");
newObject(ShellVolume, SimVolume, "Shell.zip");
newObject(ShellCommonVolume, SimVolume, "ShellCommon.zip");
newObject(EntitiesVolume, SimVolume, "Entities.zip");

$Console::GFXFont = "interface.pft";

////
// Default volumes and tags
//

exec("common");
exec("client/loadall");
exec("sound/sfx.strings");
exec("banlist");
exec("server/missionlist");
exec("gui/gui");
exec("server/server");
// exec("GenericTriggers");
exec("server/game/observer");
exec("gui/PlayerSetup");
exec("players");

Bootstrap::execModScripts();

exec("gui/Options");
exec("gui/commander");

Bootstrap::execModScripts();

//
// Default keys
//
bind(keyboard, make, control, o, to, "messageCanvasDevice(MainWindow, outline);");
bind(keyboard, make, sysreq, to, "screenShot(MainWindow);");
bind(keyboard, make, control, "-", to, "prevRes(MainWindow);");
bind(keyboard, make, control, "+",  to, "nextRes(MainWindow);");


// Load prefs and execute any autoexec commands...
exec("Server/serverDefaults");
exec("Server/serverPrefs");
exec("defaultClientPrefs");
exec("defaultConfig");
exec("clientPrefs");
exec("config");
exec("badwords");
if ( !$dedicated )
	exec("autoexec");

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
   newObject(MainWindow, SimGui::Canvas, "Tribes", 800, 600, True, "800 600", "2560 1600");

   exec("sound/sound");
   inputActivate(keyboard0);
   inputActivate(mouse0);

   if($pref::noIpx)
      newObject(clientDelegate, FearCSDelegate, false, "IP", 0, "LOOPBACK", 0);
   else
      newObject(clientDelegate, FearCSDelegate, false, "IP", 0, "IPX", 0, "LOOPBACK", 0);
   if(!$pref::lanOnly)
   	translateMasters();

   // Action map for flying cameras
   exec("client/editor/move");
   move();

   setCursor(MainWindow, "Cur_Empty.bmp");
   cursorOn(MainWindow);
   GuiLoadContentCtrl(MainWindow, "gui/empty.gui");

   // GDCHACK : don't go fullscreen on startup (currently borked in webpage) 
   // $pref::VideoFullScreen = "FALSE";
   
   //all video initialization is now done in Options
   OptionsVideo::validate();
   OptionsVideo::apply();

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
      exec("editor/editor");
      
      // check if creating or not
      %missionFile = "missions/" @ $EditMission @ ".mis";
      if(File::FindFirst(%missionFile) == "")
      {
         GuiLoadContentCtrl(MainWindow, "gui/mainmenu.gui");
         $NewMissionName = $EditMission;
         exec("editor/newmission");
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
         GuiLoadContentCtrl(MainWindow, "gui/mainmenu.gui");
         Quickstart();
   	   translateMasters();
      }
      else
      {
   	      startMainMenuScreen();
      }

   }
	echo("Client Initialized");
}