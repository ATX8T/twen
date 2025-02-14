using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace FocusAlarmClock
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;
        private System.Timers.Timer focusTimer;
        private System.Timers.Timer breakTimer;
        private DateTime focusEndTime;
        private DateTime breakEndTime;

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
            focusTimer = new System.Timers.Timer(1000); // 每秒触发一次
            focusTimer.Elapsed += FocusTimer_Elapsed;

            breakTimer = new System.Timers.Timer(1000); // 每秒触发一次
            breakTimer.Elapsed += BreakTimer_Elapsed;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void FocusTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan remainingTime = focusEndTime - DateTime.Now;
            if (remainingTime.TotalSeconds <= 0)
            {
                focusTimer.Stop();
                this.Invoke(new Action(() =>
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.BringToFront();
                    MessageBox.Show("专注时间结束！");
                }));
                label8.Invoke(new Action(() => label8.Text = "剩余专注时间：0秒"));
            }
            else
            {
                label8.Invoke(new Action(() => label8.Text = $"剩余专注时间：{remainingTime.Hours}小时 {remainingTime.Minutes}分钟 {remainingTime.Seconds}秒"));
            }
        }

        private void BreakTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan remainingTime = breakEndTime - DateTime.Now;
            if (remainingTime.TotalSeconds <= 0)
            {
                breakTimer.Stop();
                this.Invoke(new Action(() =>
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.BringToFront();
                    MessageBox.Show("休息时间结束！");
                }));
                label9.Invoke(new Action(() => label9.Text = "剩余休息时间：0秒"));
            }
            else
            {
                label9.Invoke(new Action(() => label9.Text = $"剩余休息时间：{remainingTime.Hours}小时 {remainingTime.Minutes}分钟 {remainingTime.Seconds}秒"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hours = 0;
            int minutes = 25;
            int seconds = 0;

            if (int.TryParse(textBox1.Text, out int h))
            {
                hours = h;
            }

            if (int.TryParse(textBox2.Text, out int m))
            {
                minutes = m;
            }

            if (int.TryParse(textBox5.Text, out int s))
            {
                seconds = s;
            }

            focusEndTime = DateTime.Now.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
            focusTimer.Start();

            label5.Text = "当前状态：专注中";
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int hours = 0;
            int minutes = 3;
            int seconds = 0;

            if (int.TryParse(textBox3.Text, out int h))
            {
                hours = h;
            }

            if (int.TryParse(textBox4.Text, out int m))
            {
                minutes = m;
            }

            if (int.TryParse(textBox6.Text, out int s))
            {
                seconds = s;
            }

            breakEndTime = DateTime.Now.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
            breakTimer.Start();

            label5.Text = "当前状态：休息中";
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            focusTimer.Stop();
            breakTimer.Stop();
            label5.Text = "当前状态：空闲";
            label8.Text = "剩余专注时间：0秒";
            label9.Text = "剩余休息时间：0秒";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = "当前状态：空闲";
            label8.Text = "剩余专注时间：0秒";
            label9.Text = "剩余休息时间：0秒";
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
