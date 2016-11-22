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
		void Button2Click(object sender, EventArgs e)
		{
			string luafile = GlobalVars.ClientDir + @"\\game.lua";
			string rbxexe = GlobalVars.ClientDir + @"\\RobloxApp.exe";
			string mapfile = GlobalVars.ClientDir + @"\\maps\\" + GlobalVars.Map;
			string settingsluafile = GlobalVars.ClientDir + @"\\game.lua";
			string quote = "\"";
			string args = "";
			args = "-script " + quote + "dofile('" + settingsluafile + "'); game:Load('" + mapfile + "'); wait(0.001); dofile('" + luafile + "'); _G.Play('" + GlobalVars.PlayerName + "');" + quote;
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
			GlobalVars.ClientDir = Path.Combine(Environment.CurrentDirectory, @"client");
			GlobalVars.ClientDir = GlobalVars.ClientDir.Replace(@"\",@"\\");
    		GlobalVars.Map = "Baseplate.rbxl";
    		string mapdir = GlobalVars.ClientDir + @"\\maps\\";
			DirectoryInfo dinfo = new DirectoryInfo(mapdir);
			FileInfo[] Files = dinfo.GetFiles("*.rbxl");
			foreach( FileInfo file in Files )
			{
   				listBox1.Items.Add(file.Name);
			}
			listBox1.SelectedItem = GlobalVars.Map;
    		ReadConfigValues();
		}
		
		void ReadConfigValues()
		{
			string line1, line2;

			using(StreamReader reader = new StreamReader("config.txt")) 
			{
    			line1 = reader.ReadLine();
    			line2 = reader.ReadLine();
			}
			
			bool bline1 = Convert.ToBoolean(line1);
			GlobalVars.CloseOnLaunch = bline1;
			
			GlobalVars.PlayerName = line2;
			
			if (GlobalVars.CloseOnLaunch == true)
			{
				checkBox1.Checked = true;
			}
			else if (GlobalVars.CloseOnLaunch == false)
			{
				checkBox1.Checked = false;
			}
			
			textBox2.Text = GlobalVars.PlayerName;
		}
		
		void WriteConfigValues()
		{
			string[] lines = { GlobalVars.CloseOnLaunch.ToString(), GlobalVars.PlayerName.ToString() };
			File.WriteAllLines("config.txt", lines);
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalVars.Map = listBox1.SelectedItem.ToString();
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
		
		void Button5Click(object sender, EventArgs e)
		{
			WriteConfigValues();
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			GlobalVars.PlayerName = textBox2.Text;
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			string rbxexe = GlobalVars.ClientDir + @"\\RobloxApp.exe";
			Process.Start(rbxexe);
			WriteConfigValues();
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}		
		}
	}
}
