/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 2/25/2017
 * Time: 1:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace RBXLegacyLauncher
{
	/// <summary>
	/// Description of CharacterColors.
	/// </summary>
	public partial class CharacterColors : Form
	{
		public static string SelectedPart = "Head";
		
		public CharacterColors()
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
			SelectedPart = "Head";
			label2.Text = SelectedPart;	
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			SelectedPart = "Torso";
			label2.Text = SelectedPart;	
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			SelectedPart = "Right Arm";
			label2.Text = SelectedPart;				
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			SelectedPart = "Left Arm";
			label2.Text = SelectedPart;				
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			SelectedPart = "Right Leg";
			label2.Text = SelectedPart;	
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			SelectedPart = "Left Leg";
			label2.Text = SelectedPart;	
		}
		
		void CharacterColorsLoad(object sender, EventArgs e)
		{
			label2.Text = SelectedPart;
			button1.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_HeadColor);
			button2.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_TorsoColor);
			button3.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightArmColor);
			button4.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftArmColor);
			button5.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightLegColor);
			button6.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftLegColor);
		}
		
		Color ConvertStringtoColor(string CString)
		{
			var p = CString.Split(new char[]{',',']'});

			int A = Convert.ToInt32(p[0].Substring(p[0].IndexOf('=') + 1));
			int R = Convert.ToInt32(p[1].Substring(p[1].IndexOf('=') + 1));
			int G = Convert.ToInt32(p[2].Substring(p[2].IndexOf('=') + 1));
			int B = Convert.ToInt32(p[3].Substring(p[3].IndexOf('=') + 1));
			
			return Color.FromArgb(A,R,G,B);
		}
		
		void ChangeColorOfPart(int ColorID, Color ButtonColor)
		{
			if (SelectedPart == "Head")
			{
				GlobalVars.HeadColorID = ColorID;
				GlobalVars.ColorMenu_HeadColor = ButtonColor.ToString();
				button1.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_HeadColor);
			}
			else if (SelectedPart == "Torso")
			{
				GlobalVars.TorsoColorID = ColorID;
				GlobalVars.ColorMenu_TorsoColor = ButtonColor.ToString();
				button2.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_TorsoColor);
			}
			else if (SelectedPart == "Right Arm")
			{
				GlobalVars.RightArmColorID = ColorID;
				GlobalVars.ColorMenu_RightArmColor = ButtonColor.ToString();
				button3.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightArmColor);
			}
			else if (SelectedPart == "Left Arm")
			{
				GlobalVars.LeftArmColorID = ColorID;
				GlobalVars.ColorMenu_LeftArmColor = ButtonColor.ToString();
				button4.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftArmColor);
			}
			else if (SelectedPart == "Right Leg")
			{
				GlobalVars.RightLegColorID = ColorID;
				GlobalVars.ColorMenu_RightLegColor = ButtonColor.ToString();
				button5.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightLegColor);
			}
			else if (SelectedPart == "Left Leg")
			{
				GlobalVars.LeftLegColorID = ColorID;
				GlobalVars.ColorMenu_LeftLegColor = ButtonColor.ToString();
				button6.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftLegColor);
			}
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			Color ButtonColor = button7.BackColor;
			int colorID = 1;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button8Click(object sender, EventArgs e)
		{		
			Color ButtonColor = button8.BackColor;
			int colorID = 208;
			ChangeColorOfPart(colorID, ButtonColor);			
		}
		
		void Button9Click(object sender, EventArgs e)
		{
			Color ButtonColor = button9.BackColor;
			int colorID = 194;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button10Click(object sender, EventArgs e)
		{
			Color ButtonColor = button10.BackColor;
			int colorID = 199;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button14Click(object sender, EventArgs e)
		{
			Color ButtonColor = button14.BackColor;
			int colorID = 26;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button13Click(object sender, EventArgs e)
		{
			Color ButtonColor = button13.BackColor;
			int colorID = 21;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button12Click(object sender, EventArgs e)
		{
			Color ButtonColor = button12.BackColor;
			int colorID = 24;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button11Click(object sender, EventArgs e)
		{
			Color ButtonColor = button11.BackColor;
			int colorID = 226;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button18Click(object sender, EventArgs e)
		{
			Color ButtonColor = button18.BackColor;
			int colorID = 23;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button17Click(object sender, EventArgs e)
		{
			Color ButtonColor = button17.BackColor;
			int colorID = 107;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button16Click(object sender, EventArgs e)
		{
			Color ButtonColor = button16.BackColor;
			int colorID = 102;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button15Click(object sender, EventArgs e)
		{
			Color ButtonColor = button15.BackColor;
			int colorID = 11;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button22Click(object sender, EventArgs e)
		{
			Color ButtonColor = button22.BackColor;
			int colorID = 45;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button21Click(object sender, EventArgs e)
		{
			Color ButtonColor = button21.BackColor;
			int colorID = 135;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button20Click(object sender, EventArgs e)
		{
			Color ButtonColor = button20.BackColor;
			int colorID = 106;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button19Click(object sender, EventArgs e)
		{
			Color ButtonColor = button19.BackColor;
			int colorID = 105;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button26Click(object sender, EventArgs e)
		{
			Color ButtonColor = button26.BackColor;
			int colorID = 141;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button25Click(object sender, EventArgs e)
		{
			Color ButtonColor = button25.BackColor;
			int colorID = 28;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button24Click(object sender, EventArgs e)
		{
			Color ButtonColor = button24.BackColor;
			int colorID = 37;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button23Click(object sender, EventArgs e)
		{
			Color ButtonColor = button23.BackColor;
			int colorID = 119;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button30Click(object sender, EventArgs e)
		{
			Color ButtonColor = button30.BackColor;
			int colorID = 29;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button29Click(object sender, EventArgs e)
		{
			Color ButtonColor = button29.BackColor;
			int colorID = 151;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button28Click(object sender, EventArgs e)
		{
			Color ButtonColor = button28.BackColor;
			int colorID = 38;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button27Click(object sender, EventArgs e)
		{
			Color ButtonColor = button27.BackColor;
			int colorID = 192;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button34Click(object sender, EventArgs e)
		{
			Color ButtonColor = button34.BackColor;
			int colorID = 104;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button33Click(object sender, EventArgs e)
		{
			Color ButtonColor = button33.BackColor;
			int colorID = 9;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button32Click(object sender, EventArgs e)
		{
			Color ButtonColor = button32.BackColor;
			int colorID = 101;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button31Click(object sender, EventArgs e)
		{
			Color ButtonColor = button31.BackColor;
			int colorID = 5;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button38Click(object sender, EventArgs e)
		{
			Color ButtonColor = button38.BackColor;
			int colorID = 153;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button37Click(object sender, EventArgs e)
		{
			Color ButtonColor = button37.BackColor;
			int colorID = 217;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button36Click(object sender, EventArgs e)
		{
			Color ButtonColor = button36.BackColor;
			int colorID = 18;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button35Click(object sender, EventArgs e)
		{
			Color ButtonColor = button35.BackColor;
			int colorID = 125;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void Button39Click(object sender, EventArgs e)
		{
            MessageBox.Show("remove this");			
		}
		
		void Button40Click(object sender, EventArgs e)
		{
			GlobalVars.HeadColorID = 24;
			GlobalVars.TorsoColorID = 23;
			GlobalVars.LeftArmColorID = 24;
			GlobalVars.RightArmColorID = 24;
			GlobalVars.LeftLegColorID = 119;
			GlobalVars.RightLegColorID = 119;
			GlobalVars.ColorMenu_HeadColor = "Color [A=255, R=245, G=205, B=47]";
			GlobalVars.ColorMenu_TorsoColor = "Color [A=255, R=13, G=105, B=172]";
			GlobalVars.ColorMenu_LeftArmColor = "Color [A=255, R=245, G=205, B=47]";
			GlobalVars.ColorMenu_RightArmColor = "Color [A=255, R=245, G=205, B=47]";
			GlobalVars.ColorMenu_LeftLegColor = "Color [A=255, R=164, G=189, B=71]";
			GlobalVars.ColorMenu_RightLegColor = "Color [A=255, R=164, G=189, B=71]";
			button1.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_HeadColor);
			button2.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_TorsoColor);
			button3.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightArmColor);
			button4.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftArmColor);
			button5.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightLegColor);
			button6.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftLegColor);
            MessageBox.Show("Colors Reset!");	
		}
	}
}
