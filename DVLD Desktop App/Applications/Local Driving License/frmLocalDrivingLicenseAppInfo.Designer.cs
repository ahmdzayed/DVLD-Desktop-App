﻿namespace DVLD_Desktop_App.Applications.Local_Driving_License
{
    partial class frmLocalDrivingLicenseAppInfo
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
            this.ctrlDrivingLicenseAppInfo1 = new DVLD_Desktop_App.Applications.Local_Driving_License.Controls.ctrlDrivingLicenseAppInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenseAppInfo1
            // 
            this.ctrlDrivingLicenseAppInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDrivingLicenseAppInfo1.Location = new System.Drawing.Point(13, 14);
            this.ctrlDrivingLicenseAppInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDrivingLicenseAppInfo1.Name = "ctrlDrivingLicenseAppInfo1";
            this.ctrlDrivingLicenseAppInfo1.Size = new System.Drawing.Size(817, 341);
            this.ctrlDrivingLicenseAppInfo1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(724, 363);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 38);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmLocalDrivingLicenseAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(838, 429);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDrivingLicenseAppInfo1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLocalDrivingLicenseAppInfo";
            this.Text = "frmLocalDrivingLicenseAppInfo";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseAppInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlDrivingLicenseAppInfo ctrlDrivingLicenseAppInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}