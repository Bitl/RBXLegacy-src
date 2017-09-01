using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace RBXLegacyLauncher
{
	public class LauncherFuncs
	{
		public LauncherFuncs()
		{
		}
		
		public static void ReadConfigValues(string cfgpath)
		{
			string line1;
			string Decryptline1, Decryptline2, Decryptline3, Decryptline4, Decryptline5, Decryptline6, Decryptline7, Decryptline8, Decryptline9, Decryptline10, Decryptline11, Decryptline12, Decryptline13, Decryptline14, Decryptline15, Decryptline16, Decryptline17, Decryptline18, Decryptline19, Decryptline20, Decryptline21, Decryptline22, Decryptline23, Decryptline24, Decryptline25, Decryptline26, Decryptline27, Decryptline28, Decryptline29, Decryptline30, Decryptline31, Decryptline32, Decryptline33, Decryptline34;

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
    		Decryptline27 = SecurityFuncs.Base64Decode(result[26]);
    		Decryptline28 = SecurityFuncs.Base64Decode(result[27]);
    		Decryptline29 = SecurityFuncs.Base64Decode(result[28]);
    		Decryptline30 = SecurityFuncs.Base64Decode(result[29]);
    		Decryptline31 = SecurityFuncs.Base64Decode(result[30]);
    		Decryptline32 = SecurityFuncs.Base64Decode(result[31]);
    		Decryptline33 = SecurityFuncs.Base64Decode(result[32]);
    		Decryptline34 = SecurityFuncs.Base64Decode(result[33]);
			
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
			GlobalVars.TorsoID = Decryptline26;
			GlobalVars.LeftArmID = Decryptline27;
			GlobalVars.RightArmID = Decryptline28;
			GlobalVars.LeftLegID = Decryptline29;
			GlobalVars.RightLegID = Decryptline30;
			
			GlobalVars.Custom_Gear1 = Decryptline31;
			GlobalVars.Custom_Gear2 = Decryptline32;
			GlobalVars.Custom_Gear3 = Decryptline33;
			
			bool bline34 = Convert.ToBoolean(Decryptline34);
			GlobalVars.AdminMode = bline34;
		}
		
		public static void ReadServerPrefs(string cfgpath)
		{
			string line1;
			string Decryptline1, Decryptline2, Decryptline3, Decryptline4, Decryptline5, Decryptline6, Decryptline7, Decryptline8, Decryptline9, Decryptline10, Decryptline11, Decryptline12, Decryptline13, Decryptline14, Decryptline15, Decryptline16, Decryptline17, Decryptline18, Decryptline19, Decryptline20, Decryptline21, Decryptline22, Decryptline23, Decryptline24, Decryptline25, Decryptline26, Decryptline27, Decryptline28, Decryptline29, Decryptline30, Decryptline31, Decryptline32;

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
    		Decryptline27 = SecurityFuncs.Base64Decode(result[26]);
    		Decryptline28 = SecurityFuncs.Base64Decode(result[27]);
    		Decryptline29 = SecurityFuncs.Base64Decode(result[28]);
    		Decryptline30 = SecurityFuncs.Base64Decode(result[29]);
    		Decryptline31 = SecurityFuncs.Base64Decode(result[30]);
    		Decryptline32 = SecurityFuncs.Base64Decode(result[31]);
			
			GlobalVars.Map = Decryptline1;
			
			int iline2 = Convert.ToInt32(Decryptline2);
			GlobalVars.ServerPort = iline2;
			
			int iline3 = Convert.ToInt32(Decryptline3);
			GlobalVars.DefaultRobloxPort = iline3;
			
			int iline4 = Convert.ToInt32(Decryptline4);
			GlobalVars.PlayerLimit = iline4;
			
			int iline5 = Convert.ToInt32(Decryptline5);
			GlobalVars.RespawnTime = iline5;
			
			bool bline6 = Convert.ToBoolean(Decryptline6);
			GlobalVars.IsPersonalServer = bline6;
			
			bool bline7 = Convert.ToBoolean(Decryptline7);
			GlobalVars.melee = bline7;
			bool bline8 = Convert.ToBoolean(Decryptline8);
			GlobalVars.navigation = bline8;
			bool bline9 = Convert.ToBoolean(Decryptline9);
			GlobalVars.social = bline9;
			bool bline10 = Convert.ToBoolean(Decryptline10);
			GlobalVars.powerup = bline10;
			bool bline11 = Convert.ToBoolean(Decryptline11);
			GlobalVars.explosives = bline11;
			bool bline12 = Convert.ToBoolean(Decryptline12);
			GlobalVars.transport = bline12;
			bool bline13 = Convert.ToBoolean(Decryptline13);
			GlobalVars.ranged = bline13;
			bool bline14 = Convert.ToBoolean(Decryptline14);
			GlobalVars.musical = bline14;
			bool bline15 = Convert.ToBoolean(Decryptline15);
			GlobalVars.building = bline15;
			bool bline16 = Convert.ToBoolean(Decryptline16);
			GlobalVars.navigation = bline16;
			bool bline17 = Convert.ToBoolean(Decryptline17);
			GlobalVars.social = bline17;
			bool bline18 = Convert.ToBoolean(Decryptline18);
			GlobalVars.explosives = bline18;
			bool bline19 = Convert.ToBoolean(Decryptline19);
			GlobalVars.transport = bline19;
			bool bline20 = Convert.ToBoolean(Decryptline20);
			GlobalVars.ranged = bline20;
			bool bline21 = Convert.ToBoolean(Decryptline21);
			GlobalVars.musical = bline21;
			bool bline22 = Convert.ToBoolean(Decryptline22);
			GlobalVars.building = bline22;
			
			int iline23 = Convert.ToInt32(Decryptline23);
			GlobalVars.blacklist1 = iline23;
			int iline24 = Convert.ToInt32(Decryptline24);
			GlobalVars.blacklist2 = iline24;
			int iline25 = Convert.ToInt32(Decryptline25);
			GlobalVars.blacklist3 = iline25;
			int iline26 = Convert.ToInt32(Decryptline26);
			GlobalVars.blacklist4 = iline26;
			int iline27 = Convert.ToInt32(Decryptline27);
			GlobalVars.blacklist5 = iline27;
			int iline28 = Convert.ToInt32(Decryptline28);
			GlobalVars.blacklist6 = iline28;
			int iline29 = Convert.ToInt32(Decryptline29);
			GlobalVars.blacklist7 = iline29;
			int iline30 = Convert.ToInt32(Decryptline30);
			GlobalVars.blacklist8 = iline30;
			
			bool bline31 = Convert.ToBoolean(Decryptline31);
			GlobalVars.upnp = bline31;
			
			GlobalVars.ChatType = Decryptline32;
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
				SecurityFuncs.Base64Encode(GlobalVars.TorsoID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.LeftArmID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.RightArmID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.LeftLegID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.RightLegID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Gear1.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Gear2.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Gear3.ToString()),
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
				SecurityFuncs.Base64Encode(GlobalVars.IsPersonalServer.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.melee.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.navigation.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.social.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.powerup.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.explosives.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.transport.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.ranged.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.musical.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.building.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.navigation.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.social.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.explosives.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.transport.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.ranged.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.musical.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.building.ToString()),
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
			GlobalVars.IsPersonalServer = false;
			GlobalVars.upnp = true;
			GlobalVars.melee = false;
			GlobalVars.navigation = false;
			GlobalVars.social = false;
			GlobalVars.powerup = false;
			GlobalVars.explosives = false;
			GlobalVars.transport = false;
			GlobalVars.ranged = false;
			GlobalVars.musical = false;
			GlobalVars.building = false;
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
}
