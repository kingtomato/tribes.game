function ClientEvents::onFlagPickup( %cl, %team ) {
	Event::Trigger(eventFlagPickup, %team, %cl );
	Event::Trigger(eventFlagUpdate, %cl);
}

function ClientEvents::onFlagGrab( %cl, %team ) {
	Event::Trigger(eventFlagGrab, %team, %cl );
	Event::Trigger(eventFlagUpdate, %cl);
}

function ClientEvents::onFlagDrop( %cl, %team ) {
	Event::Trigger( eventFlagDrop, %team, %cl );
	Event::Trigger( eventFlagUpdate, %cl );
	
	$Flag::DropTime[ %cl ] = getSimTime(); // for legacy carrier kill support
}

function ClientEvents::onFlagReturn( %cl, %team ) {
	Event::Trigger( eventFlagReturn, %team, %cl );
	Event::Trigger( eventFlagUpdate, %cl );
}

function ClientEvents::onFlagStandoffReturn( %cl, %team ) {
	Event::Trigger( eventFlagStandoffReturn, %team, %cl );
}

function ClientEvents::onFlagCap( %cl, %team ) {
	Event::Trigger( eventFlagCap, %team, %cl );
	Event::Trigger( eventFlagUpdate, %cl );
}

function ClientEvents::onFlagAssist( %cl, %team ) {
	Event::Trigger( eventFlagAssist, %team, %cl );
}

function ClientEvents::onFlagCarrierKill( %cl ) {
	Event::Trigger( eventFlagCarrierKill, %cl );
}

function ClientEvents::onFlagBonus( %cl ) {
	Event::Trigger( eventFlagBonus, %cl );
}
