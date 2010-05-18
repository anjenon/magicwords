namespace JRoland.MagicWords.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listMagicWords1 = new JRoland.MagicWords.Controls.ListMagicWords();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uxUserSettingsPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.uxToolDataGridView = new System.Windows.Forms.DataGridView();
            this.uxToolAliasColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxToolNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxToolDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxToolHotKeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxToolAuthorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxToolVersionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.helpViewer1 = new JRoland.MagicWords.Controls.HelpViewer();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.uxParametersDataGridView = new System.Windows.Forms.DataGridView();
            this.uxCancelButton = new System.Windows.Forms.Button();
            this.uxAcceptButton = new System.Windows.Forms.Button();
            this.uxImportLinkLabel = new System.Windows.Forms.LinkLabel();
            this.uxExportLinkLabel = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxToolDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxParametersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 370);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listMagicWords1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(577, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MagicWords library";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listMagicWords1
            // 
            this.listMagicWords1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMagicWords1.Location = new System.Drawing.Point(3, 3);
            this.listMagicWords1.Name = "listMagicWords1";
            this.listMagicWords1.Size = new System.Drawing.Size(571, 338);
            this.listMagicWords1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.uxUserSettingsPropertyGrid);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(577, 344);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uxUserSettingsPropertyGrid
            // 
            this.uxUserSettingsPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxUserSettingsPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.uxUserSettingsPropertyGrid.Name = "uxUserSettingsPropertyGrid";
            this.uxUserSettingsPropertyGrid.Size = new System.Drawing.Size(571, 338);
            this.uxUserSettingsPropertyGrid.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.uxToolDataGridView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(577, 344);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tools";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // uxToolDataGridView
            // 
            this.uxToolDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxToolDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.uxToolDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxToolDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uxToolAliasColumn,
            this.uxToolNameColumn,
            this.uxToolDescriptionColumn,
            this.uxToolHotKeyColumn,
            this.uxToolAuthorColumn,
            this.uxToolVersionColumn});
            this.uxToolDataGridView.EnableHeadersVisualStyles = false;
            this.uxToolDataGridView.Location = new System.Drawing.Point(6, 6);
            this.uxToolDataGridView.Name = "uxToolDataGridView";
            this.uxToolDataGridView.Size = new System.Drawing.Size(565, 332);
            this.uxToolDataGridView.TabIndex = 0;
            // 
            // uxToolAliasColumn
            // 
            this.uxToolAliasColumn.DataPropertyName = "Alias";
            this.uxToolAliasColumn.HeaderText = "MagicWord";
            this.uxToolAliasColumn.Name = "uxToolAliasColumn";
            // 
            // uxToolNameColumn
            // 
            this.uxToolNameColumn.DataPropertyName = "Name";
            this.uxToolNameColumn.HeaderText = "Tool name";
            this.uxToolNameColumn.Name = "uxToolNameColumn";
            // 
            // uxToolDescriptionColumn
            // 
            this.uxToolDescriptionColumn.DataPropertyName = "Description";
            this.uxToolDescriptionColumn.HeaderText = "Description";
            this.uxToolDescriptionColumn.Name = "uxToolDescriptionColumn";
            // 
            // uxToolHotKeyColumn
            // 
            this.uxToolHotKeyColumn.DataPropertyName = "HotKey";
            this.uxToolHotKeyColumn.HeaderText = "HotKey";
            this.uxToolHotKeyColumn.Name = "uxToolHotKeyColumn";
            // 
            // uxToolAuthorColumn
            // 
            this.uxToolAuthorColumn.DataPropertyName = "Author";
            this.uxToolAuthorColumn.HeaderText = "Author";
            this.uxToolAuthorColumn.Name = "uxToolAuthorColumn";
            // 
            // uxToolVersionColumn
            // 
            this.uxToolVersionColumn.DataPropertyName = "Version";
            this.uxToolVersionColumn.HeaderText = "Version";
            this.uxToolVersionColumn.Name = "uxToolVersionColumn";
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
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.uxParametersDataGridView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(577, 344);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Parameter plugins";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // uxParametersDataGridView
            // 
            this.uxParametersDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.uxParametersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxParametersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxParametersDataGridView.EnableHeadersVisualStyles = false;
            this.uxParametersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.uxParametersDataGridView.Name = "uxParametersDataGridView";
            this.uxParametersDataGridView.Size = new System.Drawing.Size(577, 344);
            this.uxParametersDataGridView.TabIndex = 0;
            // 
            // uxCancelButton
            // 
            this.uxCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxCancelButton.Location = new System.Drawing.Point(522, 388);
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
            this.uxAcceptButton.Location = new System.Drawing.Point(441, 388);
            this.uxAcceptButton.Name = "uxAcceptButton";
            this.uxAcceptButton.Size = new System.Drawing.Size(75, 23);
            this.uxAcceptButton.TabIndex = 2;
            this.uxAcceptButton.Text = "&OK";
            this.uxAcceptButton.UseVisualStyleBackColor = true;
            this.uxAcceptButton.Click += new System.EventHandler(this.uxAcceptButton_Click);
            // 
            // uxImportLinkLabel
            // 
            this.uxImportLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxImportLinkLabel.AutoSize = true;
            this.uxImportLinkLabel.Location = new System.Drawing.Point(12, 385);
            this.uxImportLinkLabel.Name = "uxImportLinkLabel";
            this.uxImportLinkLabel.Size = new System.Drawing.Size(78, 13);
            this.uxImportLinkLabel.TabIndex = 3;
            this.uxImportLinkLabel.TabStop = true;
            this.uxImportLinkLabel.Text = "Import QRS file";
            this.uxImportLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnImportLinkLabelLinkClicked);
            // 
            // uxExportLinkLabel
            // 
            this.uxExportLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxExportLinkLabel.AutoSize = true;
            this.uxExportLinkLabel.Location = new System.Drawing.Point(96, 385);
            this.uxExportLinkLabel.Name = "uxExportLinkLabel";
            this.uxExportLinkLabel.Size = new System.Drawing.Size(121, 13);
            this.uxExportLinkLabel.TabIndex = 4;
            this.uxExportLinkLabel.TabStop = true;
            this.uxExportLinkLabel.Text = "Export library to QRS file";
            this.uxExportLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnExportLinkLabelLinkClicked);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.uxAcceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uxCancelButton;
            this.ClientSize = new System.Drawing.Size(609, 423);
            this.Controls.Add(this.uxExportLinkLabel);
            this.Controls.Add(this.uxImportLinkLabel);
            this.Controls.Add(this.uxAcceptButton);
            this.Controls.Add(this.uxCancelButton);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MagicWords settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxToolDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxParametersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button uxCancelButton;
		private System.Windows.Forms.Button uxAcceptButton;
		private JRoland.MagicWords.Controls.ListMagicWords listMagicWords1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.PropertyGrid uxUserSettingsPropertyGrid;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private JRoland.MagicWords.Controls.HelpViewer helpViewer1;
		private System.Windows.Forms.LinkLabel uxImportLinkLabel;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.DataGridView uxToolDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn uxToolAliasColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn uxToolNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn uxToolDescriptionColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn uxToolHotKeyColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn uxToolAuthorColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn uxToolVersionColumn;
		private System.Windows.Forms.LinkLabel uxExportLinkLabel;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.DataGridView uxParametersDataGridView;
	}
}