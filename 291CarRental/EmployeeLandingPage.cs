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

        // start on click events
        private void backButtonClicked(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void viewAvailableVehiclesButtonClicked(object sender, EventArgs e)
        {
            new empViewAllVehicles(this).Show();
        }

        private void returnAVehicleButtonClicked(object sender, EventArgs e)
        {
            new ReturnAVehiclePage(this).Show();
        }

        private void vehicleToolsButtonClicked(object sender, EventArgs e)
        {
            new VehicleToolsPage(this).Show();
        }

        private void runCustomReportsButtonClicked(object sender, EventArgs e)
        {
            new RunCustomReportPage().Show();
        }
        // end on click events
    }
}
