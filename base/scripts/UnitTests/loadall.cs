function assert( %expr, %answer ) {
	$unittest::tests++;
	$console::logbufferenabled = false; // keep any errors/etc from echoing
	evalf( "$assert = (%1);", %expr );
	$console::logbufferenabled = true;
	if ( $assert != %answer ) {
		$unittest::errors[ $unittest::errors++ - 1 ] = sprintf( "[%1]: EXPR [%2] RESULT[%3] EXPECT[%4]",
			$unittest::type, %expr, $assert, %answer );
	} else {
		$unittest::ok++;
	}
}

function unittests::runtest( %test ) {
	$unittest::type = %test;
	$unittest::tests++;
	if ( execf( "unittests/%1test", %test ) == "syntax error" )
		$unittest::errors[ $unittest::errors++ - 1 ] = sprintf( "[%1]: %1test failed to load!", %test );
	else
		$unittest::ok++;
}

function unittests::run() {
	$unittest::ok = 0;
	$unittest::errors = 0;
	$unittest::tests = 0;
	
	unittests::runtest( "math" );
	unittests::runtest( "string" );
	unittests::runtest( "vector" );
	unittests::runtest( "switch" );
	unittests::runtest( "ternary" );
	unittests::runtest( "deref" );
	unittests::runtest( "varcat" );
	unittests::runtest( "attach" );
	unittests::runtest( "event" );
	unittests::runtest( "block" );
	unittests::runtest( "comment" );
	unittests::stats();
}

function unittests::stats() {
	echo( "--- UNIT TEST STATS ---" );
	if ( $unittest::tests ) {
		echof( " * Successfull Tests: %1 (%2%%)", $unittest::ok, round( $unittest::ok / $unittest::tests * 100, 2 ) );
		echo( " * Failed Tests: " @ $unittest::errors );
		if ( $unittest::errors ) {
			for ( %i = 0; %i < $unittest::errors; %i++ )
				echo( $unittest::errors[ %i ] );
		}
	} else {
		echo( " * No tests run!" );
	}
}