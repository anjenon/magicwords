using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Serialcoder.MagicWords.ScreenShotPlugin
{
	public class ScreenshotPlugin : Serialcoder.MagicWords.Interfaces.ITool
	{
		private string m_Alias;
		private Shortcut m_HotKey;

		public ScreenshotPlugin()
		{
			m_Alias = "screenshot";
			m_HotKey = Shortcut.ShiftF1;
		}

		#region ITool Members

		void Serialcoder.MagicWords.Interfaces.ITool.Initialize()
		{
			
		}

		void Serialcoder.MagicWords.Interfaces.ITool.Execute(string[] args)
		{
			IntPtr hwnd = (IntPtr)Components.NativeWIN32.GetForegroundWindow();

			
			System.Drawing.Bitmap image = Capture.GrabWindow(hwnd);
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.AddExtension = true;
			dialog.DefaultExt = "*.png";
			dialog.Filter = "Png files (*.png)|*.png";
			dialog.Title = "Save the screenshot...";
			
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				image.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
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
				
		string Serialcoder.MagicWords.Interfaces.ITool.Name
		{
			get { return "Screenshot maker"; }
		}

		string Serialcoder.MagicWords.Interfaces.ITool.Description
		{
			get { return "Take a screenshot of the current windows and save it as a PNG file"; }
		}

		string Serialcoder.MagicWords.Interfaces.ITool.Author
		{
			get { return "John Roland"; }
		}

		string Serialcoder.MagicWords.Interfaces.ITool.Version
		{
			get { return "1.0"; }
		}

		#endregion
	}
}
