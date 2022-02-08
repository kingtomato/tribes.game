function switchfun( %var ) {
	%val = "0";
	switch ( %var ) {
		case 0: %val = "0 break"; %fakeout = "break shouldn't return"; break;
		case "3": { %val++; %val++; } %val++;
		case '2': %val += "2";
		default:
			switch ( %var ) {
				case 5: %val *= 3;
				case 2: { %val += %val; break; }
				default: %val += 100;
			}
	}
	return ( %val );
}

assert( "switchfun( 0 )", "0 break" );
assert( "switchfun( 1 )", "100" );
assert( "switchfun( 2 )", "4" );
assert( "switchfun( 3 )", "105" );
assert( "switchfun( 5 )", "0" );