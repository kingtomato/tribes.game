
Starsiege TRIBES
----------------

Release 1.11
4.28.00

This patch addresses several client-side cheats. These are listed at the
end of this file. The complete history of changes since version 1.0 can be
found in the release.txt file.

IMPORTANT NOTE! This patch incorporates server authentication of critical
models, such as flags, weapons and mines. If you are using modified versions
of these shape (.dts) files, you may get an error message when you attempt to
join a version 1.11 server. To fix this problem, delete any modified shape files
you may have in your base directory. Note that some resources are shared, and
the error message you get may be misleading (e.g. cameras and turrets share
some textures, so a modified turret may give a error message mentioning cameras).
If you can't find the custom models or keep getting the error message, uninstall
TRIBES and apply the 1.0 to 1.11 patch.


Install
-------

To install this release, download the appropriate patch executable, run
the patch and then follow the instructions. (Note: the version you are
currently running is visible on the title screen in the lower right-hand
corner).

If you currently have version 1.0 of TRIBES, then you need to download
the file Tribes10to1115.exe.

If you currently have version 1.105 of TRIBES, then you need to download
the file Tribes1105to111.exe.


The patch may fail for several reasons:

   - You may have the wrong patch. Make sure you have the patch which
     takes you from your current version to this patch version.
   - You may have installed an early mod.  Some of the first mods
     incorrectly modified the contents of certain files.  The patch 
     will not update these files and will report an error. You will have
     to re-install TRIBES before you can install the patch.
   - You need about 20Megs of hard disk space to install the patch,
     this space is used to temporarily store files and will be recovered
     when the install is finished.
   - You have a virus which is attached to the Tribes executable. Run
     virus scanning software to detect and remove the virus.  If a virus
     is detected, then you will have to re-install tribes off of your
     CD-ROM and apply the 10to111 patch.

If the patch should fail, TRIBES will be restored to the state it was
in before the patch install program was run.  If you should run into
problems other than running out of disk space, we recommend that
you re-install TRIBES off of your CD-ROM and use the 10to111 patch.


Modified Files
--------------

This release includes changes to a number of files.  The patch program
will modify these files to bring them up to date.  General files:

    readme111.txt         - This readme file
    release.txt           - Release notes
    Tribes.exe
    sierra.inf
    scripts.vol


OpenGL Support
--------------

OpenGL support is included in the 1.11 version of TRIBES.

If your video card supports accelerated OpenGL, it should be available
in the Options/Video dialog.  If it does not appear, check the
troubleshooting tips below. Select OpenGL as the fullscreen device, and
set the "Setup OpenGL for:" combobox to your card type.  TRIBES has
selections for the TNT/TNT2/TNT2 Ultra and i740 chipsets, and
a "Generic" setting for other cards. If your card falls into the "Generic"
category and you are recieve sub optimal performance you should go to your 
card manufactorers website and download their latest drivers. 
(Picky detail note: i740 is equivalent to "Generic", the entry is
present for backwards compatability with config.cs files generated
by TRIBES 1.5 and earlier).

If you are using OpenGL as your hardware accelerator, running in 32-bit 
mode will improve your z-buffering (thus eliminating the effect where you 
could see through buildings at a distance), however, you may take a 
framerate hit as compared to 16-bit mode.  Switching between 32- and 16-bit 
modes can only be done by changing your desktop resolution in Windows.


Global OpenGL issues
--------------------

There are some visual artifacts that will occur as a result of the way
TRIBES handles the depth coordinate.  We are working to resolve these.
They will be especially visible if you are running on a Riva128.  They
do not affect performance or gameplay in any way, but they're annoying.

While the OpenGL performance has been greatly improved, there are still
some occasional pauses that occur.  You may notice these when viewing
the terrain for the first time on certain levels.

Switching from fullscreen Glide/Software mode to fullscreen OpenGL on some cards
will crash TRIBES.  You can work around this by switching to windowed software 
mode before entering OpenGL mode.

If you are running in OpenGL and occasionally TRIBES crashes you can often 
alleviate this by changing your virtual memory settings to 200 megs minimum and 
maximum. This can be accessed by going to your control panel and selecting system. 
You will find it on the performance tab. Note: changing your virtual memory settings 
is not recommended for novice users. 


TNT issues
----------

The latest "Detonator" driver set is required.  Available at http://www.nvidia.com

At the time of the release of the 1.11 patch, the latest version of the TNT drivers 
was 3.68.  We recommend using this version.

Riva128 issues
--------------

There are some problems with the z-buffering of artifacts.  This does not affect gameplay, 
but can be visually annoying.

To get the correct additive blending effects for projectiles, weapons, etc., open the 
console.cs file and change:
  
$pref::OpenGL::NoAddFade = false; 

to

$pref::OpenGL::NoAddFade = true; 


i740 issues
-----------

Switching from fullscreen software mode to fullscreen OpenGL on an i740 
will crash TRIBES.  You can work around this by switching to windowed software 
mode before entering OpenGL mode.

Visit your card suppliers website for the latest version of the card's drivers.
You can find links to manufacturers' drivers at
http://developer.intel.com/design/graphics/740/solutions/index.htm.  Reference
Intel drivers can be found at
http://developer.intel.com/design/graphics/drivers/index.htm.
  

OpenGL Troubleshooting Tips
---------------------------

TRIBES no longer filters OpenGL drivers that return the name "GDI
Generic."  This means that if you do not have the proper drivers
installed, TRIBES will use the software implementation provided by
Microsoft.  If you notice that your application is running unreasonably
slow, first try checking that your desktop resolution is set to 16 bits.
Next, make sure that you have the correct drivers.  This should resolve the 
problem.


Joystick (1.1 patch)
--------------------

If you wish to activate your joystick, rename the joystick.cs file in
your tribes\config directory to "autoexec.cs".  If you already have an
autoexec.cs file (there is none by default), append the contents of
joystick.cs to the end of the autoexec.cs file.

Joystick.cs is a plain text file, and contains some comments on tweaking
your joystick settings that you may want to read.  The instructions in
the file will bind your joystick Y axis to player movement forward/backward
and the X axis to strafe left/right.  We are compiling a list of other
avialable actions and will post this list on the www.tribesplayers.com
web site.

Activating your joystick will cause any keys bound to player movement
to no longer work.


Detailed List of Changes
------------------------

- Added server model authentication to fix the following cheats:
	* terrain haze/sky reload cheats
	* additional lights cheat
	* beacon cheat
	* replaced model cheat (e.g. "happy flags")



TRIBES



CONTACTING SIERRA
=================

A) Customer Service, Support, and Sales
B) Technical Support
C) Legal Information


A) Customer Service, Support, and Sales
----------------------------------
United States	

U.S.A. Sales Phone: (800) 757-7707
International Sales:  (425) 746-5771 
Hours: Monday-Saturday 7AM to 11 PM CST,
Sundays 8 AM to 9PM CST 
FAX: (402) 393-3224	
	
Sierra Direct				
7100 W. Center Rd			
STE 301				
Omaha, NE  68106			

United Kingdom

Havas Interactive 	
Main: (0118) 920-9111
Monday-Friday, 9:00 a.m. - 5:00 p.m.
Fax:   (0118) 987-5603
Disk/CD replacements in the U.K. are £6.00,
or £7.00 outside the UK. Add "ATTN.: Returns."

2 Beacontree Plaza,			
Gillette Way,				
Reading, Berkshire			
RG2 0BS United Kingdom		


France

Havas Interactive 
Téléphone: 01-46-01-46-50
Lundi au Jeudi de 10h à 19h
Vendredi de 10h à 18h
Fax: 01-46-30-00-65

Parc Tertiaire de Meudon		
Immeuble "Le Newton"		
25 rue Jeanne Braconnier 		
92366 Meudon La Forêt Cedex
France


Germany

Havas Interactive  	
Tel: (0) 6103-99-40-40
Montag bis Freitag von 9h - 19Uhr
Fax: (0) 6103-99-40-35

Robert-Bosh-Str. 32			
D-63303 Dreieich			
Germany


On-Line Sales

CompuServe United Kingdom:GO UKSIERRA
CompuServe France:	  GO FRSIERRA
CompuServe Germany:  	  GO DESIERRA
Internet USA:		  http://www.sierra.com
Internet United Kingdom:  http://www.sierra-online.co.uk
Internet France:  	  http://www.sierra.fr
Internet Germany:	  http://www.sierra.de

Disk and or Manual Replacement:		

Product Returns:
Sierra On-Line Returns
4100 West 190th Street
Torrance, CA  90504

Sierra On-Line Fulfillment	
4100 West 190th Street		
Torrance, CA  90504				
		
NOTE: To replace your disk(s) please send only Disk #1 (or the CD) and copy of your dated Receipt, if less
than 90 days.  After 90 days please include a $10 handling fee along with Disk / CD #1.  For Documentation,
please include a $ 5.00 handling fee and a photocopy ONLY of disk #1.  Payment should be made at the time of
your request.  Sorry, no credit cards.	

* Returns to this address valid in North America only.


B) TECHNICAL SUPPORT
-------------------------
North America

Sierra On-Line offers a 24-hour automated technical support line with recorded answers to the most frequently
asked technical questions. To access this service, call (425) 644-4343, and follow the recorded instructions
to find your specific topic and resolve the issue. If this fails to solve your problem, you may still write,
or fax us with your questions, or contact us via our Web site.

Sierra On-Line				
Technical Support
P.O. Box 85006			
Bellevue, WA 98015-8506	

Main: (425) 644-4343
Monday-Friday, 8:00 a.m.- 4:45 p.m.  PST 
Fax:   (425) 644-7697

http://www.sierra.com
support@sierra.com


United Kingdom

Havas Interactive offers a 24-hour Automated Technical Support line with recorded answers to the most
frequently asked technical questions. To access this service, call (0118) 920-9111, and follow the recorded
instructions to find your specific topic and resolve the issue. If this fails to solve your problem, you may
still write, or fax us with your questions, or contact us via our Internet or CompuServe sites.

Havas Interactive 	
2 Beacontree Plaza,			
Gillette Way,				
Reading, Berkshire			
RG2 0BS United Kingdom	

Main: (0118) 920-9111
Monday-Friday, 9:00 a.m. - 5:00 p.m.
Fax:   (0118) 987-5603

http://www.sierra-online.co.uk


France

Havas Interactive 
Parc Tertiaire de Meudon		
Immeuble "Le Newton"		 
25 rue Jeanne Braconnier		
92366 Meudon La Forêt Cedex	
France

Téléphone: 01-46-01-46-50
Lundi au Jeudi de 10h à 19h
Vendredi de 10h à 18h
Fax: 01-46-30-00-65

http://www.sierra.fr


Germany

Havas Interactive 
Robert-Bosh-Str. 32			
D-63303 Dreieich			
Deutschland				

Tel: (0) 6103-99-40-40
Montag bis Freitag von 9 - 19Uhr
Fax: (0) 6103-99-40-35
Mailbox: (0) 6103-99-40-35

http://www.sierra.de


Spain

Havas Interactive 
Avenida de Burgos 9			
1º-OF2					
28036 Madrid
Spain

Teléfono: (01) 383-2623
Lunes a Viernes de 9h30 a 14h y de 15h a 18h30
Fax: (01) 381-2437


Italy

Contattare il vostro distribotore.	


C) Sierra Warranty & Legal Information
-----------------------------------
You are entitled to use this product for your own use, but may not copy, reproduce, translate, publicly
perform, display, or reduce to any electronic medium or machine- readable form, reproductions of the software
or manual to other parties in any way, nor sell, rent or lease the product to others without prior written
permission of Sierra.  You may use one copy of the product on a single computer.  YOU MAY NOT NETWORK THE
PRODUCT OR OTHERWISE INSTALL IT OR USE IT ON MORE THAN ONE COMPUTER AT THE SAME TIME.
UNAUTHORIZED REPRESENTATIONS: SIERRA WARRANTS ONLY THAT THE PROGRAM WILL PERFORM AS DESCRIBED IN THE USER
DOCUMENTATION. NO OTHER ADVERTISING, DESCRIPTION, OR REPRESENTATION, WHETHER MADE BY A SIERRA DEALER, DISTRIBUTOR,
AGENT, OR EMPLOYEE, SHALL BE BINDING UPON SIERRA OR SHALL CHANGE THE TERMS OF THIS WARRANTY.
IMPLIED WARRANTIES LIMITED: EXCEPT AS STATED ABOVE, SIERRA MAKES NO WARRANTY, EXPRESS OR IMPLIED, REGARDING THIS
PRODUCT. SIERRA DISCLAIMS ANY WARRANTY THAT THE SOFTWARE IS FIT FOR A PARTICULAR PURPOSE, AND ANY IMPLIED WARRANTY
OF MERCHANTABILITY SHALL BE LIMITED TO THE NINETY (90) DAY DURATION OF THIS LIMITED EXPRESS WARRANTY AND IS
OTHERWISE EXPRESSLY AND SPECIFICALLY DISCLAIMED. SOME STATES DO NOT ALLOW LIMITATIONS ON HOW LONG AN IMPLIED
WARRANTY LASTS, SO THE ABOVE LIMITATION MAY NOT APPLY TO YOU.
NO CONSEQUENTIAL DAMAGES: SIERRA SHALL NOT BE LIABLE FOR SPECIAL, INCIDENTAL, CONSEQUENTIAL OR OTHER DAMAGES,
EVEN IF SIERRA IS ADVISED OF OR AWARE OF THE POSSIBILITY OF SUCH DAMAGES. THIS MEANS THAT SIERRA SHALL NOT BE
RESPONSIBLE OR LIABLE FOR LOST PROFITS OR REVENUES, OR FOR DAMAGES OR COSTS INCURRED AS A RESULT OF LOSS OF TIME,
DATA OR USE OF THE SOFTWARE, OR FROM ANY OTHER CAUSE EXCEPT THE ACTUAL COST OF THE PRODUCT. IN NO EVENT SHALL
SIERRA'S LIABILITY EXCEED THE PURCHASE PRICE OF THIS PRODUCT. SOME STATES DO NOT ALLOW THE EXCLUSION OR LIMITATION
OF INCIDENTAL OR CONSEQUENTIAL DAMAGES, SO THE ABOVE LIMITATION OR EXCLUSION MAY NOT APPLY TO YOU.
Copyright (1999 Sierra On-Line, Inc.)  
  
  
