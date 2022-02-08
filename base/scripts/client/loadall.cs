exec("client/editor/tsDefaultMatProps");

$editor::loaded = false;
function mapEditor() {
	if ( !$editor::loaded ) {
		exec( "client/editor/editor" );
		$editor::loaded = true;
	} else {
		memode();
	}
}
