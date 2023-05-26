using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroMaker
{
    public partial class Form2 : Form
    {
        Form1 form1;
        private List<SuperHero> listOfHeros;

        public Form2(SuperHeroList superHeroList, Form1 frm1)
        {
            InitializeComponent();
            form1 = frm1;
            if (superHeroList.listOfHeros != null)
            {
                listOfHeros = superHeroList.listOfHeros;
                foreach (SuperHero item in superHeroList.listOfHeros)
                {
                    listBox1.Items.Add(item.Name);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            foreach (SuperHero item in listOfHeros)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == item.Name)
                {
                    richTextBox1.Text = item.Name + " has these powers: ";

                    foreach (var ability in item.Abilities)
                    {
                        richTextBox1.Text = richTextBox1.Text + "\n" + ability.ToString() ;
                    }
                    richTextBox1.Text = richTextBox1.Text + "\nThey have a office in: " + item.OfficeLocation + "."
                                      + "\nPrefered method of transportation is: " + item.Transportation 
                                      + "\n" + item.Name + "s cape color is " + item.Color + ".\n"
                                      + "Propensity to Dark Side: " + item.DarkSidePropensity + ".\n"
                                      + "Speed: " + item.Speed + "% " + "Stamina: " + item.Stamina + "% " + "Strength: " + item.Strength + "% ";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.Show();
        }
    }
}
