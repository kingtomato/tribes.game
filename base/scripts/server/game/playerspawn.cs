$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = "";


function Game::playerSpawned( %pl, %cl, %armor ) {
	%cl.spawn = 1;
	%max = getNumItems();
	for( %i = 0; ( %item = $spawnBuyList[%i] ) != ""; %i++ ) {
		buyItem( %cl,%item );
		if( %item.className == Weapon ) 
			%cl.spawnWeapon = %item;
	}
	
	%cl.spawn = "";
	if( %cl.spawnWeapon != "" ) {
		Player::useItem( %pl, %cl.spawnWeapon );
		%cl.spawnWeapon = "";
	}
}

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
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1) {
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   return false;
}

function Game::pickStartSpawn(%team) {
	%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Start");
	%count = Group::objectCount(%group);
	if( !%count )
		return -1;

	%spawnIdx = $lastTeamSpawn[%team] + 1;
	if( %spawnIdx >= %count )
		%spawnIdx = 0;
	$lastTeamSpawn[%team] = %spawnIdx;
	
	return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn( %team, %respawn ) {
	if ( %respawn )
		return Game::pickRandomSpawn(%team);

	%spawn = Game::pickStartSpawn(%team);
	if ( %spawn == -1 )
		return Game::pickRandomSpawn(%team);

	return %spawn;
}

function Game::pickObserverSpawn( %cl ) {
	%group = nameToID("MissionGroup/ObserverDropPoints");
	%count = Group::objectCount(%group);
	if( ( %group == -1 ) || !%count )
		%group = nameToID("MissionGroup/Teams/team" @ Client::getTeam(%cl) @ "/DropPoints/Random");
	
	%count = Group::objectCount(%group);
	if ( ( %group == -1 ) || !%count )
		%group = nameToID("MissionGroup/Teams/team0/DropPoints/Random");

	%count = Group::objectCount(%group);
	if ( ( %group == -1 ) || !%count )
		return -1;
	
	%spawnIdx = %cl.lastObserverSpawn + 1;
	if(%spawnIdx >= %count)
		%spawnIdx = 0;
	%cl.lastObserverSpawn = %spawnIdx;
	
	return Group::getObject( %group, %spawnIdx );
}


function Game::playerSpawn( %cl, %respawn ) {
	if( !$ghosting )
		return false;

	Client::clearItemShopping( %cl );
	%spawnMarker = Game::pickPlayerSpawn( %cl, %respawn );

	// initial drop
	if(!%respawn)
		message::bottomprint( %cl, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5) ;

	if ( !%spawnMarker ) {
		Client::sendMessage( %cl, 0, "Sorry No Respawn Positions Are Empty - Try again later" );
		return false;
	}

	%cl.guiLock = "";
	%cl.dead = "";

	if(%spawnMarker == -1) {
		%spawnPos = "0 0 300";
		%spawnRot = "0 0 0";
	} else {
		%spawnPos = GameBase::getPosition(%spawnMarker);
		%spawnRot = GameBase::getRotation(%spawnMarker);
	}

	if( !String::ICompare(Client::getGender(%cl), "Male") )
		%armor = "larmor";
	else
		%armor = "lfemale";

	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	echo("SPAWN: cl:" @ %cl @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	
	if ( %pl != -1 ) {
		GameBase::setTeam(%pl, Client::getTeam(%cl));
		Client::setOwnedObject(%cl, %pl);

		if($matchStarted) {
			Client::setControlObject(%cl, %pl);
			%ident = Stats::Identifier( %cl );
			StatLog::Push( PlayerSpawn, %ident, %spawnPos );
		} else {
			%cl.observerMode = "pregame";
			Client::setControlObject(%cl, Client::getObserverCamera(%cl));
			Observer::setOrbitObject(%cl, %pl, 3, 3, 3);
		}
		Game::playerSpawned(%pl, %cl, %armor, %respawn);
	}

	return ( true );
}


function Game::autoRespawn( %cl ) {
	if( %cl.dead == 1 )
		Game::playerSpawn( %cl, "true" );
}

function Game::pickPlayerSpawn( %cl, %respawn ) {
	return Game::pickTeamSpawn( Client::getTeam(%cl), %respawn );
}

function Game::initialMissionDrop( %cl ) {
	Client::setGuiMode( %cl, $GuiModePlay );

	if($Server::TourneyMode) {
		GameBase::setTeam( %cl, -1);
	} else {
		if( %cl.observerMode == "observerFly" || %cl.observerMode == "observerOrbit") {
			%cl.observerMode = "observerOrbit";
			%cl.guiLock = "";
			Observer::jump(%cl);
			return;
		}

		%numTeams = getNumTeams();
		%curTeam = Client::getTeam(%cl);

		if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
			Game::assignClientTeam(%cl);
	}

	Client::setControlObject(%cl, Client::getObserverCamera(%cl));
	%camSpawn = Game::pickObserverSpawn(%cl);
	Observer::setFlyMode(%cl, GameBase::getPosition(%camSpawn), 
	GameBase::getRotation(%camSpawn), true, true);

	if(Client::getTeam(%cl) == -1) {
		%cl.observerMode = "pickingTeam";

		if($Server::TourneyMode && ($matchStarted || $matchStarting)) {
			%cl.observerMode = "observerFly";
			return;
		} else if($Server::TourneyMode) {
			if($Server::TeamDamageScale)
				%td = "ENABLED";
			else
				%td = "DISABLED";
			message::bottomprint(%cl, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
		}

		Client::buildMenu(%cl, "Pick a team:", "InitialPickTeam");
		Client::addMenuItem(%cl, "0Observe", -2);
		Client::addMenuItem(%cl, "1Automatic", -1);

		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%cl, (%i+2) @ getTeamName(%i), %i);
		%cl.justConnected = "";
	} else {
		Client::setSkin(%cl, $Server::teamSkin[Client::getTeam(%cl)]);
		if(%cl.justConnected) {
			message::centerprint(%cl, $Server::JoinMOTD, 0);
			%cl.observerMode = "justJoined";
			%cl.justConnected = "";
		} else if (%cl.observerMode == "justJoined") {
			message::centerprint(%cl, "");
			%cl.observerMode = "";
			Game::playerSpawn(%cl, false);
		} else {
			Game::playerSpawn(%cl, false);
		}
	}

	if($TeamEnergy[Client::getTeam(%cl)] != "Infinite")
		$TeamEnergy[Client::getTeam(%cl)] += $InitialPlayerEnergy;
	%cl.teamEnergy = 0;
}

function processMenuInitialPickTeam(%cl, %team) {
	if ( $Server::TourneyMode && $matchStarted )
		%team = -2;

	if( %team == -2 ) {
		Observer::enterObserverMode(%cl);
	} else if ( %team == -1 ) {
		Game::assignClientTeam(%cl);
		%team = Client::getTeam(%cl);
	}
	
	if ( %team != -2 ) {
		GameBase::setTeam(%cl, %team);

		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
		%cl.teamEnergy = 0;
		Client::setControlObject(%cl, -1);
		Game::playerSpawn(%cl, false);
	}
	
	if( $Server::TourneyMode && !$CountdownStarted ) {
		if(%team != -2) {
			message::bottomprint(%cl, "<f1><jc>Press FIRE when ready.", 0);
			%cl.notready = true;
			%cl.notreadyCount = "";
		} else {
			message::bottomprint(%cl, "", 0);
			%cl.notready = "";
			%cl.notreadyCount = "";
		}
	}
}


function Game::onPlayerConnected( %cl ) {
	%cl.scoreKills = 0;
	%cl.scoreDeaths = 0;
	%cl.score = 0;
	%cl.justConnected = true;

	$menuMode[%cl] = "None";
	Game::refreshClientScore(%cl);
}

function Game::assignClientTeam( %cl ) {
	if ( !$teamplay ) {
		GameBase::setTeam( %cl, 0 );
		Event::Trigger( eventServerClientJoinTeam, %cl, 0 );
		return;
	}
	
	%name = Client::getName( %cl );
	
	%numTeams = getNumTeams();
	if ( $teamPreset[%name] != "" ) {
		if($teamPreset[%name] < %numTeams) {
			GameBase::setTeam( %cl , $teamPreset[%name] );
			Event::Trigger( eventServerClientJoinTeam, %cl, $teamPreset[%name] );
			echo(Client::getName( %cl ), " was preset to team ", $teamPreset[%name]);
			return;
		}
	}

	%numPlayers = getNumClients();
	for( %i = 0; %i < %numTeams; %i++ )
		%numTeamPlayers[%i] = 0;

	for( %i = 0; %i < %numPlayers; %i++ ) {
		%pl = getClientByIndex(%i);
		if ( %pl !=  %cl ) {
			%team = Client::getTeam(%pl);
			%numTeamPlayers[%team]++;
		}
	}
	
	%leastPlayers = %numTeamPlayers[0];
	%leastTeam = 0;
	for( %i = 1; %i < %numTeams; %i++ ) {
		if ( ( %numTeamPlayers[%i] < %leastPlayers ) || ( (%numTeamPlayers[%i] == %leastPlayers) && ($teamScore[%i] < $teamScore[%leastTeam] ) ) ) {
			%leastTeam = %i;
			%leastPlayers = %numTeamPlayers;
		}
	}
	
	GameBase::setTeam( %cl, %leastTeam );
	Event::Trigger( eventServerClientJoinTeam, %cl, %leastTeam );
	echo( Client::getName( %cl ), " was automatically assigned to team ", %leastTeam );
}

function Client::leaveGame(%cl)
{
   echo("GAME: clientdrop " @ %cl);
   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientDropped", %cl);
}

function Game::clientKilled(%playerId, %killerId)
{
   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientKilled", %playerId, %killerId);
}
