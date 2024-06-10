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
    public partial class SplashScreen3 : Form
    {
        public SplashScreen3()
        {
            InitializeComponent();
        }

        private void SplashScreen3_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            progressBar1.Visible = false; // Hide the progress bar
            btnContinue.Visible = true; // Make the continue button visible
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            HomePage mainForm = new HomePage();
            mainForm.Show();
            this.Hide();
        }
    }
}
