using System.Diagnostics;

namespace WhackMole
{
    public partial class Form1 : Form
    {
        public static Stopwatch watch = new Stopwatch();
        private Random random = new Random();
        private int score = 0;
        private int highScore = 0;
        private bool start = false;
        private int bombSpeed = 2;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        /*
         * Start button starts the watch and starts the game
         */
        private void button2_Click(object sender, EventArgs e)
        {
            start = true;
            watch.Start();
        }

        /*
         * Stops the watch and ends the game
         */
        private void button3_Click(object sender, EventArgs e)
        {
            start = false;
            watch.Stop();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        /*
         * Restarts the watch and game
         */
        private void button4_Click(object sender, EventArgs e)
        {
            start = true;
            score = 0;
            label2.Text = "Score: " + score;
            watch.Restart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = watch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
            ts.Hours, ts.Minutes, ts.Seconds);
            label1.Text = elapsedTime;
            if (ts.Minutes < 1)
            {
                if (start == true)
                {
                    if (random.Next(0, 10) < 5)
                    {
                        pictureBox1.Left = random.Next(30, this.Width - 100);
                        pictureBox1.Top = random.Next(30, this.Height - 150);
                        pictureBox1.Visible = true;
                    }
                    if (random.Next(0, 10) < bombSpeed)
                    {
                        pictureBox2.Left = random.Next(30, this.Width - 100);
                        pictureBox2.Top = random.Next(30, this.Height - 150);
                        pictureBox2.Visible = true;
                    }
                }
            }
            else
            {
                watch.Stop();
                if (start == true)
                {
                    start = false;
                    MessageBox.Show("Game Over\nYour score was " + score);
                }
                if(score > highScore)
                {
                    highScore = score;
                    label3.Text = "High Score: " + highScore;
                }
                score = 0;
                label2.Text = "Score: " + score;
                watch.Reset();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            score++;
            bombSpeed = 2 + (score / 5);
            label2.Text = "Score: " + score;
            pictureBox1.Visible = false;
            Debug.WriteLine(bombSpeed);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if(start == true)
            {

                score--;
                bombSpeed = 2 + (score / 5);
                label2.Text = "Score: " + score;
                Debug.WriteLine(bombSpeed);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            score = score - 5;
            bombSpeed = 2 + (score / 5);
            label2.Text = "Score: " + score;
            pictureBox2.Visible = false;
            Debug.WriteLine(bombSpeed);
        }
    }
}