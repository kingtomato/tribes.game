Starsiege TRIBES README  

I:   System Compatibility
II:  Updates And Patches
III: Changes From The Printed Manual
IV:  Hosting A Game
V:   Network Performance Tuning
VI:  Dedicated Servers
VII: Real-Time Chat Programs
VIII:Known Problems
IX:  Troubleshooting
X:   Contacting Sierra
XI:  Technical Support
XII: Warranty and Legal Information
  
  
Thank you for Purchasing Starsiege TRIBES, the ultimate in first-person squad warfare! 

I: System Compatibility 

These are the minimum requirements needed to run Starsiege TRIBES: 

* Pentium 166, 32 MB RAM with 3D Graphics Accelerator 
* Pentium 200, 32 MB RAM without a Graphics Accelerator 
* Platforms: Windows 95/98, Windows NT 4 with Service Pack 3 
* Hardware Requirements: LAN Card or minimum 28.8 kps modem, 4x CD ROM 
* 2D Graphics Card: DirectDraw compatible card (minimum SVGA 640x480 @ 256 colors) 
* 3D Graphics Card: 3Dfx Glide compatible 3D accelerator (recommended) 
* Sound Support: DirectSound compatible sound cards 
* Peripheral Support: Mouse, Keyboard 
* Network Support: Internet, TCP/IP, IPX 

II: Updates and Patches 

Check our website at www.tribesplayers.com for the latest updates and patches to the game.
 
III: Changes from the Printed Manual

Since the time of the printing of the manual and the shipping of the game, there have been 
some changes made to Starsiege TRIBES, resulting in information in the manual being out of 
date.  These changes are: 

* The Laser Rifle will not function unless you are also carrying an energy pack. 
* There are now two default keys for killing your player (suicide) and dropping the flag that 
  can be set in the Options-General screen.  The defaults are set to CTRL-K to kill your 
  player, CTRL-F to drop the flag if you are carrying it. 
* Heavy Armor is listed as being able to hold up to four weapons.  It can actually hold up to five.
* There is now a check box to turn weather effects on and off in the Options-Graphics page. 
* Also in the Options-Graphics Page, the Shadow Detail Level slider bar has been removed.
* There is an additional column (Server Type) listed in the Options-Columns page. 
* There is a new slider bar in the Options-Graphics page called "Num. Decals", which 
  controls the number of footprints and bullet holes that appear during the game.
* In the Options-Sound page, you cannot select DirectSound3D and Aureal from the 3D Sound 
  menu.
* In the Demo Screen, a Continuous Play box has been added.  When checked off, a randomly-
  selected demo from the list will begin playing.  When that demo ends, another randomly 
  selected demo shall begin, and so on.
* There is a new Options screen called "Misc."  Key bindings for favorites and voting are
  listed here.

IV: Hosting A Game 

Hosting a game with more than a few players takes a fair amount of bandwidth. Hosting over 
a 28.8 modem connection is not recommended. There will be several servers running here at 
Dynamix, possibly some up at Sierra NW. For 28.8 modem players, joining a server is 
recommended. 

If you wish to do a little testing without interference, host a game while you are not 
connected to the internet. You can also limit the number of players allowed or require a 
password. 

If you wish to run a dedicated server, read the Dedicated Servers section below. 

V:  Network Performance Tuning

If you have a reliable connection to your ISP, but are still experiencing packet loss and 
lag in the game there are a three parameters that you can modify to help tune the game. 
These are packet size, packet rate and packet frame. These values can be changed on the 
Options Network page. 

Packet rate controls the number of packets per second sent from the server to your client 
game. Packet size controls the approximate size of each packet. So a packet rate of 10 and 
a packet size of 200 means that the server will be transmitting to you an average of 2000 
bytes per second. Reducing the packet rate and size will reduce the amount of data being 
sent to you and can help keep your modem connection from clogging up. 

Packet frame is how often your client sends move information to the server. A slider 
currently controls this. Adjusting the slider to the left decreases the number of packets 
sent. Transmitting too much information on a poor connection can cause packet loss & game 
lag. 

VI: Dedicated Servers 

Those of you with faster connections may wish to run dedicated servers.  Information on how 
to configure and run a dedicated server is included on our player's website at 
http://www.tribesplayers.com.

VII: Real-Time Chat Programs

The Roger Wilco real-time chat program can now be used with TRIBES.  For information 
on how to use Roger Wilco with TRIBES, please consult the Roger Wilco documentation or 
their homepage at www.rogerwilco.com

VIII: Known Problems 

Here is a list of some of the known problems and interactions with other programs. 

* Internet Explorer 5.0 Beta. 
* Gamma correction with Voodoo II cards 

IX: Troubleshooting 

We hope that you enjoy playing Starsiege TRIBES. If you are running in any difficulties in 
getting the game to operate to your satisfaction, please read further. If the symptoms of 
the problem obviously point to sound or video issues, concentrate on those sections. 
Otherwise, please spend a couple of minutes reading the entire section. The time you spend 
here may well help you get TRIBES running and will help you to be prepared with information 
that will be helpful if you should need to contact Technical Support. 

Section 1: Notes on Connection 
If you cannot find a game to join, first check that you are connected to your ISP. If you 
are but still cannot connect, check your Filter settings. It is possible that they may be 
set so that no game can meet the criteria entered. 

Section 2: Notes on Sound Problems 
TRIBES uses DirectSound 6.0, which is a part of Microsoft's DirectX programming interface, 
for sound generation. If you are having problems with distorted or no sound, check to make 
sure that your sound card drivers are DirectSound-compliant. To do so, run DXDIAG; it will 
be located in your C:\Program Files\DirectX directory on your hard drive. When running 
DXDIAG, choose the Sound tab. In the upper right corner of the dialog box, look for the 
line that reads "Certified:" If this says "No", then you should check with the manufacturer 
of your system or your sound card to determine if DirectX certified drivers are available. 
If you contact these companies via the Internet, you can usually obtain updated drivers free 
of charge. 

Section 3: Notes on Video Problems 
TRIBES supports hardware 3D video acceleration for 3DFX-chipset video cards though the Glide 
and OpenGL APIs when running in full screen mode. 

If you are experiencing display problems while in full screen Glide mode, you'll want to 
see if the problems persist after you switch to software mode. To switch to Windows (software-accelerated)
mode, simply hold down the ALT key on the keyboard and press ENTER. If the problems 
go away when running in a window, the problem is likely related to the device drivers 
you are using with your 3D card. Contact the manufacturer of the card to verify that you 
have the most recent driver with the most current version of Glide.  If the problems persist, 
try downloading the latest reference drivers from 3Dfx at http://www.3dfx.com/download/download.html. 
  
FILENAME		OS			DESCRIPTION
rkvg.exe		Win95/98		Voodoo Graphics Reference Drivers
oemrushs.exe		Win95/98		Voodoo Rush (Single Board) Reference Drivers
oemrushd.exe		Win95/98		Voodoo Rush (Dual Board) Reference Drivers
rkv2.exe		Win95/98		Voodoo2 Reference Drivers
nt40vg.exe		NT4.0			Voodoo Graphics Reference Drivers
nt40v2.exe		NT4.0			Voodoo2 Reference Drivers

The latest information on 3Dfx and Glide can be found at http://www.3dfx.com. 
Copyright (c) 1997 3Dfx Interactive, Inc.  The 3Dfx Interactive logo, Voodoo Graphics and 
Voodoo Rush are trademarks of 3Dfx Interactive. 

There is an existing problem with the gamma correction on Voodoo2 cards with TRIBES.  If you
adjust your gamma, do not click on Apply when done.  

If your video card supports accelerated OpenGL, it should be availablein the Options/Video 
dialog.  If it does not appear, check the troubleshooting tips below. Select OpenGL as the 
fullscreen device, and set the "Setup OpenGL for:" combobox to your card type.  TRIBES has
selections for the TNT/TNT2/TNT2 Ultra and i740 chipsets, and a "Generic" setting for other cards.  
(G200/G400, Rage 128, etc.) 

If you are using OpenGL as your hardware accelerator, running in 32-bit mode will improve your z-buffering
(thus eliminating the effect where you could see through buildings at a distance), however, you may take a 
framerate hit as compared to 16-bit mode.  Switching between 32- and 16-bit modes can only be done by changing
your desktop resolution in Windows.

TNT issues
----------

The latest "Detonator" driver set is required.  Available at http://www.nvidia.com

At the time of this release, the latest version of the TNT drivers was 2.08.  We recommend using 
this version.

Riva128 issues
--------------

There are some problems with the z-buffering of artifacts.  This does not affect gameplay, but can be visually annoying.

To get the correct additive blending effects for projectiles, weapons, etc., open the console.cs file and change:
  
$pref::OpenGL::NoAddFade = false; 

to

$pref::OpenGL::NoAddFade = true; 


i740 issues
-----------

Switching from fullscreen software mode to fullscreen OpenGL on an i740 will crash TRIBES.  You can work around this by 
switching to windowed software mode before entering OpenGL mode.

Visit your card suppliers website for the latest version of the card's drivers.

You can find links to manufacturers' drivers at
http://developer.intel.com/design/graphics/740/solutions/index.htm.  

Reference Intel drivers can be found at
http://developer.intel.com/design/graphics/drivers/index.htm.
  
OpenGL Troubleshooting Tips
---------------------------

TRIBES no longer filters OpenGL drivers that return the name "GDI Generic."  This means that if you do not have the proper 
drivers installed, TRIBES will use the software implementation provided by Microsoft.  If you notice that your application 
is running unreasonably slow, first try checking that your desktop resolution is set to 16 bits.  Next, make sure that you 
have the correct drivers.  This should resolve the problem.

If problems occur while running in windowed mode, changing the color depth may help. To change to 16-bit color, right-click 
on your Windows Desktop and choose Properties from the pop-up menu that appears. Choose the Settings tab in the dialog box; 
it should be the one furthest to the right. Select the Color pull-down menu and choose 16-bit color. Remember that you may 
have to reduce your screen resolution if you are raising the color setting. 

Section 4: OpenGL with Windows 95
Some early versions of Windows 95 shipped without OpenGL support.  Microsoft released a patch
to address this problem.  Point your web browser at ftp://ftp.microsoft.com/softlib/mslfiles/opengl95.exe
to download the patch.

Section 5: Other Troubleshooting 
The following are steps that can be taken to help correct non-game specific issues, such as 
random game crashes or performance problems. 

1. Verify you have sufficient hard drive space to install the program. Go to My Computer and 
right click on the drive to which you will install the game. Select Properties from the pop-
up menu that appears. You should see a Free Space listing; make sure that it shows that you 
have enough free space to properly install the game. The System Requirements Label on the 
bottom of you product box will have this information.

2. Make sure that all non-vital programs are closed when you run TRIBES. To check what 
programs are active, hold down the CTRL and ALT keys on your keyboard and press the DEL key. 
This will bring up a dialog box called Close Programs. Generally, any program listed here 
besides Explorer and Systray is non-vital and should be closed before running TRIBES. To 
close a program, highlight it and click on the End Task button. You will need to repeat this 
process for each listed program. If a program will not shut down by this method, you may have 
to consult the documentation for that program for instructions on shutting it down. (Note: 
This is not a permanent change to your computer. Simply rebooting will re-activate all of 
the programs that you have shut down.)

3. Run a thorough Scandisk on your hard drive. You can run ScanDisk by clicking on the Start 
button and selecting Programs. Inside the Accessories there will be a System Tools group 
containing ScanDisk. Once you have clicked on ScanDisk, select the drive to scan and put the 
dot in the Thorough option. Then click on the Start button. This will probably take at least 
half an hour and as long as several hours. ScanDisk will locate errors on the hard drive and 
attempt to fix these errors. (Note: Always back up any critical information on your system 
before running Scandisk. If you have errors in the data on your hard drive, Scandisk will 
fix them by deleting the corrupted data. After this deletion occurs, some programs on your computer may quit functioning. In this event, you will want to remove and reinstall those affected programs. If you need assistance with that process, you will want to contact the manufacturer of the particular program.)
4. Try using a boot disk to prevent real mode device drivers from loading. Put a blank, 
high-density diskette in your A: drive. Then, open the My Computer icon from the desktop and 
highlight the icon for Drive A: Right-click on the icon and choose Format. In the resulting 
dialog box, make sure there are checks in the boxes for "Full" and "Copy System Files". 
Click on OK to start the process. Once the disk is formatted, double-click on the icon for 
the C: drive in My Computer. Look for the file called MSDOS.SYS in the list of files. If you 
cannot find it, click on the View menu, choose Options and then the View tab. Make sure "Show 
all files" is checked and "Hide MS DOS file extensions" is not checked. Once you've found the 
MSDOS.SYS file, right-click on it and choose Send To 3 &frac12; Floppy (A). You will be 
prompted to replace an existing file - click on OK. Once you've done this, reboot your 
system with the disk in the A: drive.

5. If you are still having problems at this point, try doing a clean installation of the game.
Run SETUP from the root directory of your TRIBES CD and choose to uninstall the game. Reboot 
your computer with the boot disk that you created in step 4. Close all programs as listed in 
step 2. Then run SETUP from your TRIBES CD again and reinstall the game.

For further information, see the TRIBES webpage at http://www.tribesplayers.com.

X.  Contact Information 

CONTACTING SIERRA 
Customer Service, Support, and Sales 
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
Havas International
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
Havas International
Phone: (01) 46-01-46-50 
Lundi au Jeudi de 10h à 19h 
Vendredi 10h à 18h 
Fax: (01) 46-30-00-65 
Parc Tertiaire de Meudon 
Immeuble "Le Newton" 
25 rue Jeanne Braconnier 
92366 Meudon La Forêt Cedex 
France 
  
Germany 
Havas International
Tel: (0) 6103-99-40-40 
Montag bis Freitag von 9h - 19Uhr 
Fax: (0) 6103-99-40-35 
Robert-Bosh-Str. 32 
D-63303 Dreieich 
Germany 
On-Line Sales 
CompuServe United Kingdom:GO UKSIERRA 
CompuServe France:   GO FRSIERRA 
CompuServe Germany:     GO DESIERRA 
Internet USA:    http://www.sierra.com 
Internet United Kingdom:  http://www.sierra-online.co.uk 
Internet France:     http://www.sierra.fr 
Internet Germany:   http://www.sierra.de 
Disk and or Manual Replacement 
Product Returns: 
Sierra On-Line Returns 
4100 West 190th Street 
Torrance, CA  90504 
Sierra On-Line Fulfillment 
4100 West 190th Street 
Torrance, CA  90504 
  
NOTE: To replace your disk(s) please send only Disk #1 (or the CD) and copy of your dated 
Receipt, if less then 90 days.  After 90 days please include a $10 handling fee along with 
Disk / CD #1.  For Documentation, please include a $ 5.00 handling fee and a photocopy ONLY 
of disk #1.  Payment should be made at the time of your request.  Sorry, no credit cards. 
* Returns to this address valid in North America only. 
  
XI: Technical Support 
North America 
Sierra On-Line offers a 24-hour automated technical support line with recorded answers to 
the most frequently asked technical questions. To access this service, call (425) 644-4343, 
and follow the recorded instructions to find your specific topic and resolve the issue. If 
this fails to solve your problem, you may still write, or fax us with your questions, or 
contact us via our Web site. 

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
Havas International offers a 24-hour Automated Technical Support line 
with recorded answers to the most frequently asked technical questions. To access this 
service, call (0118) 920-9111, and follow the recorded instructions to find your specific 
topic and resolve the issue. If this fails to solve your problem, you may still write, or 
fax us with your questions, or contact us via our Internet or CompuServe sites. 

Havas International
2 Beacontree Plaza, 
Gillette Way, 
Reading, Berkshire 
RG2 0BS United Kingdom 
Main: (0118) 920-9111 
Monday-Friday, 9:00 a.m. - 5:00 p.m. 
Fax:   (0118) 987-5603 
http://www.sierra-online.co.uk 

France 
Havas International
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
Havas International
Robert-Bosh-Str. 32 
D-63303 Dreieich 
Deutschland 
Tel: (0) 6103-99-40-40 
Montag bis Freitag von 9 - 19Uhr 
Fax: (0) 6103-99-40-35 
Mailbox: (0) 6103-99-40-35 
http://www.sierra.de 

Spain 
Havas International
Avenida de Burgos 9 
1&ordm;-OF2 
28036 Madrid 
Spain 
Teléfono: (01) 383-2623 
Lunes a Viernes de 9h30 a 14h y de 15h a 18h30 
Fax: (01) 381-2437 
  
Italy 
Contattare il vostro distribotore. 
  
XII:  Warranty and Legal Information 
Sierra's end user license agreement, limited warranty and return policy is set forth in the 
EULA.txt, found on the CD, and is also available during the install of the product. 
Copyright (1998 Sierra On-Line, Inc.) 
  
  
  
  
  
  
  
  
  
  
  
  
