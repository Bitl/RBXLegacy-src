using System;
using System.Windows.Forms;

namespace RBXLegacyLauncher
{
	internal sealed class Program
	{
		static string ProcessInput(string s)
    	{
       		return s;
    	}
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
