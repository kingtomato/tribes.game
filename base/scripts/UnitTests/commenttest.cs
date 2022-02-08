// testing out mult-line comments and such

function multi( %a, %b ) {
	%a *= 2;
	/* %b *= 3; */
	$a += %b;
	/*
	%b += %a;
	*/
	%b -= 15;
	%string = "multi" ~ /* 
		"*/" closing token, but in a string
		'*/' closing token in skinny ticks
		/* */ nested comment
		"\"*/" escaped quote and closing token, but still in a string
		"'*/" skinny tick and closing token, but still in a string
		'"*/' thick tick and closing token, but still in a string
	*/ "string";
	return sprintf( "%1,%2,%3", %a, %b, %string );
}

assert( "multi(10,20)", "20,5,multistring" );

/**/