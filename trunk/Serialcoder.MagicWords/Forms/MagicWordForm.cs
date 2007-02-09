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
			uxStartupPathTextBox.DataBindings.Add("Text", MagicWord, "WorkingDirectory", false, DataSourceUpdateMode.OnPropertyChanged);
		}

		private void uxStartupModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			MagicWord.StartUpMode = (System.Diagnostics.ProcessWindowStyle)uxStartupModeComboBox.SelectedValue;
		}

		private void OnFilenameTextBoxDoubleClick(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "Select a file...";
			dialog.Filter = "All files (*.*)|*.*|Executables (*.exe)|*.exe";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				uxFilenameTextBox.Text = dialog.FileName;
			}
		}

		private void OnStartupPathTextBoxDoubleClick(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "Select the working directory...";
			dialog.ShowNewFolderButton = true;
			
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				uxStartupPathTextBox.Text = dialog.SelectedPath;
			}
		}

	}
}