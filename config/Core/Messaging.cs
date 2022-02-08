// events

$MessageTypeSystem = 0;
$MessageTypeGame = 1;
$MessageTypeChat = 2;
$MessageTypeTeamChat = 3;
$MessageTypeCommand = 4;

function onClientMessage( %cl, %msg, %type ) {
	if( %cl )
		$lastClientMessage = %cl;
	
	%muted = false;
	%index = String::findSubStr( %msg, "~" );
	if ( %index != -1 ) {
		%tags = String::getSubStr( %msg, %index + 1, 10000 );
		%msg = String::getSubStr( %msg, 0, %index );
	}

	if ( %cl )
		%muted = ( Event::Trigger( eventClientMessage, %cl, %msg, %type, %tags ) == "mute" );
	else
		%muted = ( Event::Trigger( eventServerMessage, %msg, %type, %tags) == "mute" );

	return !%muted;
}

function onLocalSound( %cl, %wav ) {
	return ( Event::Trigger( eventLocalSound, %cl, %wav ) == "mute" ) ? false : true;
}


// functions

function messageAndAnimate( %anim, %wav ) { 
	remoteEval( 2048, playAnimWav, %anim, %wav );
}

function localMessage( %wav ) {
	remoteEval( 2048, LMSG, %wav );
}
