using System;
using System.Collections.Generic;
using System.Text;

namespace Serialcoder.MagicWords.Interfaces
{
	public interface IParameter
	{
		string Variable { get;}
		string Description { get;}

		/// <summary>
		/// Gets the value that will replace the variable.
		/// </summary>
		/// <param name="magicWordNotes">The magic word notes.</param>
		/// <param name="variableValue">The value that will replace the variable.</param>
		/// <returns>false if the user has cancelled; true otherwise</returns>
		bool GetValue(string magicWordNotes, out string variableValue);
	}
}
