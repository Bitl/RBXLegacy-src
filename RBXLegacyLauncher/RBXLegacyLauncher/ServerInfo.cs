/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 5/14/2017
 * Time: 9:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace RBXLegacyLauncher
{
	/// <summary>
	/// Description of ServerInfo.
	/// </summary>
	public partial class ServerInfo : Form
	{
		public ServerInfo()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ServerInfoLoad(object sender, EventArgs e)
		{
			string sent = textBox1.Text;
        	textBox1.AppendText("Client: " + GlobalVars.SelectedClient);
        	textBox1.AppendText(Environment.NewLine);
        	textBox1.AppendText("Port: " + GlobalVars.RobloxPort.ToString());
        	textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText("Map: " + GlobalVars.Map);
        	textBox1.AppendText(Environment.NewLine);
        	textBox1.AppendText("Players: " + GlobalVars.PlayerLimit);
        	textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText("Version: RBXLegacy " + GlobalVars.Version);    	
		}
	}
}
