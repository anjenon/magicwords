using System;
using System.Collections.Generic;
using System.Text;

namespace JRoland.MagicWords.TranslatorPlugin
{
	public class TranslatorPlugin : Interfaces.ITool
	{
		public TranslatorPlugin()
		{
			m_Alias = "translator";
			m_Hotkey = System.Windows.Forms.Shortcut.ShiftF3;
		}

		#region ITool Members

		string JRoland.MagicWords.Interfaces.ITool.Name
		{
			get { return "Translator plugin"; }
		}

		string JRoland.MagicWords.Interfaces.ITool.Description
		{
			get { return "This is a Google Translator wrapper"; }
		}

		string JRoland.MagicWords.Interfaces.ITool.Author
		{
			get { return "John Roland"; }
		}

		string JRoland.MagicWords.Interfaces.ITool.Version
		{
			get { return "1.1"; }
		}

		void JRoland.MagicWords.Interfaces.ITool.Initialize()
		{
			//
		}

		void JRoland.MagicWords.Interfaces.ITool.Execute(string[] args)
		{
			MainForm form = new MainForm();
			form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			form.Select();
			form.Focus();
			form.ShowDialog();
		}

		System.Windows.Forms.Shortcut JRoland.MagicWords.Interfaces.ITool.HotKey
		{
			get
			{
				return m_Hotkey;
			}
			set
			{
				m_Hotkey = value;
			}
		}

		private string m_Alias;
		private System.Windows.Forms.Shortcut m_Hotkey;

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
