using DVLD_Business_Layer;
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
    public partial class frmAddOrUpdateUser : Form
    {
        private enum enMode { AddNew, Update };
        private int _UserID = -1;
        private clsUsers _User;
        private enMode _Mode;
        public frmAddOrUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddOrUpdateUser(int userid)
        {
            InitializeComponent();

            _UserID = userid;
            _Mode = enMode.Update;
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New User";
                lblMode.Text = this.Text;
                _User = new clsUsers();

                tpgLoginInfo.Enabled = false;

                ctrlPersonCardwithFilter1.FilterFocus();
            }
            else
            {
                this.Text = "Update User";
                lblMode.Text = this.Text;

                tpgLoginInfo.Enabled = true;
                btnSave.Enabled = true;


            }

            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            confirmpasswordTextBox.Text = "";
            isActiveCheckBox.Checked = true;
        }

        private void _Load()
        {

            _User = clsUsers.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardwithFilter1.FilterEnabled = false;

            ctrlPersonCardwithFilter1.LoadPersonInfo(_User.PersonInfo);

            iDLabel1.Text = _User.ID.ToString();
            usernameTextBox.Text = _User.Username;
            //incase update make sure not to use anothers user name
            usernameTextBox.Enabled = false;

            passwordTextBox.Text = _User.Password;
            confirmpasswordTextBox.Text = passwordTextBox.Text;

            isActiveCheckBox.Checked = _User.IsActive;
        }

        private void frmAddOrUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _Load();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.PersonID = ctrlPersonCardwithFilter1.PersonID;
            _User.Username = usernameTextBox.Text.Trim();
            _User.Password = passwordTextBox.Text.Trim();
            _User.IsActive = isActiveCheckBox.Checked;

            //to update only password
            _User.ChangPass = true;

            if (_User.Save())
            {
                iDLabel1.Text = _User.ID.ToString();
                _Mode = enMode.Update;
                this.Text = "Update User";
                lblMode.Text = this.Text;

                _User.ChangPass = false;

                //incase update make sure not to use anothers user name
                usernameTextBox.Enabled = false;

                ctrlPersonCardwithFilter1.FilterEnabled = false;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpgLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpgLoginInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlPersonCardwithFilter1.PersonID != -1)
            {

                if (clsUsers.IsExistbyPersonID(ctrlPersonCardwithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardwithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpgLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpgLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardwithFilter1.FilterFocus();

            }

        }

        private void usernameTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (_Mode == enMode.AddNew)
            {
                if (string.IsNullOrEmpty(usernameTextBox.Text.Trim()))
                {
                    e.Cancel = true;
                    epValidation.SetError(usernameTextBox, "Username cannot be blank");
                    return;
                }
                else
                {
                    epValidation.SetError(usernameTextBox, null);
                };

                if (usernameTextBox.Text.Contains(" "))
                {
                    e.Cancel = true;
                    epValidation.SetError(usernameTextBox, "Username mustn't contain spaces");
                }
                else
                {
                    e.Cancel = false;
                    epValidation.SetError(usernameTextBox, "");
                }


                if (clsUsers.IsExist(usernameTextBox.Text.Trim()))
                {
                    e.Cancel = true;
                    epValidation.SetError(usernameTextBox, "username is used by another user");
                }
                else
                {
                    epValidation.SetError(usernameTextBox, null);
                };
            }
        }
        
        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordTextBox.Text.Trim()))
            {
                e.Cancel = true;
                epValidation.SetError(passwordTextBox, "Password cannot be blank");
            }
            else
            {
                epValidation.SetError(passwordTextBox, null);
            };
        }
       
        private void confirmpasswordTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (confirmpasswordTextBox.Text != passwordTextBox.Text)
            {
                e.Cancel = true;
                epValidation.SetError(confirmpasswordTextBox, "Password Confirmation does not match Password!");
            }
            else
            {
                e.Cancel = false;
                epValidation.SetError(confirmpasswordTextBox, "");
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddOrUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardwithFilter1.FilterFocus();
        }
    }
}
