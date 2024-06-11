﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static RetroSlice_V2.HomePage;

namespace RetroSlice_V2
{
    /// <summary>
    /// Interaction logic for SortingAges.xaml
    /// </summary>
    public partial class SortingAges : Window    {
        private List<Customer> customersSortedByAge = new List<Customer>();
        public SortingAges()
        {
            InitializeComponent();
            HomePage.CustomersUpdated += LoadSortedAges;
            LoadSortedAges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HomePage.CustomersUpdated += LoadSortedAges;
            LoadSortedAges();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            HomePage.CustomersUpdated -= LoadSortedAges;
        }

        private void LoadSortedAges()
        {
            customersSortedByAge = customers.OrderBy(c => c.Age).ToList();

            dgSortedAges.ItemsSource = customersSortedByAge;

            if (customersSortedByAge.Any())
            {
                txtYoungest.Text = $"The youngest customer is: {customersSortedByAge.First().Age} years old";
                txtOldest.Text = $"The oldest customer is: {customersSortedByAge.Last().Age} years old";
            }
            else
            {
                txtYoungest.Text = "No customers available.";
                txtOldest.Text = "No customers available.";
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
