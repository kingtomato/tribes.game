function remoteSetPassword( %cl, %password ) {
	if ( !%cl.canSetPassword )
		return;
	$Server::Password = ( %password );
	log::add( %cl, "changed the password to" @ %password, "", "", "ServerPasswords" );
}