function ActionMaps::Add( %map ) {
	$ActionMaps[ $ActionMaps::Count++ - 1 ] = %map;
}

function ActionMaps::Clear() {
	deleteVariables( "$ActionMaps*" );
}

function ActionMaps::Save( %file ) {
	%save = sprintf( "saveActionMap( \"%1\"", %file );
	for ( %i = 0; $ActionMaps[%i] != ""; %i++ )
		%save = sprintf( "%1, \"%2\"", %save, $ActionMaps[%i] );
	eval( %save ~ " );" );
}

ActionMaps::Clear();
ActionMaps::Add( "actionMap.sae" );
ActionMaps::Add( "playMap.sae" );
ActionMaps::Add( "pdaMap.sae" );
ActionMaps::Add( "inventoryMap.sae" );
ActionMaps::Add( "demoMap.sae" );
