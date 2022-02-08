function Item::SetDamageType( %desc, %value ) {
	evalf( "$%1DamageType = %2;", %desc, %value );
	$Item::damagedesc[ %value ] = %desc;
}

function Item::AddDamageType( %desc ) {
	Item::SetDamageType( %desc, $Item::damageTypeCounter );
	$Item::damageTypeCounter++;
}

function Item::GetDamageDesc( %desc ) {
	return ( $Item::damagedesc[ %desc ] );
}

$Item::damageTypeCounter = -1;

Item::AddDamageType( "Impact" );
Item::AddDamageType( "Landing" );
Item::AddDamageType( "Crush" );
Item::AddDamageType( "Debris" );
Item::AddDamageType( "Turret" );

