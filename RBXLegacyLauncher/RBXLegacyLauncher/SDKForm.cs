/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 6/23/2017
 * Time: 2:33 PM
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
	/// Description of SDKForm.
	/// </summary>
	public partial class SDKForm : Form
	{
		public SDKForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		// clientinfo
		
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
					string line1;
					string Decryptline1, Decryptline2, Decryptline3, Decryptline4, Decryptline5, Decryptline6, Decryptline7, Decryptline8;

					using(StreamReader reader = new StreamReader(ofd.FileName)) 
					{
    					line1 = reader.ReadLine();
					}
			
					if (!SecurityFuncs.IsBase64String(line1))
						return;
					
					string ConvertedLine = SecurityFuncs.Base64Decode(line1);
					string[] result = ConvertedLine.Split('|');
					Decryptline1 = SecurityFuncs.Base64Decode(result[0]);
    				Decryptline2 = SecurityFuncs.Base64Decode(result[1]);
    				Decryptline3 = SecurityFuncs.Base64Decode(result[2]);
    				Decryptline4 = SecurityFuncs.Base64Decode(result[3]);
    				Decryptline5 = SecurityFuncs.Base64Decode(result[4]);
    				Decryptline6 = SecurityFuncs.Base64Decode(result[5]);
    				Decryptline7 = SecurityFuncs.Base64Decode(result[6]);
    				Decryptline8 = SecurityFuncs.Base64Decode(result[7]);
					
					Boolean bline1 = Convert.ToBoolean(Decryptline1);
					GlobalVars.ClientCreator_UsesPlayerName = bline1;
					
					Boolean bline2 = Convert.ToBoolean(Decryptline2);
					GlobalVars.ClientCreator_UsesID = bline2;
					
					Boolean bline3 = Convert.ToBoolean(Decryptline3);
					GlobalVars.ClientCreator_LoadsAssetsOnline = bline3;
					
					Boolean bline4 = Convert.ToBoolean(Decryptline4);
					GlobalVars.ClientCreator_LegacyMode = bline4;
					
					Boolean bline5 = Convert.ToBoolean(Decryptline5);
					GlobalVars.ClientCreator_HasRocky = bline5;
					
					GlobalVars.ClientCreator_SelectedClientMD5 = Decryptline6;
					
					int iline7 = Convert.ToInt32(Decryptline7);
					GlobalVars.ClientCreator_SelectedClientVersion = iline7;
					
					GlobalVars.ClientCreator_SelectedClientDesc = Decryptline8;
					
					checkBox1.Checked = GlobalVars.ClientCreator_UsesPlayerName;
					checkBox2.Checked = GlobalVars.ClientCreator_UsesID;
					checkBox5.Checked = GlobalVars.ClientCreator_LoadsAssetsOnline;
					checkBox3.Checked = GlobalVars.ClientCreator_LegacyMode;
					checkBox4.Checked = GlobalVars.ClientCreator_HasRocky;
					textBox2.Text = GlobalVars.ClientCreator_SelectedClientMD5.ToUpper();
					textBox1.Text = GlobalVars.ClientCreator_SelectedClientDesc;
					textBox3.Text = GlobalVars.ClientCreator_SelectedClientVersion.ToString();
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
            			SecurityFuncs.Base64Encode(GlobalVars.ClientCreator_UsesPlayerName.ToString()),
            			SecurityFuncs.Base64Encode(GlobalVars.ClientCreator_UsesID.ToString()),
            			SecurityFuncs.Base64Encode(GlobalVars.ClientCreator_LoadsAssetsOnline.ToString()),
            			SecurityFuncs.Base64Encode(GlobalVars.ClientCreator_LegacyMode.ToString()),
            			SecurityFuncs.Base64Encode(GlobalVars.ClientCreator_HasRocky.ToString()),
            			SecurityFuncs.Base64Encode(GlobalVars.ClientCreator_SelectedClientMD5.ToString()),
            			SecurityFuncs.Base64Encode(GlobalVars.ClientCreator_SelectedClientVersion.ToString()),
            			SecurityFuncs.Base64Encode(GlobalVars.ClientCreator_SelectedClientDesc.ToString())
            		};
            		File.WriteAllText(sfd.FileName, SecurityFuncs.Base64Encode(string.Join("|",lines)));
            	}     
			}			
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
			GlobalVars.ClientCreator_LegacyMode = false;
			GlobalVars.ClientCreator_SelectedClientDesc = "";
			GlobalVars.ClientCreator_SelectedClientMD5 = "";
			GlobalVars.ClientCreator_SelectedClientVersion = 0;
			GlobalVars.ClientCreator_HasRocky = false;
			checkBox1.Checked = GlobalVars.ClientCreator_UsesPlayerName;
			checkBox2.Checked = GlobalVars.ClientCreator_UsesID;
			checkBox5.Checked = GlobalVars.ClientCreator_LoadsAssetsOnline;
			checkBox3.Checked = GlobalVars.ClientCreator_LegacyMode;
			checkBox4.Checked = GlobalVars.ClientCreator_HasRocky;
			textBox2.Text = GlobalVars.ClientCreator_SelectedClientMD5.ToUpper();
			textBox1.Text = GlobalVars.ClientCreator_SelectedClientDesc;
			textBox3.Text = GlobalVars.ClientCreator_SelectedClientVersion.ToString();
		}
		
		void CheckBox3CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked == true)
			{
				GlobalVars.ClientCreator_LegacyMode = true;
			}
			else if (checkBox3.Checked == false)
			{
				GlobalVars.ClientCreator_LegacyMode = false;
			}
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			textBox2.Text = textBox2.Text.ToUpper();
			GlobalVars.ClientCreator_SelectedClientMD5 = textBox2.Text.ToUpper();
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox3.Text, out parsedValue))
			{
				if (textBox3.Text.Equals(""))
				{
					GlobalVars.ClientCreator_SelectedClientVersion = 0;
				}
				else
				{
					GlobalVars.ClientCreator_SelectedClientVersion = Convert.ToInt32(textBox3.Text);
				}
			}
			else
			{
				GlobalVars.ClientCreator_SelectedClientVersion = 0;
			}
		}
		
		void CheckBox4CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox4.Checked == true)
			{
				GlobalVars.ClientCreator_HasRocky = true;
			}
			else if (checkBox4.Checked == false)
			{
				GlobalVars.ClientCreator_HasRocky = false;
			}
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			DocForm doc = new DocForm();
			doc.Show();
		}
		
		// info
		
		void Button6Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
        	{
				ofd.Filter = "Text files (*.txt)|*.txt";
            	ofd.FilterIndex = 2;
            	ofd.FileName = "info.txt";
            	ofd.Title = "Load info.txt";
            	if (ofd.ShowDialog() == DialogResult.OK)
            	{
					string line1;
					string Decryptline1, Decryptline2, Decryptline3, Decryptline4;

					using(StreamReader reader = new StreamReader(ofd.FileName)) 
					{
    					line1 = reader.ReadLine();
					}
			
					if (!SecurityFuncs.IsBase64String(line1))
						return;
					
					string ConvertedLine = SecurityFuncs.Base64Decode(line1);
					string[] result = ConvertedLine.Split('|');
					Decryptline1 = SecurityFuncs.Base64Decode(result[0]);
    				Decryptline2 = SecurityFuncs.Base64Decode(result[1]);
    				Decryptline3 = SecurityFuncs.Base64Decode(result[2]);
    				Decryptline4 = SecurityFuncs.Base64Decode(result[3]);
					
					GlobalVars.InfoEditor_Version = Decryptline1;
					GlobalVars.InfoEditor_DefaultClient = Decryptline2;
					GlobalVars.InfoEditor_ScriptPath = Decryptline3;
					GlobalVars.InfoEditor_ScriptMD5 = Decryptline4;
					
					textBox7.Text = GlobalVars.InfoEditor_Version;
					textBox6.Text = GlobalVars.InfoEditor_DefaultClient;
					textBox5.Text = GlobalVars.InfoEditor_ScriptPath;
					textBox4.Text = GlobalVars.InfoEditor_ScriptMD5.ToUpper();
            	}
			}
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			using (var sfd = new SaveFileDialog())
        	{
            	sfd.Filter = "Text files (*.txt)|*.txt";
            	sfd.FilterIndex = 2;
            	sfd.FileName = "info.txt";
            	sfd.Title = "Save info.txt";

            	if (sfd.ShowDialog() == DialogResult.OK)
            	{
            		string[] lines = { 
            			SecurityFuncs.Base64Encode(GlobalVars.InfoEditor_Version.ToString()),
            			SecurityFuncs.Base64Encode(GlobalVars.InfoEditor_DefaultClient.ToString()),
            			SecurityFuncs.Base64Encode(GlobalVars.InfoEditor_ScriptPath.ToString()),
            			SecurityFuncs.Base64Encode(GlobalVars.InfoEditor_ScriptMD5.ToString())
            		};
            		File.WriteAllText(sfd.FileName, SecurityFuncs.Base64Encode(string.Join("|",lines)));
            	}     
			}			
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			GlobalVars.InfoEditor_Version = "";
			GlobalVars.InfoEditor_DefaultClient = "";
			GlobalVars.InfoEditor_ScriptPath = "";
			GlobalVars.InfoEditor_ScriptMD5 = "";
			textBox7.Text = GlobalVars.InfoEditor_Version;
			textBox6.Text = GlobalVars.InfoEditor_DefaultClient;
			textBox5.Text = GlobalVars.InfoEditor_ScriptPath;
			textBox4.Text = GlobalVars.InfoEditor_ScriptMD5.ToUpper();
		}
		
		void TextBox7TextChanged(object sender, EventArgs e)
		{
			GlobalVars.InfoEditor_Version = textBox7.Text;
		}
		
		void TextBox6TextChanged(object sender, EventArgs e)
		{
			GlobalVars.InfoEditor_DefaultClient = textBox6.Text;			
		}
		
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			GlobalVars.InfoEditor_ScriptPath = textBox5.Text;
		}
		
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			textBox4.Text = textBox4.Text.ToUpper();
			GlobalVars.InfoEditor_ScriptMD5 = textBox4.Text.ToUpper();
		}
	}
}
