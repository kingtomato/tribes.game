// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function

function onRemoteFilterServer( %fn, %cl, %p0, %p1, %p2, %p3, %p4, %p5 ) {
	return isFunction( %fn );
}

function createTrainingServer()
{
   $SinglePlayer = true;
   createServer($pref::lastTrainingMission, false);
}

function remoteSetCLInfo( %cl, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask)
{
   $Client::info[%cl, 0] = %skin;
   $Client::info[%cl, 1] = %name;
   $Client::info[%cl, 2] = %email;
   $Client::info[%cl, 3] = %tribe;
   $Client::info[%cl, 4] = %url;
   $Client::info[%cl, 5] = %info;
   if(%autowp)
      %cl.autoWaypoint = true;
   if(%enterInv)
      %cl.noEnterInventory = true;
   if(%msgMask != "")
      %cl.messageFilter = %msgMask;
}

function Server::storeData() {
   $ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";

   export("Server::*", "temp/" @ $ServerDataFile, False);
   export("pref::lastMission", "temp/" @ $ServerDataFile, true);
   Bootstrap::evalSearchPath();
}

function Server::refreshData() {
   exec($ServerDataFile);  // reload prefs.
   checkMasterTranslation();
   Server::nextMission(false);
}

function Server::onClientDisconnect( %cl ) {
	// Need to kill the player off here to make everything is cleaned up properly.
	%player = Client::getOwnedObject(%cl);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
		Player::kill(%player);
	}
	
	Event::Trigger( eventServerClientDisconnect, %cl );

	Client::setControlObject(%cl, -1);
	Client::leaveGame(%cl);
	Game::CheckTourneyMatchStart();
	if(getNumClients() == 1) // this is the last client.
		Server::refreshData();
}

function Server::onConnectionRequest( %id, %name, %ip, %password ) {
	Event::Trigger( eventServerConnectionRequest, %name, %ip, %password );
	
	if ( ( $Server::Password != "" ) && ( %password != $Server::Password ) )
		return "Wrong Password.";
	else if ( getNumClients() + 1 > $Server::MaxPlayers )
		return "Server Full.";
	
	return "true";
}

function Server::onClientConnect(%cl) {
	Event::Trigger( eventServerClientConnect, %cl );
	
	iplog::add( %cl );

	echo("CONNECT: " @ %cl @ " \"" @ String::Escape(Client::getName(%cl)) @ "\" " @ Client::getTransportAddress(%cl));
	%cl.noghost = true;
	%cl.messageFilter = -1; // all messages
	remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%cl, MODInfo, $MODInfo);
	remoteEval(%cl, FileURL, $Server::FileURL);

	// clear out any client info:
	for(%i = 0; %i < 10; %i++)
		$Client::info[%cl, %i] = "";

	Game::onPlayerConnected(%cl);
}

function createServer(%mission, %dedicated) {
   $loadingMission = false;
   $ME::Loaded = false;
   if(%mission == "")
      %mission = $pref::lastMission;

   if(%mission == "")
   {
      echo("Error: no mission provided.");
      return "False";
   }

   if(!$SinglePlayer)
      $pref::lastMission = %mission;

	//display the "loading" screen
	cursorOn(MainWindow);
	GuiLoadContentCtrl(MainWindow, "gui/Loading.gui");
	renderCanvas(MainWindow);

   if(!%dedicated) {
      deleteServer();
      purgeResources();
      newServer();
      focusServer();
   }
   if($SinglePlayer)
      newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);
   else
      newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port);
   
   exec( "server/loadall" );
   exec( "sound/nsound" );
   exec( "server/items/loadall" );

   Server::storeData();

   // NOTE!! You must have declared all data blocks BEFORE you call
   // preloadServerDataBlocks.

   preloadServerDataBlocks();

   Server::loadMission( ($missionName = %mission), true );

   if(!%dedicated)
   {
      focusClient();

      // join up to the server
      $Server::Address = "LOOPBACK:" @ $Server::Port;
		$Server::JoinPassword = $Server::Password;
      connect($Server::Address);
   }
   return "True";
}

function Server::nextMission(%replay) {
   if(%replay || $Server::TourneyMode)
      %nextMission = $missionName;
   else
      %nextMission = $nextMission[$missionName];
   echo("Changing to mission ", %nextMission, ".");
   // give the clients enough time to load up the victory screen
   Server::loadMission(%nextMission);
}

function remoteCycleMission(%cl) {
   if(%cl.isAdmin) {
      message::all(0, Client::getName(%playerId) @ " cycled the mission.");
      Server::nextMission();
   }
}

function remoteDataFinished(%cl) {
   if(%cl.dataFinished)
      return;
   %cl.dataFinished = true;
   Client::setDataFinished(%cl);
   %cl.svNoGhost = ""; // clear the data flag
   if($ghosting)
   {
      %cl.ghostDoneFlag = true; // allow a CGA done from this dude
      startGhosting(%cl);  // let the ghosting begin!
   }
}

function remoteCGADone( %cl ) {
   if(!%cl.ghostDoneFlag || !$ghosting)
      return;
   %cl.ghostDoneFlag = "";

   Game::initialMissionDrop(%cl);

	if ($cdTrack != "")
		remoteEval (%cl, setMusic, $cdTrack, $cdPlayMode);
   remoteEval(%cl, MInfo, $missionName);
   
   if ( banlist::isbanned( %cl ) )
   	   schedule( "banlist::reban(" @ %cl @ ");", 1 );
   if ( %cl.adminLevel == "" ) {
		remoteAdminPassword( %cl, "" ); // TEMP AUTO SAD FIXME
	}
}

function onServerGhostAlwaysDone() {
}

function Server::loadMission(%missionName, %immed) {
   if($loadingMission)
      return;
   
   %missionFile = "missions/" $+ %missionName $+ ".mis";
   if(File::FindFirst(%missionFile) == "")
   {
      %missionName = $firstMission;
      %missionFile = "missions/" $+ %missionName $+ ".mis";
      if(File::FindFirst(%missionFile) == "")
      {
         echo("invalid nextMission and firstMission...");
         echo("aborting mission load.");
         return;
      }
   }
   echo("Notfifying players of mission change: ", getNumClients(), " in game");
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      Client::setGuiMode(%cl, $GuiModeVictory);
      %cl.guiLock = true;
      %cl.nospawn = true;
      remoteEval(%cl, missionChangeNotify, %missionName);
   }

   $loadingMission = true;
   $missionName = %missionName;
   $missionFile = %missionFile;
   $prevNumTeams = getNumTeams();

   if(isObject("MissionGroup"))
      deleteObject("MissionGroup");
   if(isObject("MissionCleanup"))
      deleteObject("MissionCleanup");
   if(isObject("ConsoleScheduler"))
      deleteObject("ConsoleScheduler");

   resetPlayerManager();
   resetGhostManagers();
   $matchStarted = false;
   $countdownStarted = false;
   $ghosting = false;

   resetSimTime(); // deal with time imprecision
   
   Event::Trigger( eventServerLoadMission, %mission );

   newObject(ConsoleScheduler, SimConsoleScheduler);
   if(!%immed)
      schedule("Server::finishMissionLoad();", 18);
   else
      Server::finishMissionLoad();
}

function Server::finishMissionLoad() {
   $loadingMission = false;
	$TestMissionType = "";
   // instant off of the manager
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   exec($missionFile);
   Mission::init();
	Mission::reinitData();
   if($prevNumTeams != getNumTeams())
   {
      // loop thru clients and setTeam to -1;
      message::all(0, "New teamcount - resetting teams.");
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
         Event::Trigger( eventServerClientJoinTeam, %cl, -1 );
         GameBase::setTeam(%cl, -1);
      }
   }

   $ghosting = true;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(!%cl.svNoGhost)
      {
         %cl.ghostDoneFlag = true;
         startGhosting(%cl);
      }
   }
   if($SinglePlayer)
      Game::startMatch();
   else if($Server::warmupTime && !$Server::TourneyMode)
      Server::Countdown($Server::warmupTime);
   else if(!$Server::TourneyMode)
      Game::startMatch();

   $teamplay = (getNumTeams() != 1);
   purgeResources(true);

   // make sure the match happens within 5-10 hours.
   schedule("Server::CheckMatchStarted();", 3600);
   schedule("Server::nextMission();", 18000);
   
   return "True";
}

function Server::CheckMatchStarted()
{
   // if the match hasn't started yet, just reset the map
   // timing issue.
   if(!$matchStarted)
      Server::nextMission(true);
}

function Server::Countdown(%time)
{
   $countdownStarted = true;
   schedule("Game::startMatch();", %time);
   Game::notifyMatchStart(%time);
   if(%time > 30)
      schedule("Game::notifyMatchStart(30);", %time - 30);
   if(%time > 15)
      schedule("Game::notifyMatchStart(15);", %time - 15);
   if(%time > 10)
      schedule("Game::notifyMatchStart(10);", %time - 10);
   if(%time > 5)
      schedule("Game::notifyMatchStart(5);", %time - 5);
}
