function menu::votepending( %cl ) {
    menu::new( "Vote in progress", "votepending", %cl );

	menu::add( "Vote YES to " @ $vote::Topic, "voteYes " @ $vote::Count, %cl, %cl.vote == "" );
	menu::add( "Vote No to " @ $vote::Topic, "voteNo " @ $vote::Count, %cl, %cl.vote == "" );
	menu::add( "VETO Vote to " @ $vote::Topic, "veto", %cl, %cl.canCancelVote );
	menu::add( "Admin Options...", "adminoptions", %cl, (%cl.adminLevel > 0) );
}

function processMenuVotePending( %cl, %sel ) {
	%selection = getWord( %sel, 0 );
	%value = getWord( %sel, 1 );

	if ( ( %selection == "voteYes" ) && ( %value == $vote::Count ) ) {
         %cl.vote = "yes";
         message::centerprint( %cl, "", 0 );
    } else if ( ( %selection == "voteNo") && ( %value == $vote::Count ) ) {
         %cl.vote = "no";
         message::centerprint( %cl, "", 0 );
    } else if ( %selection == "veto" && ( %cl.canCancelVote ) ) {
	    message::all(0, "Vote to " @ $vote::Topic @ " was VETO'd by an Admin.");
		message::bottomprintall( "", 0 );
		$vote::Topic = "";
      	admin::votefailed();
    } else if( %selection == "adminoptions" ) {
	   menu::admin(%cl);
	   return;
	}
	
	Game::menuRequest(%cl);
}