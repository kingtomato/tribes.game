Stats::Reset( "basectf", getNumTeams() );

function registerKillDeath( %type, %weight ) {
	Stats::RegisterSubType( "Kills", %type, %weight );
	Stats::RegisterSubType( "Deaths", %type, ( %type == "Team" ) ? 0 : -5 );
}

Stats::Register( "FlagReturn", 10 );
Stats::Register( "FlagStandoffReturn", 25 );
Stats::Register( "FlagGrab", 10 );
Stats::Register( "FlagPickup", 10 );
Stats::Register( "FlagDrop", -5 );
Stats::Register( "FlagCap", 175, "", "%1 recieves a %2 point capture bonus!" );
Stats::Register( "FlagAssist", 125 );

registerKillDeath( "Team", -5 );
registerKillDeath( "Chaingun", 25 );
registerKillDeath( "Blaster", 15 );
registerKillDeath( "ELF", 5 );
registerKillDeath( "Plasma", 20 );
registerKillDeath( "Disc", 25 );
registerKillDeath( "Mine", 20 );
registerKillDeath( "Grenade", 20 );
registerKillDeath( "Laser", 25 );
registerKillDeath( "Mortar", 20 );
registerKillDeath( "Turret", 20 );

Stats::Register( "ClientDied", 0 );
Stats::Register( "Suicide", -5 );

Stats::Register( "FlagCarrierKill", 45 );

Stats::Register( "flagtime" );
Stats::Register( "teamtime" );

Stats::RegisterTeam( "score" );
Stats::RegisterTeam( "flagtime" ); // need to track team time for flag seperately



$Scoring::MADistance = 6;
$Scoring::StandoffReturnTime = 90;