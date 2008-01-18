using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace Serialcoder.MagicWords.TranslatorPlugin
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class MainForm : System.Windows.Forms.Form
	{		
				
		public MainForm()
		{
			InitializeComponent();			
		}		

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			
			this.uxLpComboBox.ValueMember = "Code";
			this.uxLpComboBox.DisplayMember = "Caption";
			this.uxLpComboBox.DataSource = LanguagePair.GoogleLanguagePairs;

			this.uxLpComboBox.DataBindings.Add("SelectedValue", Properties.Settings.Default, "SelectedLanguage", true, DataSourceUpdateMode.OnPropertyChanged);
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			Properties.Settings.Default.Save();
		}

		//private void Form1_Load(object sender, System.EventArgs e)
		//{
		//    //IDataObject datas =  Clipboard.GetDataObject();
		//    //string clip = (string)datas.GetData(DataFormats.Text);
		//    //MessageBox.Show(clip);
		//}

		private void button1_Click(object sender, System.EventArgs e)
		{
			uxTranslateButton.Enabled = false;
			toolStripProgressBar1.Visible = true;
			toolStripStatusLabel1.Text = "Translating...";
			uxBackgroundWorker.RunWorkerAsync(uxLpComboBox.SelectedValue + "$" + textBox1.Text.Replace("\r\n", string.Empty));
		}

		private void uxBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			string input = e.Argument.ToString();

			string google = readHtmlPage("http://translate.google.com/translate_t", "text=" + input.Split('$')[1] + "&langpair=" + input.Split('$')[0] + "&ie=UTF8&oe=UTF8");

			//string regex = "<div id=result_box dir=ltr>([^/<]*)</div>";
			string regex = "<div id=result_box dir=\"ltr\">([^/<]*)</div>";
			System.Text.RegularExpressions.RegexOptions options = ((System.Text.RegularExpressions.RegexOptions.Singleline | System.Text.RegularExpressions.RegexOptions.Multiline) | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(regex, options);

			e.Result  = reg.Match(google).Groups[1].Value;
		}

		private void uxBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			toolStripProgressBar1.Visible = false;
			toolStripStatusLabel1.Text = "Ready";
			textBox2.Text = e.Result.ToString();
			uxTranslateButton.Enabled = true;
		}

		private String readHtmlPage(string url, string postDatas)
		{
			String result = string.Empty;
			String strPost = postDatas; // "key=value&key1=value2"
			Stream stream = null;

			System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

			HttpWebRequest objRequest =	(HttpWebRequest)WebRequest.Create(url);
			objRequest.CookieContainer = new CookieContainer();
			objRequest.Method = "POST";
			objRequest.ContentType = "application/x-www-form-urlencoded";

			byte[] byte1 = encoding.GetBytes(postDatas);
			objRequest.ContentLength = byte1.Length;

			stream = objRequest.GetRequestStream();
			stream.Write(byte1, 0, byte1.Length);
			stream.Close();
						

			HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
			CookieCollection cookies = objResponse.Cookies;

			System.Text.StringBuilder sb = null;
			if (objResponse.ContentLength > 0)
			{
				sb = new System.Text.StringBuilder((int)objResponse.ContentLength);
			}
			else
			{
				sb = new System.Text.StringBuilder();
			}
			using (Stream str = objResponse.GetResponseStream())
			{
				using (StreamReader reader = new StreamReader(str, true))
				{
					int bufferSize = 1024;
					char[] buffer = new char[bufferSize];
					int pos = 0;
					while ((pos = reader.Read(buffer, 0, bufferSize)) > 0)
					{
						sb.Append(buffer, 0, pos);
					}
					// content = reader.ReadToEnd();
					reader.Close();
				}
			}

			if (objResponse != null)
			{
				objResponse.Close();
				objResponse = null;
			}

			//byte1 = new Byte[objResponse.ContentLength];
			//stream = objResponse.GetResponseStream();
			//stream.Read(byte1, 0, (int)objResponse.ContentLength);
			//stream.Close();
			//objResponse.Close();
			//result = encoding.GetString(byte1);
			return sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		//private void textBox1_KeyUp(object sender, KeyEventArgs e)
		//{
		//    if (e.KeyCode == Keys.Enter)
		//    {
		//        button1_Click(sender, EventArgs.Empty);
		//    }
		//}

		private void uxFrenchToEnglishToolStripButton_Click(object sender, EventArgs e)
		{
			this.uxLpComboBox.SelectedValue = "fr|en";
		}

		private void uxEnglishToFrenchToolStripButton_Click(object sender, EventArgs e)
		{
			this.uxLpComboBox.SelectedValue = "en|fr";
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Simple Google based Translator tool.", "SerialCoder 2006");
		}

		
		private void uxLpComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LanguagePair selection = uxLpComboBox.SelectedItem as LanguagePair;

			uxFrenchToEnglishToolStripButton.Checked = false;
			uxEnglishToFrenchToolStripButton.Checked = false;

			if (selection.Code == "fr|en")
			{
				uxFrenchToEnglishToolStripButton.Checked = true;
			}
			else if (selection.Code == "en|fr")
			{				
				uxEnglishToFrenchToolStripButton.Checked = true;
			}
		}

		private void textBox1_KeyUp(object sender, KeyEventArgs e)
		{
			 if (e.Control && e.KeyCode == Keys.Enter)
			 {
				 button1_Click(sender, EventArgs.Empty);
			 }
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Save();
		}
	}
}
