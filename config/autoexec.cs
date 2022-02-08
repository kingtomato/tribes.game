Autoload( "Core/*.cs" ); 
Autoload( "Modules/*.acs.cs" );
$mj::DrawWeapon = 1;
$mj::WeaponAlpha = 0.5;
$Server::warmupTime = 5;
$Server::respawnTime = 0;

function Binds::GameBinds::Init()
  after GameBinds::Init
{
	$GameBinds::CurrentMapHandle = GameBinds::GetActionMap2( "actionMap.sae");
	$GameBinds::CurrentMap = "actionMap.sae";
	GameBinds::addBindCommand( "VFF", "say(1, \"l\x03\x03\x03\x03\x03\x03l GET THE FLAG l\x03\x03\x03\x03\x03\x03l~wgeteflg\");");
	GameBinds::addBindCommand( "VFR", "say(1, \"l\x03\x03\x03\x03\x03\x03l RETURN THE FLAG l\x03\x03\x03\x03\x03\x03l~wretflag\");");
	GameBinds::addBindCommand( "S-W", "say(1, \"l\x03\x03\x03\x03\x03\x03l SOUTH-WEST l\x03\x03\x03\x03\x03\x03l~wincom2\");");
        GameBinds::addBindCommand( "SOUTH", "say(1, \"l\x03\x03\x03\x03\x03\x03l SOUTH l\x03\x03\x03\x03\x03\x03l~wincom2\");");
        GameBinds::addBindCommand( "S-E", "say(1, \"l\x03\x03\x03\x03\x03\x03l SOUTH-EAST l\x03\x03\x03\x03\x03\x03l~wincom2\");");
        GameBinds::addBindCommand( "WEST", "say(1, \"l\x03\x03\x03\x03\x03\x03l WEST l\x03\x03\x03\x03\x03\x03l~wincom2\");");
        GameBinds::addBindCommand( "CAMP", "say(1, \"l\x03\x03\x03\x03\x03\x03l CAMP l\x03\x03\x03\x03\x03\x03l~wincom2\");");
        GameBinds::addBindCommand( "EAST", "say(1, \"l\x03\x03\x03\x03\x03\x03l EAST l\x03\x03\x03\x03\x03\x03l~wincom2\");");
        GameBinds::addBindCommand( "N-W", "say(1, \"l\x03\x03\x03\x03\x03\x03l NORTH-WEST l\x03\x03\x03\x03\x03\x03l~wincom2\");");
        GameBinds::addBindCommand( "NORTH", "say(1, \"l\x03\x03\x03\x03\x03\x03l NORTH l\x03\x03\x03\x03\x03\x03l~wincom2\");");
        GameBinds::addBindCommand( "N-E", "say(1, \"l\x03\x03\x03\x03\x03\x03l NORTH-EAST l\x03\x03\x03\x03\x03\x03l~wincom2\");");
}
