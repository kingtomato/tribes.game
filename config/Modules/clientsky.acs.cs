//Skyrotation speed, set to 0 to disable this shitty plugin
$mj::skyrotationspeed = 1;


function mj::addSky(%mission, %dml, %skysize)
{
	$mj::ClientSky[%mission, dml] = %dml;
	$mj::ClientSky[%mission, size] = %skysize;
}


//Remove // to active Default sky for every map not defined by mj::addsky
//mj::addSky("Default","lushdayclear.dml",500);

//to add more skies just add more calls to mj::addSky() 
mj::addSky("Stonehenge","lushdayclear.dml",800);
mj::addSky("StonehengeLT","lushdayclear.dml",800);
mj::addSky("RaindanceLT","litesky.dml", 800);
mj::addSky("DangerousCrossingLT","litesky.dml",800);
mj::addSky("HildebrandLT","litesky.dml",700);


//Tribes adds the current world (lush/mars/alien etc) as ghosting object so if you try to set skies of different worlds it will fail, we need to load our worlds dynamically
//don't delete
$mj::skyToWorlds["aliensky_cloudyday.dml"] = "AlienWorld.zip";
$mj::skyToWorlds["alienight.dml"] = "AlienWorld.zip";
$mj::skyToWorlds["aliengreysky.dml"] = "AlienWorld.zip";

$mj::skyToWorlds["greysky.dml"] = "IceWorld.zip";
$mj::skyToWorlds["icenitesky.dml"] = "IceWorld.zip";

$mj::skyToWorlds["lushdayclear.dml"] = "LushWorld.zip";
$mj::skyToWorlds["litesky.dml"] = "LushWorld.zip";
$mj::skyToWorlds["lushsky_night.dml"] = "LushWorld.zip";

$mj::skyToWorlds["marsday.dml"] = "MarsWorld.zip";
$mj::skyToWorlds["marsdaycloud.dml"] = "MarsWorld.zip";
$mj::skyToWorlds["marsdusk.dml"] = "MarsWorld.zip";

$mj::skyToWorlds["mudsky_day.dml"] = "MudWorld.zip";
$mj::skyToWorlds["mudusk.dml"] = "MudWorld.zip";
$mj::skyToWorlds["mudcloudnight.dml"] = "MudWorld.zip";

$mj::skyToWorlds["deserttansky.dml"] = "DesertWorld.zip";
$mj::skyToWorlds["nitesky.dml"] = "DesertWorld.zip";


