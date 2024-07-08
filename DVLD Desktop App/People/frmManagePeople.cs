using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business_Layer;

namespace DVLD_Desktop_App
{
    public partial class frmMangePeople : Form
    {
        private DataTable _dtAllPeople = clsPeople.GetAllPeople();
        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPeople.GetAllPeople();
            dgvAllPeople.DataSource = _dtAllPeople;
            lblNumberofRecord.Text = dgvAllPeople.RowCount.ToString();
        }

        public frmMangePeople()
        {
            InitializeComponent();
        }
      
        private void ShowDetailstoolStrip_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            dgvAllPeople.DataSource = _dtAllPeople;

            if (dgvAllPeople.RowCount > 0)
            {
                dgvAllPeople.Columns[0].HeaderText = "Person ID";
                dgvAllPeople.Columns[1].HeaderText = "National No.";
                dgvAllPeople.Columns[2].HeaderText = "First Name";
                dgvAllPeople.Columns[3].HeaderText = "Second Name";
                dgvAllPeople.Columns[4].HeaderText = "Third Name";
                dgvAllPeople.Columns[5].HeaderText = "Last Name";
                dgvAllPeople.Columns[7].HeaderText = "Date Of Birth";

                for (Int16 i = 0; i < 10; i++)
                {
                    dgvAllPeople.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                dgvAllPeople.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
                lblNumberofRecord.Text = dgvAllPeople.RowCount.ToString();
            cbFilter.SelectedIndex = 0;
        }

        private void btnAddEditPerson_Click(object sender, EventArgs e)
        {
            frmAddOrUpdatePerson frm = new frmAddOrUpdatePerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void EdittoolStrip_Click(object sender, EventArgs e)
        {
            frmAddOrUpdatePerson frm = new frmAddOrUpdatePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void DeletetoolStrip_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this person[" + dgvAllPeople.CurrentRow.Cells[0].Value.ToString() + "] ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
               if( clsPeople.DeletePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person delete successfully");
                    _RefreshPeopleList();
                }
                else
                    MessageBox.Show("Person is Not Deleted due to date connected to it!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendEmailtoolStrip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Impelement Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PhoneCalltoolStrip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Impelement Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilter.SelectedIndex != 0); //cbFilter is Not "None"
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                switch (cbFilter.SelectedIndex)
                {
                    case 1: //cbFilter is PersonID
                        txtFilterValue.Mask = "0000000000";
                        break;
                    case 8: // cbFilter is Phone Number
                        txtFilterValue.Mask = "000-00000000";
                        break;
                    default:
                        txtFilterValue.Mask = null;
                        break;
                }
                txtFilterValue.Focus();
            }

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || cbFilter.SelectedIndex == 0)
            {
                _dtAllPeople.DefaultView.RowFilter = "";
                lblNumberofRecord.Text = dgvAllPeople.RowCount.ToString();
                return;
            }

            string FilterColumn = "";
            //Map Selected Filter to real Column name
            switch (cbFilter.SelectedIndex)
            {
                case 0: // None
                    break;
                case 1: // Person ID
                    FilterColumn = "PersonID";
                    break;
                case 2: // National No
                    FilterColumn = "NationalNo";
                    break;
                case 3: // First Name;
                    FilterColumn = "FirstName";
                    break;
                case 4: //Second Name
                    FilterColumn = "SecondName";
                    break;
                case 5: //Third Name
                    FilterColumn = "ThirdName";
                    break;
                case 6: // Last Name
                    FilterColumn = "LastName";
                    break;
                case 7: //Gender
                    FilterColumn = cbFilter.Text;
                    break;
                case 8: //Phone
                    FilterColumn = cbFilter.Text;
                    break;
                case 9: //Email
                    FilterColumn = cbFilter.Text;
                    break;
            }

            if (cbFilter.SelectedIndex == 1) // Person ID in this case we deal with integer not string.
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            dgvAllPeople.DataSource = _dtAllPeople;
            lblNumberofRecord.Text = dgvAllPeople.RowCount.ToString();
        }

    }
}
