using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroSliceV2
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            fadeInTimer.Start();
        }

        private void fadeInTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05;
            }
            else
            {
                fadeInTimer.Stop();
                displayTimer.Start();
            }
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            displayTimer.Stop();
            fadeOutTimer.Start();
        }

        private void fadeOutTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                fadeOutTimer.Stop();
                SplashScreen2 splashScreen2 = new SplashScreen2();
                splashScreen2.Show();
                this.Hide();
            }
        }
    }
}
