using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Serialcoder.MagicWords.ScratchPadPlugin
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

		string Serialcoder.MagicWords.Interfaces.ITool.Name
		{
			get { return "ScratPad plugin"; }
		}

		string Serialcoder.MagicWords.Interfaces.ITool.Description
		{
			get { return "The ScratchPad is a simple text editor to collect and keep text."; }
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
			// todo restore settings
		}

		void Serialcoder.MagicWords.Interfaces.ITool.Execute(string[] args)
		{
			
			ScratchPad.Current.Show();
			ScratchPad.Current.Left = Screen.PrimaryScreen.WorkingArea.Width - ScratchPad.Current.Width;
			ScratchPad.Current.Top = Screen.PrimaryScreen.WorkingArea.Height - ScratchPad.Current.Height;

			ScratchPad.Current.Select();
			ScratchPad.Current.Focus();
		}
		
		private Shortcut m_HotKey;
		private string m_Alias;

 
		System.Windows.Forms.Shortcut Serialcoder.MagicWords.Interfaces.ITool.HotKey
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
