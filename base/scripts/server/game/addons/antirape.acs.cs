Event::Attach( eventServerClientJoinTeam, AntiRape::Check );
Event::Attach( eventServerClientDisconnect, AntiRape::Check );
Event::Attach( eventServerMatchStarted, AntiRape::Check );

$AntiRape::MissionTypes["CTF"] = true;
$AntiRape::MissionTypes["CTFb"] = true;
$AntiRape::MissionTypes["CTF+"] = true;
$AntiRape::MissionTypes["Capture the Flag"] = true;
$AntiRape::MissionTypes["LT Maps"] = true;
$AntiRape::MissionTypes["Open Call"] = true;

function AntiRape::Check() {
	$Server::AllowRape = true;
	if( $Server::TourneyMode )
		return;

	if ( !$AntiRape::MissionTypes[ $Game::missionType ] )
		return;

	if ( !$Server::AntiRape )
		return;

	if ( Teams::size( 0 ) >= $Server::AntiRape::minTeamSize )
		return;
	
	if ( Teams::size( 1 ) >= $Server::AntiRape::minTeamSize )
		return;
	
	$Server::AllowRape = false;
}
