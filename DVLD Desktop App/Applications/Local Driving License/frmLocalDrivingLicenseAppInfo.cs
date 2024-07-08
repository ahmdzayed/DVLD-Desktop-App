﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_App.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseAppInfo : Form
    {
        private int _ApplicationID = -1;
        public frmLocalDrivingLicenseAppInfo(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }

        private void frmLocalDrivingLicenseAppInfo_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseAppInfo1.LoadDrivingLicenseAppInfo(_ApplicationID);
        }
    }
}
