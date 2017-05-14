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
			string[] defaultclient = File.ReadAllLines("info.txt");
    		string defcl = defaultclient[1];
    		GlobalVars.SelectedClient = defcl;
			if (!File.Exists("config.txt"))
			{
				WriteConfigValues();
			}
			if (!File.Exists("servers.txt"))
			{
				File.Create("servers.txt").Dispose();
			}
			if (!File.Exists("ports.txt"))
			{
				File.Create("ports.txt").Dispose();
			}
			GlobalVars.ClientDir = Path.Combine(Environment.CurrentDirectory, @"clients");
			GlobalVars.ClientDir = GlobalVars.ClientDir.Replace(@"\",@"\\");
			GlobalVars.ScriptsDir = Path.Combine(Environment.CurrentDirectory, @"scripts");
			GlobalVars.ScriptsDir = GlobalVars.ScriptsDir.Replace(@"\",@"\\");
			GlobalVars.MapsDir = Path.Combine(Environment.CurrentDirectory, @"maps");
			GlobalVars.MapsDir = GlobalVars.MapsDir.Replace(@"\",@"\\");
			label5.Text = Environment.CurrentDirectory;
			label8.Text = Application.ProductVersion;
			GlobalVars.IP = "localhost";
    		GlobalVars.Map = "Baseplate.rbxl";
    		string[] lines = File.ReadAllLines("info.txt"); //File is in System.IO
			string version = lines[0];
    		label11.Text = version;
    		GlobalVars.Version = version;
    		ReadConfigValues();
		}
		
		void ReadConfigValues()
		{
			string line1, line2, line3, line4, line5, line6, line7, line8, line9, line10, line11, line12, line13, line14, line15, line16, line17, line18, line19, line20, line21, line22, line23, line24;

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
    			line22 = reader.ReadLine();
    			line23 = reader.ReadLine();
    			line24 = reader.ReadLine();
			}
			
			bool bline1 = Convert.ToBoolean(line1);
			GlobalVars.CloseOnLaunch = bline1;
			
			bool bline2 = Convert.ToBoolean(line2);
			GlobalVars.BodyColors = bline2;
			
			int iline3 = Convert.ToInt32(line3);
			GlobalVars.UserID = iline3;
			
			GlobalVars.PlayerName = line4;
			
			GlobalVars.SelectedClient = line5;
			
			int iline6 = Convert.ToInt32(line6);
			GlobalVars.CharacterAppearanceID = iline6;
			
			bool bline7 = Convert.ToBoolean(line7);
			GlobalVars.UseAppearanceID = bline7;
			
			GlobalVars.Map = line8;
			
			int iline9 = Convert.ToInt32(line9);
			GlobalVars.RobloxPort = iline9;
			
			bool bline10 = Convert.ToBoolean(line10);
			GlobalVars.UseCustomAppearanceID = bline10;
			
			GlobalVars.Custom_ColorHash = line11;
			
			int iline12 = Convert.ToInt32(line12);
			GlobalVars.Custom_ShirtsID = iline12;
			
			int iline13 = Convert.ToInt32(line13);
			GlobalVars.Custom_PantsID = iline13;
			
			int iline14 = Convert.ToInt32(line14);
			GlobalVars.Custom_TShirtsID = iline14;
			
			int iline15 = Convert.ToInt32(line15);
			GlobalVars.Custom_Hat1ID = iline15;
			
			int iline16 = Convert.ToInt32(line16);
			GlobalVars.Custom_Hat2ID = iline16;
			
			int iline17 = Convert.ToInt32(line17);
			GlobalVars.Custom_Hat3ID = iline17;
			
			int iline18 = Convert.ToInt32(line18);
			GlobalVars.Custom_Hat1Version = iline18;
			
			int iline19 = Convert.ToInt32(line19);
			GlobalVars.Custom_Hat2Version = iline19;
			
			int iline20 = Convert.ToInt32(line20);
			GlobalVars.Custom_Hat3Version = iline20;
			
			int iline21 = Convert.ToInt32(line21);
			GlobalVars.CustomMode = iline21;
			
			GlobalVars.Custom_Hat1ID_Offline = line22;
			GlobalVars.Custom_Hat2ID_Offline = line23;
			GlobalVars.Custom_Hat3ID_Offline = line24;
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				checkBox1.Checked = true;
			}
			else if (GlobalVars.CloseOnLaunch == false)
			{
				checkBox1.Checked = false;
			}
			
			if (GlobalVars.BodyColors == true)
			{
				checkBox2.Checked = true;
			}
			else if (GlobalVars.BodyColors == false)
			{
				checkBox2.Checked = false;
			}
			
			if (GlobalVars.UseAppearanceID == true)
			{
				textBox3.Enabled = true;
				checkBox4.Enabled = true;
				checkBox4.Checked = true;
				checkBox5.Enabled = false;
			}
			else if (GlobalVars.UseAppearanceID == false)
			{
				textBox3.Enabled = false;
				checkBox4.Enabled = false;
				checkBox4.Checked = false;
				if (GlobalVars.SupportsCharacterCustomization == true)
				{
					checkBox5.Enabled = true;
				}
			}
			
			if (GlobalVars.UseCustomAppearanceID == false)
			{
				checkBox5.Checked = false;
			}
			else if (GlobalVars.UseCustomAppearanceID == true)
			{
				checkBox5.Checked = true;
			}
			
			if (iline3 == 0)
			{
				GeneratePlayerID();
				WriteConfigValues();
			}
			else
			{
				textBox5.Text = Convert.ToString(iline3);
			}
			
			textBox2.Text = GlobalVars.PlayerName;
			
			label26.Text = GlobalVars.SelectedClient;
			label28.Text = GlobalVars.Map;
			listBox1.SelectedItem = GlobalVars.Map;
			textBox3.Text = GlobalVars.CharacterAppearanceID.ToString();
			textBox4.Text = GlobalVars.RobloxPort.ToString();
			label37.Text = GlobalVars.IP;
			label38.Text = GlobalVars.RobloxPort.ToString();
			ReadClientValues(GlobalVars.SelectedClient);
		}
		
		void WriteConfigValues()
		{
			string[] lines = { 
				GlobalVars.CloseOnLaunch.ToString(), 
				GlobalVars.BodyColors.ToString(), 
				GlobalVars.UserID.ToString(), 
				GlobalVars.PlayerName.ToString(), 
				GlobalVars.SelectedClient.ToString(), 
				GlobalVars.CharacterAppearanceID.ToString(), 
				GlobalVars.UseAppearanceID.ToString(), 
				GlobalVars.Map.ToString(), 
				GlobalVars.RobloxPort.ToString(), 
				GlobalVars.UseCustomAppearanceID.ToString(), 
				GlobalVars.Custom_ColorHash.ToString(), 
				GlobalVars.Custom_ShirtsID.ToString(), 
				GlobalVars.Custom_PantsID.ToString(), 
				GlobalVars.Custom_TShirtsID.ToString(), 
				GlobalVars.Custom_Hat1ID.ToString(), 
				GlobalVars.Custom_Hat2ID.ToString(), 
				GlobalVars.Custom_Hat3ID.ToString(), 
				GlobalVars.Custom_Hat1Version.ToString(), 
				GlobalVars.Custom_Hat2Version.ToString(), 
				GlobalVars.Custom_Hat3Version.ToString(),
				GlobalVars.CustomMode.ToString(),
				GlobalVars.Custom_Hat1ID_Offline.ToString(),
				GlobalVars.Custom_Hat2ID_Offline.ToString(),
				GlobalVars.Custom_Hat3ID_Offline.ToString(),
			};
			File.WriteAllLines("config.txt", lines);
		}
		
		void ResetConfigValues()
		{
			GlobalVars.CloseOnLaunch = false;
			GlobalVars.BodyColors = true;
			GlobalVars.UserID = 0;
			GlobalVars.PlayerName = "Player";
			GlobalVars.SelectedClient = "Mid-2008";
			GlobalVars.CharacterAppearanceID = 0;
			GlobalVars.UseAppearanceID = false;
			GlobalVars.Map = "Baseplate.rbxl";
			GlobalVars.RobloxPort = 53640;
			GlobalVars.UseCustomAppearanceID = false;
			GlobalVars.Custom_ColorHash = "";
			GlobalVars.Custom_ShirtsID = 0;
			GlobalVars.Custom_PantsID = 0;
			GlobalVars.Custom_TShirtsID = 0;
			GlobalVars.Custom_Hat1ID = 0;
			GlobalVars.Custom_Hat2ID = 0;
			GlobalVars.Custom_Hat3ID = 0;
			GlobalVars.CustomMode = 0;
			GlobalVars.Custom_Hat1ID_Offline = "NoHat.rbxm";
			GlobalVars.Custom_Hat2ID_Offline = "NoHat.rbxm";
			GlobalVars.Custom_Hat3ID_Offline = "NoHat.rbxm";
			WriteConfigValues();
			ReadConfigValues();
		}
		
		void ReadClientValues(string ClientName)
		{
			string clientpath = GlobalVars.ClientDir + @"\\" + ClientName + @"\\clientinfo.txt";
			
			if (!File.Exists(clientpath))
			{
				MessageBox.Show("No clientinfo.txt detected with the client you chose. The client either cannot be loaded, or it is not available.","RBXLegacy Launcher - Error while loading client", MessageBoxButtons.OK, MessageBoxIcon.Error);
				GlobalVars.SelectedClient = "2008";
			}
			
			string line1, line2, line3, line4, line5, line6, line7, line8;

			using(StreamReader reader = new StreamReader(clientpath)) 
			{
    			line1 = reader.ReadLine();
    			line2 = reader.ReadLine();
    			line3 = reader.ReadLine();
    			line4 = reader.ReadLine();
    			line5 = reader.ReadLine();
    			line6 = reader.ReadLine();
    			line7 = reader.ReadLine();
    			line8 = reader.ReadLine();
			}
			
			bool bline1 = Convert.ToBoolean(line1);
			GlobalVars.UsesPlayerName = bline1;
			
			bool bline2 = Convert.ToBoolean(line2);
			GlobalVars.UsesID = bline2;
			
			bool bline3 = Convert.ToBoolean(line3);
			GlobalVars.SupportsLocalPlay = bline3;
			
			bool bline4 = Convert.ToBoolean(line4);
			GlobalVars.SupportsAppearanceID = bline4;
			
			bool bline5 = Convert.ToBoolean(line5);
			GlobalVars.LoadsAssetsOnline = bline5;
			
			bool bline6 = Convert.ToBoolean(line6);
			GlobalVars.ModernClient = bline6;
			
			bool bline7 = Convert.ToBoolean(line7);
			GlobalVars.SupportsCharacterCustomization = bline7;
			
			GlobalVars.SelectedClientDesc = line8;
			
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
			}
			else if (GlobalVars.UsesID == false)
			{
				textBox5.Enabled = false;
				button4.Enabled = false;
				checkBox3.Enabled = false;
				GlobalVars.LocalPlayMode = false;
			}
			
			if (GlobalVars.SupportsLocalPlay == false)
			{
				checkBox3.Enabled = false;
				GlobalVars.LocalPlayMode = false;
			}
			else if (GlobalVars.SupportsLocalPlay == true)
			{
				checkBox3.Enabled = true;
			}
			
			if (GlobalVars.SupportsAppearanceID == false)
			{
				checkBox4.Enabled = false;
				checkBox4.Checked = false;
				textBox3.Enabled = false;
				GlobalVars.UseAppearanceID = false;
			}
			else if (GlobalVars.SupportsAppearanceID == true)
			{
				if (GlobalVars.UseCustomAppearanceID == false)
				{
					checkBox4.Enabled = true;
				}
				
				if (GlobalVars.UseAppearanceID == false)
				{
					textBox3.Enabled = false;
					checkBox4.Checked = false;
					if (GlobalVars.SupportsCharacterCustomization == true)
					{
						checkBox5.Enabled = true;
					}
				}
				else if (GlobalVars.UseAppearanceID == true)
				{
					textBox3.Enabled = true;
					checkBox4.Checked = true;
					if (GlobalVars.SupportsCharacterCustomization == true)
					{
						checkBox5.Enabled = false;
						button8.Enabled = false;
					}
				}
			}
			
			if (GlobalVars.LoadsAssetsOnline == false)
			{
				label30.Visible = false;
			}
			else if (GlobalVars.LoadsAssetsOnline == true)
			{
				label30.Visible = true;
			}
			
			if (GlobalVars.SupportsCharacterCustomization == true)
			{
				checkBox5.Enabled = true;
			}
			else if (GlobalVars.SupportsCharacterCustomization == false)
			{
				checkBox5.Enabled = false;
				checkBox5.Checked = false;
				button8.Enabled = false;
				GlobalVars.UseCustomAppearanceID = false;
				GlobalVars.CustomMode = 0;
			}
			
			textBox6.Text = GlobalVars.SelectedClientDesc;
			label26.Text = GlobalVars.SelectedClient;
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
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked == true)
			{
				GlobalVars.BodyColors = true;
			}
			else if (checkBox2.Checked == false)
			{
				GlobalVars.BodyColors = false;
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
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox3.Text, out parsedValue))
			{
				if (textBox3.Text == "")
				{
					GlobalVars.CharacterAppearanceID = 0;
				}
				else
				{
					GlobalVars.CharacterAppearanceID = Convert.ToInt32(textBox3.Text);
				}
			}
			else
			{
				GlobalVars.CharacterAppearanceID = 0;
			}
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			ClientinfoEditor cie = new ClientinfoEditor();
			cie.Show();
		}
		
		void CheckBox4CheckedChanged(object sender, EventArgs e)
		{
			if (GlobalVars.SupportsAppearanceID == true)
			{
				if (checkBox4.Checked == true)
				{
					GlobalVars.UseAppearanceID = true;
					textBox3.Enabled = true;
					GlobalVars.UseCustomAppearanceID = false;
					if (GlobalVars.SupportsCharacterCustomization == true)
					{
						checkBox5.Enabled = false;
						button8.Enabled = false;
						if (checkBox5.Checked == true)
						{
							GlobalVars.UseCustomAppearanceID = false;
							checkBox5.Checked = false;
						}
					}
				}
				else if (checkBox4.Checked == false)
				{
					GlobalVars.UseAppearanceID = false;
					textBox3.Enabled = false;
					if (GlobalVars.SupportsCharacterCustomization == true)
					{
						checkBox5.Enabled = true;
					}
				}
			}
		}
		
		bool IsUsingCharacterOutfitIDs()
		{
			if (GlobalVars.SupportsAppearanceID == false && GlobalVars.UseAppearanceID == false)
				return false;
			
			if (GlobalVars.SupportsAppearanceID == false)
				return false;
			
			if (GlobalVars.UseAppearanceID == false)
				return false;
			
			return true;
		}
		
		bool IsUsingCustomOutfits()
		{
			if (GlobalVars.SupportsCharacterCustomization == false)
				return false;
						
			if (GlobalVars.UseCustomAppearanceID == false)
				return false;
			
			return true;
		}
		
		bool IsInOfflineMode()
		{
			if(GlobalVars.CustomMode == 1)
				return true;
			
			return false;
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
				if (textBox4.Text == "")
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
				if (textBox5.Text == "")
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
		
		void CheckBox5CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox5.Checked == true)
			{
				GlobalVars.UseCustomAppearanceID = true;
				button8.Enabled = true;
				if (GlobalVars.SupportsAppearanceID == true)
				{
					checkBox4.Enabled = false;
					if (checkBox4.Checked == true)
					{
						GlobalVars.UseAppearanceID = false;
						checkBox4.Checked = false;
					}
				}
			}
			else if (checkBox5.Checked == false)
			{
				GlobalVars.UseCustomAppearanceID = false;
				button8.Enabled = false;
				if (GlobalVars.SupportsAppearanceID == true)
				{
					checkBox4.Enabled = true;
				}
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
			int timerset = 3000;
			int msgdivide = timerset / 1000;
			
			DialogResult result = MessageBox.Show("Be sure to save your config options with the 'Save Config' button before starting a solo game!"+ Environment.NewLine + Environment.NewLine +"Note: The launcher will start up a server and then launch the client "+ msgdivide +" seconds after. If the health bar does not appear, just reset your character. If your character does not move or your character lags after the client window is loaded, just open the server window then minimize it.","RBXLegacy Launcher - Play Solo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.Cancel)
				return;
			
			PlaySolo(timerset);
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}
		
		void StartClient()
		{
			string luafile = "rbxasset://scripts\\\\CSMPFunctions.lua";
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string quote = "\"";
			string args = "";
			if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true && IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "'," + GlobalVars.CharacterAppearanceID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true && IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player'," + GlobalVars.CharacterAppearanceID + ");" + quote;
			}
			//how the fuck does this even happen? oh well.
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false && IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "'," + GlobalVars.CharacterAppearanceID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false && IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player'," + GlobalVars.CharacterAppearanceID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && !IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "',0,'" + GlobalVars.Custom_ColorHash + "'," + GlobalVars.Custom_PantsID + "," + GlobalVars.Custom_ShirtsID + "," + GlobalVars.Custom_TShirtsID + "," + GlobalVars.Custom_Hat1ID + "," + GlobalVars.Custom_Hat2ID + "," + GlobalVars.Custom_Hat3ID + "," + GlobalVars.Custom_Hat1Version + "," + GlobalVars.Custom_Hat2Version + "," + GlobalVars.Custom_Hat3Version + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && !IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player',0,'" + GlobalVars.Custom_ColorHash + "'," + GlobalVars.Custom_PantsID + "," + GlobalVars.Custom_ShirtsID + "," + GlobalVars.Custom_TShirtsID + "," + GlobalVars.Custom_Hat1ID + "," + GlobalVars.Custom_Hat2ID + "," + GlobalVars.Custom_Hat3ID + "," + GlobalVars.Custom_Hat1Version + "," + GlobalVars.Custom_Hat2Version + "," + GlobalVars.Custom_Hat3Version + ");" + quote;
			}
			//how the fuck does this even happen? oh well.
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && !IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "',0,'" + GlobalVars.Custom_ColorHash + "'," + GlobalVars.Custom_PantsID + "," + GlobalVars.Custom_ShirtsID + "," + GlobalVars.Custom_TShirtsID + "," + GlobalVars.Custom_Hat1ID + "," + GlobalVars.Custom_Hat2ID + "," + GlobalVars.Custom_Hat3ID + "," + GlobalVars.Custom_Hat1Version + "," + GlobalVars.Custom_Hat2Version + "," + GlobalVars.Custom_Hat3Version + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player',0,'" + GlobalVars.Custom_Hat1ID_Offline + "','" + GlobalVars.Custom_Hat2ID_Offline + "','" + GlobalVars.Custom_Hat3ID_Offline + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect2(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "',0,'" + GlobalVars.Custom_Hat1ID_Offline + "','" + GlobalVars.Custom_Hat2ID_Offline + "','" + GlobalVars.Custom_Hat3ID_Offline + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect2(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player',0,'" + GlobalVars.Custom_Hat1ID_Offline + "','" + GlobalVars.Custom_Hat2ID_Offline + "','" + GlobalVars.Custom_Hat3ID_Offline + "');" + quote;
			}
			//how the fuck does this even happen? oh well.
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect2(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "',0,'" + GlobalVars.Custom_Hat1ID_Offline + "','" + GlobalVars.Custom_Hat2ID_Offline + "','" + GlobalVars.Custom_Hat3ID_Offline + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && !IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect2(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player',0,'" + GlobalVars.Custom_ColorHash + "'," + GlobalVars.Custom_PantsID + "," + GlobalVars.Custom_ShirtsID + "," + GlobalVars.Custom_TShirtsID + "," + GlobalVars.Custom_Hat1ID + "," + GlobalVars.Custom_Hat2ID + "," + GlobalVars.Custom_Hat3ID + "," + GlobalVars.Custom_Hat1Version + "," + GlobalVars.Custom_Hat2Version + "," + GlobalVars.Custom_Hat3Version + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player');" + quote;
			}
			//how the fuck does this even happen? oh well.
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'Player');" + quote;
			}
			
			if (GlobalVars.LocalPlayMode == true)
			{
				GeneratePlayerID();
			}
			try
			{
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void StartClientSolo()
		{
			string luafile = "rbxasset://scripts\\\\CSMPFunctions.lua";
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string quote = "\"";
			string args = "";
			if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true && IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'localhost'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "'," + GlobalVars.CharacterAppearanceID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true && IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'localhost'," + GlobalVars.RobloxPort + ",'Player'," + GlobalVars.CharacterAppearanceID + ");" + quote;
			}
			//how the fuck does this even happen? oh well.
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false && IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'localhost'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "'," + GlobalVars.CharacterAppearanceID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false && IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'localhost'," + GlobalVars.RobloxPort + ",'Player'," + GlobalVars.CharacterAppearanceID + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && !IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'localhost'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "',0,'" + GlobalVars.Custom_ColorHash + "'," + GlobalVars.Custom_PantsID + "," + GlobalVars.Custom_ShirtsID + "," + GlobalVars.Custom_TShirtsID + "," + GlobalVars.Custom_Hat1ID + "," + GlobalVars.Custom_Hat2ID + "," + GlobalVars.Custom_Hat3ID + "," + GlobalVars.Custom_Hat1Version + "," + GlobalVars.Custom_Hat2Version + "," + GlobalVars.Custom_Hat3Version + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && !IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'localhost'," + GlobalVars.RobloxPort + ",'Player',0,'" + GlobalVars.Custom_ColorHash + "'," + GlobalVars.Custom_PantsID + "," + GlobalVars.Custom_ShirtsID + "," + GlobalVars.Custom_TShirtsID + "," + GlobalVars.Custom_Hat1ID + "," + GlobalVars.Custom_Hat2ID + "," + GlobalVars.Custom_Hat3ID + "," + GlobalVars.Custom_Hat1Version + "," + GlobalVars.Custom_Hat2Version + "," + GlobalVars.Custom_Hat3Version + ");" + quote;
			}
			//how the fuck does this even happen? oh well.
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && !IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'localhost'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "',0,'" + GlobalVars.Custom_ColorHash + "'," + GlobalVars.Custom_PantsID + "," + GlobalVars.Custom_ShirtsID + "," + GlobalVars.Custom_TShirtsID + "," + GlobalVars.Custom_Hat1ID + "," + GlobalVars.Custom_Hat2ID + "," + GlobalVars.Custom_Hat3ID + "," + GlobalVars.Custom_Hat1Version + "," + GlobalVars.Custom_Hat2Version + "," + GlobalVars.Custom_Hat3Version + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'localhost'," + GlobalVars.RobloxPort + ",'Player',0,'" + GlobalVars.Custom_Hat1ID_Offline + "','" + GlobalVars.Custom_Hat2ID_Offline + "','" + GlobalVars.Custom_Hat3ID_Offline + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect2(" + GlobalVars.UserID + ",'localhost'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "',0,'" + GlobalVars.Custom_Hat1ID_Offline + "','" + GlobalVars.Custom_Hat2ID_Offline + "','" + GlobalVars.Custom_Hat3ID_Offline + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect2(" + GlobalVars.UserID + ",'localhost'," + GlobalVars.RobloxPort + ",'Player',0,'" + GlobalVars.Custom_Hat1ID_Offline + "','" + GlobalVars.Custom_Hat2ID_Offline + "','" + GlobalVars.Custom_Hat3ID_Offline + "');" + quote;
			}
			//how the fuck does this even happen? oh well.
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect2(0,'localhost'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "',0,'" + GlobalVars.Custom_Hat1ID_Offline + "','" + GlobalVars.Custom_Hat2ID_Offline + "','" + GlobalVars.Custom_Hat3ID_Offline + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && IsUsingCustomOutfits() && !IsInOfflineMode())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect2(0,'localhost''," + GlobalVars.RobloxPort + ",'Player',0,'" + GlobalVars.Custom_ColorHash + "'," + GlobalVars.Custom_PantsID + "," + GlobalVars.Custom_ShirtsID + "," + GlobalVars.Custom_TShirtsID + "," + GlobalVars.Custom_Hat1ID + "," + GlobalVars.Custom_Hat2ID + "," + GlobalVars.Custom_Hat3ID + "," + GlobalVars.Custom_Hat1Version + "," + GlobalVars.Custom_Hat2Version + "," + GlobalVars.Custom_Hat3Version + ");" + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'localhost'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true && !IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'localhost'," + GlobalVars.RobloxPort + ",'Player');" + quote;
			}
			//how the fuck does this even happen? oh well.
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'localhost'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false && !IsUsingCharacterOutfitIDs() && !IsUsingCustomOutfits())
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'localhost'," + GlobalVars.RobloxPort + ",'Player');" + quote;
			}
			
			if (GlobalVars.LocalPlayMode == true)
			{
				GeneratePlayerID();
			}
			try
			{
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
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
			
			if (GlobalVars.BodyColors == true)
			{
				args = quote + mapfile + "\" -script \"dofile('" + luafile + "'); _G.CSServer(" + GlobalVars.RobloxPort + ",true); " + quote;
			}
			else if (GlobalVars.BodyColors == false)
			{
				args = quote + mapfile + "\" -script \"dofile('" + luafile + "'); _G.CSServer(" + GlobalVars.RobloxPort + ",false);" + quote;
			}
			try
			{
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
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
			if (GlobalVars.BodyColors == true)
			{
				args = quote + mapfile + "\" -script \"dofile('" + luafile + "'); _G.CSServer(" + GlobalVars.RobloxPort + ",true); " + quote + " -no3d";
			}
			else if (GlobalVars.BodyColors == false)
			{
				args = quote + mapfile + "\" -script \"dofile('" + luafile + "'); _G.CSServer(" + GlobalVars.RobloxPort + ",false);" + quote + " -no3d";
			}
			try
			{
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void StartStudio()
		{
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string mapfile = GlobalVars.MapsDir + @"\\" + GlobalVars.Map;
			string quote = "\"";
			string args = "";
			if (GlobalVars.ModernClient == true)
			{
				args = quote + mapfile + "\" -script \"" + @"loadstring('\108\111\99\97\108\32\67\111\114\101\71\117\105\32\61\32\103\97\109\101\58\71\101\116\83\101\114\118\105\99\101\40\34\67\111\114\101\71\117\105\34\41\59\10\119\104\105\108\101\32\110\111\116\32\67\111\114\101\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\82\111\98\108\111\120\71\117\105\34\41\32\100\111\10\9\67\111\114\101\71\117\105\46\67\104\105\108\100\65\100\100\101\100\58\119\97\105\116\40\41\59\10\101\110\100\10\108\111\99\97\108\32\82\111\98\108\111\120\71\117\105\32\61\32\67\111\114\101\71\117\105\46\82\111\98\108\111\120\71\117\105\59\10\108\111\99\97\108\32\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\84\111\112\76\101\102\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\66\117\105\108\100\84\111\111\108\115\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\117\105\108\100\84\111\111\108\115\34\41\10\102\117\110\99\116\105\111\110\32\109\97\107\101\89\82\101\108\97\116\105\118\101\40\41\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\10\105\102\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\116\104\101\110\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\32\101\110\100\10\105\102\32\66\117\105\108\100\84\111\111\108\115\32\116\104\101\110\32\66\117\105\108\100\84\111\111\108\115\46\70\114\97\109\101\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\32\101\110\100\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\48\44\48\44\49\44\45\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\88\44\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\101\110\100\10\102\117\110\99\116\105\111\110\32\109\97\107\101\88\82\101\108\97\116\105\118\101\40\41\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\105\102\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\116\104\101\110\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\32\101\110\100\10\105\102\32\66\117\105\108\100\84\111\111\108\115\32\116\104\101\110\32\66\117\105\108\100\84\111\111\108\115\46\70\114\97\109\101\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\32\101\110\100\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\48\44\48\44\49\44\45\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\88\44\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\101\110\100\10\108\111\99\97\108\32\102\117\110\99\116\105\111\110\32\114\101\115\105\122\101\40\41\10\105\102\32\82\111\98\108\111\120\71\117\105\46\65\98\115\111\108\117\116\101\83\105\122\101\46\120\32\62\32\82\111\98\108\111\120\71\117\105\46\65\98\115\111\108\117\116\101\83\105\122\101\46\121\32\116\104\101\110\10\109\97\107\101\89\82\101\108\97\116\105\118\101\40\41\10\101\108\115\101\10\109\97\107\101\88\82\101\108\97\116\105\118\101\40\41\10\101\110\100\10\101\110\100\10\82\111\98\108\111\120\71\117\105\46\67\104\97\110\103\101\100\58\99\111\110\110\101\99\116\40\102\117\110\99\116\105\111\110\40\112\114\111\112\101\114\116\121\41\10\105\102\32\112\114\111\112\101\114\116\121\32\61\61\32\34\65\98\115\111\108\117\116\101\83\105\122\101\34\32\116\104\101\110\10\119\97\105\116\40\41\10\114\101\115\105\122\101\40\41\10\101\110\100\10\101\110\100\41\10\119\97\105\116\40\41\10\114\101\115\105\122\101\40\41\10')()";
			}
			else if (GlobalVars.ModernClient == false)
			{
				args = quote + mapfile + quote;
			}
			try
			{
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void PlaySolo(int timerset)
		{
			StartServerNo3D();
			if (Process.GetProcessesByName("RobloxApp").Length > 0)
			{
				System.Threading.Timer timer = null; 
    			timer = new System.Threading.Timer((obj) =>
                    	{
                        	StartClientSolo();
                        	timer.Dispose();
                    	}, 
                	null, timerset, System.Threading.Timeout.Infinite);
			}
		}
		
		void Button20Click(object sender, EventArgs e)
		{
			ServerInfo infopanel = new ServerInfo();
			infopanel.Show();
		}
	}
}
