using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _291CarRental
{
    public partial class VehicleToolsPage : Form
    {
        private EmployeeLandingPage previousPage;
        public VehicleToolsPage(EmployeeLandingPage previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;

            this.StartPosition = FormStartPosition.CenterScreen;
            updatePanel.Visible = false;

        }

        private void deleteVehicleButton_Click(object sender, EventArgs e)
        {
            // don't delete vehicle if it is has been rented out
            DialogResult confirmDelete = MessageBox.Show(
                "Are you sure you want to delete (vehicle details)?" +
                "\nThis process is IRREVERSIBLE.", 
                "CONFORM VEHICLE DELETE",
                MessageBoxButtons.YesNo);

            if (confirmDelete == DialogResult.Yes)
            {
                MessageBox.Show("Vehicle deleted");
            }
            else
            {
                MessageBox.Show("Deletion cancelled");
            }
        }

        // add 
        private void addVehicleButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmAdding = MessageBox.Show(
               "Confirm adding of (vehicle details?)",
               "CONFIRM ADDING VEHICLE",
               MessageBoxButtons.YesNo);

            if (confirmAdding == DialogResult.Yes)
            {
                MessageBox.Show("VEHICLE ADDED SUCCESSFULLY");
            }
            else if (confirmAdding == DialogResult.No)
            {
                MessageBox.Show("VEHICLE NOT ADDED");
            }
        }
        // update
        private void startUpdatingButton_Click(object sender, EventArgs e)
        {
            updatePanel.Visible = true;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmUpdating = MessageBox.Show(
               "Confirm updating of (vehicle details?)",
               "CONFIRM UPDATE VEHICLE",
               MessageBoxButtons.YesNo);

            if (confirmUpdating == DialogResult.Yes)
            {
                MessageBox.Show("VEHICLE UPDATED SUCCESSFULLY");
            }
            else if (confirmUpdating == DialogResult.No)
            {
                MessageBox.Show("VEHICLE NOT UPDATED");
            }
        }
        // delete

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
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
