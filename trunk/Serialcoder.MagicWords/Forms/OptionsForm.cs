using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Serialcoder.MagicWords.Forms
{
	public partial class OptionsForm : Form
	{
		public OptionsForm()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			dataGridView1.DataSource = Context.Current.Tools;
			propertyGrid1.SelectedObject = Properties.Settings.Default;
		}

		private void uxCancelButton_Click(object sender, EventArgs e)
		{			
			this.DialogResult = DialogResult.Cancel;
		}

		private void uxAcceptButton_Click(object sender, EventArgs e)
		{			
			this.DialogResult = DialogResult.OK;
		}

		private void OnWebsiteLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://code.google.com/p/magicwords/");
		}

		private void OnImportLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "Import a SlickRun qrs file...";
			dialog.Filter = "SlickRun files (*.qrs)|*.qrs";
			dialog.CheckFileExists = true;
			dialog.CheckPathExists = true;
			dialog.Multiselect = false;
			
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Context.Current.MagicWords.AddRange(SlickRunHelper.ImportFile(dialog.FileName));
					MessageBox.Show(dialog.FileName + " imported successfully.");
				}
				catch (Exception exception)
				{
					MessageBox.Show("An error occured: " + exception.Message);
				}
				
			}
		}

		private void OnExportLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Title = "Export library...";
			dialog.Filter = "SlickRun files (*.qrs)|*.qrs";
			//dialog.CheckFileExists = true;
			//dialog.CheckPathExists = true;
			dialog.AddExtension = true;

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					SlickRunHelper.ExportFile(Context.Current.MagicWords, dialog.FileName);
					MessageBox.Show(dialog.FileName + " exported successfully.");
				}
				catch (Exception exception)
				{
					MessageBox.Show("An error occured: " + exception.Message);
				}
			}
		}
	}
}