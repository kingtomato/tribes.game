$Server::teamName[0] = "Blood Eagle";
$Server::teamSkin[0] = "beagle";
$Server::teamName[1] = "Diamond Sword";
$Server::teamSkin[1] = "dsword";
$Server::teamName[2] = "Children of the Phoenix";
$Server::teamSkin[2] = "cphoenix";
$Server::teamName[3] = "Starwolf";
$Server::teamSkin[3] = "swolf";
$Server::teamName[4] = "Generic 1";
$Server::teamSkin[4] = "base";
$Server::teamName[5] = "Generic 2";
$Server::teamSkin[5] = "base";
$Server::teamName[6] = "Generic 3";
$Server::teamSkin[6] = "base";
$Server::teamName[7] = "Generic 4";
$Server::teamSkin[7] = "base";

$Server::HostName = "TRIBES Server";
$Server::MaxPlayers = "8";
$Server::HostPublicGame = true;
$Server::AutoAssignTeams = true;
$Server::Port = "28001";

$Server::timeLimit = 25;
$Server::warmupTime = 20;

if($pref::lastMission == "")
   $pref::lastMission = Raindance;

$Server::MinVoteTime = 45;
$Server::VotingTime = 20;
$Server::VoteWinMargin = 0.50;
$Server::VoteAdminWinMargin = 0.60;
$Server::MinVotes = 1;
$Server::MinVotesPct = 0.5;
$Server::VoteFailTime = 30; // 30 seconds if your vote fails + $Server::MinVoteTime

$Server::TourneyMode = false;
$Server::TeamDamageScale = 1;

$Server::Info = "Default TRIBES server setup\nAdmin: Unknown\nEmail: Unknown";
$Server::JoinMOTD = "<jc><f1>Message of the Day:\nWelcome to TRIBES!\n\nFire to spawn.";

$Server::MasterAddressN0 = "master.pax.playtribes.com:28000 masterserver.playtribes.com:26000 216.250.231.198:28000";
$Server::MasterName0 = "US Tribes Master";
$Server::CurrentMaster = 0;

$Server::respawnTime = 2; // number of seconds before a respawn is allowed

$Server::LogFile = "ServerLog.cs";
$Server::BanFile = "Server/Bans.cs";
$Server::ExclusionFile = "Server/Exclusions.cs";
$Server::BanTime = "300";
$Server::KickTime = "150";
$Server::PermaBanMessage = "You were permanently banned";

$Server::LogMissionChange = true;
$Server::LogTeamDamage = false;
$Server::LogKickBan = true;
$Server::LogModeChange = false;
$Server::LogAdmins = true;
$Server::LogPickups = false;
$Server::LogServerPasswords = true;
$Server::LogTimeChanges = false;

$Server::AntiRape::minTeamSize = 8;
$Server::AntiRape = true;
$Server::NoRepair = false;
$Server::PickupMode = false;