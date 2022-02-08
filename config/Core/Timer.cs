// time is stored internally x10 so we can inc/dec by 1 instead of 0.1 for precision
function Timer::New( %whole, %tenths ) {
	return ( %whole * 10 ) + %tenths;
}

// increment the timer by a tenth of a second
function Timer::Inc( %str ) {
	return ( %str + 1 );
}

// decrement the timer by a tenth of a second
function Timer::Dec( %str ) {
	return ( %str - 1 );
}

function Timer::FormatSeconds( %str ) {
	%len = String::len( %str );

	switch ( %len ) {
		// ex: 5, val = 00.5
		case 1: return ( "00." @ %str );
		// ex: 83, val = 08.3	
		case 2: return ( "0" @ string::char( %str, 0 ) @ "." @ string::char( %str, 1 ) );
		//ex: 225, val = 22.5
		default: return ( string::getSubStr( %str, 0, %len - 1 ) @ "." @ string::char( %str, %len - 1 ) );
	}
}