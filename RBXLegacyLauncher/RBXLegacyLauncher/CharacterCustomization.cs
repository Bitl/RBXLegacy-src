/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 2/5/2017
 * Time: 1:53 PM
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
	/// Description of CharacterCustomization.
	/// </summary>
	public partial class CharacterCustomization : Form
	{
		public CharacterCustomization()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CharacterCustomizationLoad(object sender, EventArgs e)
		{
			string hatdir = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\content\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		DirectoryInfo dinfo = new DirectoryInfo(hatdir);
				FileInfo[] Files = dinfo.GetFiles("*.rbxm");
				foreach( FileInfo file in Files )
				{
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
        		button1.Enabled = true;
        	}
        	else
        	{
        		listBox1.Items.Add("Offline character customization is not supported");
        		listBox1.Items.Add("on this client.");
        		listBox1.Enabled = false;
        		listBox2.Enabled = false;
        		listBox3.Enabled = false;
        		button1.Enabled = false;       		
        	}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//CharacterColors ccol = new CharacterColors();
			//ccol.Show();
			MessageBox.Show("Coming Soon.");			
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
