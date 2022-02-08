$flagReturnTime = 45;


// objective init must return true
function Flag::objectiveInit( %this ) {
	%this.originalPosition = GameBase::getPosition(%this);
	%this.atHome = true;
	%this.pickupSequence = 0;
	%this.carrier = -1;
	%this.holdingTeam = -1;
	%this.holder = "";
	%this.changeTeamCount = 0;

	%this.enemyCaps = 0;
	%this.caps[0] = 0;
	%this.caps[1] = 0;
	%this.caps[2] = 0;
	%this.caps[3] = 0;
	%this.caps[4] = 0;
	%this.caps[5] = 0;
	%this.caps[6] = 0;
	%this.caps[7] = 0;

	$Team::Flag[GameBase::getTeam(%this)] = %this;

	return ( true );
}


// :-(
function Flag::getObjectiveString(%this, %forTeam) {
	%thisTeam = GameBase::getTeam(%this);

	if($missionComplete) {
		if( %thisTeam == -1 ) {
			if ( %this.holdingTeam == %forTeam && %forTeam != -1 )
				return "<Bflag_atbase.png>\nYour team finished the mission in control of " @ %this.objectiveName @ ".";
			else if (%this.holdingTeam == -1 )
				return "<Bflag_neutral.png>\nNo team finished the mission in control of " @ %this.objectiveName @ ".";
			else {
				if(%forTeam != -1)
					return "<Bflag_enemycaptured.png>\nThe " @ getTeamName(%this.holdingTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
				else
					return "<Bflag_atbase.png>\nThe " @ getTeamName(%this.holdingTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
			}
		} else if( %forTeam != -1 ) {
			if(%thisTeam == %forTeam)
				return "<Bflag_atbase.png>\nYour flag was captured " @ %this.enemyCaps @ " times.";
			else
				return "<Bflag_enemycaptured.png>\nYour team captured the " @ getTeamName(%thisTeam) @ " flag " @ %this.caps[%forTeam] @ " times.";
		} else {
			return "<Bflag_atbase.png>\nThe " @ getTeamName(%thisTeam) @ "'s flag was captured " @ %this.enemyCaps @ " times.";
		}
	} else {
		if(%thisTeam == -1) {
			if(%forTeam != -1) {
				if( %this.holdingTeam == %forTeam )
					return "<Bflag_atbase.png>\nDefend " @ %this.objectiveName @ ".";
				else if(%this.holdingTeam != -1)
					return "<Bflag_enemycaptured.png>\nGrab " @ %this.objectiveName @ " from the " @ getTeamName(%this.holdingTeam) @ " team.";
				else if(%this.carrier != -1) {
					if(GameBase::getTeam(%this.carrier) == %forTeam)
						return "<Bflag_atbase.png>\nConvey " @ %this.objectiveName @ " to an empty flag stand. (carried by " @ String::escapeFormatting(Client::getName(Player::getClient(%this.carrier))) @ ")";
					else
						return "<Bflag_enemycaptured.png>\nWaylay " @ String::escapeFormatting(Client::getName(Player::getClient(%this.carrier))) @ " and convey " @ %this.objectiveName @ " to your base.";
				} else if ( %this.atHome )
					return "<Bflag_neutral.png>\nGrab " @ %this.objectiveName @ " and convey it to an empty flag stand.";
				else
					return "<Bflag_notatbase.png>\nFind " @ %this.objectiveName @ " and convey it to an empty flag stand.";
			} else {
				if( %this.holdingTeam != -1 )
					return "<Bflag_atbase.png>\nThe " @ getTeamName(%this.holdingTeam) @ " team has " @ %this.objectiveName @ ".";
				else if ( %this.carrier != -1 )
					return "<Bflag_atbase.png>\n" @ String::escapeFormatting(Client::getName(Player::getClient(%this.carrier))) @ " has " @ %this.objectiveName @ ".";
				else if( %this.atHome )
					return "<Bflag_neutral.png>\n" @ %this.objectiveName @ " has not been found.";
				else
					return "<Bflag_notatbase.png>\n" @ %this.objectiveName @ " has been dropped in the field.";
			}
		} else {
			if(%thisTeam == %forTeam) {
				if(%this.atHome)
					return "<Bflag_atbase.png>\nDefend your flag to prevent enemy captures.";
				else if(%this.carrier != -1)
					return "<Bflag_enemycaptured.png>\nReturn your flag to base. (carried by " @ String::escapeFormatting(Client::getName(Player::getClient(%this.carrier))) @ ")";
				else
					return "<Bflag_notatbase.png>\nReturn your flag to base. (dropped in the field)";
			} else {
				if(%forTeam != -1) {
					if(%this.atHome)
						return "<Bflag_enemycaptured.png>\nGrab the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
					else if(%this.carrier == -1)
						return "<Bflag_notatbase.png>\nFind the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
					else if(GameBase::getTeam(%this.carrier) == %forTeam)
						return "<Bflag_atbase.png>\nEscort friendly carrier " @ String::escapeFormatting(Client::getName(Player::getClient(%this.carrier))) @ " to base.";
					else
						return "<Bflag_enemycaptured.png>\nWaylay enemy carrier " @ String::escapeFormatting(Client::getName(Player::getClient(%this.carrier))) @ " and steal his flag.";
				} else {
					if ( %this.atHome )
						return "<Bflag_atbase.png>\nThe " @ getTeamName(%thisTeam) @ " flag is at their base.";
					else if(%this.carrier == -1)
						return "<Bflag_notatbase.png>\nThe " @ getTeamName(%thisTeam) @ " flag has been dropped in the field.";
					else 
						return "<Bflag_atbase.png>\n" @ String::escapeFormatting(Client::getName(Player::getClient(%this.carrier))) @ " has the " @ getTeamName(%thisTeam) @ " flag.";
				}
			}         
		}
	}
}


function Flag::onDrop( %player, %type ) {
	%playerTeam = GameBase::getTeam(%player);
	%flag = %player.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	%playerClient = Player::getClient(%player);
	%dropClientName = Client::getName(%playerClient);

	if(%flagTeam == -1) {
		message::allExcept(%playerClient, 1, %dropClientName @ " dropped " @ %flag.objectiveName @ "!");
		Client::sendMessage(%playerClient, 1, "You dropped "  @ %flag.objectiveName @ "!");
	} else {
		message::allExcept(%playerClient, 0, %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!");
		Client::sendMessage(%playerClient, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!");
		message::teams(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
	}
	
	GameBase::throw(%flag, %player, 10, false);
	Item::hide(%flag, false);
	Player::setItemCount(%player, "Flag", 0);
	%flag.carrier = -1;
	%player.carryFlag = "";
	Flag::clearWaypoint(%playerClient, false);

	schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
	ObjectiveMission::ObjectiveChanged(%flag);
}


function Flag::checkReturn( %flag, %sequenceNum ) {
	if(%flag.pickupSequence == %sequenceNum && %flag.timerOn == "") {
		if(%flag.dropFade) { 
			GameBase::startFadeOut(%flag);
			%flag.dropFade= "";
			%flag.fadeOut= 1;
			schedule("Flag::checkReturn(" @ %flag @ ", " @ %sequenceNum @ ");", 2.5);
		} else {
			%flagTeam = GameBase::getTeam(%flag);
			if(%flagTeam == -1) {
				if(%flag.flagStand == "" || %flag.flagStand.flag != "") {
					message::all(0, %flag.objectiveName @ " was returned to its initial position.");
					GameBase::setPosition(%flag, %flag.originalPosition);
					Item::setVelocity(%flag, "0 0 0");
					%flag.flagStand = "";
				} else {
					%holdTeam = GameBase::getTeam(%flag.flagStand);
					message::teams(0, %holdTeam, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(GameBase::getTeam(%flag.flagStand)) @ " flag was returned to base.~wflagreturn.wav");
					GameBase::setPosition(%flag, GameBase::getPosition(%flag.flagStand));
					%flag.flagStand.flag = %flag;
					%flag.holdingTeam = %holdTeam;
					%flag.carrier = -1;
					$teamScore[%holdTeam] += %flag.scoreValue;
					$deltaTeamScore[%holdTeam] += %flag.deltaTeamScore;
					%flag.holder = %flag.flagStand;
					message::teams(0,%holdTeam, "Your team holds " @ %flag.objectiveName @ ".~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team holds " @ %flag.objectiveName @ ".");
					ObjectiveMission::checkScoreLimit();
				}
			} else {
				message::teams(0, %flagTeam, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was returned to base.~wflagreturn.wav");
				GameBase::setPosition(%flag, %flag.originalPosition);
				Item::setVelocity(%flag, "0 0 0");
			}
			
			%flag.atHome = true;
			GameBase::startFadeIn(%flag);
			%flag.fadeOut= "";
			ObjectiveMission::ObjectiveChanged(%flag);
		}
	}
}


function Flag::onCollision(%this, %object)
{
   //echo("Flag collision ", %object);
   if(getObjectType(%object) != "Player")
      return;

   if(%this.carrier != -1)
      return; // spurious collision
      
   if(Player::isAIControlled(%object))
   	return;   
      
   %name = Item::getItemData(%this);
   %playerTeam = GameBase::getTeam(%object);
   %flagTeam = GameBase::getTeam(%this);
   %playerClient = Player::getClient(%object);
   %touchClientName = Client::getName(%playerClient);
							 

   if(%flagTeam == %playerTeam)
   {
      // player is touching his own flag...
      if(!%this.atHome)
      {
         // the flag isn't home! so return it.
			GameBase::startFadeOut(%this);
			GameBase::setPosition(%this, %this.originalPosition);
         Item::setVelocity(%this, "0 0 0");
			GameBase::startFadeIn(%this);
         %this.atHome = true;
         message::allExcept(%playerClient, 0, %touchClientName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
         Client::sendMessage(%playerClient, 0, "You returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
         message::teams(1, %playerTeam, "Your flag was returned to base.", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
         %this.pickupSequence++;
         ObjectiveMission::ObjectiveChanged(%this);
      }
      else
      {
         // it's at home - see if we have an enemy flag!
         if(%object.carryFlag != "")
         {
            // can't cap the neutral flags, duh
           	%enemyTeam = GameBase::getTeam(%object.carryFlag);
			   if(%enemyTeam != -1)
            {
               message::allExcept(%playerClient, 0, %touchClientName @ " captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
               Client::sendMessage(%playerClient, 0, "You captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
               message::teams(1, %playerTeam, "Your team captured the flag.", %enemyTeam, "Your team's flag was captured.");
            
               %flag = %object.carryFlag;
               %flag.atHome = true;
               %flag.carrier = -1;
               %flag.caps[%playerTeam]++;
               %flag.enemyCaps++;
               
               
               Item::hide(%flag, false);
               $flagAtHome[1] = true;
               GameBase::setPosition(%flag, %flag.originalPosition);
               Item::setVelocity(%flag, "0 0 0");

               %flag.trainingObjectiveComplete = true;
               ObjectiveMission::ObjectiveChanged(%flag);

               Player::setItemCount(%object, Flag, 0);
               %object.carryFlag = "";
               Flag::clearWaypoint(%playerClient, true);

               $teamScore[%playerTeam] += %flag.scoreValue;
               ObjectiveMission::checkScoreLimit();

               //flag carrier gets 5 points for caputure
               %playerClient.score += 5;
               message::all(0, Client::getName(%playerClient) @ " receives 5 point capture bonus.");
            }
         }
      }
   }
   else
   {
      // it's an enemy's flag! woohoo!
      if(%object.carryFlag == "")
      {
			if(%object.outArea == "") {
				// don't pick up our flags
        		if(%this.holdingTeam == %playerTeam)
        		   return;

        		Player::setItemCount(%object, Flag, 1);
        		Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
        		Item::hide(%this, true);
        		$flagAtHome[1] = false;
        		%this.atHome = false;
        		%this.carrier = %object;
        		%this.pickupSequence++;
        		%object.carryFlag = %this;
	 			Flag::setWaypoint(%playerClient, %this);
	 			if(%this.fadeOut) {
					GameBase::startFadeIn(%this);
	 				%this.fadeOut= "";
				}
        		
        		if((%this.lastTeam == "" || %this.lastTeam != %playerTeam) && %flagTeam == -1) {
			 		%this.currentFlagStand="";
			 		%this.changeTeamCount++;
					%this.lastTeam = %playerTeam;
     		      %this.timerOn = 1;
     		      if($flagToStandTime >= 30) {
	     		      %timeToStand = $flagToStandTime - 30;
						%timeLeft = 30;
	     		      if($flagToStandTime > 30)
	     		      	Client::sendMessage(%playerClient, 0, "You have " @ $flagToStandTime @ " sec to put the flag in a stand.");
					}
					else {	
						if($flagToStandTime >= 10)
							%remain = $flagToStandTime % 10;
						else 
							%remain = $flagToStandTime % 5;
						
						if(%remain > 0 && %remain != $flagToStandTime) {
							%timeToStand = %remain;
							%timeLeft = $flagToStandTime - %remain;
		     		      Client::sendMessage(%playerClient, 0, "You have " @ $flagToStandTime @ " sec to put the flag in a stand.");
						}
						else {
							%timeToStand = 0;
							%timeLeft = $flagToStandTime;
						}
					}

     		      schedule("Flag::checkFlagsTime(" @ %this @"," @ %timeLeft @ "," @ %this.changeTeamCount @ ");",%timeToStand);
				}
        		
        		if(%flagTeam != -1)
        		{
	     		   message::allExcept(%playerClient, 0, %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
        		   Client::sendMessage(%playerClient, 0, "You took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
        		   message::teams(1, %playerTeam, "Your team has the " @ getTeamName(%flagTeam) @ " flag.", %flagTeam, "Your team's flag has been taken.");
        		}
        		else
        		{
        		   %hteam = %this.holdingTeam;
	     		   if(%hteam != -1)
        		   {
        		      $teamScore[%hteam] -= %this.scoreValue;
        		      $deltaTeamScore[%hteam] -= %this.deltaTeamScore;

	     		      message::allExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
        		      Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
        		      message::teams(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", %hteam, "Your team lost " @ %this.objectiveName @ ".", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.");
        		      %this.holdingTeam = -1;
        		      %this.holder.flag = "";
        		   }
        		   else
        		   {
	     		      message::allExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ ".~wflag1.wav");
        		      Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ ".~wflag1.wav");
        		      message::teams(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", -2, "", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ ".");
        		   }
        		}
        		%this.trainingObjectiveComplete = true;
        		ObjectiveMission::ObjectiveChanged(%this);
			}
			else
  		      Client::sendMessage(%playerClient, 1, "Flag not in mission area.");
		}
   }
}

function Flag::checkFlagsTime(%flag,%timeleft,%changeCount)
{
	if(%flag.changeTeamCount == %changeCount)
	{
		%client = Player::getClient(%flag.carrier);
		if(%timeleft <= 0 && %flag.currentFlagStand == "") { 
			GameBase::startFadeOut(%flag);
      	Player::setItemCount(%flag.carrier, "Flag", 0);
	 		%clientName = Client::getName(%client);
   		%flagTeam = GameBase::getTeam(%flag);
  	   	if(%flagTeam == -1 && (%flag.flagStand == "" || (%flag.flagStand).flag != "") ) 
   		{
      		if(%client != -1) {
      			message::allExcept(%client, 0, %clientName @ " didn't put " @ %flag.objectiveName @ " in a flag stand in time!  It was returned to its initial position.");
      			Client::sendMessage(%client, 0, "You didn't get " @ %flag.objectiveName @ " to a flag stand in time!  It was returned to its initial position.");
				}
				else
      			message::all(0, %flag.objectiveName @ " was not put in a flag stand in time!  It was returned to its initial position.");
				GameBase::setPosition(%flag, %flag.originalPosition);
      	   Item::setVelocity(%flag, "0 0 0");
				%flag.flagStand = "";
   		}
   		else
   		{
				if(%flagTeam != -1) {
					%team = %flagTeam;
					GameBase::setPosition(%flag, %flag.originalPosition);
      	      Item::setVelocity(%flag, "0 0 0");
				}
				else {
					%team = GameBase::getTeam(%flag.flagStand);
					GameBase::setPosition(%flag, GameBase::getPosition(%flag.flagStand));
      	      Item::setVelocity(%flag, "0 0 0");
				}
				if(%client != -1) {
      			message::allExcept(%client, 0, %clientName @ " didn't put " @ %flag.objectiveName @ " in a flag stand in time!");
      			Client::sendMessage(%client, 0, "You didn't get " @ %flag.objectiveName @ " to a flag stand in time!");
      		}
      		else
      			message::all(0, %flag.objectiveName @ " was not put in a flag stand in time!");
      		message::teams(1, %team, %flag.objectiveName @ " was returned to your base.~wflagreturn.wav", -2, "", %flag.objectiveName @ " was returned to the " @ getTeamName(%team) @ " base.");
	   	   %holdTeam = GameBase::getTeam(%flag.flagStand);
	   		$teamScore[%holdTeam] += %flag.scoreValue;
	   		$deltaTeamScore[%holdTeam] += %flag.deltaTeamScore;
				%flag.holder = %flag.flagStand;
   			%flag.flagStand.flag = %flag;
				%flag.holdingTeam = %holdTeam;
			}
			GameBase::startFadeIn(%flag);
			Item::hide(%flag, false);

			(%flag.carrier).carryFlag = "";
      	%flag.carrier = -1;
        	Flag::clearWaypoint(%client, false);
      	ObjectiveMission::ObjectiveChanged(%flag);
			ObjectiveMission::checkScoreLimit();





			%flag.lastTeam = "";
		}
		else if(%flag.currentFlagStand == "") {
			Client::sendMessage(%client, 0, "You have " @ %timeleft @ " sec to put the flag in a stand.");
			if(%timeleft <= 5) {
				%timeleft--;
				%nextTime = 1;
			}
			else if(%timeleft == 10) { 
				%timeleft -= 5;
				%nextTime = 5;
			}
			else {
				%timeleft -= 10;
				%nextTime = 10;
			}
	      schedule("Flag::checkFlagsTime(" @ %flag @","@ %timeleft @"," @ %changeCount @ ");",%nextTime);
		}
	}
}

function Flag::clearWaypoint(%client, %success)
{
   if(%success)
      setCommandStatus(%client, 0, "Objective completed.~wobjcomp");
   else
      setCommandStatus(%client, 0, "Objective failed.");
}

function Flag::setWaypoint(%client, %flag)
{
   if(!%client.autoWaypoint)
      return;
   %flagTeam = GameBase::getTeam(%flag);
   %team = Client::getTeam(%client);

	if(%flagTeam == -1)
	{ 
		for(%s = $Team::FlagStand[%team]; %s != ""; %s = %s.nextFlagStand) 
		{
			if(%s.flag == "") {
				%pos = GameBase::getPosition(%s);
				%posX = getWord(%pos,0);
				%posY = getWord(%pos,1);
   	   	issueCommand(%client, %client, 0,"Take " @ %flag.objectiveName @ " to empty flag stand.~wcapobj", %posX, %posY);
				return;
			}
      }
	}
	else
	{
		%pos = ($Team::Flag[%team]).originalPosition;
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
  	   issueCommand(%client, %client, 0,"Take the " @ getTeamName(%flagTeam) @ " flag to our flag.~wcapobj", %posX, %posY);
		return;
	}
}

function FlagStand::objectiveInit(%this)
{
   %this.flag = "";
   %team = GameBase::getTeam(%this);

   %this.nextFlagStand = $Team::FlagStand[%team];
   $Team::FlagStand[%team] = %this;
	
   return false;
}

function FlagStand::onCollision(%this, %object)
{
   //echo("FlagStand collision ", %object);
   %standTeam = GameBase::getTeam(%this);
   %playerTeam = GameBase::getTeam(%object);

   if(%standTeam == -1 || getObjectType(%object) != "Player" || %object.carryFlag == ""
         || %playerTeam != %standTeam || %this.flag != "" || GameBase::getTeam(%object.carryFlag) != -1)
      return;

   // if we're here, we're carrying a flag, we've hit 
   // our flag stand, it doesn't have a flag, and we're not carrying
   // a team coded flag.

   %flag = %object.carryFlag;
   %flag.carrier = -1;
   Item::hide(%flag, false);
   GameBase::setPosition(%flag, GameBase::getPosition(%this));
	%flag.flagStand = %this;
   Player::setItemCount(%object, Flag, 0);
   %object.carryFlag = "";
   %playerClient = Player::getClient(%object);
   Flag::clearWaypoint(%playerClient, true);

   $teamScore[%playerTeam] += %flag.scoreValue;
   $deltaTeamScore[%playerTeam] += %flag.deltaTeamScore;
   %flag.holder = %this;
   %flag.holdingTeam = %playerTeam;
   %this.flag = %flag;
	%flag.currentFlagStand = %this;

   message::allExcept(%playerClient, 0, Client::getName(%playerClient) @ " conveyed " @ %flag.objectiveName @ " to base.");
   Client::sendMessage(%playerClient, 0, "You conveyed " @ %flag.objectiveName @ " to base.");
   message::teams(1, %playerTeam, "Your team holds " @ %flag.objectiveName @ ".~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team holds " @ %flag.objectiveName @ ".");

   %flag.trainingObjectiveComplete = true;
   ObjectiveMission::ObjectiveChanged(%flag);
   ObjectiveMission::checkScoreLimit();
}

function Flag::clientKilled(%this, %playerId, %killerId)
{
   %player = Client::getOwnedObject(%playerId);
   %killer = Client::getOwnedObject(%killerId);

   if(%player == -1 || %killer == -1)
      return;

   %flagTeam = GameBase::getTeam(%this);
   if(%flagTeam == -1)
      return;

   %playerTeam = GameBase::getTeam(%player);
   %killerTeam = GameBase::getTeam(%killer);

   if(%playerTeam == %killerTeam)
      return;

   // killer's the only guy who gets a bonus.
   if(%killerTeam == %flagTeam)
   {
      // check for defending the flag
      // only if the flag is not being carried
      if(%this.carrier == -1)
      {
         %flagPos = GameBase::getPosition(%this);
         %playerPos = GameBase::getPosition(%player);

         if(Vector::getDistance(%flagPos, %playerPos) < 80)
         {
            %killerId.score++;
            message::all(0, Client::getName(%killerId) @ " gets a bonus for defending the flag!");
         }
      }
   }
   else
   {
      if(%this.carrier != -1)
      {
         %carrierTeam = GameBase::getTeam(%this.carrier);
         // check for defending the carrier bonus
         if(%carrierTeam == %killerTeam)
         {
            if(Vector::getDistance(GameBase::getPosition(%this.carrier),
               GameBase::getPosition(%killer)) < 80)
            {
               %killerId.score++;
               message::all(0, Client::getName(%killerId) @ " gets a bonus for defending the flag carrier!");
            }               
         }
      }
   }
}

function Flag::clientDropped(%this, %clientId)
{
   //echo(%this @ " " @ %clientId);
   %type = Player::getMountedItem(%clientId, $FlagSlot);
   if(%type != -1)
      Player::dropItem(%clientId, %type);
}

function Flag::playerLeaveMissionArea(%this, %playerId) {
	// if a guy leaves the area, warp the flag back to its base
	if(%this.carrier == %playerId) {
		GameBase::startFadeOut(%this);
		Player::setItemCount(%playerId, "Flag", 0);
		%playerClient = Player::getClient(%playerId);
		%clientName = Client::getName(%playerClient);
		%flagTeam = GameBase::getTeam(%this);
		if(%flagTeam == -1 && (%this.flagStand == "" || (%this.flagStand).flag != "") ) {
			message::allExcept(%playerClient, 0, %clientName @ " left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
			Client::sendMessage(%playerClient, 0, "You left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
			GameBase::setPosition(%this, %this.originalPosition);
			Item::setVelocity(%this, "0 0 0");
			%this.flagStand = "";
		} else {
			if(%flagTeam != -1) {
				%team = %flagTeam;
				GameBase::setPosition(%this, %this.originalPosition);
				Item::setVelocity(%this, "0 0 0");
			} else {
				%team = GameBase::getTeam(%this.flagStand);
				GameBase::setPosition(%this, GameBase::getPosition(%this.flagStand));
				Item::setVelocity(%this, "0 0 0");
			}
		
			message::allExcept(%playerClient, 0, %clientName @ " left the mission area while carrying the " @ getTeamName(%team) @ " flag!");
			Client::sendMessage(%playerClient, 0, "You left the mission area while carrying the " @ getTeamName(%team) @ " flag!");
			message::teams(1, %team, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(%team) @ " flag was returned to base.");
		
			%holdTeam = GameBase::getTeam(%this.flagStand);
			$teamScore[%holdTeam] += %this.scoreValue;
			$deltaTeamScore[%holdTeam] += %this.deltaTeamScore;
			%this.holder = %this.flagStand;
			%this.flagStand.flag = %this;
			%this.holdingTeam = %holdTeam;
			%this.atHome = true; // fix the oob return bug!
		}

		GameBase::startFadeIn(%this);
		%this.carrier = -1;
		Item::hide(%this, false);

		%playerId.carryFlag = "";
		Flag::clearWaypoint(%playerClient, false);
		ObjectiveMission::ObjectiveChanged(%this);
		ObjectiveMission::checkScoreLimit();
	}
}
