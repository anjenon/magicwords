using System;
using System.Collections.Generic;
using System.Text;

namespace Serialcoder.MagicWords.Parameters
{
	public class ClipboardParameter : Interfaces.IParameter
	{
		#region IParameter Members

		string Serialcoder.MagicWords.Interfaces.IParameter.Variable
		{
			get { return "$C$"; }
		}

		string Serialcoder.MagicWords.Interfaces.IParameter.Description
		{
			get { return "Replace the $C$ placeholder by the clipboard text."; }
		}

		bool Serialcoder.MagicWords.Interfaces.IParameter.GetValue(string magicWordNotes, out string output)
		{
			output = System.Windows.Forms.Clipboard.GetText();
			return true; // user cannot cancel
		}

		#endregion
	}
}
