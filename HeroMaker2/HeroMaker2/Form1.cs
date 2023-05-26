using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using HeroMaker;

namespace HeroMaker
{
    public partial class Form1 : Form
    {
        SuperHeroList list = new SuperHeroList();

        public Form1()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            speedLabel.Text = "Speed: " + speedHScrollbar.Value;
            int total = speedHScrollbar.Value + staminaHScrollbar.Value + strengthHScrollBar.Value;
            if(total > 100)
            {
                if(speedHScrollbar.Value % 2 == 0)
                {
                    if(staminaHScrollbar.Value != 0)
                    {
                        staminaHScrollbar.Value = staminaHScrollbar.Value - 1;
                        staminaLabel.Text = "Stamina: " + staminaHScrollbar.Value;
                    }
                    else
                    {
                        strengthHScrollBar.Value = strengthHScrollBar.Value - 1;
                        strengthLabel.Text = "Strength: " + strengthHScrollBar.Value;
                    }
                }
                else
                {
                    if(strengthHScrollBar.Value != 0)
                    {
                        strengthHScrollBar.Value = strengthHScrollBar.Value - 1;
                        strengthLabel.Text = "Strength: " + strengthHScrollBar.Value;
                    }
                    else
                    {
                        staminaHScrollbar.Value = staminaHScrollbar.Value - 1;
                        staminaLabel.Text = "Stamina: " + staminaHScrollbar.Value;
                    }
                }
            }
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            staminaLabel.Text = "Stamina: " + staminaHScrollbar.Value;
            int total = speedHScrollbar.Value + staminaHScrollbar.Value + strengthHScrollBar.Value;
            if (total > 100)
            {
                if (staminaHScrollbar.Value % 2 == 0)
                {
                    if (speedHScrollbar.Value != 0)
                    {
                        speedHScrollbar.Value = speedHScrollbar.Value - 1;
                        speedLabel.Text = "Speed: " + speedHScrollbar.Value;
                    }
                    else
                    {
                        strengthHScrollBar.Value = strengthHScrollBar.Value - 1;
                        strengthLabel.Text = "Strength: " + strengthHScrollBar.Value;
                    }
                }
                else
                {
                    if (strengthHScrollBar.Value != 0)
                    {
                        strengthHScrollBar.Value = strengthHScrollBar.Value - 1;
                        strengthLabel.Text = "Strength: " + strengthHScrollBar.Value;
                    }
                    else
                    {
                        speedHScrollbar.Value = speedHScrollbar.Value - 1;
                        speedLabel.Text = "Speed: " + speedHScrollbar.Value;
                    }
                }
            }
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            strengthLabel.Text = "Strength: " + strengthHScrollBar.Value;
            int total = speedHScrollbar.Value + staminaHScrollbar.Value + strengthHScrollBar.Value;
            if (total > 100)
            {
                if (strengthHScrollBar.Value % 2 == 0)
                {
                    if (speedHScrollbar.Value != 0)
                    {
                        speedHScrollbar.Value = speedHScrollbar.Value - 1;
                        speedLabel.Text = "Speed: " + speedHScrollbar.Value;
                    }
                    else
                    {
                        staminaHScrollbar.Value = staminaHScrollbar.Value - 1;
                        staminaLabel.Text = "Stamina: " + staminaHScrollbar.Value;
                    }
                }
                else
                {
                    if (staminaHScrollbar.Value != 0)
                    {
                        staminaHScrollbar.Value = staminaHScrollbar.Value - 1;
                        staminaLabel.Text = "Stamina: " + staminaHScrollbar.Value;
                    }
                    else
                    {
                        speedHScrollbar.Value = speedHScrollbar.Value - 1;
                        speedLabel.Text = "Speed: " + speedHScrollbar.Value;
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                capeColorPicturebox.BackColor = color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            darkSidePropLabel.Text = "Dark Side Propensity: " + darkSideTrackbar.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuperHero superHero = new SuperHero();
            superHero.Name = herosNameTextbox.Text;
            foreach (CheckBox c in specialAbilitiesCheckbox.Controls.OfType<CheckBox>())
            {
                if( superHero.Abilities == null)
                {
                    superHero.Abilities = new ArrayList();
                }
                if (c.Checked == true)
                {
                    superHero.Abilities.Add(c.Text);
                }
            }

            superHero.Birthday = birthdayDateTimePicker.Text;
            superHero.SuperPowerDiscovery = superPowerDateTimePicker.Text;
            superHero.FatefulDay = fatefulDateTimePicker.Text;
            superHero.OfficeLocation = cityListbox.Text;
            
            foreach(RadioButton r in transportGroupbox.Controls.OfType<RadioButton>())
            {
                if(r.Checked == true)
                {
                    superHero.Transportation = r.Text;
                    Debug.WriteLine(r.Text);
                }
            }
            superHero.YearsExperience = (int)yearExperienceNumericUpDown1.Value;
            superHero.Color = capeColorPicturebox.BackColor.ToString();
            superHero.DarkSidePropensity = darkSideTrackbar.Value;
            superHero.Speed = speedHScrollbar.Value;
            superHero.Stamina = staminaHScrollbar.Value;
            superHero.Strength = strengthHScrollBar.Value;

            if(list.listOfHeros == null)
            {
                list.listOfHeros = new List<SuperHero>();
            }
            list.listOfHeros.Add(superHero);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(list, this);
            this.Hide();
            f2.Show();
        }
    }
}