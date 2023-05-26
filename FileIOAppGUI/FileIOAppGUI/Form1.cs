using FileIOApp;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileIOAppGUI
{
    public partial class Form1 : Form
    {
        Person p = new Person();
        List<Person> people = new List<Person>();
        BindingSource peopleListBinding = new BindingSource();
        string filePath = @"C:\Users\APR Services\Desktop\peopleOut.txt";

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.firstName = textBox1.Text;
            person.lastName = textBox2.Text;
            person.Url = textBox3.Text;

            people.Add(person);
            richTextBox1.Text = richTextBox1.Text + person.firstName + ", " + person.lastName + ", " + person.Url + "\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> outputLines = new List<string>();

            foreach (Person person in people)
            {
                outputLines.Add(person.firstName + ", " + person.lastName + ", " + person.Url);
            }

            string outPath = @"C:\Users\APR Services\Desktop\peopleOut.txt";
            File.WriteAllLines(outPath, outputLines);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string readfile = File.ReadAllText(filename);
            richTextBox1.Text = readfile;



            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                richTextBox1.Text = richTextBox1.Text + line;
            }
        }
    }
}