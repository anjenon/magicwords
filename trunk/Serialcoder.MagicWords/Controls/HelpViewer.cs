using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JRoland.MagicWords.Controls
{
	public partial class HelpViewer : UserControl
	{
		public HelpViewer()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			webBrowser1.Url = new Uri(Properties.Settings.Default.HelpUrl);
		}
	}
}
