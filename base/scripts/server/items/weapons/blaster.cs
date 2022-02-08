$weapon = "Blaster";
$AutoUse[$weapon] = false;
$WeaponAmmo[$weapon] = "";
Item::AddWeaponToSwitchCycle( $weapon );
Item::AddDamageType( "Blaster" );

ExplosionData blasterExp
{
   shapeName = "shotgunex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 0.25, 0.25 };
   colors[1]  = { 1.0, 0.25, 0.25 };
   colors[2]  = { 1.0, 0.25, 0.25 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

//--------------------------------------
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.125;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};



//----------------------------------------------------------------------------

ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "bWeapons";
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};
