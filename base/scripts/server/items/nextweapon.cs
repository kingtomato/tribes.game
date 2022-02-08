// Add a weapon to the prev/next cycle
function Item::AddWeaponToSwitchCycle( %weapon ) {
	if ( $item::FirstWeapon == "" )
		$item::FirstWeapon = ( %weapon );
	if ( $item::LastWeapon == "" )
		$item::LastWeapon = ( %weapon );

	$PrevWeapon[%weapon] = $item::LastWeapon;
	$NextWeapon[%weapon] = $item::FirstWeapon;
	$PrevWeapon[$item::FirstWeapon] = %weapon;
	$NextWeapon[$item::LastWeapon] = %weapon;
	
	$item::LastWeapon = ( %weapon );
}

$item::FirstWeapon = "";
$item::LastWeapon = "";

Item::AddWeaponToSwitchCycle( "" ); // dummy weapon


// use variable dereferencing, "*~%dir~%weapon" refers to $NextWeapon[%weapon] or $PrevWeapon[%weapon]
function Item::NextPrevWeaponFunc( %cl, %dir ) {
	if ( Player::isDead( %cl ) )
		return;

	%item = Player::getMountedItem( %cl, $WeaponSlot );
	if ( ( %item == -1 ) || ( *%dir~%item == "" ) ) {
		selectValidWeapon( %cl );
		return;
	}
	
	for ( %weapon = *%dir~%item; String::ICompare( %weapon, %item ) != 0; %weapon = *%dir~%weapon ) {
		if ( !isSelectableWeapon( %cl, %weapon) )
			continue;

		Player::useItem(%cl,%weapon);
		// Make sure it mounted (laser may not), or at least
		// next in line to be mounted.
		if ( !String::ICompare( Player::getMountedItem( %cl, $WeaponSlot ), %weapon ) || !String::ICompare( Player::getNextMountedItem( %cl, $WeaponSlot ), %weapon ) )
			break;
	}
}

function remoteNextWeapon( %cl ) {
	Item::NextPrevWeaponFunc( %cl, "$NextWeapon" );
}

function remotePrevWeapon(%cl) {
	Item::NextPrevWeaponFunc( %cl, "$PrevWeapon" );
}

function selectValidWeapon( %cl ) {
	for ( %weapon = $item::FirstWeapon; !%visited[%weapon]; %weapon = $NextWeapon[%weapon] ) {
		if ( isSelectableWeapon( %cl, %weapon ) ) {
			Player::useItem(%cl,%weapon);
			break;
		}
		%visited[ %weapon ] = true;
	}
}

function isSelectableWeapon( %cl, %weapon ) {
	if ( Player::getItemCount( %cl, %weapon ) ) {
		%ammo = $WeaponAmmo[%weapon];
		if ( %ammo == "" || Player::getItemCount( %cl, %ammo ) > 0 )
			return true;
	}
	return false;
}
