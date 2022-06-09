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
        private DbConnection connection;

        public EmployeeLandingPage(LandingPage previousPage, String empId, DbConnection connection)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.empId = empId;
            this.connection = connection;

            this.StartPosition = FormStartPosition.CenterScreen;

            empIdLabel.Text = empId;
            empNameLabel.Text = getEmpName();

        }

        private String getEmpName()
        {
            String query = "SELECT trim(first_name) + ' ' + trim(last_name)" +
                "\nFROM Employee" +
                "\nWHERE emp_id = " + empId + ";";

            String? empName = connection.executeScalar(query);
            if (empName == null)
            {
                empName = "DATABASE ERROR OCCURED IN EmployeeLandingPage";
            }

            return empName;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void viewAvailableVehiclesButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new EmpViewAllVehicles(this, empId, connection).ShowDialog();
        }

        private void returnAVehicleButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ReturnAVehiclePage(this, empId, connection).ShowDialog();
        }

        private void vehicleToolsButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new VehicleToolsPage(this, empId, connection).ShowDialog();
        }

        private void runCustomReportsButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new RunCustomReportPage(this).ShowDialog();
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
