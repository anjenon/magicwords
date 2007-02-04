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
	}
}