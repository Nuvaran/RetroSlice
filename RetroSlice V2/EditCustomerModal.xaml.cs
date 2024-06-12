using System;
using System.Windows;
using static RetroSlice_V2.HomePage;

namespace RetroSlice_V2
{
    public partial class EditCustomerModal : Window
    {
        public Customer Customer { get; set; }

        public EditCustomerModal(Customer customer)
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
            Customer.Name = txtName.Text;
            Customer.Age = int.Parse(txtAge.Text);
            Customer.HighScoreRank = int.Parse(txtHighScoreRank.Text);
            Customer.NoOfPizzasConsumed = int.Parse(txtNoOfPizzasConsumed.Text);
            Customer.BowlingHighScore = int.Parse(txtBowlingHighScore.Text);
            Customer.SlushPuppyFlavor = txtSlushPuppyFlavor.Text;
            Customer.SlushPuppiesConsumed = int.Parse(txtSlushPuppiesConsumed.Text);
            Customer.IsEmployed = chkIsEmployed.IsChecked ?? false;
            Customer.StartDate = dpStartDate.SelectedDate ?? DateTime.Now;

            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

