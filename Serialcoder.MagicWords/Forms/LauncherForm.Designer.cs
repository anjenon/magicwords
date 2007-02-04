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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.uxInputContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.uxMagicWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uxNewMagicWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.uxHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uxSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uxHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.uxCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uxPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.uxExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uxInputContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.BackColor = global::Serialcoder.MagicWords.Properties.Settings.Default.Backcolor;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.ContextMenuStrip = this.uxInputContextMenuStrip;
			this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Serialcoder.MagicWords.Properties.Settings.Default, "ForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Serialcoder.MagicWords.Properties.Settings.Default, "Backcolor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.ForeColor = global::Serialcoder.MagicWords.Properties.Settings.Default.ForeColor;
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Margin = new System.Windows.Forms.Padding(0);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(150, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
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
            this.toolStripSeparator2,
            this.uxCutToolStripMenuItem,
            this.uxPasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.uxExitToolStripMenuItem});
			this.uxInputContextMenuStrip.Name = "contextMenuStrip1";
			this.uxInputContextMenuStrip.Size = new System.Drawing.Size(175, 198);
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
			this.uxHideToolStripMenuItem.Click += new System.EventHandler(this.uxHideToolStripMenuItem_Click);
			// 
			// uxSetupToolStripMenuItem
			// 
			this.uxSetupToolStripMenuItem.Name = "uxSetupToolStripMenuItem";
			this.uxSetupToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.uxSetupToolStripMenuItem.Text = "&Setup...";
			this.uxSetupToolStripMenuItem.Click += new System.EventHandler(this.uxSetupToolStripMenuItem_Click);
			// 
			// uxHelpToolStripMenuItem
			// 
			this.uxHelpToolStripMenuItem.Name = "uxHelpToolStripMenuItem";
			this.uxHelpToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.uxHelpToolStripMenuItem.Text = "&Help";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
			// 
			// uxCutToolStripMenuItem
			// 
			this.uxCutToolStripMenuItem.Name = "uxCutToolStripMenuItem";
			this.uxCutToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.uxCutToolStripMenuItem.Text = "&Cut";
			// 
			// uxPasteToolStripMenuItem
			// 
			this.uxPasteToolStripMenuItem.Name = "uxPasteToolStripMenuItem";
			this.uxPasteToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.uxPasteToolStripMenuItem.Text = "&Paste";
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
			this.uxExitToolStripMenuItem.Click += new System.EventHandler(this.uxExitToolStripMenuItem_Click);
			// 
			// InputForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(150, 94);
			this.ContextMenuStrip = this.uxInputContextMenuStrip;
			this.ControlBox = false;
			this.Controls.Add(this.textBox1);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Serialcoder.MagicWords.Properties.Settings.Default, "Position", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = global::Serialcoder.MagicWords.Properties.Settings.Default.Position;
			this.Name = "InputForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.uxInputContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ContextMenuStrip uxInputContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem uxExitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uxCutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uxPasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem uxMagicWordsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uxNewMagicWordToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem uxHideToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uxSetupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uxHelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}