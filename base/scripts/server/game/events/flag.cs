Event::Attach( eventServerFlagDropped, ServerEvents::onFlagDropped );
Event::Attach( eventServerFlagReturned, ServerEvents::onFlagReturned );
Event::Attach( eventServerFlagCaptured, ServerEvents::onFlagCaptured );
Event::Attach( eventServerFlagTaken, ServerEvents::onFlagTaken );

Event::Attach( eventServerClientKilled, ServerEvents::onClientKilled_Flag );
Event::Attach( eventServerClientTeamKilled, ServerEvents::onClientKilled_Flag );

function ServerEvents::onFlagDropped( %cl, %flagteam ) {
	Stats::StatRPC( %cl, "FlagDrop", 1, %flagteam );
	Stats::TimeEvent( %cl, "flagtime", $Stats::NullState );
	Stats::TeamTimeEvent( %flagteam, "flagtime", "field" );
	StatLog::Push( FlagDrop, Stats::Identifier( %cl ), GameBase::getPosition( %cl ) );
}

function ServerEvents::onFlagReturned( %cl, %flagteam, %offstandtime ) {
	if ( %cl && ( %offstandtime >= $Scoring::StandoffReturnTime ) )
		Stats::StatRPC( %cl, "FlagStandoffReturn", 1, %flagteam );
	Stats::StatRPC( %cl, "FlagReturn", 1, %flagteam );
	L::Clear( "flag::holders" @ %flagteam );
	Stats::TeamTimeEvent( %flagteam, "flagtime", $Stats::NullState );
	StatLog::Push( FlagReturn, %cl ? Stats::Identifier( %cl ) : "", GameBase::getPosition( %cl ) );
}

function ServerEvents::onFlagTaken( %cl, %flagteam, %fromField ) {
	$ServerEvents::lastName[ %cl ] = Client::getName( %cl );
	Stats::StatRPC( %cl, %fromField ? "FlagPickup" : "FlagGrab", 1, %flagteam );
	Stats::TimeEvent( %cl, "flagtime", %flagteam );
	Stats::TeamTimeEvent( %flagteam, "flagtime", "player" );
	L::PushUnique( "flag::holders" @ %flagteam, %cl );
	StatLog::Push( %fromField ? FlagPickup : FlagGrab, %cl ? Stats::Identifier( %cl ) : "", GameBase::getPosition( %cl ) );
}

function ServerEvents::onFlagCaptured( %cl, %flagteam ) {
	Stats::StatRPC( %cl, "FlagCap", 1, %flagteam );
	
	%holderlist = "flag::holders" @ %flagteam;
	%name = Client::getName( %cl );
	L::Reset( %holderlist );
	while ( ( %cl2 = L::GetNext( %holderlist ) ) != "" ) {
		%assister = $Stack::Result[1];
		if ( Client::GetName( %cl2 ) != $ServerEvents::lastName[ %cl2 ] )  // they left the server
			continue;
		if ( %cl == %cl2 )
			continue;
		Stats::StatRPC( %cl2, "Assist", 1 );
	}
	L::Clear( "flag::holders" @ %flagteam );

	Stats::TimeEvent( %cl, "flagtime", $Stats::NullState );
	Stats::TeamEvent( Client::getTeam( %cl ), "score", 1 );
	Stats::TeamTimeEvent( %flagteam, "flagtime", $Stats::NullState );
	StatLog::Push( FlagCapture, Stats::Identifier( %cl ) );
}

function ServerEvents::onClientKilled_Flag( %killer, %victim, %damage ){
	%friendlyTeam = Client::getTeam( %killer );
	%enemyTeam = Client::getTeam( %victim );
	%friendlyFlag = $Team::Flag[ %friendlyTeam ];
	%enemyFlag = $Team::Flag[ %enemyTeam ];

	%killerPos = GameBase::getPosition( %killer );

	if ( !%friendlyFlag.atHome && ( %friendlyFlag.carrier == -1 ) ) {
		//  defending a dropped friendly flag in the field
		if ( Vector::getDistance( %killerPos, GameBase::getPosition( %friendlyFlag ) ) < 30 )
			Stats::StatRPC( %killer, "FlagDefense", 1 );
	}

	if ( %enemyFlag.carrier != -1 ) {
		// defending friendly carrier
		if ( Vector::getDistance( %killerPos, GameBase::getPosition( %enemyFlag.carrier ) ) < 30 )
			Stats::StatRPC( %killer, "FlagCarrierDefense", 1 );
		
		if ( %enemyFlag.carrier == Client::getOwnedObject( %victim ) )
			Stats::StatRPC( %killer, "FlagCarrierKill_Friendly", 1 );
	}

	// killing enemy carrier
	if ( %friendlyFlag.carrier == Client::getOwnedObject( %victim ) )
		Stats::StatRPC( %killer, "FlagCarrierKill", 1 );
}
