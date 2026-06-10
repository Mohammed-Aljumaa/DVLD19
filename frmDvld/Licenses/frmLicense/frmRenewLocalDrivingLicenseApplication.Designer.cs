namespace frmDvld.Licenses.frmLicense
{
    partial class frmRenewLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRenewLocalDrivingLicenseApplication));
            this.ctrlRenewLocalDrivingLicense1 = new frmDvld.Licenses.ctrlLicense.ctrlRenewLocalDrivingLicense();
            this.ctrlLicenseFilter1 = new frmDvld.International_Licenses.ctrlLicenseIn.ctrlLicenseFilter();
            this.ctrlDriverLicenseInfo1 = new frmDvld.Licenses.ctrlLicense.ctrlDriverLicenseInfo();
            this.lnkShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lnkShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnRenew = new System.Windows.Forms.Button();
            this.ilAddPerson = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlRenewLocalDrivingLicense1
            // 
            this.ctrlRenewLocalDrivingLicense1.Location = new System.Drawing.Point(702, 126);
            this.ctrlRenewLocalDrivingLicense1.Name = "ctrlRenewLocalDrivingLicense1";
            this.ctrlRenewLocalDrivingLicense1.Size = new System.Drawing.Size(414, 488);
            this.ctrlRenewLocalDrivingLicense1.TabIndex = 2;
            // 
            // ctrlLicenseFilter1
            // 
            this.ctrlLicenseFilter1.Location = new System.Drawing.Point(109, 12);
            this.ctrlLicenseFilter1.Name = "ctrlLicenseFilter1";
            this.ctrlLicenseFilter1.Size = new System.Drawing.Size(509, 108);
            this.ctrlLicenseFilter1.TabIndex = 1;
            this.ctrlLicenseFilter1.OnSearch += new System.Action<int>(this.ctrlLicenseFilter1_OnSearch_1);
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(12, 126);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(702, 390);
            this.ctrlDriverLicenseInfo1.TabIndex = 0;
            // 
            // lnkShowLicenseInfo
            // 
            this.lnkShowLicenseInfo.AutoSize = true;
            this.lnkShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnkShowLicenseInfo.Location = new System.Drawing.Point(907, 30);
            this.lnkShowLicenseInfo.Name = "lnkShowLicenseInfo";
            this.lnkShowLicenseInfo.Size = new System.Drawing.Size(122, 17);
            this.lnkShowLicenseInfo.TabIndex = 134;
            this.lnkShowLicenseInfo.TabStop = true;
            this.lnkShowLicenseInfo.Text = "Show License Info";
            this.lnkShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseInfo_LinkClicked);
            // 
            // lnkShowLicenseHistory
            // 
            this.lnkShowLicenseHistory.AutoSize = true;
            this.lnkShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnkShowLicenseHistory.Location = new System.Drawing.Point(758, 30);
            this.lnkShowLicenseHistory.Name = "lnkShowLicenseHistory";
            this.lnkShowLicenseHistory.Size = new System.Drawing.Size(143, 17);
            this.lnkShowLicenseHistory.TabIndex = 133;
            this.lnkShowLicenseHistory.TabStop = true;
            this.lnkShowLicenseHistory.Text = "Show License History";
            this.lnkShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseHistory_LinkClicked_1);
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.Color.White;
            this.btnRenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenew.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRenew.ForeColor = System.Drawing.Color.Black;
            this.btnRenew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenew.ImageKey = "diploma.png";
            this.btnRenew.ImageList = this.ilAddPerson;
            this.btnRenew.Location = new System.Drawing.Point(909, 61);
            this.btnRenew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(120, 41);
            this.btnRenew.TabIndex = 132;
            this.btnRenew.Tag = "";
            this.btnRenew.Text = "Renew";
            this.btnRenew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click_1);
            // 
            // ilAddPerson
            // 
            this.ilAddPerson.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilAddPerson.ImageStream")));
            this.ilAddPerson.TransparentColor = System.Drawing.Color.Transparent;
            this.ilAddPerson.Images.SetKeyName(0, "user (3).png");
            this.ilAddPerson.Images.SetKeyName(1, "add.png");
            this.ilAddPerson.Images.SetKeyName(2, "licensing.png");
            this.ilAddPerson.Images.SetKeyName(3, "diploma.png");
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::frmDvld.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(775, 61);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 41);
            this.btnClose.TabIndex = 131;
            this.btnClose.Tag = "";
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRenewLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 611);
            this.Controls.Add(this.lnkShowLicenseInfo);
            this.Controls.Add(this.lnkShowLicenseHistory);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlRenewLocalDrivingLicense1);
            this.Controls.Add(this.ctrlLicenseFilter1);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmRenewLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRenewLocalDrivingLicenseApplication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLicense.ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private International_Licenses.ctrlLicenseIn.ctrlLicenseFilter ctrlLicenseFilter1;
        private ctrlLicense.ctrlRenewLocalDrivingLicense ctrlRenewLocalDrivingLicense1;
        private System.Windows.Forms.LinkLabel lnkShowLicenseInfo;
        private System.Windows.Forms.LinkLabel lnkShowLicenseHistory;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList ilAddPerson;
    }
}