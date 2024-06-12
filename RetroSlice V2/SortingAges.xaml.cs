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

        private int _currentPage = 1;
        private const int _itemsPerPage = 50;
        public SortingAges()
        {
            InitializeComponent();
            CustomersUpdated += LoadSortedAges;
            LoadSortedAges();
            UpdatePageNumbers();
            DisplayCurrentPage();
        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayCurrentPage();
            }
        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < (customers.Count + _itemsPerPage - 1) / _itemsPerPage)
            {
                _currentPage++;
                DisplayCurrentPage();
            }
        }

        private void BtnPageNumber_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse((sender as Button)?.Content.ToString(), out int pageNumber))
            {
                _currentPage = pageNumber;
                DisplayCurrentPage();
            }
        }

        private void UpdatePageNumbers()
        {
            PageNumberButtons.Items.Clear();
            int totalPages = (customers.Count + _itemsPerPage - 1) / _itemsPerPage;
            for (int i = 1; i <= totalPages; i++)
            {
                Button pageButton = new Button
                {
                    Content = i.ToString(),
                    Style = (Style)FindResource("pagingButton"),
                    Background = (i == _currentPage) ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7950f2")) : new SolidColorBrush(Colors.White),
                    Foreground = (i == _currentPage) ? new SolidColorBrush(Colors.White) : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6c7682"))
                };
                pageButton.Click += BtnPageNumber_Click;
                PageNumberButtons.Items.Add(pageButton);
            }
        }

        private void DisplayCurrentPage()
        {
            int skip = (_currentPage - 1) * _itemsPerPage;
            dgSortedAges.ItemsSource = customers.Skip(skip).Take(_itemsPerPage).ToList();
            UpdatePageNumbers();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CustomersUpdated += LoadSortedAges;
            LoadSortedAges();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            CustomersUpdated -= LoadSortedAges;
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
