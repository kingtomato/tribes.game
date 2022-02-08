Event::Attach( eventServerClientDamaged, ServerEvents::onClientDamaged );

function Player::ObstructionsBelow( %pl, %distance ) {
	%armor = Player::getArmor( %pl );
	%pos = GameBase::getPosition( %pl );
	%height = "0 0 " @ -%armor.boxNormalHeight;
	while ( %distance > 0 ) {
		%pos = Vector::Add( %pos, %height );
		if ( !GameBase::testPosition( %pl, %pos ) )
			return ( true );
		%distance -= %armor.boxNormalHeight;
	}
	return ( false );
}

function ServerEvents::onClientDamaged( %victim, %damager, %type, %value ) {
	if ( ( %damager == %victim ) || ( %damager <= 0 ) )
		return;
	
	%playerVictim = Client::getOwnedObject( %victim );

	%weight = 1;
	%friendlyTeam = Client::getTeam( %damager );
	if ( %playerVictim.carryFlag )
		%weight *= 1.25; // 25% more points for damaging the carrier
	if ( Client::getTeam( %victim ) == %friendlyTeam )
		%weight *= -1; // friendly fire

	// Check for midair (only on enemy players)
	//if ( ( %weight >= 0 ) && $Damage::isRadiusDamage && ( $Explosion::impactId == %playerVictim ) ) {
	if ( $Damage::isRadiusDamage && ( $Explosion::impactId == %playerVictim ) ) {
		if ( ( %type == $PlasmaDamageType ) || ( %type == $DiscDamageType ) || ( %type == $MortarDamageType ) || ( %type == $RocketDamageType ) || ( %type == $GrenadeDamageType ) ) {
			if ( !Player::ObstructionsBelow( %playerVictim, $Scoring::MADistance ) ) {
				%damager.stats["midairs"]++;
				message::bottomprint_tagged( %damager, "<jc>You just scored a mid-air hit on <f1>%1", 2, %victim );
			}
		}
	}

	//Stats::StatRPC( %damager, "Damage", %value * %weight * ( $Scoring::KillLightValue / larmor.maxdamage ) );
	//Client::ScoreEvent( %damager, "damage", %value * %weight * ( $Scoring::KillLightValue / larmor.maxdamage ) );
}