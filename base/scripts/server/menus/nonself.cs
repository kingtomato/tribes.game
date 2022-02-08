function menu::nonself( %cl ) {
	%sel = %cl.selClient;
	%selName = Client::getName( %sel );

	if( %cl.canBan )
		%kickMsg = "Kick or Ban ";
	else
		%kickMsg = "Kick ";

	menu::new( "Options", "nonself", %cl );
	//menu::add( "Vote to admin " @ %selName, "vadmin " @ %sel, %cl, !%cl.canMakeAdmin );
	menu::add( "Vote to kick " @ %selName, "vkick " @ %sel, %cl, !%cl.canKick );
	menu::add( %kickMsg @ %selName, "kickban " @ %sel, %cl, %cl.canKick );
	menu::add( "Message " @ %selName, "message " @ %sel, %cl, %cl.canSendWarning );
	menu::add( "Change " @ %selName @ "'s team", "fteamchange " @ %sel, %cl, %cl.canChangePlyrTeam );
	menu::add( "Admin " @ %selName, "admin " @ %sel, %cl, %cl.canMakeAdmin );
	menu::add( "Strip " @ %selName, "stradmin " @ %sel, %cl, ( %cl.canStripAdmin && %sel.adminLevel > 0 ) );
	menu::add( "Observe " @ %selName, "observe " @ %sel, %cl, ( %cl.observerMode == "observerOrbit" ) );
	menu::add( "UnMute " @ %selName, "unmute " @ %sel, %cl, %cl.muted[%sel] != "" );
	menu::add( "Mute " @ %selName, "mute " @ %sel, %cl, %cl.muted[%sel] == "" );
}


function processMenuNonSelf( %cl, %selection ) {
    %option = getWord( %selection, 0 );
    %vic = getWord( %selection, 1 );

	if (%option == "message") {
	     menu::MessagePlayer( %cl, %vic );
		 return;
	}    
    else if (%option == "admin") {
    	 menu::makeadmin(%cl, %vic);
    	 return;         
    }   
    else if (%option == "stradmin") {
    	 menu::StripAdmin(%cl, %vic);
    	 return;
	}
    else if (%option == "kickban") {
	     menu::kickban( %cl, %vic );
    	 return;
	}
	else if (%option == "fteamchange") {
    	 menu::ForceTeamChange(%cl, %vic);
    	 return;
    }
    else if (%option == "vkick") {
         %vic.voteTarget = true;
         admin::startvote(%cl, "kick " @ Client::getName(%vic), "kick", %vic);
		 Game::menuRequest( %cl );
    }
    else if (%option == "vadmin") {
         %vic.voteTarget = true;
         admin::startvote(%cl, "admin " @ Client::getName(%vic), "admin", %vic);
		 Game::menuRequest( %cl );
    }
    else if ( %option == "observe" ) {
         Observer::setTargetClient(%cl, %vic);
         return;
    } else if ( %option == "mute" ) {
         %cl.muted[%vic] = true;
    } else if ( %option == "unmute" ) {
         %cl.muted[%vic] = "";
    }

    Game::menuRequest( %cl );
}



function remoteSelectClient( %cl, %selId ) {
	if( %cl.selClient != %selId ) {
		%cl.selClient = %selId;
		Game::menuRequest( %cl );

		if ( %selId.registeredName == "" )
			%selId.registeredName = "Unknown";
		if( !%selId.adminLevel )
			%selId.adminLevel = 0;

		remoteEval( %cl, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":" );

		if( %cl.canSeePlayerSpecs ) {
			remoteEval( %cl, "setInfoLine", 2, "Admin Status: " @ adminlevel::getname( %selId.adminLevel ) );
			remoteEval( %cl, "setInfoLine", 3, "Name: " @ %selId.registeredName );
			remoteEval( %cl, "setInfoLine", 4, "IP: " @ Client::getTransportAddress(%selId) );
		} else {
			remoteEval(%cl, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
			remoteEval(%cl, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
			remoteEval(%cl, "setInfoLine", 4, "Other: " @ $Client::info[%selId, 5]);
		}

		if( %cl == %selId ) {
			if ( %cl.canBroadcast ) {
				remoteEval(%cl, "setInfoLine", 5, "");
				remoteEval(%cl, "setInfoLine", 6, "CHAT now Broadcasts message.");
			}
		} else {
			remoteEval(%cl, "setInfoLine", 5, "");
			remoteEval(%cl, "setInfoLine", 6, "CHAT now /pm's " @ Client::getName(%selId) );
		}
	}
}
