using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static RetroSlice_V2.HomePage;

namespace RetroSlice_V2
{
    public partial class AdditionalFeatures : Window
    {
        private List<Customer> customers;
        public AdditionalFeatures(List<Customer> customers)
        {
            InitializeComponent();
            this.customers = customers;
            this.Loaded += AdditionalFeatures_Loaded;
        }

        private void AdditionalFeatures_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateAveragePizzasConsumed();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateAveragePizzasConsumed();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim();
            if (!string.IsNullOrEmpty(customerName))
            {
                var customer = customers.FirstOrDefault(c => c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase));
                if (customer != null)
                {
                    var customerStats = new List<Customer> { customer };
                    dgCustomerStats.ItemsSource = customerStats;
                }
                else
                {
                    MessageBox.Show("Customer not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    dgCustomerStats.ItemsSource = null;
                }
            }
        }

        private void CalculateAveragePizzasConsumed()
        {
            if (customers.Count > 0)
            {
                // Debugging information
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Customer: {customer.Name}, Pizzas Consumed: {customer.NoOfPizzasConsumed}");
                }

                int totalPizzasConsumed = customers.Sum(c => c.NoOfPizzasConsumed);
                double averagePizzasConsumed = (double)totalPizzasConsumed / customers.Count;
                lblAveragePizzasConsumed.Content = averagePizzasConsumed.ToString("0.00");
            }
            else
            {
                lblAveragePizzasConsumed.Content = "0.00";
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is MenuItems menuItem)
            {
                NavigateTo(menuItem);
            }
        }

        private void NavigateTo(MenuItems menuItem)
        {
            switch (menuItem)
            {
                case MenuItems.AddNewCustomer:
                    HomePage homePage = new HomePage();
                    homePage.Show();
                    this.Close();
                    break;
                case MenuItems.CreditQualification:
                    CreditQualification creditQualification = new CreditQualification(customers);
                    creditQualification.Show();
                    this.Close();
                    break;
                case MenuItems.SortingAges:
                    SortingAges sortingAges = new SortingAges();
                    sortingAges.Show();
                    this.Close();
                    break;
                case MenuItems.UnlimitedCredits:
                    UnlimitedCredits unlimitedCredits = new UnlimitedCredits();
                    unlimitedCredits.Show();
                    this.Close();
                    break;
                case MenuItems.AdditionalFeatures:
                    AdditionalFeatures additionalFeatures = new AdditionalFeatures(customers);
                    additionalFeatures.Show();
                    this.Close();
                    break;
                case MenuItems.Exit:
                    Application.Current.Shutdown();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool isMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (isMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    isMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    isMaximized = true;
                }
            }
        }
    }
}

