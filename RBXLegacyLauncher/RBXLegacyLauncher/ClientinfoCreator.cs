/*
 * Created by SharpDevelop.
 * User: BITL-Gaming
 * Date: 11/28/2016
 * Time: 7:55 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace RBXLegacyLauncher
{
	/// <summary>
	/// Description of ClientinfoCreator.
	/// </summary>
	public partial class ClientinfoEditor : Form
	{
		public ClientinfoEditor()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				GlobalVars.ClientCreator_UsesPlayerName = true;
			}
			else if (checkBox1.Checked == false)
			{
				GlobalVars.ClientCreator_UsesPlayerName = false;
			}
		}
		
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked == true)
			{
				GlobalVars.ClientCreator_UsesID = true;
			}
			else if (checkBox2.Checked == false)
			{
				GlobalVars.ClientCreator_UsesID = false;
			}
		}
		
		void CheckBox3CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked == true)
			{
				GlobalVars.ClientCreator_SupportsLocalPlay = true;
			}
			else if (checkBox3.Checked == false)
			{
				GlobalVars.ClientCreator_SupportsLocalPlay = false;
			}
		}
		
		void CheckBox4CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox4.Checked == true)
			{
				GlobalVars.ClientCreator_SupportsAppearanceID = true;
			}
			else if (checkBox4.Checked == false)
			{
				GlobalVars.ClientCreator_SupportsAppearanceID = false;
			}
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			GlobalVars.ClientCreator_SelectedClientDesc = textBox1.Text;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
        	{
				ofd.Filter = "Text files (*.txt)|*.txt";
            	ofd.FilterIndex = 2;
            	ofd.FileName = "clientinfo.txt";
            	ofd.Title = "Load clientinfo.txt";
            	if (ofd.ShowDialog() == DialogResult.OK)
            	{
					string line1, line2, line3, line4, line5, line6, line7, line8;

					using(StreamReader reader = new StreamReader(ofd.FileName)) 
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
					
					Boolean bline1 = bool.Parse(line1);
					GlobalVars.ClientCreator_UsesPlayerName = bline1;
					
					Boolean bline2 = bool.Parse(line2);
					GlobalVars.ClientCreator_UsesID = bline2;
					
					Boolean bline3 = bool.Parse(line3);
					GlobalVars.ClientCreator_SupportsLocalPlay = bline3;
					
					Boolean bline4 = bool.Parse(line4);
					GlobalVars.ClientCreator_SupportsAppearanceID = bline4;
					
					Boolean bline5 = bool.Parse(line5);
					GlobalVars.ClientCreator_LoadsAssetsOnline = bline5;
					
					Boolean bline6 = bool.Parse(line6);
					GlobalVars.ClientCreator_ModernClient = bline6;
						
					Boolean bline7 = bool.Parse(line7);
					GlobalVars.ClientCreator_SupportsCharacterCustomization = bline7;
					
					GlobalVars.ClientCreator_SelectedClientDesc = line8;
					
					checkBox1.Checked = GlobalVars.ClientCreator_UsesPlayerName;
					checkBox2.Checked = GlobalVars.ClientCreator_UsesID;
					checkBox3.Checked = GlobalVars.ClientCreator_SupportsLocalPlay;
					checkBox4.Checked = GlobalVars.ClientCreator_SupportsAppearanceID;
					checkBox5.Checked = GlobalVars.ClientCreator_LoadsAssetsOnline;
					checkBox6.Checked = GlobalVars.ClientCreator_ModernClient;
					checkBox7.Checked = GlobalVars.ClientCreator_SupportsCharacterCustomization;
					textBox1.Text = GlobalVars.ClientCreator_SelectedClientDesc;
            	}
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			using (var sfd = new SaveFileDialog())
        	{
            	sfd.Filter = "Text files (*.txt)|*.txt";
            	sfd.FilterIndex = 2;
            	sfd.FileName = "clientinfo.txt";
            	sfd.Title = "Save clientinfo.txt";

            	if (sfd.ShowDialog() == DialogResult.OK)
            	{
            		string[] lines = { 
            			GlobalVars.ClientCreator_UsesPlayerName.ToString(), 
            			GlobalVars.ClientCreator_UsesID.ToString(), 
            			GlobalVars.ClientCreator_SupportsLocalPlay.ToString(), 
            			GlobalVars.ClientCreator_SupportsAppearanceID.ToString(), 
            			GlobalVars.ClientCreator_LoadsAssetsOnline.ToString(), 
            			GlobalVars.ClientCreator_ModernClient.ToString(), 
            			GlobalVars.ClientCreator_SupportsCharacterCustomization.ToString(),
            			GlobalVars.ClientCreator_SelectedClientDesc.ToString() 
            		};
					File.WriteAllLines(sfd.FileName, lines);
            	}     
			}			
		}
		
		void ClientinfoCreatorLoad(object sender, EventArgs e)
		{
			
		}
		
		void CheckBox5CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox5.Checked == true)
			{
				GlobalVars.ClientCreator_LoadsAssetsOnline = true;
			}
			else if (checkBox5.Checked == false)
			{
				GlobalVars.ClientCreator_LoadsAssetsOnline = false;
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			GlobalVars.ClientCreator_UsesPlayerName = false;
			GlobalVars.ClientCreator_UsesID = false;
			GlobalVars.ClientCreator_SupportsLocalPlay = false;
			GlobalVars.ClientCreator_SupportsAppearanceID = false;
			GlobalVars.ClientCreator_LoadsAssetsOnline = false;
			GlobalVars.ClientCreator_ModernClient = false;
			GlobalVars.ClientCreator_SupportsCharacterCustomization = false;
			GlobalVars.ClientCreator_SelectedClientDesc = "";
			checkBox1.Checked = GlobalVars.ClientCreator_UsesPlayerName;
			checkBox2.Checked = GlobalVars.ClientCreator_UsesID;
			checkBox3.Checked = GlobalVars.ClientCreator_SupportsLocalPlay;
			checkBox4.Checked = GlobalVars.ClientCreator_SupportsAppearanceID;
			checkBox5.Checked = GlobalVars.ClientCreator_LoadsAssetsOnline;
			checkBox6.Checked = GlobalVars.ClientCreator_ModernClient;
			checkBox7.Checked = GlobalVars.ClientCreator_SupportsCharacterCustomization;
			textBox1.Text = GlobalVars.ClientCreator_SelectedClientDesc;
		}
		
		void CheckBox6CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox6.Checked == true)
			{
				GlobalVars.ClientCreator_ModernClient = true;
			}
			else if (checkBox6.Checked == false)
			{
				GlobalVars.ClientCreator_ModernClient = false;
			}	
		}
		
		void CheckBox7CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox7.Checked == true)
			{
				GlobalVars.ClientCreator_SupportsCharacterCustomization = true;
			}
			else if (checkBox7.Checked == false)
			{
				GlobalVars.ClientCreator_SupportsCharacterCustomization = false;
			}			
		}
	}
}
