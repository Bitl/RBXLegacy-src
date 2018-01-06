using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Open.Nat;

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
			textBox1.AppendText("RBXLegacy Version: " + GlobalVars.Version);

			if (GlobalVars.PlayerLimit == 0)
			{
				//We need at least a limit of 12 players.
				GlobalVars.PlayerLimit = 12;
				textBox3.Text = GlobalVars.PlayerLimit.ToString();
			}
			else
			{
				textBox3.Text = GlobalVars.PlayerLimit.ToString();
			}

			if (GlobalVars.ServerPort == 0)
			{
				//We need at least a limit of 12 players.
				GlobalVars.ServerPort = GlobalVars.DefaultRobloxPort;
				numericUpDown1.Text = GlobalVars.ServerPort.ToString();
			}
			else
			{
				numericUpDown1.Text = GlobalVars.ServerPort.ToString();
			}
			
			if (GlobalVars.upnp == true)
			{
				checkBox11.Checked = true;
			}
			else
			{
				checkBox11.Checked = false;
			}
			
			comboBox1.SelectedText = GlobalVars.ChatType;		
		}
		
		string GetExternalIPAddress()
		{
        	string url = "http://checkip.dyndns.org";
        	System.Net.WebRequest req = System.Net.WebRequest.Create(url);
        	System.Net.WebResponse resp = req.GetResponse();
        	System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
        	string response = sr.ReadToEnd().Trim();
        	string[] a = response.Split(':');
        	string a2 = a[1].Substring(1);
        	string[] a3 = a2.Split('<');
        	string a4 = a3[0];
        	return a4;
		}
		
		void NumericUpDown1ValueChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(numericUpDown1.Text, out parsedValue))
			{
				if (numericUpDown1.Text.Equals(""))
				{
					//set it to the normal port, 53640. it wouldn't make any sense if we set it to 0.
					GlobalVars.ServerPort = GlobalVars.DefaultRobloxPort;
				}
				else
				{
					GlobalVars.ServerPort = Convert.ToInt32(numericUpDown1.Text);
				}
			}
			else
			{
				GlobalVars.ServerPort = GlobalVars.DefaultRobloxPort;
			}				
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalVars.ChatType = comboBox1.SelectedText;
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox2.Text, out parsedValue))
			{
				if (textBox2.Text.Equals(""))
				{
					GlobalVars.RespawnTime = 5;
				}
				else
				{
					GlobalVars.RespawnTime = Convert.ToInt32(textBox2.Text);
				}
			}
			else
			{
				GlobalVars.RespawnTime = 5;
			}
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox3.Text, out parsedValue))
			{
				if (textBox3.Text.Equals(""))
				{
					GlobalVars.PlayerLimit = 12;
				}
				else
				{
					GlobalVars.PlayerLimit = Convert.ToInt32(textBox3.Text);
				}
			}
			else
			{
				GlobalVars.PlayerLimit = 12;
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			LauncherFuncs.ResetServerPrefs();
			LauncherFuncs.WriteServerPrefs("serverhost_config.txt");
			DialogResult result = MessageBox.Show("Your server configuration has been reset to the default values.","RBXLegacy Launcher - Server Preferences", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);			
		}
		
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
    		base.OnFormClosing(e);
    		LauncherFuncs.WriteServerPrefs("serverhost_config.txt");
		}
		
		void CheckBox11CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox11.Checked == true)
			{
				GlobalVars.upnp = true;
			}
			else
			{
				GlobalVars.upnp = false;
			}		
		}
		
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox4.Text, out parsedValue))
			{
				if (textBox4.Text.Equals(""))
				{
					GlobalVars.blacklist1 = 0;
				}
				else
				{
					GlobalVars.blacklist1 = Convert.ToInt32(textBox4.Text);
				}
			}
			else
			{
				GlobalVars.blacklist1 = 0;
			}			
		}
		
		void TextBox8TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox8.Text, out parsedValue))
			{
				if (textBox8.Text.Equals(""))
				{
					GlobalVars.blacklist2 = 0;
				}
				else
				{
					GlobalVars.blacklist2 = Convert.ToInt32(textBox8.Text);
				}
			}
			else
			{
				GlobalVars.blacklist2 = 0;
			}
		}
		
		void TextBox10TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox10.Text, out parsedValue))
			{
				if (textBox10.Text.Equals(""))
				{
					GlobalVars.blacklist3 = 0;
				}
				else
				{
					GlobalVars.blacklist3 = Convert.ToInt32(textBox10.Text);
				}
			}
			else
			{
				GlobalVars.blacklist3 = 0;
			}
		}
		
		void TextBox12TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox12.Text, out parsedValue))
			{
				if (textBox12.Text.Equals(""))
				{
					GlobalVars.blacklist4 = 0;
				}
				else
				{
					GlobalVars.blacklist4 = Convert.ToInt32(textBox12.Text);
				}
			}
			else
			{
				GlobalVars.blacklist4 = 0;
			}
		}
		
		void TextBox6TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox6.Text, out parsedValue))
			{
				if (textBox6.Text.Equals(""))
				{
					GlobalVars.blacklist5 = 0;
				}
				else
				{
					GlobalVars.blacklist5 = Convert.ToInt32(textBox6.Text);
				}
			}
			else
			{
				GlobalVars.blacklist5 = 0;
			}
		}
		
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(numericUpDown1.Text, out parsedValue))
			{
				if (numericUpDown1.Text.Equals(""))
				{
					GlobalVars.blacklist6 = 0;
				}
				else
				{
					GlobalVars.blacklist6 = Convert.ToInt32(numericUpDown1.Text);
				}
			}
			else
			{
				GlobalVars.blacklist6 = 0;
			}
		}
		
		void TextBox9TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox9.Text, out parsedValue))
			{
				if (textBox9.Text.Equals(""))
				{
					GlobalVars.blacklist7 = 0;
				}
				else
				{
					GlobalVars.blacklist7 = Convert.ToInt32(textBox9.Text);
				}
			}
			else
			{
				GlobalVars.blacklist7 = 0;
			}
		}
		
		void TextBox11TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox11.Text, out parsedValue))
			{
				if (textBox11.Text.Equals(""))
				{
					GlobalVars.blacklist8 = 0;
				}
				else
				{
					GlobalVars.blacklist8 = Convert.ToInt32(textBox11.Text);
				}
			}
			else
			{
				GlobalVars.blacklist8 = 0;
			}
		}
	}
}
