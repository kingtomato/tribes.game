function ObjectiveMission::objectiveChanged( %this ) {
	if ( !%this.objectiveline )
		return;

	%teams = getNumTeams();
	for ( %i = -1; %i < %teams; %i++ )
		Team::setObjective( %i, %this.objectiveLine, "<f1> " @ GameBase::virtual(%this, getObjectiveString, %i ) );
}

function ObjectiveMission::checkScoreLimit() {
	ObjectiveMission::refreshTeamScores();

	for( %i = 0; %i < getNumTeams(); %i++ ) {
		if ( $teamScore[%i] < $teamScoreLimit )
			continue;
		
		ObjectiveMission::missionComplete();
		return;
	}
}

function ObjectiveMission::missionComplete( %nextMission ) {
	$missionComplete = true;
	
	%group = nameToID("MissionCleanup/ObjectivesSet");
	for( %i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++ )
		ObjectiveMission::objectiveChanged(%obj);

	for(%i = 0; %i < getNumTeams(); %i++) { 
		Team::setObjective(%i, $firstObjectiveLine-4, " ");
		Team::setObjective(%i, $firstObjectiveLine-3, "<f5>Mission Summary:");
		Team::setObjective(%i, $firstObjectiveLine-2, " ");
	}
	ObjectiveMission::setObjectiveHeading();
	ObjectiveMission::refreshTeamScores();

	$missionComplete = false;
	
	Event::Trigger( eventServerMissionComplete, %nextMission );
   if ( %nextMission != "" )
      schedule( "Server::loadMission( \"" @ %nextMission @ "\" );", 0 );
   else
      schedule( "Server::nextMission();", 0 );
}

function ObjectiveMission::setObjectiveHeading()
{
   if($missionComplete)
   {
      %curLeader = 0;
		%tieGame = false;
		%tie = 0;
		%tieTeams[%tie] = %curLeader; 
		for(%i = 0; %i < getNumTeams() ; %i++) 
		   echo("GAME: teamfinalscore " @ %i @ " " @ $teamScore[%i]);
      
		for(%i = 1; %i < getNumTeams() ; %i++) 
      {
		   if($teamScore[%i] == $teamScore[%curLeader]) { 
            %tieGame = true;
         	%tieTeams[%tie++] = %i;
			}
			else if($teamScore[%i] > $teamScore[%curLeader])
         {
            %curLeader = %i;	   
            %tieGame = false;
				%tie = 0;
				%tieTeams[%tie] = %curLeader; 
         }
      }
		if(%tieGame) {
			for(%g = 0; %g <= %tie; %g++) { 
				%names = %names @ getTeamName(%tieTeams[%g]);
				if(%g == %tie-1)
					%names = %names @ " and "; 
				else if(%g != %tie)
					%names = %names @ ", "; 
			}
			if(%tie > 1) 
			 	%names = %names @ " all"; 
		}
		for(%i = -1; %i < getNumTeams(); %i++)
      {
			objective::displayBitmap(%i,0);
			if(!%tieGame) {
	         if(%i == %curLeader) { 
					if($teamScore[%curLeader] == 1)
				   	Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " point!");
					else
				   	Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
				else {
					if($teamScore[%curLeader] == 1)
						Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " point!");
  					else
	          		Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
		  	}	
			else {
				if(getNumTeams() > 2) {
					Team::setObjective(%i, 1, "<F5>     The " @ %names @ " tied with a score of " @ $teamScore[%curLeader]);
  	         }
				else
					Team::setObjective(%i, 1, "<F5>     The mission ended in a tie where each team had a score of " @ $teamScore[%curLeader]);
			}
			Team::setObjective(%i, 2, " ");
		}
   }
   else {
      for(%i = -1; %i < getNumTeams(); %i++)
      {
			objective::displayBitmap(%i,0);
		  	Team::setObjective(%i,1, "<f5>Mission Completion:");
		   Team::setObjective(%i, 2,"<f1>   - " @ $teamScoreLimit @ " points needed to win the mission.");
		}
	}
   if(!$Server::timeLimit)
      %str = "<f1>   - No time limit on the game.";
   else if($timeLimitReached)
      %str = "<f1>   - Time limit reached.";
   else if($missionComplete)
   {
      %time = getSimTime() - $missionStartTime;
      %minutes = Time::getMinutes(%time);
      %seconds = Time::getSeconds(%time);
      if(%minutes < 10)
         %minutes = "0" @ %minutes;
      if(%seconds < 10)
         %seconds = "0" @ %seconds;
      %str = "<f1>   - Total match time: " @ %minutes @ ":" @ %seconds;
   }
   else
      %str = "<f1>   - Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.";
   for(%i = -1; %i < getNumTeams(); %i++) {
	  	Team::setObjective(%i, 3, " ");
  		Team::setObjective(%i, 4, "<f5>Mission Information:");
		Team::setObjective(%i, 5, "<f1>   - Mission Name: " @ $missionName); 
      Team::setObjective(%i, 6, %str);
	}
}

function objective::displayBitmap(%team, %line)
{
	if($TestMissionType == "CTF") {
		%bitmap = "capturetheflag.png";
	}
	else if($TestMissionType == "C&H") {
		%bitmap = "captureandhold.png";
	}
	else if($TestMissionType == "D&D") {
		%bitmap = "defendanddest.png";
	}	   
	else if($TestMissionType == "F&R") {
		%bitmap = "findandret.png";
	}
	if(%bitmap == "")
 		Team::setObjective(%team, %line, " ");
	else
 		Team::setObjective(%team, %line, "<jc><B0,0:" @ %bitmap @ ">");
}


function ObjectiveMission::checkPoints()
{
   for(%i = 0; %i < getNumTeams(); %i++)
      $teamScore[%i] += $deltaTeamScore[%i] / 12;
   schedule("ObjectiveMission::checkPoints();", 5);
   ObjectiveMission::checkScoreLimit();
}

function ObjectiveMission::initCheck(%object)
{
	if($TestMissionType == "") {
		%name = gamebase::getdataname(%object); 
	   if(%name == Flag) { 
			if(gamebase::getteam(%object) != -1)
				$TestMissionType = "CTF";
			else
				$TestMissionType = "F&R";
		}
		else if(%object.objectiveName != "" && %object.scoreValue)
			$TestMissionType = "D&D";
		else if(%name == TowerSwitch)
			$NumTowerSwitchs++;
	}

   %object.trainingObjectiveComplete = "";
   %object.objectiveLine = "";
   if(GameBase::virtual(%object, objectiveInit))
      addToSet("MissionCleanup/ObjectivesSet", %object);
}


function ObjectiveMission::refreshTeamScores() {
	%teams = getNumTeams();
	
	for ( %i = 0; %i < %teams; %i++ ) {
		Team::setScore( %i, "%t\t  " @ $teamScore[%i], $teamScore[%i] );

		for( %j = 0; %j < %teams; %j++ )
			Team::setObjective( %i, %j + $firstTeamLine, "<f1>   - Team " @ getTeamName(%j) @ " score = " @ $teamScore[%j] );
	}
}
