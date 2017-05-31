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
        		Image icon1 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat1ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox1.Image = icon1;
        		Image icon2 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat2ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox2.Image = icon2;
        		Image icon3 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat3ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox3.Image = icon3;
        	}
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			string hatdir = Environment.CurrentDirectory + @"\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		GlobalVars.Custom_Hat1ID_Offline = listBox1.SelectedItem.ToString();
        		Image icon1 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat1ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox1.Image = icon1;
        	}
		}
		
		void ListBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			string hatdir = Environment.CurrentDirectory + @"\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		GlobalVars.Custom_Hat2ID_Offline = listBox2.SelectedItem.ToString();
        		Image icon2 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat2ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox2.Image = icon2;
        	}
		}
		
		void ListBox3SelectedIndexChanged(object sender, EventArgs e)
		{
			string hatdir = Environment.CurrentDirectory + @"\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		GlobalVars.Custom_Hat3ID_Offline = listBox3.SelectedItem.ToString();
        		Image icon3 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat3ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox3.Image = icon3;
        	}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			string hatdir = Environment.CurrentDirectory + @"\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		Random random = new Random();
				int randomHat1  = random.Next(listBox1.Items.Count);
				listBox1.SelectedItem = listBox1.Items[randomHat1];
        		GlobalVars.Custom_Hat1ID_Offline = listBox1.SelectedItem.ToString();
        		Image icon1 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat1ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox1.Image = icon1;
        		int randomHat2  = random.Next(listBox2.Items.Count);
				listBox2.SelectedItem = listBox1.Items[randomHat2];
        		GlobalVars.Custom_Hat2ID_Offline = listBox2.SelectedItem.ToString();
        		Image icon2 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat2ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox2.Image = icon2;
        		int randomHat3  = random.Next(listBox3.Items.Count);
				listBox3.SelectedItem = listBox1.Items[randomHat3];
        		GlobalVars.Custom_Hat3ID_Offline = listBox3.SelectedItem.ToString();
        		Image icon3 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat3ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox3.Image = icon3;
        	}			
		}
	}
}
