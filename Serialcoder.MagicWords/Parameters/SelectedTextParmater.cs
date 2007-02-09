using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Serialcoder.MagicWords.Parameters
{
	public class SelectedTextParmater : Interfaces.IParameter
	{
		#region IParameter Members

		string Serialcoder.MagicWords.Interfaces.IParameter.Variable
		{
			get { return "$S$"; }
		}

		string Serialcoder.MagicWords.Interfaces.IParameter.Description
		{
			get { return "Replace the variable with the current selected text"; }
		}

		bool Serialcoder.MagicWords.Interfaces.IParameter.GetValue(string magicWordNotes, out string variableValue)
		{
			string oldClipboard = Clipboard.GetText();

			IntPtr handle = (IntPtr)Components.NativeWIN32.GetForegroundWindow();
			int result = Components.NativeWIN32.SendMessage(handle, WM_COPY, IntPtr.Zero, IntPtr.Zero);

			variableValue = Clipboard.GetText();

			Clipboard.SetText(oldClipboard);
			return true;
		}

		#endregion

		const int WM_COPY = 0x301;

		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll",CharSet=CharSet.Auto)]
		private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam,	IntPtr lParam);
	}
}
