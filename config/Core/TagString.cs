Event::Attach( eventConnectionAccepted, TagString::onConnect );

function TagString::onConnect() {
	deleteVariables( "$TagString*" );
	$TagString::Count = 0;
}

function TagString::onStatRPC( %msg, %cl, %amt, %p0, %p1, %p2, %p3, %p4 ) {
	// cat/weight
	if ( String::explode( %msg, "/", "fields" ) != 2 ) {
		errorf( "TagString::onStatRPC: Invalid formatting for %1!", %msg );
		return;
	}
	ClientEvents::onClientScoreChange( %cl, $fields[1], %amt );
	
	// ClientEvents::onStatType(...);
	*"ClientEvents::on"~$fields[0]( %cl, %p0, %p1, %p2, %p3, %p4 );
}

function TagString::onKillDeathRPC( %msg, %killer, %victim ) {
	// type/killweight/deathweight
	if ( String::explode( %msg, "/", "fields" ) != 3 ) {
		errorf( "TagString::onKillDeathRPC: Invalid formatting for %1!", %msg );
		return;
	}
	ClientEvents::onClientScoreChange( %killer, $fields[1], 1 );
	ClientEvents::onClientScoreChange( %victim, $fields[2], 1 );
	ClientEvents::onClientKilled( %killer, %victim, $fields[0] );
}

$NameExpansion["TP"] = true;
$NameExpansion["CP"] = true;
$NameExpansion["BP"] = true;

// client side tag string rpc
function remoteT( %sv, %cmd, %tagValue, %p0, %p1, %p2, %p3, %p4, %p5, %p6 ) {
	echof( "remoteTagString: cmd %1, tag %2, parms %3, %4, %5, %6, %7, %8, %9",
		%cmd, %tagValue, %p0, %p1, %p2, %p3, %p4, %p5, %p6 );
	
	%msgtype = getWord( %cmd, 0 );
	%action = getWord( %cmd, 1 );

	if ( %action == "add" ) {
		%tagIndex = $TagString::Count++;
		$TagString[ %tagIndex ] = %tagValue;
	} else if ( %action == -1 ) {
		%tagIndex = %tagValue;
	}
	
	%tag = $TagString[ %tagIndex ];
	if ( %tag == "" ) {
		errorf( "TAGSTRING: Server requesting index that doesn't exist?" );
		return;
	}
	
	// expand any client names if needed (this means you can't pass 2049 -> ~2100 as parameters!)
	if ( $NameExpansion[%msgtype] ) {
		for ( %i = 0; %i <= 6; %i++ ) {
			%name = String::escapeFormatting( Client::getName( %p[%i] ) );
			if ( %name == "" )
				continue;
			%p[%i] = %name;
		}
	}

	switch ( %msgtype ) {
		// stat rpcs
		case "ST": TagString::onStatRPC( %tag, %p0, %p1, %p2, %p3, %p4, %p5, %p6 ); break;
		case "KD": TagString::onKillDeathRPC( %tag, %p0, %p1 ); break;

		// centerprint rpc
		case "TP":
		case "CP":
		case "BP":
			%timeout = %p0;
			%msg = sprintf( %tag, %p1, %p2, %p3, %p4, %p5, %p6 );
			*"remote"~%msgtype( 2048, %msg, %timeout );
			break;

		// generic rpc
		case "RPC":
			*"remote"~%tag( 2048, %p0, %p1, %p2, %p3, %p4, %p5, %p6 );
			break;
	}
}