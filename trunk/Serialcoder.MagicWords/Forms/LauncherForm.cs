using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Serialcoder.MagicWords.Forms
{
	public partial class LauncherForm : Form
	{
		public LauncherForm()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.Size = uxInputText.Size;

			uxInputText.AutoCompleteMode = AutoCompleteMode.Append;
			uxInputText.AutoCompleteSource = AutoCompleteSource.CustomSource;
			AutoCompleteStringCollection sr = new AutoCompleteStringCollection();
			sr.AddRange(Context.Current.AutoCompleteSource);
						
			uxInputText.AutoCompleteCustomSource = sr;

			// position on bottom right
			this.StartPosition = FormStartPosition.Manual;
			this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
			this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
		}
		

		private void OnInputTextBoxKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				string alias = uxInputText.Text;
				this.Close();
				Context.Current.Start(alias);
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			Properties.Settings.Default.Position = this.Location;
			Properties.Settings.Default.Size = this.Size;
			Properties.Settings.Default.Save();
		
		}
		
		private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context.Current.Exit();
		}

		private void OnHideToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnSetupToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context.Current.Setup();
		}

		private void OnHelpToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context.Current.Help();
		}

		private void OnNewMagicWordToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context.Current.ShowNewMagicWordForm();
		}

		private void uxInputContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			uxMagicWordsToolStripMenuItem.DropDownItems.Clear();

			foreach (Entities.MagicWord word in Context.Current.MagicWords)
			{
				ToolStripMenuItem item = new ToolStripMenuItem(word.Alias);
				item.Click += new EventHandler(delegate(object source, EventArgs args) {
					Context.Current.Start(word.Alias);
				});
			}
		}
	}
}