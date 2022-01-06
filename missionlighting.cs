$ConsoleWorld::DefaultSearchPath = ".;base\\scripts;base\\missions;base";

// load the base volumes
if(isFile("base\\darkstar.vol"))
	newObject( DarkstarVol, SimVolume, "base\\darkstar.vol" );
if(isFile( "base\\common.vol" ))
	newObject( CommonVol, SimVolume, "base\\common.vol" );
if(isFile( "base\\scripts.vol"))
   newObject( ScriptsVol, SimVolume, "base\\scripts.vol" );
if(isFile( "base\\entities.vol"))
   newObject( EntitiesVol, SimVolume, "base\\entities.vol" );
   
newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);

// load up all the dynamic data stuff
exec(admin);
exec(Marker);
exec(Trigger);
exec(NSound);
exec(BaseExpData);
exec(BaseDebrisData);
exec(BaseProjData);
exec(ArmorData);
exec(Mission);
exec(Item);
exec(Player);
exec(Vehicle);
exec(Turret);
exec(Beacon);
exec(StaticShape);
exec(Station);
exec(Moveable);
exec(Sensor);
exec(Mine);
exec(AI);
exec(InteriorLight);
preloadServerDataBlocks();
focusServer();
