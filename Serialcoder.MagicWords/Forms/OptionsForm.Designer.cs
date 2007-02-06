namespace Serialcoder.MagicWords.Forms
{
	partial class OptionsForm
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.uxCancelButton = new System.Windows.Forms.Button();
			this.uxAcceptButton = new System.Windows.Forms.Button();
			this.listMagicWords1 = new Serialcoder.MagicWords.Controls.ListMagicWords();
			this.helpViewer1 = new Serialcoder.MagicWords.Controls.HelpViewer();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(518, 299);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.listMagicWords1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(510, 273);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "MagicWords library";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.propertyGrid1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(510, 273);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Options";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(504, 267);
			this.propertyGrid1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.helpViewer1);
			this.tabPage2.Controls.Add(this.linkLabel1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(510, 273);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Help";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(411, 3);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(93, 13);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Project homepage";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnWebsiteLinkClicked);
			// 
			// uxCancelButton
			// 
			this.uxCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uxCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.uxCancelButton.Location = new System.Drawing.Point(455, 317);
			this.uxCancelButton.Name = "uxCancelButton";
			this.uxCancelButton.Size = new System.Drawing.Size(75, 23);
			this.uxCancelButton.TabIndex = 1;
			this.uxCancelButton.Text = "&Cancel";
			this.uxCancelButton.UseVisualStyleBackColor = true;
			this.uxCancelButton.Click += new System.EventHandler(this.uxCancelButton_Click);
			// 
			// uxAcceptButton
			// 
			this.uxAcceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uxAcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.uxAcceptButton.Location = new System.Drawing.Point(374, 317);
			this.uxAcceptButton.Name = "uxAcceptButton";
			this.uxAcceptButton.Size = new System.Drawing.Size(75, 23);
			this.uxAcceptButton.TabIndex = 2;
			this.uxAcceptButton.Text = "&OK";
			this.uxAcceptButton.UseVisualStyleBackColor = true;
			this.uxAcceptButton.Click += new System.EventHandler(this.uxAcceptButton_Click);
			// 
			// listMagicWords1
			// 
			this.listMagicWords1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listMagicWords1.Location = new System.Drawing.Point(3, 3);
			this.listMagicWords1.Name = "listMagicWords1";
			this.listMagicWords1.Size = new System.Drawing.Size(504, 267);
			this.listMagicWords1.TabIndex = 0;
			// 
			// helpViewer1
			// 
			this.helpViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.helpViewer1.Location = new System.Drawing.Point(6, 19);
			this.helpViewer1.Name = "helpViewer1";
			this.helpViewer1.Size = new System.Drawing.Size(498, 248);
			this.helpViewer1.TabIndex = 1;
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.uxAcceptButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.uxCancelButton;
			this.ClientSize = new System.Drawing.Size(542, 352);
			this.Controls.Add(this.uxAcceptButton);
			this.Controls.Add(this.uxCancelButton);
			this.Controls.Add(this.tabControl1);
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Options";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button uxCancelButton;
		private System.Windows.Forms.Button uxAcceptButton;
		private Serialcoder.MagicWords.Controls.ListMagicWords listMagicWords1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private Serialcoder.MagicWords.Controls.HelpViewer helpViewer1;
	}
}