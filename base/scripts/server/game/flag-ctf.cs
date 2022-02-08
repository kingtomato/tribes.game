// 'Capture The Flag' flag code

$Flag::ReturnTime = 45;

function Flag::objectiveInit( %this ) {
	%this.originalPosition = GameBase::getPosition(%this);
	%this.atHome = true;
	%this.pickupSequence = 0;
	%this.carrier = -1;

	%this.enemyCaps = 0;
	%this.caps[0] = 0;
	%this.caps[1] = 0;
	%this.caps[2] = 0;
	%this.caps[3] = 0;
	%this.caps[4] = 0;
	%this.caps[5] = 0;
	%this.caps[6] = 0;
	%this.caps[7] = 0;

	$Team::Flag[ GameBase::getTeam(%this) ] = %this;

	return ( true );
}


function Flag::getObjectiveString( %this, %forTeam ) {
	%thisTeam = GameBase::getTeam(%this);

	if($missionComplete) {
		if(%thisTeam == %forTeam)
			return "<Bflag_atbase.png>\nYour flag was captured " @ %this.enemyCaps @ " times.";
		else
			return "<Bflag_enemycaptured.png>\nYour team captured the " @ getTeamName(%thisTeam) @ " flag " @ %this.caps[%forTeam] @ " times.";
		return;
	}

	if(%thisTeam == %forTeam) {
		if(%this.atHome)
			return "<Bflag_atbase.png>\nDefend your flag to prevent enemy captures.";
		else if(%this.carrier != -1)
			return "<Bflag_enemycaptured.png>\nReturn your flag to base. (carried by " @ String::escapeFormatting(Client::getName(Player::getClient(%this.carrier))) @ ")";
		else
			return "<Bflag_notatbase.png>\nReturn your flag to base. (dropped in the field)";
	} else {
		if(%this.atHome)
			return "<Bflag_enemycaptured.png>\nGrab the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
		else if(%this.carrier == -1)
			return "<Bflag_notatbase.png>\nFind the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
		else if(GameBase::getTeam(%this.carrier) == %forTeam)
			return "<Bflag_atbase.png>\nEscort friendly carrier " @ String::escapeFormatting(Client::getName(Player::getClient(%this.carrier))) @ " to base.";
		else
			return "<Bflag_enemycaptured.png>\nWaylay enemy carrier " @ String::escapeFormatting(Client::getName(Player::getClient(%this.carrier))) @ " and steal his flag.";
	}
}

function Flag::onDrop( %player, %type ) {
	%playerTeam = GameBase::getTeam(%player);
	%flag = %player.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	%cl = Player::getClient(%player);
	%name = Client::getName(%cl);
	
	Event::Trigger( eventServerFlagDropped, %cl, %flagTeam );

	message::allExcept( %cl, 0, %name @ " dropped the " @ getTeamName(%flagTeam) @ " flag!" );
	Client::sendMessage( %cl, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!" );
	message::teams( 1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field." );

	GameBase::throw(%flag, %player, 10, false);
	Flag::removeFromPlayer( %flag, %player, false );
	Item::hide(%flag, false);

	%flag.dropFade = 1;
	schedule( "Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $Flag::ReturnTime );
	
	ObjectiveMission::ObjectiveChanged(%flag);
}

function Flag::checkReturn( %flag, %sequenceNum ) {
	if( %flag.pickupSequence != %sequenceNum || %flag.timerOn != "" )
		return;
		
	if( %flag.dropFade ) { 
		GameBase::startFadeOut(%flag);
		%flag.dropFade = "";
		%flag.fadeOut = 1;
		schedule("Flag::checkReturn(" @ %flag @ ", " @ %sequenceNum @ ");", 2.5);
	} else {
		Event::Trigger( eventServerFlagReturned, 0, GameBase::getTeam(%flag) );
		Flag::Return( %flag, true );
	}
}


function Flag::onCollision( %this, %object ) {
	if( getObjectType(%object) != "Player" )
		return;

	// spurious collision?
	if( %this.carrier != -1 )
		return; 

	if ( Player::isAIControlled(%object) )
		return;   

	%name = Item::getItemData(%this);
	%playerTeam = GameBase::getTeam(%object);
	%flagTeam = GameBase::getTeam(%this);
	%cl = Player::getClient(%object);
	%touchClientName = Client::getName(%cl);

	if( %flagTeam == %playerTeam ) {
		// collision with our own flag

		if ( !%this.atHome ) {
			// return the flag
			message::allExcept(%cl, 0, %touchClientName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
			Client::sendMessage(%cl, 0, "You returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
			Event::Trigger( eventServerFlagReturned, %cl, GameBase::getTeam(%this), getSimTime() - %this.initialGrabTime );
			Flag::Return( %this, true );
			%this.pickupSequence++;
		} else {
			// cap the flag
			if ( %object.carryFlag == "" )
				return;

			Event::Trigger( eventServerFlagCaptured, %cl, GameBase::GetTeam( %object.carryFlag ) );
			
			message::allExcept(%cl, 0, %touchClientName @ " captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
			Client::sendMessage(%cl, 0, "You captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
			message::teams(1, %playerTeam, "Your team captured the flag.", %enemyTeam, "Your team's flag was captured.");

			%flag = %object.carryFlag;
			%flag.caps[%playerTeam]++;
			%flag.enemyCaps++;
			$teamScore[%playerTeam] += %flag.scoreValue;

			Flag::removeFromPlayer( %flag, %object, true );
			Flag::Return( %flag );

			%flag.trainingObjectiveComplete = true;
			ObjectiveMission::checkScoreLimit();
		}
	} else {
		if ( %object.vehicle != "" )
			return;
		
		// collision with enemy flag
		if(%object.outArea != "") {
			Client::sendMessage(%cl, 1, "Flag not in mission area.");
			return;
		}

		Player::setItemCount(%object, Flag, 1);
		Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
		Item::hide(%this, true);
		%fromField = !%this.atHome;
		if ( %this.atHome )
			%this.initialGrabTime = getSimTime();
		$flagAtHome[1] = false;
		%this.atHome = false;
		%this.carrier = %object;
		%this.pickupSequence++;
		%object.carryFlag = %this;
		Flag::setWaypoint(%cl, %this);
		
		if(%this.fadeOut) {
			GameBase::startFadeIn(%this);
			%this.fadeOut= "";
		}

		Event::Trigger( eventServerFlagTaken, %cl, %flagTeam, %fromField );

		message::allExcept(%cl, 0, %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
		Client::sendMessage(%cl, 0, "You took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
		message::teams(1, %playerTeam, "Your team has the " @ getTeamName(%flagTeam) @ " flag.", %flagTeam, "Your team's flag has been taken.");

		ObjectiveMission::ObjectiveChanged(%this);
	}
}

function Flag::clearWaypoint( %cl, %success ) {
	if ( %success )
		setCommandStatus( %cl, 0, "Objective completed.~wobjcomp");
	else
		setCommandStatus( %cl, 0, "Objective failed.");
}

function Flag::setWaypoint( %cl, %flag ) {
	if(!%cl.autoWaypoint)
		return;

	%flagTeam = GameBase::getTeam(%flag);
	%team = Client::getTeam(%cl);

	%pos = $Team::Flag[%team].originalPosition;
	%posX = getWord(%pos,0);
	%posY = getWord(%pos,1);

	issueCommand( %cl, %cl, 0, "Take the " @ getTeamName(%flagTeam) @ " flag to our flag.~wcapobj", %posX, %posY );
}

function FlagStand::objectiveInit( %this ) {
	return ( false );
}


function FlagStand::onCollision( %this, %object ) {
}

function Flag::clientDropped( %this, %clientId ) {
	%type = Player::getMountedItem( %clientId, $FlagSlot );
	if(%type != -1)
		Player::dropItem(%clientId, %type);
}

function Flag::playerLeaveMissionArea( %this, %player ) {
	if ( %this.carrier != %player )
		return;

	%this.atHome = true;
	%flagTeam = GameBase::getTeam(%this);
	
	%cl = Player::getClient(%player);
	if ( %cl != -1 ) {
		%name = Client::getName( %cl );
		
		message::allExcept(%cl, 0, %name @ " left the mission area while carrying the " @ getTeamName(%team) @ " flag!");
		Client::sendMessage(%cl, 0, "You left the mission area while carrying the " @ getTeamName(%team) @ " flag!");
		message::allExcept(%cl, 0, %name @ " left the mission area while carrying the " @ getTeamName(%team) @ " flag!");
	} else {
		message::allExcept(%cl, 0, "A non-player left the mission area while carrying the " @ getTeamName(%team) @ " flag!");
	}

	message::teams(1, %team, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(%team) @ " flag was returned to base.");

	Event::Trigger( eventServerFlagReturned, 0, %flagTeam );

	Flag::removeFromPlayer( %this, %player, false );
	Flag::Return( %this, true );	

	ObjectiveMission::checkScoreLimit();
}


function Flag::removeFromPlayer( %this, %player, %success ) {
	%this.carrier = -1;
	
	%player.carryFlag = "";
	Flag::clearWaypoint( Player::getClient( %player ), %success );
	Player::setItemCount( %player, "Flag", 0 );
}

function Flag::Return( %this, %announce ) {
	%team = GameBase::getTeam( %this );

	GameBase::setPosition( %this, %this.originalPosition );
	Item::hide( %this, false );
	Item::setVelocity( %this, "0 0 0" );
	GameBase::startFadeIn( %this );
	
	%this.atHome = true;
	%this.fadeOut = "";

	if ( %announce != "" )
		message::teams( 0, %team, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(%team) @ " flag was returned to base.~wflagreturn.wav" );
}





// REMOTES

function remoteFlagstandWaypoint( %cl, %team ) {
	if ( !$Team::Flag[%team] )
		return;

	%pos = $Team::Flag[%team].originalPosition;
	%posX = getWord(%pos,0);
	%posY = getWord(%pos,1);
	%side = ( Client::getTeam(%cl) == %team ) ? "FRIENDLY" : "ENEMY";

	issueCommand( %cl, %cl, 0, "Waypoint set to the " @ %side @ " flagstand", %posX, %posY );
}
