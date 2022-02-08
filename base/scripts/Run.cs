$rundir = "";
function rundir( %dir ) {
	$rundir = %dir;
}

function run( %file ) {
	exec( $rundir @ %file );
}
