using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace JRoland.MagicWords.ScratchPadPlugin
{
	public class ScratchPadPlugin : Interfaces.ITool
	{
		public ScratchPadPlugin()
		{
			m_Alias = "scratchpad";
			m_HotKey = Shortcut.ShiftF2;
			//ScratchPad.Current.Size = new System.Drawing.Size(200, 200);
		}

		#region ITool Members

		string JRoland.MagicWords.Interfaces.ITool.Name
		{
			get { return "ScratPad plugin"; }
		}

		string JRoland.MagicWords.Interfaces.ITool.Description
		{
			get { return "The ScratchPad is a simple text editor to collect and keep text."; }
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
			// todo restore settings
		}

		void JRoland.MagicWords.Interfaces.ITool.Execute(string[] args)
		{
			
			ScratchPad.Current.Show();
			ScratchPad.Current.Left = Screen.PrimaryScreen.WorkingArea.Width - ScratchPad.Current.Width;
			ScratchPad.Current.Top = Screen.PrimaryScreen.WorkingArea.Height - ScratchPad.Current.Height;

			ScratchPad.Current.Select();
			ScratchPad.Current.Focus();
		}
		
		private Shortcut m_HotKey;
		private string m_Alias;


		[Editor(@"System.Windows.Forms.Design.ShortcutKeysEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
		System.Windows.Forms.Shortcut JRoland.MagicWords.Interfaces.ITool.HotKey
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
