using System.Diagnostics;

namespace HeroMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label3.Text = "Speed: " + hScrollBar1.Value;
            int total = hScrollBar1.Value + hScrollBar2.Value + hScrollBar3.Value;
            if(total > 100)
            {
                if(hScrollBar1.Value % 2 == 0)
                {
                    if(hScrollBar2.Value != 0)
                    {
                        hScrollBar2.Value = hScrollBar2.Value - 1;
                        label4.Text = "Stamina: " + hScrollBar2.Value;
                    }
                    else
                    {
                        hScrollBar3.Value = hScrollBar3.Value - 1;
                        label5.Text = "Strength: " + hScrollBar3.Value;
                    }
                }
                else
                {
                    if(hScrollBar3.Value != 0)
                    {
                        hScrollBar3.Value = hScrollBar3.Value - 1;
                        label5.Text = "Strength: " + hScrollBar3.Value;
                    }
                    else
                    {
                        hScrollBar2.Value = hScrollBar2.Value - 1;
                        label4.Text = "Stamina: " + hScrollBar2.Value;
                    }
                }
            }
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label4.Text = "Stamina: " + hScrollBar2.Value;
            int total = hScrollBar1.Value + hScrollBar2.Value + hScrollBar3.Value;
            if (total > 100)
            {
                if (hScrollBar2.Value % 2 == 0)
                {
                    if (hScrollBar1.Value != 0)
                    {
                        hScrollBar1.Value = hScrollBar1.Value - 1;
                        label3.Text = "Speed: " + hScrollBar1.Value;
                    }
                    else
                    {
                        hScrollBar3.Value = hScrollBar3.Value - 1;
                        label5.Text = "Strength: " + hScrollBar3.Value;
                    }
                }
                else
                {
                    if (hScrollBar3.Value != 0)
                    {
                        hScrollBar3.Value = hScrollBar3.Value - 1;
                        label5.Text = "Strength: " + hScrollBar3.Value;
                    }
                    else
                    {
                        hScrollBar1.Value = hScrollBar1.Value - 1;
                        label3.Text = "Speed: " + hScrollBar1.Value;
                    }
                }
            }
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            label5.Text = "Strength: " + hScrollBar3.Value;
            int total = hScrollBar1.Value + hScrollBar2.Value + hScrollBar3.Value;
            if (total > 100)
            {
                if (hScrollBar3.Value % 2 == 0)
                {
                    if (hScrollBar1.Value != 0)
                    {
                        hScrollBar1.Value = hScrollBar1.Value - 1;
                        label3.Text = "Speed: " + hScrollBar1.Value;
                    }
                    else
                    {
                        hScrollBar2.Value = hScrollBar2.Value - 1;
                        label4.Text = "Stamina: " + hScrollBar2.Value;
                    }
                }
                else
                {
                    if (hScrollBar2.Value != 0)
                    {
                        hScrollBar2.Value = hScrollBar2.Value - 1;
                        label4.Text = "Stamina: " + hScrollBar2.Value;
                    }
                    else
                    {
                        hScrollBar1.Value = hScrollBar1.Value - 1;
                        label3.Text = "Speed: " + hScrollBar1.Value;
                    }
                }
            }
        } 
    }
}