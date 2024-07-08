using DVLD_Business_Layer;
using DVLD_Desktop_App.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_App
{
    public partial class frmEditApplicationTypes : Form
    {
        private int _ApplicationTypeID = -1;
        private clsApplicationTypes _ApplicationType;
        public frmEditApplicationTypes(int applicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = applicationTypeID;
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            iDLabel1.Text = _ApplicationType.ID.ToString();
            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);
            if (_ApplicationType != null)
            {
                titleTextBox.Text = _ApplicationType.Title;
                feesTextBox.Text = _ApplicationType.Fees.ToString();
            }
            else
            {
                MessageBox.Show($"This from will be close because there is no Application Type with this ID = " + _ApplicationTypeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _ApplicationType.Title = titleTextBox.Text.Trim();
            _ApplicationType.Fees = Convert.ToSingle(feesTextBox.Text.Trim());
            if (_ApplicationType.Save())
                MessageBox.Show($"Application Type with ID = " + _ApplicationTypeID + " Updated Successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Update Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void titleTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(titleTextBox.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(titleTextBox, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(titleTextBox, null);
            };
        }

        private void feesTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(feesTextBox.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(feesTextBox, "Title cannot be empty!");
            }
            else
                errorProvider1.SetError(feesTextBox, null);

            if (!clsValidation.IsNumber(feesTextBox.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(feesTextBox, "Invalid Number.");
            }
            else
                errorProvider1.SetError(feesTextBox, null);
        }
    }
}
