Event::Attach( eventServerClientJoinTeam, Teams::onClientJoinTeam );
Event::Attach( eventServerClientConnect, Teams::onClientConnect );
Event::Attach( eventServerClientDisconnect, Teams::onClientDisconnect );

function Teams::onClientJoinTeam( %cl, %team ) {
	if ( %cl.oldTeam != "" ) {
		$Server::TeamList[ $Server::teamLastClient[ %cl.oldTeam ] ] = $Server::TeamList[ %cl ];
		$Server::TeamList[ %cl.oldTeam ]--;
	}
	$Server::TeamList[ %team ]++;
	%cl.oldTeam = %team;
	$Server::TeamList[ $Server::teamLastClient[ %team ] ] = %cl;
	$Server::teamLastClient[ %team ] = %cl;
}

function Teams::onClientConnect( %cl ) {
}

function Teams::onClientDisconnect( %cl ) {
	$Server::TeamList[ %cl.oldTeam ]--;
}

function Teams::size( %team ) {
	return ( $Server::TeamList[ %team ] + 0 );
}


// $Server::Teams* was deleting the teamskins
deleteVariables( "$Server::TeamList*" );