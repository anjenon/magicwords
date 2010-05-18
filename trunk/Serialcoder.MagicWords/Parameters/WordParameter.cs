using System;
using System.Collections.Generic;
using System.Text;

namespace JRoland.MagicWords.Parameters
{
	public class WordParameter : Interfaces.IParameter
	{
		#region IParameter Members

		string JRoland.MagicWords.Interfaces.IParameter.Variable
		{
			get { return "$W$"; }
		}

		string JRoland.MagicWords.Interfaces.IParameter.Description
		{
			get { return "Replace the $W$ placeholder by an url encoded user input."; }
		}

		bool JRoland.MagicWords.Interfaces.IParameter.GetValue(string magicWordNotes, out string output)
		{
			// the value that will replace the $param$
			output = string.Empty;
						
			Forms.DynamicInput form = new Forms.DynamicInput();
			form.Title = magicWordNotes;
			switch (form.ShowDialog())
			{
				case System.Windows.Forms.DialogResult.OK:
					output = form.EncodedInput;
					break;
				
				case System.Windows.Forms.DialogResult.Cancel:
					return false;

				default:
					break;
			}
			
			return true;
		}

		#endregion
	}
}
