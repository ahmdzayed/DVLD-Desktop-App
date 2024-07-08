namespace DVLD_Desktop_App
{
    partial class frmAddOrUpdateLocalDrivingLicenseApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcApplicationInfo = new System.Windows.Forms.TabControl();
            this.tpgPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonCardwithFilter1 = new DVLD_Desktop_App.ctrlPersonCardwithFilter();
            this.tpgAppInfo = new System.Windows.Forms.TabPage();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.lblLDAppID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tcApplicationInfo.SuspendLayout();
            this.tpgPersonInfo.SuspendLayout();
            this.tpgAppInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcApplicationInfo
            // 
            this.tcApplicationInfo.Controls.Add(this.tpgPersonInfo);
            this.tcApplicationInfo.Controls.Add(this.tpgAppInfo);
            this.tcApplicationInfo.Location = new System.Drawing.Point(13, 131);
            this.tcApplicationInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcApplicationInfo.Name = "tcApplicationInfo";
            this.tcApplicationInfo.SelectedIndex = 0;
            this.tcApplicationInfo.Size = new System.Drawing.Size(860, 477);
            this.tcApplicationInfo.TabIndex = 0;
            // 
            // tpgPersonInfo
            // 
            this.tpgPersonInfo.Controls.Add(this.btnNext);
            this.tpgPersonInfo.Controls.Add(this.ctrlPersonCardwithFilter1);
            this.tpgPersonInfo.Location = new System.Drawing.Point(4, 29);
            this.tpgPersonInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpgPersonInfo.Name = "tpgPersonInfo";
            this.tpgPersonInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpgPersonInfo.Size = new System.Drawing.Size(852, 444);
            this.tpgPersonInfo.TabIndex = 0;
            this.tpgPersonInfo.Text = "Persnoal Info";
            this.tpgPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(738, 407);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(82, 29);
            this.btnNext.TabIndex = 14;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonCardwithFilter1
            // 
            this.ctrlPersonCardwithFilter1.AutoSize = true;
            this.ctrlPersonCardwithFilter1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPersonCardwithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlPersonCardwithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCardwithFilter1.FilterEnabled = true;
            this.ctrlPersonCardwithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonCardwithFilter1.Location = new System.Drawing.Point(8, 23);
            this.ctrlPersonCardwithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonCardwithFilter1.Name = "ctrlPersonCardwithFilter1";
            this.ctrlPersonCardwithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardwithFilter1.Size = new System.Drawing.Size(843, 398);
            this.ctrlPersonCardwithFilter1.TabIndex = 0;
            this.ctrlPersonCardwithFilter1.OnPersonSelected += new System.Action<DVLD_Business_Layer.clsPeople>(this.ctrlPersonCardwithFilter1_OnPersonSelected);
            // 
            // tpgAppInfo
            // 
            this.tpgAppInfo.Controls.Add(this.cbLicenseClass);
            this.tpgAppInfo.Controls.Add(this.lblCreatedBy);
            this.tpgAppInfo.Controls.Add(this.lblAppFees);
            this.tpgAppInfo.Controls.Add(this.lblAppDate);
            this.tpgAppInfo.Controls.Add(this.lblLDAppID);
            this.tpgAppInfo.Controls.Add(this.label6);
            this.tpgAppInfo.Controls.Add(this.label5);
            this.tpgAppInfo.Controls.Add(this.label4);
            this.tpgAppInfo.Controls.Add(this.label3);
            this.tpgAppInfo.Controls.Add(this.label2);
            this.tpgAppInfo.Location = new System.Drawing.Point(4, 29);
            this.tpgAppInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpgAppInfo.Name = "tpgAppInfo";
            this.tpgAppInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpgAppInfo.Size = new System.Drawing.Size(852, 444);
            this.tpgAppInfo.TabIndex = 1;
            this.tpgAppInfo.Text = "Application Info";
            this.tpgAppInfo.UseVisualStyleBackColor = true;
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(232, 172);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(272, 28);
            this.cbLicenseClass.TabIndex = 9;
            this.cbLicenseClass.SelectedIndexChanged += new System.EventHandler(this.cbLicenseClass_SelectedIndexChanged);
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(228, 266);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(59, 20);
            this.lblCreatedBy.TabIndex = 8;
            this.lblCreatedBy.Text = "[????]";
            this.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(228, 219);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(59, 20);
            this.lblAppFees.TabIndex = 7;
            this.lblAppFees.Text = "[????]";
            this.lblAppFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(228, 125);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(59, 20);
            this.lblAppDate.TabIndex = 6;
            this.lblAppDate.Text = "[????]";
            this.lblAppDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLDAppID
            // 
            this.lblLDAppID.AutoSize = true;
            this.lblLDAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLDAppID.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLDAppID.Location = new System.Drawing.Point(228, 78);
            this.lblLDAppID.Name = "lblLDAppID";
            this.lblLDAppID.Size = new System.Drawing.Size(59, 20);
            this.lblLDAppID.TabIndex = 5;
            this.lblLDAppID.Text = "[????]";
            this.lblLDAppID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(78, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Created By: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Fees";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "License Class:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Application Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "L.D.Application ID:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(636, 616);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 33);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(755, 616);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle.Location = new System.Drawing.Point(12, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(862, 69);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "New Local Driving License Application";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddOrUpdateLocalDrivingLicenseApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 659);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcApplicationInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddOrUpdateLocalDrivingLicenseApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddOrUpdateLocalDrivingLicenseApp";
            this.Activated += new System.EventHandler(this.frmAddOrUpdateLocalDrivingLicenseApp_Activated);
            this.Load += new System.EventHandler(this.frmAddOrUpdateLocalDrivingLicenseApp_Load);
            this.tcApplicationInfo.ResumeLayout(false);
            this.tpgPersonInfo.ResumeLayout(false);
            this.tpgPersonInfo.PerformLayout();
            this.tpgAppInfo.ResumeLayout(false);
            this.tpgAppInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcApplicationInfo;
        private System.Windows.Forms.TabPage tpgPersonInfo;
        private System.Windows.Forms.TabPage tpgAppInfo;
        private ctrlPersonCardwithFilter ctrlPersonCardwithFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label lblLDAppID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}