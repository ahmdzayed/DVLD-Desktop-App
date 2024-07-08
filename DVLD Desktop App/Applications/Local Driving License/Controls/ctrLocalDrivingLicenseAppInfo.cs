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

namespace DVLD_Desktop_App.Applications.Local_Driving_License.Controls
{
    public partial class ctrlDrivingLicenseAppInfo : UserControl
    {
        private int _LDLAppID = -1;
        public int LDLAppID { get { return _LDLAppID; } }

        private clsLocalDrivingLicenseApps _LocalDrivingLicenseApp;
        public clsLocalDrivingLicenseApps SelectedLocalDrivingLicenseApp 
        {get { return _LocalDrivingLicenseApp; } }
       
        public ctrlDrivingLicenseAppInfo()
        {
            InitializeComponent();
        }

        public void LoadDrivingLicenseAppInfo(int DLAppID)
        {
            _LocalDrivingLicenseApp = clsLocalDrivingLicenseApps.FindByLocalDrivingAppLicenseID(DLAppID);

            if (_LocalDrivingLicenseApp == null)
            {
                _ResetLocalDrivingLicenseAppInfo();
                MessageBox.Show("No LocalDrivingLicenseApplication with ApplicationID = " + DLAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseAppInfo();
        }
       
        public void LoadDrivingLicenseAppInfoByBaseApplicationID(int BaseApplicationID)
        {
            _LocalDrivingLicenseApp = clsLocalDrivingLicenseApps.FindByApplicationID(BaseApplicationID);

            if (_LocalDrivingLicenseApp == null)
            {
                _ResetLocalDrivingLicenseAppInfo();
                MessageBox.Show("No LocalDrivingLicenseApplication with Basic ApplicationID = " + BaseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseAppInfo();
        }
        
        public void LoadDrivingLicenseAppInfo(clsLocalDrivingLicenseApps LocalDrivingLicenseApp)
        {
            _LocalDrivingLicenseApp = LocalDrivingLicenseApp;

            if (_LocalDrivingLicenseApp == null)
            {
                _ResetLocalDrivingLicenseAppInfo();
                MessageBox.Show("No LocalDrivingLicenseApplication with ApplicationID = " + _LocalDrivingLicenseApp.ID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseAppInfo();
        }
        
        private void _ResetLocalDrivingLicenseAppInfo()
        {
            lblDLAppID.Text = "[???]";
            lblLicenseClass.Text = "[???]";
            lblPassedTests.Text = "[???]";

            ctrlApplicationBasicInfo1.ResetAppInfo();
        }
        
        private void _FillLocalDrivingLicenseAppInfo()
        {
            _LDLAppID = _LocalDrivingLicenseApp.ID;
            lblDLAppID.Text = _LDLAppID.ToString();
            lblLicenseClass.Text = _LocalDrivingLicenseApp.LicenseClassInfo.ClassName;
            lblPassedTests.Text = "[???]";

            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApp.ApplicationID);
        }
    }
}
