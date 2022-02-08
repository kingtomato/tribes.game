// GreyHound (Hunden)
/*
Default autoload sucks since it fails for directories
*/

function Autoload( %wild )
{
	%file = File::findFirst( %wild );
	while( %file != "" ) {
		if( String::right( %file, 3 ) == ".cs" ) {
			if ( $Autoload::ran[%file] )
			{
				%file = File::findNext( %wild );
				continue;
			}
			$Autoload::ran[%file] = true;
			exec( %file );
		}
		%file = File::findNext( %wild );
	}
}

function Autoload::reset()
{
	deletevariables("Autoload::ran");
}