using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Serialcoder.MagicWords.Forms
{
	public partial class MagicWordForm : Form
	{
		public MagicWordForm()
		{
			InitializeComponent();
		}

		private Entities.MagicWord m_MagicWord;

		public Entities.MagicWord MagicWord
		{
			get { return this.m_MagicWord; }
			set { this.m_MagicWord = value; }
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			uxStartupModeComboBox.DataSource = Enum.GetValues(typeof(System.Diagnostics.ProcessWindowStyle));
			
			uxAliasTextBox.DataBindings.Add("Text", MagicWord, "Alias", false, DataSourceUpdateMode.OnPropertyChanged);
			uxFilenameTextBox.DataBindings.Add("Text", MagicWord, "FileName", false, DataSourceUpdateMode.OnPropertyChanged);
			uxArgumentsTextBox.DataBindings.Add("Text", MagicWord, "Arguments", false, DataSourceUpdateMode.OnPropertyChanged);
			uxNotesTextBox.DataBindings.Add("Text", MagicWord, "Notes", false, DataSourceUpdateMode.OnPropertyChanged);
		}

	}
}