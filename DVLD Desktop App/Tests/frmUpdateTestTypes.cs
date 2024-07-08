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
    public partial class frmUpdateTestTypes : Form
    {
        private int _TestTypeID = -1;
        private clsTestTypes _clsTestTypes;
        public frmUpdateTestTypes(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void _Load()
        {
            _clsTestTypes = clsTestTypes.Find((clsTestTypes.enTestType)_TestTypeID);
            if(_clsTestTypes != null)
            {
                iDLabel1.Text = _clsTestTypes.ID.ToString();
                titleTextBox.Text = _clsTestTypes.Title;
                descriptionTextBox.Text = _clsTestTypes.Description;
                feesTextBox.Text = _clsTestTypes.Fees.ToString();
            }
            else
            {
                MessageBox.Show($"This from will be close because there is no Test Type with this ID = " + _TestTypeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _clsTestTypes.Title = titleTextBox.Text.Trim();
            _clsTestTypes.Description = descriptionTextBox.Text.Trim();
            _clsTestTypes.Fees = Convert.ToInt16(feesTextBox.Text.Trim());
            if(_clsTestTypes.Save())
                MessageBox.Show($"Test Type with ID = " + _TestTypeID + " Updated Successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Update Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
