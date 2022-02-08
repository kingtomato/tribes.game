function Autoload( %wild ) {
	%items = 0;
	%file = File::findFirst( %wild );
	while( %file != "" ) {
		if( String::right( %file, 3 ) == ".cs" ) {
			if ( %ran[%file] )
				break;
			%ran[%file] = true;
			%list[%items] = %file;
			%items++;
		}

		%file = File::findNext( %wild );
	}

	for ( %i = 0; %i < %items; %i++ )
		exec( %list[%i] );
}