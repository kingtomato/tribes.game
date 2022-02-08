// filtering white messages for 1.40

$Filterid = -1;
$Filter[$Filterid++] = " falls to ";
$Filter[$Filterid++] = " forgot to tie ";
$Filter[$Filterid++] = " bites the dust in a forceful manner.";
$Filter[$Filterid++] = " fall down go boom.";
$Filter[$Filterid++] = " makes quite an impact on ";
$Filter[$Filterid++] = " becomes the victim of a fly-by from ";
$Filter[$Filterid++] = " leaves a nasty dent in ";
$Filter[$Filterid++] = " you scratched my paint job!";
$Filter[$Filterid++] = " ventilates ";
$Filter[$Filterid++] = " an overdose of lead.";
$Filter[$Filterid++] = " full of holes.";
$Filter[$Filterid++] = " guns down ";
$Filter[$Filterid++] = " dies of turret trauma.";
$Filter[$Filterid++] = " walks into a stream of turret fire.";
$Filter[$Filterid++] = " ends up on the wrong side of a turret.";
$Filter[$Filterid++] = " feels the warm glow of ";
$Filter[$Filterid++] = " a white-hot plasma injection.";
$Filter[$Filterid++] = " Got plasma?";
$Filter[$Filterid++] = " a plasma transfusion.";
$Filter[$Filterid++] = " catches a Frisbee of Death thrown by ";
$Filter[$Filterid++] = " with a well-placed disc.";
$Filter[$Filterid++] = " spinfusor caught ";
$Filter[$Filterid++] = " falls victim to ";
$Filter[$Filterid++] = " up real good.";
$Filter[$Filterid++] = " explosive temper.";
$Filter[$Filterid++] = " a fatal concussion.";
$Filter[$Filterid++] = " never saw it coming from ";
$Filter[$Filterid++] = " list of sniper victims.";
$Filter[$Filterid++] = " with a sniper shot.";
$Filter[$Filterid++] = " becomes a victim of ";
$Filter[$Filterid++] = " crosshairs for too long.";
$Filter[$Filterid++] = " into oblivion.";
$Filter[$Filterid++] = " didn't see that last mortar from ";
$Filter[$Filterid++] = " inflicts a mortal mortar wound on ";
$Filter[$Filterid++] = " mortar takes out ";
$Filter[$Filterid++] = " gets a blast out of ";
$Filter[$Filterid++] = " rain of blaster fire.";
$Filter[$Filterid++] = " a new world of pain.";
$Filter[$Filterid++] = " master blaster.";
$Filter[$Filterid++] = " gets zapped with ";
$Filter[$Filterid++] = " a nasty jolt.";
$Filter[$Filterid++] = " gets a real shock out of meeting ";
$Filter[$Filterid++] = " short-circuits ";
$Filter[$Filterid++] = " didn't stay away from the moving parts.";
$Filter[$Filterid++] = " is crushed.";
$Filter[$Filterid++] = " gets smushed flat.";
$Filter[$Filterid++] = " gets caught in the machinery.";
$Filter[$Filterid++] = " is a victim among the wreckage.";
$Filter[$Filterid++] = " is killed by debris.";
$Filter[$Filterid++] = " becomes a victim of collateral damage.";
$Filter[$Filterid++] = " got too close to the exploding stuff.";
$Filter[$Filterid++] = " takes a missile up the keister.";
$Filter[$Filterid++] = " gets shot down.";
$Filter[$Filterid++] = " gets real friendly with a rocket.";
$Filter[$Filterid++] = " feels the burn from a warhead.";
$Filter[$Filterid++] = " ends it all.";
$Filter[$Filterid++] = " own life.";
$Filter[$Filterid++] = " own dumb self.";
$Filter[$Filterid++] = " decides to see what the afterlife is like.";
$Filter[$Filterid++] = " teammate, ";
$Filter[$Filterid++] = " dies";



function filterwhites( %cl, %msg, %type )
	after onClientMessage {
  
	if(%type != 0)
		return;
    
	%ret = true;
	
	for(%i=0;%i<=$Filterid;%i++) {
		if( String::FindSubStr(%msg, $Filter[%i]) != -1 ) {
			%ret = false;
			break;
		}
	}
	return;
}
