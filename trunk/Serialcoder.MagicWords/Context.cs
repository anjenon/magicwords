using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using JRoland.MagicWords.Entities;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace JRoland.MagicWords
{
	/// <summary>
	/// The global Context of the application.
	/// Holds user data and main business logic
	/// </summary>
	public class Context
	{
		#region Properties

		private string m_UserLibraryFileName = null;
				
        public List<MagicWord> MagicWords { get; private set; }
        public List<Interfaces.ITool> Tools { get; private set; }
        public List<Interfaces.IParameter> Parameters { get; private set; }
		
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

                

				foreach (MagicWord word in MagicWords)
				{
					test.Add(word.Alias);
				}

				foreach (Interfaces.ITool tool in Tools)
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

			MagicWords = new List<MagicWord>();

			if (File.Exists(m_UserLibraryFileName))
			{
				LoadMagicWords();
			}
			else
			{
				GetDefaultMagicWordList();
			}

            // TODO add from liberykey if it's activated in options
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LiberkeyPath) && Directory.Exists(Properties.Settings.Default.LiberkeyPath))
            {
                MagicWords.AddRange(LiberkeyHelper.GetMagicWordList(Properties.Settings.Default.LiberkeyPath).ToArray());
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
            List<Entities.MagicWord> usersWords = new List<MagicWord>();

            foreach (var item in MagicWords)
            {
                if (item.Kind == Kind.User)
                {
                    usersWords.Add(item);
                }
            }

			XmlSerializer ser = new XmlSerializer(typeof(List<MagicWord>));
			StreamWriter sw = new StreamWriter(m_UserLibraryFileName);
			ser.Serialize(sw, usersWords);
			sw.Close();
		}		

		public void Start(string alias)
		{
			switch (alias.ToLower())
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

			foreach (Interfaces.ITool tool in Tools)
			{
				if (tool.Alias.Equals(alias, StringComparison.InvariantCultureIgnoreCase))
				{
					tool.Execute(null);
					return;
				}
			}

			foreach (MagicWord word in MagicWords)
			{
				if (word.Alias.Equals(alias, StringComparison.InvariantCultureIgnoreCase))
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
            word.Kind = Kind.User;

			ShowMagicWordForm(word);
		}		

		#endregion

		#region Private methods
		private System.ComponentModel.IContainer m_Components;		

		private void LoadToolPlugins()
		{
			Tools = new List<JRoland.MagicWords.Interfaces.ITool>();
			
			this.m_Components = new System.ComponentModel.Container();

#if DEBUG
			string pluginPath = System.Windows.Forms.Application.StartupPath;			
#else
			string pluginPath = System.Windows.Forms.Application.StartupPath + "\\Plugins";
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
				Type plugin = type.GetInterface("JRoland.MagicWords.Interfaces.ITool");
				if (plugin != null)
				{
					Interfaces.ITool tool = (Interfaces.ITool)Activator.CreateInstance(type);
					tool.Initialize();

					JRoland.MagicWords.Components.SystemHotkey hotkey = new JRoland.MagicWords.Components.SystemHotkey(this.m_Components);
					hotkey.Shortcut = tool.HotKey;
					hotkey.Pressed += new EventHandler(delegate(object sender, EventArgs e)
					{
						tool.Execute(null);
					});
					Tools.Add(tool);
				}
			}
		}

		private void LoadParameterPlugins()
		{
			Parameters = new List<JRoland.MagicWords.Interfaces.IParameter>();
						
#if DEBUG
			string pluginPath = System.Windows.Forms.Application.StartupPath;			
#else
			string pluginPath = System.Windows.Forms.Application.StartupPath + "\\Plugins";
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
				Type plugin = type.GetInterface("JRoland.MagicWords.Interfaces.IParameter");
				if (plugin != null)
				{
					Interfaces.IParameter parameter = (Interfaces.IParameter)Activator.CreateInstance(type);
					Parameters.Add(parameter);
				}
			}
		}

		private void GetDefaultMagicWordList()
		{
			MagicWords.Clear();

			if (File.Exists(@"C:\Program Files\Mozilla Firefox\firefox.exe"))
			{
				MagicWord word = new MagicWord();
				word.Alias = "firefox";
				word.FileName = @"C:\Program Files\Mozilla Firefox\firefox.exe";
				MagicWords.Add(word);
			}

			MagicWord word1 = new MagicWord();
			word1.Alias = "paint";
			word1.FileName = @"pbrush.exe";
			MagicWords.Add(word1);

			MagicWord word2 = new MagicWord();
			word2.Alias = "btjunkie";
			word2.FileName = @"http://btjunkie.org/search?q=$W$";
			word2.Arguments = "";
			MagicWords.Add(word2);
		}

		private void AddGoogleMagicWords()
		{
			#region google words

			MagicWord googleWord = new MagicWord();
			googleWord.Alias = "google";
			googleWord.FileName = @"iexplore";
			googleWord.Arguments = "http://www.google.com/search?hl=en&q=$W$";
			MagicWords.Add(googleWord);

			MagicWord mailWord = new MagicWord();
			mailWord.Alias = "mail";
			mailWord.FileName = @"http://mail.google.com";
			mailWord.Arguments = "";
			MagicWords.Add(mailWord);

			MagicWord calendarWord = new MagicWord();
			calendarWord.Alias = "calendar";
			calendarWord.FileName = @"http://calendar.google.com";
			calendarWord.Arguments = "";
			MagicWords.Add(calendarWord);

			MagicWord docsWord = new MagicWord();
			docsWord.Alias = "docs";
			docsWord.FileName = @"http://www.google.com/docs";
			docsWord.Arguments = "";
			MagicWords.Add(docsWord);

			MagicWord baseWord = new MagicWord();
			baseWord.Alias = "base";
			baseWord.FileName = @"http://base.google.com";
			baseWord.Arguments = "";
			MagicWords.Add(baseWord);

			MagicWord analyticsWord = new MagicWord();
			analyticsWord.Alias = "analytics";
			analyticsWord.FileName = @"http://www.google.com/analytics";
			analyticsWord.Arguments = "";
			MagicWords.Add(analyticsWord);

			MagicWord adsenseWord = new MagicWord();
			adsenseWord.Alias = "adsense";
			adsenseWord.FileName = @"http://www.google.com/adsense";
			adsenseWord.Arguments = "";
			MagicWords.Add(adsenseWord);

			MagicWord readerWord = new MagicWord();
			readerWord.Alias = "reader";
			readerWord.FileName = @"http://www.google.com/reader";
			readerWord.Arguments = "";
			MagicWords.Add(readerWord);

			MagicWord photoWord = new MagicWord();
			photoWord.Alias = "photos";
			photoWord.FileName = @"http://picasaweb.google.com";
			photoWord.Arguments = "";
			MagicWords.Add(photoWord);

			#endregion
		}
				
		/// <summary>
		/// Loads the magic words.
		/// </summary>
		private void LoadMagicWords()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<MagicWord>));
			StreamReader reader = File.OpenText(m_UserLibraryFileName);
			MagicWords = (List<MagicWord>)serializer.Deserialize(reader);
			reader.Close();			
		}

        //private string ParseInputText(string inputText, string notes)
        //{
        //    if (inputText != null && (inputText.Contains("$W$") || inputText.Contains("$I$")))
        //    {
        //        Forms.DynamicInput form = new JRoland.MagicWords.Forms.DynamicInput();
        //        form.Title = notes;
        //        switch (form.ShowDialog())
        //        {
        //            case System.Windows.Forms.DialogResult.OK:
        //                return inputText.Replace("$W$", form.EncodedInput).Replace("$I$", form.Input);
					
        //            case System.Windows.Forms.DialogResult.Cancel:
        //                throw new ApplicationException("User cancel");
        //                break;
					
        //            default:
        //                return inputText;
        //        }
        //    }

        //    if (inputText != null && inputText.Contains("$C$"))
        //    {
        //        return inputText.Replace("$I$", Clipboard.GetText());
        //    }

        //    return inputText;
        //}

		
		private void Execute(MagicWord word)
		{			
			string fileName = word.FileName;
			string arguments = word.Arguments;
			
			foreach (Interfaces.IParameter parameter in Parameters)
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
			catch (Exception)
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
			Forms.MagicWordForm form = new JRoland.MagicWords.Forms.MagicWordForm();
			form.MagicWord = word;

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK && MagicWords.Contains(word) == false)
			{
				if (MagicWords.Contains(word) == false)
				{
					MagicWords.Add(word);
					Forms.LauncherForm.Current.UpdateAutoCompletion();
				}

				Context.Current.SaveMagicWords();
				Properties.Settings.Default.Save();
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
			Forms.OptionsForm form = new JRoland.MagicWords.Forms.OptionsForm();

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
