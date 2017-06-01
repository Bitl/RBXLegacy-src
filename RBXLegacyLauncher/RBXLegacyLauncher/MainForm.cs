/*
 * Created by SharpDevelop.
 * User: BITL-Gaming
 * Date: 10/7/2016
 * Time: 3:01 PM
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

namespace RBXLegacyLauncher
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
     		if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])//your specific tabname
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
     		else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])//your specific tabname
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
     		else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage6"])//your specific tabname
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
			
			DialogResult result = MessageBox.Show("Be sure to save your config options with the 'Save Config' button before you join a server!","RBXLegacy Launcher - Join Server", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.Cancel)
				return;
			
			StartClient();
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Be sure to save your config options with the 'Save Config' button before you start a server!","RBXLegacy Launcher - Start Server", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.Cancel)
				return;
			
			StartServer();
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			MessageBox.Show("If you want to test out your place, you will have to save your place in RBXLegacy's map folder, then launch your place in Play Solo.","RBXLegacy Launcher - Launch ROBLOX Studio", MessageBoxButtons.OK, MessageBoxIcon.Information);
			StartStudio();
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			string[] lines = File.ReadAllLines("info.txt"); //File is in System.IO
			string version = lines[0];
			string[] defaultclient = File.ReadAllLines("info.txt");
    		string defcl = defaultclient[1];
    		GlobalVars.SelectedClient = defcl;
    		ConsolePrint("RBXLegacy Launcher version " + version + " loaded. Initializing config.", 4);
    		if (File.Exists("changelog.txt"))
			{
    			richTextBox2.Text = File.ReadAllText("changelog.txt");
    		}
    		else
    		{
    			ConsolePrint("ERROR 4 - changelog.txt not found.", 2);
    		}
			if (!File.Exists("config.txt"))
			{
				ConsolePrint("WARNING 1 - config.txt not found. Creating one with default values.", 5);
				WriteConfigValues();
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
			GlobalVars.CustomPlayerDir = Path.Combine(Environment.CurrentDirectory, @"charcustom");
			GlobalVars.CustomPlayerDir = GlobalVars.CustomPlayerDir.Replace(@"\",@"\\");
			label5.Text = Environment.CurrentDirectory;
			label8.Text = Application.ProductVersion;
			GlobalVars.IP = "localhost";
    		GlobalVars.Map = "Baseplate.rbxl";
    		label11.Text = version;
    		GlobalVars.Version = version;
    		ReadConfigValues();
		}
		
		void ReadConfigValues()
		{
			string line1, line2, line3, line4, line5, line6, line7, line8, line9, line10, line11, line12, line13, line14, line15, line16, line17, line18, line19, line20, line21;

			using(StreamReader reader = new StreamReader("config.txt")) 
			{
    			line1 = reader.ReadLine();
    			line2 = reader.ReadLine();
    			line3 = reader.ReadLine();
    			line4 = reader.ReadLine();
    			line5 = reader.ReadLine();
    			line6 = reader.ReadLine();
    			line7 = reader.ReadLine();
    			line8 = reader.ReadLine();
    			line9 = reader.ReadLine();
    			line10 = reader.ReadLine();
    			line11 = reader.ReadLine();
    			line12 = reader.ReadLine();
    			line13 = reader.ReadLine();
    			line14 = reader.ReadLine();
    			line15 = reader.ReadLine();
    			line16 = reader.ReadLine();
    			line17 = reader.ReadLine();
    			line18 = reader.ReadLine();
    			line19 = reader.ReadLine();
    			line20 = reader.ReadLine();
    			line21 = reader.ReadLine();
			}
			
			bool bline1 = Convert.ToBoolean(line1);
			GlobalVars.CloseOnLaunch = bline1;
			
			int iline2 = Convert.ToInt32(line2);
			GlobalVars.UserID = iline2;
			
			GlobalVars.PlayerName = line3;
			
			GlobalVars.SelectedClient = line4;
			
			GlobalVars.Map = line5;
			
			int iline6 = Convert.ToInt32(line6);
			GlobalVars.RobloxPort = iline6;
			
			GlobalVars.Custom_Hat1ID_Offline = line7;
			GlobalVars.Custom_Hat2ID_Offline = line8;
			GlobalVars.Custom_Hat3ID_Offline = line9;
			
			int iline10 = Convert.ToInt32(line10);
			GlobalVars.HeadColorID = iline10;
			
			int iline11 = Convert.ToInt32(line11);
			GlobalVars.TorsoColorID = iline11;
			
			int iline12 = Convert.ToInt32(line12);
			GlobalVars.LeftArmColorID = iline12;
			
			int iline13 = Convert.ToInt32(line13);
			GlobalVars.RightArmColorID = iline13;
			
			int iline14 = Convert.ToInt32(line14);
			GlobalVars.LeftLegColorID = iline14;
			
			int iline15 = Convert.ToInt32(line15);
			GlobalVars.RightLegColorID = iline15;
			
			GlobalVars.ColorMenu_HeadColor = line16;
			GlobalVars.ColorMenu_TorsoColor = line17;
			GlobalVars.ColorMenu_LeftArmColor = line18;
			GlobalVars.ColorMenu_RightArmColor = line19;
			GlobalVars.ColorMenu_LeftLegColor = line20;
			GlobalVars.ColorMenu_RightLegColor = line21;
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				checkBox1.Checked = true;
			}
			else if (GlobalVars.CloseOnLaunch == false)
			{
				checkBox1.Checked = false;
			}
			
			if (iline2 == 0)
			{
				GeneratePlayerID();
				WriteConfigValues();
			}
			else
			{
				textBox5.Text = Convert.ToString(iline2);
			}
			
			textBox2.Text = GlobalVars.PlayerName;
			
			label26.Text = GlobalVars.SelectedClient;
			label28.Text = GlobalVars.Map;
			listBox1.SelectedItem = GlobalVars.Map;
			textBox4.Text = GlobalVars.RobloxPort.ToString();
			label37.Text = GlobalVars.IP;
			label38.Text = GlobalVars.RobloxPort.ToString();
			ConsolePrint("Config loaded.", 3);
			ReadClientValues(GlobalVars.SelectedClient);
		}
		
		void WriteConfigValues()
		{
			string[] lines = { 
				GlobalVars.CloseOnLaunch.ToString(), 
				GlobalVars.UserID.ToString(), 
				GlobalVars.PlayerName.ToString(), 
				GlobalVars.SelectedClient.ToString(), 
				GlobalVars.Map.ToString(), 
				GlobalVars.RobloxPort.ToString(), 
				GlobalVars.Custom_Hat1ID_Offline.ToString(),
				GlobalVars.Custom_Hat2ID_Offline.ToString(),
				GlobalVars.Custom_Hat3ID_Offline.ToString(),
				GlobalVars.HeadColorID.ToString(),
				GlobalVars.TorsoColorID.ToString(),
				GlobalVars.LeftArmColorID.ToString(),
				GlobalVars.RightArmColorID.ToString(),
				GlobalVars.LeftLegColorID.ToString(),
				GlobalVars.RightLegColorID.ToString(),
				GlobalVars.ColorMenu_HeadColor.ToString(),
				GlobalVars.ColorMenu_TorsoColor.ToString(),
				GlobalVars.ColorMenu_LeftArmColor.ToString(),
				GlobalVars.ColorMenu_RightArmColor.ToString(),
				GlobalVars.ColorMenu_LeftLegColor.ToString(),
				GlobalVars.ColorMenu_RightLegColor.ToString(),
			};
			File.WriteAllLines("config.txt", lines);
			ConsolePrint("Config Saved.", 3);
		}
		
		void ResetConfigValues()
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
			ConsolePrint("All config settings reset. Reloading config.", 4);
			WriteConfigValues();
			ReadConfigValues();
		}
		
		void ReadClientValues(string ClientName)
		{
			string clientpath = GlobalVars.ClientDir + @"\\" + ClientName + @"\\clientinfo.txt";
			
			if (!File.Exists(clientpath))
			{
				ConsolePrint("ERROR 1 - No clientinfo.txt detected with the client you chose. The client either cannot be loaded, or it is not available.", 2);
				MessageBox.Show("No clientinfo.txt detected with the client you chose. The client either cannot be loaded, or it is not available.","RBXLegacy Launcher - Error while loading client", MessageBoxButtons.OK, MessageBoxIcon.Error);
				GlobalVars.SelectedClient = "2008";
			}
			
			string line1, line2, line3, line4;

			using(StreamReader reader = new StreamReader(clientpath)) 
			{
    			line1 = reader.ReadLine();
    			line2 = reader.ReadLine();
    			line3 = reader.ReadLine();
    			line4 = reader.ReadLine();
			}
			
			bool bline1 = Convert.ToBoolean(line1);
			GlobalVars.UsesPlayerName = bline1;
			
			bool bline2 = Convert.ToBoolean(line2);
			GlobalVars.UsesID = bline2;
			
			bool bline3 = Convert.ToBoolean(line3);
			GlobalVars.LoadsAssetsOnline = bline3;
			
			GlobalVars.SelectedClientDesc = line4;
			
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
			
			if (GlobalVars.LoadsAssetsOnline == false)
			{
				label30.Visible = false;
			}
			else if (GlobalVars.LoadsAssetsOnline == true)
			{
				label30.Visible = true;
			}
			
			textBox6.Text = GlobalVars.SelectedClientDesc;
			label26.Text = GlobalVars.SelectedClient;
			ConsolePrint("Client '" + GlobalVars.SelectedClient + "' successfully loaded.", 3);
		}
		
		void GeneratePlayerID()
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
			MessageBox.Show("Config Saved!");
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
		
		void Button6Click(object sender, EventArgs e)
		{
			ClientinfoEditor cie = new ClientinfoEditor();
			cie.Show();
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			WriteConfigValues();
			MessageBox.Show("Config Saved!");
		}
		
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox4.Text, out parsedValue))
			{
				if (textBox4.Text.Equals(""))
				{
					//set it to the normal port, 53640. it wouldn't make any sense if we set it to 0.
					GlobalVars.RobloxPort = GlobalVars.DefaultRobloxPort;
				}
				else
				{
					GlobalVars.RobloxPort = Convert.ToInt32(textBox4.Text);
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
			MessageBox.Show("Config Reset!");
		}
		
		void ListBox3SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalVars.IP = listBox3.SelectedItem.ToString();
			textBox1.Text = GlobalVars.IP;
			checkBox3.Enabled = false;
			GlobalVars.LocalPlayMode = false;
			label37.Text = GlobalVars.IP;
		}
		
		void ListBox4SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalVars.RobloxPort = Convert.ToInt32(listBox4.SelectedItem.ToString());
			textBox4.Text = GlobalVars.RobloxPort.ToString();
			label38.Text = GlobalVars.RobloxPort.ToString();
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
		
		void Button18Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Be sure to save your config options with the 'Save Config' button before you start a server!","RBXLegacy Launcher - Start Server", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.Cancel)
				return;
			
			StartServerNo3D();
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}						
		}
		
		void Button19Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Be sure to save your config options with the 'Save Config' button before starting a solo game!","RBXLegacy Launcher - Play Solo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.Cancel)
				return;
			
			StartSolo();
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}
		
		void Button20Click(object sender, EventArgs e)
		{
			ServerInfo infopanel = new ServerInfo();
			infopanel.Show();
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
            	}
            }
        }
		
		void StartClient()
		{
			string luafile = "rbxasset://scripts\\\\CSMPFunctions.lua";
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string quote = "\"";
			string args = "";
			string HatIDOffline1 = GlobalVars.Custom_Hat1ID_Offline;
			string HatIDOffline2 = GlobalVars.Custom_Hat2ID_Offline;
			string HatIDOffline3 = GlobalVars.Custom_Hat3ID_Offline;
			if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true)
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true)
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false)
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false)
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ");" + quote;
			}
			try
			{
				ConsolePrint("Client Loaded.", 4);
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (" + ex.Message + ")", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void StartSolo()
		{
			string luafile = "rbxasset://scripts\\\\CSMPFunctions.lua";
			string mapfile = GlobalVars.MapsDir + @"\\" + GlobalVars.Map;
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string quote = "\"";
			string args = "";
			string HatIDOffline1 = GlobalVars.Custom_Hat1ID_Offline;
			string HatIDOffline2 = GlobalVars.Custom_Hat2ID_Offline;
			string HatIDOffline3 = GlobalVars.Custom_Hat3ID_Offline;
			if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true)
			{
				args = quote + mapfile + "\" -script \"dofile('" + luafile + "'); _G.CSSolo(" + GlobalVars.UserID + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true)
			{
				args = quote + mapfile + "\" -script \"dofile('" + luafile + "'); _G.CSSolo(" + GlobalVars.UserID + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false)
			{
				args = quote + mapfile + "\" -script \"dofile('" + luafile + "'); _G.CSSolo(0,'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false )
			{
				args = quote + mapfile + "\" -script \"dofile('" + luafile + "'); _G.CSSolo(0,'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ");" + quote;
			}
			try
			{
				ConsolePrint("Play Solo Loaded.", 4);
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (" + ex.Message + ")", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void StartServer()
		{
			string luafile = "rbxasset://scripts\\\\CSMPFunctions.lua";
			string mapfile = GlobalVars.MapsDir + @"\\" + GlobalVars.Map;
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string quote = "\"";
			string args = "";
			args = quote + mapfile + "\" -script \"dofile('" + luafile + "'); _G.CSServer(" + GlobalVars.RobloxPort + "); " + quote;
			try
			{
				ConsolePrint("Server Loaded.", 4);
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (" + ex.Message + ")", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void StartServerNo3D()
		{
			string luafile = "rbxasset://scripts\\\\CSMPFunctions.lua";
			string mapfile = GlobalVars.MapsDir + @"\\" + GlobalVars.Map;
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string quote = "\"";
			string args = "";
			args = quote + mapfile + "\" -script \"dofile('" + luafile + "'); _G.CSServer(" + GlobalVars.RobloxPort + "); " + quote + " -no3d";
			try
			{
				ConsolePrint("Server Loaded in No3d.", 4);
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (" + ex.Message + ")", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void StartStudio()
		{
			string luafile = "rbxasset://scripts\\\\CSMPFunctions.lua";
			string mapfile = GlobalVars.MapsDir + @"\\" + GlobalVars.Map;
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string quote = "\"";
			string args = "";
			args = quote + mapfile + "\" -script \"dofile('" + luafile + "');" + quote;
			try
			{
				ConsolePrint("Studio Loaded.", 4);
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
				ConsolePrint("ERROR 2 - Failed to launch RBXLegacy. (" + ex.Message + ")", 2);
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void ConsolePrint(string text, int type, bool newline = true)
		{
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
			
			if (newline == true)
			{
				richTextBox1.AppendText(Environment.NewLine);
			}
		}
		
		void ConsoleProcessCommands(string command)
		{
			if (command.Equals("rbxlegacy server"))
			{
				StartServer();
			}
			else if (command.Equals("rbxlegacy server no3d"))
			{
				StartServerNo3D();
			}
			else if (command.Equals("rbxlegacy no3d"))
			{
				StartServerNo3D();
			}
			else if (command.Equals("rbxlegacy client"))
			{
				StartClient();
			}
			else if (command.Equals("rbxlegacy client solo"))
			{
				StartSolo();
			}
			else if (command.Equals("rbxlegacy solo"))
			{
				StartSolo();
			}
			else if (command.Equals("rbxlegacy studio"))
			{
				StartStudio();
			}
			else if (command.Equals("rbxlegacy config save"))
			{
				WriteConfigValues();
			}
			else if (command.Equals("rbxlegacy config load"))
			{
				ReadConfigValues();
			}
			else if (command.Equals("rbxlegacy config reset"))
			{
				ResetConfigValues();
			}
			else if (command.Equals("rbxlegacy help"))
			{
				ConsoleRBXLegacyHelp(0);
			}
			else if (command.Equals("rbxlegacy"))
			{
				ConsoleRBXLegacyHelp(0);
			}
			else if (command.Equals("rbxlegacy config"))
			{
				ConsoleRBXLegacyHelp(1);
			}
			else if (command.Equals("config"))
			{
				ConsoleRBXLegacyHelp(1);
			}
			else if (command.Equals("help"))
			{
				ConsoleRBXLegacyHelp(0);
			}
			else
			{
				ConsolePrint("ERROR 3 - Command is either not registered or valid", 2, false);
			}
			
		}
		
		void ConsoleRBXLegacyHelp(int page)
		{
			if (page == 1)
			{
				ConsolePrint("rbxlegacy config", 2);
				ConsolePrint("-------------------------", 1);
				ConsolePrint("= save | Saves the config file", 3);
				ConsolePrint("= load | Reloads the config file", 3);
				ConsolePrint("= reset | Resets the config file", 3, false);
			}
			else
			{
				ConsolePrint("rbxlegacy", 2);
				ConsolePrint("---------", 1);
				ConsolePrint("= client | Loads client with launcher settings", 3);
				ConsolePrint("-- solo | Loads client in Play Solo mode with launcher settings", 4);
				ConsolePrint("= server | Loads server with launcher settings", 3);
				ConsolePrint("-- no3d | Loads server in NoGraphics mode with launcher settings", 4);
				ConsolePrint("= studio | Loads Roblox Studio with launcher settings", 3);
				ConsolePrint("= config", 3);
				ConsolePrint("-- save | Saves the config file", 4);
				ConsolePrint("-- load | Reloads the config file", 4);
				ConsolePrint("-- reset | Resets the config file", 4, false);
			}
		}
	}
}
