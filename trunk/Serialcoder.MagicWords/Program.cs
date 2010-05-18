using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JRoland.MagicWords
{
	class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			MagicWordsApplicationContext applicationContext = new MagicWordsApplicationContext();
			Application.Run(applicationContext);
		}
	}
}
