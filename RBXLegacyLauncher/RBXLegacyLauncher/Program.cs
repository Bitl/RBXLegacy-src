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
			if (args.Length == 0)
			{
				Application.Run(new MainForm());
			}
			else
			{
				foreach (string s in args)
      			{
        			GlobalVars.SharedArgs = ProcessInput(s);
      			}
				Application.Run(new LoaderForm());
			}
		}
		
	}
}
