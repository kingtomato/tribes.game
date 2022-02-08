rundir( "server/" );
run("command");
run("flood");
run("interiorlight");
run("messaging");
if ( !$MissionLighting )
	run("missionlist");

rundir( "server/admin/" );
run("actions");
run("admin");
run("banlist");
run("levels");
run("passwords");
run("serverpassword");
run("voting");

rundir( "server/log/" );
run("log");
run("iplog");

rundir( "server/menus/" );
run("admin");
run("changemission");
run("changeteams");
run("forceteamchange");
run("kick");
run("makeadmin");
run("menu");
run("nonself");
run("self");
run("servertoggles");
run("settimelimit");
run("stripadmin");
run("vote");
run("votepending");

rundir( "server/ai/" );
run("ai");

banlist::load( $Server::BanFile );
banlist::loadexclusions( $Server::ExlusionFile );