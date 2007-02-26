using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Serialcoder.MagicWords.ScratchPadPlugin
{
	public partial class ScratchPad : Form
	{
		//private string m_file;

		private ScratchPad()
		{
			InitializeComponent();

			this.Size = new Size(300, Screen.PrimaryScreen.WorkingArea.Height);
			richTextBoxExtended1.RichTextBox.Text = Properties.Settings.Default.ScratchPadText;
		}

		void ScratchPad_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.ScratchPadText = richTextBoxExtended1.RichTextBox.Text;
			Properties.Settings.Default.Save();

			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				this.Hide();
			}			
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			Select();
			Activate();
		}

		#region Singleton

		private static volatile ScratchPad _singleton;
		private static object syncRoot = new Object();

		public static ScratchPad Current
		{
			get
			{
				if (_singleton == null)
				{
					lock (syncRoot)
					{
						if (_singleton == null)
						{
							_singleton = new ScratchPad();
						}
					}
				}

				return _singleton;
			}
		}
		#endregion
				
	}
}