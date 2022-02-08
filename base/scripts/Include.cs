function include::Reset() {
	deleteVariables( "$Included*" );
}

function include( %file, %force ) {
	if ( String::findSubStr(%file, ".cs") == -1 )
		%file = %file @ ".cs";

	%executed = false;
	if ( %force || ( !$Included[%file] ) ) {
		%executed = exec(%file);

		if ( %executed )
			$Included[%file]++;
	}

	return ( %executed );
}