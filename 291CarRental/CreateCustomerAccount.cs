using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _291CarRental
{

    ///<summary>
    ///This class/form handles creating customer account
    ///</summary>
    public partial class CreateCustomerAccount : Form
    {
        private DbConnection connection;
        private const int MINIMUM_AGE = 25;// minimum age requried to create an account
        private String? returnPhoneNumber = null;// this phone number will be returned to the EmpViewAllVehicles and be automatically filled in 
        public CreateCustomerAccount(DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            fillComboBoxes();
            dateOfBirthPicker.Value = DateTime.Now.AddYears(-MINIMUM_AGE + 1);
        }

        /// <summary>
        /// This method fills the combo boxes in the Form: Gender combo box and Province combo box
        /// </summary>
        private void fillComboBoxes()
        {
            genderCombo.Items.Add("SELECT ONE");
            genderCombo.SelectedIndex = 0;// default is SELECT ON
            genderCombo.Items.Add("FEMALE");
            genderCombo.Items.Add("MALE");
            genderCombo.Items.Add("OTHER (TYPE)");

            provinceCombo.Items.Add("SELECT ONE");
            provinceCombo.SelectedIndex = 0;
            provinceCombo.Items.Add("AB");
            provinceCombo.Items.Add("BC");
            provinceCombo.Items.Add("MB");
            provinceCombo.Items.Add("NB");
            provinceCombo.Items.Add("NL");
            provinceCombo.Items.Add("NS");
            provinceCombo.Items.Add("NT");
            provinceCombo.Items.Add("ON");
            provinceCombo.Items.Add("PE");
            provinceCombo.Items.Add("QC");
            provinceCombo.Items.Add("SK");
        }
        
        /// <summary>
        /// This method validates the information that the customer has entered
        /// </summary>
        /// <returns>
        /// true if the all the customer's information are valid. False if not.
        /// </returns>
        private bool validateInfo()
        {
            int age = (int)((DateTime.Now - dateOfBirthPicker.Value).TotalDays / 365.242199);// use to enforce minimum age
            bool result = false;
            errorMessageLabel.Visible = true;// error message, will hide if all information are valid
            //first and last name validations
            if (String.IsNullOrEmpty(firstNameText.Text) || String.IsNullOrEmpty(lastNameText.Text))
            {
                errorMessageLabel.Text = "FIRST/LAST NAME ARE REQUIRED";
            }

            //email validation
            else if (String.IsNullOrEmpty(emailText.Text))
            {
                errorMessageLabel.Text = "EMAIL IS REQUIRED";
            }
            else if (!Regex.IsMatch(emailText.Text, "[A-Z]+@[A-Z]+\\.[A-Z]+"))
            {
                // email is not valid
                errorMessageLabel.Text = "INVALID EMAIL FORMAT";
            }

            // date of birth/age validations
            else if (age < MINIMUM_AGE)
            {
                errorMessageLabel.Text = "CUSTOMER NEEDS TO BE " + MINIMUM_AGE + "YEARS AND ABOVE";
            }

            //gender validations
            else if (genderCombo.SelectedIndex == 0 || String.IsNullOrEmpty(genderCombo.Text))
            {
                errorMessageLabel.Text = "GENDER IS REQUIRED";
            }

            //phone number validations
            else if (String.IsNullOrEmpty(phoneNumberText.Text))
            {
                errorMessageLabel.Text = "PHONE NUMBER IS REQUIRED";
            }
            else if (stripPhoneNumber(phoneNumberText.Text).Length != 10)
            {
                errorMessageLabel.Text = "PHONE NUMBER MUST BE 10 DIGITS";
            }

            //license number validations
            else if (String.IsNullOrEmpty(licenseNoText.Text))
            {
                errorMessageLabel.Text = "LICENSE NUMBER IS REQUIRED";
            }
            else if (licenseNoText.Text.Length != 8)
            {
                errorMessageLabel.Text = "LICENSE NUMBER MUST BE 8 CHARACTERS";
            }

            //address validations
            else if (String.IsNullOrEmpty(unitNumText.Text) || String.IsNullOrEmpty(streetNumText.Text)
                || String.IsNullOrEmpty(streetNameText.Text) || String.IsNullOrEmpty(cityText.Text)
                || provinceCombo.SelectedIndex == 0 || String.IsNullOrEmpty(postalCodeText.Text))
            {
                errorMessageLabel.Text = "FULL ADDRESS IS REQUIRED";
            }
            else if (postalCodeText.Text.Length != 7)
            {
                errorMessageLabel.Text = "POSTAL CODE MUST BE 7 CHARACTERS";
            }
            else if (!Regex.IsMatch(postalCodeText.Text, "[A-Z][0-9][A-Z][-][0-9][A-Z][0-9]"))
            {
                errorMessageLabel.Text = "POSTAL CODE MUST BE FORM A1B-2C3";
            }

            // all input are valid
            else
            {
                result = true;
                errorMessageLabel.Visible = false;
            }

            return result;
        }

        /// <summary>
        /// this method removes the brackets and hypen that was added when the customer was entering their phone numer
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>The phone number without () and -</returns>
        // remove () and - from the phone number
        private String stripPhoneNumber(String phoneNumber)
        {
            return phoneNumberText.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        }

        /// <summary>
        /// Create the account button click. The account will only be created when the all the customer information is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createAccountButton_Click(object sender, EventArgs e)
        {
            if (validateInfo())// if valid info
            {
                errorMessageLabel.Visible = true;// show error messages for the below statements
                if (phoneNumberInDb())// not allowing duplicate phone numbers
                {
                    errorMessageLabel.Text = "AN ACCOUNT WITH THAT PHONE NUMBER ALREADY EXISTS";
                    return;
                }
                if (licenseInDb())// not allowing duplicate licenses
                {
                    errorMessageLabel.Text = "AN ACCOUNT WITH THAT LICENSE NUMBER ALREADY EXISTS";
                    return;
                }
                // valid info from here out, safe to add
                errorMessageLabel.Visible = false;
                String phoneNumber = stripPhoneNumber(phoneNumberText.Text);
                String areaCode = phoneNumber.Substring(0, 3);
                String number = phoneNumber.Substring(3, 7);

                String query = @"
INSERT INTO Customer
(first_name, last_name, email, date_of_birth, gender, driver_license_no, area_code, phone_number, unit_number, street_number,
street_name, city, province, postal_code)
VALUES
(" + addQuotes(firstNameText.Text) + ", " + addQuotes(lastNameText.Text) + ", " + addQuotes(emailText.Text) + ", " + addQuotes(dateOfBirthPicker.Value.ToString("d")) +
@"," + addQuotes(genderCombo.Text) + ", " + addQuotes(licenseNoText.Text) + ", " + addQuotes(areaCode) + ", " + addQuotes(number)
+ @", " + addQuotes(unitNumText.Text) + ", " + addQuotes(streetNumText.Text) + ", " + addQuotes(streetNameText.Text) + ", " + addQuotes(cityText.Text)
+ @", " + addQuotes(provinceCombo.Text) + ", " + addQuotes(postalCodeText.Text) + ");";
                DialogResult confirmAdding = MessageBox.Show("CREATE THIS ACCOUNT?", "CREATING CUSTOMER ACCOUNT", MessageBoxButtons.YesNo);
                if (confirmAdding == DialogResult.Yes)
                {// add to db
                    // if the amount of rows affected is not equal to 1 (shouldn't happen), show an error so the employee can know something is wrong
                    MessageBox.Show((connection.executeNonQuery(query) == 1 ? "ACCOUNT CREATED SUCCESSFULLY" : "DATABASE ERROR IN CreateCustomerPage, contact administrator"));
                    returnPhoneNumber = areaCode + number;// sets this for EmpViewAllVehicles screen to be auto filled with the new customer's number
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ACCOUNT NOT CREATED");// no was selected
                }
            }
        }

        /// <summary>
        /// Checks if the license number already exists in the database
        /// </summary>
        /// <returns>True if the license exists, false if not</returns>
        private bool licenseInDb()
        {
            String query = "SELECT driver_license_no FROM customer WHERE driver_license_no = " + addQuotes(licenseNoText.Text);
            return connection.executeScalar(query) != null; ;
        }

        /// <summary>
        /// Checks if the phone number already exists in the database
        /// </summary>
        /// <returns>True if the phone number exists, false if not</returns>
        private bool phoneNumberInDb()
        {
            //only selecting area code because I just need to know if the return value is null
            String query = "SELECT area_code FROM customer WHERE CAST(area_code + phone_number AS VARCHAR) = " + addQuotes(stripPhoneNumber(phoneNumberText.Text));
            return connection.executeScalar(query) != null;
        }
        
        /// <summary>
        /// Method to simply add quotes to sql query variables. Closing and opening quotes and adding '' seemed too confusing
        /// </summary>
        /// <param name="rawString"></param>
        /// <returns>A string with '' surrounding it. E.g parameter today will return 'Today'</returns>
        private String addQuotes(String rawString)
        {
            String temp1 = rawString.Insert(0, "'");
            String temp2 = temp1.Insert(temp1.Length, "'");
            return temp2;
        }

        /// <summary>
        /// This method makes any textbox ignore input that aren't numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ignoreCharInput(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// This method adds bracket and hypen to the customer's number as it is being typed in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void phoneNumberText_TextChanged(object sender, EventArgs e)
        {
            String currentNumber = phoneNumberText.Text;
            if (currentNumber.Length == 3 && !currentNumber.Contains("("))
            {// current length is 3 and there are no brackets, add branckets 
                phoneNumberText.Text = "";
                phoneNumberText.AppendText("(" + currentNumber + ") ");
            }
            if (currentNumber.Length == 9 && !currentNumber.Contains("-"))
            {// time to add -
                phoneNumberText.AppendText("-");
            }

        }

        /// <summary>
        /// This method adds hypen to the postal code after the 3rd character
        /// todo: fix the deleting bug
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void postalCodeText_TextChanged(object sender, EventArgs e)
        {
            String currentPostal = postalCodeText.Text;
            if (currentPostal.Length == 3 && !currentPostal.Contains("-"))
            {
                postalCodeText.Text = "";// clear text and append old text + hypen
                postalCodeText.AppendText(currentPostal + "-");
            }
        }

        /// <summary>
        /// This method changes the gender combo box drop down style when the customer choose "Other (Type)". The customer
        /// can type their gender in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genderCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (genderCombo.SelectedIndex == 3)
            {// "Other (type) was selcted, change style"
                genderCombo.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {// change back to DropDownList for any other option that was selected
                genderCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        // after creating the customer account, the customer phone number will be sent back to the previous form so
        // it will be automatically loaded
        internal String? getPhoneNumber()
        {
            return returnPhoneNumber;
        }
    }
}
