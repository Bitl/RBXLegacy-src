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
			textBox1.Text = GlobalVars.Custom_ColorHash;
			textBox2.Text = GlobalVars.Custom_ShirtsID.ToString();
			textBox3.Text = GlobalVars.Custom_PantsID.ToString();
			textBox4.Text = GlobalVars.Custom_TShirtsID.ToString();
			textBox5.Text = GlobalVars.Custom_Hat1ID.ToString();
			textBox6.Text = GlobalVars.Custom_Hat2ID.ToString();
			textBox7.Text = GlobalVars.Custom_Hat3ID.ToString();
			textBox8.Text = GlobalVars.Custom_Hat1Version.ToString();
			textBox9.Text = GlobalVars.Custom_Hat2Version.ToString();
			textBox10.Text = GlobalVars.Custom_Hat3Version.ToString();
			
			if (GlobalVars.CustomMode == 0)
			{
				tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
			}
			else if (GlobalVars.CustomMode == 1)
			{
				tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
			}
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			GlobalVars.Custom_ColorHash = textBox1.Text;
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox2.Text, out parsedValue))
			{
				if (textBox2.Text == "")
				{
					GlobalVars.Custom_ShirtsID = 0;
				}
				else
				{
					GlobalVars.Custom_ShirtsID = Convert.ToInt32(textBox2.Text);
				}
			}
			else
			{
				GlobalVars.Custom_ShirtsID = 0;
			}
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox3.Text, out parsedValue))
			{
				if (textBox3.Text == "")
				{
					GlobalVars.Custom_PantsID = 0;
				}
				else
				{
					GlobalVars.Custom_PantsID = Convert.ToInt32(textBox3.Text);
				}
			}
			else
			{
				GlobalVars.Custom_PantsID = 0;
			}
		}
		
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox4.Text, out parsedValue))
			{
				if (textBox4.Text == "")
				{
					GlobalVars.Custom_TShirtsID = 0;
				}
				else
				{
					GlobalVars.Custom_TShirtsID = Convert.ToInt32(textBox4.Text);
				}
			}
			else
			{
				GlobalVars.Custom_TShirtsID = 0;
			}
		}
		
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox5.Text, out parsedValue))
			{
				if (textBox5.Text == "")
				{
					GlobalVars.Custom_Hat1ID = 0;
				}
				else
				{
					GlobalVars.Custom_Hat1ID = Convert.ToInt32(textBox5.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Hat1ID = 0;
			}
		}
		
		void TextBox6TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox6.Text, out parsedValue))
			{
				if (textBox6.Text == "")
				{
					GlobalVars.Custom_Hat2ID = 0;
				}
				else
				{
					GlobalVars.Custom_Hat2ID = Convert.ToInt32(textBox6.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Hat2ID = 0;
			}
		}
		
		void TextBox7TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox7.Text, out parsedValue))
			{
				if (textBox7.Text == "")
				{
					GlobalVars.Custom_Hat3ID = 0;
				}
				else
				{
					GlobalVars.Custom_Hat3ID = Convert.ToInt32(textBox7.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Hat3ID = 0;
			}
		}
		
		void TextBox8TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox8.Text, out parsedValue))
			{
				if (textBox8.Text == "")
				{
					GlobalVars.Custom_Hat1Version = 1;
				}
				else
				{
					GlobalVars.Custom_Hat1Version = Convert.ToInt32(textBox8.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Hat1Version = 1;
			}
		}
		
		void TextBox9TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox9.Text, out parsedValue))
			{
				if (textBox9.Text == "")
				{
					GlobalVars.Custom_Hat2Version = 1;
				}
				else
				{
					GlobalVars.Custom_Hat2Version = Convert.ToInt32(textBox9.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Hat2Version = 1;
			}
		}
		
		void TextBox10TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox10.Text, out parsedValue))
			{
				if (textBox10.Text == "")
				{
					GlobalVars.Custom_Hat3Version = 1;
				}
				else
				{
					GlobalVars.Custom_Hat3Version = Convert.ToInt32(textBox10.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Hat3Version = 1;
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			CharacterColors ccol = new CharacterColors();
			ccol.Show();	
		}
		
		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
     		if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])//your specific tabname
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
					GlobalVars.CustomMode = 1;
        		}
        		else
        		{
        			GlobalVars.CustomMode = 0;
        			listBox1.Items.Add("Offline character customization is not supported");
        			listBox1.Items.Add("on this client.");
        			button1.Enabled = false;       		
        		}
     		}
     		else
     		{
     			GlobalVars.CustomMode = 0;
     			listBox1.Items.Clear();
     			listBox2.Items.Clear();
     			listBox3.Items.Clear();
     		}
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			string hatdir = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\content\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		GlobalVars.Custom_Hat1ID_Offline = listBox1.SelectedItem.ToString();;
        	}
		}
		
		void ListBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			string hatdir = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\content\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		GlobalVars.Custom_Hat2ID_Offline = listBox2.SelectedItem.ToString();;
        	}
		}
		
		void ListBox3SelectedIndexChanged(object sender, EventArgs e)
		{
			string hatdir = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\content\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		GlobalVars.Custom_Hat3ID_Offline = listBox3.SelectedItem.ToString();;
        	}
		}
	}
}
