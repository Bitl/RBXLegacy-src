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
		public static int HeadColor = 24;
		public static int TorsoColor = 23;
		public static int LArmColor = 24;
		public static int RArmColor = 24;
		public static int LLegColor = 119;
		public static int RLegColor = 119;
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
			if (!File.Exists("playercolors.txt"))
			{
				WriteColorConfigValues();
			}
			//if (!File.Exists(GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\content\\charcustom\\CharacterColors.rbxm"))
			//{
				//WriteColorModel();
			//}
			label2.Text = SelectedPart;
			button1.BackColor = ConvertStringtoColor("Color [A=255, R=245, G=205, B=47]");
			button2.BackColor = ConvertStringtoColor("Color [A=255, R=13, G=105, B=172]");
			button3.BackColor = ConvertStringtoColor("Color [A=255, R=245, G=205, B=47]");
			button4.BackColor = ConvertStringtoColor("Color [A=255, R=245, G=205, B=47]");
			button5.BackColor = ConvertStringtoColor("Color [A=255, R=164, G=189, B=71]");
			button6.BackColor = ConvertStringtoColor("Color [A=255, R=164, G=189, B=71]");
			ReadColorConfigValues();
		}
		
		void ReadColorConfigValues()
		{
			string line1, line2, line3, line4, line5, line6, line7, line8, line9, line10, line11, line12;

			using(StreamReader reader = new StreamReader("playercolors.txt")) 
			{
    			line1 = reader.ReadLine();
    			line2 = reader.ReadLine();
    			line3 = reader.ReadLine();
    			line4 = reader.ReadLine();
    			line5 = reader.ReadLine();
    			line6 = reader.ReadLine();
    			line7 = reader.ReadLine();
    			line8 = reader.ReadLine();
    			line9 = reader.ReadLine();
    			line10 = reader.ReadLine();
    			line11 = reader.ReadLine();
    			line12 = reader.ReadLine();
			}
			
			int iline1 = Convert.ToInt32(line1);
			HeadColor = iline1;
			
			int iline2 = Convert.ToInt32(line2);
			TorsoColor = iline2;
			
			int iline3 = Convert.ToInt32(line3);
			LArmColor = iline3;
			
			int iline4 = Convert.ToInt32(line4);
			RArmColor = iline4;
			
			int iline5 = Convert.ToInt32(line5);
			LLegColor = iline5;
			
			int iline6 = Convert.ToInt32(line6);
			RLegColor = iline6;
			
			button1.BackColor = ConvertStringtoColor(line7);
			button2.BackColor = ConvertStringtoColor(line8);
			button3.BackColor = ConvertStringtoColor(line9);
			button4.BackColor = ConvertStringtoColor(line10);
			button5.BackColor = ConvertStringtoColor(line11);
			button6.BackColor = ConvertStringtoColor(line12);
		}
		
		void WriteColorConfigValues()
		{
			string[] lines = { 
				HeadColor.ToString(), 
				TorsoColor.ToString(), 
				LArmColor.ToString(), 
				RArmColor.ToString(), 
				LLegColor.ToString(), 
				RLegColor.ToString(), 
				button1.BackColor.ToString(), 
				button2.BackColor.ToString(),
				button3.BackColor.ToString(),
				button4.BackColor.ToString(),
				button5.BackColor.ToString(),
				button6.BackColor.ToString(),
			};
			File.WriteAllLines("playercolors.txt", lines);
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
				HeadColor = ColorID;
				GlobalVars.HeadColorID = 24;
				button1.BackColor = ButtonColor;
			}
			else if (SelectedPart == "Torso")
			{
				TorsoColor = ColorID;
				GlobalVars.TorsoColorID = 23;
				button2.BackColor = ButtonColor;
			}
			else if (SelectedPart == "Right Arm")
			{
				RArmColor = ColorID;
				GlobalVars.RightArmColorID = 24;
				button3.BackColor = ButtonColor;
			}
			else if (SelectedPart == "Left Arm")
			{
				LArmColor = ColorID;
				GlobalVars.LeftArmColorID = 24;
				button4.BackColor = ButtonColor;
			}
			else if (SelectedPart == "Right Leg")
			{
				RLegColor = ColorID;
				GlobalVars.RightLegColorID = 119;
				button5.BackColor = ButtonColor;
			}
			else if (SelectedPart == "Left Leg")
			{
				LLegColor = ColorID;
				GlobalVars.LeftLegColorID = 119;
				button6.BackColor = ButtonColor;
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
			//WriteColorModel();
            WriteColorConfigValues();
            MessageBox.Show("Colors Saved!");			
		}
		
		void WriteColorModel()
        {
            string filename = GlobalVars.ClientDir + @"\\" + GlobalVars.SelectedClient + @"\\content\\charcustom\\CharacterColors.rbxm";
			XmlTextWriter writer = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 3;
            writer.WriteStartDocument(true);
            writer.WriteStartElement("roblox");
            writer.WriteAttributeString("xmlns:xmime", "http://www.w3.org/2005/05/xmlmime");
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "http://www.roblox.com/roblox.xsd");
            writer.WriteAttributeString("version", "4");
            writer.WriteStartElement("External");
            writer.WriteString("null");
            writer.WriteEndElement();
            writer.WriteStartElement("External");
            writer.WriteString("nil");
            writer.WriteEndElement();
            writer.WriteStartElement("Item");
            writer.WriteAttributeString("class", "BodyColors");
            writer.WriteStartElement("Properties");
            writer.WriteStartElement("int");
            writer.WriteAttributeString("name", "HeadColor");
            writer.WriteString(HeadColor.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("int");
            writer.WriteAttributeString("name", "LeftArmColor");
            writer.WriteString(LArmColor.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("int");
            writer.WriteAttributeString("name", "LeftLegColor");
            writer.WriteString(LLegColor.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("string");
            writer.WriteAttributeString("name", "Name");
            writer.WriteString("Body Colors");
            writer.WriteEndElement();
            writer.WriteStartElement("int");
            writer.WriteAttributeString("name", "RightArmColor");
            writer.WriteString(RArmColor.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("int");
            writer.WriteAttributeString("name", "RightLegColor");
            writer.WriteString(RLegColor.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("int");
            writer.WriteAttributeString("name", "TorsoColor");
            writer.WriteString(TorsoColor.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("bool");
            writer.WriteAttributeString("name", "archivable");
            writer.WriteString("true");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
		
		void Button40Click(object sender, EventArgs e)
		{
			HeadColor = 24;
			TorsoColor = 23;
			LArmColor = 24;
			RArmColor = 24;
			LLegColor = 119;
			RLegColor = 119;
			button1.BackColor = ConvertStringtoColor("Color [A=255, R=245, G=205, B=47]");
			button2.BackColor = ConvertStringtoColor("Color [A=255, R=13, G=105, B=172]");
			button3.BackColor = ConvertStringtoColor("Color [A=255, R=245, G=205, B=47]");
			button4.BackColor = ConvertStringtoColor("Color [A=255, R=245, G=205, B=47]");
			button5.BackColor = ConvertStringtoColor("Color [A=255, R=164, G=189, B=71]");
			button6.BackColor = ConvertStringtoColor("Color [A=255, R=164, G=189, B=71]");
			//WriteColorModel();
            WriteColorConfigValues();
            MessageBox.Show("Colors Reset!");	
		}
	}
}
