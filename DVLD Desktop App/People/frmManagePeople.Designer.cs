namespace DVLD_Desktop_App
{
    partial class frmMangePeople
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAllPeople = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowDetailstoolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewtoolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.EdittoolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DeletetoolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SendEmailtoolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.PhoneCalltoolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.btnAddEditPerson = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumberofRecord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1467, 1108);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(1, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1762, 76);
            this.label2.TabIndex = 1;
            this.label2.Text = "Manage People";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvAllPeople
            // 
            this.dgvAllPeople.AllowUserToAddRows = false;
            this.dgvAllPeople.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllPeople.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllPeople.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllPeople.Location = new System.Drawing.Point(18, 352);
            this.dgvAllPeople.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAllPeople.Name = "dgvAllPeople";
            this.dgvAllPeople.ReadOnly = true;
            this.dgvAllPeople.Size = new System.Drawing.Size(1733, 346);
            this.dgvAllPeople.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowDetailstoolStrip,
            this.AddNewtoolStrip,
            this.EdittoolStrip,
            this.DeletetoolStrip,
            this.SendEmailtoolStrip,
            this.PhoneCalltoolStrip});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 136);
            // 
            // ShowDetailstoolStrip
            // 
            this.ShowDetailstoolStrip.Name = "ShowDetailstoolStrip";
            this.ShowDetailstoolStrip.Size = new System.Drawing.Size(162, 22);
            this.ShowDetailstoolStrip.Text = "Show Details";
            this.ShowDetailstoolStrip.Click += new System.EventHandler(this.ShowDetailstoolStrip_Click);
            // 
            // AddNewtoolStrip
            // 
            this.AddNewtoolStrip.Name = "AddNewtoolStrip";
            this.AddNewtoolStrip.Size = new System.Drawing.Size(162, 22);
            this.AddNewtoolStrip.Text = "Add New Person";
            this.AddNewtoolStrip.Click += new System.EventHandler(this.btnAddEditPerson_Click);
            // 
            // EdittoolStrip
            // 
            this.EdittoolStrip.Name = "EdittoolStrip";
            this.EdittoolStrip.Size = new System.Drawing.Size(162, 22);
            this.EdittoolStrip.Text = "Edit";
            this.EdittoolStrip.Click += new System.EventHandler(this.EdittoolStrip_Click);
            // 
            // DeletetoolStrip
            // 
            this.DeletetoolStrip.Name = "DeletetoolStrip";
            this.DeletetoolStrip.Size = new System.Drawing.Size(162, 22);
            this.DeletetoolStrip.Text = "Delete";
            this.DeletetoolStrip.Click += new System.EventHandler(this.DeletetoolStrip_Click);
            // 
            // SendEmailtoolStrip
            // 
            this.SendEmailtoolStrip.Name = "SendEmailtoolStrip";
            this.SendEmailtoolStrip.Size = new System.Drawing.Size(162, 22);
            this.SendEmailtoolStrip.Text = "Send Email";
            this.SendEmailtoolStrip.Click += new System.EventHandler(this.SendEmailtoolStrip_Click);
            // 
            // PhoneCalltoolStrip
            // 
            this.PhoneCalltoolStrip.Name = "PhoneCalltoolStrip";
            this.PhoneCalltoolStrip.Size = new System.Drawing.Size(162, 22);
            this.PhoneCalltoolStrip.Text = "Call Phone";
            this.PhoneCalltoolStrip.Click += new System.EventHandler(this.PhoneCalltoolStrip_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 294);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Filter By:";
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo",
            "FirstName",
            "SecondName",
            "ThirdName",
            "LastName",
            "Gender",
            "Phone",
            "Email"});
            this.cbFilter.Location = new System.Drawing.Point(111, 289);
            this.cbFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(190, 32);
            this.cbFilter.TabIndex = 4;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // btnAddEditPerson
            // 
            this.btnAddEditPerson.Location = new System.Drawing.Point(1524, 294);
            this.btnAddEditPerson.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEditPerson.Name = "btnAddEditPerson";
            this.btnAddEditPerson.Size = new System.Drawing.Size(111, 50);
            this.btnAddEditPerson.TabIndex = 5;
            this.btnAddEditPerson.Text = "Add ";
            this.btnAddEditPerson.UseVisualStyleBackColor = true;
            this.btnAddEditPerson.Click += new System.EventHandler(this.btnAddEditPerson_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(334, 289);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PromptChar = ' ';
            this.txtFilterValue.Size = new System.Drawing.Size(190, 29);
            this.txtFilterValue.TabIndex = 7;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 723);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "# Records:";
            // 
            // lblNumberofRecord
            // 
            this.lblNumberofRecord.AutoSize = true;
            this.lblNumberofRecord.Location = new System.Drawing.Point(132, 723);
            this.lblNumberofRecord.Name = "lblNumberofRecord";
            this.lblNumberofRecord.Size = new System.Drawing.Size(60, 24);
            this.lblNumberofRecord.TabIndex = 9;
            this.lblNumberofRecord.Text = "label5";
            // 
            // frmMangePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1764, 830);
            this.Controls.Add(this.lblNumberofRecord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.btnAddEditPerson);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvAllPeople);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmMangePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmListPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAllPeople;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnAddEditPerson;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowDetailstoolStrip;
        private System.Windows.Forms.ToolStripMenuItem AddNewtoolStrip;
        private System.Windows.Forms.ToolStripMenuItem EdittoolStrip;
        private System.Windows.Forms.ToolStripMenuItem DeletetoolStrip;
        private System.Windows.Forms.ToolStripMenuItem SendEmailtoolStrip;
        private System.Windows.Forms.ToolStripMenuItem PhoneCalltoolStrip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumberofRecord;
        private System.Windows.Forms.MaskedTextBox txtFilterValue;
    }
}

