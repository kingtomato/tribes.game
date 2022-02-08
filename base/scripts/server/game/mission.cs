exec("server/game/objectives");

function checkObjectives(%this) {
   //echo("checking for objective player leave mission area...");
}

function Mission::init() {
	setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL");
	setTeamScoreHeading("Team Name\t\xD6Score");

	$firstTeamLine = 7;
	$firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
	for(%i = -1; %i < getNumTeams(); %i++) {
		$teamFlagStand[%i] = "";
		$teamFlag[%i] = "";
		Team::setObjective(%i, $firstTeamLine - 1, " ");
		Team::setObjective(%i, $firstObjectiveLine - 1, " ");
		Team::setObjective(%i, $firstObjectiveLine, "<f5>Mission Objectives: ");
		$firstObjectiveLine++;
		$deltaTeamScore[%i] = 0;
		$teamScore[%i] = 0;
		newObject("TeamDrops" @ %i, SimSet);
		addToSet(MissionCleanup, "TeamDrops" @ %i);
		%dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints/Random");
		for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
			addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
	}
	$numObjectives = 0;
	newObject(ObjectivesSet, SimSet);
	addToSet(MissionCleanup, ObjectivesSet);

	Group::iterateRecursive(MissionGroup, ObjectiveMission::initCheck);
	%group = nameToID("MissionCleanup/ObjectivesSet");

	ObjectiveMission::setObjectiveHeading();
	for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++) {
		%obj.objectiveLine = %i + $firstObjectiveLine;
		ObjectiveMission::objectiveChanged(%obj);
	}
	ObjectiveMission::refreshTeamScores();
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		%cl.score = 0;
		Game::refreshClientScore(%cl);
	}
	schedule("ObjectiveMission::checkPoints();", 5);

	if($TestMissionType == "") {
		if($NumTowerSwitchs) 
			$TestMissionType = "C&H";
		else 
			$TestMissionType = "NONE";		
		$NumTowerSwitchs = "";
	}

	AI::setupAI();
}

function UpdateClientTimes(%time) {
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time) {
   message::all(0, "Match starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch() {
	$matchStarted = true;
	$missionStartTime = getSimTime();
	message::all(0, "Match started.");
	message::remoteall( "matchStarted" );

	Game::resetScores();

	%numTeams = getNumTeams();
	for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}
	
	Event::Trigger( eventServerMatchStarted, $missionName );
	for( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) ) {
		if(%cl.observerMode == "pregame") {
			%cl.observerMode = "";
			Client::setControlObject(%cl, Client::getOwnedObject(%cl));
			%ident = Stats::Identifier( %cl );
			StatLog::Push( PlayerSpawn, %ident, Gamebase::GetPosition( %cl ) );
			StatLog::Push( SetArmor, %ident, "", Player::getArmor( %cl ) );
		}

		Game::refreshClientScore(%cl);
	}

	Game::checkTimeLimit();
}

function Game::ForceTourneyMatchStart() {
	%playerCount = 0;
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) ) {
		if ( %cl.observerMode == "pregame" )
			%playerCount++;
	}

	if( %playerCount == 0 )
		return;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if(%cl.observerMode == "pickingTeam")
			processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
	
		for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) ) {
			%cl.notready = "";
			%cl.notreadyCount = "";
			message::bottomprint(%cl, "", 0);
		}
	}

	Server::Countdown(30);
}

function Game::CheckTourneyMatchStart() {
	if ( $CountdownStarted || $matchStarted )
		return;

	// loop through all the clients and see if any are still notready
	%playerCount = 0;
	%notReadyCount = 0;

	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) ) {
		if( %cl.observerMode == "pickingTeam" ) {
			%notReady[%notReadyCount] = %cl;
			%notReadyCount++;
		} else if(%cl.observerMode == "pregame") {
			if(%cl.notready) {
				%notReady[%notReadyCount] = %cl;
				%notReadyCount++;
			} else {
				%playerCount++;
			}
		}
	}
	
	if(%notReadyCount) {
		if ( %notReadyCount == 1 )
			message::all( 0, Client::getName(%notReady[0]) @ " is holding things up!" );
		else if ( %notReadyCount < 4 ) {
			for(%i = 0; %i < %notReadyCount - 2; %i++)
				%str = Client::getName(%notReady[%i]) @ ", " @ %str;

			%str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!";
			message::all(0, %str);
		}
		return;
	}

	if( %playerCount != 0 ) {
		for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) ) {
			%cl.notready = "";
			%cl.notreadyCount = "";
			message::bottomprint(%cl, "", 0);
		}
		Server::Countdown(30);
	}
}


function Game::checkTimeLimit() {
	// if no timeLimit set or timeLimit set to 0, just reschedule the check for a minute hence
	$timeLimitReached = false;
	ObjectiveMission::setObjectiveHeading();

	if( $Server::timeLimit <= 0 ) {
		schedule("Game::checkTimeLimit();", 60);
		return;
	}

	%curTimeLeft = ( $Server::timeLimit * 60 ) + $missionStartTime - getSimTime();
	if( %curTimeLeft <= 0 && $matchStarted ) {
		echo("GAME: timelimit");
		$timeLimitReached = true;
		//echo("checking for objective time limit status...");
		%set = nameToID("MissionCleanup/ObjectiveSet");
		for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
			GameBase::virtual(%obj, "timeLimitReached", %clientId);
		ObjectiveMission::missionComplete();
	} else {
		if ( %curTimeLeft >= 20 )
			schedule("Game::checkTimeLimit();", 20);
		else
			schedule("Game::checkTimeLimit();", %curTimeLeft + 1);
		UpdateClientTimes(%curTimeLeft);
	}
}

function Game::refreshClientScore( %cl ) {
	// observers go last
	%team = Client::getTeam( %cl );
	if(%team == -1) 
		%team = 9;
	
	// objective mission sorts by team first.
	Client::setScore( %cl, "%n\t%t\t  " @ round( %cl.score, 0 )  @ "\t%p\t%l", %cl.score + (9 - %team) * 10000 );
}

function Game::resetScores( %cl ) {
	if( %cl == "") {
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			%cl.scoreKills = 0;
			%cl.scoreDeaths = 0;
			%cl.ratio = 0;
			%cl.score = 0;
		}
	} else {
		%cl.scoreKills = 0;
		%cl.scoreDeaths = 0;
		%cl.ratio = 0;
		%cl.score = 0;
	}
}
