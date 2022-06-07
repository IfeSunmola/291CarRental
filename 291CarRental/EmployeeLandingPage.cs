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
        private String empId;

        public EmployeeLandingPage(LandingPage previousPage, String empId)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.empId = empId;

            this.StartPosition = FormStartPosition.CenterScreen;

            empIdLabel.Text = empId;
            empNameLabel.Text = getEmpName();
            
        }

        private String getEmpName()
        {
            String? result = "";
            String query = "SELECT trim(first_name) + ' ' + trim(last_name)" +
                "\nFROM Employee" +
                "\nWHERE emp_id = " + empId + ";";

            var empName = DatabaseConnection.getCommand(query).ExecuteScalar();
            if (empName != null)
            {
                result = empName.ToString();
            }
            DatabaseConnection.kThanksBye();
            return result;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void viewAvailableVehiclesButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new EmpViewAllVehicles(this, empId).Show();
        }

        private void returnAVehicleButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ReturnAVehiclePage(this).Show();
        }

        private void vehicleToolsButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new VehicleToolsPage(this, empId).Show();
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
