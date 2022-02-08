// evita's isht - 1.40 version from alarik (meaning i changed nothing just like anubis does)

// Ill put some directions in this one I guess.  If you want to make
// a quick popup hud to display whatever information, this is for you.
// It gives you a bit more power than the normal remote print functions
// in Tribes, plus it does not conflict with them.  I might add more
// features to this in a future release, but dont hold your breath.
//
// If you are familiar with the remote print functions, this will be
// a cakewalk for ya.  Here is how to use remoteEP (ya, E stands for 
// Evita, shuddup).
//
// remoteEP(%msg, %time, %bg, %lines, %liney, %hudx);
//
// Definition of parameters:
// %msg   = The message you want to display.  Of course, you can use
//          string tags (<jc><f2>, etc.)  Keep in mind, the only font
//          I include with my pack is the white (<f2>), so if you use
//	    <f0> or <f1> it will be a normal Tribes font.
// %time  = The time in seconds you want the message to be displayed.
// %bg    = Show a background or make transparant.
// %lines = How many lines the hud will be.  Remember, for each '\n'
//	    tag that you use, you would +1 to %lines.
// %liney = This is the height of each line.
// %hudx  = The width of the hud.
//
// If you only want to display a simple one line message, you only have
// to use the first two parameters, and the others will use default settings.
// Example: remoteEP("<jc><f2>Just a one line message", 3);
// Or, for more advanced stuff:
// Example: remoteEP("<jc><f2>One Line\nTwo Line\nThree line", 5, false, 3, 16, 120);
// On a side note, this hud will always top print.  This is because I run
// with my huds at the bottom of the screen.  If you want to change this for
// your setup, go into the remoteEP function below, and change the %ypos.
//
// There ya go.

function remoteEP::Init() {

	$remoteEP::Container = newObject("remoteEP",      SimGui::Control,      0, 0, 0, 0);
	%remoteEP::BG        = newObject("remoteEP_BG",   FearGui::FearGuiMenu, 0, 0, 0, 0);
	%remoteEP::Text      = newObject("remoteEP_Text", FearGuiFormattedText, 0, -2, 0, 0);

	addToSet($remoteEP::Container, %remoteEP::BG);
	addToSet($remoteEP::Container, %remoteEP::Text);

	Control::setVisible("remoteEP", false);
}

function remoteEP::GuiOpen(%gui) {

	if(%gui != playGui)
	  return;

	addToSet(playGui, $remoteEP::Container);
}

function remoteEP::GuiClose(%gui) {

	if(%gui != playGui)
	  return;

	removeFromSet($remoteEP::Container);
}

function remoteEP::Destroy() {

	deleteObject($remoteEP::Container);
}

function remoteEP(%msg, %time, %bg, %lines, %liney, %hudx) {

	schedule::cancel("Control::setVisible(remoteEP, false);");

	// if %hudx parameter not passed, default to 200
	if(%hudx == "")
	  %hudx = 1920 - 200;

	// always centers the hud (x) with the screen
	%xpos = (1920 - %hudx) / 2;

	// if %liney parameter not passed, default to 18
	if(%liney == "")
	  %liney = 18;

	// if %lines parameter not passed, default to 1
	if(%lines == "")
	  %lines = 1;

	%ysiz = %lines * %liney;
	
	// position from top of screen
	%ypos = 800;

	// if %bg parameter not passed, default to true
	if(%bg == "")
	  %bg = true;

	Control::SetPosition("remoteEP", %xpos, %ypos);
	Control::setExtent("remoteEP", %hudx, %ysiz);
	Control::setExtent("remoteEP_BG", %hudx, %ysiz);
	Control::setVisible("remoteEP_BG", %bg);
	Control::setVisible("remoteEP", true);
	Control::setValue("remoteEP_Text", %msg);

	schedule::add("Control::setVisible(remoteEP, false);", %time);
}

function remoteEPoff()
{
	Control::setVisible(remoteEP, false);
}

Event::Attach(eventGuiClose, remoteEP::GuiClose);
Event::Attach(eventGuiOpen, remoteEP::GuiOpen);
Event::Attach(eventExit, remoteEP::Destroy);

remoteEP::Init();


