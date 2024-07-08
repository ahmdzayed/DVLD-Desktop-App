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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshTestTypesList()
        {
            dgvTestTypesList.DataSource = clsTestTypes.GetAllTestTypes();
            dgvTestTypesList.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTestTypesList.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTestTypesList.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            lblNumberOfRecords.Text = dgvTestTypesList.RowCount.ToString();
        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesList();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes frm = new frmUpdateTestTypes((int)dgvTestTypesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypesList();
        }
    }
}
