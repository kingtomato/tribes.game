exec( "stats/HTML" );

// util functions
function boldnum( %n ) {
	return ( !String::Compare( %n, "-" ) || ( String::Compare( %n, "" ) &&  String::Compare( %n, "0" ) ) ) ? bold( %n ) : "0";
}

function alttag() {
	$Exporter::alttag = ( $Exporter::alttag + 1 ) & 1;
	return ( "alt" @ $Exporter::alttag );
}

function boldtime( %duration ) {
	if ( %duration == "-" )
		return ( %duration );
	else if ( %duration == "" || %duration == "0" ) 
		return ( "0" );
	%hr = String::lpad( floor( %duration / 3600 ), 2, "0" );
	%duration = ( %duration % 3600 );
	%min = String::lpad( floor( %duration / 60 ), 2, "0" ); 
	%duration = ( %duration % 60 );
	%sec = String::lpad( floor( %duration ), 2, "0" );
	%time = %min @ ":" @ %sec;
	if ( %hr > 0 )
		%time = %hr @ ":" @ %time;
	return boldnum( %time );
}

function xmlizename( %name ) {
	%name = String::Replace( %name, "&", "&amp;" );
	%name = String::Replace( %name, "<", "&lt;" );
	%name = String::Replace( %name, ">", "&gt;" );
	return ( %name );
}

function filenameizename( %name ) {
	%name = String::Replace( %name, "&", "_" );
	%name = String::Replace( %name, "<", "_" );
	%name = String::Replace( %name, ">", "_" );
	%name = String::Replace( %name, "|", "_" );
	%name = String::Replace( %name, "*", "_" );
	%name = String::Replace( %name, "$", "_" );
	%name = String::Replace( %name, ":", "_" );
	%name = String::Replace( %name, "?", "_" );
	%name = String::Replace( %name, "\\", "_" );
	%name = String::Replace( %name, "/", "_" );
	%name = String::Replace( %name, "@", "_" );
	%name = String::Replace( %name, "#", "_" );
	%name = String::Replace( %name, "%", "_" );
	%name = String::Replace( %name, "^", "_" );
	%name = String::Replace( %name, "~", "_" );
	return ( %name );
}

// format stuff


// %1 = title
$Exporter::header = "<!DOCTYPE\nhtml PUBLIC \"-//W3C//DTD XHTML 1.1//EN\"\n \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">\n<html>\n<head>\n\t<title>%1</title>\n\t<link id=\"style\" rel=\"stylesheet\" type=\"text/css\" href=\"style.css\" />\n</head>\n";
$Exporter::footer = "</div>\n</body>\n</html>";

// %1 = date, %2 = map, %3 = length, %4 = score(0), %5 = score(1)
$Exporter::body = 
	"<body>\n" @
		div( "spacer" ) @
		div( "content",
			span( "label", "Date:" ) @ span( "value", "%1" ) @ br() @
			span( "label", "Map:" ) @ span( "value", "%2" ) @ br() @
			span( "label", "Length:" ) @ span( "value", "%3" ) @ br() @
			span( "label", bold( "BE" ) @ " score:" ) @ span( "value", "%4" ) @ br() @
			span( "label", bold( "DS" ) @ " score:" ) @ span( "value", "%5" )
		) @
		"<div class=\"body\">\n";

$Exporter::timeheader =
	tr( "", "<th colspan=\"5\">Time Info</th>" ) @
	tr( "title",
		td( "t", "Name" ) @
		td( "c", "OBs Time" ) @
		td( "c", "BE" ) @	
		td( "c", "DS" ) @
		td( "c", "Flag" )
	);

$Exporter::timefooter = "</table>" @ div( "spacer" );

$Exporter::statsheader =
	tr( "", "<th colspan=\"20\">Match Stats</th>" ) @
	tr( "title",
		td( "t", "Player" ) @
		td( "", "Rating" ) @
		td( "", "K/D" ) @
		td( "", "CG" ) @
		td( "", "Plas" ) @
		td( "", "Disc" ) @
		td( "", "Xplosv" ) @
		td( "", "Laser" ) @
		td( "", "Mortar" ) @
		td( "", "Trt" ) @
		td( "", "Suic" ) @
		td( "", "TK" ) @
		td( "", "CKill" ) @
		td( "", "Grb" ) @
		td( "", "Pckup" ) @
		td( "", "Drp" ) @
		td( "", "Ret" ) @
		td( "", "Stdoff Ret" ) @
		td( "", "Assists" ) @
		td( "", "Cap" )
	);

$Exporter::statsfooter = "</table>" @ div( "spacer" );

$Exporter::display["BE"] = "BE Totals";
$Exporter::display["DS"] = "DS Totals";
$Exporter::display["Home"] = "Enemy Flag Home";
$Exporter::display["Field"] = "Enemy Flag in Field";

function Exporter::ExportTimeRow( %class, %team, %name ) {
	if ( String::len( %name ) > 16 )
		%dispname = $Exporter::display[ String::trim( %name ) ];
	else
		%dispname = xmlizename( %name );
	
	html::emit(
		tr( %class,
			td( "t", %dispname ) @
			td( "c", boldtime( $Collector::timeplayer[ %name, -1 ] ) ) @ 
			td( "c", boldtime( $Collector::timeplayer[ %name,  0 ] ) ) @
			td( "c", boldtime( $Collector::timeplayer[ %name,  1 ] ) ) @
			td( "c", boldtime( $Collector::timeflag[ %team ^ 1, %name ] ) )
		)
	);
}

function Exporter::ExportTime() {
	html::emit( "<table class=\"time\">\n" );
	html::emit( $Exporter::timeheader );
	
	for ( %team = 0; %team <= 1; %team++ ) {
		Stack::Reset( "teamlist" @ %team );

		for ( %i = 0; %i < Stack::Count( "teamlist" @ %team ); %i++ ) {
			%name = Stack::GetNext( "teamlist" @ %team );
			Exporter::ExportTimeRow( alttag(), %team, %name );
		}

		Exporter::ExportTimeRow( alttag(), %team, $Marker::Home );
		Exporter::ExportTimeRow( alttag(), %team, $Marker::Field );
		html::emit( tr( "l", "<td class=\"l\" colspan=\"5\"></td>" ) );
		Exporter::ExportTimeRow( "total", %team, Marker::Team( %team ) );
		html::emit( tr( "l", "<td class=\"l\" colspan=\"5\"></td>" ) );
	}
	
	html::emit( $Exporter::timefooter );
}


function Exporter::KillDeathPair( %name, %type ) {
	if ( %type == "" )
		return sprintf( "%1/%2", boldnum( $Collector::Kills[ %name ] ), boldnum( $Collector::Deaths[ %name ] ) );
	else
		return sprintf( "%1/%2", boldnum( $Collector::Kills[ %name, %type ] ), boldnum( $Collector::Deaths[ %name, %type ] ) );
}

function Exporter::ExportStatsRow( %class, %name ) {
	%dispname = ( String::len( %name ) > 16 ) ? String::trim( %name ) @ " Totals" : xmlizename( %name );
	
	html::emit(
		tr( %class,
			td( "t", %dispname ) @
			td( "", boldnum( $Collector::Score[ %name ] ) ) @
			td( "", Exporter::KillDeathPair( %name ) ) @
			td( "", Exporter::KillDeathPair( %name, "Chaingun" ) ) @
			td( "", Exporter::KillDeathPair( %name, "Plasma" ) ) @
			td( "", Exporter::KillDeathPair( %name, "Disc" ) ) @
			td( "", Exporter::KillDeathPair( %name, "Explosive" ) ) @
			td( "", Exporter::KillDeathPair( %name, "Laser" ) ) @
			td( "", Exporter::KillDeathPair( %name, "Mortar" ) ) @
			td( "", Exporter::KillDeathPair( %name, "Turret" ) ) @
			td( "", boldnum( $Collector::Suicides[ %name ] ) ) @
			td( "", sprintf( "%1/%2", boldnum( $Collector::TeamKills[ %name ] ), boldnum( $Collector::TeamDeaths[ %name ] ) ) ) @
			td( "", boldnum( $Collector::CarrierKills[ %name ] ) ) @
			td( "", boldnum( $Collector::Grabs[ %name ] ) ) @
			td( "", boldnum( $Collector::Pickups[ %name ] ) ) @
			td( "", boldnum( $Collector::Drops[ %name ] ) ) @
			td( "", boldnum( $Collector::Returns[ %name ] ) ) @
			td( "", boldnum( $Collector::StandoffReturns[ %name ] ) ) @
			td( "", boldnum( $Collector::Assists[ %name ] ) ) @
			td( "", boldnum( $Collector::Caps[ %name ] ) )
		)
	);
}

function Exporter::ExportStats() {
	html::emit( "<table class=\"stats\">\n" );
	html::emit( $Exporter::statsheader );

	for ( %team = 0; %team <= 1; %team++ ) {
		Stack::Reset( "teamlist" @ %team );
		for ( %j = 0; %j < Stack::Count( "teamlist" @ %team ); %j++ )
			Exporter::ExportStatsRow( alttag(), Stack::GetNext( "teamlist" @ %team ) );
		
		html::emit( tr( "", "<td class=\"l\" colspan=\"20\"></td>" ) );
		Exporter::ExportStatsRow( "total", Marker::Team( %team ) );
		html::emit( tr( "", "<td class=\"l\" colspan=\"20\"></td>" ) );
	}

	html::emit( $Exporter::statsfooter );
}

function Exporter::ExportMap( %name ) {
	echo( "EXPORTING " @ %name );
	
	%obj = newobject( "FileWriterDummy", FearGuiFormattedText, 0, 0, 0, 0 );
	flushExportText();

	%playername = filenameizename( %name );

	timestamp::array();
	%displaydate = sprintf( "%1-%2-%3 %4:%5:%6", $Time["yr"], $Time["mo"], $Time["dy"], $Time["hr"], $Time["mn"], $Time["sc"] );
	
	%suffix = "am";
	if ( $Time["hr"] > 12 ) {
		$Time["hr"] = String::lpad( $Time["hr"] - 12, 2, "0" );
		%suffix = "pm";
	}
	%filedate = sprintf( "%1-%2-%3_%4%5%6", $Time["yr"], $Time["mo"], $Time["dy"], $Time["hr"], $Time["mn"], %suffix );
	
	html::emitf( $Exporter::header, "Andrew's Map Stats" );
	html::emitf(
		$Exporter::body,
		%displaydate,
		$Collector::MissionName,
		boldtime( $Collector::Duration ),
		boldnum( $Collector::Caps[Marker::Team(0)] ),
		boldnum( $Collector::Caps[Marker::Team(1)] )
	);
	
	Exporter::ExportTime();
	Exporter::ExportStats();
	
	html::emit( $Exporter::footer );
	
	exportObjectToScript( "FileWriterDummy", "stats\\("@%filedate@")_" @ %playername @ "_" @ $Collector::MissionName @ ".html", true );
	deleteObject( nameToID("FileWriterDummy") );
	flushExportText();

}