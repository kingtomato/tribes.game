function banlist::permaban( %cl, %bannedcl, %numWords, %stringSize ) {
	if(!%cl.canPermanentBan)
		return;

	//you must be higher level than the other admin to kick/ban him
	if (%cl.adminLevel <= %bannedcl.adminLevel) {
		Client::sendMessage(%cl, $MSGTypeSystem, "You do not have the power to ban " @ Client::getName(%bannedcl) @ ".");
		Client::sendMessage(%bannedcl, $MSGTypeGame, Client::getName(%cl) @ " just tried to ban you.");
		log::add( %cl, "attempted to ban ", %bannedcl, "", "KickBan" );
		return;
	}

	%ip = Client::getTransportAddress(%bannedcl);
	%truncatedip = admin::parseip( %bannedcl, %numWords, %stringSize, false );
	if ( %truncatedIP == "" )
		return;

	$banlist[$banlist::count++] = String::rpad(%truncatedip, 20) @ String::rpad(%ip, 26) @ Client::getName(%bannedcl) @ " permanently banned by " @ %cl.registeredName @ ".";

	log::add( %cl, "permanently banned", %bannedcl, "@", "KickBan" );
	export( "banlist" @ $banlist::count, "config/" @ $Server::BanFile, true );
	message::all(0, Client::getName(%bannedcl) @ " was banned by " @ Client::getName(%cl));

	Net::kick( %bannedcl, $Server::PermaBanMessage );
	BanList::addAbsolute();
	BanList::add( %ip, $Server::BanTime );
}

function banlist::isbanned( %cl ) {
	if ( banlist::isexcluded( %cl ) )
		return ( false );
	
	%ip = Client::getTransportAddress(%cl);
	
	for ( %octets = 1; %octets <= 4; %octets++ ) {
		%idx = $banlistlookup[ admin::parseip( %cl, %octets, 18, false ) ];
		if ( %idx == "" )
			continue;
		
		echo( "BANLIST ENTRY " @ %idx @ " caused " @ %ip @ " to be banned" );
		return ( true );
	}
	
	return ( false );
}

function banlist::reban( %cl ) {
    log::add( -2, "automatically re-banned", %cl, "!", "KickBan" );
	echo( "AUTOBOOT: " @ Client::getName(%cl) @ " has been previously permabanned and is being dropped." );
    %ip = Client::getTransportAddress(%cl);
	BanList::add( %ip, $Server::BanTime );
	Net::Kick( %cl, $Server::PermaBanMessage );
}

function banlist::load( %file ) {
	deleteVariables("$banlist*");

	exec( %file );
	
	for ( %i = 0; %i < 1000; %i++ ) {
		%iprule = $banlist[%i];
		if ( %iprule == "" )
			continue;
		
		// create lookup for this ip
		for ( %octets = 1; %octets <= 4; %octets++ )
			$banlistlookup[ admin::formatip( %iprule, %octets, 18, false ) ] = %i;

		// highest entry seen
		$banlist::count = ( %i );
	}
}

function banlist::isexcluded( %cl ) {
	%ip = Client::getTransportAddress( %cl );
	%name = Client::getName( %cl );
	
	for ( %octets = 1; %octets <= 4; %octets++ ) {
		%idx = $exclusionlookup[ admin::parseip( %cl, %octets, 18, false ) ];
		if ( %idx == "" )
			continue;

		for ( %i = 0; %i < 6; %i++ ) {
			if ( $exlusionlist[ %idx, %i ] == %name )
				return ( true );
		}
	}
	
	return ( false );
}

function banlist::loadexclusions( %file ) {
	deleteVariables("$exclusion*");
	$exclusion::count = 0;
	exec( %file );
}

function banlist::addexclusion( %ip, %name0, %name1, %name2, %name3, %name4, %name5 ) {
	%idx = $exclusion::count;
	$exclusion::count++;
	
	$exclusionlookup[ %ip ] = %idx;
	for ( %i = 0; %name[%i] != ""; %i++ )
		$exclusionlist[ %idx, %i ] = %name[%i];
}
