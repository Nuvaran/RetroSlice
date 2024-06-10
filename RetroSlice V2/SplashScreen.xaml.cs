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
using System.Windows.Threading;
using RetroSlice;


namespace RetroSlice_V2
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        readonly DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public SplashScreen()
        {
            InitializeComponent();

            dispatcherTimer.Tick += new EventHandler(MySplash);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 13);
            dispatcherTimer.Start();
        }

        private void MySplash(object sender, EventArgs e)
        {
            HomePage main = new HomePage();
            main.Show();

            dispatcherTimer.Stop();
            this.Close();
        }
    }
}
