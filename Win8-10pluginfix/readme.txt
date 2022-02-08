This is a registry fix for Windows 8/8.1 & 10 and Tribes 1.40+ rasadhlp.dll pluginloader

in win8+ the path to rasadhlp.dll is set in the registry and doesn't look in the current working directory, so pluginloader doesn't load and plugins dont load :(

i had previously released a crappy .exe fix but it was loading plugins way too early where they didn't have access to all variables and functions
so delete that stupid win8 pluginfix.exe if you still have it, put your old 1.40/1.41 Tribes.exe back and apply this registry fix instead


registry fix = better cause:

- it affects all tribes.exe's on your system
- there's already too many damn modified exes out there
- hey who knows what else i put into that patched .exe i gave u - but you can open up these .reg files and see that all its doing is removing the path to rasadhlp.dll
- you don't have to move scriptGL.dll around if u change .exes
- i never released a 1.40 version of the pluginfix .exe so there was no way to use stock 1.40 with plugins under 8 or 10
- loads plugins last where they have full access to all variables and functions that have been loaded like they always were before my kinda sketchy bad .exe fix

derpy instructions:

to apply: 

- double click on win8_pluginfix.reg
- click 'yes' to apply the registry patch 
- click 'ok' 

to undo:

- double click on win8_pluginfix_undo.reg
- click 'yes' to apply the registry patch 
- click 'ok'  

details:

this changes [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\WinSock2\Parameters] from:
"AutodialDLL"="C:\\Windows\\System32\\rasadhlp.dll"
to
"AutodialDLL"="rasadhlp.dll"

