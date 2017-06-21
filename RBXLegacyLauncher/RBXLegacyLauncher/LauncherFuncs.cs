/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 6/13/2017
 * Time: 10:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
	/// <summary>
	/// Description of LauncherFuncs.
	/// </summary>
	public class LauncherFuncs
	{
		public LauncherFuncs()
		{
		}
		
		public static void ReadConfigValues(string cfgpath)
		{
			string line1;
			string Decryptline1, Decryptline2, Decryptline3, Decryptline4, Decryptline5, Decryptline6, Decryptline7, Decryptline8, Decryptline9, Decryptline10, Decryptline11, Decryptline12, Decryptline13, Decryptline14, Decryptline15, Decryptline16, Decryptline17, Decryptline18, Decryptline19, Decryptline20, Decryptline21, Decryptline22, Decryptline23, Decryptline24, Decryptline25, Decryptline26;

			using(StreamReader reader = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.txt")) 
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
			
			GlobalVars.Map = Decryptline5;
			
			int iline6 = Convert.ToInt32(Decryptline6);
			GlobalVars.RobloxPort = iline6;
			
			GlobalVars.Custom_Hat1ID_Offline = Decryptline7;
			GlobalVars.Custom_Hat2ID_Offline = Decryptline8;
			GlobalVars.Custom_Hat3ID_Offline = Decryptline9;
			
			int iline10 = Convert.ToInt32(Decryptline10);
			GlobalVars.HeadColorID = iline10;
			
			int iline11 = Convert.ToInt32(Decryptline11);
			GlobalVars.TorsoColorID = iline11;
			
			int iline12 = Convert.ToInt32(Decryptline12);
			GlobalVars.LeftArmColorID = iline12;
			
			int iline13 = Convert.ToInt32(Decryptline13);
			GlobalVars.RightArmColorID = iline13;
			
			int iline14 = Convert.ToInt32(Decryptline14);
			GlobalVars.LeftLegColorID = iline14;
			
			int iline15 = Convert.ToInt32(Decryptline15);
			GlobalVars.RightLegColorID = iline15;
			
			GlobalVars.ColorMenu_HeadColor = Decryptline16;
			GlobalVars.ColorMenu_TorsoColor = Decryptline17;
			GlobalVars.ColorMenu_LeftArmColor = Decryptline18;
			GlobalVars.ColorMenu_RightArmColor = Decryptline19;
			GlobalVars.ColorMenu_LeftLegColor = Decryptline20;
			GlobalVars.ColorMenu_RightLegColor = Decryptline21;
			
			int iline22 = Convert.ToInt32(Decryptline22);
			GlobalVars.PlayerLimit = iline22;
			
			int iline23 = Convert.ToInt32(Decryptline23);
			GlobalVars.Custom_TShirt = iline23;
			int iline24 = Convert.ToInt32(Decryptline24);
			GlobalVars.Custom_Shirt = iline24;
			int iline25 = Convert.ToInt32(Decryptline25);
			GlobalVars.Custom_Pants = iline25;
			int iline26 = Convert.ToInt32(Decryptline26);
			GlobalVars.Custom_Face = iline26;
		}
		
		public static void WriteConfigValues(string cfgpath)
		{
			string[] lines = { 
				SecurityFuncs.Base64Encode(GlobalVars.CloseOnLaunch.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.UserID.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.PlayerName.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.SelectedClient.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Map.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.RobloxPort.ToString()),
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
				SecurityFuncs.Base64Encode(GlobalVars.PlayerLimit.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_TShirt.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Shirt.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Pants.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.Custom_Face.ToString())
			};
			File.WriteAllText(cfgpath, SecurityFuncs.Base64Encode(string.Join("|",lines)));
		}
		
		public static void ResetConfigValues()
		{
			GlobalVars.CloseOnLaunch = false;
			GlobalVars.UserID = 0;
			GlobalVars.PlayerName = "Player";
			GlobalVars.SelectedClient = "Mid-2008";
			GlobalVars.Map = "Baseplate.rbxl";
			GlobalVars.RobloxPort = 53640;
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
			GlobalVars.PlayerLimit = 12;
			GlobalVars.Custom_TShirt = 0;
			GlobalVars.Custom_Shirt = 0;
			GlobalVars.Custom_Pants = 0;
			GlobalVars.Custom_Face = 0;
		}
		
		public static void ReadClientValues(string clientpath)
		{
			string line1;
			string Decryptline1, Decryptline2, Decryptline3, Decryptline4, Decryptline5, Decryptline6, Decryptline7;

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
			
			bool bline1 = Convert.ToBoolean(Decryptline1);
			GlobalVars.UsesPlayerName = bline1;
			
			bool bline2 = Convert.ToBoolean(Decryptline2);
			GlobalVars.UsesID = bline2;
			
			bool bline3 = Convert.ToBoolean(Decryptline3);
			GlobalVars.LoadsAssetsOnline = bline3;
			
			bool bline4 = Convert.ToBoolean(Decryptline4);
			GlobalVars.LegacyMode = bline4;
			
			GlobalVars.SelectedClientMD5 = Decryptline5;
			
			GlobalVars.SelectedClientVersion = Decryptline6;
					
			GlobalVars.SelectedClientDesc = Decryptline7;
			
			GlobalVars.MD5 = GlobalVars.SelectedClientMD5;
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
		
		public static bool IsProcessOpen(string name)
    	{
        	foreach (Process clsProcess in Process.GetProcesses()) 
        	{
           	 	if (clsProcess.ProcessName.Contains(name))
            	{
                	return true;
            	}
        	}

        	return false;
    	}
	}
}
