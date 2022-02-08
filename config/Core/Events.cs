// eventChangeMission(%nextMission)
function remoteMissionChangeNotify( %sv, %nextMission ) {
	Event::Trigger( eventChangeMission, %nextMission );

	echo("Server mission complete - changing to mission: ", %nextMission);
	echo("Flushing Texture Cache"); 
	flushTextureCache();
	Schedule::Add("purgeResources(true);", 3);
}

// eventMissionInfo(%server, %missionName, $ServerMissionType)
function remoteMInfo( %sv, %missionName ) {
	$MDESC::Type = "";
	$MDESC::Text = "";

	%file = "missions\\" @ %missionName @ ".dsc";
	if(File::findFirst(%file) != "")
		exec(%file);

	$ServerMission = %missionName;
	$ServerText = $MDESC::Text;
	$ServerMissionType = $MDESC::Type;

	if( isObject( LobbyGui ) )
		LobbyGui::onOpen();  // update lobby screen text.

	Event::Trigger(eventMissionInfo, %server, %missionName, $ServerMissionType);
}


// eventServerInfo(%server, %version, %hostname, %mod, %info, %favKey)
function remoteSVInfo( %sv, %version, %hostname, %mod, %info, %favKey ) {
    $ServerVersion = %version;
    $ServerName = %hostname;
    $modList = %mod;
    $ServerMod = $modList;
    $ServerInfo = %info;
    $ServerFavoritesKey = String::MakeAlphaNumeric( %favKey );   

    Event::Trigger( eventServerInfo, %server, %version, %hostname, %mod, %info, %favKey );
    Bootstrap::evalSearchPath();
}


// eventClientTeamAdd(%team, %name)
// eventClientJoin(%cl)
// eventClientDrop(%cl)
// eventClientChangeTeam(%cl, %team)
function onTeamAdd( %team, %name ) {
    Event::Trigger(eventTeamAdd, %team, %name);
}

function onClientJoin( %cl ) {
    Event::Trigger(eventClientJoin, %cl);
}

function onClientDrop( %cl ) {
    Event::Trigger(eventClientDrop, %cl);
}

function onClientChangeTeam( %cl, %team ) {
    Event::Trigger( eventClientChangeTeam, %cl, %team );
}

function onPlaybackFinished() {
	Event::Trigger( eventPlaybackOver );
	cursorOn(MainWindow);
	GuiLoadContentCtrl(MainWindow, "gui/Recordings.gui");
}


function onConnectionError( %sv, %manager, %error ) {
	if ( Event::Trigger( eventConnectionError, %error ) == "ignore" )
		return;
	Quickstart();
	GuiPushDialog(MainWindow, "gui\\MessageDialog.gui");
	$errorString = "Connection to server error:\n" @ %error;
	Schedule::Add("Control::setValue(MessageDialogTextFormat, $errorString);", 0);
}

function onConnection(%message) {
    echo("Connection ", %message);
 	if ( %message != "Accepted" )
 		echo( "  Reason: " ~ $errorString );

    $dataFinished = false;
    if(%message == "Accepted") {
		Event::Trigger(eventConnectionAccepted);
        resetSimTime();
    	//execute the custom script
        if ($PCFG::Script != "")
            exec($PCFG::Script);

        resetPlayDelegate();
        remoteEval(2048, "SetCLInfo", $PCFG::SkinBase, $PCFG::RealName, $PCFG::EMail, $PCFG::Tribe, $PCFG::URL, $PCFG::Info, $pref::autoWaypoint, $pref::noEnterInv, $pref::messageMask);

        // Don't check join mode?? This messes up the loading GUI when doing IA game joins -JDD
        //if ($Pref::PlayGameMode == "JOIN") {
            cursorOn(MainWindow);
            GuiLoadContentCtrl(MainWindow, "gui/Loading.gui");
            renderCanvas(MainWindow);
        //}
    } else if(%message == "Rejected") {
        Quickstart();
        $errorString = "Connection to server rejected:\n" @ $errorString;
        GuiPushDialog(MainWindow, "gui\\MessageDialog.gui");
        schedule("Control::setValue(MessageDialogTextFormat, $errorString);", 0);
        Event::Trigger(eventConnectionRejected, $errorString);
    } else {
        //startMainMenuScreen();
        Quickstart();

        if(%message == "Dropped") {
            if($errorString == "")
                $errorString = "Connection to server lost:\nServer went down.";
            else
                $errorString = "Connection to server lost:\n" @ $errorString;

            Event::Trigger(eventConnectionLost, $errorString);
        } else if(%message == "TimedOut") {
            $errorString = "Connection to server timed out.";
            Event::Trigger(eventConnectionTimeout);
        }
		GuiPushDialog(MainWindow, "gui\\MessageDialog.gui");
        Schedule::Add("Control::setValue(MessageDialogTextFormat, $errorString);", 0);
    }
}


// eventConnected
function dataFinished() {
	Control::setValue( "ProgressText", "<jc><f0>Waiting for Mission Start" );
	Control::setValue( "ProgressSlider", 1 );

	$dataFinished = true;
	remoteEval( 2048, dataFinished );

	echo("Flushing Texture Cache");
	flushTextureCache();

	Event::Trigger(eventConnected);
}

// ---------------------------------------------------------------------------
// eventScreenModeChanged
// eventFullScreenMode
// eventSoftwareMode
// eventScreenSizeChanged
// ---------------------------------------------------------------------------

function remoteMatchStarted( %sv ) {
	Event::Trigger( eventMatchStarted );
}

// eventUpdateTime(%min, %sec)
function remoteSetTime( %s, %t ) {
	setHudTimer(%t);
	Event::Trigger(eventUpdateTime, Time::GetMinutes((%t+1) * -1), Time::GetSeconds((%t+1) * -1));
}


function remoteCP( %manager, %msg, %timeout, %type ) {
	if ( %manager != 2048 )
		return;

	$centerPrintId++;
	if ( %timeout )
		schedule( "clearCenterPrint(" @ $centerPrintId @ ");", %timeout );

	if ( Event::Trigger( eventPopup, %msg ) == mute )
		return;

	if ( %type == "" )
		%type = 0;

	Client::centerPrint( %msg, %type );
}

function remoteBP( %manager, %msg, %timeout ) {
	remoteCP( %manager, %msg, %timeout, 1 );
}

function remoteTP( %manager, %msg, %timeout ) {
	remoteCP( %manager, %msg, %timeout, 2 );
}




// universal "left the server" event
Event::Attach( eventConnectionError, Events::onLeaveServer );
Event::Attach( eventConnectionLost, Events::onLeaveServer );
Event::Attach( eventConnectionTimeout, Events::onLeaveServer );
Event::Attach( eventDisconnected, Events::onLeaveServer );
Event::Attach( eventPlaybackOver, Events::onLeaveServer );

function Events::onLeaveServer() {
	Event::Trigger( eventLeaveServer );
}
