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
    public partial class StartAReturnPage : Form
    {
        private ReturnAVehiclePage previousPage;
        private DbConnection connection;
        private String empId;

        private String rentalId;
        private String? name;
        private DateTime? startDate;
        private DateTime? expectedDropoffDate;
        private String? amountPaid;
        private String? expectedDropoffLocation;
        private String? vehicleRented;

        public StartAReturnPage(ReturnAVehiclePage previousPage, String empId, DbConnection connection, String rentalId, String name, String? startDate, String? expectedDropoffDate, String? amountPaid, String? expectedDropoffLocation,
            String vehicleRented)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.connection = connection;
            this.empId = empId;
            this.StartPosition = FormStartPosition.CenterScreen;
            returnDateTimePicker.Value = DateTime.Now;
            amountDuePanel.Visible = false;
            fillBranchCombobox();

            this.rentalId = rentalId;
            this.name = name;
            this.startDate = Convert.ToDateTime(startDate);
            this.expectedDropoffDate = Convert.ToDateTime(expectedDropoffDate);
            this.amountPaid = amountPaid;
            this.expectedDropoffLocation = expectedDropoffLocation;
            this.vehicleRented = vehicleRented;

            returnLabelText.Text = "RETURNING " + vehicleRented.ToUpper() + " FOR " + name.ToUpper();
        }


        private void calculateAmountDue_ButtonClicked(object sender, EventArgs e)
        {
            Decimal changeBranchFee = 0.00m;
            Decimal lateFee = 0.00m;
            bool isGoldMember = getFees().Item3;
            // is late fee a flat fee or is it based on how many days late the customer was?

            if ((int)mileageUsedTextbox.Value <= 0)
            {
                MessageBox.Show("Enter a valid mileage");
                return;
            }
            else
            {
                String actualDropoffLocation = (String)branchCombobox.SelectedItem;
                if (!String.Equals(actualDropoffLocation, expectedDropoffLocation, StringComparison.OrdinalIgnoreCase))
                {// returning to the different location
                    if (!isGoldMember)
                    {
                        changeBranchFee = getFees().Item1;
                        MessageBox.Show("Returning to different location");
                    }
                    else
                    {
                        feeWaiverLabel.Text = "DIFFERENT BRANCH RETURN FEE OF " + getFees().Item1.ToString("C") + " HAS BEEN " +
                 " WAIVED FOR THIS GOLD CUSTOMER HEHEHE";
                        feeWaiverLabel.Visible = true;
                        MessageBox.Show("GOLD MEMBER RETURNING, SHOULD BE FREE");
                    }
                }
                else
                {
                    feeWaiverLabel.Visible = false;
                }
                if (expectedDropoffDate.Value.AddDays(1) <= returnDateTimePicker.Value)
                {// drop off is late
                    lateFee = getFees().Item2;
                    MessageBox.Show("Late Returns");
                }
            }
            amountPaidLabel.Text = amountPaid;
            lateFeeLabel.Text = lateFee.ToString("C");
            differentBranchFeeLabel.Text = changeBranchFee.ToString("C");
            amountDueNowLabel.Text = (lateFee + changeBranchFee).ToString("C");
            amountDuePanel.Visible = true;
        }

        private Tuple<Decimal, Decimal, bool> getFees()
        {
            String query = @"SELECT change_branch_fee, late_fee
                FROM Vehicle_Class
                WHERE vehicle_class_id in (SELECT vehicle_class_requested FROM Rental WHERE rental_id = " + rentalId + @");
                SELECT membership_type 
                FROM Customer
                WHERE customer_id in (SELECT customer_id FROM Rental WHERE rental_id =  " + rentalId + @") ";
            SqlDataReader reader = connection.executeReader(query);
            Decimal changeBranchFee = 0.00m, lateFee = 0.00m;
            bool isGoldMember = false;
            while (reader.Read())
            {
                changeBranchFee = reader.GetDecimal("change_branch_fee");
                lateFee = reader.GetDecimal("late_fee");
            }
            reader.NextResult();
            if (reader.Read())
            {
                String status = reader.GetString("membership_type");
                isGoldMember = String.Equals(status, "GOLD", StringComparison.OrdinalIgnoreCase);
            }
            return Tuple.Create(changeBranchFee, lateFee, isGoldMember);
        }

        private void fillBranchCombobox()
        {
            String query =
                "\nSELECT branch_name FROM Branch;" +
                "\nSELECT Employee.branch_id" +
                "\nFROM Employee, Branch " +
                "\nWHERE Employee.branch_id = Branch.branch_id" +
                "\nAND emp_id = " + empId;
            SqlDataReader reader = connection.executeReader(query);

            while (reader.Read())
            {
                branchCombobox.Items.Add(reader.GetString("branch_name").ToUpper());
            }
            reader.NextResult();
            if (reader.Read())
            {
                branchCombobox.SelectedIndex = reader.GetInt32("branch_id") - 1;
            }

            branchCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void finishReturn_ButtonClicked(object sender, EventArgs e)
        {

            DialogResult confirmReturn = MessageBox.Show(
          ("Confirm returning of " + vehicleRented + " FOR " + name).ToUpper(),
          "CONFIRM RETURN VEHICLE",
          MessageBoxButtons.YesNo);

            if (confirmReturn == DialogResult.Yes)
            {

                if (vehicleWasReturned(amountDueNowLabel.Text))
                {
                    MessageBox.Show("VEHICLE RETURNED SUCCESSFULLY");
                    this.Close();
                    previousPage.Visible = true;
                }
                else
                {
                    MessageBox.Show("DATABASE ERROR OCCURED AT StartAReturnPage");
                }


            }
            else if (confirmReturn == DialogResult.No)
            {
                MessageBox.Show("VEHICLE RETURN CANCELLED");
            }
        }


        private bool vehicleWasReturned(String extraCharge)
        {
            String actualDropoffDate = returnDateTimePicker.Value.Date.ToString("d");
            String query = @"UPDATE Rental
                            SET actual_dropoff_date = " + addQuotes(actualDropoffDate) + @", 
total_mileage_used = " + mileageUsedTextbox.Text + @", extra_charges = " + extraCharge + ", emp_id_return = " + empId + ", " +
"dropoff_branch_id = " + (branchCombobox.SelectedIndex + 1) +
@"WHERE rental_id = " + rentalId;

            MessageBox.Show(query);
            return connection.executeNonQuery(query) > 0;
        }

        private String addQuotes(String stringToAdd)
        {
            String temp1 = stringToAdd.Insert(0, "'");
            String temp2 = temp1.Insert(temp1.Length, "'");
            return temp2;
        }

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
