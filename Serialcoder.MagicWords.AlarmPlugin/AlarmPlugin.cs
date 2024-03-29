using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JRoland.MagicWords.AlarmPlugin
{
	public class AlarmPlugin : Interfaces.ITool
	{
		public AlarmPlugin()
		{
			m_Alias = "alarm";
			m_Hotkey = System.Windows.Forms.Shortcut.ShiftF4;
		}

		#region ITool Members

		string JRoland.MagicWords.Interfaces.ITool.Name
		{
			get { return "Alarm plugin"; }
		}

		string JRoland.MagicWords.Interfaces.ITool.Description
		{
			get { return "This plugin allow you to be alerted on a particular time."; }
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
			Console.WriteLine(AlarmForm.Current.Name);
			//throw new Exception("The method or operation is not implemented.");
		}

		void JRoland.MagicWords.Interfaces.ITool.Execute(string[] args)
		{
			AlarmForm.Current.Show();
		}

		[Editor(@"System.Windows.Forms.Design.ShortcutKeysEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
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
