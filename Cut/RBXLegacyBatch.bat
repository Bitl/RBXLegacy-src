@ECHO OFF
cls
COLOR 4F
SET appname=RBXLegacy
TITLE %appname%
SET RobloxPath=%CD%\client\RobloxApp.exe
SET RobloxPathRoot=%CD%\client
SET GameLoadPath=%RobloxPathRoot:\=\\%
SET RobloxPort=53640
SET UserID=0
SET PlayerName=Player
SET DefaultIP=localhost
SET DefaultMap=Baseplate
GOTO MainMenu
GOTO::EOF

:MainMenu
cls
ECHO %appname%
ECHO.
ECHO Menu Options: 
ECHO 1 - JOIN SERVER
ECHO 2 - START SERVER
ECHO 0 - QUIT
SET /P LaunchId="Option: "
IF %LaunchId%==1 GOTO ClientSetup
IF %LaunchId%==2 GOTO ServerSetup
IF %LaunchId%==0 EXIT
GOTO::EOF

:ClientSetup
cls
ECHO JOIN SERVER
ECHO.
ECHO If you don't enter an IP, the default will be used instead.
ECHO.
SET /P JoinServer="Server IP (Default: %DefaultIP%): "
IF NOT DEFINED JoinServer SET JoinServer=%DefaultIP%
ECHO Starting Roblox...
%RobloxPath% -script "dofile('%GameLoadPath%\\content\\Scripts\\CSMPFunctions.lua'); _G.CSConnect(%UserID%,'%JoinServer%',%RobloxPort%,'%PlayerName%');"
GOTO::EOF

:ServerSetup
cls
ECHO START SERVER
ECHO.
ECHO If you don't enter a map name, the default will be used instead.
ECHO Be sure you port forward %RobloxPort% if you want to start a public server.
ECHO.
ECHO Select a map:
ECHO.
for %%a in ("%CD%\client\content\Maps\*") do @echo %%~na
ECHO.
SET /P ServerPlaceId="Type the name of the map you would like to load (Default: %DefaultMap%): "
IF NOT DEFINED ServerPlaceId SET ServerPlaceId=%DefaultMap%
ECHO Starting Roblox...
%RobloxPath% -script "dofile('%GameLoadPath%\\content\\Scripts\\CSMPFunctions.lua'); _G.CSServer(%RobloxPort%,false); game:Load('%GameLoadPath%\\content\\Maps\\%ServerPlaceId%.rbxl');"
GOTO::EOF