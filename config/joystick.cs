// You can use the console command listInputDevices(); to list out your
// devices.  If you have a trackball or something, add an inputActivate for it
// like below.

inputActivate(joystick0);

EditActionMap("playMap.sae");

// movement axis
bindAction(joystick0, xAxis0, TO, IDACTION_STRAFE, Center, DeadZone, 0.04, Scale, 100);
bindAction(joystick0, yAxis0, TO, IDACTION_RUN, Center, DeadZone, 0.04, Scale, 100);

// The following lines are for panther XL or trackball people
// thanks Aslan for the info.  Uncomment the bindAction lines to activate.

// To change the sensitivity of the trackball, just edit the 0.6s at the end of each line
// increase for more sensitivity, decrease for less.

// bindAction(joystick0, slider0, TO, IDACTION_YAW, Center, DeadZone, 0.01, Scale, 0.6);
// bindAction(joystick0, slider1, TO, IDACTION_PITCH, Flip, Center, DeadZone, 0.01, Scale, 0.6);

