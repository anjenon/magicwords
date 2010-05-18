using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JRoland.MagicWords.LiberkeyPlugin
{
    public class AddSoftwareListPlugin : JRoland.MagicWords.Interfaces.ITool
    {
        private string m_Alias;
		private Shortcut m_HotKey;

        public AddSoftwareListPlugin()
		{
			m_Alias = "liberkey";
			m_HotKey = Shortcut.None;
		}

        #region ITool Members

        public string Name
        {
            get { return "Liberkey"; }
        }

        public string Description
        {
            get { return "Add liberkey software to be run through magic word"; }
        }

        public string Author
        {
            get { return "john roland"; }
        }

        public string Version
        {
            get { return "1.0.0.0"; }
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Execute(string[] args)
        {
            throw new NotImplementedException();
        }

        public System.Windows.Forms.Shortcut HotKey
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

        public string Alias
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
