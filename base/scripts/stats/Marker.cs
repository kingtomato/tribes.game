// common stats stuff

function Marker::AddTeam( %id, %name ) {
	$Marker::Team[%id] = %name;
	$Marker::Team[%name] = %id;
}

function Marker::Team( %nameorid ) {
	return ( $Marker::Team[ %nameorid ] );
}

// make the markers longer than an allowable name (16 characters)
$Marker::Player   = "                Player";
$Marker::Global   = "                Global";
$Marker::Home     = "                Home";
$Marker::Field    = "                Field";

Marker::AddTeam( -2, "                ?" );
Marker::AddTeam( -1, "                OBS" );
Marker::AddTeam(  0, "                BE" );
Marker::AddTeam(  1, "                DS" );
Marker::AddTeam(  2, "                CP" );
Marker::AddTeam(  3, "                SW" );

