using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Serialcoder.MagicWords.AlarmPlugin
{
	public partial class AlarmForm : Form
	{
		private AlarmForm()
		{
			InitializeComponent();
		}
		private DateTime m_Alarm;

		private void button1_Click(object sender, EventArgs e)
		{
			if (timer1.Enabled == false)
			{
				m_Alarm = dateTimePicker1.Value;
				timer1.Enabled = true;
				button1.Text = "&Stop";
			}
			else
			{
				timer1.Enabled = false;
				button1.Text = "&Start";
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (DateTime.Now.CompareTo(m_Alarm)>0)
			{
				System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.alarm);
				player.Play();
				
				timer1.Enabled = false;
				button1.Enabled = true;
				button1.Text = "&Start";
			}
		}

		#region Singleton

		private static volatile AlarmForm _singleton;
		private static object syncRoot = new Object();

		public static AlarmForm Current
		{
			get
			{
				if (_singleton == null)
				{
					lock (syncRoot)
					{
						if (_singleton == null)
						{
							_singleton = new AlarmForm();
						}
					}
				}

				return _singleton;
			}
		}
		#endregion

	}
}