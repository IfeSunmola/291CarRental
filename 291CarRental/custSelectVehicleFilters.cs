﻿using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace _291CarRental
{
    public partial class CustSelectVehicleFilters : Form
    {
        private DbConnection connection;
        private LandingPage previousPage;

        public CustSelectVehicleFilters(LandingPage previousPage, DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            this.previousPage = previousPage;
            this.StartPosition = FormStartPosition.CenterScreen;
            fromDatePicker.Value = DateTime.Now.AddDays(1);
            toDatePicker.Value = DateTime.Now.AddDays(2);
            addressLabel.Visible = false;
            fillComboBoxes();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (validated())
            {
                this.Visible = false;
                new CustViewVehiclePage(this, fromDatePicker, toDatePicker, (int)vehicleClassCombobox.SelectedIndex,
                    (int)branchComboBox.SelectedIndex, connection).ShowDialog();
            }
        }

        private String getBranchAddress()
        {
            int branchId = (int)branchComboBox.SelectedIndex;// not adding +1 because of "ALL BRANCHES"
            if (branchId == 0)
            {
                return "";
            }

            String query =
                @"SELECT trim(street_number + ' ' + street_name + ', ' + city)
                        FROM Branch 
                    WHERE  branch_id = " + branchId + ";";

            // null checking is not needed here because of the earlier validations but... why not
            String? branchAddress = connection.executeScalar(query);
            if (branchAddress == null)
            {
                branchAddress = "DATABASE ERROR OCCURED IN CustSelectVehicleFilters";
            }

            return branchAddress;
        }

        private bool validated()
        {
            bool result = false;
            String vehicleClassSelected = (String)vehicleClassCombobox.SelectedItem;
            String branchSelected = (String)branchComboBox.SelectedItem;
            if (fromDatePicker.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Vehicles must be booked one day before");
            }
            else if (fromDatePicker.Value.Date >= toDatePicker.Value.Date)
            {
                MessageBox.Show("FROM DATE HAS TO BE BEFORE TO DATE");
            }
            else if (String.IsNullOrEmpty(vehicleClassSelected))
            {
                MessageBox.Show("SELECT A VEHICLE CLASS");
            }
            else if (String.IsNullOrEmpty(branchSelected))
            {
                MessageBox.Show("SELECT A BRANCH");
            }
            else
            {
                result = true;
            }
            return result;
        }

        private void fillComboBoxes()
        {
            vehicleClassCombobox.Items.Add("ALL CLASSES");
            branchComboBox.Items.Add("ALL BRANCHES");
            vehicleClassCombobox.SelectedIndex = 0;
            branchComboBox.SelectedIndex = 0;

            String query = "SELECT vehicle_class FROM Vehicle_Class; SELECT branch_name FROM Branch;";

            SqlDataReader reader = connection.executeReader(query);
            while (reader.Read())
            {
                vehicleClassCombobox.Items.Add(reader.GetString("vehicle_class").ToUpper());
            }
            reader.NextResult();
            while (reader.Read())
            {
                branchComboBox.Items.Add(reader.GetString("branch_name").ToUpper());
            }


            vehicleClassCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            branchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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

        // update the address field as the customer selects different branches
        private void branchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addressLabel.Text = getBranchAddress();
            addressLabel.Visible = true;
        }
    }
}
