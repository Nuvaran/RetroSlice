using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static RetroSlice_V2.HomePage;

namespace RetroSlice_V2
{
    /// <summary>
    /// Interaction logic for EditCustomerModal.xaml
    /// </summary>
    public partial class EditCustomerModal : Window
    {
        public Customer EditedCustomer { get; private set; }
        public Customer Customer { get; set; }
        public EditCustomerModal( Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            DataContext = Customer;

            // Populate fields with existing customer data
            txtName.Text = customer.Name;
            txtAge.Text = customer.Age.ToString();
            txtHighScoreRank.Text = customer.HighScoreRank.ToString();
            txtNoOfPizzasConsumed.Text = customer.NoOfPizzasConsumed.ToString();
            txtBowlingHighScore.Text = customer.BowlingHighScore.ToString();
            txtSlushPuppyFlavor.Text = customer.SlushPuppyFlavor;
            txtSlushPuppiesConsumed.Text = customer.SlushPuppiesConsumed.ToString();
            chkIsEmployed.IsChecked = customer.IsEmployed;
            dpStartDate.SelectedDate = customer.StartDate;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            EditedCustomer.Name = txtName.Text;
            EditedCustomer.Age = int.Parse(txtAge.Text);
            EditedCustomer.HighScoreRank = int.Parse(txtHighScoreRank.Text);
            EditedCustomer.NoOfPizzasConsumed = int.Parse(txtNoOfPizzasConsumed.Text);
            EditedCustomer.BowlingHighScore = int.Parse(txtBowlingHighScore.Text);
            EditedCustomer.SlushPuppyFlavor = txtSlushPuppyFlavor.Text;
            EditedCustomer.SlushPuppiesConsumed = int.Parse(txtSlushPuppiesConsumed.Text);
            EditedCustomer.IsEmployed = chkIsEmployed.IsChecked ?? false;
            EditedCustomer.StartDate = dpStartDate.SelectedDate ?? DateTime.Now;

            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
