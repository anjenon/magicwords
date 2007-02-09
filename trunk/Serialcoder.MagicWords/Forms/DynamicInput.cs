using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Serialcoder.MagicWords.Forms
{
	public partial class DynamicInput : Form
	{
		public DynamicInput()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (Properties.Settings.Default.ArgumentHistory == null)
			{
				Properties.Settings.Default.ArgumentHistory = new System.Collections.Specialized.StringCollection();
			}
			uxArgumentComboBox.DataSource = Properties.Settings.Default.ArgumentHistory;

			uxArgumentComboBox.Focus();
			uxArgumentComboBox.Select();
			uxArgumentComboBox.Focus();
		}

		public string Input
		{
			get
			{
				return uxArgumentComboBox.Text;
			}
		}

		public string EncodedInput
		{
			get
			{
				return System.Web.HttpUtility.UrlEncode(uxArgumentComboBox.Text);
			}
		}

		public string Title
		{
			set
			{
				uxNotesLabel.Text = value;
			}
		}
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);

			if (Properties.Settings.Default.ArgumentHistory == null)
			{
				Properties.Settings.Default.ArgumentHistory = new System.Collections.Specialized.StringCollection();
			}

			if (DialogResult == DialogResult.OK && string.IsNullOrEmpty(uxArgumentComboBox.Text) == false && Properties.Settings.Default.ArgumentHistory.Contains(uxArgumentComboBox.Text) == false)
			{
				Properties.Settings.Default.ArgumentHistory.Add(uxArgumentComboBox.Text);
			}
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
						
			
		}
	}
}