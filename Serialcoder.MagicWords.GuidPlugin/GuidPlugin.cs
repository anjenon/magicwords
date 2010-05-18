using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JRoland.MagicWords.GuidPlugin
{
	public class GuidPlugin : JRoland.MagicWords.Interfaces.ITool
	{
		private string m_Alias;
		private Shortcut m_HotKey;

		public GuidPlugin()
		{
			m_Alias = "guid";
			m_HotKey = Shortcut.CtrlF1;
		}

		#region ITool Members

		string JRoland.MagicWords.Interfaces.ITool.Name
		{
			get { return "Générateur Guid"; }
		}

		string JRoland.MagicWords.Interfaces.ITool.Description
		{
			get { return "Génère un identifiant unique Guid"; }
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
			Clipboard.SetText(Guid.NewGuid().ToString());
		}

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
