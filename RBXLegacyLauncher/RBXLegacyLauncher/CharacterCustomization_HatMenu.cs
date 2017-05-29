/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 5/29/2017
 * Time: 8:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace RBXLegacyLauncher
{
	/// <summary>
	/// Description of CharacterCustomization_HatMenu.
	/// </summary>
	public partial class CharacterCustomization_HatMenu : Form
	{
		public CharacterCustomization_HatMenu()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CharacterCustomization_HatMenuLoad(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			listBox2.Items.Clear();
			listBox3.Items.Clear();
			string hatdir = Environment.CurrentDirectory + @"\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		DirectoryInfo dinfo = new DirectoryInfo(hatdir);
				FileInfo[] Files = dinfo.GetFiles("*.rbxm");
				foreach( FileInfo file in Files )
				{
					if (file.Name.Equals(String.Empty))
					{
   						continue;
					}
					
					if (file.Name.Equals("TeapotTurret.rbxm") && GlobalVars.AdminMode != true)
					{
   						continue;
					}
					
					listBox1.Items.Add(file.Name);
   					listBox2.Items.Add(file.Name);
   					listBox3.Items.Add(file.Name);
				}
				listBox1.SelectedItem = GlobalVars.Custom_Hat1ID_Offline;
				listBox2.SelectedItem = GlobalVars.Custom_Hat2ID_Offline;
				listBox3.SelectedItem = GlobalVars.Custom_Hat3ID_Offline;
				listBox1.Enabled = true;
        		listBox2.Enabled = true;
        		listBox3.Enabled = true;
        	}
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
        	GlobalVars.Custom_Hat1ID_Offline = listBox1.SelectedItem.ToString();
		}
		
		void ListBox2SelectedIndexChanged(object sender, EventArgs e)
		{
        	GlobalVars.Custom_Hat2ID_Offline = listBox2.SelectedItem.ToString();
		}
		
		void ListBox3SelectedIndexChanged(object sender, EventArgs e)
		{
        	GlobalVars.Custom_Hat3ID_Offline = listBox3.SelectedItem.ToString();
		}
	}
}
