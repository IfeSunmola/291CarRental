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
    public partial class StartAReturnPage : Form
    {
        ReturnAVehiclePage previousPage;
        public StartAReturnPage(ReturnAVehiclePage previousPage)
        {
            InitializeComponent(); 
            this.previousPage = previousPage;

            this.StartPosition = FormStartPosition.CenterScreen;
            amountDuePanel.Visible = false;
        }

        private void calculateAmountDue_ButtonClicked(object sender, EventArgs e)
        {
            amountDuePanel.Visible = true;
        }

        private void finishReturn_ButtonClicked(object sender, EventArgs e)
        {
            DialogResult confirmPayment = MessageBox.Show(
                "HAS THE CUSTOMER PAID THE AMOUNT DUE OF $120?", 
                "CONFIRM PAYMENT", 
                MessageBoxButtons.YesNo);

            if (confirmPayment == DialogResult.Yes)
            {
                DialogResult confirmReturn = MessageBox.Show(

              "Confirm returning of 2022 TOYOTA COROLLA for JOHN SMITH (031)",
              "CONFIRM RETURN VEHICLE",
              MessageBoxButtons.YesNo);

                if (confirmReturn == DialogResult.Yes)
                {
                    MessageBox.Show("VEHICLE RETURNED SUCCESSFULLY");
                    this.Close();
                    previousPage.Visible = true;
                }
                else if (confirmReturn == DialogResult.No)
                {
                    MessageBox.Show("VEHICLE RETURN CANCELLED");
                }
            }
            else if(confirmPayment == DialogResult.No)
            {
                MessageBox.Show("COLLECT PAYMENT FROM THE CUSTOMER");
            }
            
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
