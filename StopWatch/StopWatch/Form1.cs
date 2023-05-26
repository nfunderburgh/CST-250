using System.Diagnostics;

namespace StopWatch
{
    public partial class Form1 : Form
    {
        public static Stopwatch watch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            watch.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            watch.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            watch.Reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = watch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            label1.Text = elapsedTime;
        }
    }
}