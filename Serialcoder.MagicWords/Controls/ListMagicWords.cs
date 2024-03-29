using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JRoland.MagicWords.Controls
{
	public partial class ListMagicWords : UserControl
	{
		public ListMagicWords()
		{
			InitializeComponent();
			uxDataGridView.AutoGenerateColumns = false;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			uxModesColumn.DataSource = Enum.GetValues(typeof (System.Diagnostics.ProcessWindowStyle));

			if (DesignMode == false)
			{
				bindingSource1.DataSource = Context.Current.MagicWords;
			}
			
		}

		private void OnDataGridViewCellParsing(object sender, DataGridViewCellParsingEventArgs e)
		{
			if (e.ColumnIndex == uxModesColumn.Index && e.Value is string)
			{
				e.Value = (Object)Enum.Parse(typeof(System.Diagnostics.ProcessWindowStyle), e.Value.ToString(), true);
				e.ParsingApplied = true;
			}
		}

		
		private void OnDataGridViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == uxModesColumn.Index &&  e.Value is System.Diagnostics.ProcessWindowStyle)
			{
				e.Value = e.Value.ToString();
				e.FormattingApplied = true;
			}
		}

		private void OnDataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			Console.WriteLine(e.Exception);
			Console.WriteLine(e.RowIndex);
		}
	}
}
