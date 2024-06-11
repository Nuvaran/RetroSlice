using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static RetroSlice_V2.CustomInputDialog;
using static RetroSlice_V2.CreditQualification;
using static RetroSlice_V2.HomePage;


namespace RetroSlice_V2
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public static List<Customer> customers = new List<Customer>();
        private CreditQualification creditQualificationScreen;
        public HomePage()
        {
            InitializeComponent();
            customers = LoadCustomersFromExcel(); // Load existing customers from Excel
            dgCustomers.ItemsSource = customers;
            creditQualificationScreen = new CreditQualification(customers);
            UpdateCounterTitle();
        }

        public class Customer
        {
            public int Age { get; set; }
            public int HighScoreRank { get; set; }
            public int NoOfPizzasConsumed { get; set; }
            public int BowlingHighScore { get; set; }
            public int SlushPuppiesConsumed { get; set; }
            public bool IsEmployed { get; set; }
            public string Name { get; set; }
            public string SlushPuppyFlavor { get; set; }
            public DateTime StartDate { get; set; }
        }

        private void UpdateCustomerList()
        {
            dgCustomers.ItemsSource = null;
            dgCustomers.ItemsSource = customers;
            creditQualificationScreen.PerformCreditQualification();
            creditQualificationScreen.UpdateUI();
        }

        private void btnAddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            popupAddCustomer.IsOpen = true;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Customer newCustomer = new Customer();

            // Validates and captures customer name
            bool validName = !string.IsNullOrWhiteSpace(txtName.Text);
            if (validName) newCustomer.Name = txtName.Text;
            else MessageBox.Show("Invalid Answer! Please enter a name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            // Validates and captures customer age
            bool validAge = int.TryParse(txtAge.Text, out int age) && (age >= 0) && age <= 120;
            if (validAge) newCustomer.Age = age;
            else MessageBox.Show("Invalid Answer! Please enter a valid age (0 -> 120)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            // Validates and captures customer high score rank
            bool validHighScoreRank = int.TryParse(txtHighScoreRank.Text, out int highScoreRank) && (highScoreRank > 0);
            if (validHighScoreRank) newCustomer.HighScoreRank = highScoreRank;
            else MessageBox.Show("Invalid Answer! Please enter a score (0 -> 2000000)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            // Validates and captures number of pizzas consumed
            bool validPizzasConsumed = int.TryParse(txtNoOfPizzasConsumed.Text, out int noOfPizzasConsumed) && (noOfPizzasConsumed > 0);
            if (validPizzasConsumed) newCustomer.NoOfPizzasConsumed = noOfPizzasConsumed;
            else MessageBox.Show("Invalid Answer! Please enter a number (0 -> 2000000)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            // Validates and captures customer bowling high score
            bool validBowlingHighScore = int.TryParse(txtBowlingHighScore.Text, out int bowlingHighScore) && (bowlingHighScore > 0);
            if (validBowlingHighScore) newCustomer.BowlingHighScore = bowlingHighScore;
            else MessageBox.Show("Invalid Answer! Please enter a score (0 -> 2000000)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            // Validates and captures customer slush puppy flavor
            bool validSlushPuppyFlavor = !string.IsNullOrWhiteSpace(txtSlushPuppyFlavor.Text);
            if (validSlushPuppyFlavor) newCustomer.SlushPuppyFlavor = txtSlushPuppyFlavor.Text;
            else MessageBox.Show("Invalid Answer! Please enter a valid flavour", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            // Validates and captures number of slush puppies consumed
            bool validSlushPuppiesConsumed = int.TryParse(txtSlushPuppiesConsumed.Text, out int slushPuppiesConsumed) && (slushPuppiesConsumed > 0);
            if (validSlushPuppiesConsumed) newCustomer.SlushPuppiesConsumed = slushPuppiesConsumed;
            else MessageBox.Show("Invalid Answer! Please enter a number (0 -> 2000000)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            // Validates and captures employment status
            newCustomer.IsEmployed = chkIsEmployed.IsChecked ?? false;

            // Validates and captures start date
            bool validStartDate = dpStartDate.SelectedDate.HasValue && dpStartDate.SelectedDate.Value <= DateTime.Now;
            if (validStartDate) newCustomer.StartDate = dpStartDate.SelectedDate.Value;
            else MessageBox.Show("Invalid Date! Please enter a valid date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            if (validName && validAge && validHighScoreRank && validPizzasConsumed && validBowlingHighScore && validSlushPuppyFlavor && validSlushPuppiesConsumed && validStartDate)
            {
                customers.Add(newCustomer);
                dgCustomers.ItemsSource = null;
                dgCustomers.ItemsSource = customers;
                SaveCustomersToExcel(customers); // Save to Excel
                UpdateCounterTitle(); // Update the title counter with the new number of customers
                popupAddCustomer.IsOpen = false;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            popupAddCustomer.IsOpen = false;
        }

        private void UpdateCounterTitle()
        {
            this.Title = $"HomePage - Total Customers: {customers.Count}";
        }

        public void SaveCustomersToExcel(List<Customer> customers)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "customers.xlsx");
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Customers");
                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Age";
                worksheet.Cells[1, 3].Value = "High Score Rank";
                worksheet.Cells[1, 4].Value = "No Of Pizzas Consumed";
                worksheet.Cells[1, 5].Value = "Bowling High Score";
                worksheet.Cells[1, 6].Value = "Slush Puppies Consumed";
                worksheet.Cells[1, 7].Value = "Employed";
                worksheet.Cells[1, 8].Value = "Slush Puppy Flavor";
                worksheet.Cells[1, 9].Value = "Start Date";

                for (int i = 0; i < customers.Count; i++)
                {
                    var customer = customers[i];
                    worksheet.Cells[i + 2, 1].Value = customer.Name;
                    worksheet.Cells[i + 2, 2].Value = customer.Age;
                    worksheet.Cells[i + 2, 3].Value = customer.HighScoreRank;
                    worksheet.Cells[i + 2, 4].Value = customer.NoOfPizzasConsumed;
                    worksheet.Cells[i + 2, 5].Value = customer.BowlingHighScore;
                    worksheet.Cells[i + 2, 6].Value = customer.SlushPuppiesConsumed;
                    worksheet.Cells[i + 2, 7].Value = customer.IsEmployed;
                    worksheet.Cells[i + 2, 8].Value = customer.SlushPuppyFlavor;
                    worksheet.Cells[i + 2, 9].Value = customer.StartDate.ToShortDateString();
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }

        private List<Customer> LoadCustomersFromExcel()
        {
            var customers = new List<Customer>();

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "customers.xlsx");
            if (File.Exists(filePath))
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet != null)
                    {
                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                        {
                            var customer = new Customer
                            {
                                Name = worksheet.Cells[row, 1].Text,
                                Age = int.Parse(worksheet.Cells[row, 2].Text),
                                HighScoreRank = int.Parse(worksheet.Cells[row, 3].Text),
                                NoOfPizzasConsumed = int.Parse(worksheet.Cells[row, 4].Text),
                                BowlingHighScore = int.Parse(worksheet.Cells[row, 5].Text),
                                SlushPuppiesConsumed = int.Parse(worksheet.Cells[row, 6].Text),
                                IsEmployed = bool.Parse(worksheet.Cells[row, 7].Text),
                                SlushPuppyFlavor = worksheet.Cells[row, 8].Text,
                                StartDate = DateTime.Parse(worksheet.Cells[row, 9].Text)
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is MenuItems menuItem)
            {
                NavigateTo(menuItem);
            }
        }

        public static event Action CustomersUpdated;

        private void NotifyCustomersUpdated()
        {
            CustomersUpdated?.Invoke();
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem != null && dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                EditCustomerModal editModal = new EditCustomerModal(selectedCustomer);
                if (editModal.ShowDialog() == true)
                {
                    // Update the customer list and data grid
                    int index = customers.IndexOf(selectedCustomer);
                    if (index >= 0)
                    {
                        customers[index] = editModal.EditedCustomer;
                        SaveCustomersToExcel(customers);
                        //LoadCustomersToDataGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "No Customer Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomInputDialog inputDialog = new CustomInputDialog("Delete Customer");
            if (inputDialog.ShowDialog() == true)
            {
                string customerName = inputDialog.Input;

                if (!string.IsNullOrEmpty(customerName))
                {
                    Customer customerToDelete = customers.FirstOrDefault(c => c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase));

                    if (customerToDelete != null)
                    {
                        customers.Remove(customerToDelete);
                        UpdateCustomerList();
                        SaveCustomersToExcel(customers);
                        MessageBox.Show("Customer deleted successfully.", "Delete Customer", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.", "Delete Customer", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid name.", "Delete Customer", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void NavigateTo(MenuItems menuItem)
        {
            switch (menuItem)
            {
                case MenuItems.AddNewCustomer:
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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
