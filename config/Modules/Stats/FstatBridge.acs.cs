function remoteFlagTrackUpdate( %sv, %flag, %flagId, %cl, %clientteam, %type ) {
	switch ( %type ) {
		case "GRAB": remoteFlagTaken( 2048, %flagId, %cl ); break;
		case "DROP": remoteFlagDropped( 2048, %flagId, %cl ); break;
		case "CAPTURE": remoteFlagCap( 2048, %flagId, %cl ); break;
		case "RETURN":
		case "LEFT":
		case "TIMEOUT": remoteFlagReturn( 2048, %flagId, %cl ); break;
	}
}


function remoteCountDown( %sv, %count ) {
	if( %count == 0 )
		Event::Trigger(eventMatchStarted);
}

function remoteReceiveMessage( %client, %count, %item, %itemId ) {
	Event::Trigger( EventItemReceived, %item, %count );
}


$Fstat::DamageType = "Suicide";
$Fstat::DamageType[-1] = "Impact";
$Fstat::DamageType[0] = "Suicide";
$Fstat::DamageType[1] = "Chaingun";
$Fstat::DamageType[2] = "Turret";
$Fstat::DamageType[3] = "Plasma";
$Fstat::DamageType[4] = "Disc";
$Fstat::DamageType[5] = "Explosive";
$Fstat::DamageType[6] = "Laser";
$Fstat::DamageType[7] = "Mortar";
$Fstat::DamageType[8] = "Blaster";
$Fstat::DamageType[9] = "ELF";
$Fstat::DamageType[10] = "Crushed";
$Fstat::DamageType[11] = "Debris";
$Fstat::DamageType[12] = "Missile";
$Fstat::DamageType[13] = "Explosives";

function remoteKillUpdate( %sv, %victim, %killer, %weapon ) {
	%weapon = $Fstat::DamageType[ %weapon ];
	remoteKillTrak( 2048, %killer, %victim, %weapon );
}