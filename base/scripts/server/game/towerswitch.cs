// objective init must return true
function TowerSwitch::objectiveInit(%this)
{
   return %this.scoreValue || %this.deltaTeamScore;
}

function TowerSwitch::onAdd(%this)
{
	%this.numSwitchTeams = 0;	
}

function TowerSwitch::onDamage()
{
   // tower switches can't take damage
}

function TowerSwitch::getObjectiveString(%this, %forTeam)
{
   %thisTeam = GameBase::getTeam(%this);
   
   if($missionComplete)
   {
      if(%thisTeam == -1)
         return "<Btowers_neutral.png>\nNo team claimed " @ %this.objectiveName @ ".";
      else if(%thisTeam == %forTeam)
         return "<Btower_teamcontrol.png>\nYour team finished the mission in control of " @ %this.objectiveName @ ".";
      else {
       	if(%forTeam != -1)
		   	return "<Btower_enemycontrol.png>\nThe " @ getTeamName(%thisTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
   		else
		   	return "<Btower_teamcontrol.png>\nThe " @ getTeamName(%thisTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
		}
	}
   else
   {
		if(%forTeam != -1) {
     		if(%this.deltaTeamScore)
     		{																	  
				if(%thisTeam == -1)
 			   	return "<Btowers_neutral.png>\nClaim " @ %this.objectiveName @ " to gain " @ %this.deltaTeamScore @ " points per minute."; 
 			   else if(%thisTeam == %forTeam)
 			      return "<Btower_teamcontrol.png>\nDefend " @ %this.objectiveName @ " to retain " @ %this.deltaTeamScore @ " points per minute.";
 			   else
 			      return "<Btower_enemycontrol.png>\nCapture " @ %this.objectiveName @ " from the " @ getTeamName(%thisTeam) @ " team to gain " @ %this.deltaTeamScore @ " points per minute.";
			}
     		else if(%this.scoreValue)
     		{
     			if(%thisTeam == -1)
     		      return "<Btowers_neutral.png>\nClaim and defend " @ %this.objectiveName @ " to gain " @ %this.scoreValue @ " points.";
     		   else if(%thisTeam == %forTeam)
     		      return "<Btower_teamcontrol.png>\nDefend " @ %this.objectiveName @ " to retain " @ %this.scoreValue @ " points.";
     		   else
     		      return "<Btower_enemycontrol.png>\nCapture " @ %this.objectiveName @ " from the " @ getTeamName(%thisTeam) @ " team to gain " @ %this.deltaTeamScore @ " points.";
     		 }
		}
		else {
 			if(%thisTeam == -1)
 			  	return "<Btowers_neutral.png>\n" @ %this.objectiveName @ " has not been claimed."; 
 			else
 			   return "<Btower_teamcontrol.png>\nThe " @ getTeamName(%thisTeam) @ " team is in control of the " @ %this.objectiveName @ ".";
	  	}
   }
}

function TowerSwitch::onCollision(%this, %object)
{
   //echo("switch collision ", %object);
   if(getObjectType(%object) != "Player")
      return;

   if(Player::isDead(%object))
      return;

   %playerTeam = GameBase::getTeam(%object);
   %oldTeam = GameBase::getTeam(%this);
   if(%oldTeam == %playerTeam)
      return;

   %this.trainingObjectiveComplete = true;
   
   %playerClient = Player::getClient(%object);
   %touchClientName = Client::getName(%playerClient);
   %group = GetGroup(%this);
   Group::iterateRecursive(%group, GameBase::setTeam, %playerTeam);

   %dropPoints = nameToID(%group @ "/DropPoints");
   %oldDropSet = nameToID("MissionCleanup/TeamDrops" @ %oldTeam);
   %newDropSet = nameToID("MissionCleanup/TeamDrops" @ %playerTeam);

   $deltaTeamScore[%oldTeam] -= %this.deltaTeamScore;
   $deltaTeamScore[%playerTeam] += %this.deltaTeamScore;
   $teamScore[%oldTeam] -= %this.scoreValue;
   $teamScore[%playerTeam] += %this.scoreValue;

   if(%dropPoints != -1)
   {
      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
      {
         if(%oldDropSet != -1)
            removeFromSet(%oldDropSet, %dropPoint);
         addToSet(%newDropSet, %dropPoint);
      }
   }

   if(%oldTeam == -1)
   {
      message::allexcept(%playerClient, 0, %touchClientName @ " claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!");
      Client::sendMessage(%playerClient, 0, "You claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!");
 	}
   else
   {
      if(%this.objectiveLine)
      {
         message::allExcept(%playerClient, 0, %touchClientName @ " captured " @ %this.objectiveName @ " from the " @ getTeamName(%oldTeam) @ " team!");
         Client::sendMessage(%playerClient, 0, "You captured " @ %this.objectiveName @ " from the " @ getTeamName(%oldTeam) @ " team!");
			%this.numSwitchTeams++;	
			schedule("TowerSwitch::timeLimitCheckPoints(" @ %this @ "," @ %playerClient @ "," @ %this.numSwitchTeams @ ");",60);
      }
   }
   if(%this.objectiveLine)
   {
      message::teams(1, %playerTeam, "Your team has taken an objective.~wCapturedTower.wav");
		message::teams(0, %playerTeam, "The " @ getTeamName(%playerTeam) @ " has taken an objective.");
		if(%oldTeam != -1)
	      message::teams(1, %oldTeam, "The " @ getTeamName(%playerTeam) @ " team has taken your objective.~wLostTower.wav");
      ObjectiveMission::ObjectiveChanged(%this);
   }
   ObjectiveMission::checkScoreLimit();
}

function TowerSwitch::timeLimitCheckPoints( %this, %client, %numChange ) {
	//give player 5 points for capturing tower!
	//if ( %this.numSwitchTeams == %numChange ) {
	//	%client.score + =5;
	//	Game::refreshClientScore(%client);
	//	Client::sendMessage(%client, 0, "You receive 5 points for holding your captured tower!");
	//}
}

function TowerSwitch::clientKilled(%this, %playerId, %killerId)
{      
   if(!%this.objectiveLine)
      return;

   %killerTeam = Client::getTeam(%killerId);
   %playerTeam = Client::getTeam(%playerId);
   %killerPos = GameBase::getPosition(%killerId);
      
   if(%killerId && (%playerTeam != %killerTeam))
   {   
      %dist = Vector::getDistance(%killerPos, GameBase::getPosition(%this));
      //echo(%dist);
      if(%dist <= 80)
      {
         //echo("distance to objective" @ %this @ " : " @ %dist);
         if(GameBase::getTeam(%this) == Client::getTeam(%killerId) && getObjectType(%killerId) == "Player")
         {
            %killerId.score++;
            message::all(0, strcat(Client::getName(%killerId), " receives a bonus for defending " @ %this.objectiveName @ "."));
         }
      }
   }
}


// set up spawns to allow tower switch to swap stuff around
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

function Game::pickRandomSpawn( %team ) {
	%spawnSet = nameToID("MissionCleanup/TeamDrops" @ %team);
	%spawnCount = Group::objectCount(%spawnSet);
	if(!%spawnCount)
		return -1;

	%spawnIdx = floor(getRandom() * (%spawnCount - 0.1));
	%value = %spawnCount;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%spawnSet, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
	
		if(%i == %spawnCount - 1) {
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}

	return false;
}
