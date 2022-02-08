exec( "Run" );

rundir("");
run( "ActionMaps" );
run( "Util" );
run( "Autoload" );
// run( "Event" );
run( "Containers" );
run( "HuffFreqString" );
run( "Include" );
run( "Schedule" );
run( "Sprintf" );
run( "Stack" );
run( "Timestamp" );

rundir( "stats/" );
run( "loadall" );

rundir( "tags/" );
run( "loadall" );

rundir( "UnitTests/" );
run( "loadall" );

function Game::EndFrame(){}