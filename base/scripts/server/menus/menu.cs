function menu::new( %displayName, %menuHandle, %cl ) {
   Client::buildMenu( %cl, %displayName, %menuHandle, true );
   %cl.menuLine = 0;
   %cl.menuKey++;
}

function menu::add( %item, %code, %cl, %condition ) {
	if ( %condition || ( %condition == "" ) ) {
		Client::addMenuItem( %cl, %cl.menuLine++ @ %item, %code );
		%cl.visibleMenuOption[%code] = %cl.menuKey;
	}
}

function Game::menuRequest( %cl ) {
	if( %cl.selClient && ( %cl.selClient != %cl ) )
		menu::nonself( %cl );
	else if ( %cl.selClient == %cl )
		menu::self( %cl );
	else if( $vote::Topic != "" && ( %cl.vote == "" || %cl.canCancelVote ) )
		menu::votepending( %cl );
	else if( %cl.adminLevel )
		menu::admin( %cl );
	else 
		menu::Vote( %cl );
}

function remoteMenuSelect( %cl, %code ) {
	if ( ( %cl.visibleMenuOption[%code] != %cl.menuKey ) || ( %cl.menuMode == "" ) )
		return;
	
	// no quotes or escapes
	if( String::findSubStr( %code, "\"" ) != -1 || String::findSubStr( %code, "\\" ) != -1 )
		return;

	%eval = "processMenu" @ %cl.menuMode @ "(" @ %cl @ ", \"" @ %code @ "\");";
	%cl.menuMode = "";
	%cl.menuLock = "";
	dbecho(2, "MENU: " @ %cl @ "- " @ %eval);
	eval(%eval);
	
	if( %cl.menuMode == "" ) {
		Client::setMenuScoreVis(%cl, false);
		%cl.selClient = "";
		%cl.menuKey++;
	}
}

function Client::cancelMenu(%cl) {
	if ( %cl.menuLock )
		return;

	%cl.selClient = "";
	%cl.menuMode = "";
	%cl.menuLock = "";
	remoteEval(%cl, "CancelMenu");
	Client::setMenuScoreVis(%cl, false);
}

function Client::buildMenu(%cl, %menuTitle, %menuCode, %cancellable) {
	Client::setMenuScoreVis(%cl, true);
	%cl.menuLock = !%cancellable;
	%cl.menuMode = %menuCode;
	remoteEval(%cl, "NewMenu", %menuTitle);
}

function Client::addMenuItem(%cl, %option, %code) {
	remoteEval(%cl, "AddMenuItem", %option, %code);
}
