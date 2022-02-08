function Schedule::Add( %eval, %time, %tag ) {
	if ( %tag == "" )
		%tag = %eval;
	$Schedule::id[%tag]++;
	$Schedule::eval[%tag] = %eval;
	
	schedule( "Schedule::Exec(\""@String::Escape(%tag)@"\", "@$Schedule::ID[%tag]@");", %time );
}

function Schedule::Exec( %tag, %id ) {
	if ( $Schedule::ID[%tag] != %id )
		return;

	%eval = $Schedule::eval[%tag];
	Schedule::Cancel(%tag);
	eval(%eval);
}

function Schedule::Cancel( %tag ) {
	$Schedule::ID[%tag]++;
	$Schedule::eval[%tag] = "";
}

function Schedule::Check( %tag ) {
	return ( $Schedule::eval[%tag] != "" ) ? true : false;
}