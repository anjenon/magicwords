using System;
using System.Windows.Forms;
using System.Drawing;
using Serialcoder.MagicWords.Utilities;
using Serialcoder.MagicWords.Forms;
using System.Diagnostics;

namespace Serialcoder.MagicWords
{
	/// <summary>
	/// CalendarApplicationContext.
	/// This class has several jobs:
	///		- Create the NotifyIcon UI
	///		- Manage the Input form that pops up
	///		- Determines when the Application should exit
	/// </summary>
	public class MagicWordsApplicationContext : ApplicationContext 
	{
		private System.ComponentModel.IContainer	components;						// a list of components to dispose when the context is disposed
		private System.Windows.Forms.NotifyIcon		m_NotifyIcon;				// the icon that sits in the system tray
		private System.Windows.Forms.ContextMenuStrip	m_NotifyIconContextMenu;	// the context menu for the notify icon
		private System.Windows.Forms.ToolStripMenuItem exitContextMenuItem;			// exit menu command for context menu 
		private System.Windows.Forms.ToolStripMenuItem m_helpContextMenuItem;			// open menu command for context menu 	
		private System.Windows.Forms.ToolStripMenuItem showContextMenuItem;			// open menu command for context menu 	
		private System.Windows.Forms.ToolStripMenuItem setupContextMenuItem;			// open menu command for context menu 	
		private System.Windows.Forms.Form m_MainForm;						// the current form we're displaying

		private SystemHotkey m_SystemHotkey;
		private SystemHotkey m_AddWordSystemHotkey;

		/// <summary>
		/// This class should be created and passed into Application.Run( ... )
		/// </summary>
		public MagicWordsApplicationContext() 
		{
			// create the notify icon and it's associated context menu
			InitializeContext();
		}


		/// <summary>
		/// Create the NotifyIcon UI, the ContextMenu for the NotifyIcon and an Exit menu item. 
		/// </summary>
		private void InitializeContext() 
		{
			this.components = new System.ComponentModel.Container();
			this.m_NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.m_NotifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip();
			this.showContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setupContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_helpContextMenuItem = new ToolStripMenuItem();
			this.m_SystemHotkey = new SystemHotkey(this.components);
			m_AddWordSystemHotkey = new SystemHotkey(this.components);
			
		
			// 
			// calendarNotifyIcon
			// 
			this.m_NotifyIcon.ContextMenuStrip = this.m_NotifyIconContextMenu;
			this.m_NotifyIcon.DoubleClick += new System.EventHandler(this.OnNotifyIconDoubleClick);
			this.m_NotifyIcon.Icon = Properties.Resources.App;//new Icon(typeof(LauncherApplicationContext), "CLOCK05.ICO");
			this.m_NotifyIcon.Text = "Serialcoder launcher 1.0";
			this.m_NotifyIcon.Visible = true;

			// 
			// calendarNotifyIconContextMenu
			// 
			this.m_NotifyIconContextMenu.Items.AddRange(new ToolStripItem[] { this.setupContextMenuItem, this.showContextMenuItem, exitContextMenuItem });

			
			// 
			// showContextMenuItem
			// 
			this.setupContextMenuItem.Text = "&Setup...";
			this.setupContextMenuItem.Click += new EventHandler(OnSetupContextMenuItemClick);

			//this.showContextMenuItem.Index = 0;
			this.showContextMenuItem.Text = "&Show launch pad";
			//this.showContextMenuItem.DisplayStyle = true;
			this.showContextMenuItem.Click += new System.EventHandler(this.OnShowContextMenuItemClick);

			//
			// m_helpContextMenuItem
			//
			this.m_helpContextMenuItem.Text = "&Help...";
			this.showContextMenuItem.Click += new System.EventHandler(delegate(object sender, EventArgs e)
			{
				Context.Current.Help();
			});

			// 
			// exitContextMenuItem
			// 
			//this.exitContextMenuItem.Index = 1;
			this.exitContextMenuItem.Text = "&Exit";
			this.exitContextMenuItem.Click += new System.EventHandler(this.OnExitContextMenuItemClick);

			//
			// m_SystemHotkey
			//
			m_SystemHotkey.Shortcut = Properties.Settings.Default.TypeWordHotKey; //Shortcut.CtrlF12;
			m_SystemHotkey.Pressed += new EventHandler(OnSystemHotkeyPressed);

			//
			// m_AddWordSystemHotkey
			//
			m_AddWordSystemHotkey.Shortcut = Properties.Settings.Default.AddWordHotKey;//Shortcut.CtrlF11;
			m_AddWordSystemHotkey.Pressed += new EventHandler(OnAddWordSystemHotkeyPressed);

			Application.ApplicationExit += new EventHandler(OnApplicationExit);
		}

		/// <summary>
		/// When the application context is disposed,; dispose things like the notify icon.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}		
		}

		void OnSetupContextMenuItemClick(object sender, EventArgs e)
		{
			OptionsForm form = new OptionsForm();
			form.ShowDialog();
		}

		void OnApplicationExit(object sender, EventArgs e)
		{
			Context.Current.SaveMagicWords();
		}		

		/// <summary>
		/// When the open menu item is clicked, make a call to Show the form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShowContextMenuItemClick(object sender, EventArgs e) 
		{
			ShowForm();
		}
		/// <summary>
		/// When the exit menu item is clicked, make a call to terminate the ApplicationContext.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnExitContextMenuItemClick(object sender, EventArgs e) 
		{
			ExitThread();
		}
		
		/// <summary>
		/// When the notify icon is double clicked in the system tray, bring up a form with a calendar on it.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNotifyIconDoubleClick(object sender,System.EventArgs e)
		{
			ShowForm();
		}

		private void OnSystemHotkeyPressed(object sender, EventArgs e)
		{
			ShowForm();
		}

		private void OnAddWordSystemHotkeyPressed(object sender, EventArgs e)
		{
			string appExePath = NativeWIN32.GetFocusesApp();
			string appExeName = appExePath.Substring(appExePath.LastIndexOf(@"\") + 1);

			Context.Current.AddActiveApplicationMagicWord(appExeName, appExePath);
		}		

		/// <summary>
		/// This function will either create a new CalendarForm or activate the existing one, bringing the 
		/// window to front.
		/// </summary>
		private void ShowForm() 
		{
			if (m_MainForm == null) 
			{
				// create a fresh new CalendarForm and show it.
				m_MainForm = new LauncherForm();
				m_MainForm.Show();
				
				// hook onto the closed event so we can null out the main form...  this avoids reshowing
				// a disposed form.
				m_MainForm.Closed +=new EventHandler(mainForm_Closed);		
			}
			else 
			{
				// the form is currently visible, go ahead and bring it to the front so the user can interact
				m_MainForm.Activate();
			}
		}


		private void mainForm_Closed (object sender, EventArgs e) 
		{
			// null out the main form so we know to create a new one.
			this.m_MainForm = null;
		}

		/// <summary>
		/// If we are presently showing a mainForm, clean it up.
		/// </summary>
		protected override void ExitThreadCore()
		{
			if (m_MainForm != null) 
			{
				// before we exit, give the main form a chance to clean itself up.
				m_MainForm.Close();
			}
			base.ExitThreadCore ();
		}
		
	}
}
