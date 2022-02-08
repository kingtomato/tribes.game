function html::emit( %str ) {
	AddExportText( %str );
}

function html::emitf( %fmt, %p0, %p1, %p2, %p3, %p4, %p5, %p6, %p7, %p8, %p9 ) {
	html::emit( sprintf( %fmt, %p0, %p1, %p2, %p3, %p4, %p5, %p6, %p7, %p8, %p9 ) );
}

function htmltag( %name, %class, %value ) {	
	if ( %class != "" )
		return sprintf( "<%1 class=\"%2\">%3</%1>", %name, %class, %value ); 
	else
		return sprintf( "<%1>%2</%1>", %name, %value ); 
}
function table( %class, %value ) { return htmltag( "table", %class, %value ); }
function tr( %class, %value ) { return htmltag( "tr", %class, %value ); }
function td( %class, %value ) { return htmltag( "td", %class, %value ); }
function div( %class, %value ) { return htmltag( "div", %class, %value ); }
function span( %class, %value ) { return htmltag( "span", %class, %value ); }
function br() { return "<br />\n"; }

function bold( %value ) { return span( "bold", %value ); }




