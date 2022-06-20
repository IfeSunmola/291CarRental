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
    /// <summary>
    /// This class/Form is the home screen for employees. It directs to viewing/renting vehicles, returning vehicles,
    /// adding/deleting/editing vehicles and running reports, 
    /// </summary>
    public partial class EmployeeLandingPage : Form
    {
        private LandingPage previousPage;// connection to previous page for going back
        private String empId;// employee id that was used to log in. It will be passed around all the
                             // forms that links from this screen. The branch of this employee will be used for selecting "defaults"
        private DbConnection connection; //connection to the database

        public EmployeeLandingPage(LandingPage previousPage, String empId, DbConnection connection)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.empId = empId;
            this.connection = connection;

            empIdLabel.Text = empId;
            empNameLabel.Text = getEmpName();

        }

        /// <summary>
        /// This method gets the employee name from the database and returns it. The employee name will be displayed at the side of the screen
        /// </summary>
        /// <returns>The name of the emmployee that logged in</returns>
        private String getEmpName()
        {
            String query = "SELECT trim(first_name) + ' ' + trim(last_name)" +
                "\nFROM Employee" +
                "\nWHERE emp_id = " + empId + ";";

            String? empName = connection.executeScalar(query);
            if (empName == null)// employee name is null meaning for some reason, then there's an error
            {
                empName = "DATABASE ERROR OCCURED IN EmployeeLandingPage, contact your administrator";
            }
            return empName;
        }

        /// <summary>
        /// back button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        /// <summary>
        /// view available vehicles was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewAvailableVehiclesButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;// hide screens and show accordingly
            new EmpViewAllVehicles(this, empId, connection).ShowDialog();
            this.Visible = true;
        }

        /// <summary>
        /// return a vehicle button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnAVehicleButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;// hide screens and show accordingly
            new ReturnAVehiclePage(this, empId, connection).ShowDialog();
            this.Visible = true;
        }

        /// <summary>
        /// vehicle tools button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vehicleToolsButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new VehicleToolsPage(this, empId, connection).ShowDialog();
            this.Visible = true;
        }

        /// <summary>
        /// custom reports screen was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runCustomReportsButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new RunCustomReportPage(this, connection).ShowDialog();
            this.Visible = true;
        }

        /// <summary>
        /// exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
