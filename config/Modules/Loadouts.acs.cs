Event::Attach( eventConnected, AutoBuy::onConnected );
Event::Attach( eventEnterStation, AutoBuy::onEnterStation );

function AutoBuy::onConnected() {
	$curFavorites = $pref::defaultloadout + 1;
}

function AutoBuy::onEnterStation() {
	if ( $PlayingDemo )
		return;

	if ( $pref::autoSpewPacks && ( $Station::Type == "Inventory" ) ) {
		AutoBuy::cheeseRepair();
		AutoBuy::litterItem( "Repair Pack" );
	}

	if ( $pref::autoBuyLoadout )
		AutoBuy::SelectAndBuyLoadout( $curFavorites );
}

function AutoBuy::litterItem( %item ) {
	%type = getItemType( %item );
	for ( %i = 0; %i < 4; %i++ ) {
		Schedule( "remoteEval(2048,buyItem," @ %type @ ");", 0.1 );
		Schedule( "remoteEval(2048,dropItem," @ %type @ ");", 0.1 );
	}
}

function AutoBuy::BuyLoadout() {
	%items = String::Explode( $pref::favorites[$curFavorites, $ServerFavoritesKey], ",", "temp" );
	if ( !%items )
		return;
	
	%cmd = "remoteEval(2048, buyFavorites";
	for ( %i = 0; %i < %items; %i++ ) {
		%item = $temp[%i];
		%items[%item] = true;
		%cmd = sprintf( "%1, %2", %cmd, getItemType(%item) );
		if ( %item == "Mine" )
			%cmd = sprintf( "%1, %2", %cmd, getItemType(%item) );
	}

	eval( %cmd ~ " );" );
	
	if ( $Station::Type != "" ) {
		if ( %items["Shield Pack"] && $pref::autoUseShield )
			Schedule("use(\"Backpack\");", 0.1);
	}
}

function AutoBuy::SelectAndBuyLoadout( %idx ) {
	$curFavorites = %idx;
	%name = $pref::favorites[$curFavorites, $ServerFavoritesKey, "name"];
	if ( $pref::noEnterInv || ( $Station::Type == "" ) )
		remoteBP( 2048, "<jc><f1>Favorite set to: <f2>" ~ %name ~ "<f1>.", 3 );

	CmdInventoryGui::favoritesSel( $curFavorites );
	Schedule::Add( "AutoBuy::BuyLoadout();", 0.1 );
}

function AutoBuy::DumpNonLoadoutItems() {
	for ( %i = 0; (%item = $pref::favorites[$curFavorites, $ServerFavoritesKey, %i]) != ""; %i++ )
		%items[%item] = true;

	for ( %i = 0; (%desc = getItemDesc(%i)) != ""; %i++ ) {
		if ( !%items[%desc] && ( getItemCount(%desc) == 1 ) )
			remoteEval( 2048, dropItem, %i );
	}
}

function AutoBuy::cheeseRepair() {
	if ( $Scripts::Version != "none" )
		return;

	%type = getItemType("Repair Kit");
	if ( $Station::Type == "Inventory" ) {
		for ( %i = 0; %i < 5; %i++ ) {
			Schedule( "remoteEval(2048,useItem," @ %type @ ");", 0 );
			Schedule( "remoteEval(2048,buyItem," @ %type @ ");", 0 );
		}
	} else {
		use("Repair Kit");
	}
}