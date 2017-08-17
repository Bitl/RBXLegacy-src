using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace RBXLegacyLauncher
{
	public partial class ServerPrefs : Form
	{
		public ServerPrefs()
		{
			InitializeComponent();
		}
		
		void ServerPrefsLoad(object sender, EventArgs e)
		{
        	textBox1.AppendText("Client: " + GlobalVars.SelectedClient);
        	textBox1.AppendText(Environment.NewLine);
        	textBox1.AppendText("IP: " + GetExternalIPAddress());
        	textBox1.AppendText(Environment.NewLine);
        	textBox1.AppendText("Port: " + GlobalVars.RobloxPort.ToString());
        	textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText("Map: " + GlobalVars.Map);
        	textBox1.AppendText(Environment.NewLine);
        	textBox1.AppendText("Players: " + GlobalVars.PlayerLimit);
        	textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText("Version: RBXLegacy " + GlobalVars.Version);
			textBox1.AppendText(Environment.NewLine);
			string[] lines = { 
				SecurityFuncs.Base64Encode(GetExternalIPAddress()),
				SecurityFuncs.Base64Encode(GlobalVars.RobloxPort.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.SelectedClient)
			};
			string URI = "RBXLegacy://" + SecurityFuncs.Base64Encode(string.Join("|",lines));
			textBox1.AppendText("Online URI Link:");
			textBox1.AppendText(URI);
			textBox1.AppendText(Environment.NewLine);
			string[] lines2 = { 
				SecurityFuncs.Base64Encode("localhost"),
				SecurityFuncs.Base64Encode(GlobalVars.RobloxPort.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.SelectedClient)
			};
			string URI2 = "RBXLegacy://" + SecurityFuncs.Base64Encode(string.Join("|",lines2));
			textBox1.AppendText("Local URI Link:");
			textBox1.AppendText(URI2);			
		}
		
		string GetExternalIPAddress()
		{
    		string ipAddress;
			using (WebClient wc = new WebClient())
			{
				try
  				{
    				ipAddress = wc.DownloadString("http://ipv4.icanhazip.com");
  				}
				catch (Exception)
  				{
    				ipAddress = "localhost" + Environment.NewLine;
  				}
			}

    		return ipAddress;
		}
		
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			checkBox1.Enabled = false;
			checkBox2.Enabled = false;
			checkBox3.Enabled = false;
			checkBox4.Enabled = false;
			checkBox5.Enabled = false;
			checkBox6.Enabled = false;
			checkBox7.Enabled = false;
			checkBox8.Enabled = false;
			checkBox9.Enabled = false;
		}
		
		void RadioButton3CheckedChanged(object sender, EventArgs e)
		{
			checkBox1.Enabled = false;
			checkBox2.Enabled = false;
			checkBox3.Enabled = false;
			checkBox4.Enabled = false;
			checkBox5.Enabled = false;
			checkBox6.Enabled = false;
			checkBox7.Enabled = false;
			checkBox8.Enabled = false;
			checkBox9.Enabled = false;
		}
				
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			checkBox1.Enabled = true;
			checkBox2.Enabled = true;
			checkBox3.Enabled = true;
			checkBox4.Enabled = true;
			checkBox5.Enabled = true;
			checkBox6.Enabled = true;
			checkBox7.Enabled = true;
			checkBox8.Enabled = true;
			checkBox9.Enabled = true;
		}
	}
}
