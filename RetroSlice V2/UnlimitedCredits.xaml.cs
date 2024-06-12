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
    /// Interaction logic for UnlimitedCredits.xaml
    /// </summary>
    public partial class UnlimitedCredits : Window
    {
        private static List<Customer> customersWithUnlimitedCredit = new List<Customer>();
        public UnlimitedCredits()
        {
            InitializeComponent();
            CustomersUpdated += LoadUnlimitedCreditCustomers;
            LoadUnlimitedCreditCustomers();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CustomersUpdated += LoadUnlimitedCredit;
            LoadUnlimitedCredit();
        }

        private void LoadUnlimitedCredit()
        {
            customersWithUnlimitedCredit = customers
                .Where(c => (DateTime.Now.Year - c.StartDate.Year > 10) ||
                            (DateTime.Now.Year - c.StartDate.Year == 10 && c.StartDate.Month <= DateTime.Now.Month))
                .ToList();

            dgUnlimitedCredit.ItemsSource = customersWithUnlimitedCredit;

            txtUnlimitedCreditCount.Text = $"Number of customers with unlimited credit: {customersWithUnlimitedCredit.Count}";
        }

        private void LoadUnlimitedCreditCustomers()
        {
            customersWithUnlimitedCredit = GetCustomersWithUnlimitedCredit(customers);
            dgUnlimitedCredit.ItemsSource = null; // Clear existing data
            dgUnlimitedCredit.ItemsSource = customersWithUnlimitedCredit;
            txtUnlimitedCreditCount.Text = $"Customers with Unlimited Credit: {customersWithUnlimitedCredit.Count}";
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            CustomersUpdated -= LoadUnlimitedCredit;
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
                    // Navigate to Credit Qualification screen
                    CreditQualification creditQualification = new CreditQualification(customers);
                    creditQualification.Show();
                    this.Close();
                    break;
                case MenuItems.SortingAges:
                    // Navigate to Sorting Ages screen
                    SortingAges sortingAges = new SortingAges();
                    sortingAges.Show();
                    this.Close();
                    break;
                case MenuItems.UnlimitedCredits:
                    // Navigate to Unlimited Credits screen
                    UnlimitedCredits unlimitedCredits = new UnlimitedCredits();
                    unlimitedCredits.Show();
                    this.Close();
                    break;
                case MenuItems.AdditionalFeatures:
                    // Navigate to Additional Features screen
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
