function timestamp::zeropad( %s ) {
	return ( String::lpad( %s, 2, "0" ) );
}

function timestamp::array() {
	%t = timestamp();

	$time["yr"] = String::GetSubStr(%t, 00, 04);
	$time["mo"] = String::GetSubStr(%t, 05, 02);
	$time["dy"] = String::GetSubStr(%t, 08, 02);
	$time["hr"] = String::GetSubStr(%t, 11, 02);
	$time["mn"] = String::GetSubStr(%t, 14, 02);
	$time["sc"] = String::GetSubStr(%t, 17, 02);
	$time["ms"] = String::GetSubStr(%t, 20, 03);
}

function timestamp::format() {
	timestamp::array();
	
	%time = timestamp::zeropad( $time["hr"] ) @ ":" @ timestamp::zeropad( $time["mn"] );
	%date = $time["yr"] @ "-" @ timestamp::zeropad( $time["mo"] ) @ "-" @ timestamp::zeropad( $time["dy"] );
	return ( %date @ " " @ %time );
}

function time::getMinutes( %simTime ) {
	return floor( %simTime / 60 );
}

function Time::getSeconds( %simTime ) {
	return ( %simTime % 60 );
}