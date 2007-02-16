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

		public ScratchPad()
		{
			InitializeComponent();

			this.Size = new Size(300, Screen.PrimaryScreen.WorkingArea.Height);
			this.FormClosing += new FormClosingEventHandler(ScratchPad_FormClosing);

			//m_file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MagicWordsScratchPad.txt";
			//if (System.IO.File.Exists(m_file))
			//{
			//    richTextBox1.LoadFile(m_file, RichTextBoxStreamType.PlainText);
			//}
			richTextBox1.DataBindings.Add("Text", Properties.Settings.Default, "ScratchPadText", false, DataSourceUpdateMode.OnPropertyChanged);
			//richTextBox1.Text = Properties.Settings.Default.ScratchPadText;
		}

		void ScratchPad_FormClosing(object sender, FormClosingEventArgs e)
		{
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