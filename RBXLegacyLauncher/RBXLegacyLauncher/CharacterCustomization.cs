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
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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
			textBox1.Text = GlobalVars.Custom_TShirt.ToString();
			textBox2.Text = GlobalVars.Custom_Shirt.ToString();
			textBox3.Text = GlobalVars.Custom_Pants.ToString();
			textBox4.Text = GlobalVars.Custom_Face.ToString();
			if (GlobalVars.Custom_IconType.Equals("BC"))
			{
				radioButton1.Checked = true;
			}
			else if (GlobalVars.Custom_IconType.Equals("TBC"))
			{
				radioButton2.Checked = true;
			}
			else if (GlobalVars.Custom_IconType.Equals("OBC"))
			{
				radioButton3.Checked = true;
			}
			else if (GlobalVars.Custom_IconType.Equals("NBC"))
			{
				radioButton4.Checked = true;
			}
			string hatdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		button2.Enabled = true;
        	}
        	else
        	{
        		button2.Enabled = false;
        	}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			CharacterColors ccol = new CharacterColors();
			ccol.Show();			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			CharacterCustomization_HatMenu chats = new CharacterCustomization_HatMenu();
			chats.Show();
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox1.Text, out parsedValue))
			{
				if (textBox1.Text.Equals(""))
				{
					GlobalVars.Custom_TShirt = 0;
				}
				else
				{
					GlobalVars.Custom_TShirt = Convert.ToInt32(textBox1.Text);
				}
			}
			else
			{
				GlobalVars.Custom_TShirt = 0;
			}
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox2.Text, out parsedValue))
			{
				if (textBox2.Text.Equals(""))
				{
					GlobalVars.Custom_Shirt = 0;
				}
				else
				{
					GlobalVars.Custom_Shirt = Convert.ToInt32(textBox2.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Shirt = 0;
			}
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox3.Text, out parsedValue))
			{
				if (textBox3.Text.Equals(""))
				{
					GlobalVars.Custom_Pants = 0;
				}
				else
				{
					GlobalVars.Custom_Pants = Convert.ToInt32(textBox3.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Pants = 0;
			}
		}
		
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox4.Text, out parsedValue))
			{
				if (textBox4.Text.Equals(""))
				{
					GlobalVars.Custom_Face = 0;
				}
				else
				{
					GlobalVars.Custom_Face = Convert.ToInt32(textBox4.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Face = 0;
			}
		}
		
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.Custom_IconType = "BC";
		}
		
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.Custom_IconType = "TBC";
		}
		
		void RadioButton3CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.Custom_IconType = "OBC";
		}
		
		void RadioButton4CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.Custom_IconType = "NBC";
		}
	}
}
