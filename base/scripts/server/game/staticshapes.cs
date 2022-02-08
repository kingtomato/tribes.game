function Sensor::objectiveInit(%this)
{
   return StaticShape::objectiveInit(%this);
}

function Turret::objectiveInit(%this)
{
   return StaticShape::objectiveInit(%this);
}

function StaticShape::objectiveInit(%this)
{
   %this.destroyerTeam = "";
   return %this.scoreValue != "";
}

function Sensor::getObjectiveString(%this, %forTeam)
{
   return StaticShape::getObjectiveString(%this, %forTeam);
}

function Turret::getObjectiveString(%this, %forTeam)
{
   return StaticShape::getObjectiveString(%this, %forTeam);
}

function StaticShape::getObjectiveString(%this, %forTeam)
{
   %thisTeam = GameBase::getTeam(%this);
   if(%this.destroyerTeam != "")
   {
      if(%forTeam == %this.destroyerTeam && %thisTeam != %forTeam)
         return "<Bitem_ok.png>\nYour team successfully destroyed the " @ getTeamName(%thisTeam) @ " " @ %this.objectiveName @ " objective.";
      else if(%forTeam == %thisTeam)
         return "<Bitem_damaged.png>\nYour team failed to defend " @ %this.objectiveName;
      else
         return "<Bitem_ok.png>\n" @ getTeamName(%this.destroyerTeam) @ " team destroyed the " @ getTeamName(%thisTeam) @ " " @ %this.objectiveName @ " objective.";
   }
   else
   {
      if($missionComplete)
      {
         if(%forTeam != -1) {
				if(%forTeam == %thisTeam)
         	   return "<Bitem_ok.png>\nYour team successfully defended " @ %this.objectiveName @ ".";
         	else
         	   return "<Bitem_damaged.png>\nYour team failed to destroy " @ getTeamName(%thisTeam) @ " objective, " @ %this.objectiveName @ ".";
      	}
			else 
        	   return "<Bitem_ok.png>\n" @ getTeamName(%thisTeam) @ " failed to destroy the " @ %this.objectiveName @ " objective.";
		}
      else
      {
         if(%forTeam != -1) {
         	if(%forTeam == %thisTeam)
            	return "<Bitem_ok.png>\nDefend " @ %this.objectiveName @ ".";
         	else
	          	return "<Bitem_damaged.png>\nDestroy " @ getTeamName(%thisTeam) @ " objective, " @ %this.objectiveName @ "(" @ %this.scoreValue @ " points).";
      	}
			else 
        	   return "<Bitem_ok.png>\n" @ getTeamName(%thisTeam) @ " must defend the " @ %this.objectiveName @ " objective.";

      }
   }
}

function StaticShape::timeLimitReached(%this)
{
   if(%this.scoreValue && !%this.destroyerTeam)
   {
      // give the defense some props!
      $teamScore[GameBase::getTeam(%this)] += %this.scoreValue;
   }
}

function StaticShape::objectiveDestroyed(%this)
{
	if(%this.destroyed == "") {
   	// test if it's really an objective
   	if(!%this.objectiveLine)
      	return;
   	%destroyerTeam = %this.lastDamageTeam;
		%thisTeam = GameBase::getTeam(%this);
      %playerClient = GameBase::getControlClient(%this.lastDamageObject);
      if(%playerClient != -1)
         %clientName = Client::getName(%playerClient);

   	if(%thisTeam == %destroyerTeam)
   	{
   	   // uh-oh... we killed our own stuff.
   	   // award the points to everyone else
   	   for(%i = 0; %i < getNumTeams(); %i++)
   	   {
   	      if(%i == %thisTeam)
   	         continue;
   	      $teamScore[%i] += %this.scoreValue;
   	   }
         if(%playerClient != -1)
         {
      	   message::allExcept(%playerClient, 0, %clientName @ " destroyed a friendly objective.");
      	   Client::sendMessage(%playerClient, 0, "You destroyed a friendly objective!");
         }
         message::all(1, getTeamName(%destroyerTeam) @ " objective " @ %this.objectiveName @ " destroyed.");
   	}
   	else
   	{
   	   $teamScore[%destroyerTeam] += %this.scoreValue;
         if(%playerClient != -1)
         {
			   %playerClient.score+=5;
      	   message::allExcept(%playerClient, 0, %clientName @ " destroyed an objective!");
      	   Client::sendMessage(%playerClient, 0, "You destroyed an objective!");
         }
         message::all(1, getTeamName(%thisTeam) @ " objective " @ %this.objectiveName @ " destroyed.");
   	}
   	%this.destroyerTeam = %destroyerTeam;
   	ObjectiveMission::ObjectiveChanged(%this);
   	ObjectiveMission::checkScoreLimit();
		%this.destroyed = 1;
	}
}

function StaticShape::objectiveDisabled(%this)
{
}
