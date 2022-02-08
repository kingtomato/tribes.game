function unifyDamageTypes( %damageType ) {
	switch ( %damageType ) {
		case "Grenade":
		case "Mine":
			%damageType = "Explosive";
	}
	
	return ( %damageType );
}

function ClientEvents::onClientDied( %victim ) {
	Event::Trigger( eventClientDied, %victim );
}

function ClientEvents::onSuicide( %victim, %damageType ) {
	Event::Trigger( eventClientSuicided, %victim );
	Event::Trigger( eventClientDied, %victim );
}

function ClientEvents::onClientKilled( %killer, %victim, %damageType ) {
	%damageType = unifyDamageTypes( %damageType );
	if ( %damageType == "Team" )
		Event::Trigger( eventClientTeamKilled, %killer, %victim );
	else
		Event::Trigger( eventClientKilled, %killer, %victim, %damageType );
	Event::Trigger( eventClientDied, %victim );
}
