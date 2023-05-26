using CarClassLibrary;
using CarShopConsoleApp;

namespace CarShopGUI
{
    public partial class Form1 : Form
    {
        Store store = new Store();

        BindingSource carListBinding = new BindingSource();
        BindingSource ShoppingListBinding = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            carListBinding.DataSource = store.CarList;
            listBox1.DataSource = carListBinding;
            listBox1.DisplayMember = "Display";
            listBox1.ValueMember = "Display";

            ShoppingListBinding.DataSource = store.ShoppingList;
            listBox2.DataSource = ShoppingListBinding;
            listBox2.DisplayMember = "Display";
            listBox2.ValueMember = "Display";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car newCar = new Car();
            newCar.Make = textBox1.Text;
            newCar.Model = textBox2.Text;
           
            newCar.Color = textBox4.Text;
            try
            {
                newCar.Price = Decimal.Parse(textBox3.Text);
                newCar.Year = int.Parse(textBox5.Text);
                store.CarList.Add(newCar);
            }
            catch
            {
                MessageBox.Show("Invalid Price or Year\nItem could not be added");

            }
            carListBinding.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            store.ShoppingList.Add((Car)listBox1.SelectedItem);
            ShoppingListBinding.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal total = store.checkout();
            label5.Text = "$" + total.ToString();
        }
    }
}