using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Serialcoder.MagicWords.Entities;
using System.Xml.Serialization;
using System.IO;

namespace Serialcoder.MagicWords
{
	public class Context : IDisposable
	{
		#region Properties

		private string m_wordsPath = null;


		private List<MagicWord> m_MagicWords;

		public List<MagicWord> MagicWords
		{
			get { return m_MagicWords; }
			set { m_MagicWords = value; }
		}

		private List<Interfaces.ITool> m_Tools;

		public List<Interfaces.ITool> Tools
		{
			get { return m_Tools; }
			set { m_Tools = value; }
		} 
		#endregion
				
		public Context()
		{
			#region Register app at windows startup
			if (Properties.Settings.Default.RunAtWindowsStart)
			{
				Utilities.RunOnStart("MagicWords", System.Windows.Forms.Application.ExecutablePath);
			}
			else
			{
				Utilities.RemoveRunOnStart("MagicWords");
			}
			#endregion

			m_wordsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + Environment.UserName +".magicwords";

			m_MagicWords = new List<MagicWord>();

			if (File.Exists(m_wordsPath))
			{
				LoadMagicWords();
			}
			else
			{
				GetDefaultMagicWordList();
			}

			// TODO load plugins
			m_Tools = new List<Serialcoder.MagicWords.Interfaces.ITool>();
			LoadPlugins();
		}

		#region public methods
		
		public void GetDefaultMagicWordList()
		{
			m_MagicWords.Clear();

			if (File.Exists(@"C:\Program Files\Mozilla Firefox\firefox.exe"))
			{
				MagicWord word = new MagicWord();
				word.Alias = "firefox";
				word.FileName = @"C:\Program Files\Mozilla Firefox\firefox.exe";
				m_MagicWords.Add(word);
			}			

			MagicWord word1 = new MagicWord();
			word1.Alias = "paint";
			word1.FileName = @"pbrush.exe";
			m_MagicWords.Add(word1);

			MagicWord word2 = new MagicWord();
			word2.Alias = "torrentspy";
			word2.FileName = @"http://www.torrentspy.com/search?query=$W$&submit.x=0&submit.y=0";
			word2.Arguments = "";
			m_MagicWords.Add(word2);

			
		}

		/// <summary>
		/// Saves the magic words.
		/// </summary>
		public void SaveMagicWords()
		{
			XmlSerializer ser = new XmlSerializer(typeof(List<MagicWord>));
			StreamWriter sw = new StreamWriter(m_wordsPath);
			ser.Serialize(sw, m_MagicWords);
			sw.Close();
		}

		/// <summary>
		/// Gets the auto complete source.
		/// </summary>
		/// <value>The auto complete source.</value>
		public string[] AutoCompleteSource
		{
			get
			{
				List<string> test = new List<string>();
				test.Add("add");
				test.Add("exit");
				test.Add("help");
				test.Add("setup");
				
				foreach (MagicWord word in m_MagicWords)
				{
					test.Add(word.Alias);
				}

				foreach (Interfaces.ITool tool in m_Tools)
				{
					test.Add(tool.Alias);
				}

				return test.ToArray();
			}
		}

		public void Start(string alias)
		{
			switch (alias)
			{
				case "exit":
					Exit();
					return;

				case "setup":
					Setup();
					return;

				case "help":
					Help();
					return;

				case "add":
					ShowNewMagicWordForm();
					return;
				default:
					break;
			}

			foreach (Interfaces.ITool tool in m_Tools)
			{
				if (tool.Alias.Equals(alias))
				{
					tool.Execute(null);
					return;
				}
			}

			foreach (MagicWord word in m_MagicWords)
			{
				if (word.Alias.Equals(alias))
				{
					Execute(word);
					return;
				}
			}

			//MagicWord word = m_MagicWords.Find(delegate(MagicWord w) { return w.Alias.Equals(alias); });
			//if (word != null)
			//{
			//    Execute(word);
			//}
			//else
			{
				Execute(alias);
			}
		}

		#endregion

		#region Private methods
		private System.ComponentModel.IContainer m_Components;		

		private void LoadPlugins()
		{
			this.m_Components = new System.ComponentModel.Container();

			string pluginPath = string.Empty;
			
			// we extract all the IAttributeDefinition implementations 
			foreach (string filename in Directory.GetFiles(System.Windows.Forms.Application.StartupPath /* + "\\Plugins" */, "*.dll"))
			{
				System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(filename);
				foreach (Type type in assembly.GetTypes())
				{
					Type plugin = type.GetInterface("Serialcoder.MagicWords.Interfaces.ITool");
					if (plugin != null)
					{
						Interfaces.ITool tool = (Interfaces.ITool)Activator.CreateInstance(type);
						tool.Initialize();

						Serialcoder.MagicWords.Components.SystemHotkey hotkey = new Serialcoder.MagicWords.Components.SystemHotkey(this.m_Components);
						hotkey.Shortcut = tool.HotKey;
						hotkey.Pressed += new EventHandler(delegate(object sender, EventArgs e)
						{
							tool.Execute(null);
						});
						m_Tools.Add(tool);
					}
				}
			}
			
		}

		private void AddGoogleMagicWords()
		{
			#region google words

			MagicWord googleWord = new MagicWord();
			googleWord.Alias = "google";
			googleWord.FileName = @"iexplore";
			googleWord.Arguments = "http://www.google.com/search?hl=en&q=$W$";
			m_MagicWords.Add(googleWord);

			MagicWord mailWord = new MagicWord();
			mailWord.Alias = "mail";
			mailWord.FileName = @"http://mail.google.com";
			mailWord.Arguments = "";
			m_MagicWords.Add(mailWord);

			MagicWord calendarWord = new MagicWord();
			calendarWord.Alias = "calendar";
			calendarWord.FileName = @"http://calendar.google.com";
			calendarWord.Arguments = "";
			m_MagicWords.Add(calendarWord);

			MagicWord docsWord = new MagicWord();
			docsWord.Alias = "docs";
			docsWord.FileName = @"http://www.google.com/docs";
			docsWord.Arguments = "";
			m_MagicWords.Add(docsWord);

			MagicWord baseWord = new MagicWord();
			baseWord.Alias = "base";
			baseWord.FileName = @"http://base.google.com";
			baseWord.Arguments = "";
			m_MagicWords.Add(baseWord);

			MagicWord analyticsWord = new MagicWord();
			analyticsWord.Alias = "analytics";
			analyticsWord.FileName = @"http://www.google.com/analytics";
			analyticsWord.Arguments = "";
			m_MagicWords.Add(analyticsWord);

			MagicWord adsenseWord = new MagicWord();
			adsenseWord.Alias = "adsense";
			adsenseWord.FileName = @"http://www.google.com/adsense";
			adsenseWord.Arguments = "";
			m_MagicWords.Add(adsenseWord);

			MagicWord readerWord = new MagicWord();
			readerWord.Alias = "reader";
			readerWord.FileName = @"http://www.google.com/reader";
			readerWord.Arguments = "";
			m_MagicWords.Add(readerWord);

			MagicWord photoWord = new MagicWord();
			photoWord.Alias = "photos";
			photoWord.FileName = @"http://picasaweb.google.com";
			photoWord.Arguments = "";
			m_MagicWords.Add(photoWord);

			#endregion
		}

		
		/// <summary>
		/// Loads the magic words.
		/// </summary>
		private void LoadMagicWords()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<MagicWord>));
			StreamReader reader = File.OpenText(m_wordsPath);
			m_MagicWords = (List<MagicWord>)serializer.Deserialize(reader);
			reader.Close();			
		}

		

		#endregion
		
		#region Singleton

		private static volatile Context _singleton;
		private static object syncRoot = new Object();

		public static Context Current
		{
			get
			{
				if (_singleton == null)
				{
					lock (syncRoot)
					{
						if (_singleton == null)
						{
							_singleton = new Context();
						}
					}
				}

				return _singleton;
			}
		}
		#endregion
				
		private string ParseInputText(string inputText, string notes)
		{
			// TODO preprocess infos
			if (inputText != null && (inputText.Contains("$W$") || inputText.Contains("$w$")))
			{
				Forms.DynamicInput form = new Serialcoder.MagicWords.Forms.DynamicInput();
				form.Title = notes;
				switch (form.ShowDialog())
				{
					case System.Windows.Forms.DialogResult.OK:
						return inputText.Replace("$W$", form.EncodedInput).Replace("$w$", form.Input);
						break;
					
					default:
						return inputText;
				}
			}

			return inputText;
		}

		private void Execute(MagicWord word)
		{
			string fileName = ParseInputText(word.FileName, word.Notes);
			string arguments = ParseInputText(word.Arguments, word.Notes);

			ProcessStartInfo info = new ProcessStartInfo(fileName, arguments);
			info.WindowStyle = word.StartUpMode;
			info.WorkingDirectory = word.WorkingDirectory;
			info.ErrorDialog = true;
			
			Process process = Process.Start(info);
		}

		private void Execute(string word)
		{
			try
			{
				ProcessStartInfo info = new ProcessStartInfo(word);
				info.WindowStyle = ProcessWindowStyle.Normal;
				info.UseShellExecute = true;
				Process.Start(info);
			}
			catch (Exception)
			{
				System.Media.SystemSounds.Exclamation.Play();	
			}

		}

		#region BuildIn MagicWords launcher

		public void Help()
		{
			Process.Start("http://code.google.com/p/magicwords");
		}

		public void Setup()
		{
			Forms.OptionsForm form = new Serialcoder.MagicWords.Forms.OptionsForm();

			switch (form.ShowDialog())
			{
				case System.Windows.Forms.DialogResult.OK:
					Context.Current.SaveMagicWords();
					Properties.Settings.Default.Save();
					break;

				case System.Windows.Forms.DialogResult.Cancel:
					Properties.Settings.Default.Reload();
					break;

				default:
					break;
			}			
		}

		public void Exit()
		{
			System.Windows.Forms.Application.Exit();
		}

		#endregion

		public void AddActiveApplicationMagicWord(string appExeName, string appExePath)
		{			
			MagicWord word = new MagicWord();
			word.Alias = appExeName;
			word.FileName = appExePath;

			ShowMagicWordForm(word);
		}

		public void ShowNewMagicWordForm()
		{
			ShowMagicWordForm(new MagicWord());			
		}

		private void ShowMagicWordForm(MagicWord word)
		{
			Forms.MagicWordForm form = new Serialcoder.MagicWords.Forms.MagicWordForm();
			form.MagicWord = word;

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK && m_MagicWords.Contains(word) == false)
			{
				m_MagicWords.Add(word);
			}
		}
		
		#region IDisposable Members

		void IDisposable.Dispose()
		{			
			if (this.m_Components != null)
			{
				this.m_Components.Dispose();
			}				
		}

		#endregion
	}
}
