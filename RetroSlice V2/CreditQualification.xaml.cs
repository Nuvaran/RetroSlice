using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static RetroSlice_V2.HomePage;

namespace RetroSlice_V2
{
    public partial class CreditQualification : Window
    {
        private List<Customer> customersWtokens = new List<Customer>();
        private List<Customer> customersWithoutTokens = new List<Customer>();
        private int applicantsAccepted;
        private int applicantsDenied;

        public CreditQualification(List<Customer> customers)
        {
            InitializeComponent();
            LoadCreditQualification();
            UpdateUI();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CustomersUpdated += LoadCreditQualification;
            LoadCreditQualification();
            UpdateUI();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            CustomersUpdated -= LoadCreditQualification;
        }

        public void LoadCreditQualification()
        {
            customersWtokens.Clear();
            customersWithoutTokens.Clear();
            applicantsAccepted = 0;
            applicantsDenied = 0;

            foreach (var customer in customers)
            {
                int yearsLoyal = DateTime.Now.Year - customer.StartDate.Year;
                int monthsLoyal = ((yearsLoyal * 12) + (DateTime.Now.Month - customer.StartDate.Month));

                if (customer.IsEmployed == true // Checking token qualification
                   && yearsLoyal >= 2
                   && (customer.HighScoreRank > 2000 || customer.BowlingHighScore > 1200)
                   && customer.NoOfPizzasConsumed / monthsLoyal >= 3
                   && customer.SlushPuppiesConsumed / monthsLoyal >= 4
                   && (!(customer.SlushPuppyFlavor.Equals("Gooey Gulp Galore"))))
                {
                    customersWtokens.Add(customer);
                    applicantsAccepted++;
                }
                else
                {
                    customersWithoutTokens.Add(customer);
                    applicantsDenied++;
                }
            }
            UpdateUI();
        }

        public void UpdateUI()
        {
            dgQualifiedCustomers.ItemsSource = null;
            dgQualifiedCustomers.ItemsSource = customersWtokens;

            dgNonQualifiedCustomers.ItemsSource = null;
            dgNonQualifiedCustomers.ItemsSource = customersWithoutTokens;

            txtQualifiedCount.Text = applicantsAccepted.ToString();
            txtNonQualifiedCount.Text = applicantsDenied.ToString();
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
