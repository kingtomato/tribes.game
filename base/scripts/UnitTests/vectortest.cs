assert( "vector::add( '1 2 3', '4 5 6' )", "5 7 9" );
assert( "vector::sub( '1 2 3', '4 5 6' )", "-3 -3 -3" );
assert( "vector::dot( '1 2 3', '4 5 6' )", "32" );
assert( "vector::neg( '-1.2 2.3 3.4' )", "1.2 -2.3 -3.4" );
assert( "vector::getdistance( '1 2 3', '4 5 6' )", "5.196152" );
assert( "vector::normalize( '1 2 3' )", "0.267261 0.534522 0.801784" );
assert( "vector::getfromrot( '0.1 0.2 0.3' )", "-0.294044 0.950564 0.099833" );
assert( "vector::getrotation( '0.1 0.2 0.3' )", "-0.640522 0 -0.463648" );
