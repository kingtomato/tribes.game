// Single item container

function C::Clear( %prefix ) {
	deleteVariables( "$C::Amount" @ %prefix @ "*" );
}

function C::Set( %event, %state ) {
	$C::Amount[ %event ] = %state;
}

function C::Get( %event ) {
	return $C::Amount[ %event ];
}

function C::Inc( %event, %amt ) {
	echof( "Incrementing %1 by %2", %event, %amt );
	$C::Amount[ %event ] += %amt;
}


// Time Container which accumulates the duration of various states of an event

function TimeC::Clear( %prefix ) {
	C::Clear( %prefix );
	deleteVariables( "$TimeC::State" @ %prefix @ "*" );
}

function TimeC::Update( %event, %state ) {
	%now = getSimTime();
	
	echof( "%1: %2", %event, $TimeC::State[ %event ] );
	if ( $TimeC::State[ %event ] != "" ) {
		%oldstate = $TimeC::State[ %event ];
		%duration = ( %now - $TimeC::State[ %event, "time" ] );
		C::Inc( %event @ %oldstate, %duration );
	}

	$TimeC::State[ %event ] = %state;
	$TimeC::State[ %event, "time" ] = %now;

	return %oldstate;
}

function TimeC::Get( %event ) {
	return $TimeC::State[ %event ];
}

function TimeC::GetTime( %event ) {
	return $TimeC::State[ %event, "time" ];
}

function TimeC::Duration( %event, %state ) {
	return C::Get( %event @ %state );
}



// List container tracks lists of items

function L::Count( %list ) {
	return Stack::Count( %list );
}

function L::Clear( %list ) {
	return Stack::Clear( %list );
}

function L::Push( %list, %value ) {
	Stack::Push( %list, %value );
}

function L::PushUnique( %list, %value ) {
	return Stack::PushUnique( %list, %value );
}

function L::Reset( %list ) {
	Stack::Reset( %list );
	return ( Stack::Count( %list ) );
}

function L::GetNext( %list ) {
	return ( Stack::GetNext( %list ) );
}

function L::GetTop( %list ) {
	return ( Stack::GetTop( %list ) );
}

function L::Find( %list, %item ) {
	return ( Stack::Find( %list, %item ) );
}
