$options::minimapautosize = "OptionsGui::miniMapAutoSize";
$options::minimapwidth = "OptionsGui::miniMapWidth";
$options::minimapzoom = "OptionsGui::miniMapZoom";
$options::minimapalpha = "OptionsGui::miniMapAlpha";

function OptionsGame::HUDs::init() {
	FGSlider::setDiscretePositions( $options::minimapalpha, 0 );
	
	Control::setValue( $options::minimapwidth, $pref::miniMapWidth );
	Control::setValue( $options::minimapzoom, $pref::miniMapZoom );
	Control::setValue( $options::minimapalpha, $pref::miniMapAlpha );
	OptionsGame::HUDs::onAutosize();
	echo( Control::getValue( $options::minimapalpha ) );
}

function OptionsGame::HUDs::onAutosize() {
	%widthEnabled = !Control::getValue( $options::minimapautosize );
	Control::setActive( $options::minimapwidth, %widthEnabled );
	Control::setActive( $options::minimapzoom, %widthEnabled );
}

function OptionsGame::HUDs::shutdown() {
	echo( Control::getValue( $options::minimapalpha ) );
	$pref::miniMapAlpha = Control::getValue( $options::minimapalpha );
}