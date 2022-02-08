newObject(PlayChatMenu, ChatMenu, "Root Menu:");
newObject(CommandChatMenu, ChatMenu, "Command Menu");

function setPlayChatMenu(%heading)
{
   $curPlayChatMenu = %heading;
}

function setCommanderChatMenu(%heading)
{
   $curCommanderChatMenu = %heading;
}

function addPlayTeamChat(%text, %msg, %sound)
{
   if(%sound != "")
   {
      %msg = %msg @ "~w" @ %sound;
   }
   if($curPlayChatMenu != "")
   {
      %text = $curPlayChatMenu @ "\\" @ %text;
   }
   addCMCommand(PlayChatMenu, %text, say, 1, %msg);
}

function addPlayChat(%text, %msg, %sound)
{
   if(%sound != "")
   {
      %msg = %msg @ "~w" @ %sound;
   }
   if($curPlayChatMenu != "")
   {
      %text = $curPlayChatMenu @ "\\" @ %text;
   }
   addCMCommand(PlayChatMenu, %text, say, 0, %msg);
}

function addPlayAnim(%text, %anim, %sound)
{
   if($curPlayChatMenu != "")
   {
      %text = $curPlayChatMenu @ "\\" @ %text;
   }
   addCMCommand(PlayChatMenu, %text, messageAndAnimate, %anim, %sound);
}

function addLocal(%text, %sound)
{
   if($curPlayChatMenu != "")
   {
      %text = $curPlayChatMenu @ "\\" @ %text;
   }
   addCMCommand(PlayChatMenu, %text, localMessage, %sound);
}

function addPlayCMDResponse(%text, %action, %msg, %sound)
{
   if(%sound != "")
      %msg = %msg @ "~w" @ %sound;
   if($curPlayChatMenu != "")
      %text = $curPlayChatMenu @ "\\" @ %text;
   addCMCommand(PlayChatMenu, %text, remoteEval, 2048, "CStatus", %action, %msg);
}

function addCommandResponse(%text, %action, %msg, %sound)
{
   if(%sound != "")
      %msg = %msg @ "~w" @ %sound;
   if($curCommanderChatMenu != "")
      %text = $curCommanderChatMenu @ "\\" @ %text;
   addCMCommand(CommandChatMenu, %text, remoteEval, 2048, "CStatus", %action, %msg);
}


function addContextCommand(%text, %type)
{
   if($curCommanderChatMenu != "")
      %text = $curCommanderChatMenu @ "\\" @ %text;
   addCMCommand(CommandChatMenu, %text, contextCommand, %type);
}

function addCommand(%text, %action, %msg, %sound)
{
   if(%sound != "")
      %msg = %msg @ "~w" @ %sound;
   if($curCommanderChatMenu != "")
      %text = $curCommanderChatMenu @ "\\" @ %text;
   addCMCommand(CommandChatMenu, %text, setIssueCommand, %action, %msg);
}

// Player Chat menu

setPlayChatMenu("vOffense");
		addPlayTeamChat("aAttack!","Attack!", attack);
		addPlayTeamChat("wWait for signal", "Wait for my signal to attack.", waitsig);
		addPlayTeamChat("cCease fire", "Cease fire!", cease);
		addPlayTeamChat("mMove out", "Move out.", moveout);
		addPlayTeamChat("rRetreat", "Retreat!", retreat);
		addPlayTeamChat("bGo on the offensive", "Go on the offensive.", gooff);
		addPlayTeamChat("hHit deck", "Hit the deck!", hitdeck);
		addPlayTeamChat("eRegroup", "Regroup.", regroup);
		addPlayTeamChat("vCover me", "Cover me!", coverme);
		addPlayTeamChat("gGoing offense", "Going offense.", ono);
		addPlayTeamChat("zAPC ready", "APC ready to go... waiting for passengers.", waitpas);

setPlayChatMenu("tTarget");
		addPlayTeamChat("aTarget acquired", "Target Acquired", tgtacq);
		addPlayTeamChat("fFire on my target", "Fire on my target", firetgt);
		addPlayTeamChat("nTarget needed", "I need a target.", needtgt);
		addPlayTeamChat("oTarget out of range", "Target out of range.", tgtout);
		addPlayTeamChat("dDestroy Enemy Generator", "Destroy the enemy generator.", desgen);
		addPlayTeamChat("eEnemy Generator Destroyed", "Enemy generator destroyed.", gendes);
		addPlayTeamChat("tDestroy Enemy Turret", "Destroy enemy turret.", destur);
		addPlayTeamChat("sEnemy Turret Destroyed", "Enemy turret destroyed.", turdes);

setPlayChatMenu("dDefense");
		addPlayTeamChat("iIncoming Enemies", "Incoming enemies!", incom2);
		addPlayTeamChat("aAttacked", "We are being attacked.", basatt);
		addPlayTeamChat("eEnemy is attacking base", "The enemy is attacking our base.", basundr);
		addPlayTeamChat("nNeed more defense", "We need more defense.", needdef);
		addPlayTeamChat("bDefend our base", "Defend our base.", defbase);
		addPlayTeamChat("gGo on the defensive", "Go on the defensive.", godef);
		addPlayTeamChat("dDefending base", "Defending our base.", defend);
		addPlayTeamChat("tBase Taken", "Base is taken.", basetkn);
		addPlayTeamChat("cBase Clear", "Base is secured.", bsclr2);
		addPlayTeamChat("qIs Base Clear?", "Is our base clear?", isbsclr);

setPlayChatMenu("fFlag");
		addPlayTeamChat("tMine flag", "Mine the flag.", mineflg);
		addPlayTeamChat("gFlag gone", "Our flag is not in the base!", flgtkn1);
		addPlayTeamChat("eEnemy has flag", "The enemy has our flag!", flgtkm2);
		addPlayTeamChat("hHave enemy flag", "I have the enemy flag.", haveflg);
		addPlayTeamChat("sFlag secure", "Our flag is secure.", flaghm);
		addPlayTeamChat("rReturn our flag", "Return our flag to base.", retflag);
		addPlayTeamChat("fGet enemy flag", "Get the enemy flag.", geteflg);
		addPlayTeamChat("mFlag mined", "Our flag is mined.", flgmine);
		addPlayTeamChat("cClear mines", "Clear the mines from our flag.", clrflg);
		addPlayTeamChat("dMines cleared", "Mines have been cleared.", mineclr);

setPlayChatMenu("rNeed");
		addPlayTeamChat("rNeed Repairs", "Need repairs.", needrep);
		addPlayTeamChat("aNeed APC Pickup", "I need an APC pickup.", needpku);
		addPlayTeamChat("eNeed Escort", "I need an escort back to base.", needesc);
		addPlayTeamChat("tNeed Ammo", "Can anyone bring me some ammo?", needamo);

setPlayChatMenu("eTeam");
		addPlayTeamChat("wWatch Shooting", "Watch where your shooting!", wshoot3);
		addPlayTeamChat("hHi", "Hi.", hello);
		addPlayTeamChat("bBye", "Bye!", bye);
		addPlayTeamChat("zDoh!", "Doh!", oops1);
		addPlayTeamChat("fHow'd that feel?", "How'd that feel?", taunt10);
		addPlayTeamChat("cAh Crap!", "Ah Crap!", color7);
		addPlayTeamChat("oOops!", "Oops!", oops2);
		addPlayTeamChat("rShazbot!", "Shazbot!", color2);
		addPlayTeamChat("xArgh!", "Argh!", dsgst4);
		addPlayTeamChat("dDont know", "I don't know.", dontkno);
		addPlayTeamChat("nNo", "No.", no);
		addPlayTeamChat("yYes", "Yes.", yes);
		addPlayTeamChat("6Sigh", "*sigh*", dsgst5);
		addPlayTeamChat("gWait", "Don't return the flag yet!", wait1);
		addPlayTeamChat("eReady", "Tell me when to return the flag.", ready);
		addPlayTeamChat("qDamnit", "Damnit!", color6);
		addPlayTeamChat("tThanks", "Thanks", thanks);
		addPlayTeamChat("aNo Problem", "No Problem.", noprob);
		addPlayTeamChat("sSorry", "Sorry.", sorry);
		addPlayTeamChat("uWoo-hoo!", "Woo-hoo!", cheer2);
		addPlayTeamChat("iYeah!", "Yeah!", cheer1);
		addPlayTeamChat("jAlright!", "Alright!", cheer3);
// why does this line throw an error? wtf
//		addLocal("uHurry station", hurystn);
		
setPlayChatMenu("sIncoming Enemies - Direction");
		addPlayTeamChat("wIncoming North", "*** INCOMING NORTH ***", incom2);
		addPlayTeamChat("aIncoming West", "*** INCOMING WEST ***", incom2);
		addPlayTeamChat("sIncoming East", "*** INCOMING EAST ***", incom2);
		addPlayTeamChat("zIncoming South", "*** INCOMING SOUTH ***", incom2);
		addPlayTeamChat("dIncoming HEAVIES", "*** INCOMING HEAVIES ***", hitdeck);

setPlayChatMenu("gGlobal");
		addPlayChat("zDoh", "Doh!", oops1);
		addPlayChat("oOops", "Oops!", oops2);
		addPlayChat("yShazbot", "Shazbot!", color2);
		addPlayChat("qDamnit", "Damnit!", color6);
		addPlayChat("cCrap", "Ah Crap!", color7);
		addPlayChat("eDuh", "Duh.", dsgst1);
		addPlayChat("xYou Idiot", "You Idiot!", dsgst2);
		addPlayChat("gI've Had Worse", "I've had worse.", tautn11);
		addPlayChat("hHi", "Hi.", hello);
		addPlayChat("bBye", "Bye!", bye);
		addPlayChat("sSorry", "Sorry.", sorry);
		addPlayChat("dI don't know", "I don't know.", dontkno);
		addPlayChat("wArgh!", "Argh!", dsgst4);
		addPlayChat("kHmmmm...", "Hmmm.", color3);
		addPlayChat("mYooo-Hooo!", "Yoo-Hoo!", taunt1);
		addPlayChat("uWhoohoo", "Woo-hoo!", cheer2);
		addPlayChat("iYeah!", "Yeah!", cheer1);
		addPlayChat("jAlright!", "Alright!", cheer3);
		addPlayChat("pWait", "Wait.", wait1);
		addPlayChat("aNo Problem", "No Problemo.", noprob);
		addPlayChat("tThanks", "Thanks.", thanks);
		addPlayChat("nOver Here", "Over here!", ovrhere);
		addPlayChat("vCome Get Some", "Come get some!", taunt4);
		addPlayChat("rHow'd That Feel?", "How'd that feel?", taunt10);
		addPlayChat("1Dance", "Dance!", taunt3);
		addPlayChat("2Waiting", "Waiting.", wait2);
		addPlayChat("3Ready", "Ready.", ready);
		addPlayChat("4Missed Me", "Missed me!", taunt2);
		addPlayChat("5Hey!", "Hey!!", wshoot1);
		addPlayChat("6Sigh", "*sigh*", dsgst5);
		addPlayChat("7Yes", "Yes.", yes);
		addPlayChat("8No", "No.", no);

setPlayChatMenu("aAnimations");
		addPlayAnim("oOver here", 0, ovrhere);
		addPlayAnim("dMove out of way", 1, outway);
		addPlayAnim("rRetreat", 2, retreat);
		addPlayAnim("sStop", 3, dsgst4);
		addPlayAnim("fSalute", 4, yes);
		addPlayAnim("zKneel Pose", 10);
		addPlayAnim("xStand Pose", 11);
		addPlayAnim("qCelebrate 1", 5, cheer1);
		addPlayAnim("eCelebrate 2", 6, cheer2);
		addPlayAnim("wCelebrate 3", 7, cheer3);
		addPlayAnim("vTaunt 1 - how'd that feel?", 8, taunt10);
		addPlayAnim("gTaunt 2 - Come get some", 9, taunt4);
		addPlayAnim("hWave - Hi", 12, hello);
		addPlayAnim("bWave - Bye", 12, bye);


setPlayChatMenu("zCommand Response");
	addPlayCMDResponse("aAcknowledged", 1, "Command acknowledged", "acknow");
	addPlayCMDResponse("zCompleted", 0, "Objective complete", "objcomp");
	addPlayCMDResponse("uUnable to complete", 0, "Unable to complete objective", "objxcmp");


// Commander Menu

function contextIssueCommand(%action, %msg, %sound)
{
   if(%sound != "")
      %msg = %msg @ "~w" @ %sound;
   setIssueCommand(%action, %msg);
}

// $CommandTarget can be one of:

// waypoint
// enemy vehicle
// enemy player
// enemy static
// enemy turret
// enemy sensor
// friendly vehicle
// friendly player
// friendly static
// friendly turret
// friendly sensor


function Commander::StarCommand(%type)
{
   if(%type == "*Attack")
   {
      if($CommandTarget == "enemy static")
			contextIssueCommand(1, "Destroy enemy equipment at waypoint", "attobj"); 
      else if($CommandTarget == "enemy turret")
			contextIssueCommand(1, "Destroy enemy turret at waypoint", "attobj"); 
      else if($CommandTarget == "enemy sensor")
			contextIssueCommand(1, "Destroy enemy sensor at waypoint", "attobj"); 
      else if($CommandTarget == "enemy player" || $CommandTarget == "enemy vehicle")
         contextIssueCommand(1, "Attack enemy " @ $CommandTargetName, "attway");
      else if($CommandTarget == "friendly player")
         contextIssueCommand(1, "Cover " @ $CommandTargetName, "escfr");
      else if($CommandTarget == "friendly vehicle")
         contextIssueCommand(1, "Board APC ", "boarda");
      else
         contextIssueCommand(1, "Attack enemy forces", "attway");
   }
   else if(%type == "*Defend")
   {
		if($CommandTarget == "friendly player")
		   contextIssueCommand(2, "Defend " @ $CommandTargetName, "escfr"); 
		else
		   contextIssueCommand(2, "Defend waypoint", "defway");
   }
   else if(%type == "*Repair")
   {
		if($CommandTarget == "friendly player")
		   contextIssueCommand(2, "Repair " @ $CommandTargetName, "repplyr"); 
		else
		   contextIssueCommand(2, "Repair " @ $CommandTargetName, "repobj");
   }
}

setCommanderChatMenu("");
   addCommand("aAttack", 1, "*Attack");
   addCommand("dDefend", 2, "*Defend");
   addCommand("rRepair", 3, "*Repair");

   setCommanderChatMenu("eDeploy");
		setCommanderChatMenu("eDeploy\\sSensor");
			addCommand("pPulse sensor", 2, "Deploy pulse sensor at waypoint", "deppuls");
			addCommand("jJammer", 2, "Deploy sensor jammer at waypoint", "depjamr");
			addCommand("mMotion sensor", 2, "Deploy motion sensor at waypoint", "depmot");
			addCommand("cCamera", 2, "Deploy camera at waypoint", "depcam");
		setCommanderChatMenu("eDeploy\\aObject");
			addCommand("aAmmo", 2, "Deploy Ammo Station", "depamo");
			addCommand("iInventory", 2, "Deploy Inventory Station", "depinv");
			addCommand("tTurret", 2, "Deploy Turret", "deptur");
			addCommand("bBeacon", 2, "Deploy beacon at waypoint", "depbecn");
		setCommanderChatMenu("eDeploy");
		addCommand("vA.P.C.", 2, "Pilot APC to waypoint", "pilot");

setCommanderChatMenu("kCommand Response");
	addCommandResponse("aAcknwledged", 1, "Command acknowledged", "acknow");
	addCommandResponse("cCompleted", 0, "Objective complete", "objcomp");
	addCommandResponse("uUnable to complete", 0, "Unable to complete objective", "objxcmp");