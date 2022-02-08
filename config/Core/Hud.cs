function Hud::Init() {
	DeleteVariables( "Hud::*" );
	$Hud::Count = 0;
}

function Hud::New( %name, %x, %y, %w, %h, %wake, %sleep, %shaded ) {
	//dont recreate the hud
	if ( $Hud::Huds[%name] )
		return false;

	//shaded = background, non shaded = just the hud text
	$Hud::Huds[$Hud::Count] = newObject( %name, ( %shaded != "" ) ? FearGui::ShadedHudCtrl : FearGui::HudCtrl, %x, %y, %w, %h );

	//set the hud variables
	$Hud::Huds[$Hud::Count, name]	= %name;
	$Hud::Huds[$Hud::Count, wake]	= %wake;
	$Hud::Huds[$Hud::Count, sleep]	= %sleep;
	$Hud::Huds[%name]				= $Hud::Huds[$Hud::Count];

	Control::SetVisible( %name, true );
	$Hud::Count++;
}


function Hud::New::Shaded(%name, %x, %y, %w, %h, %wake, %sleep) {
	Hud::New( %name, %x, %y, %w, %h, %wake, %sleep, "shaded" );
}

//add a component to a hud
function Hud::Add( %name, %addname ) {
	if ( $Hud::Huds[%name] )
		addToSet( %name, %addname );
}

//
//gui open/close functions
//

function Hud::Store( %i ) {
	%handle = $Hud::Huds[%i];
	%name = $Hud::Huds[%i, name];
	$pref::hudPositions[%name] = (%handle.position) ~ "||" ~ (%handle.fracPos);
}

function Hud::Restore( %i ) {
	%handle = $Hud::Huds[%i];
	%name = $Hud::Huds[%i, name];
	%saved = $pref::hudPositions[%name];
	if ( %saved != "" ) {
		if ( String::explode( %saved, "||", "fields" ) == 2 ) {
			%handle.position = $fields[0];
			%handle.fracPos = $fields[1];
		}
	}
}

function Hud::OnGuiOpen( %gui ) {
	if ( %gui != "playGui" )
		return;
	
	for ( %i = 0; %i < $Hud::Count; %i++ ) {
		%handle = $Hud::Huds[%i];
		Hud::Restore( %i );
		addToSet( %gui, %handle );
		*$Hud::Huds[%i, wake]();
	}
}

function Hud::OnGuiClose( %gui ) {
	if ( %gui != "playGui" )
		return;

	for ( %i = 0; %i < $Hud::Count; %i++ ) {
		%handle = $Hud::Huds[%i];
		Hud::Store( %i );
		removeFromSet( %gui, %handle );
		*$Hud::Huds[%i, sleep]();
	}
}

//clean up so we dont leave our garbage in play.gui
function Hud::OnExit() {
	for ( %i = 0; %i < $Hud::Count; %i++ ) {
		%handle = $Hud::Huds[%i];
		Hud::Store( %i );
		removeFromSet( playGui, %handle );
		deleteObject( %handle );
	}
}

//Hud position fix - Hunden/ Greyhound
$HudMessupFix::DoExport = false;
function HudMessupFix::OnGuiOpen( %gui ) after Hud::OnGuiOpen {
	if ( %gui == "playGui" )
		$HudMessupFix::DoExport = true;
}
function HudMessupFix::OnExit() before Hud::OnExit 
{
	if($HudMessupFix::DoExport) //fine, don't halt
		return;	
	echo("Sucky behavior detected and prevented.");
	halt;
}


Hud::Init();

Event::Attach(eventGuiClose, Hud::OnGuiClose);
Event::Attach(eventGuiOpen, Hud::OnGuiOpen);
Event::Attach(eventExit, Hud::onExit);