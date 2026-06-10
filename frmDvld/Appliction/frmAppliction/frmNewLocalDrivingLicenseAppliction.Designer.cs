namespace frmDvld.Appliction.frmAppliction
{
    partial class frmNewLocalDrivingLicenseAppliction
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tapPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNextTap = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new frmDvld.ctrlPersonCardWithFilter();
            this.tapApplicationInfo = new System.Windows.Forms.TabPage();
            this.cmbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplictionFees = new System.Windows.Forms.Label();
            this.lblApplictionDate = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblAddEditNewPerson = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tapPersonInfo.SuspendLayout();
            this.tapApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tapPersonInfo);
            this.tabControl1.Controls.Add(this.tapApplicationInfo);
            this.tabControl1.Location = new System.Drawing.Point(11, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 466);
            this.tabControl1.TabIndex = 53;
            // 
            // tapPersonInfo
            // 
            this.tapPersonInfo.BackColor = System.Drawing.Color.White;
            this.tapPersonInfo.Controls.Add(this.btnNextTap);
            this.tapPersonInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tapPersonInfo.Location = new System.Drawing.Point(4, 22);
            this.tapPersonInfo.Name = "tapPersonInfo";
            this.tapPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tapPersonInfo.Size = new System.Drawing.Size(808, 440);
            this.tapPersonInfo.TabIndex = 0;
            this.tapPersonInfo.Text = "Person Info";
            // 
            // btnNextTap
            // 
            this.btnNextTap.BackColor = System.Drawing.Color.White;
            this.btnNextTap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextTap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextTap.ForeColor = System.Drawing.Color.Black;
            this.btnNextTap.Image = global::frmDvld.Properties.Resources.Next_32;
            this.btnNextTap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNextTap.Location = new System.Drawing.Point(642, 389);
            this.btnNextTap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNextTap.Name = "btnNextTap";
            this.btnNextTap.Size = new System.Drawing.Size(120, 41);
            this.btnNextTap.TabIndex = 54;
            this.btnNextTap.Tag = "";
            this.btnNextTap.Text = "Next";
            this.btnNextTap.UseVisualStyleBackColor = false;
            this.btnNextTap.Click += new System.EventHandler(this.btnNextTap_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCardWithFilter1.FilterEnable = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(6, 6);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.PersonID = -1;
            this.ctrlPersonCardWithFilter1.SearchText = "";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(775, 389);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // tapApplicationInfo
            // 
            this.tapApplicationInfo.BackColor = System.Drawing.Color.White;
            this.tapApplicationInfo.Controls.Add(this.cmbLicenseClass);
            this.tapApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tapApplicationInfo.Controls.Add(this.lblApplictionFees);
            this.tapApplicationInfo.Controls.Add(this.lblApplictionDate);
            this.tapApplicationInfo.Controls.Add(this.pictureBox5);
            this.tapApplicationInfo.Controls.Add(this.label5);
            this.tapApplicationInfo.Controls.Add(this.lblApplicationID);
            this.tapApplicationInfo.Controls.Add(this.label4);
            this.tapApplicationInfo.Controls.Add(this.label3);
            this.tapApplicationInfo.Controls.Add(this.label2);
            this.tapApplicationInfo.Controls.Add(this.label1);
            this.tapApplicationInfo.Controls.Add(this.pictureBox4);
            this.tapApplicationInfo.Controls.Add(this.pictureBox3);
            this.tapApplicationInfo.Controls.Add(this.pictureBox1);
            this.tapApplicationInfo.Controls.Add(this.pictureBox2);
            this.tapApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tapApplicationInfo.Name = "tapApplicationInfo";
            this.tapApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tapApplicationInfo.Size = new System.Drawing.Size(808, 440);
            this.tapApplicationInfo.TabIndex = 1;
            this.tapApplicationInfo.Text = "Application";
            // 
            // cmbLicenseClass
            // 
            this.cmbLicenseClass.FormattingEnabled = true;
            this.cmbLicenseClass.Location = new System.Drawing.Point(262, 172);
            this.cmbLicenseClass.Name = "cmbLicenseClass";
            this.cmbLicenseClass.Size = new System.Drawing.Size(121, 21);
            this.cmbLicenseClass.TabIndex = 74;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(258, 251);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(65, 20);
            this.lblCreatedBy.TabIndex = 73;
            this.lblCreatedBy.Text = " /    /    / :";
            // 
            // lblApplictionFees
            // 
            this.lblApplictionFees.AutoSize = true;
            this.lblApplictionFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplictionFees.Location = new System.Drawing.Point(258, 211);
            this.lblApplictionFees.Name = "lblApplictionFees";
            this.lblApplictionFees.Size = new System.Drawing.Size(65, 20);
            this.lblApplictionFees.TabIndex = 72;
            this.lblApplictionFees.Text = " /    /    / :";
            // 
            // lblApplictionDate
            // 
            this.lblApplictionDate.AutoSize = true;
            this.lblApplictionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplictionDate.Location = new System.Drawing.Point(258, 126);
            this.lblApplictionDate.Name = "lblApplictionDate";
            this.lblApplictionDate.Size = new System.Drawing.Size(65, 20);
            this.lblApplictionDate.TabIndex = 71;
            this.lblApplictionDate.Text = " /    /    / :";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::frmDvld.Properties.Resources.user__2_;
            this.pictureBox5.Location = new System.Drawing.Point(208, 246);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(39, 31);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 70;
            this.pictureBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 69;
            this.label5.Text = "Created By :";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.Location = new System.Drawing.Point(258, 83);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(40, 24);
            this.lblApplicationID.TabIndex = 68;
            this.lblApplicationID.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 60;
            this.label4.Text = "Appliction Fees : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 59;
            this.label3.Text = "License Class :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 58;
            this.label2.Text = "Appliction Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "D.L.Application ID :";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::frmDvld.Properties.Resources.wage;
            this.pictureBox4.Location = new System.Drawing.Point(208, 205);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(39, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 65;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::frmDvld.Properties.Resources.license2;
            this.pictureBox3.Location = new System.Drawing.Point(208, 163);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 63;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::frmDvld.Properties.Resources.license1;
            this.pictureBox1.Location = new System.Drawing.Point(208, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::frmDvld.Properties.Resources.time;
            this.pictureBox2.Location = new System.Drawing.Point(208, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::frmDvld.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(707, 519);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 41);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::frmDvld.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(562, 519);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 41);
            this.btnClose.TabIndex = 55;
            this.btnClose.Tag = "";
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblAddEditNewPerson
            // 
            this.lblAddEditNewPerson.AutoSize = true;
            this.lblAddEditNewPerson.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblAddEditNewPerson.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblAddEditNewPerson.Location = new System.Drawing.Point(161, 15);
            this.lblAddEditNewPerson.Name = "lblAddEditNewPerson";
            this.lblAddEditNewPerson.Size = new System.Drawing.Size(464, 37);
            this.lblAddEditNewPerson.TabIndex = 59;
            this.lblAddEditNewPerson.Text = "NewLocalDrivingLicenseAppliction";
            this.lblAddEditNewPerson.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmNewLocalDrivingLicenseAppliction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(838, 568);
            this.Controls.Add(this.lblAddEditNewPerson);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmNewLocalDrivingLicenseAppliction";
            this.Text = "frmNewLocalDrivingLicenseAppliction";
            this.Load += new System.EventHandler(this.frmNewLocalDrivingLicenseAppliction_Load);
            this.tabControl1.ResumeLayout(false);
            this.tapPersonInfo.ResumeLayout(false);
            this.tapApplicationInfo.ResumeLayout(false);
            this.tapApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tapPersonInfo;
        private System.Windows.Forms.Button btnNextTap;
        private ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.TabPage tapApplicationInfo;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLicenseClass;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplictionFees;
        private System.Windows.Forms.Label lblApplictionDate;
        private System.Windows.Forms.Label lblAddEditNewPerson;
    }
}