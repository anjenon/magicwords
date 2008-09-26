using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace Serialcoder.MagicWords.MultiScreenPlugin
{
	class MoveToNextScreenPlugin : Serialcoder.MagicWords.Interfaces.ITool
	{
		private string m_Alias;
		private Shortcut m_HotKey;

		public MoveToNextScreenPlugin()
		{
			m_Alias = "ns";
			m_HotKey = Shortcut.CtrlF6;
		}

		#region ITool Members

		string Serialcoder.MagicWords.Interfaces.ITool.Name
		{
			get { return "Move current application to next screen"; }
		}

		string Serialcoder.MagicWords.Interfaces.ITool.Description
		{
			get { return "Move the current application to the next screen"; }
		}

		string Serialcoder.MagicWords.Interfaces.ITool.Author
		{
			get { return "John Roland"; }
		}

		string Serialcoder.MagicWords.Interfaces.ITool.Version
		{
			get { return "1.0"; }
		}

		void Serialcoder.MagicWords.Interfaces.ITool.Initialize()
		{
			
		}

		void Serialcoder.MagicWords.Interfaces.ITool.Execute(string[] args)
		{
			ToggleScreen();
		}

		private void ToggleScreen()
		{
			if (Screen.AllScreens.Length > 1)
			{
				//IntPtr hwnd = (IntPtr)Serialcoder.MagicWords.Components.NativeWIN32.GetForegroundWindow();

				Process process = Serialcoder.MagicWords.Components.NativeWIN32.GetFocusedProcess();
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
				
				//Serialcoder.MagicWords.Components.NativeWIN32.SetWindowPos(hwnd, Serialcoder.MagicWords.Components.NativeWIN32.HWND_TOP, screen.WorkingArea.X, screen.WorkingArea.Y, screen.WorkingArea.Width, screen.WorkingArea.Height, Serialcoder.MagicWords.Components.NativeWIN32.SWP_SHOWWINDOW);

				Serialcoder.MagicWords.Components.NativeWIN32.MoveWindow(hwnd, screen.WorkingArea.X, screen.WorkingArea.Y, screen.WorkingArea.Width, screen.WorkingArea.Height, true);
				Serialcoder.MagicWords.Components.NativeWIN32.UpdateWindow(hwnd);
			}
		}

		[Editor(@"System.Windows.Forms.Design.ShortcutKeysEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
		Shortcut Serialcoder.MagicWords.Interfaces.ITool.HotKey
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

		string Serialcoder.MagicWords.Interfaces.ITool.Alias
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
