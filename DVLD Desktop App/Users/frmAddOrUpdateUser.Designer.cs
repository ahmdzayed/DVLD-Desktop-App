namespace DVLD_Desktop_App
{
    partial class frmAddOrUpdateUser
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label usernameLabel;
            System.Windows.Forms.Label label1;
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tpgPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardwithFilter1 = new DVLD_Desktop_App.ctrlPersonCardwithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpgLoginInfo = new System.Windows.Forms.TabPage();
            this.usernameTextBox = new System.Windows.Forms.MaskedTextBox();
            this.confirmpasswordTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.isActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.iDLabel1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.epValidation = new System.Windows.Forms.ErrorProvider(this.components);
            iDLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tcUserInfo.SuspendLayout();
            this.tpgPersonalInfo.SuspendLayout();
            this.tpgLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            iDLabel.Location = new System.Drawing.Point(115, 49);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(76, 20);
            iDLabel.TabIndex = 0;
            iDLabel.Text = "User ID:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            passwordLabel.Location = new System.Drawing.Point(100, 155);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(91, 20);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usernameLabel.Location = new System.Drawing.Point(95, 102);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(96, 20);
            usernameLabel.TabIndex = 6;
            usernameLabel.Text = "Username:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(33, 205);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(158, 20);
            label1.TabIndex = 8;
            label1.Text = "Confirm Password:";
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcUserInfo.Controls.Add(this.tpgPersonalInfo);
            this.tcUserInfo.Controls.Add(this.tpgLoginInfo);
            this.tcUserInfo.Location = new System.Drawing.Point(24, 107);
            this.tcUserInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(858, 507);
            this.tcUserInfo.TabIndex = 0;
            // 
            // tpgPersonalInfo
            // 
            this.tpgPersonalInfo.Controls.Add(this.ctrlPersonCardwithFilter1);
            this.tpgPersonalInfo.Controls.Add(this.btnNext);
            this.tpgPersonalInfo.Location = new System.Drawing.Point(4, 29);
            this.tpgPersonalInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpgPersonalInfo.Name = "tpgPersonalInfo";
            this.tpgPersonalInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpgPersonalInfo.Size = new System.Drawing.Size(850, 474);
            this.tpgPersonalInfo.TabIndex = 0;
            this.tpgPersonalInfo.Text = "Personal Info";
            this.tpgPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonCardwithFilter1
            // 
            this.ctrlPersonCardwithFilter1.AutoSize = true;
            this.ctrlPersonCardwithFilter1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPersonCardwithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlPersonCardwithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCardwithFilter1.FilterEnabled = true;
            this.ctrlPersonCardwithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonCardwithFilter1.Location = new System.Drawing.Point(4, 10);
            this.ctrlPersonCardwithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonCardwithFilter1.Name = "ctrlPersonCardwithFilter1";
            this.ctrlPersonCardwithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardwithFilter1.Size = new System.Drawing.Size(843, 398);
            this.ctrlPersonCardwithFilter1.TabIndex = 14;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(743, 416);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 39);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpgLoginInfo
            // 
            this.tpgLoginInfo.Controls.Add(this.usernameTextBox);
            this.tpgLoginInfo.Controls.Add(this.confirmpasswordTextBox);
            this.tpgLoginInfo.Controls.Add(this.passwordTextBox);
            this.tpgLoginInfo.Controls.Add(label1);
            this.tpgLoginInfo.Controls.Add(usernameLabel);
            this.tpgLoginInfo.Controls.Add(passwordLabel);
            this.tpgLoginInfo.Controls.Add(this.isActiveCheckBox);
            this.tpgLoginInfo.Controls.Add(iDLabel);
            this.tpgLoginInfo.Controls.Add(this.iDLabel1);
            this.tpgLoginInfo.Location = new System.Drawing.Point(4, 29);
            this.tpgLoginInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpgLoginInfo.Name = "tpgLoginInfo";
            this.tpgLoginInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpgLoginInfo.Size = new System.Drawing.Size(850, 474);
            this.tpgLoginInfo.TabIndex = 1;
            this.tpgLoginInfo.Text = "Login Info";
            this.tpgLoginInfo.UseVisualStyleBackColor = true;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(213, 99);
            this.usernameTextBox.Mask = "LLLLLLLLLLLL";
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.PromptChar = ' ';
            this.usernameTextBox.Size = new System.Drawing.Size(173, 26);
            this.usernameTextBox.TabIndex = 12;
            this.usernameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.usernameTextBox_Validating);
            // 
            // confirmpasswordTextBox
            // 
            this.confirmpasswordTextBox.Location = new System.Drawing.Point(213, 202);
            this.confirmpasswordTextBox.Name = "confirmpasswordTextBox";
            this.confirmpasswordTextBox.PasswordChar = '*';
            this.confirmpasswordTextBox.Size = new System.Drawing.Size(173, 26);
            this.confirmpasswordTextBox.TabIndex = 14;
            this.confirmpasswordTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.confirmpasswordTextBox_Validating);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(213, 152);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(173, 26);
            this.passwordTextBox.TabIndex = 13;
            // 
            // isActiveCheckBox
            // 
            this.isActiveCheckBox.Location = new System.Drawing.Point(213, 258);
            this.isActiveCheckBox.Name = "isActiveCheckBox";
            this.isActiveCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isActiveCheckBox.TabIndex = 3;
            this.isActiveCheckBox.Text = "Is Active";
            this.isActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // iDLabel1
            // 
            this.iDLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iDLabel1.Location = new System.Drawing.Point(213, 49);
            this.iDLabel1.Name = "iDLabel1";
            this.iDLabel1.Size = new System.Drawing.Size(100, 23);
            this.iDLabel1.TabIndex = 1;
            this.iDLabel1.Text = "????";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(788, 622);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 33);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(620, 622);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMode
            // 
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMode.Location = new System.Drawing.Point(12, 40);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(849, 24);
            this.lblMode.TabIndex = 3;
            this.lblMode.Text = "Add Or Eidt User";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // epValidation
            // 
            this.epValidation.ContainerControl = this;
            // 
            // frmAddOrUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(911, 667);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcUserInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddOrUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddOrUpdateUser";
            this.Activated += new System.EventHandler(this.frmAddOrUpdateUser_Activated);
            this.Load += new System.EventHandler(this.frmAddOrUpdateUser_Load);
            this.tcUserInfo.ResumeLayout(false);
            this.tpgPersonalInfo.ResumeLayout(false);
            this.tpgPersonalInfo.PerformLayout();
            this.tpgLoginInfo.ResumeLayout(false);
            this.tpgLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tpgPersonalInfo;
        private System.Windows.Forms.TabPage tpgLoginInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox isActiveCheckBox;
        private System.Windows.Forms.Label iDLabel1;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.TextBox confirmpasswordTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.ErrorProvider epValidation;
        private System.Windows.Forms.MaskedTextBox usernameTextBox;
        private ctrlPersonCardwithFilter ctrlPersonCardwithFilter1;
    }
}