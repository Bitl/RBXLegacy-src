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
using System.Text.RegularExpressions;
using Open.Nat;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RBXLegacyLauncher
{
	public partial class MainForm : Form
	{
		DiscordRpc.EventHandlers handlers;
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		public async void StartUPNP()
		{
			try
			{
    			var nat = new NatDiscoverer();

    			var cts = new CancellationTokenSource(5000);
    			var device = await nat.DiscoverDeviceAsync(PortMapper.Upnp, cts);
    			await device.CreatePortMapAsync(new Mapping(Protocol.Udp, GlobalVars.ServerPort, GlobalVars.ServerPort, "RBXLegacy"));
    			
    			var ip = await device.GetExternalIPAsync();
    			
    			ConsolePrint("Port " + GlobalVars.ServerPort.ToString() + " registered to device " + ip, 3);
			}
			catch(NatDeviceNotFoundException e)
			{
				ConsolePrint("Error: " + e.ToString(), 2);
			}
			catch(MappingException me)
			{
    			switch(me.ErrorCode)
    			{
        		case 718:
            		ConsolePrint("The external port is already in use.", 2);
            		break;
        		case 728: 
            		ConsolePrint("The router's mapping table is full.", 2);
            		break;
    			}
			}
		}
		
		public async void StopUPNP()
		{
			try
			{
    			var nat = new NatDiscoverer();
				var cts = new CancellationTokenSource(5000);
				var device = await nat.DiscoverDeviceAsync(PortMapper.Upnp, cts);

				foreach (var mapping in await device.GetAllMappingsAsync())
				{
     				if(mapping.Description.Contains("RBXLegacy"))
     				{
        				await device.DeletePortMapAsync(mapping);
     				}
				}
				
				var ip = await device.GetExternalIPAsync();
        		ConsolePrint("Port " + GlobalVars.ServerPort.ToString() + " removed from device " + ip, 2);
			}
			catch(NatDeviceNotFoundException e)
			{
    			ConsolePrint("Error: " + e.ToString(), 2);
			}
		}
		
		public void ReadyCallback()
        {
            ConsolePrint("Discord RPC: Ready", 3);
        }

        public void DisconnectedCallback(int errorCode, string message)
        {
            ConsolePrint("Discord RPC: Disconnected. Reason - " + errorCode + ": " + message, 2);
        }

        public void ErrorCallback(int errorCode, string message)
        {
            ConsolePrint("Discord RPC: Error. Reason - " + errorCode + ": " + message, 2);
        }

        public void JoinCallback(string secret)
        {
        }

        public void SpectateCallback(string secret)
        {
        }

        public void RequestCallback(DiscordRpc.JoinRequest request)
        {
        }
        
        void StartDiscord()
        {
        	handlers = new DiscordRpc.EventHandlers();
            handlers.readyCallback = ReadyCallback;
            handlers.disconnectedCallback += DisconnectedCallback;
            handlers.errorCallback += ErrorCallback;
            handlers.joinCallback += JoinCallback;
            handlers.spectateCallback += SpectateCallback;
            handlers.requestCallback += RequestCallback;
            DiscordRpc.Initialize(GlobalVars.appid, ref handlers, true, "");
			
            GlobalVars.presence.largeImageKey = GlobalVars.imagekey_large;
            GlobalVars.presence.state = "In Launcher";
            GlobalVars.presence.largeImageText = GlobalVars.PlayerName;
            DiscordRpc.UpdatePresence(ref GlobalVars.presence);
        }
		
		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
     		if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
     		{
        		string mapdir = GlobalVars.MapsDir;
				DirectoryInfo dinfo = new DirectoryInfo(mapdir);
				FileInfo[] Files = dinfo.GetFiles("*.rbxl");
				foreach( FileInfo file in Files )
				{
   					listBox1.Items.Add(file.Name);
				}
				listBox1.SelectedItem = GlobalVars.Map;
				listBox2.Items.Clear();
				listBox3.Items.Clear();
     			listBox4.Items.Clear();
     		}
     		else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
     		{
        		string clientdir = GlobalVars.ClientDir;
				DirectoryInfo dinfo = new DirectoryInfo(clientdir);
				DirectoryInfo[] Dirs = dinfo.GetDirectories();
				foreach( DirectoryInfo dir in Dirs )
				{
   					listBox2.Items.Add(dir.Name);
				}
				listBox2.SelectedItem = GlobalVars.SelectedClient;
				listBox1.Items.Clear();
				listBox3.Items.Clear();
     			listBox4.Items.Clear();
     		}
     		else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage6"])
     		{
     			string[] lines_server = File.ReadAllLines("servers.txt");
				string[] lines_ports = File.ReadAllLines("ports.txt");
				listBox3.Items.AddRange(lines_server);
				listBox4.Items.AddRange(lines_ports);
     			listBox1.Items.Clear();
     			listBox2.Items.Clear();
     		}
     		else
     		{
     			listBox1.Items.Clear();
     			listBox2.Items.Clear();
     			listBox3.Items.Clear();
     			listBox4.Items.Clear();
     		}
		}
		void Button1Click(object sender, EventArgs e)
		{
			if (GlobalVars.LocalPlayMode == true)
			{
				GeneratePlayerID();
			}
			
			WriteConfigValues();
			ReadClientValues(GlobalVars.SelectedClient);
			if (GlobalVars.HasRocky == true)
			{
				Process sudp = new Process();
				sudp.StartInfo.FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +  "\\udppipe.exe";
				sudp.StartInfo.Arguments = "-p " + GlobalVars.IP + " " + GlobalVars.RobloxPort  + " " + GlobalVars.RobloxPort;
				sudp.StartInfo.UseShellExecute = false;
				sudp.StartInfo.CreateNoWindow = true;
				sudp.Start();
			}
			StartClient();
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.WindowState = FormWindowState.Minimized;
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("If you want to test out your place, you will have to save your place in RBXLegacy's map folder, then launch your place in Play Solo.","RBXLegacy Launcher - Launch ROBLOX Studio", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.Cancel)
				return;
			
			WriteConfigValues();
			StartStudio();
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.WindowState = FormWindowState.Minimized;
			}
		}	
		
		void Button2Click(object sender, EventArgs e)
		{
			if (GlobalVars.upnp == true)
			{
				StartUPNP();
			}
			WriteConfigValues();
			StartServer();
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.WindowState = FormWindowState.Minimized;
			}
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			string line1;
			string Decryptline1, Decryptline2, Decryptline3, Decryptline4;
			using(StreamReader reader = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\info.txt"))
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
			string version = Decryptline1;
    		GlobalVars.SelectedClient = Decryptline2;
    		GlobalVars.DefaultScript = Decryptline3;
    		GlobalVars.DefaultScriptMD5 = Decryptline4;
    		ConsolePrint("RBXLegacy Launcher version " + version + " loaded. Initializing config.", 4);
    		if (File.Exists("changelog.txt"))
			{
    			richTextBox2.Text = File.ReadAllText("changelog.txt");
    		}
    		else
    		{
    			ConsolePrint("ERROR 4 - changelog.txt not found.", 2);
    		}
			if (!File.Exists("rbxlegacy_config.txt"))
			{
				ConsolePrint("WARNING 1 - rbxlegacy_config.txt not found. Creating one with default values.", 5);
				WriteConfigValues();
			}
			if (!File.Exists("serverhost_config.txt"))
			{
				ConsolePrint("WARNING 1 - serverhost_config.txt not found. Creating one with default values.", 5);
				LauncherFuncs.WriteServerPrefs("serverhost_config.txt");
			}
			if (!File.Exists("servers.txt"))
			{
				ConsolePrint("WARNING 2 - servers.txt not found. Creating empty file.", 5);
				File.Create("servers.txt").Dispose();
			}
			if (!File.Exists("ports.txt"))
			{
				ConsolePrint("WARNING 3 - ports.txt not found. Creating empty file.", 5);
				File.Create("ports.txt").Dispose();
			}
			GlobalVars.ClientDir = Path.Combine(Environment.CurrentDirectory, @"clients");
			GlobalVars.ClientDir = GlobalVars.ClientDir.Replace(@"\",@"\\");
			GlobalVars.ScriptsDir = Path.Combine(Environment.CurrentDirectory, @"scripts");
			GlobalVars.ScriptsDir = GlobalVars.ScriptsDir.Replace(@"\",@"\\");
			GlobalVars.MapsDir = Path.Combine(Environment.CurrentDirectory, @"maps");
			GlobalVars.MapsDir = GlobalVars.MapsDir.Replace(@"\",@"\\");
			GlobalVars.CustomPlayerDir = Path.Combine(Environment.CurrentDirectory, @"avatar");
			GlobalVars.CustomPlayerDir = GlobalVars.CustomPlayerDir.Replace(@"\",@"\\");
			label5.Text = Environment.CurrentDirectory;
			label8.Text = Application.ProductVersion;
			GlobalVars.IP = "localhost";
    		GlobalVars.Map = "Baseplate.rbxl";
    		label11.Text = version;
    		GlobalVars.Version = version;
    		ReadConfigValues();
    		StartDiscord();
		}
		
		void MainFormClose(object sender, CancelEventArgs e)
        {
            if (GlobalVars.upnp == true)
			{
    			StopUPNP();
    		}
			WriteConfigValues();
            DiscordRpc.Shutdown();
        }
		
		void ReadConfigValues()
		{
			LauncherFuncs.ReadConfigValues("rbxlegacy_config.txt");
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				checkBox1.Checked = true;
			}
			else if (GlobalVars.CloseOnLaunch == false)
			{
				checkBox1.Checked = false;
			}
			
			if (GlobalVars.UserID == 0)
			{
				GeneratePlayerID();
				WriteConfigValues();
			}
			else
			{
				textBox5.Text = GlobalVars.UserID.ToString();
			}
			
			if (GlobalVars.PlayerLimit == 0)
			{
				//We need at least a limit of 12 players.
				GlobalVars.PlayerLimit = 12;
			}
			
			textBox2.Text = GlobalVars.PlayerName;
			label26.Text = GlobalVars.SelectedClient;
			label28.Text = GlobalVars.Map;
			listBox1.SelectedItem = GlobalVars.Map;
			numericUpDown1.Text = GlobalVars.RobloxPort.ToString();
			label37.Text = GlobalVars.IP;
			label38.Text = GlobalVars.RobloxPort.ToString();
			ConsolePrint("Configuration has been loaded.", 3);
			ReadServerPrefs();
			ReadClientValues(GlobalVars.SelectedClient);
		}
		
		void WriteConfigValues()
		{
			LauncherFuncs.WriteConfigValues("rbxlegacy_config.txt");
			ConsolePrint("Configuration has been saved successfully.", 3);
		}
		
		void ReadServerPrefs()
		{
			LauncherFuncs.ReadServerPrefs("serverhost_config.txt");
			ConsolePrint("Server configuration has been loaded.", 3);
		}
		
		void ReadClientValues(string ClientName)
		{
			string clientpath = GlobalVars.ClientDir + @"//" + ClientName + @"//clientinfo.txt";
			
			if (!File.Exists(clientpath))
			{
				ConsolePrint("ERROR 1 - No clientinfo.txt detected with the client you chose. The client either cannot be loaded, or it is not available.", 2);
				MessageBox.Show("No clientinfo.txt detected with the client you chose. The client either cannot be loaded, or it is not available.","RBXLegacy Launcher - Error while loading client", MessageBoxButtons.OK, MessageBoxIcon.Error);
				GlobalVars.SelectedClient = "2008";
			}
			
			LauncherFuncs.ReadClientValues(clientpath);
			
			if (GlobalVars.UsesPlayerName == true)
			{
				textBox2.Enabled = true;
			}
			else if (GlobalVars.UsesPlayerName == false)
			{
				textBox2.Enabled = false;
			}
			
			if (GlobalVars.UsesID == true)
			{
				textBox5.Enabled = true;
				button4.Enabled = true;
				if (GlobalVars.IP.Equals("localhost"))
				{
					checkBox3.Enabled = true;
				}
			}
			else if (GlobalVars.UsesID == false)
			{
				textBox5.Enabled = false;
				button4.Enabled = false;
				checkBox3.Enabled = false;
				GlobalVars.LocalPlayMode = false;
			}
					
			// use clientinfo desc rather than labels
			
			textBox6.Text = GlobalVars.SelectedClientDesc;
			label26.Text = GlobalVars.SelectedClient;
			ConsolePrint("Client '" + GlobalVars.SelectedClient + "' successfully loaded.", 3);
		}
		
		void GeneratePlayerID()
		{
			LauncherFuncs.GeneratePlayerID();
			textBox5.Text = Convert.ToString(GlobalVars.UserID);
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			GlobalVars.IP = textBox1.Text;
			checkBox3.Enabled = false;
			GlobalVars.LocalPlayMode = false;
			label37.Text = GlobalVars.IP;
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalVars.Map = listBox1.SelectedItem.ToString();
			label28.Text = GlobalVars.Map;
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				GlobalVars.CloseOnLaunch = true;
			}
			else if (checkBox1.Checked == false)
			{
				GlobalVars.CloseOnLaunch = false;
			}
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			GeneratePlayerID();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			WriteConfigValues();
			DialogResult result = MessageBox.Show("Your configuration has been saved successfully!","RBXLegacy Launcher - Configuration", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			GlobalVars.PlayerName = textBox2.Text;
		}
		
		void ListBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalVars.SelectedClient = listBox2.SelectedItem.ToString();
			ReadClientValues(GlobalVars.SelectedClient);
		}
		
		void CheckBox3CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked == true)
			{
				GlobalVars.LocalPlayMode = true;
			}
			else if (checkBox3.Checked == false)
			{
				GlobalVars.LocalPlayMode = false;
			}
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			WriteConfigValues();
			DialogResult result = MessageBox.Show("Your configuration has been saved successfully!","RBXLegacy Launcher - Configuration", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
		}
		
		void NumericUpDown1ValueChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(numericUpDown1.Text, out parsedValue))
			{
				if (numericUpDown1.Text.Equals(""))
				{
					//set it to the normal port, 53640. it wouldn't make any sense if we set it to 0.
					GlobalVars.RobloxPort = GlobalVars.DefaultRobloxPort;
				}
				else
				{
					GlobalVars.RobloxPort = Convert.ToInt32(numericUpDown1.Text);
				}
			}
			else
			{
				GlobalVars.RobloxPort = GlobalVars.DefaultRobloxPort;
			}
			label38.Text = GlobalVars.RobloxPort.ToString();
		}
		
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox5.Text, out parsedValue))
			{
				if (textBox5.Text.Equals(""))
				{
					GlobalVars.UserID = 0;
				}
				else
				{
					GlobalVars.UserID = Convert.ToInt32(textBox5.Text);
				}
			}
			else
			{
				GlobalVars.UserID = 0;
			}
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			CharacterCustomization ccustom = new CharacterCustomization();
			ccustom.Show();
		}
		
		void Button9Click(object sender, EventArgs e)
		{
			ResetConfigValues();
			DialogResult result = MessageBox.Show("Your configuration has been reset to the default values.","RBXLegacy Launcher - Configuration", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
		}
		
		void ListBox3SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				GlobalVars.IP = listBox3.SelectedItem.ToString();
				textBox1.Text = GlobalVars.IP;
				checkBox3.Enabled = false;
				GlobalVars.LocalPlayMode = false;
				label37.Text = GlobalVars.IP;
			}
			catch (Exception)
      		{
			}
		}
		
		void ListBox4SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				GlobalVars.RobloxPort = Convert.ToInt32(listBox4.SelectedItem.ToString());
				numericUpDown1.Text = GlobalVars.RobloxPort.ToString();
				label38.Text = GlobalVars.RobloxPort.ToString();
			}
			catch (Exception)
      		{
			}
		}
		
		void Button10Click(object sender, EventArgs e)
		{
			File.AppendAllText("servers.txt", GlobalVars.IP + Environment.NewLine);
		}
		
		void Button11Click(object sender, EventArgs e)
		{
			File.AppendAllText("ports.txt", GlobalVars.RobloxPort + Environment.NewLine);
		}
		
		void Button12Click(object sender, EventArgs e)
		{
			if (listBox3.SelectedIndex >= 0)
			{
				TextLineRemover.RemoveTextLines(new List<string> { listBox3.SelectedItem.ToString() }, "servers.txt", "servers.tmp");
				listBox3.Items.Clear();
				string[] lines_server = File.ReadAllLines("servers.txt");
				listBox3.Items.AddRange(lines_server);
			}
		}
		
		void Button13Click(object sender, EventArgs e)
		{
			if (listBox4.SelectedIndex >= 0)
			{
				TextLineRemover.RemoveTextLines(new List<string> { listBox4.SelectedItem.ToString() }, "ports.txt", "ports.tmp");
				listBox4.Items.Clear();
				string[] lines_ports = File.ReadAllLines("ports.txt");
				listBox4.Items.AddRange(lines_ports);
			}
		}
		
		void Button14Click(object sender, EventArgs e)
		{
			File.Create("servers.txt").Dispose();
			listBox3.Items.Clear();
			string[] lines_server = File.ReadAllLines("servers.txt");
			listBox3.Items.AddRange(lines_server);
		}
		
		void Button15Click(object sender, EventArgs e)
		{
			File.Create("ports.txt").Dispose();
			listBox4.Items.Clear();
			string[] lines_ports = File.ReadAllLines("ports.txt");
			listBox4.Items.AddRange(lines_ports);
		}
		
		void Button16Click(object sender, EventArgs e)
		{
			File.AppendAllText("servers.txt", GlobalVars.IP + Environment.NewLine);
			listBox3.Items.Clear();
			string[] lines_server = File.ReadAllLines("servers.txt");
			listBox3.Items.AddRange(lines_server);			
		}
		
		void Button17Click(object sender, EventArgs e)
		{
			File.AppendAllText("ports.txt", GlobalVars.RobloxPort + Environment.NewLine);
			listBox4.Items.Clear();
			string[] lines_ports = File.ReadAllLines("ports.txt");
			listBox4.Items.AddRange(lines_ports);
		}
		
		void Button19Click(object sender, EventArgs e)
		{
			if (GlobalVars.SelectedClientVersion >= 7)
			{
				DialogResult result = MessageBox.Show("Note: If the health bar or scoreboard don't appear, just reset your character.","RBXLegacy Launcher - Play Solo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			WriteConfigValues();
			StartSolo();
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.WindowState = FormWindowState.Minimized;
			}
		}
		
		void Button20Click(object sender, EventArgs e)
		{
			ServerPrefs prefspanel = new ServerPrefs();
			prefspanel.Show();
		}
		
		void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
			//Command proxy
            
            int totalLines = richTextBox1.Lines.Length;
            if (totalLines > 0)
            {
				string lastLine = richTextBox1.Lines[totalLines - 1];
            
            	if (e.KeyCode == Keys.Enter)
            	{
            		richTextBox1.AppendText(Environment.NewLine);
            		ConsoleProcessCommands(lastLine);
            		e.Handled = true;
            	}
            }
            
            if ( e.Modifiers == Keys.Control )
			{
				switch(e.KeyCode)
				{
				case Keys.C:
				case Keys.X:
				case Keys.V:
				case Keys.Z:
					e.Handled = true;
					break;
				default:
					break;
				}
			}
        }
		
		void ResetConfigValues()
		{
			LauncherFuncs.ResetConfigValues();
			WriteConfigValues();
			ReadConfigValues();
		}
		
		void ConsolePrint(string text, int type)
		{
			//1 = white text, 2 = red text, 3 = green text, 4 = aqua text, 5 = yellow text
			richTextBox1.AppendText("[" + DateTime.Now.ToShortTimeString() + "]", Color.White);
			richTextBox1.AppendText(" - ", Color.White);
			if (type == 1)
			{
				richTextBox1.AppendText(text, Color.White);
			}
			else if (type == 2)
			{
				richTextBox1.AppendText(text, Color.Red);
			}
			else if (type == 3)
			{
				richTextBox1.AppendText(text, Color.Lime);
			}
			else if (type == 4)
			{
				richTextBox1.AppendText(text, Color.Aqua);
			}
			else if (type == 5)
			{
				richTextBox1.AppendText(text, Color.Yellow);
			}
			
			richTextBox1.AppendText(Environment.NewLine);
		}
		
		void StartClient()
		{
			if (SecurityFuncs.checkScriptMD5() == true)
			{
			string rbxexe = "";
			if (GlobalVars.LegacyMode == true)
			{
				rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			}
			else
			{
				rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxPlayer.exe";
			}
			string quote = "\"";
			string args = "";
			string HatIDOffline1 = GlobalVars.Custom_Hat1ID_Offline;
			string HatIDOffline2 = GlobalVars.Custom_Hat2ID_Offline;
			string HatIDOffline3 = GlobalVars.Custom_Hat3ID_Offline;
			if (GlobalVars.HasRocky == true)
			{
				if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true)
				{
					args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "'); _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + ") _G.CSConnect(" + GlobalVars.UserID + ",'localhost'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.AdminMode.ToString().ToLower() + ")" + quote;
				}
				else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true)
				{
					args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "'); _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + ") _G.CSConnect(" + GlobalVars.UserID + ",'localhost'," + GlobalVars.RobloxPort + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.AdminMode.ToString().ToLower() + ")" + quote;
				}
				else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false)
				{
					args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "'); _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + ") _G.CSConnect(0,'localhost'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.AdminMode.ToString().ToLower() + ")" + quote;
				}
				else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false)
				{
					args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "'); _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + ") _G.CSConnect(0,'localhost'," + GlobalVars.RobloxPort + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.AdminMode.ToString().ToLower() + ")" + quote;
				}
			}
			else
			{
				if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true)
				{
					args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + "); _G.CSConnect(" + GlobalVars.UserID + "," + GlobalVars.IP + "," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.AdminMode.ToString().ToLower() + ")" + quote;
				}
				else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true)
				{
					args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + "); _G.CSConnect(" + GlobalVars.UserID + "," + GlobalVars.IP + "," + GlobalVars.RobloxPort + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.AdminMode.ToString().ToLower() + ")" + quote;
				}
				else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false)
				{
					args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + "); _G.CSConnect(0," + GlobalVars.IP + "," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.AdminMode.ToString().ToLower() + ")" + quote;
				}
				else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false)
				{
					args = "-script " + quote + "dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + "); _G.CSConnect(0," + GlobalVars.IP + "," + GlobalVars.RobloxPort + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.AdminMode.ToString().ToLower() + ")" + quote;
				}
			}
			try
			{
				ConsolePrint("Client Loaded.", 4);
				if (SecurityFuncs.checkClientMD5(GlobalVars.SelectedClient) == true)
				{
					Process client = new Process();
					client.StartInfo.FileName = rbxexe;
					client.StartInfo.Arguments = args;
					client.EnableRaisingEvents = true;
					ReadClientValues(GlobalVars.SelectedClient);
					client.Exited += new EventHandler(ClientExited);
					client.Start();
					GlobalVars.presence.largeImageKey = GlobalVars.imagekey_large;
            		GlobalVars.presence.state = "In " + GlobalVars.SelectedClient + " Game";
            		GlobalVars.presence.largeImageText = GlobalVars.PlayerName;
            		DiscordRpc.UpdatePresence(ref GlobalVars.presence);
				}
			}
			catch (Exception)
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (The client has been detected as modified.)", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: The client has been detected as modified.)","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			}
			else
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (The script has been detected as modified.)", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: The script has been detected as modified.)","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void ClientExited(object sender, EventArgs e)
		{
			Process[] sudp = Process.GetProcessesByName("udppipe");
			if (sudp != null)
			{
				foreach (var process in sudp)
				{
    				process.Kill();
				}
				
				if (this.WindowState == FormWindowState.Minimized)
				{
					this.WindowState = FormWindowState.Normal;
				}
			}
			
			GlobalVars.presence.largeImageKey = GlobalVars.imagekey_large;
            GlobalVars.presence.state = "In Launcher";
            GlobalVars.presence.largeImageText = GlobalVars.PlayerName;
            DiscordRpc.UpdatePresence(ref GlobalVars.presence);
		}
		
		void StartSolo()
		{
			string mapfile = GlobalVars.MapsDir + @"\\" + GlobalVars.Map;
            string rbxexe = "";
            if (GlobalVars.LegacyMode == true)
            {
                rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
            }
            else
            {
                rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxStudio.exe";
            }
            string quote = "\"";
			string args = "";
			string HatIDOffline1 = GlobalVars.Custom_Hat1ID_Offline;
			string HatIDOffline2 = GlobalVars.Custom_Hat2ID_Offline;
			string HatIDOffline3 = GlobalVars.Custom_Hat3ID_Offline;
			if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true)
			{
				args = quote + "\"-script \"dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + ") _G.CSSolo(" + GlobalVars.UserID + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.RespawnTime + ") " + quote + " " + quote + mapfile + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true)
			{
				args = quote + "\"-script \"dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + ") _G.CSSolo(" + GlobalVars.UserID + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.RespawnTime + ") " + quote + " " + quote + mapfile + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false)
			{
				args = quote + "\"-script \"dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + ") _G.CSSolo(0,'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.RespawnTime + ") " + quote + " " + quote + mapfile + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false )
			{
				args = quote + "\"-script \"dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + ") _G.CSSolo(0,'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.Custom_IconType + "'," + GlobalVars.RespawnTime + ") " + quote + " " + quote + mapfile + quote;
			}
			try
			{
				ConsolePrint("Play Solo Loaded.", 4);
				Process client = new Process();
				client.StartInfo.FileName = rbxexe;
				client.StartInfo.Arguments = args;
				client.EnableRaisingEvents = true;
				ReadClientValues(GlobalVars.SelectedClient);
				client.Exited += new EventHandler(StudioExited);
				client.Start();
				GlobalVars.presence.largeImageKey = GlobalVars.imagekey_large;
            	GlobalVars.presence.state = "In " + GlobalVars.SelectedClient + " Solo Game";
            	GlobalVars.presence.largeImageText = GlobalVars.PlayerName;
            	DiscordRpc.UpdatePresence(ref GlobalVars.presence);
			}
			catch (Exception ex)
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (" + ex.Message + ")", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
			
		void StartServer()
		{
			string mapfile = GlobalVars.MapsDir + @"\\" + GlobalVars.Map;
            string rbxexe = "";
            if (GlobalVars.LegacyMode == true)
            {
                rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
            }
            else
            {
                rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxStudio.exe";
            }
            string quote = "\"";
			string args = "";
			args = "-script \"dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + "); _G.CSServer(" + GlobalVars.ServerPort + "," + GlobalVars.PlayerLimit + "," + GlobalVars.RespawnTime + ",'" + GlobalVars.ChatType + "'," + GlobalVars.UserID + "," + GlobalVars.blacklist1 + "," + GlobalVars.blacklist2 + "," + GlobalVars.blacklist3 + "," + GlobalVars.blacklist4 + "," + GlobalVars.blacklist5 + "," + GlobalVars.blacklist6 + "," + GlobalVars.blacklist7 + "," + GlobalVars.blacklist8 + ") " + quote + " " + quote + mapfile + quote;
			try
			{
				ConsolePrint("Server Loaded.", 4);
				Process server = new Process();
				server.StartInfo.FileName = rbxexe;
				server.StartInfo.Arguments = args;
				server.EnableRaisingEvents = true;
				ReadClientValues(GlobalVars.SelectedClient);
				if (GlobalVars.upnp == true)
				{
					server.Exited += new EventHandler(ServerExited);
				}
				server.Start();
			}
			catch (Exception ex)
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (" + ex.Message + ")", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void StartServerNo3D()
		{
			string mapfile = GlobalVars.MapsDir + @"\\" + GlobalVars.Map;
            string rbxexe = "";
            if (GlobalVars.LegacyMode == true)
            {
                rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
            }
            else
            {
                rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxStudio.exe";
            }
            string quote = "\"";
			string args = "";
			args = "-script \"dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + "); _G.CSServer(" + GlobalVars.ServerPort + "," + GlobalVars.PlayerLimit + "," + GlobalVars.RespawnTime + ",'" + GlobalVars.ChatType + "'," + GlobalVars.UserID + "," + GlobalVars.blacklist1 + "," + GlobalVars.blacklist2 + "," + GlobalVars.blacklist3 + "," + GlobalVars.blacklist4 + "," + GlobalVars.blacklist5 + "," + GlobalVars.blacklist6 + "," + GlobalVars.blacklist7 + "," + GlobalVars.blacklist8 + ") " + quote + " -no3d " + quote + mapfile + quote;
			try
			{
				ConsolePrint("Server Loaded in No3D mode.", 4);
				Process server = new Process();
				server.StartInfo.FileName = rbxexe;
				server.StartInfo.Arguments = args;
				server.EnableRaisingEvents = true;
				ReadClientValues(GlobalVars.SelectedClient);
				if (GlobalVars.upnp == true)
				{
					server.Exited += new EventHandler(ServerExited);
				}
				server.Start();
			}
			catch (Exception ex)
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (" + ex.Message + ")", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void ServerExited(object sender, EventArgs e)
		{
			StopUPNP();
				
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.WindowState = FormWindowState.Normal;
			}
		}
		
		void StartStudio()
		{
			string mapfile = GlobalVars.MapsDir + @"\\" + GlobalVars.Map;
            string rbxexe = "";
            if (GlobalVars.LegacyMode == true)
            {
                rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
            }
            else
            {
                rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxStudio.exe";
            }
            string quote = "\"";
			string args = "";
			ReadClientValues(GlobalVars.SelectedClient);
			args = "-script \"dofile('" + GlobalVars.DefaultScript + "') _G.SetRBXLegacyVersion(" + GlobalVars.SelectedClientVersion + ") " + quote + " " + quote + mapfile + quote;
			try
			{
				ConsolePrint("Studio Loaded.", 4);
				Process client = new Process();
				client.StartInfo.FileName = rbxexe;
				client.StartInfo.Arguments = args;
				client.EnableRaisingEvents = true;
				ReadClientValues(GlobalVars.SelectedClient);
				client.Exited += new EventHandler(StudioExited);
				client.Start();
				GlobalVars.presence.largeImageKey = GlobalVars.imagekey_large;
            	GlobalVars.presence.state = "In " + GlobalVars.SelectedClient + " Solo Game";
            	GlobalVars.presence.largeImageText = GlobalVars.PlayerName;
            	DiscordRpc.UpdatePresence(ref GlobalVars.presence);
			}
			catch (Exception ex)
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (" + ex.Message + ")", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void StudioExited(object sender, EventArgs e)
		{
			GlobalVars.presence.largeImageKey = GlobalVars.imagekey_large;
            GlobalVars.presence.state = "In Launcher";
            GlobalVars.presence.largeImageText = GlobalVars.PlayerName;
            DiscordRpc.UpdatePresence(ref GlobalVars.presence);
		}
		
		void ConsoleProcessCommands(string command)
		{
			string important = SecurityFuncs.Base64Decode("a2FucmlzaGE=");
			if (command.Equals("server"))
			{
				if (GlobalVars.upnp == true)
				{
					StartUPNP();
				}
				StartServer();
			}
			else if (command.Equals("serverno3d"))
			{
				if (GlobalVars.upnp == true)
				{
					StartUPNP();
				}
				StartServerNo3D();
			}
			else if (command.Equals("client"))
			{
				ReadClientValues(GlobalVars.SelectedClient);
				if (GlobalVars.HasRocky == true)
				{
					Process sudp = new Process();
					sudp.StartInfo.FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +  "\\udppipe.exe";
					sudp.StartInfo.Arguments = "-p " + GlobalVars.IP + " " + GlobalVars.RobloxPort  + " " + GlobalVars.RobloxPort;
					sudp.StartInfo.UseShellExecute = false;
					sudp.StartInfo.CreateNoWindow = true;
					sudp.Start();
				}
				StartClient();
			}
			else if (command.Equals("solo"))
			{
				StartSolo();
			}
			else if (command.Equals("studio"))
			{
				StartStudio();
			}
			else if (command.Equals("config save"))
			{
				WriteConfigValues();
			}
			else if (command.Equals("config load"))
			{
				ReadConfigValues();
			}
			else if (command.Equals("config reset"))
			{
				ResetConfigValues();
			}
			else if (command.Equals("sdk"))
			{
				SDKForm sdk = new SDKForm();
				sdk.Show();
				ConsolePrint("Launched SDK.", 4);
			}
			else if (command.Equals("config"))
			{
				ConsoleRBXLegacyHelp(1);
			}
			else if (command.Equals("help"))
			{
				ConsoleRBXLegacyHelp(0);
			}
			else if (command.Equals(important))
			{
				GlobalVars.AdminMode = true;
				ConsolePrint("ADMIN MODE ENABLED.", 4);
				ConsolePrint("YOU ARE GOD.", 2);
			}
			else
			{
				ConsolePrint("ERROR 3 - Command is invalid", 2);
			}
			
		}
		
		void ConsoleRBXLegacyHelp(int page)
		{
			if (page == 1)
			{
				ConsolePrint("RBXLegacy Config Command List", 2);
				ConsolePrint("-----------------------------------------", 1);
				ConsolePrint("config save | Saves the config file", 4);
				ConsolePrint("config load | Reloads the config file", 4);
				ConsolePrint("config reset | Resets the config file", 4);
			}
			else
			{
				ConsolePrint("RBXLegacy Console Command List", 2);
				ConsolePrint("------------------------------------------", 1);
				ConsolePrint("client | Loads client with launcher settings", 4);
				ConsolePrint("solo | Loads client in Play Solo mode with launcher settings", 4);
				ConsolePrint("server | Loads server with launcher settings", 4);
				ConsolePrint("serverno3d | Loads server in No3D mode with launcher settings", 4);
				ConsolePrint("studio | Loads Roblox Studio with launcher settings", 4);
				ConsolePrint("sdk | Loads the RBXLegacy SDK", 4);
				ConsolePrint("config save | Saves the config file", 4);
				ConsolePrint("config load | Reloads the config file", 4);
				ConsolePrint("config reset | Resets the config file", 4);
			}
		}
	}
}
