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
	public partial class InfoEditor : Form
	{
		public InfoEditor()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button2Click(object sender, EventArgs e)
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
					
					textBox1.Text = GlobalVars.InfoEditor_Version;
					textBox2.Text = GlobalVars.InfoEditor_DefaultClient;
					textBox3.Text = GlobalVars.InfoEditor_ScriptPath;
					textBox4.Text = GlobalVars.InfoEditor_ScriptMD5.ToUpper();
            	}
			}
		}
		
		void Button1Click(object sender, EventArgs e)
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
		
		void ClientinfoCreatorLoad(object sender, EventArgs e)
		{
			
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			GlobalVars.InfoEditor_Version = "";
			GlobalVars.InfoEditor_DefaultClient = "";
			GlobalVars.InfoEditor_ScriptPath = "";
			GlobalVars.InfoEditor_ScriptMD5 = "";
			textBox1.Text = GlobalVars.InfoEditor_Version;
			textBox2.Text = GlobalVars.InfoEditor_DefaultClient;
			textBox3.Text = GlobalVars.InfoEditor_ScriptPath;
			textBox4.Text = GlobalVars.InfoEditor_ScriptMD5.ToUpper();
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			GlobalVars.InfoEditor_Version = textBox1.Text;
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			GlobalVars.InfoEditor_DefaultClient = textBox2.Text;			
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			GlobalVars.InfoEditor_ScriptPath = textBox3.Text;
		}
		
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			textBox4.Text = textBox4.Text.ToUpper();
			GlobalVars.InfoEditor_ScriptMD5 = textBox4.Text.ToUpper();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			DocForm doc = new DocForm();
			doc.Show();
		}
	}
}
