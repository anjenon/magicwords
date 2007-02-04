using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Serialcoder.MagicWords
{
	class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (Properties.Settings.Default.RunAtWindowsStart)
			{
				RunOnStart("MagicWords", Application.ExecutablePath);
			}
			else
			{
				RemoveRunOnStart("MagicWords");
			}
			
			MagicWordsApplicationContext applicationContext = new MagicWordsApplicationContext();
			Application.Run(applicationContext);
		}



		private static void RunOnStart(string Libele, string Fichier)
		{
			Microsoft.Win32.RegistryKey Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			Key.SetValue(Libele, Fichier);
			Key.Close();
			Key = null;
		}

		private static void RemoveRunOnStart(string keyName)
		{
			try
			{
				Microsoft.Win32.RegistryKey Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
				Key.DeleteSubKey(keyName);
				Key.Close();
				Key = null;
			}
			catch (Exception)
			{
				//throw;
			}
			
		}


	}
}
