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
    public partial class ctrlUserInfromation : UserControl
    {
        private int _UserID = -1;

        private clsUsers _User;
        public int UserID { get { return _UserID; } }
        public ctrlUserInfromation()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUsers.Find(UserID);

            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        public void LoadUserInfo(clsUsers User)
        {
            _User = User;

            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + _User.ID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void _ResetUserInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();

            lblUserID.Text = "[????]";
            lblUsername.Text = "[????]";
            lblIsActive.Text = "[????]";
        }

        private void _FillUserInfo()
        {
            _UserID = _User.ID;

            ctrlPersonCard1.LoadPersonInfo(_User.PersonInfo);

            lblUserID.Text = _User.ID.ToString();
            lblUsername.Text = _User.Username;
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";

        }

    }
}
