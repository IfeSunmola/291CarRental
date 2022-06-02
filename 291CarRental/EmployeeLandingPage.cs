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

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void viewAvailableVehiclesButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new EmpViewAllVehicles(this).Show();
        }

        private void returnAVehicleButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ReturnAVehiclePage(this).Show();
        }

        private void vehicleToolsButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new VehicleToolsPage(this).Show();
        }

        private void runCustomReportsButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new RunCustomReportPage(this).Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmExit = MessageBox.Show(
                "Are you sure you want to exit the application?" +
                "\nAny unsaved information will be lost".ToUpper(),
                "CONFIRM EXIT",
                MessageBoxButtons.YesNo);
            if (confirmExit == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
    }
}
