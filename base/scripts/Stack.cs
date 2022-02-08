function Stack::Push( %var, %item0, %item1, %item2 ) {
	if ( $Stack[%var, count] == "" )
		$Stack[%var, count] = 0;

	%idx = $Stack[%var, count];
	for ( %i = 0; %item[%i] != ""; %i++ ) {
		$Stack[ %var, %idx, %i ] = %item[%i];
		$Stack[ %var, has, %item[%i] ]++;
	}

	if ( %item[0] != "" )
		$Stack[%var, count]++;
}

function Stack::PushUnique( %var, %item ) {
	%exists = Stack::Find(%var, %item);
	if ( !%exists )
		Stack::Push( %var, %item );
	return %exists;
}

function Stack::Pop( %var ) {
	%result = "";
	
	%cnt = $Stack[%var, count];
	if ( %cnt ) {
		for( %items = 0; true; %items++ ) {
			%item = $Stack[%var, %cnt - 1, %items];
			if ( %item == "" )
				break;
			$Stack[%var, has, %item]--;
		}
		%result = $Stack[%var, %cnt - 1, 0];
		$Stack[%var, count]--;
	}

	return ( %result );
}

function Stack::Clear( %var ) {
	deleteVariables( "$Stack" @ %var @ "*" );
	$Stack[%var, count] = 0;
	$Stack[%var, idx] = 0;
}


function Stack::Reset( %var ) {
	$Stack[%var, idx] = 0;
}

function Stack::Freeze( %var ) {
	Stack::Push( %var @ "freezeidx", $Stack[%var, idx] );
}

function Stack::Unfreeze( %var ) {
	if ( Stack::Count( %var @ "freezeidx" ) > 0 )
		$Stack[%var, idx] = Stack::Pop( %var @ "freezeidx" );
}

function Stack::GetFirst( %var ) {
	%result = "";
	$Stack::Result = "";

	if ( $Stack[%var, count] <= 0 )
		return ( %result );

	for ( %i = 0; $Stack[%var, 0, %i] != ""; %i++ )
		$Stack::Result[%i] = $Stack[%var, 0, %i];
	$Stack::Result = true;

	return ( $Stack[ %var, 0, 0 ] );
}

function Stack::GetNext( %var ) {
	if ( $Stack[%var, idx] == "" )
		$Stack[%var, idx] = 0;

	%result = "";
	$Stack::Result = "";

	if ( $Stack[%var, idx] >= $Stack[%var, count] )
		return ( %result );

	%idx = $Stack[%var, idx];
	for ( %i = 0; $Stack[%var, %idx, %i] != ""; %i++ )
		$Stack::Result[%i] = $Stack[%var, %idx, %i];
	$Stack[%var, idx]++;
	$Stack::Result = true;

	return ( $Stack[ %var, %idx, 0 ] );
}

function Stack::Find( %var, %search ) {
	return ( $Stack[ %var, has, %search ] > 0 );
}

function Stack::Count( %var ) {
	return ( $Stack[%var, count] );
}

function Stack::Exist( %var ) {
	return ( $Stack[%var, count] != "" );
}

function Stack::Test() {
	stack::clear("test");
	stack::push("test", 1);
	stack::push("test", 2);
	stack::push("test", 3);
	
	stack::reset("test");
	echo(stack::getnext("test"));
	echo(stack::getnext("test"));
	echo(stack::getnext("test"));
	echo(stack::find("test", 1));
	echo(stack::find("test", 4));
}
