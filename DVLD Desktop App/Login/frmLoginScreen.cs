using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Desktop_App.Properties;

namespace DVLD_Desktop_App
{
    public partial class frmLoginScreen : Form
    {
        private bool _isLoggedIn()
        {
            clsGlobalSettings.CurrentUser = clsUsers.Find(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            return clsGlobalSettings.CurrentUser != null;
        }
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (_isLoggedIn())
            {
                if (chkRememberMe.Checked)
                {
                    //store username and password
                    clsGlobalSettings.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    clsGlobalSettings.RememberUsernameAndPassword("", "");

                }


                if (!clsGlobalSettings.CurrentUser.IsActive)
                {
                    MessageBox.Show("Your Account is Deactivated please get in touch with Your Admin!", "Deactivated Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide();
                frmMain frmMain = new frmMain(this);
                frmMain.ShowDialog();

            }
            else
                MessageBox.Show("Invalid Username Or Password", "wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {

            string Username = "", Password = "";
            if (clsGlobalSettings.GetStoredCredential(ref Username, ref Password))
            {
                txtUsername.Text = Username;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
                btnLogin.Focus();
            }
            else
            {
                chkRememberMe.Checked = false;
                txtUsername.Focus();
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
