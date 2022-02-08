// Training_AI.cs
// This script defines all basic functionality for training 
// missions AI, and more!
////////////////////////////////////////////////////////////

//Globals
//////////////////////////
$AI_NamesCount = 0;

// jdd - VEA
$AI_Names[$AI_NamesCount++] = "Andrew";
$AI_Names[$AI_NamesCount++] = "justin`";
$AI_Names[$AI_NamesCount++] = "xgalaxy";
$AI_Names[$AI_NamesCount++] = "KillerBunny";

$AI_Names[$AI_NamesCount++] = "GotM*lk?";
$AI_Names[$AI_NamesCount++] = "Slacker";
$AI_Names[$AI_NamesCount++] = "Bob";
$AI_Names[$AI_NamesCount++] = "Cornboy!";
$AI_Names[$AI_NamesCount++] = "SymLink";
$AI_Names[$AI_NamesCount++] = "Skeet";
$AI_Names[$AI_NamesCount++] = "Jett";
$AI_Names[$AI_NamesCount++] = "Sne/\\keR";
$AI_Names[$AI_NamesCount++] = "DiamondBack";
$AI_Names[$AI_NamesCount++] = "Nailz";
$AI_Names[$AI_NamesCount++] = "Missing";
$AI_Names[$AI_NamesCount++] = "UberBob";
$AI_Names[$AI_NamesCount++] = "Ski to Die";
$AI_Names[$AI_NamesCount++] = "Sebirt";
$AI_Names[$AI_NamesCount++] = "Thulsa Doom";
$AI_Names[$AI_NamesCount++] = "MotoMan";

$AIkilled = 0;
$MatchStartTime = getSimTime();
$TrainMissionComplete = false;
 
//----------------------------------
//Training::setupAI()
//----------------------------------   
function Training::setupAI(%clientId)
{
   %group = "MissionGroup/AI";
   %itemCount = Group::objectCount(%group);
   $numGuards = %itemCount; 

   if( %group == -1 || %itemCount == 0 )
      dbecho(2, "No AI exists...");  
   	//what the hell?
   else 
   {  
      for(%guard = 1; %guard <= %itemCount; %guard++)
      {
         %AIname = "guard" @ %guard;
         $aiPathNum[%guard] = %AIname;
         createAI(%AIname, %group @ "/guard" @ %guard, larmor);
         %aiId = AI::getId( %AIname );
         GameBase::setTeam(%aiId, 1);
         AI::setVar( %AIname,  iq,  60 );
         AI::setVar( %AIname,  attackMode, 0);
         AI::DirectiveTarget(%AIname, %clientId);
      }
      AI::callWithId("*", Player::setItemCount, blaster, 1);
      AI::callWithId("*", Player::mountItem, blaster, 0);
      AI::SetVar( "*", triggerPct, 0.03 );
   }
}

//-----------------------------------------
//ObjectiveMission::objectiveChanged()
//-----------------------------------------
function ObjectiveMission::objectiveChanged(%this, %taken)
{
   if(%this.trainingObjectiveComplete)
   {
      if($trainingType == 0)
         TowersTraining::objectiveComplete(%this, %taken);
      else if($trainingType == 1)
         CTFTraining::objectiveComplete(%this);
      else if($trainingType == 2)
         RetrievalTraining::objectiveComplete(%this);
      else
         DestroyTraining::objectiveComplete(%this);  
   }
}

//-------------------------------------
//Training::displayBitmap()
//-------------------------------------
function Training::displayBitmap(%line)
{
   %team = Client::getTeam(Client::getFirst());
   
   if($Train::missionType == "CTF") {
      %bitmap = "capturetheflag.png";
   }
   else if($Train::missionType == "C&H") {
      %bitmap = "captureandhold.png";
   }
   else if($Train::missionType == "D&D") {
      %bitmap = "defendanddest.png";
   }
   else if($Train::missionType == "F&R") {
      %bitmap = "findandret.png";
   }
   else if($Train::missionType == "WELCOME") {
      %bitmap = "intro.png";
   }
   else if($Train::missionType == "VEHICLE") {
      %bitmap = "vehicle.png";
   }
   else if($Train::missionType == "COMMAND") {
      %bitmap = "commander.png";
   }
   else if($Train::missionType == "WEAPONS") {
      %bitmap = "weapons.png";
   }

   if(%bitmap == "")
   {
      Team::setObjective(%team, %line, " ");
      dbecho(2, "no bitmap found");
   }
   else
      Team::setObjective(%team, %line, "<jc><B0,0:" @ %bitmap @ ">");
}

//-----------------------------------
//Game::pickRandomSpawn()
//-----------------------------------
function Game::pickRandomSpawn(%team)
{
   %group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = floor(getRandom() * (%count - 0.1));
   %value = %count;
   for(%i = %spawnIdx; %i < %value; %i++) {
      %set = newObject("set",SimSet);
      %obj = Group::getObject(%group, %i);
      if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) 
         return %obj;
      if(%i == %count - 1) {
         %i = -1;
         %value = %spawnIdx;
      }
      deleteObject(%set);
   }
   return false;
}

//--------------------------------
//TrainingEndGameCallback()
//--------------------------------
function TrainingEndGameCallback()
{
   if($Train::missionType == "WELCOME")
      RestoreIcons();
} 

//--------------------------------
//RestoreIcons()
//--------------------------------   
function RestoreIcons()
{
   control::setVisible("healthHud", $AI_SaveHealth);
   control::setVisible("jetPackHud", $AI_SaveJett);
   control::setVisible("weaponHud", $AI_SaveWeapons);
   control::setVisible("compassHud", $AI_SaveCompass);
   control::setVisible("chatDisplayHud", $AI_SaveChat);
   control::setVisible("sensorHUD", $AI_SavePing);
}

//-------------------------------------
//ObjectiveMission::refreshTeamScores()
//-------------------------------------
function ObjectiveMission::refreshTeamScores()
{
   //no scoring in training missions!
}

//-------------------------------------
//Game::refreshClientScore()
//-------------------------------------
function Game::refreshClientScore(%clientId)
{
   //no scoring in training missions!
}

//------------------------------------
//TowerSwitch::onDamage()
//------------------------------------
function TowerSwitch::onDamage()
{
   //tower switches can't take damage
}

//---------------------------------
//remoteSetTimeLimit()
//--------------------------------
function remoteSetTimeLimit(%client, %time)
{
   //start timer going up
}

//-------------------------------------
//AI::onDroneKilled()
//-------------------------------------
function AI::onDroneKilled(%aiName)
{
   $AIkilled++;
}     

//these AI function callbacks can be very useful!
function AI::onTargetLOSAcquired(%aiName, %idNum)
{
}

function AI::onTargetDied(%aiName, %idNum)
{
}                                 

function AI::onTargetLOSLost(%aiName, %idNum)
{
}

function AI::onTargetLOSRegained(%aiName, %idNum)
{
}

//do nothing functions
function Mission::init()
{
}


   

  


