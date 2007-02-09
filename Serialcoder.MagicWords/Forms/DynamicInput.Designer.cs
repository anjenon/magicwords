namespace Serialcoder.MagicWords.Forms
{
	partial class DynamicInput
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
			this.uxNotesLabel = new System.Windows.Forms.Label();
			this.uxAcceptButton = new System.Windows.Forms.Button();
			this.uxCancelButton = new System.Windows.Forms.Button();
			this.uxArgumentComboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// uxNotesLabel
			// 
			this.uxNotesLabel.AutoSize = true;
			this.uxNotesLabel.Location = new System.Drawing.Point(12, 9);
			this.uxNotesLabel.Name = "uxNotesLabel";
			this.uxNotesLabel.Size = new System.Drawing.Size(35, 13);
			this.uxNotesLabel.TabIndex = 3;
			this.uxNotesLabel.Text = "label1";
			// 
			// uxAcceptButton
			// 
			this.uxAcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.uxAcceptButton.Location = new System.Drawing.Point(265, 27);
			this.uxAcceptButton.Name = "uxAcceptButton";
			this.uxAcceptButton.Size = new System.Drawing.Size(32, 23);
			this.uxAcceptButton.TabIndex = 1;
			this.uxAcceptButton.Text = "&OK";
			this.uxAcceptButton.UseVisualStyleBackColor = true;
			// 
			// uxCancelButton
			// 
			this.uxCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.uxCancelButton.Location = new System.Drawing.Point(303, 27);
			this.uxCancelButton.Name = "uxCancelButton";
			this.uxCancelButton.Size = new System.Drawing.Size(75, 23);
			this.uxCancelButton.TabIndex = 2;
			this.uxCancelButton.Text = "&Cancel";
			this.uxCancelButton.UseVisualStyleBackColor = true;
			// 
			// uxArgumentComboBox
			// 
			this.uxArgumentComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.uxArgumentComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.uxArgumentComboBox.Location = new System.Drawing.Point(12, 29);
			this.uxArgumentComboBox.Name = "uxArgumentComboBox";
			this.uxArgumentComboBox.Size = new System.Drawing.Size(247, 21);
			this.uxArgumentComboBox.TabIndex = 4;
			// 
			// DynamicInput
			// 
			this.AcceptButton = this.uxAcceptButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.uxCancelButton;
			this.ClientSize = new System.Drawing.Size(391, 62);
			this.ControlBox = false;
			this.Controls.Add(this.uxArgumentComboBox);
			this.Controls.Add(this.uxCancelButton);
			this.Controls.Add(this.uxAcceptButton);
			this.Controls.Add(this.uxNotesLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DynamicInput";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label uxNotesLabel;
		private System.Windows.Forms.Button uxAcceptButton;
		private System.Windows.Forms.Button uxCancelButton;
		private System.Windows.Forms.ComboBox uxArgumentComboBox;
	}
}