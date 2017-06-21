/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 6/17/2017
 * Time: 8:41 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RBXLegacyLauncher
{
	/// <summary>
	/// Description of CharacterCustomization_ClothingMenu.
	/// </summary>
	public partial class CharacterCustomization_ClothingMenu : Form
	{
		public CharacterCustomization_ClothingMenu()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
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
		
		void CharacterCustomization_ClothingMenuLoad(object sender, EventArgs e)
		{
			textBox1.Text = GlobalVars.Custom_TShirt.ToString();
			textBox2.Text = GlobalVars.Custom_Shirt.ToString();
			textBox3.Text = GlobalVars.Custom_Pants.ToString();
			textBox4.Text = GlobalVars.Custom_Face.ToString();
		}
	}
}
