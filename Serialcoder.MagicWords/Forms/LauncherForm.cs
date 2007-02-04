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
			this.Size = textBox1.Size;

			textBox1.AutoCompleteMode = AutoCompleteMode.Append;
			textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
			AutoCompleteStringCollection sr = new AutoCompleteStringCollection();
			sr.AddRange(Context.Current.AutoCompleteSource);

			
			textBox1.AutoCompleteCustomSource = sr;

			// position on bottom right
			this.StartPosition = FormStartPosition.Manual;
			this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
			this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
		}
		

		private void textBox1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				string alias = textBox1.Text;
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
		
		private void uxExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Context.Current.Exit();
		}

		private void uxHideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void uxSetupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Context.Current.Setup();
		}

	}
}