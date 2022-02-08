function KillPop( %killer, %victim, %damage ) {
	if ( %killer != getManagerId() )
		return;

	remoteBP( 2048, "<JC><F2>You <F1>killed <F2>" ~ String::escapeFormatting( Client::getName( %victim ) ) ~ "\n<F1>Weapon: <F2>" ~ %damage, 3 );
}

function TeamKillPop( %killer, %victim, %damage ) {
	if ( %killer != getManagerId() )
		return;

	remoteBP( 2048, "<JC><F2>You <F1>TEAMKILLED <F2>" ~ String::escapeFormatting( Client::getName( %victim ) ), 3 );
}

Event::Attach( eventClientKilled, KillPop );
Event::Attach( eventClientTeamKilled, TeamKillPop );
