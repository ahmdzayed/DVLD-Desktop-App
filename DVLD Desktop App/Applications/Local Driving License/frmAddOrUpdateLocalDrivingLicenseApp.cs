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
    public partial class frmAddOrUpdateLocalDrivingLicenseApp : Form
    {
        private enum enMode { AddNew, Update};
        private enMode _Mode;
        private int _ApplicantPersonID = -1;
        private int _LocalLicenseAppID = -1;
        private clsLocalDrivingLicenseApps _LocalLicenseApp;

        public frmAddOrUpdateLocalDrivingLicenseApp()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddOrUpdateLocalDrivingLicenseApp(int LocalLicenseAppID)
        {
            InitializeComponent();
            _LocalLicenseAppID = LocalLicenseAppID;
            _Mode = enMode.Update;
        }

        private void _FillComboBoxWithLicenseClasses()
        {
            DataTable table = clsLicenseClasses.GetAllLicenseClasses();
            foreach (DataRow row in table.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
            cbLicenseClass.SelectedIndex = 2;
        }

        private void _ResetDefualtValues()
        {
            _FillComboBoxWithLicenseClasses();

            if(_Mode == enMode.AddNew)
            {
                this.Text = "New Local Driving License Application";
                lblTitle.Text = this.Text;
                ctrlPersonCardwithFilter1.FilterFocus();
                tpgAppInfo.Enabled = false;
                lblAppDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
                _LocalLicenseApp = new clsLocalDrivingLicenseApps();
            }
            else
            {
                this.Text = "Update Local Driving License Application";
                lblTitle.Text = this.Text;
                tpgAppInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void _LoadData()
        {
            ctrlPersonCardwithFilter1.FilterEnabled = false;
            _LocalLicenseApp = clsLocalDrivingLicenseApps.FindByLocalDrivingAppLicenseID(_LocalLicenseAppID);
            if (_LocalLicenseApp == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalLicenseAppID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            _ApplicantPersonID = _LocalLicenseApp.ApplicantPersonID;
            ctrlPersonCardwithFilter1.LoadPersonInfo(_ApplicantPersonID);
            lblAppDate.Text = _LocalLicenseApp.ApplicationDate.ToShortDateString();
            lblLDAppID.Text = _LocalLicenseApp.ID.ToString();
            lblCreatedBy.Text = _LocalLicenseApp.CreatedByUserInfo.Username;
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalLicenseApp.LicenseClassInfo.ClassName);
            lblAppFees.Text = _LocalLicenseApp.PaidFees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddOrUpdateLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAppFees.Text = clsLicenseClasses.Find(cbLicenseClass.Text).Fees.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardwithFilter1.PersonID == -1)
            {
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpgPersonInfo"];
                tpgAppInfo.Enabled = false;
                ctrlPersonCardwithFilter1.FilterFocus();
                MessageBox.Show("No Person is selected, Choose one.", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tpgAppInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpgAppInfo"];
                btnSave.Enabled = true;
            }
        }

        private void ctrlPersonCardwithFilter1_OnPersonSelected(clsPeople Person)
        {
            _ApplicantPersonID = Person.ID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClasses.Find(cbLicenseClass.Text).ID;
            int ActiveApplicationID = clsApplications.GetActiveApplicationIDForLicenseClass(_ApplicantPersonID, clsApplications.enApplicationTypes.NewDrivingLicense, LicenseClassID);
            
            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            _LocalLicenseApp.LicenseClassID = LicenseClassID; 
            _LocalLicenseApp.ApplicantPersonID = ctrlPersonCardwithFilter1.PersonID;
            _LocalLicenseApp.ApplicationDate = DateTime.Now;
            _LocalLicenseApp.ApplicatoinTypeID = 1; //NewLocalDrivingLicense
            _LocalLicenseApp.Status = clsApplications.enApplicationStatus.New;
            _LocalLicenseApp.LastDateStatus = DateTime.Now;
            _LocalLicenseApp.PaidFees = Convert.ToSingle(lblAppFees.Text);
            _LocalLicenseApp.UserID = clsGlobalSettings.CurrentUser.ID;

            if(_LocalLicenseApp.Save())
            {
                lblLDAppID.Text = _LocalLicenseApp.ID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmAddOrUpdateLocalDrivingLicenseApp_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardwithFilter1.FilterFocus();
        }
    }  
}



