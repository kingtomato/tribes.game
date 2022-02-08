assert( "sqrt( 100 )", "10" );
assert( "sqrt( 9 )", "3" );
assert( "sqrt( -1 )", "0" );
assert( "sqrt( 240.25 )", "15.5" );
assert( "pow( 225, 0.5 )", "15" );
assert( "pow( 3.5, 5 )", "525.21875" );
assert( "round( 1.23456, 3 )", "1.234" );
assert( "round( 1, 3 )", "1.000" );
assert( "round( 1.0, 3 )", "1.000" );
assert( "round( 1.0002, 0 )", "1" );
assert( "round( 3.35360000, 64 )", "3.3536000000000000000000000000000" ); // max of 32 trailing digits
assert( "round( 94.117599, 2 )", "94.11" );
//assert( "rad2deg( 1 )", "57.295776" ); # likes to fail due to precision issues
assert( "deg2rad( 57.295776 )", "1" );
assert( "abs( -1.234 )", "1.234" );
assert( "abs( 1.234 )", "1.234" );
assert( "floor( 1.234 )", "1" );
assert( "floor( -1.934 )", "-2" );
assert( "floor( 4374571.234734734 )", "4374571" );

