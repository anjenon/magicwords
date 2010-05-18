using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace JRoland.MagicWords.MultiScreenPlugin
{
	class MoveToNextScreenPlugin : JRoland.MagicWords.Interfaces.ITool
	{
		private string m_Alias;
		private Shortcut m_HotKey;

		public MoveToNextScreenPlugin()
		{
			m_Alias = "ns";
			m_HotKey = Shortcut.CtrlF6;
		}

		#region ITool Members

		string JRoland.MagicWords.Interfaces.ITool.Name
		{
			get { return "Move current application to next screen"; }
		}

		string JRoland.MagicWords.Interfaces.ITool.Description
		{
			get { return "Move the current application to the next screen"; }
		}

		string JRoland.MagicWords.Interfaces.ITool.Author
		{
			get { return "John Roland"; }
		}

		string JRoland.MagicWords.Interfaces.ITool.Version
		{
			get { return "1.0"; }
		}

		void JRoland.MagicWords.Interfaces.ITool.Initialize()
		{
			
		}

		void JRoland.MagicWords.Interfaces.ITool.Execute(string[] args)
		{
			ToggleScreen();
		}

		private void ToggleScreen()
		{
			if (Screen.AllScreens.Length > 1)
			{
				//IntPtr hwnd = (IntPtr)JRoland.MagicWords.Components.NativeWIN32.GetForegroundWindow();

				Process process = JRoland.MagicWords.Components.NativeWIN32.GetFocusedProcess();
				IntPtr hwnd = process.MainWindowHandle;


				Screen currentScreen = Screen.FromHandle(hwnd);
				int currentScreenIndex = -1;
				for (int i = 0; i < Screen.AllScreens.Length; i++)
				{
					if (currentScreen.Bounds == Screen.AllScreens[i].Bounds)
					{
						currentScreenIndex = i;
					}
				}

				// Determine new screen index, and move form to it
				int newScreenIndex = (currentScreenIndex + 1) % Screen.AllScreens.Length;
				Screen screen = Screen.AllScreens[newScreenIndex];
				
				//JRoland.MagicWords.Components.NativeWIN32.SetWindowPos(hwnd, JRoland.MagicWords.Components.NativeWIN32.HWND_TOP, screen.WorkingArea.X, screen.WorkingArea.Y, screen.WorkingArea.Width, screen.WorkingArea.Height, JRoland.MagicWords.Components.NativeWIN32.SWP_SHOWWINDOW);

				JRoland.MagicWords.Components.NativeWIN32.MoveWindow(hwnd, screen.WorkingArea.X, screen.WorkingArea.Y, screen.WorkingArea.Width, screen.WorkingArea.Height, true);
				JRoland.MagicWords.Components.NativeWIN32.UpdateWindow(hwnd);
			}
		}

		[Editor(@"System.Windows.Forms.Design.ShortcutKeysEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
		Shortcut JRoland.MagicWords.Interfaces.ITool.HotKey
		{
			get
			{
				return m_HotKey;
			}
			set
			{
				m_HotKey = value;
			}
		}

		string JRoland.MagicWords.Interfaces.ITool.Alias
		{
			get
			{
				return m_Alias;
			}
			set
			{
				m_Alias = value;
			}
		}

		#endregion
	}
}
