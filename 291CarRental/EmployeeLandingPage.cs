using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _291CarRental
{
    public partial class EmployeeLandingPage : Form
    {
        private LandingPage previousPage;
        public EmployeeLandingPage(LandingPage previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new empViewAllVehicles(this).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new VehicleToolsPage(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ReturnAVehiclePage(this).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new RunCustomReportPage().Show();  
        }

        private void backButtonClick(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }
    }
}
