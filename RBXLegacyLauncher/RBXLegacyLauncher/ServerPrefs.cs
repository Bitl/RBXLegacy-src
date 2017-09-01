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
				textBox7.Text = GlobalVars.ServerPort.ToString();
			}
			else
			{
				textBox7.Text = GlobalVars.ServerPort.ToString();
			}
			
			if (GlobalVars.melee == true && GlobalVars.navigation == true 
			    && GlobalVars.social == true && GlobalVars.powerup == true && 
			    GlobalVars.explosives == true && GlobalVars.transport == true && 
			    GlobalVars.ranged == true && GlobalVars.musical == true && 
			    GlobalVars.building == true)
			{
				radioButton1.Checked = true;
			}
			else if (GlobalVars.melee == false && GlobalVars.navigation == false 
			    && GlobalVars.social == false && GlobalVars.powerup == false && 
			    GlobalVars.explosives == false && GlobalVars.transport == false && 
			    GlobalVars.ranged == false && GlobalVars.musical == false && 
			    GlobalVars.building == false)
			{
				radioButton3.Checked = true;
			}
			else
			{
				radioButton2.Checked = true;
			}
			
			if (GlobalVars.melee == true)
			{
				checkBox1.Checked = true;
			}
			else
			{
				checkBox1.Checked = false;
			}
			
			if (GlobalVars.navigation == true)
			{
				checkBox2.Checked = true;
			}
			else
			{
				checkBox2.Checked = false;
			}
			
			if (GlobalVars.social == true)
			{
				checkBox3.Checked = true;
			}
			else
			{
				checkBox3.Checked = false;
			}
			
			if (GlobalVars.powerup == true)
			{
				checkBox6.Checked = true;
			}
			else
			{
				checkBox6.Checked = false;
			}
			
			if (GlobalVars.explosives == true)
			{
				checkBox5.Checked = true;
			}
			else
			{
				checkBox5.Checked = false;
			}
			
			if (GlobalVars.transport == true)
			{
				checkBox4.Checked = true;
			}
			else
			{
				checkBox4.Checked = false;
			}
			
			if (GlobalVars.ranged == true)
			{
				checkBox9.Checked = true;
			}
			else
			{
				checkBox9.Checked = false;
			}
			
			if (GlobalVars.musical == true)
			{
				checkBox8.Checked = true;
			}
			else
			{
				checkBox8.Checked = false;
			}
			
			if (GlobalVars.building == true)
			{
				checkBox7.Checked = true;
			}
			else
			{
				checkBox7.Checked = false;
			}
			
			if (GlobalVars.upnp == true)
			{
				checkBox11.Checked = true;
			}
			else
			{
				checkBox11.Checked = false;
			}
			
			if (GlobalVars.IsPersonalServer == true)
			{
				checkBox10.Checked = true;
			}
			else
			{
				checkBox10.Checked = false;
			}
			
			comboBox1.SelectedText = GlobalVars.ChatType;		
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
			
			checkBox1.Checked = true;
			checkBox2.Checked = true;
			checkBox3.Checked = true;
			checkBox4.Checked = true;
			checkBox5.Checked = true;
			checkBox6.Checked = true;
			checkBox7.Checked = true;
			checkBox8.Checked = true;
			checkBox9.Checked = true;
			
			GlobalVars.melee = true;
			GlobalVars.navigation = true;
			GlobalVars.social = true;
			GlobalVars.powerup = true;
			GlobalVars.explosives = true;
			GlobalVars.transport = true;
			GlobalVars.ranged = true;
			GlobalVars.musical = true;
			GlobalVars.building = true;
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
			
			checkBox1.Checked = false;
			checkBox2.Checked = false;
			checkBox3.Checked = false;
			checkBox4.Checked = false;
			checkBox5.Checked = false;
			checkBox6.Checked = false;
			checkBox7.Checked = false;
			checkBox8.Checked = false;
			checkBox9.Checked = false;
			
			GlobalVars.melee = false;
			GlobalVars.navigation = false;
			GlobalVars.social = false;
			GlobalVars.powerup = false;
			GlobalVars.explosives = false;
			GlobalVars.transport = false;
			GlobalVars.ranged = false;
			GlobalVars.musical = false;
			GlobalVars.building = false;
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
			
			checkBox1.Checked = false;
			checkBox2.Checked = false;
			checkBox3.Checked = false;
			checkBox4.Checked = false;
			checkBox5.Checked = false;
			checkBox6.Checked = false;
			checkBox7.Checked = false;
			checkBox8.Checked = false;
			checkBox9.Checked = false;
			
			GlobalVars.melee = false;
			GlobalVars.navigation = false;
			GlobalVars.social = false;
			GlobalVars.powerup = false;
			GlobalVars.explosives = false;
			GlobalVars.transport = false;
			GlobalVars.ranged = false;
			GlobalVars.musical = false;
			GlobalVars.building = false;
		}
		
		void TextBox7TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox7.Text, out parsedValue))
			{
				if (textBox7.Text.Equals(""))
				{
					//set it to the normal port, 53640. it wouldn't make any sense if we set it to 0.
					GlobalVars.ServerPort = GlobalVars.DefaultRobloxPort;
				}
				else
				{
					GlobalVars.ServerPort = Convert.ToInt32(textBox7.Text);
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
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				GlobalVars.melee = true;
			}
			else
			{
				GlobalVars.melee = false;
			}
		}
		
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked == true)
			{
				GlobalVars.navigation = true;
			}
			else
			{
				GlobalVars.navigation = false;
			}
		}
		
		void CheckBox3CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked == true)
			{
				GlobalVars.social = true;
			}
			else
			{
				GlobalVars.social = false;
			}
		}
		
		void CheckBox4CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox4.Checked == true)
			{
				GlobalVars.transport = true;
			}
			else
			{
				GlobalVars.transport = false;
			}
		}
		
		void CheckBox5CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox5.Checked == true)
			{
				GlobalVars.explosives = true;
			}
			else
			{
				GlobalVars.explosives = false;
			}
		}
		
		void CheckBox6CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox6.Checked == true)
			{
				GlobalVars.powerup = true;
			}
			else
			{
				GlobalVars.powerup = false;
			}
		}
		
		void CheckBox7CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox7.Checked == true)
			{
				GlobalVars.building = true;
			}
			else
			{
				GlobalVars.building = false;
			}
		}
		
		void CheckBox8CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox8.Checked == true)
			{
				GlobalVars.musical = true;
			}
			else
			{
				GlobalVars.musical = false;
			}
		}
		
		void CheckBox9CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox9.Checked == true)
			{
				GlobalVars.ranged = true;
			}
			else
			{
				GlobalVars.ranged = false;
			}
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
		
		void CheckBox10CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox10.Checked == true)
			{
				GlobalVars.IsPersonalServer = true;
			}
			else
			{
				GlobalVars.IsPersonalServer = false;
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
			if (int.TryParse(textBox7.Text, out parsedValue))
			{
				if (textBox7.Text.Equals(""))
				{
					GlobalVars.blacklist6 = 0;
				}
				else
				{
					GlobalVars.blacklist6 = Convert.ToInt32(textBox7.Text);
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
