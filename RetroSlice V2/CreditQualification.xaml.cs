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
    /// Interaction logic for CreditQualification.xaml
    /// </summary>
    public partial class CreditQualification : Window
    {
        private List<Customer> customers;
        private List<Customer> customersWtokens;
        private int applicantsAccepted;
        private int applicantsDenied;
        public CreditQualification(List<Customer> customers)
        {
            InitializeComponent();
            this.customers = customers;
            this.customersWtokens = new List<Customer>();
            PerformCreditQualification();
            UpdateUI();
        }

        public void PerformCreditQualification()
        {
            customersWtokens.Clear();
            applicantsAccepted = 0;
            applicantsDenied = 0;

            for (int i = 0; i < customers.Count; i++)
            {
                int yearsLoyal = DateTime.Now.Year - customers[i].StartDate.Year;
                int monthsLoyal = ((yearsLoyal * 12) + (DateTime.Now.Month - customers[i].StartDate.Month));
                if (customers[i].IsEmployed == true //Checking token qualification
                   && yearsLoyal >= 2
                   && (customers[i].HighScoreRank > 2000 || customers[i].BowlingHighScore > 1200)
                   && customers[i].NoOfPizzasConsumed / monthsLoyal >= 3
                   && customers[i].SlushPuppiesConsumed / monthsLoyal >= 4
                   && (!(customers[i].SlushPuppyFlavor.Equals("Gooey Gulp Galore"))))
                {
                    customersWtokens.Add(customers[i]);
                    applicantsAccepted = applicantsAccepted + 1;
                }
                else
                {
                    applicantsDenied = applicantsDenied + 1;
                }
            }
        }

        public void UpdateUI()
        {
            dgQualifiedCustomers.ItemsSource = customersWtokens;
            dgNonQualifiedCustomers.ItemsSource = customers.Except(customersWtokens).ToList();
            txtQualifiedCount.Text = applicantsAccepted.ToString();
            txtNonQualifiedCount.Text = applicantsDenied.ToString();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
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
                    AdditionalFeatures additionalFeatures = new AdditionalFeatures();
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
