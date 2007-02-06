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

		public string Input
		{
			get
			{
				return comboBox1.Text;
			}
		}

		public string EncodedInput
		{
			get
			{
				return System.Web.HttpUtility.UrlEncode(comboBox1.Text);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		public string Title
		{
			set
			{
				uxNotesLabel.Text = value;
			}
		}
	}
}