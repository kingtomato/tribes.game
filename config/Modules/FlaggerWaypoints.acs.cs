Event::Attach( eventFlagGrab, CarrierWaypoint::flagTaken );
Event::Attach( eventFlagPickup, CarrierWaypoint::flagTaken );

function CarrierWaypoint::Toggle() {
	if ($pref::CarrierAutoWaypoint == 0)
		remoteBP(2048, "<jc><f1>Waypoint AutoTarget set to: <f2>Manual<f1>.", 1);
	else if ($pref::CarrierAutoWaypoint == 1)
	{
		remoteBP(2048, "<jc><f1>Waypoint AutoTarget set to: <f2>Friendly<f1>.", 1);
		CarrierWaypoint::TargetFriendly();
	}
	else if ($pref::CarrierAutoWaypoint == 2)
	{
		remoteBP(2048, "<jc><f1>Waypoint AutoTarget set to: <f2>Enemy<f1>.", 1);
		CarrierWaypoint::TargetEnemy();
	}
}

function CarrierWaypoint::flagTaken( %team, %client ) {
	%friendlyCarrier = ( %team == Team::Enemy() );
	%enemyCarrier    = ( %team == Team::Friendly() );

	switch ( $pref::CarrierAutoWaypoint ) {
		case 1: if ( %friendlyCarrier ) CarrierWaypoint::TargetFriendly(); break;
		case 2: if ( %enemyCarrier ) CarrierWaypoint::TargetEnemy(); break;
	}
}

function CarrierWaypoint::TargetFriendly() {
	%cl = Team::Flag::Location(Team::Enemy());
	if( ( %cl == "home" ) || ( %cl == "field" ) || ( %cl == getManagerId() ) )
		return;

	remoteEval(2048, "IssueTargCommand", 0, "Escort: " @ Client::GetName( %cl ) @ "~wescfr", %cl - 2048, getManagerId());
}

function CarrierWaypoint::TargetEnemy() {
	%cl = Team::Flag::Location(Team::Friendly());
	if( ( %cl == "home" ) || ( %cl == "field" ) || ( %cl == getManagerId() ) )
		return;

	remoteEval( 2048, "IssueTargCommand", 0, "Attack: " @ Client::GetName( %cl ) @ "~wattway", %cl - 2048, getManagerId() );
}