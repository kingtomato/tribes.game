function flood::getdelay( %cl, %type, %max, %floodtime ) {
	%time = ( getIntegerTime(true) >> 5 );
	%left = ( %cl.floodtime[%type] - %time );
	if ( %left > 0 )
		return ( %left );
	
	schedule( sprintf( "%1.floodcount[\"%2\"]--;", %cl, %type ), 5, %cl );
	if ( %cl.floodcount[%type]++ > %max ) {
		%cl.floodtime[%type] = ( %time + %floodtime );
		return ( %floodtime );
	}

	return ( 0 );
}