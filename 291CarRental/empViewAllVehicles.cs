﻿using System;
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
    public partial class EmpViewAllVehicles : Form
    {
        private String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader? reader; // nullable, initialization not needed
        private EmployeeLandingPage previousPage;
        public EmpViewAllVehicles(EmployeeLandingPage previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;

            connection = new SqlConnection(connectionString);
            command = new SqlCommand();

            command.Connection = connection;

            this.StartPosition = FormStartPosition.CenterScreen;

            fillComboBoxes();
        }

        private DataTable getAvailableVehicleList()
        {
            DataTable cars = new DataTable();
            String query = @"SELECT vehicle_id, branch_name Location, vehicle_class Class, [year] Year, brand Brand, model Model
                                 FROM Vehicle, Branch, Vehicle_Class
                                 WHERE Vehicle.branch_id = Branch.branch_id
                                 AND Vehicle.vehicle_class_id = vehicle_class.vehicle_class_id;
                                ";
            try
            {
                connection.Open();
                command.CommandText = query;
                reader = command.ExecuteReader();
                cars.Load(reader);
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return cars;
        }

        // start on click events
        private void backButtonClicked(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void findAvailableVehiclesButtonClicked(object sender, EventArgs e)
        {
            //new empViewVehiclePage().Show();
            // load data into the DataGripView
            //showVehicleDataGridView.Rows.Clear();
            showVehicleDataGridView.DataSource = getAvailableVehicleList();
            showVehicleDataGridView.Columns["vehicle_id"].Visible = false;
            //disable sorting the columns
            foreach (DataGridViewColumn dataGridViewColumn in showVehicleDataGridView.Columns)
            {
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            showVehicleDataGripViewPanel.Visible = true;
            rentVehicleButton.Visible = true;
        }

        private void vehicleInfoClicked(object sender, DataGridViewCellMouseEventArgs e)
        {
            String query = "";
            try
            {
                connection.Open();
                command.CommandText = query;
                // reader = command.ExecuteReader();

                //reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            estimatedCostLabel.Text = "ESTIMATED COST: $120";
        }

        private void rentThisVehicleButtonClicked(object sender, EventArgs e)
        {
            DialogResult confirmRenting = MessageBox.Show(
              "Confirm renting of 2022 KIA SPORTAGE for JOHN DOE (003) ",
              "CONFIRM RENTING VEHICLE",
              MessageBoxButtons.YesNo);

            if (confirmRenting == DialogResult.Yes)
            {
                MessageBox.Show("VEHICLE RENTED SUCCESSFULLY");
            }
            else if (confirmRenting == DialogResult.No)
            {
                MessageBox.Show("VEHICLE NOT RENTED");
            }
        }
        // end on click events
        
        private void fillComboBoxes()
        {
            String query = "SELECT vehicle_class FROM Vehicle_Class; SELECT branch_name FROM Branch;";
            try
            {
                connection.Open();
                command.CommandText = query;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    vehicleClassCombobox.Items.Add(reader.GetString("vehicle_class"));
                }
                reader.NextResult();
                while (reader.Read())
                {
                    branchComboBox.Items.Add(reader.GetString("branch_name"));
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
