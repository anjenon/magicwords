using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JRoland.MagicWords.Parameters
{
	public class FilePathParameter : Interfaces.IParameter
	{
		#region IParameter Members

		string JRoland.MagicWords.Interfaces.IParameter.Variable
		{
			get { return "$FILE$"; }
		}

		string JRoland.MagicWords.Interfaces.IParameter.Description
		{
			get { return "Open a file selector"; }
		}

		bool JRoland.MagicWords.Interfaces.IParameter.GetValue(string magicWordNotes, out string variableValue)
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
