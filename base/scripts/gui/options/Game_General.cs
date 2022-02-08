$options::resetzoom = "OptionsGui::resetZoom";
$options::defaultzoom = "OptionsGui::defaultZoomLevel";
$options::autowp = "OptionsGui::waypointPreference";

$options::oobvisible = "OptionsGui::oobVisible";
$options::oobopacity = "OptionsGui::oobOpacitySlider";
$options::oobdistance = "OptionsGui::oobVisDistance";

function OptionsGame::General::init() {
	Control::setValue( $options::resetzoom, $pref::resetZoom );
	
	FGCombo::clear( $options::defaultzoom );
	FGCombo::addEntry( $options::defaultzoom, "1. Zoom 2x", 0 );
	FGCombo::addEntry( $options::defaultzoom, "2. Zoom 5x", 1 );
	FGCombo::addEntry( $options::defaultzoom, "3. Zoom 10x", 2 );
	FGCombo::addEntry( $options::defaultzoom, "4. Zoom 20x", 3 );
	
	$pref::defaultZoom = clamp( $pref::defaultZoom, 0, 3 );
	FGCombo::setSelected( $options::defaultzoom, $pref::defaultZoom );

	FGCombo::clear( $options::autowp );
	FGCombo::addEntry( $options::autowp, "1. Manual", 0 );
	FGCombo::addEntry( $options::autowp, "2. Friendly Capper", 1 );
	FGCombo::addEntry( $options::autowp, "3. Enemy Capper", 2 );

	$pref::carrierAutoWaypoint = clamp( $pref::carrierAutoWaypoint, 0, 2 );
	FGCombo::setSelected( $options::autowp, $pref::carrierAutoWaypoint );
	
	Control::setValue( $options::oobopacity, $pref::OOBGridAlpha );
	Control::setValue( $options::oobdistance, $pref::OOBGridPercent );	
	Control::setValue( $options::oobvisible, $pref::OOBGridVisible );
}

function OptionsGame::General::shutdown() {
	$pref::carrierAutoWaypoint = FGCombo::getSelected( $options::autowp );
	$pref::defaultZoom = FGCombo::getSelected( $options::defaultzoom );
	$pref::OOBGridAlpha = Control::getValue( $options::oobopacity );
	$pref::OOBGridPercent = Control::getValue( $options::oobdistance );		
}

function OptionsGame::Game::onOOBGrid() {
   %oobVisible = Control::getValue( $options::oobvisible );
	Control::setActive( $options::oobdistance, %oobVisible );
	Control::setActive( $options::oobopacity, %oobVisible );
	$pref::OOBGridVisible = %oobVisible;  
}
