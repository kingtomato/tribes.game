//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$ChaingunDamageType, 0]      = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$ChaingunDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$ChaingunDamageType, 2]      = "%1 fills %2 full of holes.";
$deathMsg[$ChaingunDamageType, 3]      = "%1 guns down %2.";
$deathMsg[$TurretDamageType, 0]      = "%2 dies of turret trauma.";
$deathMsg[$TurretDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$TurretDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$TurretDamageType, 3]      = "%2 ends up on the wrong side of a turret.";
$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";
$deathMsg[$DiscDamageType, 0]   = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$DiscDamageType, 1]   = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$DiscDamageType, 2]   = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$DiscDamageType, 3]   = "%2 falls victim to %1's Stormhammer.";
$deathMsg[$GrenadeDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$GrenadeDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$GrenadeDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$GrenadeDamageType, 3]    = "%2 never saw it coming from %1.";
$deathMsg[$LaserDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1]       = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$MortarDamageType, 0]      = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1's mortar takes out %2.";
$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]     = "%2 meets %1's master blaster.";
$deathMsg[$ELFDamageType, 0] = "%2 gets zapped with %1's ELF gun.";
$deathMsg[$ELFDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ELFDamageType, 2] = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ELFDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$CrushDamageType, 0]		 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]		 = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]		 = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]		 = "%2 gets caught in the machinery.";
$deathMsg[$DebrisDamageType, 0]		 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]		 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]		 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		 = "%2 got too close to the exploding stuff.";
$deathMsg[$RocketDamageType, 0]	    = "%2 takes a missile up the keister.";
$deathMsg[$RocketDamageType, 1]	    = "%2 gets shot down.";
$deathMsg[$RocketDamageType, 2]	    = "%2 gets real friendly with a rocket.";
$deathMsg[$RocketDamageType, 3]	    = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0]	       = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

function Client::getPronoun( %cl ) {
	if( !String::ICompare(Client::getGender(%cl), "Male") )
		return "his";
	else
		return "her";
}

function Client::onKilled( %victim, %killer, %damageType ) {
	echo( "GAME: kill " @ %killer @ " " @ %victim @ " " @ %damageType );
	
	%victim.guiLock = true;
	Client::setGuiMode( %victim, $GuiModePlay );

	%victimName = Client::getName( %victim );
	%victimGender = Client::getPronoun( %victim );
	%killerName = Client::getName( %killer );
	%killerGender = Client::getPronoun( %killer );
	
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	
	if ( !%killer ) {
		Event::Trigger( eventServerClientDied, %victim, %damageType );
		
		message::all( 0, %victimName ~ " dies.", $DeathMessageMask );
	} else if ( %killer == %victim ) {
		Event::Trigger( eventServerClientSuicided, %victim, %damageType );
		
		%msg = sprintf( $deathMsg[-2, %ridx], %victimName, %victimGender );
		message::all( 0, %msg, $DeathMessageMask );
	} else {
		if( $teamplay && (Client::getTeam(%killer) == Client::getTeam(%victim)) ) {
			Event::Trigger( eventServerClientTeamKilled, %killer, %victim, %damageType );
			
			if(%damageType != $MineDamageType)
				message::all(0, %killerName ~ " mows down " ~ %killerGender ~ " teammate, " ~ %victimName, $DeathMessageMask);
			else 
				message::all(0, %killerName ~ " killed " ~ %killerGender ~ " teammate, " ~ %victimName ~ " with a mine.", $DeathMessageMask);
		} else {
			Event::Trigger( eventServerClientKilled, %killer, %victim, %damageType );
			
			%msg = sprintf( $deathMsg[%damageType, %ridx], %killerName, %victimName, %killerGender, %victimGender );
			message::all( 0, %msg, $DeathMessageMask );
		}
	}

	Game::clientKilled( %victim, %killer );
}
