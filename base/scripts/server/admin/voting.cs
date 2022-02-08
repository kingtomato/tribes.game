$vote::Topic = "";
$vote::Action = "";
$vote::Option = "";
$vote::Count = 0;

function admin::startvote( %cl, %topic, %action, %option ) {
	if( %cl.lastVoteTime == "" )
		%cl.lastVoteTime = -$Server::MinVoteTime;

	// we want an absolute time here.
	%time = getIntegerTime(true) >> 5;
	%diff = ( %cl.lastVoteTime + $Server::MinVoteTime ) - %time;

	if ( %diff > 0 ) {
		Client::sendMessage(%cl, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
		return;
	}
	
	if( $vote::Topic != "" ) {
		Client::sendMessage( %cl, 0, "Voting already in progress." );
		return;
	}
	
	if ( $dedicated )
		echo( "VOTE INITIATED: " @ Client::getName(%cl) @ " initiated a vote to " @ %topic );

	if( %cl.numFailedVotes )
		%time += %cl.numFailedVotes * $Server::VoteFailTime;

	%cl.lastVoteTime = %time;
	$vote::Initiator = %cl;
	$vote::Topic = %topic;
	$vote::Action = %action;
	$vote::Option = %option;
	if(%action == "kick")
		$vote::Option.kickTeam = GameBase::getTeam($vote::Option);

	$vote::Count++;
	message::bottomprintall( "<jc><f1>" @ String::escapeFormatting(Client::getName(%cl)) @ " <f0>initiated a vote to <f1>" @ $vote::Topic, 10 );

	// reset everyone's votes
	for( %cl2 = Client::getFirst(); %cl2 != -1; %cl2 = Client::getNext(%cl2) )
		%cl2.vote = "";
	
	// vote initiator votes yes!
	%cl.vote = "yes";
	for( %cl2 = Client::getFirst(); %cl2 != -1; %cl2 = Client::getNext(%cl2) )
		if( %cl2.menuMode == "options" )
			Game::menuRequest(%cl2);

	schedule( "admin::tallyvotes(" @ $vote::Count @ ");", $Server::VotingTime, 35 );
}


function admin::tallyvotes( %curvote ) {
	if ( ( %curvote != $vote::Count ) || ( $vote::Topic == "" ) )
		return;

	%for["yes"] = 1;
	%against["no"] = 1;
	%abstain[""] = 1;
	
	%for_team = %against_team = 0;
	%for = %against = %abstain = 0;
	for( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl) ) {
		%for += %for[ %cl.vote ];
		%against += %against[ %cl.vote ];
		%abstain += %abstain[ %cl.vote ];
		if ( GameBase::getTeam(%cl) == $vote::Option.kickTeam ) {
			%for_team += %for[ %cl.vote ];
			%against_team += %against[ %cl.vote ];
		}
   }

   %votes = ( %for + %against );
   %votes_team = ( %for_team + %against_team );
   %clients = ( %votes + %abstain );

   %minvotes = floor( $Server::MinVotesPct * %clients );
   if( %minvotes < $Server::MinVotes )
      %minvotes = $Server::MinVotes;

   if ( %votes < %minVotes ) {
      %against += ( %minVotes - %votes );
      %votes = %minVotes;
   }
   
   %margin = $Server::VoteWinMargin;
   if ( $vote::Action == "admin" ) {
      %margin = $Server::VoteAdminWinMargin;
      %votes = %for + %against + %abstain;
      if( %votes < %minVotes )
         %votes = %minVotes;
   }
   
   if( ( %for / %votes  ) >= %margin ) {
      message::all( 0, "Vote to " @ $vote::Topic @ " passed: " @ %for @ " to " @ %against @ " with " @ %abstain @ " abstentions." );
      admin::votepassed();
   } else {
   	   // recheck team votes for kicking
      if($vote::Action == "kick") {
         if( ( %votes_team >= $Server::MinVotes ) && ( ( %for_team / %votes_team ) >= $Server::VoteWinMargin ) ) {
            message::all(0, "Vote to " @ $vote::Topic @ " passed: " @ %for_team @ " to " @ %votes_team - %for_team @ ".");
            admin::votepassed();
            $vote::Topic = "";
            return;
         }
      }
      message::all(0, "Vote to " @ $vote::Topic @ " did not pass: " @ %for @ " to " @ %against @ " with " @ %abstain @ " abstentions." );
      admin::votefailed();
   }
   $vote::Topic = "";
}


function admin::votefailed() {
	$vote::Initiator.numVotesFailed++;

	if( $vote::Action == "kick" || $vote::Action == "admin" )
		$vote::Option.voteTarget = "";
}


function admin::votepassed() {
	if ( $vote::Action == "kick" ) {
		if ( $vote::Option.voteTarget )
			admin::kick( -1, $vote::Option );
	} else if ( $vote::Action == "admin" ) {
		if ( $vote::Option.voteTarget ) {
			log::add( -1, "adminned", $vote::Option, "", "Admins" );
			adminlevel::grant( $vote::Option, adminlevel::get("Public Admin") );
			$vote::Option.registeredName = "Admin by vote";

			message::all( 0, Client::getName($vote::Option) @ " has become an administrator." );
			if ( $vote::Option.menuMode == "options" )
				Game::menuRequest( $vote::Option );
		}
	
		$vote::Option.voteTarget = false;
	} else if ( $vote::Action == "changeMission" ) {
		message::all( 0, "Changing to mission " @ $vote::Option @ "." );
		ObjectiveMission::missionComplete( $vote::Option );
	} else if ( $vote::Action == "tourney" ) {
		admin::settourneymode( -1 );
	} else if ( $vote::Action == "ffa" ) {
		admin::setffamode( -1 );
	} else if ( $vote::Action == "etd" ) {
		admin::setteamdamage( -1, true );
	} else if ( $vote::Action == "dtd" ) {
		admin::setteamdamage( -1, false );
	} else if ( $vote::Option == "smatch" ) {
		admin::startmatch( -1 );
	}
}


function remoteVoteYes( %cl ) {
   %cl.vote = "yes";
   message::centerprint( %cl, "", 0 );
}

function remoteVoteNo( %cl ) {
   %cl.vote = "no";
   message::centerprint( %cl, "", 0 );
}
