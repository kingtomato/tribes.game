function menu::servertoggles( %cl ) {
	menu::new( "Server Options", "servertoggle", %cl );
	
	menu::add("Enable Anti-Rape", "ear", %cl, !$Server::AntiRape && %cl.canAntiRape );
	menu::add("Disable Anti-Rape", "dar", %cl, $Server::AntiRape && %cl.canAntiRape );

	menu::add("Enable No-Repair", "enr", %cl, !$Server::NoRepair && %cl.canAntiRepair );
	menu::add("Disable No-Repair", "dnr", %cl, $Server::NoRepair && %cl.canAntiRepair );

	menu::add("Enable Pickup Mode", "epm", %cl, !$Server::PickupMode && %cl.canPickup );
	menu::add("Disable Pickup Mode", "dpm", %cl, $Server::PickupMode && %cl.canPickup );
}

function processMenuServerToggle( %cl, %sel ) {
	if ((%sel == "ear") && %cl.canAntiRape) {
		$Server::AntiRape = true;
		AntiRape::Check();
	} else if ((%sel == "dar") && %cl.canAntiRape) {
		$Server::AntiRape = false;
		AntiRape::Check();
	} else if ((%sel == "enr") && %cl.canAntiRepair) {
		$Server::NoRepair = true;
		AntiRepair::Check();
	} else if ((%sel == "dnr") && %cl.canAntiRepair) {
		$Server::NoRepair = false;
		AntiRepair::Check();
	} else if ((%sel == "epm") && %cl.canPickup) {
		$Server::PickupMode = true;
		$Server::Password = "pickup";
		OverflowCycle(getNumClients());
		
		message::all(0, Client::getName(%cl) @ " ENABLED Pickup Mode! Server Password='pickup'");
		
		log::add( %cl, "enabled PICKUP mode", "", "", "Pickups" );
	} else if ((%sel == "dpm") && %cl.canPickup) {
		$Server::PickupMode = false;
		OverflowCycle(getNumClients());
		
		message::all(0, Client::getName(%cl) @ " DISABLED Pickup Mode.");
		
		log::add( %cl, "disabled PICKUP mode", "", "Pickups" );
	}
	
	menu::servertoggles( %cl );
}
