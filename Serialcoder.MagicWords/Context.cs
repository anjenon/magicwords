using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Serialcoder.MagicWords.Entities;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace Serialcoder.MagicWords
{
	/// <summary>
	/// The global Context of the application.
	/// Holds user data and main business logic
	/// </summary>
	public class Context
	{
		#region Properties

		private string m_UserLibraryFileName = null;
		
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

		private List<Interfaces.IParameter> m_Parameters;

		public List<Interfaces.IParameter> Parameters
		{
			get { return m_Parameters; }
			set { m_Parameters = value; }
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
				test.Add("hide");

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
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="Context"/> class.
		/// </summary>
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

			m_UserLibraryFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + Environment.UserName +".magicwords";

			m_MagicWords = new List<MagicWord>();

			if (File.Exists(m_UserLibraryFileName))
			{
				LoadMagicWords();
			}
			else
			{
				GetDefaultMagicWordList();
			}
						
			LoadToolPlugins();
			LoadParameterPlugins();
		}
		
		#region public methods
				
		/// <summary>
		/// Saves the magic words.
		/// </summary>
		public void SaveMagicWords()
		{
			XmlSerializer ser = new XmlSerializer(typeof(List<MagicWord>));
			StreamWriter sw = new StreamWriter(m_UserLibraryFileName);
			ser.Serialize(sw, m_MagicWords);
			sw.Close();
		}		

		public void Start(string alias)
		{
			switch (alias)
			{
				case "exit":
					Exit();
					return;

				case "hide":
					HideLauncherForm();
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

			Execute(alias);
		}		

		public void AddActiveApplicationMagicWord(string appExeName, string appExePath)
		{
			MagicWord word = new MagicWord();
			word.Alias = appExeName;
			word.FileName = appExePath;

			ShowMagicWordForm(word);
		}		

		#endregion

		#region Private methods
		private System.ComponentModel.IContainer m_Components;		

		private void LoadToolPlugins()
		{
			m_Tools = new List<Serialcoder.MagicWords.Interfaces.ITool>();
			
			this.m_Components = new System.ComponentModel.Container();

#if Release
			string pluginPath = System.Windows.Forms.Application.StartupPath + "\\Plugins";
#else
			string pluginPath = System.Windows.Forms.Application.StartupPath;
#endif

			AddToolPlugin(Assembly.GetExecutingAssembly());

			// We extract all the ITool implementations 
			foreach (string filename in Directory.GetFiles(pluginPath , "*.dll"))
			{
				Assembly assembly = Assembly.LoadFrom(filename);
				AddToolPlugin(assembly);
			}
			
		}

		private void AddToolPlugin(Assembly assembly)
		{
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

		private void LoadParameterPlugins()
		{
			m_Parameters = new List<Serialcoder.MagicWords.Interfaces.IParameter>();
						
#if Release
			string pluginPath = System.Windows.Forms.Application.StartupPath + "\\Plugins";
#else
			string pluginPath = System.Windows.Forms.Application.StartupPath;
#endif

			// Load build in IParameter
			AddParameterPlugin(Assembly.GetExecutingAssembly());

			// add Iparameter stored in external plugins
			foreach (string filename in Directory.GetFiles(pluginPath, "*.dll"))
			{
				AddParameterPlugin(Assembly.LoadFrom(filename));
			}
		}

		private void AddParameterPlugin(Assembly assembly)
		{
			foreach (Type type in assembly.GetTypes())
			{					
				Type plugin = type.GetInterface("Serialcoder.MagicWords.Interfaces.IParameter");
				if (plugin != null)
				{
					Interfaces.IParameter parameter = (Interfaces.IParameter)Activator.CreateInstance(type);
					m_Parameters.Add(parameter);
				}
			}
		}

		private void GetDefaultMagicWordList()
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
			StreamReader reader = File.OpenText(m_UserLibraryFileName);
			m_MagicWords = (List<MagicWord>)serializer.Deserialize(reader);
			reader.Close();			
		}

		private string ParseInputText(string inputText, string notes)
		{
			if (inputText != null && (inputText.Contains("$W$") || inputText.Contains("$I$")))
			{
				Forms.DynamicInput form = new Serialcoder.MagicWords.Forms.DynamicInput();
				form.Title = notes;
				switch (form.ShowDialog())
				{
					case System.Windows.Forms.DialogResult.OK:
						return inputText.Replace("$W$", form.EncodedInput).Replace("$I$", form.Input);
					
					case System.Windows.Forms.DialogResult.Cancel:
						throw new ApplicationException("User cancel");
						break;
					
					default:
						return inputText;
				}
			}

			if (inputText != null && inputText.Contains("$C$"))
			{
				return inputText.Replace("$I$", Clipboard.GetText());
			}

			return inputText;
		}

		
		private void Execute(MagicWord word)
		{			
			string fileName = word.FileName;
			string arguments = word.Arguments;
			
			foreach (Interfaces.IParameter parameter in m_Parameters)
			{
				try
				{
					fileName = ApplyParameterPlugin(word.Notes, fileName, parameter);
					arguments = ApplyParameterPlugin(word.Notes, arguments, parameter);					
				}
				catch (ApplicationException)
				{
					return;
				}				
			}

			try
			{
				ProcessStartInfo info = new ProcessStartInfo(fileName, arguments);
				info.WindowStyle = word.StartUpMode;
				info.WorkingDirectory = word.WorkingDirectory;
				info.ErrorDialog = true;

				Process process = Process.Start(info);
			}			
			catch (Exception ex)
			{
				System.Media.SystemSounds.Exclamation.Play();
				//System.Windows.Forms.MessageBox.Show(ex.Message);
			}
			
		}

		private string ApplyParameterPlugin(string wordNotes, string input, Interfaces.IParameter parameter)
		{
			while (string.IsNullOrEmpty(input) == false && input.Contains(parameter.Variable))
			{
				string parameterValue = string.Empty;

				if (parameter.GetValue(wordNotes, out parameterValue) == true)
				{
					input = input.Replace(parameter.Variable, parameterValue);
				}
				else
				{
					throw new ApplicationException();
				}
			}
			return input;
		}

		private void Execute(string word)
		{
			try
			{
				ProcessStartInfo info = new ProcessStartInfo(word);
				info.WindowStyle = ProcessWindowStyle.Normal;
				info.UseShellExecute = true;
				Process p = Process.Start(info);
			}
			catch (Exception ex)
			{
				System.Media.SystemSounds.Exclamation.Play();
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}

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

		#endregion
		
		#region BuildIn MagicWords launcher

		/// <summary>
		/// Open the online help. "help" magicword handler
		/// </summary>
		public void Help()
		{
			Process.Start(Properties.Settings.Default.HelpUrl);
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

		public void HideLauncherForm()
		{
			Forms.LauncherForm.Current.Hide();
		}

		public void ShowNewMagicWordForm()
		{
			ShowMagicWordForm(new MagicWord());
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
		
	}
}
