function blocks( %a, %b, %c ) {
	{
		{
			{ %a++; {}{}{} }
			{ %b++; {}{}{} }
		}
		{
			{ %c++; }
		}
	}
	
	{}{}{}{}
	
	switch ( %a + %b + %c ) {
		case 3: { {}{} return "wrong"; {} }
		case 6: {} { return "right"; }
		default: { return "what"; {} }
	}
}

assert( "blocks(0,1,2)", "right" );