using System;
using System.Collections.Generic;
using System.Text;

namespace Serialcoder.MagicWords.Interfaces
{
	public interface ITool
	{
		string Name { get;}
		string Description { get;}
		string Author { get;}
		string Version { get;}

		void Initialize();
		void Execute(string[] args);

		// configurable
		System.Windows.Forms.Shortcut HotKey { get; set;}
		string Alias { get; set;}
	}
}
