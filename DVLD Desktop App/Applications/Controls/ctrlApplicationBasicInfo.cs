using DVLD_Business_Layer;
using DVLD_Desktop_App.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_App.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int _ApplicationID = -1;
        public int ApplicationID { get { return _ApplicationID; } }

        private clsApplications _Application;
        public clsApplications SelectedApplicationInfo { get { return _Application; } }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplications.FindBaseApplication(ApplicationID);

            if (_Application == null)
            {
                ResetAppInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillAppInfo();
        }
       
        public void LoadApplicationInfo(clsApplications Application)
        {
            _Application = Application;

            if (_Application == null)
            {
                ResetAppInfo();
                MessageBox.Show("No Application with ApplicationID = " + _Application.ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillAppInfo();
        }
        
        public void ResetAppInfo()
        {
            lblApplicationID.Text = "[???]";
            lblStatus.Text = "[???]";
            lblFees.Text = "[$$$]";
            lblType.Text = "[???]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[??/??/???]";
            lblStatusDate.Text = "[??/??/???]";
            lblCreatedByUser.Text = "[????]";

        }
        
        private void _FillAppInfo()
        {
            _ApplicationID = _Application.ApplicationID;

            llViewPersonInfo.Enabled = true;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationTypeInfo.Title;
            lblApplicant.Text = _Application.ApplicantPersonInfo.FullName;
            lblDate.Text = clsFormats.DateToShort(_Application.ApplicationDate);
            lblStatusDate.Text = clsFormats.DateToShort(_Application.LastDateStatus);
            lblCreatedByUser.Text = _Application.CreatedByUserInfo.Username;
        }
        
        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_Application.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}
