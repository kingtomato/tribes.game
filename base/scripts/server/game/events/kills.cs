Event::Attach( eventServerClientDied, ServerEvents::onClientDied );
Event::Attach( eventServerClientSuicided, ServerEvents::onClientSuicide );
Event::Attach( eventServerClientKilled, ServerEvents::onClientKilled );
Event::Attach( eventServerClientTeamKilled, ServerEvents::onClientTeamKilled );

function ServerEvents::onClientDied( %victim, %damage ) {
	Stats::StatRPC( %victim, "ClientDied", 1 );
	StatLog::Push( PlayerDeath, Stats::Identifier( %victim ) );
}

function ServerEvents::onClientSuicide( %victim, %damage ) {
	Stats::StatRPC( %victim, "Suicide", 1 );
	StatLog::Push( PlayerSuicide, Stats::Identifier( %victim ), GameBase::getPosition( %victim ) );
}

function ServerEvents::onClientKilled( %killer, %victim, %damage ) {
	%dmgdesc = ( %damage != "Team" ) ? Item::GetDamageDesc( %damage ) : "Team";
	Stats::KillDeathRPC( %killer, %victim, %dmgdesc );
	%k = Stats::Identifier( %killer ); 
	%kp = GameBase::getPosition( %killer );
	%v = Stats::Identifier( %victim );
	%vp = GameBase::getPosition( %victim );
	StatLog::Push( PlayerKill, %k, %kp, %dmgdesc, %v );
}

function ServerEvents::onClientTeamKilled( %killer, %victim, %damage ) {
	ServerEvents::onClientKilled( %killer, %victim, "Team" );
}

