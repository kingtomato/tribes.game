$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;

function remotePlayMode(%cl) {
	if ( %cl.guiLock )
		return;

	remoteSCOM( %cl, -1 );
	Client::setGuiMode( %cl, $GuiModePlay );
}

function remoteCommandMode(%cl) {
	if ( %cl.guiLock )
		return;

	remoteSCOM( %cl, -1 );  // force the bandwidth to be full command
	if( %cl.observerMode != "pregame" )
		checkControlUnmount( %cl );

	Client::setGuiMode( %cl, $GuiModeCommand );
}

function remoteInventoryMode(%cl) {
	if ( %cl.guiLock || Observer::isObserver(%cl) )
		return;

	remoteSCOM(%cl, -1);
	Client::setGuiMode(%cl, $GuiModeInventory);
}

function remoteObjectivesMode(%cl) {
	if ( %cl.guiLock )
		return;

	remoteSCOM(%cl, -1);
	Client::setGuiMode(%cl, $GuiModeObjectives);
}

function remoteScoresOn(%cl) {
	if( !%cl.menuMode )
		Game::menuRequest(%cl);
}

function remoteScoresOff(%cl) {
	Client::cancelMenu(%cl);
}

function remoteToggleCommandMode(%cl) {
	if ( Client::getGuiMode(%cl) != $GuiModeCommand )
		remoteCommandMode(%cl);
	else
		remotePlayMode(%cl);
}

function remoteToggleInventoryMode(%cl) {
	if (Client::getGuiMode(%cl) != $GuiModeInventory)
		remoteInventoryMode(%cl);
	else
		remotePlayMode(%cl);
}

function remoteToggleObjectivesMode(%cl) {
	if (Client::getGuiMode(%cl) != $GuiModeObjectives)
		remoteObjectivesMode(%cl);
	else
		remotePlayMode(%cl);
}

function Client::setInventoryText(%cl, %txt)
{
   remoteEval(%cl, "ITXT", %txt);
}