function adminlevel::reset() {
	deletevariables( "$admin::level*" );
	$admin::levels = 0;
	$admin::levelpermissions = 0;
	$admin::levelname[ "" ] = "(Undefined)";
	$admin::level[ "" ] = "(Undefined)";
}

function adminlevel::add( %desc ) {
	$admin::level[ %desc ] = $admin::levels;
	$admin::levelname[ $admin::levels ] = %desc;
	$admin::levels++;
}

function adminlevel::get( %levelname ) {
	return ( $admin::level[ %levelname ] );
}

function adminlevel::getname( %level ) {
	if ( %level < 0 || %level >= $admin::levels )
		return "(Undefined)";
	return ( $admin::levelname[ %level ] );
}

function adminlevel::addpermission( %name, %levelname ) {
	$admin::levelpermissions[ %name ] = adminlevel::get( %levelname );
	
	$admin::levelpermissionlist[ $admin::levelpermissions ] = %name;
	$admin::levelpermissions++;
}

function adminlevel::access( %cl, %name ) {
	return ( $admin::levelpermissions[ %name ] <= %cl.adminLevel );
}

function adminlevel::grant( %cl, %level ) {
	if ( %level >= $admin::levels )
		%level = ( $admin::levels - 1 );
	if ( %level < 0 )
		%level = 0;

	%cl.adminLevel = ( %level );
	%cl.isAdmin = ( %level > 0 );
	
	for ( %i = 0; %i < $admin::levelpermissions; %i++ ) {
		%name = $admin::levelpermissionlist[%i];
		eval( %cl @ "." @ %name @ " = " @ adminlevel::access( %cl, %name ) @ ";" );
	}
}

exec( "Server/adminlevels" );

