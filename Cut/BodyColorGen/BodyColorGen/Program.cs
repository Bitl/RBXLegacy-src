/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 5/24/2017
 * Time: 7:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.IO;

namespace BodyColorGen
{
	class Program
	{
		public static int Main(string[] args)
		{
			Console.Title = "RBXLegacy - Body Color Generator";
			
			// Test if input arguments were supplied:
        	if (args.Length == 0)
        	{
            	Console.WriteLine("Usage: BodyColorGen <number>");
            	Console.WriteLine("Number Values:");
            	Console.WriteLine("0 = All possible combos");
            	Console.WriteLine("1 = 2006 style patterns");
            	Console.WriteLine("2 = Shirt and Pants");
            	return 1;
        	}
        	
        	int num;
        	bool test = int.TryParse(args[0], out num);
        	if (test == false)
        	{
            	Console.WriteLine("Usage: BodyColorGen <number>");
            	Console.WriteLine("Number Values:");
            	Console.WriteLine("0 = All possible combos");
            	Console.WriteLine("1 = 2006 style patterns");
            	Console.WriteLine("2 = Shirt and Pants");
            	return 1;
        	}
			
			int[] colorArray = new int[32] {1,208,194,199,26,21,24,226,23,107,102,11,45,135,106,105,141,28,37,119,29,151,38,192,104,9,101,5,153,217,18,125};
			int HeadColor,TorsoColor,LArmColor,RArmColor,LLegColor,RLegColor;
			int FleshColor,ShirtColor,PantsColor;
			while (true)
			{
				Random rand = new Random();
				if (num == 1)
				{
					FleshColor = rand.Next(colorArray.Length);
					ShirtColor = rand.Next(colorArray.Length);
					PantsColor = rand.Next(colorArray.Length);
					HeadColor = colorArray[FleshColor];
					TorsoColor = colorArray[ShirtColor];
					LArmColor = colorArray[FleshColor];
					RArmColor = colorArray[FleshColor];
					LLegColor = colorArray[PantsColor];
					RLegColor = colorArray[PantsColor];
				}
				else if (num == 2)
				{
					FleshColor = rand.Next(colorArray.Length);
					ShirtColor = rand.Next(colorArray.Length);
					PantsColor = rand.Next(colorArray.Length);
					HeadColor = colorArray[FleshColor];
					TorsoColor = colorArray[ShirtColor];
					LArmColor = colorArray[ShirtColor];
					RArmColor = colorArray[ShirtColor];
					LLegColor = colorArray[PantsColor];
					RLegColor = colorArray[PantsColor];
				}
				else
				{
					HeadColor = colorArray[rand.Next(colorArray.Length)];
					TorsoColor = colorArray[rand.Next(colorArray.Length)];
					LArmColor = colorArray[rand.Next(colorArray.Length)];
					RArmColor = colorArray[rand.Next(colorArray.Length)];
					LLegColor = colorArray[rand.Next(colorArray.Length)];
					RLegColor = colorArray[rand.Next(colorArray.Length)];
				}
				string dirname = "bodycolors/";
				if(!Directory.Exists(dirname))
				{
   					 System.IO.Directory.CreateDirectory(dirname);
				}
            	string filename = dirname + HeadColor + "-" + TorsoColor + "-" + LArmColor + "-" + RArmColor + "-" + LLegColor + "-" + RLegColor +".rbxm";
            	if (!File.Exists(filename))
            	{
            		Console.ForegroundColor = ConsoleColor.Green;
            		Console.WriteLine("Writing " + filename);
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
			}
		}
	}
}