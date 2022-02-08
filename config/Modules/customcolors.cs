Echoc(2,"++++ groovar bluelines.dll custom colors override" );

// syntax for my command is:
// groovcolor(destination1-19,Red,Green,Blue)
// basically you want to change the last 3 values of each line to the RGB value you want
// dont change the first value (1 through 19) and use 0-255 for the others
// if u do something strange it'll probably crash tribe cuz im lazy
// destinations 1-19 are vaguely described below:

// 1 = most menu greenlines and select highlight. default is 44,153,18
groovcolor(1,50,50,50);
// 2 = dialog box backgrounds. default is 22,86,3
groovcolor(2,50,50,50);
// 3 = Join server top background. default is 0,40,0
groovcolor(3,50,50,50);
// 4 = MenuGreenLinesInner. default is 104,175,86
groovcolor(4,50,50,50);
// 5 = MenuGreenLinesOuter. default is 80,124,66
groovcolor(5,50,50,50);
// 6 = another fricken greenline. default is 56,177,23
groovcolor(6,50,50,50);
// 7 = SelectHostGameTextColor. default is 0,0,1
groovcolor(7,50,50,50);
// 8 = HUD Brackets inner greenline. default is 0,255,0
groovcolor(8,13,71,161);
// 9 = HUD Brackets outer glow. default is 0,132,0
groovcolor(9,13,71,161);
// 10 = WeaponHUD Bracket. default is 0,255,0
groovcolor(10,0,255,0);
// 11 = TimeTextColor. default is 255,255,255
groovcolor(11,255,255,255);
// 12 = All ingame huds backdrop opacity - uses the R value - ignores the last 2 values but needs something there between 0 and 255 - i know its derpy :P default is 138,whatever,watever
groovcolor(12,1,1,1);
// 13 = All Scripted HUDS backdrop color (ctfhud etc). default for all the backdrops is 1,1,1
groovcolor(13,220,220,220);
// 14 = ChatHUD backdrop color
groovcolor(14,220,220,220);
// 15 = TimeHUD backdrop color
groovcolor(15,220,220,220);
// 16 = Tab Menu and others backdrop color
groovcolor(16,1,1,1);
// 17 = WeaponHUD backdrop color
groovcolor(17,1,1,1);
// 18 = Chat INPUT backdrop color
groovcolor(18,1,1,1);
// 19 = Chat INPUT Brackets outer and flashing cursor color. default is 0,255,0
groovcolor(19,0,0,0);
// 20 = MiniMap grey background. default is 1,1,1
groovcolor(20,220,220,220);
// 21 = Zoomed Sniper Crosshair. default is 0,255,0
groovcolor(21,0,102,255);
// 22 = MiniMap background Opacity. uses the R value only - default is 51,0,0 - to match to default huds set to 138
groovcolor(22,80,0,0);
// 23 = Vote popup, remoteCP, remoteBP etc background color. default is 1,1,1
groovcolor(23,1,1,1);

// load our style pref for this config