using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Serialcoder.MagicWords.Parameters
{
	public class FilePathParameter : Interfaces.IParameter
	{
		#region IParameter Members

		string Serialcoder.MagicWords.Interfaces.IParameter.Variable
		{
			get { return "$FILE$"; }
		}

		string Serialcoder.MagicWords.Interfaces.IParameter.Description
		{
			get { return "Open a file selector"; }
		}

		bool Serialcoder.MagicWords.Interfaces.IParameter.GetValue(string magicWordNotes, out string variableValue)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "Select a file please";
			dialog.Filter = "All Files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				variableValue = dialog.FileName;
				return true;
			}
			else
			{
				variableValue = string.Empty;
				return false;
			}
		}

		#endregion
	}
}
