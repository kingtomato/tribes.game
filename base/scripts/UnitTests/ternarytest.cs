assert( "( 5 > 2 ) ? 3 : 2", "3" );
assert( "( 5 < 2 ) ? 3 : 2", "2" );
assert( "1 < 2 ? 3 : 4", "3" );
assert( "( floor( 5.2 ) > 2 ) ? ( 3 * 7 ) : 2", "21" );
assert( "( 3838 < 33 ) ? 23525 : ( 8753 < 235235 ) ? 'nested' : 'broken'", "nested" );
