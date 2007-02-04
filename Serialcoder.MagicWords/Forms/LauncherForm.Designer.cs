namespace Serialcoder.MagicWords.Forms
{
	partial class LauncherForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.uxInputText = new System.Windows.Forms.TextBox();
			this.uxInputContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.uxMagicWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uxNewMagicWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.uxHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uxSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uxHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.uxExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uxInputContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// uxInputText
			// 
			this.uxInputText.BackColor = global::Serialcoder.MagicWords.Properties.Settings.Default.Backcolor;
			this.uxInputText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uxInputText.ContextMenuStrip = this.uxInputContextMenuStrip;
			this.uxInputText.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Serialcoder.MagicWords.Properties.Settings.Default, "ForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.uxInputText.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Serialcoder.MagicWords.Properties.Settings.Default, "Backcolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.uxInputText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxInputText.ForeColor = global::Serialcoder.MagicWords.Properties.Settings.Default.ForeColor;
			this.uxInputText.Location = new System.Drawing.Point(0, 0);
			this.uxInputText.Margin = new System.Windows.Forms.Padding(0);
			this.uxInputText.Name = "uxInputText";
			this.uxInputText.Size = new System.Drawing.Size(150, 20);
			this.uxInputText.TabIndex = 0;
			this.uxInputText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnInputTextBoxKeyUp);
			// 
			// uxInputContextMenuStrip
			// 
			this.uxInputContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxMagicWordsToolStripMenuItem,
            this.uxNewMagicWordToolStripMenuItem,
            this.toolStripSeparator3,
            this.uxHideToolStripMenuItem,
            this.uxSetupToolStripMenuItem,
            this.uxHelpToolStripMenuItem,
            this.toolStripSeparator1,
            this.uxExitToolStripMenuItem});
			this.uxInputContextMenuStrip.Name = "contextMenuStrip1";
			this.uxInputContextMenuStrip.Size = new System.Drawing.Size(175, 170);
			this.uxInputContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.uxInputContextMenuStrip_Opening);
			// 
			// uxMagicWordsToolStripMenuItem
			// 
			this.uxMagicWordsToolStripMenuItem.Name = "uxMagicWordsToolStripMenuItem";
			this.uxMagicWordsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.uxMagicWordsToolStripMenuItem.Text = "MagicWords";
			// 
			// uxNewMagicWordToolStripMenuItem
			// 
			this.uxNewMagicWordToolStripMenuItem.Name = "uxNewMagicWordToolStripMenuItem";
			this.uxNewMagicWordToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.uxNewMagicWordToolStripMenuItem.Text = "New MagicWord...";
			this.uxNewMagicWordToolStripMenuItem.Click += new System.EventHandler(this.OnNewMagicWordToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(171, 6);
			// 
			// uxHideToolStripMenuItem
			// 
			this.uxHideToolStripMenuItem.Name = "uxHideToolStripMenuItem";
			this.uxHideToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.uxHideToolStripMenuItem.Text = "&Hide in Tray";
			this.uxHideToolStripMenuItem.Click += new System.EventHandler(this.OnHideToolStripMenuItemClick);
			// 
			// uxSetupToolStripMenuItem
			// 
			this.uxSetupToolStripMenuItem.Name = "uxSetupToolStripMenuItem";
			this.uxSetupToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.uxSetupToolStripMenuItem.Text = "&Setup...";
			this.uxSetupToolStripMenuItem.Click += new System.EventHandler(this.OnSetupToolStripMenuItemClick);
			// 
			// uxHelpToolStripMenuItem
			// 
			this.uxHelpToolStripMenuItem.Name = "uxHelpToolStripMenuItem";
			this.uxHelpToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.uxHelpToolStripMenuItem.Text = "&Help";
			this.uxHelpToolStripMenuItem.Click += new System.EventHandler(this.OnHelpToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
			// 
			// uxExitToolStripMenuItem
			// 
			this.uxExitToolStripMenuItem.Name = "uxExitToolStripMenuItem";
			this.uxExitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.uxExitToolStripMenuItem.Text = "&Exit";
			this.uxExitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
			// 
			// LauncherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(150, 94);
			this.ContextMenuStrip = this.uxInputContextMenuStrip;
			this.ControlBox = false;
			this.Controls.Add(this.uxInputText);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Serialcoder.MagicWords.Properties.Settings.Default, "Position", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = global::Serialcoder.MagicWords.Properties.Settings.Default.Position;
			this.Name = "LauncherForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.uxInputContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox uxInputText;
		private System.Windows.Forms.ContextMenuStrip uxInputContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem uxExitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem uxMagicWordsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uxNewMagicWordToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem uxHideToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uxSetupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uxHelpToolStripMenuItem;
	}
}