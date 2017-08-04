/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 2/5/2017
 * Time: 1:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
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
		public static string SelectedPart = "Head";
		public string[,] ColorArray;
		
		public CharacterCustomization()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			LauncherFuncs.ReadClientValuesBCC(GlobalVars.SelectedClient);
			if (GlobalVars.SelectedClientVersion < 6)
			{
				ColorArray = new string[32, 2] {
					{ "1", ColorButton7.BackColor.ToString() }, 
					{ "208", ColorButton8.BackColor.ToString() },
					{ "194", ColorButton9.BackColor.ToString() }, 
					{ "199", ColorButton10.BackColor.ToString() },
					{ "26", ColorButton14.BackColor.ToString() },
					{ "21", ColorButton13.BackColor.ToString() },
					{ "24", ColorButton12.BackColor.ToString() },
					{ "226", ColorButton11.BackColor.ToString() },
					{ "23", ColorButton18.BackColor.ToString() },
					{ "107", ColorButton17.BackColor.ToString() },
					{ "102", ColorButton16.BackColor.ToString() },
					{ "11", ColorButton15.BackColor.ToString() },
					{ "45", ColorButton22.BackColor.ToString() },
					{ "135", ColorButton21.BackColor.ToString() },
					{ "106", ColorButton20.BackColor.ToString() },
					{ "105", ColorButton19.BackColor.ToString() },
					{ "141", ColorButton26.BackColor.ToString() },
					{ "28", ColorButton25.BackColor.ToString() },
					{ "37", ColorButton24.BackColor.ToString() },
					{ "119", ColorButton23.BackColor.ToString() },
					{ "29", ColorButton30.BackColor.ToString() },
					{ "151", ColorButton29.BackColor.ToString() },
					{ "38", ColorButton28.BackColor.ToString() },
					{ "192", ColorButton27.BackColor.ToString() },
					{ "104", ColorButton34.BackColor.ToString() },
					{ "9", ColorButton33.BackColor.ToString() },
					{ "101", ColorButton32.BackColor.ToString() },
					{ "5", ColorButton31.BackColor.ToString() },
					{ "153", ColorButton38.BackColor.ToString() },
					{ "217", ColorButton37.BackColor.ToString() },
					{ "18", ColorButton36.BackColor.ToString() },
					{ "125", ColorButton35.BackColor.ToString() }
				};
			}
		else if (GlobalVars.SelectedClientVersion >= 6)
		{
			ColorArray = new string[64, 2] {
				{ "1", ColorButton7.BackColor.ToString() }, 
				{ "208", ColorButton8.BackColor.ToString() },
				{ "194", ColorButton9.BackColor.ToString() }, 
				{ "199", ColorButton10.BackColor.ToString() },
				{ "26", ColorButton14.BackColor.ToString() },
				{ "21", ColorButton13.BackColor.ToString() },
				{ "24", ColorButton12.BackColor.ToString() },
				{ "226", ColorButton11.BackColor.ToString() },
				{ "23", ColorButton18.BackColor.ToString() },
				{ "107", ColorButton17.BackColor.ToString() },
				{ "102", ColorButton16.BackColor.ToString() },
				{ "11", ColorButton15.BackColor.ToString() },
				{ "45", ColorButton22.BackColor.ToString() },
				{ "135", ColorButton21.BackColor.ToString() },
				{ "106", ColorButton20.BackColor.ToString() },
				{ "105", ColorButton19.BackColor.ToString() },
				{ "141", ColorButton26.BackColor.ToString() },
				{ "28", ColorButton25.BackColor.ToString() },
				{ "37", ColorButton24.BackColor.ToString() },
				{ "119", ColorButton23.BackColor.ToString() },
				{ "29", ColorButton30.BackColor.ToString() },
				{ "151", ColorButton29.BackColor.ToString() },
				{ "38", ColorButton28.BackColor.ToString() },
				{ "192", ColorButton27.BackColor.ToString() },
				{ "104", ColorButton34.BackColor.ToString() },
				{ "9", ColorButton33.BackColor.ToString() },
				{ "101", ColorButton32.BackColor.ToString() },
				{ "5", ColorButton31.BackColor.ToString() },
				{ "153", ColorButton38.BackColor.ToString() },
				{ "217", ColorButton37.BackColor.ToString() },
				{ "18", ColorButton36.BackColor.ToString() },
				{ "125", ColorButton35.BackColor.ToString() },
				{ "1001", ColorButton39.BackColor.ToString() },
				{ "1002", ColorButton40.BackColor.ToString() },
				{ "1003", ColorButton41.BackColor.ToString() },
				{ "1022", ColorButton42.BackColor.ToString() },
				{ "1023", ColorButton43.BackColor.ToString() },
				{ "133", ColorButton44.BackColor.ToString() },
				{ "1018", ColorButton45.BackColor.ToString() },
				{ "1030", ColorButton46.BackColor.ToString() },
				{ "1029", ColorButton47.BackColor.ToString() },
				{ "1025", ColorButton48.BackColor.ToString() },
				{ "1016", ColorButton49.BackColor.ToString() },
				{ "1026", ColorButton50.BackColor.ToString() },
				{ "1024", ColorButton51.BackColor.ToString() },
				{ "1027", ColorButton52.BackColor.ToString() },
				{ "1028", ColorButton53.BackColor.ToString() },
				{ "1008", ColorButton54.BackColor.ToString() },
				{ "1009", ColorButton55.BackColor.ToString() },
				{ "1005", ColorButton55.BackColor.ToString() },
				{ "1004", ColorButton56.BackColor.ToString() },
				{ "1032", ColorButton57.BackColor.ToString() },
				{ "1010", ColorButton58.BackColor.ToString() },
				{ "1019", ColorButton59.BackColor.ToString() },
				{ "1020", ColorButton60.BackColor.ToString() },
				{ "1031", ColorButton61.BackColor.ToString() },
				{ "1006", ColorButton62.BackColor.ToString() },
				{ "1013", ColorButton63.BackColor.ToString() },
				{ "1021", ColorButton64.BackColor.ToString() },
				{ "1014", ColorButton65.BackColor.ToString() },
				{ "1007", ColorButton66.BackColor.ToString() },
				{ "1015", ColorButton67.BackColor.ToString() },
				{ "1012", ColorButton68.BackColor.ToString() },
				{ "1011", ColorButton68.BackColor.ToString() }
			};
		}
		}
		
		void CharacterCustomizationLoad(object sender, EventArgs e)
		{
			textBox1.Text = GlobalVars.Custom_TShirt.ToString();
			textBox2.Text = GlobalVars.Custom_Shirt.ToString();
			textBox3.Text = GlobalVars.Custom_Pants.ToString();
			if (GlobalVars.Custom_IconType.Equals("BC"))
			{
				radioButton1.Checked = true;
			}
			else if (GlobalVars.Custom_IconType.Equals("TBC"))
			{
				radioButton2.Checked = true;
			}
			else if (GlobalVars.Custom_IconType.Equals("OBC"))
			{
				radioButton3.Checked = true;
			}
			else if (GlobalVars.Custom_IconType.Equals("NBC"))
			{
				radioButton4.Checked = true;
			}
			// pages
			if (GlobalVars.SelectedClientVersion >= 6)
			{
				button6.Enabled = true;
			}
        	//color menu implementation
        	PartSelectionLabel2.Text = SelectedPart;
			HeadButton1.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_HeadColor);
			TorsoButton2.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_TorsoColor);
			RArmButton3.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightArmColor);
			LArmButton4.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftArmColor);
			RLegButton5.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightLegColor);
			LLegButton6.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftLegColor);
		}
		
		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])
			{
				if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage6"])//your specific tabname
				{
					string partdir;
					if (SelectedPart == "Head")
					{
						partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\heads";
						if (Directory.Exists(partdir))
						{
							listBox5.Items.Clear();
							DirectoryInfo dinfo = new DirectoryInfo(partdir);
							FileInfo[] Files = dinfo.GetFiles("*.rbxm");
							foreach( FileInfo file in Files )
							{
								if (file.Name.Equals(String.Empty))
								{
									continue;
								}
								
								listBox5.Items.Add(file.Name);
							}
							listBox5.SelectedItem = GlobalVars.HeadID;
							listBox5.Enabled = true;
							Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.HeadID.Replace(".rbxm", "") + ".png");
							pictureBox5.Image = icon5;
						}
					}
					else if (SelectedPart == "Torso")
					{
						partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\2";
						if (Directory.Exists(partdir))
						{
							listBox5.Items.Clear();
							DirectoryInfo dinfo = new DirectoryInfo(partdir);
							FileInfo[] Files = dinfo.GetFiles("*.rbxm");
							foreach( FileInfo file in Files )
							{
								if (file.Name.Equals(String.Empty))
								{
									continue;
								}
								
								listBox5.Items.Add(file.Name);
							}
							listBox5.SelectedItem = GlobalVars.TorsoID;
							listBox5.Enabled = true;
							Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.TorsoID.Replace(".rbxm", "") + ".png");
							pictureBox5.Image = icon5;
						}
					}
					else if (SelectedPart == "Right Arm")
					{
						partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\3";
						if (Directory.Exists(partdir))
						{
							listBox5.Items.Clear();
							DirectoryInfo dinfo = new DirectoryInfo(partdir);
							FileInfo[] Files = dinfo.GetFiles("*.rbxm");
							foreach( FileInfo file in Files )
							{
								if (file.Name.Equals(String.Empty))
								{
									continue;
								}
								
								listBox5.Items.Add(file.Name);
							}
							listBox5.SelectedItem = GlobalVars.RightArmID;
							listBox5.Enabled = true;
							Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.RightArmID.Replace(".rbxm", "") + ".png");
							pictureBox5.Image = icon5;
						}
					}
					else if (SelectedPart == "Left Arm")
					{
						partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\4";
						if (Directory.Exists(partdir))
						{
							listBox5.Items.Clear();
							DirectoryInfo dinfo = new DirectoryInfo(partdir);
							FileInfo[] Files = dinfo.GetFiles("*.rbxm");
							foreach( FileInfo file in Files )
							{
								if (file.Name.Equals(String.Empty))
								{
									continue;
								}
								
								listBox5.Items.Add(file.Name);
							}
							listBox5.SelectedItem = GlobalVars.LeftArmID;
							listBox5.Enabled = true;
							Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.LeftArmID.Replace(".rbxm", "") + ".png");
							pictureBox5.Image = icon5;
						}
					}
					else if (SelectedPart == "Right Leg")
					{
						partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\5";
						if (Directory.Exists(partdir))
						{
							listBox5.Items.Clear();
							DirectoryInfo dinfo = new DirectoryInfo(partdir);
							FileInfo[] Files = dinfo.GetFiles("*.rbxm");
							foreach( FileInfo file in Files )
							{
								if (file.Name.Equals(String.Empty))
								{
									continue;
								}
								
								listBox5.Items.Add(file.Name);
							}
							listBox5.SelectedItem = GlobalVars.RightLegID;
							listBox5.Enabled = true;
							Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.RightLegID.Replace(".rbxm", "") + ".png");
							pictureBox5.Image = icon5;
						}
					}
					else if (SelectedPart == "Left Leg")
					{
						partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\6";
						if (Directory.Exists(partdir))
						{
							listBox5.Items.Clear();
							DirectoryInfo dinfo = new DirectoryInfo(partdir);
							FileInfo[] Files = dinfo.GetFiles("*.rbxm");
							foreach( FileInfo file in Files )
							{
								if (file.Name.Equals(String.Empty))
								{
									continue;
								}
								
								listBox5.Items.Add(file.Name);
							}
							listBox5.SelectedItem = GlobalVars.LeftLegID;
							listBox5.Enabled = true;
							Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.LeftLegID.Replace(".rbxm", "") + ".png");
							pictureBox5.Image = icon5;
						}
					}
				}
				else
     			{
     				listBox5.Items.Clear();
     			}
				
				listBox1.Items.Clear();
     			listBox2.Items.Clear();
     			listBox3.Items.Clear();
     			listBox4.Items.Clear();
			}
     		else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])//your specific tabname
     		{
     			string facedir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\faces";
        		if (Directory.Exists(facedir))
        		{
        			DirectoryInfo dinfo = new DirectoryInfo(facedir);
					FileInfo[] Files = dinfo.GetFiles("*.rbxm");
					foreach( FileInfo file in Files )
					{
						if (file.Name.Equals(String.Empty))
						{
   							continue;
						}
					
						listBox4.Items.Add(file.Name);
					}
					listBox4.SelectedItem = GlobalVars.FaceID;
        			listBox4.Enabled = true;
        			Image icon4 = Image.FromFile(facedir + @"\\" + GlobalVars.FaceID.Replace(".rbxm", "") + ".png");
        			pictureBox4.Image = icon4;
        		}
        		
     			listBox1.Items.Clear();
     			listBox2.Items.Clear();
     			listBox3.Items.Clear();
     			listBox5.Items.Clear();
     		}
			else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])//your specific tabname
     		{
				string hatdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\hats";
        		if (Directory.Exists(hatdir))
        		{
        			DirectoryInfo dinfo = new DirectoryInfo(hatdir);
					FileInfo[] Files = dinfo.GetFiles("*.rbxm");
					foreach( FileInfo file in Files )
					{
						if (file.Name.Equals(String.Empty))
						{
   							continue;
						}
					
						if (file.Name.Equals("TeapotTurret.rbxm") && GlobalVars.AdminMode != true)
						{
   							continue;
						}
					
						listBox1.Items.Add(file.Name);
   						listBox2.Items.Add(file.Name);
   						listBox3.Items.Add(file.Name);
					}
					listBox1.SelectedItem = GlobalVars.Custom_Hat1ID_Offline;
					listBox2.SelectedItem = GlobalVars.Custom_Hat2ID_Offline;
					listBox3.SelectedItem = GlobalVars.Custom_Hat3ID_Offline;
					listBox1.Enabled = true;
        			listBox2.Enabled = true;
        			listBox3.Enabled = true;
        			Image icon1 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat1ID_Offline.Replace(".rbxm", "") + ".png");
        			pictureBox1.Image = icon1;
        			Image icon2 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat2ID_Offline.Replace(".rbxm", "") + ".png");
        			pictureBox2.Image = icon2;
        			Image icon3 = Image.FromFile(hatdir + @"\\" + GlobalVars.Custom_Hat3ID_Offline.Replace(".rbxm", "") + ".png");
        			pictureBox3.Image = icon3;
        		}
        		
        		listBox4.Items.Clear();
        		listBox5.Items.Clear();
			}
			else
			{
				listBox1.Items.Clear();
     			listBox2.Items.Clear();
     			listBox3.Items.Clear();
				listBox4.Items.Clear();
				listBox5.Items.Clear();
			}
		}
		
		void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
		{
     		if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage6"])//your specific tabname
     		{
     			string partdir;
				if (SelectedPart == "Head")
				{
					partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\heads";
					if (Directory.Exists(partdir))
        			{
						listBox5.Items.Clear();
						DirectoryInfo dinfo = new DirectoryInfo(partdir);
						FileInfo[] Files = dinfo.GetFiles("*.rbxm");
						foreach( FileInfo file in Files )
						{
							if (file.Name.Equals(String.Empty))
							{
   								continue;
							}
					
							listBox5.Items.Add(file.Name);
						}
						listBox5.SelectedItem = GlobalVars.HeadID;
        				listBox5.Enabled = true;
        				Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.HeadID.Replace(".rbxm", "") + ".png");
        				pictureBox5.Image = icon5;
        			}
				}
				else if (SelectedPart == "Torso")
				{
					partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\2";
					if (Directory.Exists(partdir))
        			{
						listBox5.Items.Clear();
						DirectoryInfo dinfo = new DirectoryInfo(partdir);
						FileInfo[] Files = dinfo.GetFiles("*.rbxm");
						foreach( FileInfo file in Files )
						{
							if (file.Name.Equals(String.Empty))
							{
   								continue;
							}
					
							listBox5.Items.Add(file.Name);
						}
						listBox5.SelectedItem = GlobalVars.TorsoID;
        				listBox5.Enabled = true;
        				Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.TorsoID.Replace(".rbxm", "") + ".png");
        				pictureBox5.Image = icon5;
        			}
				}
				else if (SelectedPart == "Right Arm")
				{
					partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\3";
					if (Directory.Exists(partdir))
        			{
						listBox5.Items.Clear();
						DirectoryInfo dinfo = new DirectoryInfo(partdir);
						FileInfo[] Files = dinfo.GetFiles("*.rbxm");
						foreach( FileInfo file in Files )
						{
							if (file.Name.Equals(String.Empty))
							{
   								continue;
							}
					
							listBox5.Items.Add(file.Name);
						}
						listBox5.SelectedItem = GlobalVars.RightArmID;
        				listBox5.Enabled = true;
        				Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.RightArmID.Replace(".rbxm", "") + ".png");
        				pictureBox5.Image = icon5;
        			}
				}
				else if (SelectedPart == "Left Arm")
				{
					partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\4";
					if (Directory.Exists(partdir))
        			{
						listBox5.Items.Clear();
						DirectoryInfo dinfo = new DirectoryInfo(partdir);
						FileInfo[] Files = dinfo.GetFiles("*.rbxm");
						foreach( FileInfo file in Files )
						{
							if (file.Name.Equals(String.Empty))
							{
   								continue;
							}
					
							listBox5.Items.Add(file.Name);
						}
						listBox5.SelectedItem = GlobalVars.LeftArmID;
        				listBox5.Enabled = true;
        				Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.LeftArmID.Replace(".rbxm", "") + ".png");
        				pictureBox5.Image = icon5;
        			}
				}
				else if (SelectedPart == "Right Leg")
				{
					partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\5";
					if (Directory.Exists(partdir))
        			{
						listBox5.Items.Clear();
						DirectoryInfo dinfo = new DirectoryInfo(partdir);
						FileInfo[] Files = dinfo.GetFiles("*.rbxm");
						foreach( FileInfo file in Files )
						{
							if (file.Name.Equals(String.Empty))
							{
   								continue;
							}
					
							listBox5.Items.Add(file.Name);
						}
						listBox5.SelectedItem = GlobalVars.RightLegID;
        				listBox5.Enabled = true;
        				Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.RightLegID.Replace(".rbxm", "") + ".png");
        				pictureBox5.Image = icon5;
        			}
				}
				else if (SelectedPart == "Left Leg")
				{
					partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\6";
					if (Directory.Exists(partdir))
        			{
						listBox5.Items.Clear();
						DirectoryInfo dinfo = new DirectoryInfo(partdir);
						FileInfo[] Files = dinfo.GetFiles("*.rbxm");
						foreach( FileInfo file in Files )
						{
							if (file.Name.Equals(String.Empty))
							{
   								continue;
							}
					
							listBox5.Items.Add(file.Name);
						}
						listBox5.SelectedItem = GlobalVars.LeftLegID;
        				listBox5.Enabled = true;
        				Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.LeftLegID.Replace(".rbxm", "") + ".png");
        				pictureBox5.Image = icon5;
        			}
				}
     		}
     		else
     		{
     			listBox5.Items.Clear();
     		}
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
				HeadButton1.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_HeadColor);
			}
			else if (SelectedPart == "Torso")
			{
				GlobalVars.TorsoColorID = ColorID;
				GlobalVars.ColorMenu_TorsoColor = ButtonColor.ToString();
				TorsoButton2.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_TorsoColor);
			}
			else if (SelectedPart == "Right Arm")
			{
				GlobalVars.RightArmColorID = ColorID;
				GlobalVars.ColorMenu_RightArmColor = ButtonColor.ToString();
				RArmButton3.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightArmColor);
			}
			else if (SelectedPart == "Left Arm")
			{
				GlobalVars.LeftArmColorID = ColorID;
				GlobalVars.ColorMenu_LeftArmColor = ButtonColor.ToString();
				LArmButton4.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftArmColor);
			}
			else if (SelectedPart == "Right Leg")
			{
				GlobalVars.RightLegColorID = ColorID;
				GlobalVars.ColorMenu_RightLegColor = ButtonColor.ToString();
				RLegButton5.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightLegColor);
			}
			else if (SelectedPart == "Left Leg")
			{
				GlobalVars.LeftLegColorID = ColorID;
				GlobalVars.ColorMenu_LeftLegColor = ButtonColor.ToString();
				LLegButton6.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftLegColor);
			}
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox1.Text, out parsedValue))
			{
				if (textBox1.Text.Equals(""))
				{
					GlobalVars.Custom_TShirt = 0;
				}
				else
				{
					GlobalVars.Custom_TShirt = Convert.ToInt32(textBox1.Text);
				}
			}
			else
			{
				GlobalVars.Custom_TShirt = 0;
			}
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox2.Text, out parsedValue))
			{
				if (textBox2.Text.Equals(""))
				{
					GlobalVars.Custom_Shirt = 0;
				}
				else
				{
					GlobalVars.Custom_Shirt = Convert.ToInt32(textBox2.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Shirt = 0;
			}
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (int.TryParse(textBox3.Text, out parsedValue))
			{
				if (textBox3.Text.Equals(""))
				{
					GlobalVars.Custom_Pants = 0;
				}
				else
				{
					GlobalVars.Custom_Pants = Convert.ToInt32(textBox3.Text);
				}
			}
			else
			{
				GlobalVars.Custom_Pants = 0;
			}
		}
		
		
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.Custom_IconType = "BC";
		}
		
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.Custom_IconType = "TBC";
		}
		
		void RadioButton3CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.Custom_IconType = "OBC";
		}
		
		void RadioButton4CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.Custom_IconType = "NBC";
		}
		
		void ColorButton7Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton7.BackColor;
			int colorID = 1;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton8Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton8.BackColor;
			int colorID = 208;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton9Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton9.BackColor;
			int colorID = 194;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton10Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton10.BackColor;
			int colorID = 199;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton14Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton14.BackColor;
			int colorID = 26;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton13Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton13.BackColor;
			int colorID = 21;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton12Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton12.BackColor;
			int colorID = 24;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton11Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton11.BackColor;
			int colorID = 226;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton18Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton18.BackColor;
			int colorID = 23;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton17Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton17.BackColor;
			int colorID = 107;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton16Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton16.BackColor;
			int colorID = 102;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton15Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton15.BackColor;
			int colorID = 11;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton22Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton22.BackColor;
			int colorID = 45;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton21Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton21.BackColor;
			int colorID = 135;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton20Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton20.BackColor;
			int colorID = 106;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton19Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton19.BackColor;
			int colorID = 105;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton26Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton26.BackColor;
			int colorID = 141;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton25Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton25.BackColor;
			int colorID = 28;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton24Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton24.BackColor;
			int colorID = 37;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton23Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton23.BackColor;
			int colorID = 119;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton30Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton30.BackColor;
			int colorID = 29;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton29Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton29.BackColor;
			int colorID = 151;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton28Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton28.BackColor;
			int colorID = 38;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton27Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton27.BackColor;
			int colorID = 192;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton34Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton34.BackColor;
			int colorID = 104;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton33Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton33.BackColor;
			int colorID = 9;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton32Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton32.BackColor;
			int colorID = 101;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton31Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton31.BackColor;
			int colorID = 5;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton38Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton38.BackColor;
			int colorID = 153;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton37Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton37.BackColor;
			int colorID = 217;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton36Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton36.BackColor;
			int colorID = 18;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton35Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 125;
			ChangeColorOfPart(colorID, ButtonColor);
		}
				
		void ColorButton39Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1001;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton40Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1002;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton41Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1003;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton42Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1022;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton43Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1023;
			ChangeColorOfPart(colorID, ButtonColor);
		}
				
		void ColorButton44Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 133;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton45Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1018;
			ChangeColorOfPart(colorID, ButtonColor);
		}
				
		void ColorButton46Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1030;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton47Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1029;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton48Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1025;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton49Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1016;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton50Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1026;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton51Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1024;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton52Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1027;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton53Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1028;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton54Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1008;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton55Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1009;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton56Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1005;
			ChangeColorOfPart(colorID, ButtonColor);
		}
				
		void ColorButton57Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1004;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton58Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1032;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton59Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1010;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton60Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1019;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton61Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1020;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton62Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1031;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton63Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1006;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton64Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1013;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton65Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1021;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton66Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1014;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton68Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1007;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton69Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1015;
			ChangeColorOfPart(colorID, ButtonColor);
		}
			
		void ColorButton70Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1012;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void ColorButton71Click(object sender, EventArgs e)
		{
			Color ButtonColor = ColorButton35.BackColor;
			int colorID = 1011;
			ChangeColorOfPart(colorID, ButtonColor);
		}
		
		void RandColorsButton39Click(object sender, EventArgs e)
		{
			Random rand = new Random();
			int RandomColor;
			
			for (int i=1; i <= 6; i++)
			{
				RandomColor = rand.Next(ColorArray.GetLength(0));
				if (i == 1)
				{
					GlobalVars.HeadColorID = Convert.ToInt32(ColorArray[RandomColor, 0]);
					GlobalVars.ColorMenu_HeadColor = ColorArray[RandomColor, 1];
					HeadButton1.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_HeadColor);
				}
				else if (i == 2)
				{
					GlobalVars.TorsoColorID = Convert.ToInt32(ColorArray[RandomColor, 0]);
					GlobalVars.ColorMenu_TorsoColor = ColorArray[RandomColor, 1];
					TorsoButton2.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_TorsoColor);
				}
				else if (i == 3)
				{
					GlobalVars.RightArmColorID = Convert.ToInt32(ColorArray[RandomColor, 0]);
					GlobalVars.ColorMenu_RightArmColor = ColorArray[RandomColor, 1];
					RArmButton3.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightArmColor);
				}
				else if (i == 4)
				{
					GlobalVars.LeftArmColorID = Convert.ToInt32(ColorArray[RandomColor, 0]);
					GlobalVars.ColorMenu_LeftArmColor = ColorArray[RandomColor, 1];
					LArmButton4.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftArmColor);
				}
				else if (i == 5)
				{
					GlobalVars.RightLegColorID = Convert.ToInt32(ColorArray[RandomColor, 0]);
					GlobalVars.ColorMenu_RightLegColor = ColorArray[RandomColor, 1];
					RLegButton5.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightLegColor);
				}
				else if (i == 6)
				{
					GlobalVars.LeftLegColorID = Convert.ToInt32(ColorArray[RandomColor, 0]);
					GlobalVars.ColorMenu_LeftLegColor = ColorArray[RandomColor, 1];
					LLegButton6.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftLegColor);
				}
			}			
		}
		
		void ResetColorsButton40Click(object sender, EventArgs e)
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
			HeadButton1.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_HeadColor);
			TorsoButton2.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_TorsoColor);
			RArmButton3.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightArmColor);
			LArmButton4.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftArmColor);
			RLegButton5.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_RightLegColor);
			LLegButton6.BackColor = ConvertStringtoColor(GlobalVars.ColorMenu_LeftLegColor);
            MessageBox.Show("Colors Reset!");			
		}
		
		void HeadButton1Click(object sender, EventArgs e)
		{
			SelectedPart = "Head";
			PartSelectionLabel2.Text = SelectedPart;
			if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage6"])//your specific tabname
     		{
				string partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\heads";
				if (Directory.Exists(partdir))
				{
					listBox5.Items.Clear();
					DirectoryInfo dinfo = new DirectoryInfo(partdir);
					FileInfo[] Files = dinfo.GetFiles("*.rbxm");
					foreach( FileInfo file in Files )
					{
						if (file.Name.Equals(String.Empty))
						{
							continue;
						}
						
						listBox5.Items.Add(file.Name);
					}
					listBox5.SelectedItem = GlobalVars.HeadID;
					listBox5.Enabled = true;
					Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.HeadID.Replace(".rbxm", "") + ".png");
					pictureBox5.Image = icon5;
				}
     		}
		}
		
		void TorsoButton2Click(object sender, EventArgs e)
		{
			SelectedPart = "Torso";
			PartSelectionLabel2.Text = SelectedPart;
			
			if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage6"])//your specific tabname
     		{
     			string partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\2";
     			if (Directory.Exists(partdir))
     			{
     				listBox5.Items.Clear();
     				DirectoryInfo dinfo = new DirectoryInfo(partdir);
     				FileInfo[] Files = dinfo.GetFiles("*.rbxm");
     				foreach( FileInfo file in Files )
     				{
     					if (file.Name.Equals(String.Empty))
     					{
     						continue;
     					}
     					
     					listBox5.Items.Add(file.Name);
     				}
     				listBox5.SelectedItem = GlobalVars.TorsoID;
     				listBox5.Enabled = true;
     				Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.TorsoID.Replace(".rbxm", "") + ".png");
     				pictureBox5.Image = icon5;
     			}
     		}
		}
		
		void RArmButton3Click(object sender, EventArgs e)
		{
			SelectedPart = "Right Arm";
			PartSelectionLabel2.Text = SelectedPart;
			
			if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage6"])//your specific tabname
     		{
				string partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\3";
				if (Directory.Exists(partdir))
				{
					listBox5.Items.Clear();
					DirectoryInfo dinfo = new DirectoryInfo(partdir);
					FileInfo[] Files = dinfo.GetFiles("*.rbxm");
					foreach( FileInfo file in Files )
					{
						if (file.Name.Equals(String.Empty))
						{
							continue;
						}
						
						listBox5.Items.Add(file.Name);
					}
					listBox5.SelectedItem = GlobalVars.RightArmID;
					listBox5.Enabled = true;
					Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.RightArmID.Replace(".rbxm", "") + ".png");
					pictureBox5.Image = icon5;
				}
     		}
		}
		
		void LArmButton4Click(object sender, EventArgs e)
		{
			SelectedPart = "Left Arm";
			PartSelectionLabel2.Text = SelectedPart;
			
			if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage6"])//your specific tabname
     		{
				string partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\4";
				if (Directory.Exists(partdir))
				{
					listBox5.Items.Clear();
					DirectoryInfo dinfo = new DirectoryInfo(partdir);
					FileInfo[] Files = dinfo.GetFiles("*.rbxm");
					foreach( FileInfo file in Files )
					{
						if (file.Name.Equals(String.Empty))
						{
							continue;
						}
						
						listBox5.Items.Add(file.Name);
					}
					listBox5.SelectedItem = GlobalVars.LeftArmID;
					listBox5.Enabled = true;
					Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.LeftArmID.Replace(".rbxm", "") + ".png");
					pictureBox5.Image = icon5;
				}
			}
		}
		
		void RLegButton5Click(object sender, EventArgs e)
		{
			SelectedPart = "Right Leg";
			PartSelectionLabel2.Text = SelectedPart;
			
			if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage6"])//your specific tabname
     		{
				string partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\5";
				if (Directory.Exists(partdir))
				{
					listBox5.Items.Clear();
					DirectoryInfo dinfo = new DirectoryInfo(partdir);
					FileInfo[] Files = dinfo.GetFiles("*.rbxm");
					foreach( FileInfo file in Files )
					{
						if (file.Name.Equals(String.Empty))
						{
							continue;
						}
						
						listBox5.Items.Add(file.Name);
					}
					listBox5.SelectedItem = GlobalVars.RightLegID;
					listBox5.Enabled = true;
					Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.RightLegID.Replace(".rbxm", "") + ".png");
					pictureBox5.Image = icon5;
				}
			}
		}
		
		void LLegButton6Click(object sender, EventArgs e)
		{
			SelectedPart = "Left Leg";
			PartSelectionLabel2.Text = SelectedPart;
			
			if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage6"])//your specific tabname
     		{
				string partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\6";
				if (Directory.Exists(partdir))
				{
					listBox5.Items.Clear();
					DirectoryInfo dinfo = new DirectoryInfo(partdir);
					FileInfo[] Files = dinfo.GetFiles("*.rbxm");
					foreach( FileInfo file in Files )
					{
						if (file.Name.Equals(String.Empty))
						{
							continue;
						}
						
						listBox5.Items.Add(file.Name);
					}
					listBox5.SelectedItem = GlobalVars.LeftLegID;
					listBox5.Enabled = true;
					Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.LeftLegID.Replace(".rbxm", "") + ".png");
					pictureBox5.Image = icon5;
				}
			}
		}
		
		//hats
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			string hatdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		GlobalVars.Custom_Hat1ID_Offline = listBox1.SelectedItem.ToString();
        		Image icon1 = Image.FromFile(hatdir + "\\" + GlobalVars.Custom_Hat1ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox1.Image = icon1;
        	}
		}
		
		void ListBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			string hatdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		GlobalVars.Custom_Hat2ID_Offline = listBox2.SelectedItem.ToString();
        		Image icon2 = Image.FromFile(hatdir + "\\" + GlobalVars.Custom_Hat2ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox2.Image = icon2;
        	}
		}
		
		void ListBox3SelectedIndexChanged(object sender, EventArgs e)
		{
			string hatdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		GlobalVars.Custom_Hat3ID_Offline = listBox3.SelectedItem.ToString();
        		Image icon3 = Image.FromFile(hatdir + "\\" + GlobalVars.Custom_Hat3ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox3.Image = icon3;
        	}
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			string hatdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
        		Random random = new Random();
				int randomHat1  = random.Next(listBox1.Items.Count);
				listBox1.SelectedItem = listBox1.Items[randomHat1];
        		GlobalVars.Custom_Hat1ID_Offline = listBox1.SelectedItem.ToString();
        		Image icon1 = Image.FromFile(hatdir + "\\" + GlobalVars.Custom_Hat1ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox1.Image = icon1;
        		int randomHat2  = random.Next(listBox2.Items.Count);
				listBox2.SelectedItem = listBox1.Items[randomHat2];
        		GlobalVars.Custom_Hat2ID_Offline = listBox2.SelectedItem.ToString();
        		Image icon2 = Image.FromFile(hatdir + "\\" + GlobalVars.Custom_Hat2ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox2.Image = icon2;
        		int randomHat3  = random.Next(listBox3.Items.Count);
				listBox3.SelectedItem = listBox1.Items[randomHat3];
        		GlobalVars.Custom_Hat3ID_Offline = listBox3.SelectedItem.ToString();
        		Image icon3 = Image.FromFile(hatdir + "\\" + GlobalVars.Custom_Hat3ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox3.Image = icon3;
        	}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			string hatdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\hats";
        	if (Directory.Exists(hatdir))
        	{
				listBox1.SelectedItem = "NoHat.rbxm";
        		GlobalVars.Custom_Hat1ID_Offline = listBox1.SelectedItem.ToString();
        		Image icon1 = Image.FromFile(hatdir + "\\" + GlobalVars.Custom_Hat1ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox1.Image = icon1;
				listBox2.SelectedItem = "NoHat.rbxm";
        		GlobalVars.Custom_Hat2ID_Offline = listBox2.SelectedItem.ToString();
        		Image icon2 = Image.FromFile(hatdir + "\\" + GlobalVars.Custom_Hat2ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox2.Image = icon2;
				listBox3.SelectedItem = "NoHat.rbxm";
        		GlobalVars.Custom_Hat3ID_Offline = listBox3.SelectedItem.ToString();
        		Image icon3 = Image.FromFile(hatdir + "\\" + GlobalVars.Custom_Hat3ID_Offline.Replace(".rbxm", "") + ".png");
        		pictureBox3.Image = icon3;
        	}
		}
		
		void ListBox4SelectedIndexChanged(object sender, EventArgs e)
		{
			string facedir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\faces";
        	if (Directory.Exists(facedir))
        	{
        		GlobalVars.FaceID = listBox4.SelectedItem.ToString();
        		Image icon4 = Image.FromFile(facedir + "\\" + GlobalVars.FaceID.Replace(".rbxm", "") + ".png");
        		pictureBox4.Image = icon4;
        	}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			string facedir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\faces";
        	if (Directory.Exists(facedir))
        	{
        		Random random = new Random();
				int randomFace  = random.Next(listBox4.Items.Count);
				listBox4.SelectedItem = listBox4.Items[randomFace];
        		GlobalVars.FaceID = listBox4.SelectedItem.ToString();
        		Image icon4 = Image.FromFile(facedir + "\\" + GlobalVars.FaceID.Replace(".rbxm", "") + ".png");
        		pictureBox4.Image = icon4;
        	}		
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			string facedir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\faces";
        	if (Directory.Exists(facedir))
        	{
				listBox4.SelectedItem = "DefaultFace.rbxm";
        		GlobalVars.FaceID = listBox4.SelectedItem.ToString();
        		Image icon4 = Image.FromFile(facedir + "\\" + GlobalVars.FaceID.Replace(".rbxm", "") + ".png");
        		pictureBox4.Image = icon4;
        	}			
		}
		
		void ListBox5SelectedIndexChanged(object sender, EventArgs e)
		{
			string partdir;
			if (SelectedPart == "Head")
			{
				partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\heads";
				if (Directory.Exists(partdir))
        		{
        			GlobalVars.HeadID = listBox5.SelectedItem.ToString();
        			Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.HeadID.Replace(".rbxm", "") + ".png");
        			pictureBox5.Image = icon5;
        		}
			}
			else if (SelectedPart == "Torso")
			{
				partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\2";
				if (Directory.Exists(partdir))
        		{
        			GlobalVars.TorsoID = listBox5.SelectedItem.ToString();
        			Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.TorsoID.Replace(".rbxm", "") + ".png");
        			pictureBox5.Image = icon5;
        		}
			}
			else if (SelectedPart == "Right Arm")
			{
				partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\3";
				if (Directory.Exists(partdir))
        		{
        			GlobalVars.RightArmID = listBox5.SelectedItem.ToString();
        			Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.RightArmID.Replace(".rbxm", "") + ".png");
        			pictureBox5.Image = icon5;
        		}
			}
			else if (SelectedPart == "Left Arm")
			{
				partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\4";
				if (Directory.Exists(partdir))
        		{
        			GlobalVars.LeftArmID = listBox5.SelectedItem.ToString();
        			Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.LeftArmID.Replace(".rbxm", "") + ".png");
        			pictureBox5.Image = icon5;
        		}
			}
			else if (SelectedPart == "Right Leg")
			{
				partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\5";
				if (Directory.Exists(partdir))
        		{
        			GlobalVars.RightLegID = listBox5.SelectedItem.ToString();
        			Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.RightLegID.Replace(".rbxm", "") + ".png");
        			pictureBox5.Image = icon5;
        		}
			}
			else if (SelectedPart == "Left Leg")
			{
				partdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\bodies\\6";
				if (Directory.Exists(partdir))
        		{
        			GlobalVars.LeftLegID = listBox5.SelectedItem.ToString();
        			Image icon5 = Image.FromFile(partdir + "\\" + GlobalVars.LeftLegID.Replace(".rbxm", "") + ".png");
        			pictureBox5.Image = icon5;
        		}
			}
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			LauncherFuncs.WriteConfigValues("config.txt");
			Start3DView();
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			Page1Panel.Visible = false;
			Page2Panel.Visible = true;
			button5.Enabled = true;
			button6.Enabled = false;
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			Page2Panel.Visible = false;
			Page1Panel.Visible = true;
			button5.Enabled = false;
			button6.Enabled = true;
		}
		
		void Start3DView()
		{
			string mapfile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\3DView\\content\\fonts\\3DView.rbxl";
			string rbxexe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\charcustom\\3DView\\3DView.exe";
			string quote = "\"";
			string args = "";
			string HatIDOffline1 = GlobalVars.Custom_Hat1ID_Offline;
			string HatIDOffline2 = GlobalVars.Custom_Hat2ID_Offline;
			string HatIDOffline3 = GlobalVars.Custom_Hat3ID_Offline;
			if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == true)
			{
				args = quote + mapfile + "\" -script \"dofile('" + GlobalVars.DefaultScript + "'); _G.CS3DView(" + GlobalVars.UserID + ",'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.TorsoID + "','" + GlobalVars.RightArmID + "','" + GlobalVars.LeftArmID + "','" + GlobalVars.RightLegID + "','" + GlobalVars.LeftLegID + "','" + GlobalVars.Custom_IconType + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == true)
			{
				args = quote + mapfile + "\" -script \"dofile('" + GlobalVars.DefaultScript + "'); _G.CS3DView(" + GlobalVars.UserID + ",'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.TorsoID + "','" + GlobalVars.RightArmID + "','" + GlobalVars.LeftArmID + "','" + GlobalVars.RightLegID + "','" + GlobalVars.LeftLegID + "','" + GlobalVars.Custom_IconType + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == true && GlobalVars.UsesID == false)
			{
				args = quote + mapfile + "\" -script \"dofile('" + GlobalVars.DefaultScript + "'); _G.CS3DView(0,'" + GlobalVars.PlayerName + "','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.TorsoID + "','" + GlobalVars.RightArmID + "','" + GlobalVars.LeftArmID + "','" + GlobalVars.RightLegID + "','" + GlobalVars.LeftLegID + "','" + GlobalVars.Custom_IconType + "');" + quote;
			}
			else if (GlobalVars.UsesPlayerName == false && GlobalVars.UsesID == false )
			{
				args = quote + mapfile + "\" -script \"dofile('" + GlobalVars.DefaultScript + "'); _G.CS3DView(0,'Player','" + HatIDOffline1 + "','" + HatIDOffline2 + "','" + HatIDOffline3 + "'," + GlobalVars.HeadColorID + "," + GlobalVars.TorsoColorID + "," + GlobalVars.LeftArmColorID + "," + GlobalVars.RightArmColorID + "," + GlobalVars.LeftLegColorID + "," + GlobalVars.RightLegColorID + ",'" + GlobalVars.Custom_TShirt + "','" + GlobalVars.Custom_Shirt + "','" + GlobalVars.Custom_Pants + "','" + GlobalVars.FaceID + "','" + GlobalVars.HeadID + "','" + GlobalVars.TorsoID + "','" + GlobalVars.RightArmID + "','" + GlobalVars.LeftArmID + "','" + GlobalVars.RightLegID + "','" + GlobalVars.LeftLegID + "','" + GlobalVars.Custom_IconType + "');" + quote;
			}
			try
			{
				Process.Start(rbxexe, args);
			}
			catch (Exception ex)
			{
				DialogResult result2 = MessageBox.Show("Failed to launch RBXLegacy. (Error: " + ex.Message + ")","RBXLegacy Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
			
		// relevance
		// TODO: make it make certain "clothe palletes" appear
		
 		void RadioButton5CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.AdTheme = 2008;
		}
		
		void RadioButton6CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.AdTheme = 2009;
		}
		
		void RadioButton7CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.AdTheme = 2010;
		}
		
		void RadioButton8CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.AdTheme = 2011;
		}
		
		void RadioButton9CheckedChanged(object sender, EventArgs e)
		{
			GlobalVars.AdTheme = 2012;
		}
		
		void Page2PanelPaint(object sender, PaintEventArgs e)
		{
			
		}
	}
}
