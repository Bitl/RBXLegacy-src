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
     		}
     		else
     		{
     			listBox1.Items.Clear();
     			listBox2.Items.Clear();
     		}
		}
		void Button1Click(object sender, EventArgs e)
		{
			string luafile = GlobalVars.ScriptsDir + @"\\CSMPFunctions.lua";
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string quote = "\"";
			string args = "";
			if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true)
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "',53640,'" + GlobalVars.PlayerName + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true)
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "',53640,'Player');" + quote;
			}
			//how the fuck does this even happen? oh well.
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false)
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'" + GlobalVars.IP + "',53640,'" + GlobalVars.PlayerName + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false)
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(0,'" + GlobalVars.IP + "',53640,'Player');" + quote;
			}
			if (GlobalVars.LocalPlayMode == true)
			{
				GlobalVars.LocalPlayNameSuffixNum += 1;
				GeneratePlayerID(true);
				GeneratePlayerName();
			}
			Process.Start(rbxexe, args);
			if (GlobalVars.LocalPlayMode == true)
			{
				WriteConfigValues();
			}
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			string luafile = GlobalVars.ScriptsDir + @"\\CSMPFunctions.lua";
			string mapfile = GlobalVars.MapsDir + @"\\" + GlobalVars.Map;
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string quote = "\"";
			string args = "";
			if (GlobalVars.BodyColors == true)
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSServer(53640,true); game:Load('" + mapfile + "');" + quote;
			}
			else if (GlobalVars.BodyColors == false)
			{
				args = "-script " + quote + "dofile('" + luafile + "'); _G.CSServer(53640,false); game:Load('" + mapfile + "');" + quote;
			}
			Process.Start(rbxexe, args);
			WriteConfigValues();
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			string textboxdir = "";
			textboxdir = GlobalVars.ScriptsDir;
			textboxdir = textboxdir.Replace(@"\\",@"\");
			MessageBox.Show("If you want to test out your place, you will have to save your place, then go to Tools->Execute Script in ROBLOX Studio, and then load 'Play Solo.lua' from '"+ textboxdir + "'. " + "To edit your place again, you must restart ROBLOX Studio and load your place again to edit it.","RBXLegacy Launcher - Launch ROBLOX Studio", MessageBoxButtons.OK, MessageBoxIcon.Information);
			string rbxexe = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\RobloxApp.exe";
			string luafile = GlobalVars.ScriptsDir + @"\\CSMPFunctions.lua";
			string quote = "\"";
			string args = "-script " + quote + "dofile('" + luafile + "');" + quote;
			Process.Start(rbxexe, args);
			WriteConfigValues();
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			if (!File.Exists("config.txt"))
			{
				WriteConfigValues();
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
    		string[] lines = File.ReadAllLines("version.txt"); //File is in System.IO
			string version = lines[0];
    		label11.Text = version;
    		ReadConfigValues();
		}
		
		void ReadConfigValues()
		{
			string line1, line2, line3, line4, line5;

			using(StreamReader reader = new StreamReader("config.txt")) 
			{
    			line1 = reader.ReadLine();
    			line2 = reader.ReadLine();
    			line3 = reader.ReadLine();
    			line4 = reader.ReadLine();
    			line5 = reader.ReadLine();
			}
			
			bool bline1 = Convert.ToBoolean(line1);
			GlobalVars.CloseOnLaunch = bline1;
			
			bool bline2 = Convert.ToBoolean(line2);
			GlobalVars.BodyColors = bline2;
			
			int iline3 = Convert.ToInt32(line3);
			GlobalVars.UserID = iline3;
			
			GlobalVars.PlayerName = line4;
			
			GlobalVars.SelectedClient = line5;
			
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
			
			if (iline3 == 0)
			{
				GeneratePlayerID(false);
			}
			else
			{
				label14.Text = Convert.ToString(iline3);
			}
			
			textBox2.Text = GlobalVars.PlayerName;
			
			label26.Text = GlobalVars.SelectedClient;
			label28.Text = GlobalVars.Map;
			ReadClientValues(GlobalVars.SelectedClient);
		}
		
		void WriteConfigValues()
		{
			string[] lines = { GlobalVars.CloseOnLaunch.ToString(), GlobalVars.BodyColors.ToString(), GlobalVars.UserID.ToString(), GlobalVars.PlayerName.ToString(), GlobalVars.SelectedClient.ToString() };
			File.WriteAllLines("config.txt", lines);
		}
		
		void ReadClientValues(string ClientName)
		{
			string clientpath = GlobalVars.ClientDir + @"\\" + ClientName + @"\\clientinfo.txt";
			
			if (!File.Exists(clientpath))
			{
				MessageBox.Show("No clientinfo.txt detected with the client you chose. The client cannot be loaded.","RBXLegacy Launcher - Error while loading client", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			GlobalVars.SupportsLocalPlay = bline3;
			
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
				label14.Enabled = true;
				button4.Enabled = true;
			}
			else if (GlobalVars.UsesID == false)
			{
				label14.Enabled = false;
				button4.Enabled = false;
				checkBox3.Enabled = false;
				checkBox3.Checked = false;
				GlobalVars.LocalPlayMode = false;
			}
			
			if (GlobalVars.SupportsLocalPlay == false)
			{
				checkBox3.Enabled = false;
				checkBox3.Checked = false;
				GlobalVars.LocalPlayMode = false;
			}
			
			label21.Text = GlobalVars.SelectedClientDesc;
			label26.Text = GlobalVars.SelectedClient;
			WriteConfigValues();
		}
		
		void GeneratePlayerID(bool bPlaySoloMode)
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
			label14.Text = Convert.ToString(GlobalVars.UserID);
			if (bPlaySoloMode == false)
			{
				WriteConfigValues();
			}
		}
		
		void GeneratePlayerName()
		{
			if (GlobalVars.LocalPlayNameSuffixNum > 0)
			{
				int oldsuffix = GlobalVars.LocalPlayNameSuffixNum - 1;
				char oldplayersuffix = Convert.ToChar(oldsuffix);
				string oldplayername = GlobalVars.PlayerName.TrimEnd(oldplayersuffix);
				string playersuffix = Convert.ToString(GlobalVars.LocalPlayNameSuffixNum);
				GlobalVars.PlayerName = oldplayername + playersuffix;
				textBox2.Text = GlobalVars.PlayerName;
			}
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			GlobalVars.IP = textBox1.Text;
			checkBox3.Enabled = false;
			checkBox3.Checked = false;
			GlobalVars.LocalPlayMode = false;
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
			GeneratePlayerID(false);
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			WriteConfigValues();
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
	}
}
