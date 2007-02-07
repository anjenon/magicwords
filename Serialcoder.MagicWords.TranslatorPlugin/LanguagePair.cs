using System;
using System.Collections.Generic;
using System.Text;

namespace Serialcoder.MagicWords.TranslatorPlugin
{
	public class LanguagePair
	{
		private string _code;

		public string Code
		{
			get { return _code; }
			set { _code = value; }
		}

		private string _caption;

		public string Caption
		{
			get { return _caption; }
			set { _caption = value; }
		}


		public LanguagePair(string code, string caption)
		{
			_code = code;
			_caption = caption;
		}

		public static List<LanguagePair> GoogleLanguagePairs
		{
			get
			{
				List<LanguagePair> _lps = new List<LanguagePair>();
				_lps.Add(new LanguagePair("zh|en", "Du chinois simpl. vers l'anglais"));
				_lps.Add(new LanguagePair("zt|en", "Du chinois trad. vers l'anglais"));
				_lps.Add(new LanguagePair("en|zh", "De l'anglais vers le chinois simpl."));
				_lps.Add(new LanguagePair("en|zt", "De l'anglais vers le chinois trad."));
				_lps.Add(new LanguagePair("en|nl", "De l'anglais vers le hollandais"));
				_lps.Add(new LanguagePair("en|fr", "De l'anglais vers le fran�ais"));
				_lps.Add(new LanguagePair("en|de", "De l'anglais vers l'allemand"));
				_lps.Add(new LanguagePair("en|el", "De l'anglais vers le grec"));
				_lps.Add(new LanguagePair("en|it", "De l'anglais vers l'italien"));
				_lps.Add(new LanguagePair("en|ja", "De l'anglais vers le japonais"));
				_lps.Add(new LanguagePair("en|ko", "De l'anglais vers cor�en"));
				_lps.Add(new LanguagePair("en|pt", "De l'anglais vers le portugais"));
				_lps.Add(new LanguagePair("en|ru", "De l'anglais vers le russe"));
				_lps.Add(new LanguagePair("en|es", "De l'anglais vers l'espagnol"));
				_lps.Add(new LanguagePair("nl|en", "Du hollandais vers l'anglais"));
				_lps.Add(new LanguagePair("nl|fr", "Du hollandais vers le fran�ais"));
				_lps.Add(new LanguagePair("fr|en", "Du fran�ais vers l'anglais"));
				_lps.Add(new LanguagePair("fr|de", "Du fran�ais vers l'allemand"));
				_lps.Add(new LanguagePair("fr|el", "Du fran�ais vers le grec"));
				_lps.Add(new LanguagePair("fr|it", "Du fran�ais vers l'italien"));
				_lps.Add(new LanguagePair("fr|pt", "Du fran�ais vers le portugais"));
				_lps.Add(new LanguagePair("fr|nl", "Du fran�ais vers le hollandais"));
				_lps.Add(new LanguagePair("fr|es", "Du fran�ais vers l'espagnol"));
				_lps.Add(new LanguagePair("de|en", "De l'allemand vers l'anglais"));
				_lps.Add(new LanguagePair("de|fr", "De l'allemand vers le fran�ais"));
				_lps.Add(new LanguagePair("el|en", "Du grec vers l'anglais"));
				_lps.Add(new LanguagePair("el|fr", "Du grec vers le fran�ais"));
				_lps.Add(new LanguagePair("it|en", "De l'italien vers l'anglais"));
				_lps.Add(new LanguagePair("it|fr", "De l'italien vers le fran�ais"));
				_lps.Add(new LanguagePair("ja|en", "Du japonais vers l'anglais"));
				_lps.Add(new LanguagePair("ko|en", "Du cor�en vers l'anglais"));
				_lps.Add(new LanguagePair("pt|en", "Du portugais vers l'anglais"));
				_lps.Add(new LanguagePair("pt|fr", "Du portugais vers le fran�ais"));
				_lps.Add(new LanguagePair("ru|en", "Du russe vers l'anglais"));
				_lps.Add(new LanguagePair("es|en", "De l'espagnol vers l'anglais"));
				_lps.Add(new LanguagePair("es|fr", "De l'espagnol vers le fran�ais"));
				return _lps;
			}
		}
	}
}
