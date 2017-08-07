using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RBXLegacyLauncher
{
	public partial class LoaderForm : Form
	{
		public LoaderForm()
		{
			InitializeComponent();
		}
		
		void LoaderFormLoad(object sender, EventArgs e)
		{
			string line1;
			string Decryptline3, Decryptline4;
			using(StreamReader reader = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\info.txt"))
			{
    			line1 = reader.ReadLine();
			}
			
			if (!SecurityFuncs.IsBase64String(line1))
				return;
			string ConvertedLine = SecurityFuncs.Base64Decode(line1);
			string[] result = ConvertedLine.Split('|');
    		Decryptline3 = SecurityFuncs.Base64Decode(result[2]);
    		Decryptline4 = SecurityFuncs.Base64Decode(result[3]);
    		GlobalVars.DefaultScript = Decryptline3;
    		GlobalVars.DefaultScriptMD5 = Decryptline4;
			QuickConfigure main = new QuickConfigure();
			main.ShowDialog();
			System.Threading.Timer timer = new System.Threading.Timer(new TimerCallback(CheckIfFinished), null, 1, 0);			
		}
		
		void StartGame()
		{
			if (SecurityFuncs.checkScriptMD5() == true)
			{
			string ExtractedArg = GlobalVars.SharedArgs.Replace("rbxlegacy://", "").Replace("rbxlegacy", "").Replace(":", "").Replace("/", "").Replace("?", "");
			string ConvertedArg = SecurityFuncs.Base64Decode(ExtractedArg);
			string[] SplitArg = ConvertedArg.Split('|');
			string ip = SecurityFuncs.Base64Decode(SplitArg[0]);
			string port = SecurityFuncs.Base64Decode(SplitArg[1]);
			string client = SecurityFuncs.Base64Decode(SplitArg[2]);
			ReadClientValues(client);
			string rbxexe = "";
			if (GlobalVars.LegacyMode == true)
			{
				rbxexe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +  "\\clients\\" + client + @"\\RobloxApp.exe";
			}
			else
			{
				rbxexe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +  "\\clients\\" + client + @"\\RobloxPlayer.exe";
			}
			string quote = "\"";
			string args = "";
			string HatIDOffline1 = GlobalVars.Custom_Hat1ID_Offline;
			string HatIDOffline2 = GlobalVars.Custom_Hat2ID_Offline;
			string HatIDOffline3 = GlobalVars.Custom_Hat3ID_Offline;
			if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true)
			{
				args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "'); _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + "); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.TorsoID + "','" + GlobalVars.RightArmID + "','" + GlobalVars.LeftArmID + "','" + GlobalVars.RightLegID + "','" + GlobalVars.LeftLegID + "','" + GlobalVars.Custom_IconType + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true)
			{
				args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "'); _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + "); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" +GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.TorsoID + "','" + GlobalVars.RightArmID + "','" + GlobalVars.LeftArmID + "','" + GlobalVars.RightLegID + "','" + GlobalVars.LeftLegID + "','" + GlobalVars.Custom_IconType + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false)
			{
				args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "'); _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + "); _G.CSConnect(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.TorsoID + "','" + GlobalVars.RightArmID + "','" + GlobalVars.LeftArmID + "','" + GlobalVars.RightLegID + "','" + GlobalVars.LeftLegID + "','" + GlobalVars.Custom_IconType + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false)
			{
				args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "'); _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + "); _G.CSConnect(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.TorsoID + "','" + GlobalVars.RightArmID + "','" + GlobalVars.LeftArmID + "','" + GlobalVars.RightLegID + "','" + GlobalVars.LeftLegID + "','" + GlobalVars.Custom_IconType + "');" + quote;
			}
			try
			{
				if (SecurityFuncs.checkClientMD5(client) == true)
				{
					Process pclient = new Process();
					pclient.StartInfo.FileName = rbxexe;
					pclient.StartInfo.Arguments = args;
					pclient.EnableRaisingEvents = true;
					pclient.Exited += new EventHandler(ClientExited);
					pclient.Start();
					this.ShowInTaskbar = false;
					this.WindowState = FormWindowState.Minimized;
				}
				else
				{
					label1.Text = "The client has been detected as modified.";
				}
			}
			catch (Exception)
			{
				label1.Text = "The client has been detected as modified.";
			}
			}
			else
			{
				label1.Text = "The script has been detected as modified.";
			}
		}
		
		void ClientExited(object sender, EventArgs e)
		{
			Process[] sudp = Process.GetProcessesByName("sudppipe");
			if (sudp != null)
			{
				foreach (var process in sudp)
				{
    				process.Kill();
				}
			}
			
			Process[] self = Process.GetProcessesByName("RBXLegacyLauncher");
			if (self != null)
			{
				foreach (var process in self)
				{
    				process.Kill();
				}
			}
		}
		
		private void CheckIfFinished(object state)
    	{
			if (GlobalVars.ReadyToLaunch == false)
			{
				System.Threading.Timer timer = new System.Threading.Timer(new TimerCallback(CheckIfFinished), null, 1, 0);
			}
			else
			{
				string ExtractedArg = GlobalVars.SharedArgs.Replace("rbxlegacy://", "").Replace("rbxlegacy", "").Replace(":", "").Replace("/", "").Replace("?", "");
				string ConvertedArg = SecurityFuncs.Base64Decode(ExtractedArg);
				string[] SplitArg = ConvertedArg.Split('|');
				string ip = SecurityFuncs.Base64Decode(SplitArg[0]);
				string port = SecurityFuncs.Base64Decode(SplitArg[1]);
				string client = SecurityFuncs.Base64Decode(SplitArg[2]);
				label1.Text = "Launching " + client + " Game...";
				Process sudp = new Process();
				sudp.StartInfo.FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +  "\\sudppipe.exe";
				sudp.StartInfo.Arguments = "-p " + ip + " " + port  + " " + port;
				sudp.StartInfo.UseShellExecute = false;
				sudp.StartInfo.CreateNoWindow = true;
				sudp.Start();
				StartGame();
			}
    	}
		
		void ReadConfigValues()
		{
			LauncherFuncs.ReadConfigValues(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.txt");
		}
		
		void ReadClientValues(string ClientName)
		{
			string clientpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +  "\\clients\\" + ClientName + "\\clientinfo.txt";
			
			if (!File.Exists(clientpath))
			{
				MessageBox.Show("No clientinfo.txt detected with the client you chose. The client either cannot be loaded, or it is not available.","RBXLegacy Launcher - Error while loading client", MessageBoxButtons.OK, MessageBoxIcon.Error);
				GlobalVars.SelectedClient = "2008";
			}
			
			LauncherFuncs.ReadClientValues(clientpath);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
