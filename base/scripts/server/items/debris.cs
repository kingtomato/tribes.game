ExplosionData flashExpSmall
{
   shapeName = "flash_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpMedium
{
   shapeName = "flash_medium.dts";
   soundId   = debrisMediumExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.75;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpLarge
{
   shapeName = "flash_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};


ExplosionData debrisExpSmall
{
   shapeName = "tumult_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData debrisExpMedium
{
   shapeName = "tumult_medium.dts";
   soundId   = debrisMediumExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData debrisExpLarge
{
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};





DebrisData defaultDebrisSmall
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = debrisExpSmall;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData defaultDebrisMedium
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = debrisExpMedium;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData defaultDebrisLarge
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = debrisExpLarge;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData flashDebrisSmall
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = flashExpSmall;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData flashDebrisMedium
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = flashExpMedium;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData flashDebrisLarge
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = flashExpLarge;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData playerDebris
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

