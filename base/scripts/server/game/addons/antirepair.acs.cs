Event::Attach( eventServerMatchStarted, AntiRepair::Check );

$AntiRepair::Items["IndoorTurret"] = true;
$AntiRepair::Items["RocketTurret"] = true;

function AntiRepair::Check() {
	$Server::allowRepair = true;
	if ( !$Server::TourneyMode )
		$Server::allowRepair = !$Server::NoRepair;
}