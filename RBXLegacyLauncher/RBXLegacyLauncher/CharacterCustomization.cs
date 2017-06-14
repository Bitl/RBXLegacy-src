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
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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
			string hatdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		button2.Enabled = true;
        	}
        	else
        	{
        		button2.Enabled = false;
        	}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			CharacterColors ccol = new CharacterColors();
			ccol.Show();			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			CharacterCustomization_HatMenu chats = new CharacterCustomization_HatMenu();
			chats.Show();
		}
	}
}
