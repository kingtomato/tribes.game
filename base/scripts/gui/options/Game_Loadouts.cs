$options::defaultloadout = "OptionsGui::defaultLoadout";
$options::autospew = "OptionsGui::spewPacks";
$options::autoshield = "OptionsGui::autoUseShield";
$options::autoloadout = "OptionsGui::autoBuyLoadout";
$options::noenterinv = "OptionsGui::noEnterInv";

function OptionsGame::Loadout::init() {
	Control::setValue( $options::autoshield, $pref::autoUseShield );
	Control::setValue( $options::autospew, $pref::autoSpewPacks );
	Control::setValue( $options::autoloadout, $pref::autoBuyLoadout );
	Control::setValue( $options::noenterinv, $pref::noEnterInv );
	
	FGCombo::clear( $options::defaultloadout );
	for ( %i = 0; %i < 5; %i++ ) {
		%name = $pref::favorites[%i+1, $ServerFavoritesKey, "name"];
		if ( %name == "" )
			%name = "Un-Named Loadout";
		FGCombo::addEntry( $options::defaultloadout, sprintf( "%1. %2", %i + 1, %name ), %i );
	}

	$pref::defaultLoadout = clamp( $pref::defaultLoadout, 0, 4 );
	FGCombo::setSelected( $options::defaultloadout, $pref::defaultLoadout );
}

function OptionsGame::Loadout::shutdown() {
	$pref::defaultLoadout = FGCombo::getSelected( $options::defaultloadout );
}