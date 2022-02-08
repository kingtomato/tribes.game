function Auto::Health( ) {
	if ( $Station::Type == "Inventory" || $Station::Type == "RemoteInventory" )
		{ 
		schedule::cancel("Auto::Health();");
		// echo("in station, delay autokit 9 seconds");
		schedule::add("Auto::Health();", 9);
		return;
		}
	%RKit = getItemCount("Repair Kit");
        
	if ( %RKit>0 && $Health < 65 && $Health > 0 )
		use("Repair Kit");
		
	schedule::add("Auto::Health();", 0.1);
}

Event::Attach(eventConnected, Auto::Health);