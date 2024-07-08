using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;

namespace DVLD_Desktop_App.Applications.Local_Driving_License
{
    public partial class frmListLocalDrivingLicenseApps : Form
    {
        private DataTable _dtAllApplications;

        public frmListLocalDrivingLicenseApps()
        {
            InitializeComponent();
        }
        
        private void _RefreshApplciationsList()
        {
            _dtAllApplications = clsLocalDrivingLicenseApps.GetAllLocalDrivingLicenseApps();
            dgvListAllApplications.DataSource = _dtAllApplications;  
            lblNumberofRecords.Text = dgvListAllApplications.RowCount.ToString(); 
        }

        private void frmListLocalDrivingLicenseApps_Load(object sender, EventArgs e)
        {
            _dtAllApplications = clsLocalDrivingLicenseApps.GetAllLocalDrivingLicenseApps();
            dgvListAllApplications.DataSource = _dtAllApplications;

            if(dgvListAllApplications.Rows.Count > 0 )
            {
                dgvListAllApplications.Columns[0].HeaderText = "L.D.LApp ID";
                dgvListAllApplications.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                
                dgvListAllApplications.Columns[1].HeaderText = "Class Name";
                dgvListAllApplications.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                
                dgvListAllApplications.Columns[2].HeaderText = "National No.";
                dgvListAllApplications.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                
                dgvListAllApplications.Columns[3].HeaderText = "Full Name";
                dgvListAllApplications.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                
                dgvListAllApplications.Columns[4].HeaderText = "Application Date";
                dgvListAllApplications.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                
                dgvListAllApplications.Columns[5].HeaderText = "Passed Tests";
                dgvListAllApplications.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            }
            lblNumberofRecords.Text = dgvListAllApplications.RowCount.ToString();
            cbFilter.SelectedIndex = 0; //None
        }

        private void btnAddNewLDLApp_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateLocalDrivingLicenseApp frm = new frmAddOrUpdateLocalDrivingLicenseApp();
            frm.ShowDialog();
            _RefreshApplciationsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateLocalDrivingLicenseApp frm = new frmAddOrUpdateLocalDrivingLicenseApp((int)dgvListAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplciationsList();
        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Application[" + dgvListAllApplications.CurrentRow.Cells[0].Value.ToString() + "] ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clsLocalDrivingLicenseApps LDLApp = clsLocalDrivingLicenseApps.FindByLocalDrivingAppLicenseID((int)dgvListAllApplications.CurrentRow.Cells[0].Value);
                if (LDLApp != null)
                {
                    if (LDLApp.Delete())
                    {
                        MessageBox.Show("Applciation delete successfully");
                    }
                    else
                        MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
                }
                else
                    MessageBox.Show("Application Not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                _RefreshApplciationsList();
            }
        }

        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel this Application[" + dgvListAllApplications.CurrentRow.Cells[0].Value.ToString() + "] ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int LDLAppID = (int)dgvListAllApplications.CurrentRow.Cells[0].Value;
                clsLocalDrivingLicenseApps LDLApp = clsLocalDrivingLicenseApps.FindByLocalDrivingAppLicenseID(LDLAppID);
                if (LDLApp == null)
                {
                    MessageBox.Show("Application Not found!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (LDLApp.Cancel())
                {
                        MessageBox.Show("Applciation delete successfully");
                        _RefreshApplciationsList();
                }
                else
                    MessageBox.Show("Could Not Cancel this Application!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScheduleTestsMenue_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not implemented yet!");
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not implemented yet!");
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not implemented yet!");
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not implemented yet!");
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilter.SelectedIndex == 1) //L.D.L ID
            {
                //we allow number incase Application id.
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {            
            txtFilterValue.Visible = cbFilter.SelectedIndex != 0;

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || cbFilter.SelectedIndex == 0)
            {
                _dtAllApplications.DefaultView.RowFilter = "";
                lblNumberofRecords.Text = dgvListAllApplications.RowCount.ToString();
                return;
            }

            string FilterColumn = "";
            switch (cbFilter.SelectedIndex)
            { 
                case 1: //LDLApp ID
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case 2: //Nation No.
                    FilterColumn = "NationalNo";
                    break;
                case 3: //Full Name
                    FilterColumn = "FullName";
                    break;
                case 4: //Status
                    FilterColumn = cbFilter.Text;
                    break;
            }

            if (cbFilter.SelectedIndex == 1)
                _dtAllApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtAllApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text);

            lblNumberofRecords.Text = dgvListAllApplications.RowCount.ToString();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseAppInfo frm = new frmLocalDrivingLicenseAppInfo((int)dgvListAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
