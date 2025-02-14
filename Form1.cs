using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace FocusAlarmClock
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;
        private System.Timers.Timer focusTimer;
        private System.Timers.Timer breakTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeNotifyIcon();
            InitializeTimers();
        }

        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.Visible = true;
            notifyIcon.Click += NotifyIcon_Click;
        }

        private void InitializeTimers()
        {
            focusTimer = new System.Timers.Timer();
            focusTimer.Elapsed += FocusTimer_Elapsed;

            breakTimer = new System.Timers.Timer();
            breakTimer.Elapsed += BreakTimer_Elapsed;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void FocusTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            focusTimer.Stop();
            MessageBox.Show("专注时间结束！");
        }

        private void BreakTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            breakTimer.Stop();
            MessageBox.Show("休息时间结束！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hours = 0;
            int minutes = 25;

            if (int.TryParse(textBox1.Text, out int h))
            {
                hours = h;
            }

            if (int.TryParse(textBox2.Text, out int m))
            {
                minutes = m;
            }

            focusTimer.Interval = (hours * 60 + minutes) * 60 * 1000;
            focusTimer.Start();

            label5.Text = "当前状态：专注中";
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int hours = 0;
            int minutes = 3;

            if (int.TryParse(textBox3.Text, out int h))
            {
                hours = h;
            }

            if (int.TryParse(textBox4.Text, out int m))
            {
                minutes = m;
            }

            breakTimer.Interval = (hours * 60 + minutes) * 60 * 1000;
            breakTimer.Start();

            label5.Text = "当前状态：休息中";
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            focusTimer.Stop();
            breakTimer.Stop();
            label5.Text = "当前状态：空闲";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = "当前状态：空闲";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // 处理 label1 点击事件
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // 处理 label2 点击事件
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 处理 textBox1 文本变化事件
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // 处理 textBox2 文本变化事件
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
