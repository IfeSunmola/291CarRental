using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace _291CarRental
{
    public partial class CustSelectVehicleFilters : Form
    {
        private String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader? reader; // nullable, initialization not needed
        private LandingPage previousPage;
        public CustSelectVehicleFilters(LandingPage previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;

            connection = new SqlConnection(connectionString);
            command = new SqlCommand();

            command.Connection = connection;

            this.StartPosition = FormStartPosition.CenterScreen;

            fillComboBoxes();
        }

        // start on click events
        private void backButtonClicked(object sender, EventArgs e)
        {
            this.Close();
            previousPage.Visible = true;
        }

        private void searchButtonClicked(object sender, EventArgs e)
        {
            this.Visible = false;
            new CustViewVehiclePage(this).Show();
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
