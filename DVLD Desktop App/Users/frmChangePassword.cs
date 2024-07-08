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
    public partial class frmChangePassword : Form
    {
        private int _UserID = -1;
        private clsUsers _User;
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _User = clsUsers.Find(_UserID);
            if (_User == null)
            {

                MessageBox.Show("This form will be closed because There is No _User with ID = " + _UserID.ToString());
                this.Close();
                return;
            }

            ctrlUserInfromation1.LoadUserInfo(_User);

        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtCurrentPassword.Text.Trim() != _User.Password)
            {
                e.Cancel = true;
                epValidationPassword.SetError(txtCurrentPassword, "Current Password is Wrong!");
            }
            else
            {
                e.Cancel = false;
                epValidationPassword.SetError(txtCurrentPassword, "");
            }
        }
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != "" && txtNewPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                epValidationPassword.SetError(txtNewPassword, "New Password does not mach ConfirmPassword");
            }
            else
            {
                e.Cancel = false;
                epValidationPassword.SetError(txtNewPassword, "");
            }
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                epValidationPassword.SetError(txtConfirmPassword, "Password Confirmation does not match New Password!");
            }
            else
            {
                e.Cancel = false;
                epValidationPassword.SetError(txtConfirmPassword, "");
            }
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

            _User.Password = txtNewPassword.Text;

            //to Update Only Password.
            _User.ChangPass = true;

            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _User.ChangPass = false;
                _ResetDefualtValues();
            }
            else
            {
                MessageBox.Show("An Erro Occured, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
