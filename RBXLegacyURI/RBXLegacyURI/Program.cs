using Microsoft.Win32;
using System;

namespace RBXLegacyURI
{
	internal class Program
	{
		private static void registerURI(string protocolName, string applicationPath, string description)
		{
			RegistryKey registryKey = Registry.ClassesRoot.CreateSubKey(protocolName);
			registryKey.SetValue(null, description);
			registryKey.SetValue("URL Protocol", string.Empty);
			Registry.ClassesRoot.CreateSubKey(protocolName + "\\Shell");
			Registry.ClassesRoot.CreateSubKey(protocolName + "\\Shell\\open");
			registryKey = Registry.ClassesRoot.CreateSubKey(protocolName + "\\Shell\\open\\command");
			registryKey.SetValue(null, "\"" + applicationPath + "\" \"%1\"");
		}

		private static void Main(string[] args)
		{
			Console.Title = "RBXLegacy";
			try {
				Program.registerURI("RBXLegacy", AppDomain.CurrentDomain.BaseDirectory + "RBXLegacyLauncher.exe", "");
				Program.registerURI("rbxlegacy", AppDomain.CurrentDomain.BaseDirectory + "RBXLegacyLauncher.exe", ""); // chromium
				Console.WriteLine("RBXLegacy has been installed on your computer successfully! You can now join RBXLegacy servers with URI.");
				Console.WriteLine("Press any key to continue . . .");
				Console.ReadKey();
			} catch (Exception) {	
				Console.Title = "RBXLegacy - ERROR";
				Console.WriteLine("RBXLegacy failed to install the RBXLegacy URL protocol.");
				Console.WriteLine("Make sure you're running this application as an administrator, and that RBXLegacyLauncher.exe is in the RBXLegacy folder.");
				Console.WriteLine("Press any key to continue . . .");
				Console.ReadKey();
				Console.WriteLine("z0mgh4x0r l0gs"); // how can they see this still??? 1337 h4x0r
			}
		}
	}
}
