// old ratings values
$OldRatings[ "ChaingunKill" ] = 25;
$OldRatings[ "PlasmaKill" ] = 15;
$OldRatings[ "DiscKill" ] = 25;
$OldRatings[ "ExplosiveKill" ] = 25;
$OldRatings[ "LaserKill" ] = 20;
$OldRatings[ "MortarKill" ] = 15;
$OldRatings[ "BlasterKill" ] = 5;
$OldRatings[ "ElfKill" ] = 25;
$OldRatings[ "ImpactKill" ] = 25;
$OldRatings[ "Suicide" ] = -5;
$OldRatings[ "TeamKill" ] = -5;
$OldRatings[ "CarrierKill" ] = 45;
$OldRatings[ "Grab" ] = 10;
$OldRatings[ "Pickup" ] = 10;
$OldRatings[ "Drops" ] = -5;
$OldRatings[ "Return" ] = 10;
$OldRatings[ "StandoffReturn" ] = 25;
$OldRatings[ "Assist" ] = 125;
$OldRatings[ "Cap" ] = 175;
$OldRatings[ "Death" ] = -2;
$OldRatings[ "MortarDeath" ] = -1;

function OldRatings::scoreEvent( %cl, %event ) {
	if ( String::findSubStr( %event, "Death" ) != -1 ) {
		if ( %event != "MortarDeath" )
			%event = "Death";
	}
	%value = $OldRatings[ %event ];
	if ( %value == "" )
		%value = 0;
	echof( "%1 = %2", %event, %value );
	ClientEvents::onClientScoreChange( %cl, %value, 1 );
}
