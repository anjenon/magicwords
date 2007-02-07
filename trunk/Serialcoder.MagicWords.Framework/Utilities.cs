using System;
using System.Collections.Generic;
using System.Text;

namespace Serialcoder.MagicWords
{
	/// <summary>
	/// Exposes some usefull helpers. need to be sorted out.
	/// </summary>
	public static class Utilities
	{
		public static void RunOnStart(string appName, string appPath)
		{
			Microsoft.Win32.RegistryKey Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			Key.SetValue(appName, appPath);
			Key.Close();
			Key = null;
		}

		public static void RemoveRunOnStart(string appName)
		{
			try
			{
				Microsoft.Win32.RegistryKey Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
				Key.DeleteSubKey(appName);
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
