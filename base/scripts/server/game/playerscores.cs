function UpdateScores() {
	for ( %cl = Client::getFirst(); %cl != -1; %cl = Client::getNext( %cl ) ) {
		if ( !%cl.lastscore || ( abs( %cl.score - %cl.lastscore ) >= 0.09999 ) ) {
			%cl.lastscore = %cl.score;
			Game::refreshClientScore( %cl );
		}
	}
	
	Schedule::Add( "UpdateScores();", 1 );
}

Schedule::Cancel( "UpdateScores();" );
UpdateScores();