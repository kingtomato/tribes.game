$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

// %p0 is the function name!
function message::buildremoteparms( %p0, %p1, %p2, %p3, %p4, %p5, %p6, %p7, %p8, %p9 ) {
	// building the list instead of just passing them all saves on bandwidth
	%last = -1;
	for ( %i = 0; %i <= 9; %i++ ) {
		if ( %p[%i] != "" )
			%last = %i;
	}

	%parms = "";
	if ( %last >= 0 ) {
		for ( %i = 0; %i <= %last; %i++ )
			%parms = %parms @ ", \"" @ %p[%i] @ "\"";
	}

	return ( %parms );
}

function message::remoteall( %fn, %p0, %p1, %p2, %p3, %p4, %p5, %p6, %p7, %p8 ) {
	%parms = message::buildremoteparms( %fn, %p0, %p1, %p2, %p3, %p4, %p5, %p6, %p7, %p8 );
	for ( %cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext( %cl ) )
		eval( "remoteEval( " @ %cl @ %parms @ ");" );
}

function message::remoteall_except( %exceptcl, %fn, %p0, %p1, %p2, %p3, %p4, %p5, %p6, %p7, %p8 ) {
	%parms = message::buildremoteparms( %fn, %p0, %p1, %p2, %p3, %p4, %p5, %p6, %p7, %p8 );
	for ( %cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext( %cl ) )
		if ( %cl != %exceptcl )
			eval( "remoteEval( " @ %cl @ %parms @ ");" );
}

function message::remote( %cl, %fn, %p0, %p1, %p2, %p3, %p4, %p5, %p6, %p7, %p8 ) {
	%parms = message::buildremoteparms( %fn, %p0, %p1, %p2, %p3, %p4, %p5, %p6, %p7, %p8 );
	eval( "remoteEval( " @ %cl @ %parms @ ");" );
}


// Chat hud messaging

function message::all( %type, %message, %filter ) {
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) ) {
		if ( %filter == "" || ( %cl.messageFilter & %filter ) )
			Client::sendMessage( %cl, %type, %message );
	}
}

function message::client( %cl, %type, %message ) {
	Client::sendMessage( %cl, %type, %message );
}

function message::allfromclient( %cl, %type, %message, %team ) {
	for ( %cldst = Client::getFirst(); %cldst != -1; %cldst = Client::getNext(%cldst) ) {
		if ( ( %cldst.muted[%cl] && !%cl.adminLevel ) || ( %team != "" && %team != Client::getTeam( %cldst ) ) )
			continue;
		Client::sendMessage( %cldst, %type, %message, %cl );
	}
}


function message::allexcept( %clexcept, %type, %message ) {
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) ) {
		if ( %cl != %clexcept )
			Client::sendMessage( %cl, %type, %message );
	}
}

function message::teams( %type, %team1, %message1, %team2, %message2, %message3 ) {
	%count = getNumClients();
	for ( %i = 0; %i < %count; %i++ ) {
		%cl = getClientByIndex( %i );
		%team = Client::getTeam( %cl );
		
		if ( %team == %team1 )
			Client::sendMessage( %cl, %type, %message1 );
		else if ( ( %message2 != "" ) && ( %team == %team2 ) )
			Client::sendMessage( %cl, %type, %message2 );
		else if ( %message3 != "" )
			Client::sendMessage( %cl, %type, %message3 );
	}
}

function message::team( %type, %team, %message ) {
	%count = getNumClients();
	for ( %i = 0; %i < %count; %i++ ) {
		%cl = getClientByIndex( %i );
		if ( Client::getTeam( %cl ) == %team )
			Client::sendMessage( %cl, %type, %message );
	}
}

function remoteSay( %cl, %team, %message ) {
	%msg = %cl @ " \"" @ String::Escape(%message) @ "\"";

	if( !$Server::TourneyMode ) {
		%flood = flood::getdelay( %cl, "message", 5, 10 );
		if ( %flood ) {
			Client::sendMessage( %cl, $MSGTypeGame, "FLOOD! You cannot talk for " @ %flood @ " seconds. ");
			return;
		}
	}

	if ( ( %cl.selClient != "" ) && ( %cl.selClient != %cl ) ) {
		%sel = %cl.selClient;
		if ( %sel.muted[%cl] && !%cl.adminLevel )
			return;

		echo("MSG PRIVATE:   " @ %msg);
		message::bottomPrint( %cl, "<jc>(Sent to " @ Client::getName(%sel) @ ") " @ %message );
		Client::sendMessage( %sel, $MSGTypeTeamChat, "(PM) " @ %message, %cl );
	} else if ( ( %cl.selClient == %cl ) && %cl.canBroadcast ) {
		echo("MSG BROADCAST:   " @ %msg);
		message::centerprintall( "<jc>" @ Client::getName(%cl) @ " (Broadcast): " @ %message );
	} else {
		if ( %team ) {
			%team = Client::getTeam( %cl );
			%type = $MsgTypeTeamChat;
			echo( "SAYTEAM: " @ %msg );
		} else {
			%team = "";
			%type = $MsgTypeChat;
			echo( "SAY: " @ %msg );
		}

		message::allfromclient( %cl, %type, %message, %team );
	}
}

function remotePlayAnimWav( %cl, %anim, %wav ) {
	remotePlayAnim( %cl, %anim );
	remoteLMSG( %cl, %wav );
}

function remoteLMSG(%cl, %wav) {
	if ( flood::getdelay( %cl, "localwav", 5, 10 ) <= 0 )
		playVoice( %cl, %wav );
}


// Top/Center/Bottom printing

function message::xxxprint( %cl, %type, %msg, %timeout ) {
	if( %timeout == "" )
		%timeout = 5;
	remoteEval( %cl, %type, %msg, %timeout );
}

function message::xxxprintall( %msg, %type, %timeout ) {
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) )
		message::xxxprint( %cl, %type, %msg, %timeout );
}

function message::topprint   ( %cl, %msg, %timeout ) { message::xxxprint( %cl, "TP", %msg, %timeout ); }
function message::centerprint( %cl, %msg, %timeout ) { message::xxxprint( %cl, "CP", %msg, %timeout ); }
function message::bottomprint( %cl, %msg, %timeout ) { message::xxxprint( %cl, "BP", %msg, %timeout ); }

function message::topprintall   ( %msg, %timeout ) { message::xxxprintall( %msg, "TP", %timeout ); }
function message::centerprintall( %msg, %timeout ) { message::xxxprintall( %msg, "CP", %timeout ); }
function message::bottomprintall( %msg, %timeout ) { message::xxxprintall( %msg, "BP", %timeout ); }


// Tagged messaging

function message::tagged( %cl, %type, %msg, %p0, %p1, %p2, %p3, %p4, %p5, %p6 ) {
	%tagIndex = %cl.tagged[ %msg ];
	if ( %tagIndex == "" ) {
		%cl.tagged[ %msg ] = %cl.taggedMessages++;
		message::remote( %cl, "T", %type @ " add", %msg, %p0, %p1, %p2, %p3, %p4, %p5, %p6 );
	} else {
		message::remote( %cl, "T", %type, %tagIndex, %p0, %p1, %p2, %p3, %p4, %p5, %p6 );
	}
}

function message::taggedall( %type, %msg, %p0, %p1, %p2, %p3, %p4, %p5, %p6 ) {
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) ) 
		message::tagged( %cl, %type, %msg, %p0, %p1, %p2, %p3, %p4, %p4, %p6 );
}

function message::xxxprint_tagged( %cl, %type, %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ) {
	if( %timeout == "" )
		%timeout = 5;
	message::tagged( %cl, %type, %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 );
}

function message::xxxprintall_tagged( %msg, %type, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ) {
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) )	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) )
		message::tagged( %cl, %type, %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 );
}

function message::topprint_tagged   ( %cl, %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ) { message::xxxprint_tagged( %cl, "TP", %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ); }
function message::centerprint_tagged( %cl, %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ) { message::xxxprint_tagged( %cl, "CP", %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ); }
function message::bottomprint_tagged( %cl, %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ) { message::xxxprint_tagged( %cl, "BP", %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ); }

function message::topprintall_tagged   ( %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ) { message::xxxprintall_tagged( %msg, "TP", %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ); }
function message::centerprintall_tagged( %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ) { message::xxxprintall_tagged( %msg, "CP", %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ); }
function message::bottomprintall_tagged( %msg, %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ) { message::xxxprintall_tagged( %msg, "BP", %timeout, %p0, %p1, %p2, %p3, %p4, %p5 ); }