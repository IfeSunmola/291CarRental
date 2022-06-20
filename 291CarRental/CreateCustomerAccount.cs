using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _291CarRental
{
    public partial class CreateCustomerAccount : Form
    {
        private DbConnection connection;
        public CreateCustomerAccount(DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            fillComboBoxes();
            dateOfBirthPicker.Value = DateTime.Now.AddYears(-23);
        }
        
        private void fillComboBoxes()
        {
            genderCombo.Items.Add("SELECT ONE");
            genderCombo.SelectedIndex = 0;
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
       
        //validate information in the textbox
        private bool validateInfo()
        { 
            int age = (int)((DateTime.Now - dateOfBirthPicker.Value).TotalDays / 365.242199);
            bool result = false;
            errorMessageLabel.Visible = true;
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
            else if (!Regex.IsMatch(emailText.Text, "[A-Z]+@[A-Z]+\\.[A-Z]+")){
                // email is not valid
                errorMessageLabel.Text = "INVALID EMAIL FORMAT";
            }
            
            // date of birth/age validations
            else if (age < 23)
            {
                errorMessageLabel.Text = "CUSTOMER NEEDS TO BE 23 YEARS AND ABOVE";
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

        private String stripPhoneNumber(String phoneNumber)
        {
            return phoneNumberText.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        }
        private void createAccountButton_Click(object sender, EventArgs e)
        {
            validateInfo();
        }

        // this method makes textboxes ignore inputs that aren't numbers
        private void ignoreCharInput(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        // this method adds bracket and hypen to the customer's number as it is being typed in
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

        // same as above, just hypen
        private void postalCodeText_TextChanged(object sender, EventArgs e)
        {
            String currentPostal = postalCodeText.Text;
            if (currentPostal.Length == 3 && !currentPostal.Contains("-"))
            {
                postalCodeText.Text = "";
                postalCodeText.AppendText(currentPostal + "-");
            }
        }

        private void genderCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (genderCombo.SelectedIndex == 3)
            {
                genderCombo.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                genderCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }
}
