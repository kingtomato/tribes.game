function ClientEvents::onClientScoreChange( %cl, %weight, %amt ) {
	Event::Trigger( eventClientScoreAdd, %cl, %weight * %amt );
}