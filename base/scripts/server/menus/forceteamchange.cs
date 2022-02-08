function menu::forceteamchange( %cl, %vic ) {
    %cl.ptc = %vic;
	
	menu::new( "Force Team Change", "forceteamchange", %cl );

    menu::add( "Observer", -2, %cl );
	if ( $Game::MissionType == "Rabbit" ) {
		menu::add( getTeamName(0), 0, %cl );
	} else {
		menu::add( "Automatic", -1, %cl );

		for( %i = 0; %i < getNumTeams(); %i++ )
			menu::add( getTeamName(%i), %i, %cl );
	}
}

function processMenuForceTeamChange( %cl, %team ) {
	%ptc = %cl.ptc;
    if( %cl.canChangePlyrTeam && %cl.adminlevel >= %ptc.adminLevel )
		processMenuChangeTeams( %ptc, %team, %cl );
    
    %cl.ptc = "";
}
