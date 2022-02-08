function remoteCancelMenu( %sv ) {
	if ( %sv != 2048 )
		return;

	if( isObject( CurServerMenu) )
		deleteObject( CurServerMenu );
}

function remoteNewMenu( %sv, %title ) {
	if( %sv != 2048 )
		return;

	if ( isObject( "CurServerMenu" ) )
		deleteObject( "CurServerMenu" );

	newObject( "CurServerMenu", ChatMenu, %title );
	setCMMode( "PlayChatMenu", 0 );
	setCMMode( "CurServerMenu", 1 );
}

function remoteAddMenuItem( %sv, %title, %code ) {
	if ( %sv != 2048 )
		return;

	addCMCommand( "CurServerMenu", %title, clientMenuSelect, %code );
}

function clientMenuSelect( %code ) {
	deleteObject( "CurServerMenu" );
	remoteEval( 2048, menuSelect, %code );
}
