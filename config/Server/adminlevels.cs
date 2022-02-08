adminlevel::reset();

adminlevel::add( "Player" );
adminlevel::add( "Public Admin" );
adminlevel::add( "General Admin" );
adminlevel::add( "Super Admin" );
adminlevel::add( "Ultra Admin" );
adminlevel::add( "Owner Admin" );

adminlevel::addpermission( canChangeGameMode,           "Public Admin" );
adminlevel::addpermission( canChangeMission,            "Public Admin" );
adminlevel::addpermission( canChangePlyrTeam,           "Public Admin" );
adminlevel::addpermission( canEZConsoleShowsAsAdmin,    "Public Admin" );
adminlevel::addpermission( canForceMatchStart,          "Public Admin" );
adminlevel::addpermission( canKick,                     "Public Admin" );
adminlevel::addpermission( canSwitchTeamDamage,         "Public Admin" );

adminlevel::addpermission( canAnnounceTakeover,         "General Admin" );
adminlevel::addpermission( canBan,                      "General Admin" );
adminlevel::addpermission( canCancelVote,               "General Admin" );
adminlevel::addpermission( canChangeTimeLimit,          "General Admin" );
adminlevel::addpermission( canMakeAdmin,                "General Admin" );
adminlevel::addpermission( canBroadcast,                "General Admin" );
adminlevel::addpermission( canSetPassword,              "General Admin" );
adminlevel::addpermission( canPickupMode,               "General Admin" );

adminlevel::addpermission( canMute,                     "Super Admin" );
adminlevel::addpermission( canReceiveAlerts,            "Super Admin" );
adminlevel::addpermission( canSeePlayerSpecs,           "Super Admin" );
adminlevel::addpermission( canSendWarning,              "Super Admin" );

adminlevel::addpermission( canPermanentBan,             "Ultra Admin" );
adminlevel::addpermission( canResetServer,              "Ultra Admin" );
adminlevel::addpermission( canSeePlayerlist,            "Ultra Admin" );

adminlevel::addpermission( canAntiRape,                 "Owner Admin" );
adminlevel::addpermission( canAntiRepair,               "Owner Admin" );
adminlevel::addpermission( canStripAdmin,               "Owner Admin" );
adminlevel::addpermission( canSetTeamInfo,              "Owner Admin" );
