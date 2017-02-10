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
			textBox1.Text = GlobalVars.Custom_ColorID;
			textBox2.Text = GlobalVars.Custom_ShirtsID.ToString();
			textBox3.Text = GlobalVars.Custom_PantsID.ToString();
			textBox4.Text = GlobalVars.Custom_TShirtsID.ToString();
			textBox5.Text = GlobalVars.Custom_Hat1ID.ToString();
			textBox6.Text = GlobalVars.Custom_Hat2ID.ToString();
			textBox7.Text = GlobalVars.Custom_Hat3ID.ToString();
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			GlobalVars.Custom_ColorID = textBox1.Text;
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
			if (int.TryParse(textBox7.Text, out parsedValue))
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
			if (int.TryParse(textBox3.Text, out parsedValue))
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
	}
}
