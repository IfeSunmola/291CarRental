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
    public partial class CustViewVehiclesInfoRequest : Form
    {
        private String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader? reader; // nullable, initialization not needed
        private LandingPage previousPage;
        public CustViewVehiclesInfoRequest(LandingPage previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;

            connection = new SqlConnection(connectionString);
            command = new SqlCommand();

            command.Connection = connection;

            this.StartPosition = FormStartPosition.CenterScreen;

            fillVehicleClassAndBranchCombobox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new custViewVehiclePage().Show();
        }

        private void fillVehicleClassAndBranchCombobox()
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

        private void backButtonClick(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }
    }
}
