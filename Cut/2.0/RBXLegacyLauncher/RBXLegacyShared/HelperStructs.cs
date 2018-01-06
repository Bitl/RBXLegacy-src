using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RBXLegacyLauncher
{
    public class HelperStructs
    {
        public class GlobalVars
        {
            //base paths
            public static string BasePath = AppDomain.CurrentDomain.BaseDirectory;
            public static string ClientFolder = BasePath + "clients/";
            public static string DataFolder = BasePath + "data/";
            public static string MapFolder = BasePath + "maps/";
            
            //customization paths
            public static string AvatarFolder = BasePath + "avatar/";
            public static string BodiesFolder = AvatarFolder + "bodies/";
            public static string TorsoFolder = BodiesFolder + "2/";
            public static string RArmFolder = BodiesFolder + "3/";
            public static string LArmFolder = BodiesFolder + "4/";
            public static string RLegFolder = BodiesFolder + "5/";
            public static string LLegFolder = BodiesFolder + "6/";
            public static string FacesFolder = AvatarFolder + "faces/";
            public static string GearFolder = AvatarFolder + "gears/";
            public static string HatFolder = AvatarFolder + "hats/";
            public static string HeadsFolder = AvatarFolder + "heads/";
            public static string CharacterViewFolder = AvatarFolder + "preview/";

            //configs and info
            public static string ConfigExt = ".rbxcfg";
            public static string LauncherConfigFile = DataFolder + "config" + ConfigExt;
            public static string ServerListFile = DataFolder + "servers" + ConfigExt;
            public static string ChangelogFile = DataFolder + "changelog" + ConfigExt;
            public static string ClientInfoFile = "clientinfo" + ConfigExt;
            public static string ClientListFile = ClientFolder + "clientlist" + ConfigExt;
            public static string LauncherInfoFile = DataFolder + "info" + ConfigExt;
            public static string CustomizationFile = DataFolder + "character" + ConfigExt;
            public static string ServerSettingsFile = DataFolder + "serversettings" + ConfigExt;

            //default values
            public static string SelectedMap = "Baseplate.rbxl";
            public static string RobloxLegacyExeFile = "/RobloxApp.exe";
            public static string RobloxClientExeFile = "/RobloxPlayer.exe";
            public static string RobloxStudioExeFile = "/RobloxStudio.exe";
            public static string RobloxServerExeFile = "/RobloxServer.exe";
            public static string CharacterViewExeFile = CharacterViewFolder + "3DView.exe";
            public static string RockyPatchExeFilename = "udppipe";
            public static string RockyPatchExeFile = BasePath + RockyPatchExeFilename + ".exe";
            public static string ScriptExt = ".rbxscript";
            public static string JoinServerLuaFile = BasePath + "client" + ScriptExt;
            public static string StartServerLuaFile = BasePath + "server" + ScriptExt;
            public static string PlaySoloLuaFile = BasePath + "playsolo" + ScriptExt;
            public static string CharacterViewLuaFile = BasePath + "3dview" + ScriptExt;
            public static string StudioLuaFile = BasePath + "studio" + ScriptExt;
            //todo add strings for arguments for server, client, solo, and 3dView in proper methods.

            //loaded into launcher memory
            public static Config LauncherConfig;
            public static Info LauncherInfo;
            public static Client SelectedClient;
            public static Customization PlayerLook;
            public static ServerSettings ServerScriptSettings;
            public static JoinSettings ServerToJoin;
            public static List <ClientDef> AvailableClients = new List<ClientDef>();

            //discord :D
            public static DiscordRpc.RichPresence presence;
            public static string appid = "378626645038333952";
            public static string imagekey_large = "rbxlegacy_logo_large";

            //validation for script gen
            public static string[] ValidClientVersions = new string[] { "m2007", "l2007/e2008", "m2008", "l2008/e2009", "e2009/m2009", "l2009/e2010", "m2010/l2010", "l2010/e2011", "m2011/m2012", "l2012/e2013" };
        }

        public class LauncherFuncs
        {
            public LauncherFuncs()
            {

            }

            public static void ReadClientValues(string clientpath)
            {
                string line1;

                using (StreamReader reader = new StreamReader(clientpath))
                {
                    line1 = reader.ReadLine();
                }

                string[] result = line1.Split('|');
                string ClientMD5 = result[0];
                string ClientDesc = result[1];
                string ClientVersion = result[2];
                string ClientUsesNames = result[3];
                string ClientUsesIDs = result[4];
                string ClientLegacyMode = result[5];
                string ClientHasRocky = result[6];
                Client selectedClient = new Client(ClientMD5, ClientDesc, ClientVersion, Convert.ToBoolean(ClientUsesNames), Convert.ToBoolean(ClientUsesIDs), Convert.ToBoolean(ClientLegacyMode), Convert.ToBoolean(ClientHasRocky));

                GlobalVars.SelectedClient = selectedClient;
            }

            public static void ReadClientNames()
            {
                string[] lines = File.ReadLines(GlobalVars.ClientListFile).ToArray();
                foreach (string line in lines)
                {
                    ClientDef selectedClient = new ClientDef(line);
                    GlobalVars.AvailableClients.Add(selectedClient);
                }
            }

            public static void ReadConfigValues(string configpath)
            {
                string line1;

                using (StreamReader reader = new StreamReader(configpath))
                {
                    line1 = reader.ReadLine();
                }

                string[] result = line1.Split('|');
                string PlayerName = result[0];
                string PlayerID = result[1];
                string LauncherScheme = result[2];
                string LauncherTheme = result[3];
                string SelectedClient = result[4];
                string AdminMode = result[5];
                Config launcherConfig = new Config(PlayerName, Convert.ToInt32(PlayerID), LauncherScheme, Convert.ToBoolean(LauncherTheme), SelectedClient, Convert.ToBoolean(AdminMode));

                GlobalVars.LauncherConfig = launcherConfig;
            }

            public static void WriteConfigValues(string cfgpath)
            {
                string[] lines = {
                    GlobalVars.LauncherConfig.PlayerName.ToString(),
                    GlobalVars.LauncherConfig.PlayerID.ToString(),
                    GlobalVars.LauncherConfig.Scheme.ToString(),
                    GlobalVars.LauncherConfig.Theme.ToString(),
                    GlobalVars.LauncherConfig.SelectedClient.ToString(),
                    GlobalVars.LauncherConfig.AdminMode.ToString()
                };

                File.WriteAllText(cfgpath, string.Join("|", lines));
            }

            //todo add customization, clientinfo, and info writers for the specific apps.

            public static void ReadInfoValues(string infopath)
            {
                string line1;

                using (StreamReader reader = new StreamReader(infopath))
                {
                    line1 = reader.ReadLine();
                }

                string[] result = line1.Split('|');
                string Version = result[0];
                string DefaultClientName = result[1];
                Info launcherInfo = new Info(Version, DefaultClientName);

                GlobalVars.LauncherInfo = launcherInfo;
            }

            public static void ResetConfigValues()
            {
                string defaultclient = GlobalVars.LauncherInfo.DefaultSelectedClient;

                GlobalVars.LauncherConfig.PlayerName = "Player";
                GlobalVars.LauncherConfig.PlayerID = GeneratePlayerID();
                GlobalVars.LauncherConfig.Scheme = "blue";
                GlobalVars.LauncherConfig.Theme = false;
                GlobalVars.LauncherConfig.SelectedClient = defaultclient;
                GlobalVars.LauncherConfig.AdminMode = false;
            }

            public static void ReadCustomizationValues(string customizationpath)
            {
                string line1;

                using (StreamReader reader = new StreamReader(customizationpath))
                {
                    line1 = reader.ReadLine();
                }

                string[] result = line1.Split('|');
                string Hat1 = result[0];
                string Hat2 = result[1];
                string Hat3 = result[2];
                string HeadColor = result[3];
                string TorsoColor = result[4];
                string LeftArmColor = result[5];
                string RightArmColor = result[6];
                string LeftLegColor = result[7];
                string RightLegColor = result[8];
                string TShirt = result[9];
                string Shirt = result[10];
                string Pants = result[11];
                string Face = result[12];
                string Head = result[13];
                string Torso = result[14];
                string LeftArm = result[15];
                string RightArm = result[16];
                string LeftLeg = result[17];
                string RightLeg = result[18];
                string Gear1 = result[19];
                string Gear2 = result[20];
                string Gear3 = result[21];
                string IconType = result[22];
                Customization custom = new Customization(Hat1,Hat2,Hat3,Convert.ToInt32(HeadColor),Convert.ToInt32(TorsoColor),Convert.ToInt32(LeftArmColor),Convert.ToInt32(RightArmColor),Convert.ToInt32(LeftLegColor),Convert.ToInt32(RightLegColor),Convert.ToInt32(TShirt),Convert.ToInt32(Shirt),Convert.ToInt32(Pants),Face,Head,Torso,LeftArm,RightArm,RightLeg,LeftLeg,Gear1,Gear2,Gear3,IconType);

                GlobalVars.PlayerLook = custom;
            }

            public static void ReadServerSettingsValues(string serversettingspath)
            {
                string line1;

                using (StreamReader reader = new StreamReader(serversettingspath))
                {
                    line1 = reader.ReadLine();
                }

                string[] result = line1.Split('|');
                string Port = result[0];
                string PlayerLimit = result[1];
                string RespawnTime = result[2];
                string IsPersonalServer = result[3];
                string ChatType = result[4];
                string Blacklist1 = result[5];
                string Blacklist2 = result[6];
                string Blacklist3 = result[7];
                string Blacklist4 = result[8];
                string Blacklist5 = result[9];
                string Blacklist6 = result[10];
                string Blacklist7 = result[11];
                string Blacklist8 = result[12];
                string MeleeGears = result[13];
                string PowerUpGears = result[14];
                string RangedGears = result[15];
                string NavigationGears = result[16];
                string ExplosivesGears = result[17];
                string MusicalGears = result[18];
                string SocialGears = result[19];
                string TransportGears = result[20];
                string BuildingGears = result[21];
                ServerSettings serverscript = new ServerSettings(Convert.ToInt32(Port), Convert.ToInt32(PlayerLimit), Convert.ToInt32(RespawnTime), Convert.ToBoolean(IsPersonalServer), ChatType, Convert.ToInt32(Blacklist1), Convert.ToInt32(Blacklist2), Convert.ToInt32(Blacklist3), Convert.ToInt32(Blacklist4), Convert.ToInt32(Blacklist5), Convert.ToInt32(Blacklist6), Convert.ToInt32(Blacklist7), Convert.ToInt32(Blacklist8), Convert.ToBoolean(MeleeGears), Convert.ToBoolean(PowerUpGears), Convert.ToBoolean(RangedGears), Convert.ToBoolean(NavigationGears), Convert.ToBoolean(ExplosivesGears), Convert.ToBoolean(MusicalGears), Convert.ToBoolean(SocialGears), Convert.ToBoolean(TransportGears), Convert.ToBoolean(BuildingGears));

                GlobalVars.ServerScriptSettings = serverscript;
            }

            public static int GeneratePlayerID()
            {
                CryptoRandom random = new CryptoRandom();
                int randomID = 0;
                int randIDmode = random.Next(0, 7);
                if (randIDmode == 0)
                {
                    randomID = random.Next(0, 99);
                }
                else if (randIDmode == 1)
                {
                    randomID = random.Next(0, 999);
                }
                else if (randIDmode == 2)
                {
                    randomID = random.Next(0, 9999);
                }
                else if (randIDmode == 3)
                {
                    randomID = random.Next(0, 99999);
                }
                else if (randIDmode == 4)
                {
                    randomID = random.Next(0, 999999);
                }
                else if (randIDmode == 5)
                {
                    randomID = random.Next(0, 9999999);
                }
                else if (randIDmode == 6)
                {
                    randomID = random.Next(0, 99999999);
                }
                else if (randIDmode == 7)
                {
                    randomID = random.Next();
                }
                //2147483647 is max id.
                return randomID;
            }
        }

        public class SecurityFuncs
        {
            public SecurityFuncs()
            {

            }

            public static bool checkfileMD5(string filepath, string storedmd5)
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filepath))
                    {
                        byte[] hash = md5.ComputeHash(stream);
                        string fileMD5 = BitConverter.ToString(hash).Replace("-", "");
                        if (fileMD5.Equals(storedmd5))
                        {
                            return true;
                        }
                        else
                        {
                            if (GlobalVars.LauncherConfig.AdminMode == false)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }

        public class ScriptGenerator
        {
            public ScriptGenerator()
            {

            }

            public static void GenerateScriptForClient(ScriptType type)
            {
                //first, let's check the version list to see if this version is valid

                string clientversion = GlobalVars.SelectedClient.Version;

                if (!IsVersionValid(clientversion))
                    return;

                //next, generate the header functions.

                string header = "";

                if (type != ScriptType.Studio)
                {
                    header = MultiLine(
                    "function waitForChild(instance, name)",
                    "while not instance:FindFirstChild(name) do",
                    "instance.ChildAdded:wait()",
                    "end",
                    "end",
                    "function newWaitForChild(newParent,name)",
                    "local returnable = nil",
                    "if newParent:FindFirstChild(name) then",
                    "returnable = newParent:FindFirstChild(name)",
                    "else",
                    "repeat wait() returnable = newParent:FindFirstChild(name)  until returnable ~= nil",
                    "end",
                    "return returnable",
                    "end"
                    );
                }

                //next, associate the settings 

                string settings = "";

                if (clientversion.Equals("m2007"))
                {
                    settings = MultiLine(
                    "settings().Network.maxDataModelSendBuffer = 1000000",
                    "settings().Network.sendRate = 1000000",
                    "rbxlegacyversion = 1"
                    );
                }
                else if (clientversion.Equals("l2007/e2008"))
                {
                    settings = MultiLine(
                    "settings().Rendering.frameRateManager = 2",
                    "settings().Network.maxDataModelSendBuffer = 1000000",
                    "settings().Network.SendRate = 1000000",
                    "rbxlegacyversion = 1"
                    );
                }
                else if (clientversion.Equals("m2008"))
                {
                    settings = MultiLine(
                    "settings().Rendering.frameRateManager = 2",
                    "settings().Network.MaxSendBuffer = 1000000",
                    "settings().Network.PhysicsReplicationUpdateRate = 1000000",
                    "settings().Network.SendRate = 1000000",
                    "settings().Network.PhysicsSend = 1",
                    "rbxlegacyversion = 2"
                    );
                }
                else if (clientversion.Equals("l2008/e2009"))
                {
                    settings = MultiLine(
                    "settings().Rendering.FrameRateManager = 2",
                    "settings().Network.SendRate = 30",
                    "settings().Network.ReceiveRate = 60",
                    "settings().Network.PhysicsSend = 1",
                    "rbxlegacyversion = 2"
                    );
                }
                else if (clientversion.Equals("e2009/m2009"))
                {
                    settings = MultiLine(
                    "settings().Rendering.FrameRateManager = 2",
                    "settings().Network.DataSendRate = 30",
                    "settings().Network.PhysicsSendRate = 20",
                    "settings().Network.ReceiveRate = 60",
                    "rbxlegacyversion = 3"
                    );
                }
                else if (clientversion.Equals("l2009/e2010"))
                {
                    settings = MultiLine(
                    "settings().Rendering.FrameRateManager = 2",
                    "settings().Network.DataSendRate = 30",
                    "settings().Network.PhysicsSendRate = 20",
                    "settings().Network.ReceiveRate = 60",
                    "settings().Diagnostics.LuaRamLimit = 0",
                    "pcall(function() game:GetService('ScriptContext').ScriptsDisabled = false end)",
                    "pcall(function() settings().Diagnostics:LegacyScriptMode() end)",
                    "rbxlegacyversion = 3"
                    );
                }
                else if (clientversion.Equals("m2010/l2010"))
                {
                    settings = MultiLine(
                    "settings().Rendering.FrameRateManager = 2",
                    "settings().Network.DataSendRate = 30",
                    "settings().Network.PhysicsSendRate = 20",
                    "settings().Network.ReceiveRate = 60",
                    "settings().Diagnostics.LuaRamLimit = 0",
                    "pcall(function() game:GetService('ScriptContext').ScriptsDisabled = false end)",
                    "pcall(function() settings().Diagnostics:LegacyScriptMode() end)",
                    "rbxlegacyversion = 4"
                    );
                }
                else if (clientversion.Equals("l2010/e2011"))
                {
                    settings = MultiLine(
                    "settings().Rendering.FrameRateManager = 2",
                    "settings().Diagnostics.LuaRamLimit = 0",
                    "pcall(function() game:GetService('ScriptContext').ScriptsDisabled = false end)",
                    "pcall(function() settings().Diagnostics:LegacyScriptMode() end)",
                    "coroutine.resume(coroutine.create(function()",
                    @"loadstring('\108\111\99\97\108\32\67\111\114\101\71\117\105\32\61\32\103\97\109\101\58\71\101\116\83\101\114\118\105\99\101\40\34\67\111\114\101\71\117\105\34\41\59\10\119\104\105\108\101\32\110\111\116\32\67\111\114\101\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\82\111\98\108\111\120\71\117\105\34\41\32\100\111\10\9\67\111\114\101\71\117\105\46\67\104\105\108\100\65\100\100\101\100\58\119\97\105\116\40\41\59\10\101\110\100\10\108\111\99\97\108\32\82\111\98\108\111\120\71\117\105\32\61\32\67\111\114\101\71\117\105\46\82\111\98\108\111\120\71\117\105\59\10\108\111\99\97\108\32\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\84\111\112\76\101\102\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\66\117\105\108\100\84\111\111\108\115\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\117\105\108\100\84\111\111\108\115\34\41\10\102\117\110\99\116\105\111\110\32\109\97\107\101\89\82\101\108\97\116\105\118\101\40\41\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\10\105\102\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\116\104\101\110\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\32\101\110\100\10\105\102\32\66\117\105\108\100\84\111\111\108\115\32\116\104\101\110\32\66\117\105\108\100\84\111\111\108\115\46\70\114\97\109\101\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\32\101\110\100\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\48\44\48\44\49\44\45\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\88\44\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\101\110\100\10\102\117\110\99\116\105\111\110\32\109\97\107\101\88\82\101\108\97\116\105\118\101\40\41\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\105\102\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\116\104\101\110\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\32\101\110\100\10\105\102\32\66\117\105\108\100\84\111\111\108\115\32\116\104\101\110\32\66\117\105\108\100\84\111\111\108\115\46\70\114\97\109\101\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\32\101\110\100\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\48\44\48\44\49\44\45\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\88\44\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\101\110\100\10\108\111\99\97\108\32\102\117\110\99\116\105\111\110\32\114\101\115\105\122\101\40\41\10\105\102\32\82\111\98\108\111\120\71\117\105\46\65\98\115\111\108\117\116\101\83\105\122\101\46\120\32\62\32\82\111\98\108\111\120\71\117\105\46\65\98\115\111\108\117\116\101\83\105\122\101\46\121\32\116\104\101\110\10\109\97\107\101\89\82\101\108\97\116\105\118\101\40\41\10\101\108\115\101\10\109\97\107\101\88\82\101\108\97\116\105\118\101\40\41\10\101\110\100\10\101\110\100\10\82\111\98\108\111\120\71\117\105\46\67\104\97\110\103\101\100\58\99\111\110\110\101\99\116\40\102\117\110\99\116\105\111\110\40\112\114\111\112\101\114\116\121\41\10\105\102\32\112\114\111\112\101\114\116\121\32\61\61\32\34\65\98\115\111\108\117\116\101\83\105\122\101\34\32\116\104\101\110\10\119\97\105\116\40\41\10\114\101\115\105\122\101\40\41\10\101\110\100\10\101\110\100\41\10\119\97\105\116\40\41\10\114\101\115\105\122\101\40\41\10')()",
                    "end))",
                    "waitForChild(game.GuiRoot,'ScoreHud')",
                    "game.GuiRoot.ScoreHud:Remove()",
                    "rbxlegacyversion = 5"
                    );
                }
                else if (clientversion.Equals("m2011/m2012"))
                {
                    settings = MultiLine(
                    "settings().Rendering.FrameRateManager = 2",
                    "settings().Diagnostics.LuaRamLimit = 0",
                    "pcall(function() game:GetService('ScriptContext').ScriptsDisabled = false end)",
                    "pcall(function() settings().Diagnostics:LegacyScriptMode() end)",
                    "waitForChild(game.GuiRoot,'ScoreHud')",
                    "game.GuiRoot.ScoreHud:Remove()",
                    "rbxlegacyversion = 6"
                    );
                }
                else if (clientversion.Equals("l2012/e2013"))
                {
                    settings = MultiLine(
                    "settings().Rendering.FrameRateManager = 2",
                    "settings().Diagnostics.LuaRamLimit = 0",
                    "pcall(function() game:GetService('ScriptContext').ScriptsDisabled = false end)",
                    "pcall(function() settings().Diagnostics:LegacyScriptMode() end)",
                    "pcall(function() game:GetService('InsertService'):SetBaseSetsUrl('http://www.roblox.com/Game/Tools/InsertAsset.ashx?nsets=10&type=base') end)",
                    "pcall(function() game:GetService('InsertService'):SetUserSetsUrl('http://www.roblox.com/Game/Tools/InsertAsset.ashx?nsets=20&type=user&userid=%d') end)",
                    "pcall(function() game: GetService('InsertService'):SetCollectionUrl('http://www.roblox.com/Game/Tools/InsertAsset.ashx?sid=%d') end)",
                    "pcall(function() game: GetService('InsertService'):SetAssetUrl('http://www.roblox.com/Asset/?id=%d') end)",
                    "pcall(function() game: GetService('InsertService'):SetAssetVersionUrl('http://www.roblox.com/Asset/?assetversionid=%d') end)",
                    "pcall(function() game: GetService('SocialService'):SetGroupUrl('http://assetgame.roblox.com/Game/LuaWebService/HandleSocialRequest.ashx?method=IsInGroup&playerid=%d&groupid=%d') end)",
                    "pcall(function() game: GetService('BadgeService'):SetPlaceId(-1) end)",
                    "pcall(function() game: GetService('BadgeService'):SetIsBadgeLegalUrl('') end)",
                    "pcall(function() game: GetService('ScriptInformationProvider'):SetAssetUrl('http://www.roblox.com/Asset/') end)",
                    "pcall(function() game: GetService('ContentProvider'):SetBaseUrl('http://www.roblox.com/') end)",
                    "rbxlegacyversion = 7"
                    );
                }
                else
                {
                    settings = MultiLine(
                    "settings().Rendering.FrameRateManager = 2",
                    "settings().Diagnostics.LuaRamLimit = 0",
                    "pcall(function() game:GetService('ScriptContext').ScriptsDisabled = false end)",
                    "pcall(function() settings().Diagnostics:LegacyScriptMode() end)",
                    "waitForChild(game.GuiRoot,'ScoreHud')",
                    "game.GuiRoot.ScoreHud:Remove()",
                    "rbxlegacyversion = 5"
                    );
                }

                //0 = 2006, 1 = 2007, 2 = 2008, 3 = 2009, 4 = 2010, 5 = 2011, 6 = 2012, 7 = 2013

                //then, init customization

                //LauncherFuncs.ReadCustomizationValues(GlobalVars.CustomizationFile);

                string Name = GlobalVars.SelectedClient.UsesNames ? GlobalVars.LauncherConfig.PlayerName : "Player";
                int ID = GlobalVars.SelectedClient.UsesIDs ? GlobalVars.LauncherConfig.PlayerID : 0;

                string playersettings = "";

                if (type != ScriptType.Studio || type != ScriptType.Server)
                {
                    playersettings = MultiLine(
                    "UserID = '" + ID + "'",
                    "PlayerName = '" + Name + "'",
                    "Hat1ID = '" + GlobalVars.PlayerLook.Hat1 + "'",
                    "Hat2ID = '" + GlobalVars.PlayerLook.Hat2 + "'",
                    "Hat3ID = '" + GlobalVars.PlayerLook.Hat3 + "'",
                    "HeadColorID = " + GlobalVars.PlayerLook.HeadColor,
                    "TorsoColorID = " + GlobalVars.PlayerLook.TorsoColor,
                    "LeftArmColorID = " + GlobalVars.PlayerLook.LeftArmColor,
                    "RightArmColorID = " + GlobalVars.PlayerLook.RightArmColor,
                    "LeftLegColorID = " + GlobalVars.PlayerLook.LeftLegColor,
                    "RightLegColorID = " + GlobalVars.PlayerLook.RightArmColor,
                    "TShirtID = " + GlobalVars.PlayerLook.TShirt,
                    "ShirtID = " + GlobalVars.PlayerLook.Shirt,
                    "PantsID = " + GlobalVars.PlayerLook.Pants,
                    "FaceID = '" + GlobalVars.PlayerLook.Face + "'",
                    "HeadID = '" + GlobalVars.PlayerLook.Head + "'",
                    "TorsoID = '" + GlobalVars.PlayerLook.Torso + "'",
                    "RArmID = '" + GlobalVars.PlayerLook.RightArm + "'",
                    "LArmID = '" + GlobalVars.PlayerLook.LeftArm + "'",
                    "RLegID = '" + GlobalVars.PlayerLook.RightLeg + "'",
                    "LLegID = '" + GlobalVars.PlayerLook.LeftLeg + "'",
                    "Gear1 = '" + GlobalVars.PlayerLook.Gear1 + "'",
                    "Gear2 = '" + GlobalVars.PlayerLook.Gear2 + "'",
                    "Gear3 = '" + GlobalVars.PlayerLook.Gear3 + "'",
                    "IconType = '" + GlobalVars.PlayerLook.IconType + "'"
                    );
                }

                /*
                if (type == ScriptType.Server || type == ScriptType.Solo)
                {
                    LauncherFuncs.ReadServerSettingsValues(GlobalVars.ServerSettingsFile);
                }
                */

                string scriptsettings = "";

                if (type == ScriptType.Join)
                {
                    string IP = GlobalVars.SelectedClient.HasRocky ? GlobalVars.ServerToJoin.IP : "localhost";
                    scriptsettings = MultiLine(
                    "ServerIP = '" + IP + "'",
                    "ServerPort = " + GlobalVars.ServerToJoin.Port
                    );
                }
                else if (type == ScriptType.Server)
                {
                    scriptsettings = MultiLine(
                    "Port = " + GlobalVars.ServerScriptSettings.Port,
                    "PlayerLimit = " + GlobalVars.ServerScriptSettings.PlayerLimit,
                    "RespawnTime = " + GlobalVars.ServerScriptSettings.RespawnTime,
                    "IsPersonalServer = " + GlobalVars.ServerScriptSettings.IsPersonalServer.ToString().ToLower(),
                    "ChatType = '" + GlobalVars.ServerScriptSettings.ChatType + "'",
                    "HostID = " + ID,
                    "Blacklist1 = " + GlobalVars.ServerScriptSettings.Blacklist1,
                    "Blacklist2 = " + GlobalVars.ServerScriptSettings.Blacklist2,
                    "Blacklist3 = " + GlobalVars.ServerScriptSettings.Blacklist3,
                    "Blacklist4 = " + GlobalVars.ServerScriptSettings.Blacklist4,
                    "Blacklist5 = " + GlobalVars.ServerScriptSettings.Blacklist5,
                    "Blacklist6 = " + GlobalVars.ServerScriptSettings.Blacklist6,
                    "Blacklist7 = " + GlobalVars.ServerScriptSettings.Blacklist7,
                    "Blacklist8 = " + GlobalVars.ServerScriptSettings.Blacklist8,
                    "MeleeGT = " + GlobalVars.ServerScriptSettings.MeleeGears.ToString().ToLower(),
                    "PowerUpGT = " + GlobalVars.ServerScriptSettings.PowerUpGears.ToString().ToLower(),
                    "RangedGT = " + GlobalVars.ServerScriptSettings.RangedGears.ToString().ToLower(),
                    "NavigationGT = " + GlobalVars.ServerScriptSettings.NavigationGears.ToString().ToLower(),
                    "ExplosivesGT = " + GlobalVars.ServerScriptSettings.ExplosivesGears.ToString().ToLower(),
                    "MusicalGT = " + GlobalVars.ServerScriptSettings.MusicalGears.ToString().ToLower(),
                    "SocialGT = " + GlobalVars.ServerScriptSettings.SocialGears.ToString().ToLower(),
                    "TransportGT = " + GlobalVars.ServerScriptSettings.TransportGears.ToString().ToLower(),
                    "BuildingGT = " + GlobalVars.ServerScriptSettings.BuildingGears.ToString().ToLower()
                    );
                }
                else if (type == ScriptType.Solo)
                {
                    scriptsettings = MultiLine(
                    "RespawnTime = " + GlobalVars.ServerScriptSettings.RespawnTime,
                    "MeleeGT = " + GlobalVars.ServerScriptSettings.MeleeGears.ToString().ToLower(),
                    "PowerUpGT = " + GlobalVars.ServerScriptSettings.PowerUpGears.ToString().ToLower(),
                    "RangedGT = " + GlobalVars.ServerScriptSettings.RangedGears.ToString().ToLower(),
                    "NavigationGT = " + GlobalVars.ServerScriptSettings.NavigationGears.ToString().ToLower(),
                    "ExplosivesGT = " + GlobalVars.ServerScriptSettings.ExplosivesGears.ToString().ToLower(),
                    "MusicalGT = " + GlobalVars.ServerScriptSettings.MusicalGears.ToString().ToLower(),
                    "SocialGT = " + GlobalVars.ServerScriptSettings.SocialGears.ToString().ToLower(),
                    "TransportGT = " + GlobalVars.ServerScriptSettings.TransportGears.ToString().ToLower(),
                    "BuildingGT = " + GlobalVars.ServerScriptSettings.BuildingGears.ToString().ToLower()
                    );
                }

                //add customization funcs

                string clientside = MultiLine(
                    "function InitalizeClientAppearance(Player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3)",
                    "local newCharApp = Instance.new('IntValue',Player)",
                    "newCharApp.Name = 'Appearance'",
                    "for i=1,6,1 do",
                    "local BodyColor = Instance.new('BrickColorValue',newCharApp)",
                    "if (i == 1) then",
                    "if (HeadColorID ~= nil) then",
                    "BodyColor.Value = BrickColor.new(HeadColorID)",
                    "BodyColor.Name = 'HeadColor (ID: '..HeadColorID..')'",
                    "else",
                    "BodyColor.Value = BrickColor.new(1)",
                    "BodyColor.Name = 'HeadColor (ID: 1)'",
                    "end",
                    "elseif (i == 2) then",
                    "if (TorsoColorID ~= nil) then",
                    "BodyColor.Value = BrickColor.new(TorsoColorID)",
                    "BodyColor.Name = 'TorsoColor (ID: '..TorsoColorID..')'",
                    "else",
                    "BodyColor.Value = BrickColor.new(1)",
                    "BodyColor.Name = 'TorsoColor (ID: 1)'",
                    "end",
                    "elseif (i == 3) then",
                    "if (LeftArmColorID ~= nil) then",
                    "BodyColor.Value = BrickColor.new(LeftArmColorID)",
                    "BodyColor.Name = 'LeftArmColor (ID: '..LeftArmColorID..')'",
                    "else",
                    "BodyColor.Value = BrickColor.new(1)",
                    "BodyColor.Name = 'LeftArmColor (ID: 1)'",
                    "end",
                    "elseif (i == 4) then",
                    "if (RightArmColorID ~= nil) then",
                    "BodyColor.Value = BrickColor.new(RightArmColorID)",
                    "BodyColor.Name = 'RightArmColor (ID: '..RightArmColorID..')'",
                    "else",
                    "BodyColor.Value = BrickColor.new(1)",
                    "BodyColor.Name = 'RightArmColor (ID: 1)'",
                    "end",
                    "elseif (i == 5) then",
                    "if (LeftLegColorID ~= nil) then",
                    "BodyColor.Value = BrickColor.new(LeftLegColorID)",
                    "BodyColor.Name = 'LeftLegColor (ID: '..LeftLegColorID..')'",
                    "else",
                    "BodyColor.Value = BrickColor.new(1)",
                    "BodyColor.Name = 'LeftLegColor (ID: 1)'",
                    "end",
                    "elseif (i == 6) then",
                    "if (RightLegColorID ~= nil) then",
                    "BodyColor.Value = BrickColor.new(RightLegColorID)",
                    "BodyColor.Name = 'RightLegColor (ID: '..RightLegColorID..')'",
                    "else",
                    "BodyColor.Value = BrickColor.new(1)",
                    "BodyColor.Name = 'RightLegColor (ID: 1)'",
                    "end",
                    "end",
                    "local typeValue = Instance.new('NumberValue')",
                    "typeValue.Name = 'CustomizationType'",
                    "typeValue.Parent = BodyColor",
                    "typeValue.Value = 1",
                    "local indexValue = Instance.new('NumberValue')",
                    "indexValue.Name = 'ColorIndex'",
                    "indexValue.Parent = BodyColor",
                    "indexValue.Value = i",
                    "end",
                    "for i=1,3,1 do",
                    "local newHat = Instance.new('StringValue',newCharApp)",
                    "if (i == 1) then",
                    "if (Hat1ID ~= nil) then",
                    "newHat.Value = Hat1ID",
                    "newHat.Name = Hat1ID",
                    "else",
                    "newHat.Value = 'NoHat.rbxm'",
                    "newHat.Name = 'NoHat.rbxm'",
                    "end",
                    "elseif (i == 2) then",
                    "if (Hat2ID ~= nil) then",
                    "newHat.Value = Hat2ID",
                    "newHat.Name = Hat2ID",
                    "else",
                    "newHat.Value = 'NoHat.rbxm'",
                    "newHat.Name = 'NoHat.rbxm'",
                    "end",
                    "elseif (i == 3) then",
                    "if (Hat3ID ~= nil) then",
                    "newHat.Value = Hat3ID",
                    "newHat.Name = Hat3ID",
                    "else",
                    "newHat.Value = 'NoHat.rbxm'",
                    "newHat.Name = 'NoHat.rbxm'",
                    "end",
                    "end",
                    "local typeValue = Instance.new('NumberValue')",
                    "typeValue.Name = 'CustomizationType'",
                    "typeValue.Parent = newHat",
                    "typeValue.Value = 2",
                    "end",
                    "local newTShirt = Instance.new('StringValue',newCharApp)",
                    "if (TShirtID ~= nil or TShirtID ~= '0') then",
                    "newTShirt.Value = TShirtID",
                    "else",
                    "newTShirt.Value = '0'",
                    "end",
                    "newTShirt.Name = 'T-Shirt'",
                    "local typeValue = Instance.new('NumberValue')",
                    "typeValue.Name = 'CustomizationType'",
                    "typeValue.Parent = newTShirt",
                    "typeValue.Value = 3",
                    "local newShirt = Instance.new('StringValue',newCharApp)",
                    "if (ShirtID ~= nil or ShirtID ~= '0') then",
                    "newShirt.Value = ShirtID",
                    "else",
                    "newShirt.Value = '0'",
                    "end",
                    "newShirt.Name = 'Shirt'",
                    "local typeValue = Instance.new('NumberValue')",
                    "typeValue.Name = 'CustomizationType'",
                    "typeValue.Parent = newShirt",
                    "typeValue.Value = 4",
                    "local newPants = Instance.new('StringValue',newCharApp)",
                    "if (PantsID ~= nil or PantsID ~= '0') then",
                    "newPants.Value = PantsID",
                    "else",
                    "newPants.Value = '0'",
                    "end",
                    "newPants.Name = 'Pants'",
                    "local typeValue = Instance.new('NumberValue')",
                    "typeValue.Name = 'CustomizationType'",
                    "typeValue.Parent = newPants",
                    "typeValue.Value = 5",
                    "local newFace = Instance.new('StringValue',newCharApp)",
                    "if (FaceID ~= nil) then",
                    "newFace.Value = FaceID",
                    "newFace.Name = FaceID",
                    "else",
                    "newFace.Value = 'DefaultFace.rbxm'",
                    "newFace.Name = 'DefaultFace.rbxm'",
                    "end",
                    "local typeValue = Instance.new('NumberValue')",
                    "typeValue.Name = 'CustomizationType'",
                    "typeValue.Parent = newFace",
                    "typeValue.Value = 6",
                    "local newHead = Instance.new('StringValue',newCharApp)",
                    "if (HeadID ~= nil) then",
                    "newHead.Value = HeadID",
                    "newHead.Name = HeadID",
                    "else",
                    "newHead.Value = 'DefaultHead.rbxm'",
                    "newHead.Name = 'DefaultHead.rbxm'",
                    "end",
                    "local typeValue = Instance.new('NumberValue')",
                    "typeValue.Name = 'CustomizationType'",
                    "typeValue.Parent = newHead",
                    "typeValue.Value = 7",
                    "for i=2,5,1 do",
                    "local BodyMesh = Instance.new('StringValue',newCharApp)",
                    "local BodyMesh2 = Instance.new('StringValue',newCharApp)",
                    "local BodyMesh3 = Instance.new('StringValue',newCharApp)",
                    "local BodyMesh4 = Instance.new('StringValue',newCharApp)",
                    "local BodyMesh5 = Instance.new('StringValue',newCharApp)",
                    "if (i == 2) then",
                    "if (TorsoID ~= nil) then",
                    "BodyMesh.Value = TorsoID",
                    "BodyMesh.Name = TorsoID",
                    "else",
                    "BodyMesh.Value = 'DefaultTorso.rbxm'",
                    "BodyMesh.Name = 'DefaultTorso.rbxm'",
                    "end",
                    "elseif (i == 3) then",
                    "if (LArmID ~= nil) then",
                    "BodyMesh2.Value = LArmID",
                    "BodyMesh2.Name = LArmID",
                    "else",
                    "BodyMesh2.Value = 'DefaultLArm.rbxm'",
                    "BodyMesh2.Name = 'DefaultLArm.rbxm'",
                    "end",
                    "elseif (i == 4) then",
                    "if (RArmID ~= nil) then",
                    "BodyMesh3.Value = RArmID",
                    "BodyMesh3.Name = RArmID",
                    "else",
                    "BodyMesh3.Value = 'DefaultRArm.rbxm'",
                    "BodyMesh3.Name = 'DefaultRArm.rbxm'",
                    "end",
                    "elseif (i == 5) then",
                    "if (LLegID ~= nil) then",
                    "BodyMesh4.Value = LLegID",
                    "BodyMesh4.Name = LLegID",
                    "else",
                    "BodyMesh4.Value = 'DefaultLLeg.rbxm'",
                    "BodyMesh4.Name = 'DefaultLLeg.rbxm'",
                    "end",
                    "elseif (i == 6) then",
                    "if (RLegID ~= nil) then",
                    "BodyMesh5.Value = RLegID",
                    "BodyMesh5.Name = RLegID",
                    "else",
                    "BodyMesh5.Value = 'DefaultRLeg.rbxm'",
                    "BodyMesh5.Name = 'DefaultRLeg.rbxm'",
                    "end",
                    "end",
                    "local typeValue = Instance.new('NumberValue')",
                    "typeValue.Name = 'CustomizationType'",
                    "typeValue.Parent = BodyMesh",
                    "typeValue.Value = 8",
                    "local typeValue2 = Instance.new('NumberValue')",
                    "typeValue2.Name = 'CustomizationType'",
                    "typeValue2.Parent = BodyMesh2",
                    "typeValue2.Value = 8",
                    "local typeValue3 = Instance.new('NumberValue')",
                    "typeValue3.Name = 'CustomizationType'",
                    "typeValue3.Parent = BodyMesh3",
                    "typeValue3.Value = 8",
                    "local typeValue4 = Instance.new('NumberValue')",
                    "typeValue4.Name = 'CustomizationType'",
                    "typeValue4.Parent = BodyMesh4",
                    "typeValue4.Value = 8",
                    "local typeValue5 = Instance.new('NumberValue')",
                    "typeValue5.Name = 'CustomizationType'",
                    "typeValue5.Parent = BodyMesh5",
                    "typeValue5.Value = 8",
                    "local indexValue = Instance.new('NumberValue')",
                    "indexValue.Name = 'MeshIndex'",
                    "indexValue.Parent = BodyMesh",
                    "indexValue.Value = i",
                    "local indexValue2 = Instance.new('NumberValue')",
                    "indexValue2.Name = 'MeshIndex'",
                    "indexValue2.Parent = BodyMesh2",
                    "indexValue2.Value = i",
                    "local indexValue3 = Instance.new('NumberValue')",
                    "indexValue3.Name = 'MeshIndex'",
                    "indexValue3.Parent = BodyMesh3",
                    "indexValue3.Value = i",
                    "local indexValue4 = Instance.new('NumberValue')",
                    "indexValue4.Name = 'MeshIndex'",
                    "indexValue4.Parent = BodyMesh4",
                    "indexValue4.Value = i",
                    "local indexValue5 = Instance.new('NumberValue')",
                    "indexValue5.Name = 'MeshIndex'",
                    "indexValue5.Parent = BodyMesh5",
                    "indexValue5.Value = i",
                    "end",
                    "for i=1,3,1 do",
                    "local newGear = Instance.new('StringValue',newCharApp)",
                    "if (i == 1) then",
                    "if (Gear1 ~= nil) then",
                    "newGear.Value = Gear1",
                    "newGear.Name = Gear1",
                    "else",
                    "newGear.Value = 'NoGear.rbxm'",
                    "newGear.Name = 'NoGear.rbxm'",
                    "end",
                    "elseif (i == 2) then",
                    "if (Gear2 ~= nil) then",
                    "newGear.Value = Gear2",
                    "newGear.Name = Gear2",
                    "else",
                    "newGear.Value = 'NoGear.rbxm'",
                    "newGear.Name = 'NoGear.rbxm'",
                    "end",
                    "elseif (i == 3) then",
                    "if (Gear3 ~= nil) then",
                    "newGear.Value = Gear3",
                    "newGear.Name = Gear3",
                    "else",
                    "newGear.Value = 'NoGear.rbxm'",
                    "newGear.Name = 'NoGear.rbxm'",
                    "end",
                    "end",
                    "local typeValue = Instance.new('NumberValue')",
                    "typeValue.Name = 'CustomizationType'",
                    "typeValue.Parent = newGear",
                    "typeValue.Value = 9",
                    "end",
                    "end"
                   );

                string serverside = MultiLine(
                    "function LoadCharacterNew(playerApp,newChar,newBackpack)",
                    "local charparts = {[1] = newWaitForChild(newChar,'Head'),[2] = newWaitForChild(newChar,'Torso'),[3] = newWaitForChild(newChar,'Left Arm'),[4] = newWaitForChild(newChar,'Right Arm'),[5] = newWaitForChild(newChar,'Left Leg'),[6] = newWaitForChild(newChar,'Right Leg')}",
                    "for _,newVal in pairs(playerApp:GetChildren()) do",
                    "newWaitForChild(newVal,'CustomizationType')",
                    "local customtype = newVal:FindFirstChild('CustomizationType')",
                    "if (customtype.Value == 1) then ",
                    "pcall(function() ",
                    "newWaitForChild(newVal,'ColorIndex')",
                    "local colorindex = newVal:FindFirstChild('ColorIndex')",
                    "charparts[colorindex.Value].BrickColor = newVal.Value ",
                    "end)",
                    "elseif (customtype.Value == 2) then",
                    "if (rbxlegacyversion > 0) then",
                    "pcall(function()",
                    "local newHat = game.Workspace:InsertContent('rbxasset://../../../avatar/hats/'..newVal.Value)",
                    "if newHat[1] then ",
                    "if newHat[1].className == 'Hat' then",
                    "newHat[1].Parent = newChar",
                    "else",
                    "newHat[1]:remove()",
                    "end",
                    "end",
                    "end)",
                    "end",
                    "elseif (customtype.Value == 3) then",
                    "if (rbxlegacyversion > 0) then",
                    "pcall(function()",
                    "local newTShirt = game.Workspace:InsertContent('http://www.roblox.com/asset/?id='..newVal.Value)",
                    "if newTShirt[1] then ",
                    "if newTShirt[1].className == 'ShirtGraphic' then",
                    "newTShirt[1].Parent = newChar",
                    "else",
                    "newTShirt[1]:remove()",
                    "end",
                    "end",
                    "end)",
                    "end",
                    "elseif (customtype.Value == 4) then",
                    "if (rbxlegacyversion > 1) then",
                    "pcall(function()",
                    "local newShirt = game.Workspace:InsertContent('http://www.roblox.com/asset/?id='..newVal.Value)",
                    "if newShirt[1] then ",
                    "if newShirt[1].className == 'Shirt' then",
                    "newShirt[1].Parent = newChar",
                    "else",
                    "newShirt[1]:remove()",
                    "end",
                    "end",
                    "end)",
                    "end",
                    "elseif (customtype.Value == 5) then",
                    "if (rbxlegacyversion > 1) then",
                    "pcall(function()",
                    "local newPants = game.Workspace:InsertContent('http://www.roblox.com/asset/?id='..newVal.Value)",
                    "if newPants[1] then ",
                    "if newPants[1].className == 'Pants' then",
                    "newPants[1].Parent = newChar",
                    "else",
                    "newPants[1]:remove()",
                    "end",
                    "end",
                    "end)",
                    "end",
                    "elseif (customtype.Value == 6) then",
                    "if (rbxlegacyversion > 2) then",
                    "pcall(function()",
                    "local newFace = game.Workspace:InsertContent('rbxasset://../../../avatar/faces/'..newVal.Value)",
                    "if newFace[1] then ",
                    "if newFace[1].className == 'Decal' then",
                    "newWaitForChild(charparts[1],'face'):remove()",
                    "newFace[1].Parent = charparts[1]",
                    "newFace[1].Face = 'Front'",
                    "else",
                    "newFace[1]:remove()",
                    "end",
                    "end",
                    "end)",
                    "end",
                    "elseif (customtype.Value == 7) then ",
                    "if (rbxlegacyversion > 2) then",
                    "pcall(function()",
                    "local newPart = game.Workspace:InsertContent('rbxasset://../../../avatar/heads/'..newVal.Value)",
                    "if newPart[1] then ",
                    "if newPart[1].className == 'SpecialMesh' or newPart[1].className == 'CylinderMesh' or newPart[1].className == 'BlockMesh' then",
                    "newWaitForChild(charparts[1],'Mesh'):remove()",
                    "newPart[1].Parent = charparts[1]",
                    "else",
                    "newPart[1]:remove()",
                    "end",
                    "end",
                    "end)",
                    "end",
                    "elseif (customtype.Value == 8) then ",
                    "if (rbxlegacyversion > 3) then",
                    "pcall(function()",
                    "local meshindex = newVal:FindFirstChild('MeshIndex')",
                    "local newPart = game.Workspace:InsertContent('rbxasset://../../../avatar/bodies/'..meshindex.Value..'/'..newVal.Value)",
                    "if newPart[1] then ",
                    "if newPart[1].className == 'SpecialMesh' then",
                    "newWaitForChild(newVal,'MeshIndex')",
                    "newPart[1].Parent = charparts[meshindex.Value]",
                    "else",
                    "newPart[1]:remove()",
                    "end",
                    "end",
                    "end)",
                    "end",
                    "elseif (customtype.Value == 9) then ",
                    "if (rbxlegacyversion > 2) then",
                    "pcall(function()",
                    "local newGear = game.Workspace:InsertContent('rbxasset://../../../avatar/gears/'..newVal.Value)",
                    "if newGear[1] then ",
                    "if newGear[1].className == 'Tool' then",
                    "if (ReadGearInfo(newGear[1], playerApp) == true) then",
                    "if (playerApp.StarterGear) then",
                    "for _,gearCheck in pairs(playerApp.StarterGear:GetChildren()) do",
                    "if (gearCheck ~= nil) then",
                    "if (gearCheck:isA('Tool')) then",
                    "if (gearCheck.Name ~= newGear[1].Name) then",
                    "newGear[1].Parent = playerApp.StarterGear",
                    "else",
                    "newGear[1]:remove()",
                    "end",
                    "end",
                    "end",
                    "end",
                    "else",
                    "for _,gearCheck in pairs(playerApp.Backpack:GetChildren()) do",
                    "if (gearCheck ~= nil) then",
                    "if (gearCheck:isA('Tool')) then",
                    "if (gearCheck.Name ~= newGear[1].Name) then",
                    "newGear[1].Parent = playerApp.Backpack",
                    "else",
                    "newGear[1]:remove()",
                    "end",
                    "end",
                    "end",
                    "end",
                    "end",
                    "else",
                    "newGear[1]:remove()",
                    "end",
                    "else",
                    "newGear[1]:remove()",
                    "end",
                    "end",
                    "end)",
                    "end",
                    "end",
                    "end",
                    "end",
                    "function ReadGearInfo(newTool,player)",
                    "if newTool.className == 'Tool' then",
                    "for _,GearVal in pairs(newTool:GetChildren()) do",
                    "newWaitForChild(GearVal,'GearType')",
                    "local GearType = newTool:FindFirstChild('GearType')",
                    "newWaitForChild(game.Lighting,'AllowedGearTypes')",
                    "if (GearType == 1) then",
                    "if (game.Lighting.AllowedGearTypes.Melee == true) then",
                    "return true",
                    "end",
                    "elseif (GearType == 2) then",
                    "if (game.Lighting.AllowedGearTypes.PowerUp == true) then",
                    "return true",
                    "end",
                    "elseif (GearType == 3) then",
                    "if (game.Lighting.AllowedGearTypes.Ranged == true) then",
                    "return true",
                    "end",
                    "elseif (GearType == 4) then",
                    "if (game.Lighting.AllowedGearTypes.Navigation == true) then",
                    "return true",
                    "end",
                    "elseif (GearType == 5) then",
                    "if (game.Lighting.AllowedGearTypes.Explosives == true) then",
                    "return true",
                    "end",
                    "elseif (GearType == 6) then",
                    "if (game.Lighting.AllowedGearTypes.Musical == true) then",
                    "return true",
                    "end",
                    "elseif (GearType == 7) then",
                    "if (game.Lighting.AllowedGearTypes.Social == true) then",
                    "return true",
                    "end",
                    "elseif (GearType == 8) then",
                    "if (game.Lighting.AllowedGearTypes.Transport == true) then",
                    "return true",
                    "end",
                    "elseif (GearType == 9) then",
                    "if (game.Lighting.AllowedGearTypes.Building == true) then",
                    "return true",
                    "end",
                    "end",
                    "end",
                    "else",
                    "return false",
                    "end",
                    "end"
                   );

                string customizationgen = "";

                if (type == ScriptType.Join)
                {
                    customizationgen = clientside;
                }
                else if (type == ScriptType.Server)
                {
                    customizationgen = serverside;
                }
                else if (type == ScriptType.Solo || type == ScriptType.CharacterView)
                {
                    customizationgen = MultiLine(
                        clientside,
                        serverside
                        );
                }

                //finally, we generate the actual script code.

                string code = "";

                if (type == ScriptType.Join)
                {
                    code = MultiLine(
                        "if (rbxlegacyversion > 3) then",
                        "pcall(function() game:SetPlaceID(-1, false) end)",
                        "game:GetService('RunService'):Run()",
                        "assert((ServerIP~=nil and ServerPort~=nil),'CSConnect Error: ServerIP and ServerPort must be defined.')",
                        "local function SetMessage(Message) game:SetMessage(Message) end",
                        "local Visit,NetworkClient,PlayerSuccess,Player,ConnectionFailedHook=game:GetService('Visit'),game:GetService('NetworkClient')",
                        "local function GetClassCount(Class,Parent)",
                        "local Objects=Parent:GetChildren()",
                        "local Number=0",
                        "for Index,Object in pairs(Objects) do",
                        "if (Object.className==Class) then",
                        "Number=Number+1",
                        "end",
                        "Number=Number+GetClassCount(Class,Object)",
                        "end",
                        "return Number",
                        "end",
                        "local function RequestCharacter(Replicator)",
                        "local Connection",
                        "Connection=Player.Changed:connect(function(Property)",
                        "if (Property=='Character') then",
                        "game:ClearMessage()",
                        "end",
                        "end)",
                        "SetMessage('Requesting character...')",
                        "Replicator:RequestCharacter()",
                        "SetMessage('Waiting for character...')",
                        "end",
                        "local function Disconnection(Peer,LostConnection)",
                        "SetMessage('You have lost connection to the game')",
                        "end",
                        "local function ConnectionAccepted(Peer,Replicator)",
                        "Replicator.Disconnection:connect(Disconnection)",
                        "local RequestingMarker=true",
                        "game:SetMessageBrickCount()",
                        "local Marker=Replicator:SendMarker()",
                        "Marker.Received:connect(function()",
                        "RequestingMarker=false",
                        "RequestCharacter(Replicator)",
                        "end)",
                        "while RequestingMarker do",
                        "Workspace:ZoomToExtents()",
                        "wait(0.5)",
                        "end",
                        "end",
                        "local function ConnectionFailed(Peer, Code, why)",
                        "SetMessage('Failed to connect to the Game. (ID='..Code..' ['..why..'])')",
                        "end",
                        "pcall(function() settings().Diagnostics:LegacyScriptMode() end)",
                        "pcall(function() game:SetRemoteBuildMode(true) end)",
                        "SetMessage('Connecting to server...')",
                        "NetworkClient.ConnectionAccepted:connect(ConnectionAccepted)",
                        "ConnectionFailedHook=NetworkClient.ConnectionFailed:connect(ConnectionFailed)",
                        "NetworkClient.ConnectionRejected:connect(function()",
                        "pcall(function() ConnectionFailedHook:disconnect() end)",
                        "SetMessage('Failed to connect to the Game. (Connection rejected)')",
                        "end)",
                        "pcall(function() NetworkClient.Ticket=Ticket or '' end)",
                        "PlayerSuccess,Player=pcall(function() return NetworkClient:PlayerConnect(UserID,ServerIP,ServerPort) end)",
                        "if (not PlayerSuccess) then",
                        "SetMessage('Failed to connect to the Game. (Invalid IP Address)')",
                        "NetworkClient:Disconnect()",
                        "end",
                        "if (not PlayerSuccess) then",
                        "local Error,Message=pcall(function()",
                        "Player=game:GetService('Players'):CreateLocalPlayer(UserID)",
                        "NetworkClient:Connect(ServerIP,ServerPort)",
                        "end)",
                        "if (not Error) then",
                        "SetMessage('Failed to connect to the Game.')",
                        "end",
                        "end",
                        "pcall(function() Player:SetUnder13(false) end)",
                        "if (rbxlegacyversion > 4) then",
                        "if (IconType == 'BC') then",
                        "Player:SetMembershipType(Enum.MembershipType.BuildersClub)",
                        "elseif (IconType == 'TBC') then",
                        "Player:SetMembershipType(Enum.MembershipType.TurboBuildersClub)",
                        "elseif (IconType == 'OBC') then",
                        "Player:SetMembershipType(Enum.MembershipType.OutrageousBuildersClub)",
                        "elseif (IconType == 'NBC') then",
                        "Player:SetMembershipType(Enum.MembershipType.None)",
                        "end",
                        "end",
                        "pcall(function() Player:SetAccountAge(365) end)",
                        "Player:SetSuperSafeChat(false)",
                        "Player.CharacterAppearance=0",
                        "pcall(function() Player.Name=PlayerName or '' end)",
                        "pcall(function() Visit:SetUploadUrl('') end)",
                        "game:GetService('Visit')",
                        "if (rbxlegacyversion == 5) then",
                        "game.CoreGui.RobloxGui.TopLeftControl.Help:Remove()",
                        "elseif (rbxlegacyversion > 5) then",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Help:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ReportAbuse:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.RecordToggle:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Screenshot:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ToggleFullScreen:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.TogglePlayMode:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.Exit:Remove()",
                        "waitForChild(Player,'PlayerGui')",
                        "waitForChild(Player.PlayerGui,'UserSettingsShield')",
                        "waitForChild(Player.PlayerGui.UserSettingsShield,'Settings')",
                        "waitForChild(Player.PlayerGui.UserSettingsShield.Settings,'SettingsStyle')",
                        "waitForChild(Player.PlayerGui.UserSettingsShield.Settings.SettingsStyle,'GameSettingsMenu')",
                        "waitForChild(Player.PlayerGui.UserSettingsShield.Settings.SettingsStyle.GameSettingsMenu, 'CameraField')",
                        "waitForChild(Player.PlayerGui.UserSettingsShield.Settings.SettingsStyle.GameSettingsMenu.CameraField, 'DropDownMenuButton')",
                        "UserSettings().GameSettings.ControlMode.Changed:connect(function()",
                        "if UserSettings().GameSettings.ControlMode == Enum.ControlMode['MouseShiftLock'] then ",
                        "if game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible == false then",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible = true",
                        "end",
                        "end",
                        "if UserSettings().GameSettings.ControlMode == Enum.ControlMode['Classic'] then",
                        "if game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible == true then",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible = false",
                        "end",
                        "end",
                        "end)",
                        "end",
                        "if (rbxlegacyversion > 5) then",
                        "Player.CanLoadCharacterAppearance = false",
                        "end",
                        "InitalizeClientAppearance(Player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3)",
                        "local isAdmin = Instance.new('BoolValue')",
                        "isAdmin.Parent = Player",
                        "isAdmin.Name = 'isAdmin'",
                        "isAdmin.Value = IsAdminUser ",
                        "else",
                        "pcall(function() game:SetPlaceID(-1, false) end)",
                        "local suc, err = pcall(function()",
                        "client = game:GetService('NetworkClient')",
                        "player = game:GetService('Players'):CreateLocalPlayer(UserID) ",
                        "player:SetSuperSafeChat(false)",
                        "pcall(function() player:SetUnder13(false) end)",
                        "pcall(function() player:SetAccountAge(365) end)",
                        "player.CharacterAppearance=0",
                        "pcall(function() player.Name=PlayerName or '' end)",
                        "game:GetService('Visit')",
                        "InitalizeClientAppearance(player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3)",
                        "local isAdmin = Instance.new('BoolValue')",
                        "isAdmin.Parent = player",
                        "isAdmin.Name = 'isAdmin'",
                        "isAdmin.Value = IsAdminUser",
                        "end)",
                        "local function dieerror(errmsg)",
                        "game:SetMessage(errmsg)",
                        "wait(math.huge)",
                        "end",
                        "if not suc then",
                        "dieerror(err)",
                        "end",
                        "local function disconnect(peer,lostconnection)",
                        "game:SetMessage('You have lost connection to the game')",
                        "end",
                        "local function connected(url, replicator)",
                        "replicator.Disconnection:connect(disconnect)",
                        "local marker = nil",
                        "local suc, err = pcall(function()",
                        "game:SetMessageBrickCount()",
                        "marker = replicator:SendMarker()",
                        "end)",
                        "if not suc then",
                        "dieerror(err)",
                        "end",
                        "marker.Received:connect(function()",
                        "local suc, err = pcall(function()",
                        "game:ClearMessage()",
                        "end)",
                        "if not suc then",
                        "dieerror(err)",
                        "end",
                        "end)",
                        "end",
                        "local function rejected()",
                        "dieerror('Failed to connect to the Game. (Connection rejected)')",
                        "end",
                        "local function failed(peer, errcode, why)",
                        "dieerror('Failed to connect to the Game. (ID='..errcode..' ['..why..'])')",
                        "end",
                        "local suc, err = pcall(function()",
                        "game:SetMessage('Connecting to server...')",
                        "client.ConnectionAccepted:connect(connected)",
                        "client.ConnectionRejected:connect(rejected)",
                        "client.ConnectionFailed:connect(failed)",
                        "client:Connect(ServerIP,ServerPort, 0, 20)",
                        "end)",
                        "if not suc then",
                        "local x = Instance.new('Message')",
                        "x.Text = err",
                        "x.Parent = workspace",
                        "wait(math.huge)",
                        "end",
                        "end"
                        );
                }
                else if (type == ScriptType.Server)
                {
                    code = MultiLine(
                        "assert((type(Port)~='number' or tonumber(Port)~=nil or Port==nil),'CSRun Error: Port must be nil or a number.')",
                        "local NetworkServer=game:GetService('NetworkServer')",
                        "local RunService=game:GetService('RunService')",
                        "pcall(NetworkServer.Stop,NetworkServer)",
                        "if (rbxlegacyversion >= 5) then",
                        "NetworkServer:Start(Port)",
                        "RunService:Run()",
                        "else",
                        "NetworkServer:start(Port, 20)",
                        "RunService:run()",
                        "end",
                        "game.Workspace:InsertContent('rbxasset://fonts/libraries.rbxm')",
                        "game:GetService('Players').PlayerAdded:connect(function(Player)",
                        "if (rbxlegacyversion < 6) then",
                        "game:GetService('Players').MaxPlayers = PlayerLimit",
                        "if (game:GetService('Players').NumPlayers > game:GetService('Players').MaxPlayers) then",
                        "local message = Instance.new('Message')",
                        "message.Text = 'You were kicked. Reason: Too many players on server.'",
                        "message.Parent = Player",
                        "wait(2)",
                        "Player:remove()",
                        "print('Player '' .. Player.Name .. '' with ID '' .. Player.userId .. '' kicked. Reason: Too many players on server.')",
                        "end",
                        "end",
                        "if (Player.userId == Blacklist1 or Player.userId == Blacklist2 or Player.userId == Blacklist3 or Player.userId == Blacklist4 or Player.userId == Blacklist5 or Player.userId == Blacklist6 or Player.userId == Blacklist7 or Player.userId == Blacklist8) then",
                        "local message = Instance.new('Message')",
                        "message.Text = 'You have been blacklisted from this server.'",
                        "message.Parent = Player",
                        "wait(2)",
                        "Player:remove()",
                        "print('Player '' .. Player.Name .. '' with ID '' .. Player.userId .. '' kicked. Reason: Player is banned from playing this server.')",
                        "else",
                        "print('Player '' .. Player.Name .. '' with ID '' .. Player.userId .. '' added')",
                        "Player:LoadCharacter()",
                        "if (rbxlegacyversion < 5) then",
                        "LoadCharacterNew(newWaitForChild(Player,'Appearance'),Player.Character,Player.Backpack)",
                        "end",
                        "end",
                        "if (rbxlegacyversion >= 5) then",
                        "Player.CharacterAdded:connect(function(char)",
                        "LoadCharacterNew(newWaitForChild(Player,'Appearance'),Player.Character,Player.Backpack)",
                        "end)",
                        "Player.Changed:connect(function(Property)",
                        "if (Property=='Character') and (Player.Character~=nil) then",
                        "local Character=Player.Character",
                        "local Humanoid=Character:FindFirstChild('Humanoid')",
                        "if (Humanoid~=nil) then",
                        "Humanoid.Died:connect(function() delay(RespawnTime,function() Player:LoadCharacter() LoadCharacterNew(newWaitForChild(Player,'Appearance'),Player.Character,Player.Backpack) end) end)",
                        "end",
                        "end",
                        "end)",
                        "else",
                        "while true do ",
                        "wait(0.001)",
                        "if (Player.Character ~= nil) then",
                        "if (Player.Character.Humanoid.Health == 0) then",
                        "wait(RespawnTime)",
                        "Player:LoadCharacter()",
                        "LoadCharacterNew(newWaitForChild(Player,'Appearance'),Player.Character,Player.Backpack)",
                        "elseif (Player.Character.Parent == nil) then ",
                        "wait(RespawnTime)",
                        "Player:LoadCharacter()",
                        "LoadCharacterNew(newWaitForChild(Player,'Appearance'),Player.Character,Player.Backpack)",
                        "end",
                        "end",
                        "end",
                        "end",
                        "end)",
                        "game:GetService('Players').PlayerRemoving:connect(function(Player)",
                        "print('Player '' .. Player.Name .. '' with ID '' .. Player.userId .. '' leaving')",
                        "end)",
                        "pcall(function() game.Close:connect(function() NetworkServer:Stop() end) end)",
                        "NetworkServer.IncommingConnection:connect(IncommingConnection)",
                        "if IsPersonalServer == true then",
                        "pcall(function() game:GetService('PersonalServerService') end)",
                        "pcall(function() game.IsPersonalServer(true) end)",
                        "end",
                        "local HostIDValue = Instance.new('StringValue')",
                        "HostIDValue.Parent = game.Lighting",
                        "HostIDValue.Name = 'HostID'",
                        "HostIDValue.Value = '' .. HostID .. ''",
                        "local AllowedGearTypes = Instance.new('StringValue')",
                        "AllowedGearTypes.Name = 'AllowedGearTypes'",
                        "AllowedGearTypes.Parent = game.Lighting",
                        "local MeleeGTR = Instance.new('BoolValue')",
                        "MeleeGTR.Parent = AllowedGearTypes",
                        "MeleeGTR.Name = 'Melee'",
                        "MeleeGTR.Value = MeleeGT",
                        "local PowerUpGTR = Instance.new('BoolValue')",
                        "PowerUpGTR.Parent = AllowedGearTypes",
                        "PowerUpGTR.Name = 'PowerUp'",
                        "PowerUpGTR.Value = PowerUpGT",
                        "local RangedGTR = Instance.new('BoolValue')",
                        "RangedGTR.Parent = AllowedGearTypes",
                        "RangedGTR.Name = 'Ranged'",
                        "RangedGTR.Value = RangedGT",
                        "local NavigationGTR = Instance.new('BoolValue')",
                        "NavigationGTR.Parent = AllowedGearTypes",
                        "NavigationGTR.Name = 'Navigation'",
                        "NavigationGTR.Value = NavigationGT",
                        "local ExplosivesGTR = Instance.new('BoolValue')",
                        "ExplosivesGTR.Parent = AllowedGearTypes",
                        "ExplosivesGTR.Name = 'Explosives'",
                        "ExplosivesGTR.Value = ExplosivesGT",
                        "local MusicalGTR = Instance.new('BoolValue')",
                        "MusicalGTR.Parent = AllowedGearTypes",
                        "MusicalGTR.Name = 'Musical'",
                        "MusicalGTR.Value = MusicalGT",
                        "local SocialGTR = Instance.new('BoolValue')",
                        "SocialGTR.Parent = AllowedGearTypes",
                        "SocialGTR.Name = 'Social'",
                        "SocialGTR.Value = SocialGT",
                        "local TransportGTR = Instance.new('BoolValue')",
                        "TransportGTR.Parent = AllowedGearTypes",
                        "TransportGTR.Name = 'Transport'",
                        "TransportGTR.Value = TransportGT",
                        "local BuildingGTR = Instance.new('BoolValue')",
                        "BuildingGTR.Parent = AllowedGearTypes",
                        "BuildingGTR.Name = 'Building'",
                        "BuildingGTR.Value = BuildingGT",
                        "if rbxlegacyversion >= 4 then",
                        "if ChatType == 'Both' then",
                        "pcall(function() game:GetService('Players'):SetChatStyle(Enum.ChatStyle.ClassicAndBubble) end)",
                        "elseif ChatType == 'Classic' then",
                        "pcall(function() game:GetService('Players'):SetChatStyle(Enum.ChatStyle.Classic) end)",
                        "elseif ChatType == 'Bubble' then",
                        "pcall(function() game:GetService('Players'):SetChatStyle(Enum.ChatStyle.Bubble) end)",
                        "end",
                        "end"
                         );
                }
                else if (type == ScriptType.Solo)
                {
                    code = MultiLine(
                        "if (rbxlegacyversion > 5) then",
                        "game:GetService('RunService'):Run()",
                        "else",
                        "game:GetService('RunService'):run()",
                        "end",
                        "game.Workspace:InsertContent('rbxasset://fonts//libraries.rbxm')",
                        "if (rbxlegacyversion == 6) then",
                        "waitForChild(game.StarterGui,'Playerlist')",
                        "waitForChild(game.StarterGui,'Menu')",
                        "waitForChild(game.StarterGui,'Backpack')",
                        "waitForChild(game.StarterGui,'Dialogs')",
                        "waitForChild(game.StarterGui,'Health')",
                        "waitForChild(game.StarterGui,'Notifications')",
                        "game.StarterGui.Menu.Workaround:remove()",
                        "elseif (rbxlegacyversion > 6) then",
                        "waitForChild(game.StarterGui,'Playerlist')",
                        "waitForChild(game.StarterGui,'Menu')",
                        "waitForChild(game.StarterGui,'Backpack')",
                        "waitForChild(game.StarterGui,'Dialogs')",
                        "waitForChild(game.StarterGui,'Health')",
                        "waitForChild(game.StarterGui,'Notifications')",
                        "waitForChild(game.StarterGui,'Chat')",
                        "game.StarterGui.Menu.Workaround:remove()",
                        "elseif (rbxlegacyversion == 4) then",
                        "waitForChild(game.StarterGui,'Health')",
                        "end",
                        "local AllowedGearTypes = Instance.new('StringValue')",
                        "AllowedGearTypes.Name = 'AllowedGearTypes'",
                        "AllowedGearTypes.Parent = game.Lighting",
                        "local MeleeGTR = Instance.new('BoolValue')",
                        "MeleeGTR.Parent = AllowedGearTypes",
                        "MeleeGTR.Name = 'Melee'",
                        "MeleeGTR.Value = MeleeGT",
                        "local PowerUpGTR = Instance.new('BoolValue')",
                        "PowerUpGTR.Parent = AllowedGearTypes",
                        "PowerUpGTR.Name = 'PowerUp'",
                        "PowerUpGTR.Value = PowerUpGT",
                        "local RangedGTR = Instance.new('BoolValue')",
                        "RangedGTR.Parent = AllowedGearTypes",
                        "RangedGTR.Name = 'Ranged'",
                        "RangedGTR.Value = RangedGT",
                        "local NavigationGTR = Instance.new('BoolValue')",
                        "NavigationGTR.Parent = AllowedGearTypes",
                        "NavigationGTR.Name = 'Navigation'",
                        "NavigationGTR.Value = NavigationGT",
                        "local ExplosivesGTR = Instance.new('BoolValue')",
                        "ExplosivesGTR.Parent = AllowedGearTypes",
                        "ExplosivesGTR.Name = 'Explosives'",
                        "ExplosivesGTR.Value = ExplosivesGT",
                        "local MusicalGTR = Instance.new('BoolValue')",
                        "MusicalGTR.Parent = AllowedGearTypes",
                        "MusicalGTR.Name = 'Musical'",
                        "MusicalGTR.Value = MusicalGT",
                        "local SocialGTR = Instance.new('BoolValue')",
                        "SocialGTR.Parent = AllowedGearTypes",
                        "SocialGTR.Name = 'Social'",
                        "SocialGTR.Value = SocialGT",
                        "local TransportGTR = Instance.new('BoolValue')",
                        "TransportGTR.Parent = AllowedGearTypes",
                        "TransportGTR.Name = 'Transport'",
                        "TransportGTR.Value = TransportGT",
                        "local BuildingGTR = Instance.new('BoolValue')",
                        "BuildingGTR.Parent = AllowedGearTypes",
                        "BuildingGTR.Name = 'Building'",
                        "BuildingGTR.Value = BuildingGT",
                        "local plr = game.Players:CreateLocalPlayer(UserID)",
                        "plr.Name = PlayerName",
                        "plr:LoadCharacter()",
                        "if (rbxlegacyversion == 5) then",
                        "game.CoreGui.RobloxGui.TopLeftControl.Help:Remove()",
                        "elseif (rbxlegacyversion > 5) then",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Help:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ReportAbuse:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.RecordToggle:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Screenshot:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ToggleFullScreen:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.TogglePlayMode:Remove()",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.Exit:Remove()",
                        "waitForChild(plr,'PlayerGui')",
                        "waitForChild(plr.PlayerGui,'UserSettingsShield')",
                        "waitForChild(plr.PlayerGui.UserSettingsShield,'Settings')",
                        "waitForChild(plr.PlayerGui.UserSettingsShield.Settings,'SettingsStyle')",
                        "waitForChild(plr.PlayerGui.UserSettingsShield.Settings.SettingsStyle,'GameSettingsMenu')",
                        "waitForChild(plr.PlayerGui.UserSettingsShield.Settings.SettingsStyle.GameSettingsMenu, 'CameraField')",
                        "waitForChild(plr.PlayerGui.UserSettingsShield.Settings.SettingsStyle.GameSettingsMenu.CameraField, 'DropDownMenuButton')",
                        "UserSettings().GameSettings.ControlMode.Changed:connect(function()",
                        "if UserSettings().GameSettings.ControlMode == Enum.ControlMode['MouseShiftLock'] then ",
                        "if game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible == false then",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible = true",
                        "end",
                        "end",
                        "if UserSettings().GameSettings.ControlMode == Enum.ControlMode['Classic'] then",
                        "if game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible == true then",
                        "game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible = false",
                        "end",
                        "end",
                        "end)",
                        "end",
                        "pcall(function() plr:SetUnder13(false) end)",
                        "if (rbxlegacyversion >= 5) then",
                        "if (IconType == 'BC') then",
                        "plr:SetMembershipType(Enum.MembershipType.BuildersClub)",
                        "elseif (IconType == 'TBC') then",
                        "plr:SetMembershipType(Enum.MembershipType.TurboBuildersClub)",
                        "elseif (IconType == 'OBC') then",
                        "plr:SetMembershipType(Enum.MembershipType.OutrageousBuildersClub)",
                        "elseif (IconType == 'NBC') then",
                        "plr:SetMembershipType(Enum.MembershipType.None)",
                        "end",
                        "end",
                        "pcall(function() plr:SetAccountAge(365) end)",
                        "plr.CharacterAppearance=0",
                        "if (rbxlegacyversion > 5) then",
                        "plr.CanLoadCharacterAppearance = false",
                        "end",
                        "InitalizeClientAppearance(plr,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3)",
                        "LoadCharacterNew(newWaitForChild(plr,'Appearance'),plr.Character,plr.Backpack)",
                        "game:GetService('Visit')",
                        "while true do ",
                        "wait(0.001)",
                        "if (plr.Character ~= nil) then",
                        "if (plr.Character.Humanoid.Health == 0) then",
                        "wait(RespawnTime)",
                        "plr:LoadCharacter()",
                        "LoadCharacterNew(newWaitForChild(plr,'Appearance'),plr.Character,plr.Backpack)",
                        "elseif (plr.Character.Parent == nil) then ",
                        "wait(RespawnTime)",
                        "plr:LoadCharacter()",
                        "LoadCharacterNew(newWaitForChild(plr,'Appearance'),plr.Character,plr.Backpack)",
                        "end",
                        "end",
                        "end"
                        );
                }
                else if (type == ScriptType.CharacterView)
                {
                    code = MultiLine(
                        "settings().Rendering.FrameRateManager = 2",
                        "game:GetService('RunService'):run()",
                        "local plr = game.Players:CreateLocalPlayer(UserID)",
                        "plr.Name = PlayerName",
                        "plr:LoadCharacter()",
                        "pcall(function() plr:SetUnder13(false) end)",
                        "pcall(function() plr:SetSuperSafeChat(true) end)",
                        "pcall(function() plr:SetAccountAge(365) end)",
                        "plr.CharacterAppearance=0",
                        "game.CoreGui.RobloxGui:Remove()",
                        "game.GuiRoot.ScoreHud:Remove()",
                        "game.GuiRoot.ChatHud:Remove()",
                        "game.GuiRoot.ChatMenuPanel:Remove()",
                        "if (plr.PlayerGui:FindFirstChild('HealthGUI')) then",
                        "plr.PlayerGui.HealthGUI:Remove()",
                        "end",
                        "pcall(function() game:GetService('ScriptContext').ScriptsDisabled = true end)",
                        "if plr.Character:FindFirstChild('Animate') then",
                        "plr.Character.Animate:Remove()",
                        "end",
                        "InitalizeClientAppearance(plr,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3)",
                        "LoadCharacterNew(newWaitForChild(plr,'Appearance'),plr.Character,plr.Backpack)",
                        "wait(1)",
                        "game:GetService('NetworkClient')"
                        );
                }

                string scriptfile = MultiLine(
                header,
                settings,
                playersettings,
                scriptsettings,
                customizationgen,
                code
                );

                string filename = "";

                if (type == ScriptType.Join)
                {
                    filename = GlobalVars.JoinServerLuaFile;
                }
                else if (type == ScriptType.Server)
                {
                    filename = GlobalVars.StartServerLuaFile;
                }
                else if (type == ScriptType.Solo)
                {
                    filename = GlobalVars.PlaySoloLuaFile;
                }
                else if (type == ScriptType.CharacterView)
                {
                    filename = GlobalVars.CharacterViewLuaFile;
                }
                else if (type == ScriptType.Studio)
                {
                    filename = GlobalVars.StudioLuaFile;
                }

                List<string> list = new List<string>(Regex.Split(scriptfile, Environment.NewLine));
                File.WriteAllLines(filename, list);
            }

            public static bool IsVersionValid(string version)
            {
                if (GlobalVars.ValidClientVersions.Contains(version))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static string GetScriptNameForType(ScriptType type)
            {
                string filename = "";

                if (type == ScriptType.Join)
                {
                    filename = GlobalVars.JoinServerLuaFile;
                }
                else if (type == ScriptType.Server)
                {
                    filename = GlobalVars.StartServerLuaFile;
                }
                else if (type == ScriptType.Solo)
                {
                    filename = GlobalVars.PlaySoloLuaFile;
                }
                else if (type == ScriptType.CharacterView)
                {
                    filename = GlobalVars.CharacterViewLuaFile;
                }
                else if (type == ScriptType.Studio)
                {
                    filename = GlobalVars.StudioLuaFile;
                }

                return filename;
            }

            static string MultiLine(params string[] args)
            {
                return string.Join(Environment.NewLine, args);
            }

        }

        class CryptoRandom : RandomNumberGenerator
        {
            private static RandomNumberGenerator r;

            public CryptoRandom()
            {
                r = RandomNumberGenerator.Create();
            }

            ///<param name=”buffer”>An array of bytes to contain random numbers.</param>
            public override void GetBytes(byte[] buffer)
            {
                r.GetBytes(buffer);
            }

            public override void GetNonZeroBytes(byte[] data)
            {
                r.GetNonZeroBytes(data);
            }
            public double NextDouble()
            {
                byte[] b = new byte[4];
                r.GetBytes(b);
                return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
            }

            ///<param name=”minValue”>The inclusive lower bound of the random number returned.</param>
            ///<param name=”maxValue”>The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
            public int Next(int minValue, int maxValue)
            {
                return (int)Math.Round(NextDouble() * (maxValue - minValue - 1)) + minValue;
            }
            public int Next()
            {
                return Next(0, Int32.MaxValue);
            }

            ///<param name=”maxValue”>The inclusive upper bound of the random number returned. maxValue must be greater than or equal 0</param>
            public int Next(int maxValue)
            {
                return Next(0, maxValue);
            }
        }

        //Discord Rich Presence Integration :D
        public class DiscordRpc
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void ReadyCallback();

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void DisconnectedCallback(int errorCode, string message);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void ErrorCallback(int errorCode, string message);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void JoinCallback(string secret);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void SpectateCallback(string secret);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void RequestCallback(JoinRequest request);

            public struct EventHandlers
            {
                public ReadyCallback readyCallback;
                public DisconnectedCallback disconnectedCallback;
                public ErrorCallback errorCallback;
                public JoinCallback joinCallback;
                public SpectateCallback spectateCallback;
                public RequestCallback requestCallback;
            }

            [System.Serializable]
            public struct RichPresence
            {
                public string state; /* max 128 bytes */
                public string details; /* max 128 bytes */
                public long startTimestamp;
                public long endTimestamp;
                public string largeImageKey; /* max 32 bytes */
                public string largeImageText; /* max 128 bytes */
                public string smallImageKey; /* max 32 bytes */
                public string smallImageText; /* max 128 bytes */
                public string partyId; /* max 128 bytes */
                public int partySize;
                public int partyMax;
                public string matchSecret; /* max 128 bytes */
                public string joinSecret; /* max 128 bytes */
                public string spectateSecret; /* max 128 bytes */
                public bool instance;
            }

            [System.Serializable]
            public struct JoinRequest
            {
                public string userId;
                public string username;
                public string avatar;
            }

            public enum Reply
            {
                No = 0,
                Yes = 1,
                Ignore = 2
            }

            [DllImport("discord-rpc", EntryPoint = "Discord_Initialize", CallingConvention = CallingConvention.Cdecl)]
            public static extern void Initialize(string applicationId, ref EventHandlers handlers, bool autoRegister, string optionalSteamId);

            [DllImport("discord-rpc", EntryPoint = "Discord_Shutdown", CallingConvention = CallingConvention.Cdecl)]
            public static extern void Shutdown();

            [DllImport("discord-rpc", EntryPoint = "Discord_RunCallbacks", CallingConvention = CallingConvention.Cdecl)]
            public static extern void RunCallbacks();

            [DllImport("discord-rpc", EntryPoint = "Discord_UpdatePresence", CallingConvention = CallingConvention.Cdecl)]
            public static extern void UpdatePresence(ref RichPresence presence);

            [DllImport("discord-rpc", EntryPoint = "Discord_Respond", CallingConvention = CallingConvention.Cdecl)]
            public static extern void Respond(string userId, Reply reply);
        }

        public struct Client
        {
            public string MD5, Desc, Version;
            public bool UsesNames, UsesIDs, LegacyMode, HasRocky;

            public Client(string cmd5, string cdesc, string cversion, bool names, bool ids, bool legacy, bool rocky)
            {
                MD5 = cmd5;
                Desc = cdesc;
                Version = cversion;
                UsesNames = names;
                UsesIDs = ids;
                LegacyMode = legacy;
                HasRocky = rocky;
            }
        }

        public struct ClientDef
        {
            public string Name;

            public ClientDef(string cname)
            {
                Name = cname;
            }
        }

        public struct Config
        {
            public string PlayerName, Scheme, SelectedClient;
            public int PlayerID;
            public bool AdminMode, Theme;

            public Config(string cname, int cid, string cscheme, bool ctheme, string clientname, bool admin)
            {
                PlayerName = cname;
                PlayerID = cid;
                Scheme = cscheme;
                Theme = ctheme;
                SelectedClient = clientname;
                AdminMode = admin;
            }
        }

        public struct Info
        {
            public string Version, DefaultSelectedClient;

            public Info(string cversion, string clientname)
            {
                Version = cversion;
                DefaultSelectedClient = clientname;
            }
        }

        public struct Customization
        {
            public string Hat1, Hat2, Hat3, Face, Head, Torso, RightArm, LeftArm, RightLeg, LeftLeg, Gear1, Gear2, Gear3, IconType;
            public int HeadColor, TorsoColor, LeftArmColor, RightArmColor, LeftLegColor, RightLegColor, TShirt, Shirt, Pants;

            public Customization(string chat1, string chat2, string chat3, int headcol, int torsocol, int larmcol, int rarmcol, int llegcol, int rlegcol, int ctshirt, int cshirt, int cpants, string cface, string chead, string ctorso, string clarm, string crarm, string crleg, string clleg, string cgear1, string cgear2, string cgear3, string icon)
            {
                Hat1 = chat1;
                Hat2 = chat2;
                Hat3 = chat3;
                HeadColor = headcol;
                TorsoColor = torsocol;
                LeftArmColor = larmcol;
                RightArmColor = rarmcol;
                LeftLegColor = llegcol;
                RightLegColor = rlegcol;
                TShirt = ctshirt;
                Shirt = cshirt;
                Pants = cpants;
                Face = cface;
                Head = chead;
                Torso = ctorso;
                LeftArm = clarm;
                RightArm = crarm;
                LeftLeg = clleg;
                RightLeg = crleg;
                Gear1 = cgear1;
                Gear2 = cgear2;
                Gear3 = cgear3;
                IconType = icon;
            }
        }

        public struct ServerSettings
        {
            public string ChatType;
            public int Port, PlayerLimit, RespawnTime, Blacklist1, Blacklist2, Blacklist3, Blacklist4, Blacklist5, Blacklist6, Blacklist7, Blacklist8;
            public bool IsPersonalServer, MeleeGears, PowerUpGears, RangedGears, NavigationGears, ExplosivesGears, MusicalGears, SocialGears, TransportGears, BuildingGears;

            public ServerSettings(int cport, int limit, int respawn, bool personal, string chtype, int bl1, int bl2, int bl3, int bl4, int bl5, int bl6, int bl7, int bl8, bool MeleeGT, bool PowerUpGT, bool RangedGT, bool NavigationGT, bool ExplosivesGT, bool MusicalGT, bool SocialGT, bool TransportGT, bool BuildingGT)
            {
                Port = cport;
                PlayerLimit = limit;
                RespawnTime = respawn;
                IsPersonalServer = personal;
                ChatType = chtype;
                Blacklist1 = bl1;
                Blacklist2 = bl2;
                Blacklist3 = bl3;
                Blacklist4 = bl4;
                Blacklist5 = bl5;
                Blacklist6 = bl6;
                Blacklist7 = bl7;
                Blacklist8 = bl8;
                MeleeGears = MeleeGT;
                PowerUpGears = PowerUpGT;
                RangedGears = RangedGT;
                NavigationGears = NavigationGT;
                ExplosivesGears = ExplosivesGT;
                MusicalGears = MusicalGT;
                SocialGears = SocialGT;
                TransportGears = TransportGT;
                BuildingGears = BuildingGT;
            }
        }

        public struct JoinSettings
        {
            public string IP;
            public int Port;

            public JoinSettings(string cip, int cport)
            {
                IP = cip;
                Port = cport;
            }
        }

        public enum ScriptType { Join, Server, Solo, CharacterView, Studio };
    }
}
