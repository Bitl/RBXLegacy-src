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
		
		void Button1Click(object sender, EventArgs e)
		{
			ClientinfoEditor cie = new ClientinfoEditor();
			cie.Show();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			InfoEditor ie = new InfoEditor();
			ie.Show();
		}
	}
}
