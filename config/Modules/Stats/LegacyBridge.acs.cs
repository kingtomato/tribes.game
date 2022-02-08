/*
	MESSAGING
*/

function onClientMessageLegacy( %cl, %msg, %type ) {
	%muted = false;
	%index = String::findSubStr( %msg, "~" );
	if ( %index != -1 ) {
		%tags = String::getSubStr( %msg, %index + 1, 10000 );
		%msg = String::getSubStr( %msg, 0, %index );
	}
	
	if (%client) {
	} else {
		%handled = false;

		if ( String::FindSubStr( %msg, "Station " ) != -1 ) {
			if (%msg == "Station Access On") {
				remoteEnterStation( 2048, $Event::Station );
				%handled = true;
			} else if (%msg == "Station Access Off") {
				remoteExitStation( 2048, $Event::Station );
				$Event::Station = "";
				%handled = true;
			}
		}

		if ( !%handled && ( String::FindSubStr(%msg, " flag") != -1 ) ) {
			%returns = Event::Trigger( eventFlagMessage, %msg );
			%handled = %returns;
		}

		if ( !%handled && ( %msg == "Match started." ) ) {
			remoteMatchStarted( 2048 );
			%handled = true;
		}
	}

    return !%muted;
}

// $Event::Station (station types..)
function remoteINV( %msg ) { 
	if( String::findSubStr( %msg, "STATION ENERGY" ) != -1 ) 
		$Event::Station = "RemoteInventory";
	else 
		$Event::Station = "Inventory";
}

function remoteITXT( %sv, %msg ) {
	Control::setValue(EnergyDisplayText, %msg); 
	remoteINV( %msg );
}

/*
	FLAG EVENTS
*/

Event::Attach( eventFlagMessage, Legacy::flagEvents );

function Legacy::flagEvents( %msg ) {
	if (%msg == "You couldn't buy Flag")
		return "mute";
	
	%event = "";
	%id = 0;
	
	if( ( %idx = String::FindSubStr( %msg, " took the" ) ) != -1 ) {
		%name = String::GetSubStr(%msg, 0, %idx); 
		if ( %name == "You") 
			%name = Client::getName(getManagerId());
		%id = getClientByName( %name );
		%team = Client::GetTeam( %id ) ^ 1;
		%event = "FlagTaken";	
	} else if ( ( %idx = String::FindSubStr( %msg, " dropped the" ) ) != -1 ) {
		%name = String::GetSubStr(%msg, 0, %idx); 
		if ( %name == "You") 
			%name = Client::getName(getManagerId());
		%id = getClientByName( %name );
		%team = Client::GetTeam( %id ) ^ 1;
		%event = "FlagDropped";
	} else if ( ( %idx = String::FindSubStr(%msg, " returned the" ) ) != -1 ) {
		%name = String::GetSubStr(%msg, 0, %idx); 
		if ( %name == "You") 
			%name = Client::getName(getManagerId());
		%id = getClientByName( %name );
		%team = Client::GetTeam( %id );
		%event = "FlagReturned";
	} else if( ( %idx = String::FindSubStr( %msg, " captured the" ) ) != -1 ) {
		%name = String::GetSubStr(%msg, 0, %idx); 
		if ( %name == "You") 
			%name = Client::getName(getManagerId());
		else if ( %name == "Your Team" )
			return;
		%id = getClientByName( %name );
		%team =  Client::GetTeam( %id ) ^ 1;
		%event = "FlagCaptured";
	} else if ( (%idx = String::FindSubStr( %msg, " left the mission" ) ) != -1 ) {
		%name = String::GetSubStr(%msg, 0, %idx); 
		if ( %name == "You") 
			%name = Client::getName(getManagerId());
		%id = getClientByName( %name );
		%team = Client::GetTeam( %id ) ^ 1;
		%event = "FlagReturned";
	}

	if ( %id == 0 || %event == "" )
		return false;
	*"remote"~%event( 2048, %team, %id );
	return true;
}

/*
	KILLS
*/

////////////////////////////////////////////////////////////
// File:	KillTrak.cs
// Version:	3.3b
// Author:	Runar
// Credits:	Daerid
// Modified:Andrew
// Info:	Message parsing killtrack
//
// History:	3.3 Initial Version
//			3.3b Andrew Remix (Fixes Client name exploits)
//
////////////////////////////////////////////////////////////

function KillTrak::DeathMessage(%msg, %weapon) 
{
	//[Andrew]: I've never seen a %4 for a second gender indicator so I stripped
	//the extra message declarations to converse memory

	// Strip out the %1,%2 so we have a base message to compare to, and store a weapon for that message
	$KillTrak::Weapon[sprintf(%msg,"","","his")] = %weapon;
	$KillTrak::Weapon[sprintf(%msg,"","","her")] = %weapon;

	// Check to see the format for this msg
	%pos["%1"] = String::FindSubStr(%msg, "%1");
	%pos["%2"] = String::FindSubStr(%msg, "%2");

	%kfirst = (%pos["%1"] < %pos["%2"]);

	$KillTrak::KillerFirst[sprintf(%msg,"","","his")] = 
	$KillTrak::KillerFirst[sprintf(%msg,"","","her")] = %kfirst;

	%single = (%pos["%1"] == -1);

	$KillTrak::Single[sprintf(%msg,"","","his")] = 
	$KillTrak::Single[sprintf(%msg,"","","her")] = %single;
}

function KillTrak::Parse(%msg)
{
	%names = 0;

	for(%i = 1; %i <= $Team::Client::Count; %i++)
	{
		%name = $Team::Client::Name[ $Team::Client::List[%i] ];

		//[Andrew]: We need to keep track of EVERY player name that is found in the message
		//			e.g. If Bob, Bobber, Bobb, and Bobble are all in the server, there will undoubtedly be
		//				 name clashes.

		//if we found this players name in the msg, add it to the list
   		if((%pos = String::FindSubStr(%msg, %name))!= -1)
		{
			echo("Killtrack: Found possible name: " @ %name);
			%name[%names] = %name;
			%pos[%names] = %pos;
			%names++;
		}
	}
	
	//no names found
	if(%names == 0)
		return;

	%res = false;	
	//single name in the message
	if (%names == 1)
		%res = KillTrak::TestSingle(%msg, %name0);
	//normal 2 names found
	else if (%names == 2)
		%res = KillTrak::TestPair(%msg, %name0, %name1);
	//multiple names found, must test every combination
	else
	{
		//test every name combination, halt on a positive
		for (%i = 0; (%i < %names) && !%res; %i++)
			for (%j = %i+1; (%j < %names) && !%res; %j++)
				{
					echo("Killtrack:: Testing " @ %name[%i] @ " & " @ %name[%j]);
					if (KillTrak::TestPair(%msg, %name[%i], %name[%j]))
						%res = true;
				}
	}
			
	if (%res)
	{
		echo("Kill! Victim: " @ $KillTrak::Victim @ " Killer: " @ $killTrak::Killer @ " Weapon: " @ $killTrak::Weapon);
		remoteKillTrak( 2048, $killTrak::Killer, $KillTrak::Victim, $killTrak::Weapon );
	}
	return ;//mute;
}

function KillTrak::Reset() 
{
	deleteVariables("$KillTrak::*");
}

function KillTrak::TestSingle(%msg, %name)
{
	if (%name == "")
		return false;

	%found = 0;
	%namelen = String::Len(%name[%i]);

	%tmsg = %msg;
	%chopped = 0;

	//find the # of occurances for the name
	while ( (%idx = String::FindSubStr(%tmsg, %name)) != -1 )
	{
		%pos[%found] = %idx + %chopped;	//record the position, modified for the previously chopped names
		%chopped += %namelen;

		//strip this occurance from the test string
		%tmsg = String::GetSubStr(%tmsg, 0, %idx) @ String::GetSubStr(%tmsg, %idx + %namelen, 1024); 
		
		%found++;
	}

	//test each instance of the name for a positive match
	for (%i = 0; %i < %found; %i++)
	{
		%base = String::GetSubStr(%msg, 0, %pos[%i]) @ 
				String::GetSubStr(%msg, %pos[%i] + %namelen, 1024);

		//did this name fit a kill message?
		if ((%wpn = $KillTrak::Weapon[%base]) != "")
		{
			if ($KillTrak::Single[%base])
			{
				//already know this is single
				$KillTrak::Killer = $KillTrak::Victim = getClientByName(%name);
				$KillTrak::Weapon = %wpn;
			
				return true;
			}
		}
	}

	return false;
}

function KillTrak::TestPair(%msg, %name0, %name1)
{
	if ((%name0 == "") && (%name1 != ""))
		return KillTrak::TestSingle(%msg, %name1);
	else if ((%name0 != "") && (%name1 == ""))
		return KillTrak::TestSingle(%msg, %name0);
	else if ((%name0 == "") && (%name1 == ""))
		return false;

	echo("Killtrack: Testing: " @ %name0 @ " & " @ %name1);

	//find the # of occurances for each name
	for (%i = 0; (%i < 2); %i++)
	{
		%found[%i] = 0;
		%namelen[%i] = String::Len(%name[%i]);

		%tmsg = %msg;
		%chopped = 0;
		while ( (%idx = String::FindSubStr(%tmsg, %name[%i])) != -1 )
		{
			%pos[%i, %found[%i]] = %idx + %chopped; //record the position, modified for the previously chopped names
			%chopped += %namelen[%i];

			//strip this occurance from the test string
			%tmsg = String::GetSubStr(%tmsg, 0, %idx) @ String::GetSubStr(%tmsg, %idx + %namelen[%i], 1024);
			
			//increase # found
			%found[%i]++;
		}
	}

	//test each combination of name possibilites
	for (%i = 0; %i < %found[0]; %i++)
	{
		for (%j = 0; %j < %found[1]; %j++)
		{
			//find which name occurance appears first
			if (%pos[0, %i] < %pos[1, %j])
			{
				%first = %pos[0, %i]; 
				%second = %pos[1, %j];
				%firstidx = 0;
				%secondidx = 1;
			}
			else
			{
				%first = %pos[1, %j]; 
				%second = %pos[0, %i];
				%firstidx = 1;
				%secondidx = 0;
			}
			
			//build our test string
			%base = String::GetSubStr(%msg, 0, %first) @ 
					String::GetSubStr(%msg, %first + %namelen[%firstidx], %second - %namelen[%firstidx]) @
					String::GetSubStr(%msg, %second + %namelen[%secondidx], 1024);

			echo("Test string: " @ %base);

			//see if this occurs anywhere
			if ((%wpn = $KillTrak::Weapon[%base]) != "")
			{
				//find who is who
				if ($KillTrak::KillerFirst[%base])
				{
					$KillTrak::Killer = getClientByName(%name[%firstidx]);
					$KillTrak::Victim = getClientByName(%name[%secondidx]);
				}
				else
				{
					$KillTrak::Killer = getClientByName(%name[%secondidx]);
					$KillTrak::Victim = getClientByName(%name[%firstidx]);
				}

				$KillTrak::Weapon = %wpn;
				
				//found it
				return true;
			}
		}
	}

	//didnt, dangit
	return false;
}

// Suicide
KillTrak::DeathMessage("%2 ends it all.", "Suicide");
KillTrak::DeathMessage("%2 takes %3 own life.", "Suicide");
KillTrak::DeathMessage("%2 kills %3 own dumb self.", "Suicide");
KillTrak::DeathMessage("%2 decides to see what the afterlife is like.", "Suicide");

// Disc Launcher
KillTrak::DeathMessage("%2 catches a Frisbee of Death thrown by %1.", "Disc Launcher");
KillTrak::DeathMessage("%1 blasts %2 with a well-placed disc.", "Disc Launcher");
KillTrak::DeathMessage("%1's spinfusor caught %2 by surprise.", "Disc Launcher");
KillTrak::DeathMessage("%2 falls victim to %1's Stormhammer.", "Disc Launcher");

// Chaingun
KillTrak::DeathMessage("%1 ventilates %2 with %3 chaingun.", "Chaingun");
KillTrak::DeathMessage("%1 gives %2 an overdose of lead.", "Chaingun");
KillTrak::DeathMessage("%1 fills %2 full of holes.", "Chaingun");
KillTrak::DeathMessage("%1 guns down %2.", "Chaingun");

// Mines and Grenades
KillTrak::DeathMessage("%1 blows %2 up real good.", "Explosives");
KillTrak::DeathMessage("%2 gets a taste of %1's explosive temper.", "Explosives");
KillTrak::DeathMessage("%1 gives %2 a fatal concussion.", "Explosives");
KillTrak::DeathMessage("%2 never saw it coming from %1.", "Explosives");

// Mortar
KillTrak::DeathMessage("%1 mortars %2 into oblivion.", "Mortar");
KillTrak::DeathMessage("%2 didn't see that last mortar from %1.", "Mortar");
KillTrak::DeathMessage("%1 inflicts a mortal mortar wound on %2.", "Mortar");
KillTrak::DeathMessage("%1's mortar takes out %2.", "Mortar");

// Teamkill
KillTrak::DeathMessage("%1 mows down %3 teammate, %2", "Teamkill");
KillTrak::DeathMessage("%1 killed %3 teammate, %2 with a mine.","Teamkill");

// Laser Rifle
KillTrak::DeathMessage("%1 adds %2 to %3 list of sniper victims.", "Laser Rifle");
KillTrak::DeathMessage("%1 fells %2 with a sniper shot.", "Laser Rifle");
KillTrak::DeathMessage("%2 becomes a victim of %1's laser rifle.", "Laser Rifle");
KillTrak::DeathMessage("%2 stayed in %1's crosshairs for too long.", "Laser Rifle");

// Turret
KillTrak::DeathMessage("%2 dies of turret trauma.", "Turret");
KillTrak::DeathMessage("%2 is chewed to pieces by a turret.", "Turret");
KillTrak::DeathMessage("%2 walks into a stream of turret fire.", "Turret");
KillTrak::DeathMessage("%2 ends up on the wrong side of a turret.", "Turret");
KillTrak::DeathMessage("%2 dies.", "Turret");

// Plasma Gun
KillTrak::DeathMessage("%2 feels the warm glow of %1's plasma.", "Plasma");
KillTrak::DeathMessage("%1 gives %2 a white-hot plasma injection.", "Plasma");
KillTrak::DeathMessage("%1 asks %2, 'Got plasma?'", "Plasma");
KillTrak::DeathMessage("%1 gives %2 a plasma transfusion.", "Plasma");

// Blaster
KillTrak::DeathMessage("%2 gets a blast out of %1.", "Blaster");
KillTrak::DeathMessage("%2 succumbs to %1's rain of blaster fire.", "Blaster");
KillTrak::DeathMessage("%1's puny blaster shows %2 a new world of pain.", "Blaster");
KillTrak::DeathMessage("%2 meets %1's master blaster.", "Blaster");

// Falling
KillTrak::DeathMessage("%2 falls to %3 death.", "Suicide");
KillTrak::DeathMessage("%2 forgot to tie %3 bungie cord.", "Suicide");
KillTrak::DeathMessage("%2 bites the dust in a forceful manner.", "Suicide");
KillTrak::DeathMessage("%2 fall down go boom.", "Suicide");

// Vehicle
KillTrak::DeathMessage("%1 makes quite an impact on %2.", "Vehicle");
KillTrak::DeathMessage("%2 becomes the victim of a fly-by from %1.", "Vehicle");
KillTrak::DeathMessage("%2 leaves a nasty dent in %1's fender.", "Vehicle");
KillTrak::DeathMessage("%1 says, 'Hey %2, you scratched my paint job!'", "Vehicle");

// ELF Gun
KillTrak::DeathMessage("%2 gets zapped with %1's ELF gun.", "Elf Gun");
KillTrak::DeathMessage("%1 gives %2 a nasty jolt.", "Elf Gun");
KillTrak::DeathMessage("%2 gets a real shock out of meeting %1.", "Elf Gun");
KillTrak::DeathMessage("%1 short-circuits %2's systems.", "Elf Gun");

// Debris
KillTrak::DeathMessage("%2 is a victim among the wreckage.", "Explosion");
KillTrak::DeathMessage("%2 is killed by debris.", "Explosion");
KillTrak::DeathMessage("%2 becomes a victim of collateral damage.", "Explosion");
KillTrak::DeathMessage("%2 got too close to the exploding stuff.", "Explosion");

// Missile
KillTrak::DeathMessage("%2 takes a missile up the keister.", "Missile");
KillTrak::DeathMessage("%2 gets shot down.", "Missile");
KillTrak::DeathMessage("%2 gets real friendly with a rocket.", "Missile");
KillTrak::DeathMessage("%2 feels the burn from a warhead.", "Missile");

// Crushed
KillTrak::DeathMessage("%2 didn't stay away from the moving parts.", "Crushed");
KillTrak::DeathMessage("%2 is crushed.", "Crushed");
KillTrak::DeathMessage("%2 gets smushed flat.", "Crushed");
KillTrak::DeathMessage("%2 gets caught in the machinery.", "Crushed");
