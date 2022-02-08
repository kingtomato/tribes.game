Stats::Reset( "base", getNumTeams() );

Stats::Register( "FlagCap", 5, "", "%1 recieves a %2 point capture bonus!" );
Stats::Register( "Kills", 1 );
Stats::Register( "KillsTeam", -1 );
Stats::Register( "Suicide", -1 );
Stats::Register( "TowerSwitch", 5, "You receive a %2 point bonus for holding your captured switch!" );

Stats::Register( "teamtime" );

$Scoring::MADistance = 6;