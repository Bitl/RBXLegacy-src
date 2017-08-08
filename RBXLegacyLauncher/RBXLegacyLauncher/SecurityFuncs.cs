using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace RBXLegacyLauncher
{
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
		
		public static void RegisterURLProtocol(string protocolName, string applicationPath, string description)
    	{
      		RegistryKey subKey = Registry.ClassesRoot.CreateSubKey(protocolName);
      		subKey.SetValue((string) null, (object) description);
      		subKey.SetValue("URL Protocol", (object) string.Empty);
      		Registry.ClassesRoot.CreateSubKey(protocolName + "\\Shell");
      		Registry.ClassesRoot.CreateSubKey(protocolName + "\\Shell\\open");
      		Registry.ClassesRoot.CreateSubKey(protocolName + "\\Shell\\open\\command").SetValue((string) null, (object) ("\"" + applicationPath + "\" \"%1\""));
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
            			return false;
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
            			return false;
            		}
        		}
    		}
		}
	}
}
