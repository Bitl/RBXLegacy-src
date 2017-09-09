; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define AppVer "1.18Preview-1.1"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{DCC48BED-A985-4C5F-8C52-7E2E3F53C8EB}
AppName=RBXLegacy-Preview
AppVersion={#AppVer}
AppVerName=RBXLegacy-Preview
AppPublisher=Bitl
DefaultDirName=C:\RBXLegacy-Preview
DefaultGroupName=RBXLegacy-Preview
AllowNoIcons=yes
OutputDir=.
OutputBaseFilename=RBXLegacySetup_{#AppVer}
SetupIconFile=RBXLegacy-Preview\RBXLegacyIcon.ico
Compression=lzma2/ultra64
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a icon on your Desktop"; GroupDescription: "Icons"
Name: "quicklaunchicon"; Description: "Create a icon on your Quick Start Menu"; GroupDescription: "Icons"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "RBXLegacy-Preview\RBXLegacyLauncher.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "RBXLegacy-Preview\RBXLegacyLauncher.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "RBXLegacy-Preview\README.TXT"; DestDir: "{app}"; Flags: ignoreversion
Source: "RBXLegacy-Preview\changelog.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "RBXLegacy-Preview\info.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "RBXLegacy-Preview\clients\*"; DestDir: "{app}\clients"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "RBXLegacy-Preview\maps\*"; DestDir: "{app}\maps"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "RBXLegacy-Preview\models\*"; DestDir: "{app}\models"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "RBXLegacy-Preview\avatar\*"; DestDir: "{app}\avatar"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "RBXLegacy-Preview\scripts\*"; DestDir: "{app}\scripts"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "RBXLegacy-Preview\udppipe.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "RBXLegacy-Preview\Mono.Nat.dll"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\RBXLegacy-Preview"; Filename: "{app}\RBXLegacyLauncher.exe"
Name: "{group}\{cm:UninstallProgram,RBXLegacy-Preview}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\RBXLegacy-Preview"; Filename: "{app}\RBXLegacyLauncher.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\RBXLegacy-Preview"; Filename: "{app}\RBXLegacyLauncher.exe"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\RBXLegacyLauncher.exe"; Description: "Play RBXLegacy 1.18 Preview"; Flags: nowait postinstall skipifsilent
Filename: "{app}\README.TXT"; Description: "View the README file"; Flags: postinstall shellexec skipifsilent unchecked
Filename: "{app}\changelog.txt"; Description: "View the changelog"; Flags: postinstall shellexec skipifsilent unchecked
