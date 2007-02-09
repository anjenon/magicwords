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
		private LauncherForm()
		{
			InitializeComponent();
		}

		#region Singleton

		private static volatile LauncherForm _singleton;
		private static object syncRoot = new Object();

		public static LauncherForm Current
		{
			get
			{
				if (_singleton == null)
				{
					lock (syncRoot)
					{
						if (_singleton == null)
						{
							_singleton = new LauncherForm();
						}
					}
				}

				return _singleton;
			}
		}
		#endregion
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.Size = uxInputText.Size;

			UpdateAutoCompletion();

			// position on bottom right
			this.StartPosition = FormStartPosition.Manual;
			this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
			this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;

		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			UpdateAutoCompletion();

			Select();
			Activate();
		}

		public void UpdateAutoCompletion()
		{
			uxInputText.AutoCompleteMode = AutoCompleteMode.Append;
			uxInputText.AutoCompleteSource = AutoCompleteSource.CustomSource;
			AutoCompleteStringCollection sr = new AutoCompleteStringCollection();
			sr.AddRange(Context.Current.AutoCompleteSource);

			uxInputText.AutoCompleteCustomSource = sr;
		}
		

		private void OnInputTextBoxKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				string alias = uxInputText.Text;
				this.HideForm();
				Context.Current.Start(alias);
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.HideForm();
			}
		}

		/// <summary>
		/// Hides the form.
		/// </summary>
		private void HideForm()
		{
			this.Hide();

			Properties.Settings.Default.Position = this.Location;
			Properties.Settings.Default.Size = this.Size;
			Properties.Settings.Default.Save();			
		}

		//protected override void OnClosing(CancelEventArgs e)
		//{
		//    base.OnClosing(e);

		//    Properties.Settings.Default.Position = this.Location;
		//    Properties.Settings.Default.Size = this.Size;
		//    Properties.Settings.Default.Save();
		
		//}

		
		private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context.Current.Exit();
		}

		private void OnHideToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (this.Visible)
			{
				this.HideForm();
			}
			else
			{
				this.Show();
			}
			
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
			// update the show/hide input bar
			uxHideToolStripMenuItem.Text = this.Visible ? "Hide command line" : "Show command line";
			
			// adding magicwords
			uxMagicWordsToolStripMenuItem.DropDownItems.Clear();
			Context.Current.MagicWords.Sort(delegate(Entities.MagicWord w1, Entities.MagicWord w2) { return w1.Alias.CompareTo(w2.Alias); });
			foreach (Entities.MagicWord word in Context.Current.MagicWords)
			{
				ToolStripMenuItem item = new ToolStripMenuItem(word.Alias);
				item.Click += new EventHandler(delegate(object source, EventArgs args)
				{
					Context.Current.Start(item.Text);
				});
				uxMagicWordsToolStripMenuItem.DropDownItems.Add(item);
			}
		}
	}
}