namespace JRoland.MagicWords.AlarmPlugin
{
	partial class AlarmForm
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
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.uxCancelButton = new System.Windows.Forms.Button();
			this.uxHideButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(91, 20);
			this.dateTimePicker1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(109, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "&Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// uxCancelButton
			// 
			this.uxCancelButton.Location = new System.Drawing.Point(190, 12);
			this.uxCancelButton.Name = "uxCancelButton";
			this.uxCancelButton.Size = new System.Drawing.Size(75, 23);
			this.uxCancelButton.TabIndex = 2;
			this.uxCancelButton.Text = "&Cancel";
			this.uxCancelButton.UseVisualStyleBackColor = true;
			// 
			// uxHideButton
			// 
			this.uxHideButton.Location = new System.Drawing.Point(12, 119);
			this.uxHideButton.Name = "uxHideButton";
			this.uxHideButton.Size = new System.Drawing.Size(75, 23);
			this.uxHideButton.TabIndex = 2;
			this.uxHideButton.Text = "&Hide";
			this.uxHideButton.UseVisualStyleBackColor = true;
			this.uxHideButton.Click += new System.EventHandler(this.uxHideButton_Click);
			// 
			// AlarmForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(272, 154);
			this.ControlBox = false;
			this.Controls.Add(this.uxHideButton);
			this.Controls.Add(this.uxCancelButton);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dateTimePicker1);
			this.Name = "AlarmForm";
			this.Text = "AlarmForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button uxCancelButton;
		private System.Windows.Forms.Button uxHideButton;
	}
}