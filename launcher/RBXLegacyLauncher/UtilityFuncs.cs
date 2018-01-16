using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RBXLegacyLauncher
{
	public static class GlobalVars 
	{
		public static string ClientDir = "";
		public static string ScriptsDir = "";
		public static string MapsDir = "";
		public static string CustomPlayerDir = "";
		public static string IP = "localhost";
		public static string Version = "";
		public static string MD5 = "";
		public static string SharedArgs = "";
		public static string DefaultScript = "";
		public static string DefaultScriptMD5 = "";
		public static bool AdminMode = false;
		// server settings
		public static string Map = "Baseplate.rbxl";
		public static int RobloxPort = 53640;
		public static int ServerPort = 53640;
		public static int DefaultRobloxPort = 53640;
		public static int PlayerLimit = 12;
		public static int RespawnTime = 5;
		public static bool upnp = true;
		public static int blacklist1 = 0;
		public static int blacklist2 = 0;
		public static int blacklist3 = 0;
		public static int blacklist4 = 0;
		public static int blacklist5 = 0;
		public static int blacklist6 = 0;
		public static int blacklist7 = 0;
		public static int blacklist8 = 0;
		public static string ChatType = "Both";
		// player settings
		public static int UserID = 0;
		public static string PlayerName = "Player";
		// launcher settings
		public static bool CloseOnLaunch = false;
		public static bool LocalPlayMode = false;
		// client shit
		public static string SelectedClient = "";
		public static bool UsesPlayerName = false;
		public static bool UsesID = true;
		public static string SelectedClientDesc = "";
		public static bool LoadsAssetsOnline = false;
		public static bool LegacyMode = false;
		public static string SelectedClientMD5 = "";
		public static int SelectedClientVersion = 0;
		public static bool HasRocky = false;
		// clientinfo creator
		public static bool ClientCreator_UsesPlayerName = false;
		public static bool ClientCreator_UsesID = false;
		public static bool ClientCreator_LoadsAssetsOnline = false;
		public static string ClientCreator_SelectedClientDesc = "";
		public static bool ClientCreator_LegacyMode = false;
		public static string ClientCreator_SelectedClientMD5 = "";
		public static int ClientCreator_SelectedClientVersion = 0;
		public static bool ClientCreator_HasRocky = false;
		// info editor
		public static string InfoEditor_Version = "";
		public static string InfoEditor_DefaultClient = "";
		public static string InfoEditor_ScriptPath = "";
		public static string InfoEditor_ScriptMD5 = "";
		// charcustom
		public static string Custom_Hat1ID_Offline = "NoHat.rbxm";
		public static string Custom_Hat2ID_Offline = "NoHat.rbxm";
		public static string Custom_Hat3ID_Offline = "NoHat.rbxm";
		public static int Custom_TShirt = 0;
		public static int Custom_Shirt = 0;
		public static int Custom_Pants = 0;
		public static string Custom_IconType = "NBC";
		public static int HeadColorID = 24;
		public static int TorsoColorID = 23;
		public static int LeftArmColorID = 24;
		public static int RightArmColorID = 24;
		public static int LeftLegColorID = 119;
		public static int RightLegColorID = 119;
		public static string FaceID = "DefaultFace.rbxm";
		public static string HeadID = "DefaultHead.rbxm";
		public static string ColorMenu_HeadColor = "Color [A=255, R=245, G=205, B=47]";
		public static string ColorMenu_TorsoColor = "Color [A=255, R=13, G=105, B=172]";
		public static string ColorMenu_LeftArmColor = "Color [A=255, R=245, G=205, B=47]";
		public static string ColorMenu_RightArmColor = "Color [A=255, R=245, G=205, B=47]";
		public static string ColorMenu_LeftLegColor = "Color [A=255, R=164, G=189, B=71]";
		public static string ColorMenu_RightLegColor = "Color [A=255, R=164, G=189, B=71]";
		public static DiscordRpc.RichPresence presence;
        public static string appid = "378626645038333952";
        public static string imagekey_large = "rbxlegacy_logo_large";
	}
	
	public class LauncherFuncs
	{
		public LauncherFuncs()
		{
		}
		
		public static void ReadConfigValues(string cfgpath)
		{
			string line1;
			string Decryptline1, Decryptline2, Decryptline3, Decryptline4, Decryptline5, Decryptline6, Decryptline7, Decryptline8, Decryptline9, Decryptline10, Decryptline11, Decryptline12, Decryptline13, Decryptline14, Decryptline15, Decryptline16, Decryptline17, Decryptline18, Decryptline19, Decryptline20, Decryptline21, Decryptline22, Decryptline23, Decryptline24, Decryptline25, Decryptline26;

			using(StreamReader reader = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + cfgpath)) 
			{
    			line1 = reader.ReadLine();
			}
			
			if (!SecurityFuncs.IsBase64String(line1))
				return;
			
			string ConvertedLine = SecurityFuncs.Base64Decode(line1);
			string[] result = ConvertedLine.Split('|');
			Decryptline1 = SecurityFuncs.Base64Decode(result[0]);
    		Decryptline2 = SecurityFuncs.Base64Decode(result[1]);
    		Decryptline3 = SecurityFuncs.Base64Decode(result[2]);
    		Decryptline4 = SecurityFuncs.Base64Decode(result[3]);
    		Decryptline5 = SecurityFuncs.Base64Decode(result[4]);
    		Decryptline6 = SecurityFuncs.Base64Decode(result[5]);
    		Decryptline7 = SecurityFuncs.Base64Decode(result[6]);
    		Decryptline8 = SecurityFuncs.Base64Decode(result[7]);
    		Decryptline9 = SecurityFuncs.Base64Decode(result[8]);
    		Decryptline10 = SecurityFuncs.Base64Decode(result[9]);
    		Decryptline11 = SecurityFuncs.Base64Decode(result[10]);
    		Decryptline12 = SecurityFuncs.Base64Decode(result[11]);
    		Decryptline13 = SecurityFuncs.Base64Decode(result[12]);
    		Decryptline14 = SecurityFuncs.Base64Decode(result[13]);
    		Decryptline15 = SecurityFuncs.Base64Decode(result[14]);
    		Decryptline16 = SecurityFuncs.Base64Decode(result[15]);
    		Decryptline17 = SecurityFuncs.Base64Decode(result[16]);
    		Decryptline18 = SecurityFuncs.Base64Decode(result[17]);
    		Decryptline19 = SecurityFuncs.Base64Decode(result[18]);
    		Decryptline20 = SecurityFuncs.Base64Decode(result[19]);
    		Decryptline21 = SecurityFuncs.Base64Decode(result[20]);
    		Decryptline22 = SecurityFuncs.Base64Decode(result[21]);
    		Decryptline23 = SecurityFuncs.Base64Decode(result[22]);
    		Decryptline24 = SecurityFuncs.Base64Decode(result[23]);
    		Decryptline25 = SecurityFuncs.Base64Decode(result[24]);
    		Decryptline26 = SecurityFuncs.Base64Decode(result[25]);
			
			bool bline1 = Convert.ToBoolean(Decryptline1);
			GlobalVars.CloseOnLaunch = bline1;
			
			int iline2 = Convert.ToInt32(Decryptline2);
			GlobalVars.UserID = iline2;
			
			GlobalVars.PlayerName = Decryptline3;
			
			GlobalVars.SelectedClient = Decryptline4;
			
			GlobalVars.Custom_Hat1ID_Offline = Decryptline5;
			GlobalVars.Custom_Hat2ID_Offline = Decryptline6;
			GlobalVars.Custom_Hat3ID_Offline = Decryptline7;
			
			int iline8 = Convert.ToInt32(Decryptline8);
			GlobalVars.HeadColorID = iline8;
			
			int iline9 = Convert.ToInt32(Decryptline9);
			GlobalVars.TorsoColorID = iline9;
			
			int iline10 = Convert.ToInt32(Decryptline10);
			GlobalVars.LeftArmColorID = iline10;
			
			int iline11 = Convert.ToInt32(Decryptline11);
			GlobalVars.RightArmColorID = iline11;
			
			int iline12 = Convert.ToInt32(Decryptline12);
			GlobalVars.LeftLegColorID = iline12;
			
			int iline13 = Convert.ToInt32(Decryptline13);
			GlobalVars.RightLegColorID = iline13;
			
			GlobalVars.ColorMenu_HeadColor = Decryptline14;
			GlobalVars.ColorMenu_TorsoColor = Decryptline15;
			GlobalVars.ColorMenu_LeftArmColor = Decryptline16;
			GlobalVars.ColorMenu_RightArmColor = Decryptline17;
			GlobalVars.ColorMenu_LeftLegColor = Decryptline18;
			GlobalVars.ColorMenu_RightLegColor = Decryptline19;

			int iline20 = Convert.ToInt32(Decryptline20);
			GlobalVars.Custom_TShirt = iline20;
			int iline21 = Convert.ToInt32(Decryptline21);
			GlobalVars.Custom_Shirt = iline21;
			int iline22 = Convert.ToInt32(Decryptline22);
			GlobalVars.Custom_Pants = iline22;
			
			GlobalVars.Custom_IconType = Decryptline23;
			
			GlobalVars.FaceID = Decryptline24;
			GlobalVars.HeadID = Decryptline25;
			
			bool bline26 = Convert.ToBoolean(Decryptline26);
			GlobalVars.AdminMode = bline26;
		}
		
		public static void ReadServerPrefs(string cfgpath)
		{
			string line1;
			string Decryptline1, Decryptline2, Decryptline3, Decryptline4, Decryptline5, Decryptline6, Decryptline7, Decryptline8, Decryptline9, Decryptline10, Decryptline11, Decryptline12, Decryptline13, Decryptline14, Decryptline15;

			using(StreamReader reader = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + cfgpath)) 
			{
    			line1 = reader.ReadLine();
			}
			
			if (!SecurityFuncs.IsBase64String(line1))
				return;
			
			string ConvertedLine = SecurityFuncs.Base64Decode(line1);
			string[] result = ConvertedLine.Split('|');
			Decryptline1 = SecurityFuncs.Base64Decode(result[0]);
    		Decryptline2 = SecurityFuncs.Base64Decode(result[1]);
    		Decryptline3 = SecurityFuncs.Base64Decode(result[2]);
    		Decryptline4 = SecurityFuncs.Base64Decode(result[3]);
    		Decryptline5 = SecurityFuncs.Base64Decode(result[4]);
    		Decryptline6 = SecurityFuncs.Base64Decode(result[5]);
    		Decryptline7 = SecurityFuncs.Base64Decode(result[6]);
    		Decryptline8 = SecurityFuncs.Base64Decode(result[7]);
    		Decryptline9 = SecurityFuncs.Base64Decode(result[8]);
    		Decryptline10 = SecurityFuncs.Base64Decode(result[9]);
    		Decryptline11 = SecurityFuncs.Base64Decode(result[10]);
    		Decryptline12 = SecurityFuncs.Base64Decode(result[11]);
    		Decryptline13 = SecurityFuncs.Base64Decode(result[12]);
    		Decryptline14 = SecurityFuncs.Base64Decode(result[13]);
    		Decryptline15 = SecurityFuncs.Base64Decode(result[14]);
			
			GlobalVars.Map = Decryptline1;
			
			int iline2 = Convert.ToInt32(Decryptline2);
			GlobalVars.ServerPort = iline2;
			
			int iline3 = Convert.ToInt32(Decryptline3);
			GlobalVars.DefaultRobloxPort = iline3;
			
			int iline4 = Convert.ToInt32(Decryptline4);
			GlobalVars.PlayerLimit = iline4;
			
			int iline5 = Convert.ToInt32(Decryptline5);
			GlobalVars.RespawnTime = iline5;
			
			int iline6 = Convert.ToInt32(Decryptline6);
			GlobalVars.blacklist1 = iline6;
			int iline7 = Convert.ToInt32(Decryptline7);
			GlobalVars.blacklist2 = iline7;
			int iline8 = Convert.ToInt32(Decryptline8);
			GlobalVars.blacklist3 = iline8;
			int iline9 = Convert.ToInt32(Decryptline9);
			GlobalVars.blacklist4 = iline9;
			int iline10 = Convert.ToInt32(Decryptline10);
			GlobalVars.blacklist5 = iline10;
			int iline11 = Convert.ToInt32(Decryptline11);
			GlobalVars.blacklist6 = iline11;
			int iline12 = Convert.ToInt32(Decryptline12);
			GlobalVars.blacklist7 = iline12;
			int iline13 = Convert.ToInt32(Decryptline13);
			GlobalVars.blacklist8 = iline13;
			
			bool bline14 = Convert.ToBoolean(Decryptline14);
			GlobalVars.upnp = bline14;
			
			GlobalVars.ChatType = Decryptline15;
		}
		
		public static void WriteConfigValues(string cfgpath)
		{
			string[] lines = { 
				SecurityFuncs.Base64Encode(GlobalVars.CloseOnLaunch.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.UserID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.PlayerName.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.SelectedClient.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Hat1ID_Offline.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Hat2ID_Offline.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Hat3ID_Offline.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.HeadColorID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.TorsoColorID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.LeftArmColorID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.RightArmColorID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.LeftLegColorID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.RightLegColorID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.ColorMenu_HeadColor.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.ColorMenu_TorsoColor.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.ColorMenu_LeftArmColor.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.ColorMenu_RightArmColor.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.ColorMenu_LeftLegColor.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.ColorMenu_RightLegColor.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_TShirt.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Shirt.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Pants.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_IconType.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.FaceID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.HeadID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.AdminMode.ToString())
			};
			File.WriteAllText(cfgpath, SecurityFuncs.Base64Encode(string.Join("|",lines)));
		}
		
		public static void WriteServerPrefs(string cfgpath)
		{
			string[] lines = { 
				SecurityFuncs.Base64Encode(GlobalVars.Map.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.ServerPort.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.DefaultRobloxPort.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.PlayerLimit.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.RespawnTime.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.blacklist1.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.blacklist2.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.blacklist3.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.blacklist4.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.blacklist5.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.blacklist6.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.blacklist7.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.blacklist8.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.upnp.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.ChatType.ToString())
			};
			File.WriteAllText(cfgpath, SecurityFuncs.Base64Encode(string.Join("|",lines)));
		}
		
		public static void ResetConfigValues()
		{
			string line1;
			string Decryptline2;
			using(StreamReader reader = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\info.txt"))
			{
    			line1 = reader.ReadLine();
			}
			
			if (!SecurityFuncs.IsBase64String(line1))
				return;
			string ConvertedLine = SecurityFuncs.Base64Decode(line1);
			string[] result = ConvertedLine.Split('|');
    		Decryptline2 = SecurityFuncs.Base64Decode(result[1]);
    		
			GlobalVars.CloseOnLaunch = false;
			GlobalVars.UserID = 0;
			GlobalVars.PlayerName = "Player";
    		GlobalVars.SelectedClient = Decryptline2;
			GlobalVars.ServerPort = 53640;
			GlobalVars.Custom_Hat1ID_Offline = "NoHat.rbxm";
			GlobalVars.Custom_Hat2ID_Offline = "NoHat.rbxm";
			GlobalVars.Custom_Hat3ID_Offline = "NoHat.rbxm";
			GlobalVars.HeadColorID = 24;
			GlobalVars.TorsoColorID = 23;
			GlobalVars.LeftArmColorID = 24;
			GlobalVars.RightArmColorID = 24;
			GlobalVars.LeftLegColorID = 119;
			GlobalVars.RightLegColorID = 119;
			GlobalVars.ColorMenu_HeadColor = "Color [A=255, R=245, G=205, B=47]";
			GlobalVars.ColorMenu_TorsoColor = "Color [A=255, R=13, G=105, B=172]";
			GlobalVars.ColorMenu_LeftArmColor = "Color [A=255, R=245, G=205, B=47]";
			GlobalVars.ColorMenu_RightArmColor = "Color [A=255, R=245, G=205, B=47]";
			GlobalVars.ColorMenu_LeftLegColor = "Color [A=255, R=164, G=189, B=71]";
			GlobalVars.ColorMenu_RightLegColor = "Color [A=255, R=164, G=189, B=71]";
			GlobalVars.Custom_TShirt = 0;
			GlobalVars.Custom_Shirt = 0;
			GlobalVars.Custom_Pants = 0;
			GlobalVars.Custom_IconType = "NBC";
			GlobalVars.AdminMode  = false;
		}
		
		public static void ResetServerPrefs()
		{
			GlobalVars.Map = "Baseplate.rbxl";
			GlobalVars.ServerPort = 53640;
			GlobalVars.DefaultRobloxPort = 53640;
			GlobalVars.PlayerLimit = 12;
			GlobalVars.RespawnTime = 5;
			GlobalVars.upnp = true;
			GlobalVars.blacklist1 = 0;
			GlobalVars.blacklist2 = 0;
			GlobalVars.blacklist3 = 0;
			GlobalVars.blacklist4 = 0;
			GlobalVars.blacklist5 = 0;
			GlobalVars.blacklist6 = 0;
			GlobalVars.blacklist7 = 0;
			GlobalVars.blacklist8 = 0;
			GlobalVars.ChatType = "Both";
		}
		
		public static void ReadClientValues(string clientpath)
		{
			string line1;
			string Decryptline1, Decryptline2, Decryptline3, Decryptline4, Decryptline5, Decryptline6, Decryptline7, Decryptline8;

			using(StreamReader reader = new StreamReader(clientpath)) 
			{
    			line1 = reader.ReadLine();
			}
			
			if (!SecurityFuncs.IsBase64String(line1))
				return;
			
			string ConvertedLine = SecurityFuncs.Base64Decode(line1);
			string[] result = ConvertedLine.Split('|');
			Decryptline1 = SecurityFuncs.Base64Decode(result[0]);
    		Decryptline2 = SecurityFuncs.Base64Decode(result[1]);
    		Decryptline3 = SecurityFuncs.Base64Decode(result[2]);
    		Decryptline4 = SecurityFuncs.Base64Decode(result[3]);
    		Decryptline5 = SecurityFuncs.Base64Decode(result[4]);
    		Decryptline6 = SecurityFuncs.Base64Decode(result[5]);
    		Decryptline7 = SecurityFuncs.Base64Decode(result[6]);
    		Decryptline8 = SecurityFuncs.Base64Decode(result[7]);
			
			bool bline1 = Convert.ToBoolean(Decryptline1);
			GlobalVars.UsesPlayerName = bline1;
			
			bool bline2 = Convert.ToBoolean(Decryptline2);
			GlobalVars.UsesID = bline2;
			
			bool bline3 = Convert.ToBoolean(Decryptline3);
			GlobalVars.LoadsAssetsOnline = bline3;
			
			bool bline4 = Convert.ToBoolean(Decryptline4);
			GlobalVars.LegacyMode = bline4;
			
			bool bline5 = Convert.ToBoolean(Decryptline5);
			GlobalVars.HasRocky = bline5;
			
			GlobalVars.SelectedClientMD5 = Decryptline6;
			
			int iline7 = Convert.ToInt32(Decryptline7);
			GlobalVars.SelectedClientVersion = iline7;
			
			GlobalVars.SelectedClientDesc = Decryptline8;
			
			GlobalVars.MD5 = GlobalVars.SelectedClientMD5;
		}
		
		public static void ReadClientValuesBCC(string ClientName)
		{
			string clientpath = GlobalVars.ClientDir + @"\\" + ClientName + @"\\clientinfo.txt";
			
			if (!File.Exists(clientpath))
			{
				GlobalVars.SelectedClient = "2008";
			}
			
			ReadClientValues(clientpath);
		}
		
		public static void GeneratePlayerID()
		{
			CryptoRandom random = new CryptoRandom();
			int randomID = 0;
			int randIDmode = random.Next(0,7);
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
			GlobalVars.UserID = randomID;
		}
	}
	
	public class SecurityFuncs
	{
		public SecurityFuncs()
		{
		}
		
		public static string Base64Decode(string base64EncodedData) 
		{
  			var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
  			return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
		}
		
		public static string Base64Encode(string plainText) 
		{
  			var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
  			return System.Convert.ToBase64String(plainTextBytes);
		}
		
		public static bool IsBase64String(string s)
		{
    		s = s.Trim();
    		return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
		}
		
		public static bool checkClientMD5(string client)
		{
			string rbxexe = "";
			if (GlobalVars.LegacyMode == true)
			{
				rbxexe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\clients\\" + client + "\\RobloxApp.exe";
			}
			else
			{
				rbxexe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\clients\\" + client + "\\RobloxPlayer.exe";
			}
    		using (var md5 = MD5.Create())
    		{
    			using (var stream = File.OpenRead(rbxexe))
        		{
    				byte[] hash = md5.ComputeHash(stream);
    				string clientMD5 = BitConverter.ToString(hash).Replace("-", "");
            		if (clientMD5.Equals(GlobalVars.MD5))
            		{
            			return true;
            		}
            		else
            		{
            			if (GlobalVars.AdminMode == false)
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
		
		public static bool checkScriptMD5()
		{
			string rbxexe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\scripts\\CSMPFunctions.lua";
    		using (var md5 = MD5.Create())
    		{
    			using (var stream = File.OpenRead(rbxexe))
        		{
    				byte[] hash = md5.ComputeHash(stream);
    				string clientMD5 = BitConverter.ToString(hash).Replace("-", "");
            		if (clientMD5.Equals(GlobalVars.DefaultScriptMD5))
            		{
            			return true;
            		}
            		else
            		{
            			if (GlobalVars.AdminMode == false)
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
		
		public static string GetLocalIPAddress()
    	{
      		string str = "";
      		foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
      		{
        		if (address.AddressFamily == AddressFamily.InterNetwork)
        		{
          			str = address.ToString();
          			break;
        		}
      		}
      		return str;
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
	
	public static class TextLineRemover
	{
	    public static void RemoveTextLines(IList<string> linesToRemove, string filename, string tempFilename)
	    {
	        // Initial values
	        int lineNumber = 0;
	        int linesRemoved = 0;
	        DateTime startTime = DateTime.Now;
	
	        // Read file
	        using (var sr = new StreamReader(filename))
	        {
	            // Write new file
	            using (var sw = new StreamWriter(tempFilename))
	            {
	                // Read lines
	                string line;
	                while ((line = sr.ReadLine()) != null)
	                {
	                    lineNumber++;
	                    // Look for text to remove
	                    if (!ContainsString(line, linesToRemove))
	                    {
	                        // Keep lines that does not match
	                        sw.WriteLine(line);
	                    }
	                    else
	                    {
	                        // Ignore lines that DO match
	                        linesRemoved++;
	                        InvokeOnRemovedLine(new RemovedLineArgs { RemovedLine = line, RemovedLineNumber = lineNumber});
	                    }
	                }
	            }
	        }
	        // Delete original file
	        File.Delete(filename);
	
	        // ... and put the temp file in its place.
	        File.Move(tempFilename, filename);
	
	        // Final calculations
	        DateTime endTime = DateTime.Now;
	        InvokeOnFinished(new FinishedArgs {LinesRemoved = linesRemoved, TotalLines = lineNumber, TotalTime = endTime.Subtract(startTime)});
	    }
	
	    private static bool ContainsString(string line, IEnumerable<string> linesToRemove)
	    {
	        foreach (var lineToRemove in linesToRemove)
	        {
	            if(line.Contains(lineToRemove))
	                return true;
	        }
	        return false;
	    }
	
	    public static event RemovedLine OnRemovedLine;
	    public static event Finished OnFinished;
	
	    public static void InvokeOnFinished(FinishedArgs args)
	    {
	        Finished handler = OnFinished;
	        if (handler != null) handler(null, args);
	    }
	
	    public static void InvokeOnRemovedLine(RemovedLineArgs args)
	    {
	        RemovedLine handler = OnRemovedLine;
	        if (handler != null) handler(null, args);
	    }
	}
	
	public delegate void Finished(object sender, FinishedArgs args);
	
	public class FinishedArgs
	{
	    public int TotalLines { get; set; }
	    public int LinesRemoved { get; set; }
	    public TimeSpan TotalTime { get; set; }
	}
	
	public delegate void RemovedLine(object sender, RemovedLineArgs args);
	
	public class RemovedLineArgs
	{
	    public string RemovedLine { get; set; }
	    public int RemovedLineNumber { get; set; }
	}
	
	// you need this once (only), and it must be in this namespace
	/*
	namespace System.Runtime.CompilerServices
	{
	    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class
	         | AttributeTargets.Method)]
	    public sealed class ExtensionAttribute : Attribute {}
	}
	*/
	
	public static class RichTextBoxExtensions
	{
	    public static void AppendText(this RichTextBox box, string text, Color color)
	    {
	        box.SelectionStart = box.TextLength;
	        box.SelectionLength = 0;
	
	        box.SelectionColor = color;
	        box.AppendText(text);
	        box.SelectionColor = box.ForeColor;
	    }
	}
}
