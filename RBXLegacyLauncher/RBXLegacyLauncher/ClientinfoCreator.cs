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
					string line1, line2, line3, line4;

					using(StreamReader reader = new StreamReader(ofd.FileName)) 
					{
    					line1 = reader.ReadLine();
    					line2 = reader.ReadLine();
    					line3 = reader.ReadLine();
    					line4 = reader.ReadLine();
					}
					
					Boolean bline1 = bool.Parse(line1);
					GlobalVars.ClientCreator_UsesPlayerName = bline1;
					
					Boolean bline2 = bool.Parse(line2);
					GlobalVars.ClientCreator_UsesID = bline2;
					
					Boolean bline3 = bool.Parse(line3);
					GlobalVars.ClientCreator_LoadsAssetsOnline = bline3;
					
					GlobalVars.ClientCreator_SelectedClientDesc = line4;
					
					checkBox1.Checked = GlobalVars.ClientCreator_UsesPlayerName;
					checkBox2.Checked = GlobalVars.ClientCreator_UsesID;
					checkBox5.Checked = GlobalVars.ClientCreator_LoadsAssetsOnline;
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
            			GlobalVars.ClientCreator_LoadsAssetsOnline.ToString(), 
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
			GlobalVars.ClientCreator_LoadsAssetsOnline = false;
			GlobalVars.ClientCreator_SelectedClientDesc = "";
			checkBox1.Checked = GlobalVars.ClientCreator_UsesPlayerName;
			checkBox2.Checked = GlobalVars.ClientCreator_UsesID;
			checkBox5.Checked = GlobalVars.ClientCreator_LoadsAssetsOnline;
			textBox1.Text = GlobalVars.ClientCreator_SelectedClientDesc;
		}
	}
}
