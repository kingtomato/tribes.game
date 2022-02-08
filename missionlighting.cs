$ConsoleWorld::DefaultSearchPath = ".;base/scripts;base/missions;base";

// load the base volumes
newObject( DarkstarVol, SimVolume, "base/darkstar.vol" );
newObject( CommonVol, SimVolume, "base/common.vol" );
newObject( ScriptsVol, SimVolume, "base/scripts.vol" );
newObject( EntitiesVol, SimVolume, "base/entities.vol" );
newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);

// load up all the dynamic data stuff
exec( "common" );
exec( "server/loadall" );
exec( "sound/nsound" );
exec( "server/items/loadall" );

preloadServerDataBlocks();
focusServer();