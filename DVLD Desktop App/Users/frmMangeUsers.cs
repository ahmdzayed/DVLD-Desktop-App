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
    public partial class frmMangeUsers : Form
    {
        private DataTable _dtAllUsers;
        public frmMangeUsers()
        {
            InitializeComponent();
        }

        private void _RefreshUsersList()
        {
            _dtAllUsers = clsUsers.GetAllUsers();

            dgvUsersList.DataSource = _dtAllUsers;
            lblNumberofRecords.Text = dgvUsersList.RowCount.ToString();
        }

        private void frmMangeUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUsers.GetAllUsers();
            dgvUsersList.DataSource = _dtAllUsers;

            if (dgvUsersList.RowCount > 0)
            {
                dgvUsersList.Columns[0].HeaderText = "ID";
                dgvUsersList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvUsersList.Columns[1].HeaderText = "Person ID";
                dgvUsersList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvUsersList.Columns[2].HeaderText = "Full Name";
                dgvUsersList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvUsersList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvUsersList.Columns[4].HeaderText = "Is Active";
                dgvUsersList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            lblNumberofRecords.Text = dgvUsersList.RowCount.ToString();

            cbFilter.SelectedIndex = 0;
            cbIsActiveFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilter.SelectedIndex != 0 && cbFilter.SelectedIndex != 5); //Filter Not None and not is active
            cbIsActiveFilter.Visible = (cbFilter.SelectedIndex == 5); //Is Active Filter

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();
            }
        }

        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //to reset tabel after trun from is active to none
            txtFilterValue.Text = " ";

            switch (cbIsActiveFilter.SelectedIndex)
            {
                case 0: //All
                    _dtAllUsers.DefaultView.RowFilter = "";
                    break;
                case 1: // Yes => Is Active
                    _dtAllUsers.DefaultView.RowFilter = "IsActive = 1";
                    break;
                case 2: // No => Not Active
                    _dtAllUsers.DefaultView.RowFilter = "IsActive = 0";
                    break;

            }

            lblNumberofRecords.Text = dgvUsersList.RowCount.ToString();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateUser frm = new frmAddOrUpdateUser((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateUser frm = new frmAddOrUpdateUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this User [" + dgvUsersList.CurrentRow.Cells[0].Value.ToString() + "] ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsUsers.Delete((int)dgvUsersList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully");
                    _RefreshUsersList();
                }
                else
                    MessageBox.Show("User is Not Deleted due to date connected to it!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmsShowUserDetials_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void tsmSendPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Impelement Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Impelement Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || cbFilter.SelectedIndex == 0)
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberofRecords.Text = dgvUsersList.RowCount.ToString();
                return;
            }

            string FilterColumn = "";
            //Map Selected Filter to real Column name
            switch (cbFilter.SelectedIndex)
            {
                case 1: // User ID
                    FilterColumn = "UserID";
                    break;
                case 2: // Person ID
                    FilterColumn = "PersonID";
                    break;
                case 3: // FuLl Name;
                    FilterColumn = "FullName";
                    break;
                case 4: // Username
                    FilterColumn = cbFilter.Text;
                    break;
            }

            if (cbFilter.SelectedIndex == 3 || cbFilter.SelectedIndex == 4) // Full Name Or Username
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            lblNumberofRecords.Text = dgvUsersList.RowCount.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 2) // Filter by UserID Or PersonID
            {
                //we allow number incase user id and person id is selected.
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
