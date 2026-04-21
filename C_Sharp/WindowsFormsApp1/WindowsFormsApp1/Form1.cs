using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // initialize timer for stopwatch
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;

            // initial UI state: show separate components
            richTextBox1.Text = $"{hour:D2}"; // hours
            richTextBox2.Text = $"{min:D2}";  // minutes
            richTextBox3.Text = $"{sec:D2}";  // seconds
            button2.Enabled = false;
        }

        int hour = 0;
        int min = 0;
        int sec = 0;
        private Timer timer;
        private bool running = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                timer.Start();
                running = true;
                this.Text = "Running";
                button1.Enabled = false;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (running)
            {
                timer.Stop();
                running = false;
                this.Text = "Stopped";
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // save current time (hh:mm:ss) to laps.txt
            var current = $"{hour:D2}:{min:D2}:{sec:D2}";
            var path = Path.Combine(Application.StartupPath, "laps.txt");
            try
            {
                File.AppendAllText(path, current + Environment.NewLine);
                MessageBox.Show($"Saved: {current}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec >= 60)
            {
                sec = 0;
                min++;
            }
            if (min >= 60)
            {
                min = 0;
                hour++;
            }

            // update separate displays
            richTextBox1.Text = $"{hour:D2}";
            richTextBox2.Text = $"{min:D2}";
            richTextBox3.Text = $"{sec:D2}";
        }

        // empty handlers for designer wired events
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void richTextBox2_TextChanged(object sender, EventArgs e) { }
        private void richTextBox3_TextChanged(object sender, EventArgs e) { }
    }
}
