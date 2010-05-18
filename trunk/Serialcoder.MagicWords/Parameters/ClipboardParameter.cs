using System;
using System.Collections.Generic;
using System.Text;

namespace JRoland.MagicWords.Parameters
{
	public class ClipboardParameter : Interfaces.IParameter
	{
		#region IParameter Members

		string JRoland.MagicWords.Interfaces.IParameter.Variable
		{
			get { return "$C$"; }
		}

		string JRoland.MagicWords.Interfaces.IParameter.Description
		{
			get { return "Replace the $C$ placeholder by the clipboard text."; }
		}

		bool JRoland.MagicWords.Interfaces.IParameter.GetValue(string magicWordNotes, out string output)
		{
			output = System.Windows.Forms.Clipboard.GetText();
			return true; // user cannot cancel
		}

		#endregion
	}
}
