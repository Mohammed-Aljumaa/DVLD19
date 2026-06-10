namespace frmDvld.International_Licenses
{
    partial class frmNewInternationalLicenseAppliction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewInternationalLicenseAppliction));
            this.btnIssue = new System.Windows.Forms.Button();
            this.ilAddPerson = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.lnkShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lnkShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.ctrlLicenseFilter2 = new frmDvld.International_Licenses.ctrlLicenseIn.ctrlLicenseFilter();
            this.ctrlDriverLicenseInfo2 = new frmDvld.Licenses.ctrlLicense.ctrlDriverLicenseInfo();
            this.ctrlInternationalApplicationInfo1 = new frmDvld.International_Licenses.ctrlLicenseIn.ctrlInternationalApplicationInfo();
            this.SuspendLayout();
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.White;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnIssue.ForeColor = System.Drawing.Color.Black;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.ImageKey = "diploma.png";
            this.btnIssue.ImageList = this.ilAddPerson;
            this.btnIssue.Location = new System.Drawing.Point(872, 105);
            this.btnIssue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(120, 41);
            this.btnIssue.TabIndex = 128;
            this.btnIssue.Tag = "";
            this.btnIssue.Text = "Issue     ";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
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
            this.btnClose.Location = new System.Drawing.Point(738, 105);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 41);
            this.btnClose.TabIndex = 127;
            this.btnClose.Tag = "";
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lnkShowLicenseHistory
            // 
            this.lnkShowLicenseHistory.AutoSize = true;
            this.lnkShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnkShowLicenseHistory.Location = new System.Drawing.Point(721, 74);
            this.lnkShowLicenseHistory.Name = "lnkShowLicenseHistory";
            this.lnkShowLicenseHistory.Size = new System.Drawing.Size(143, 17);
            this.lnkShowLicenseHistory.TabIndex = 129;
            this.lnkShowLicenseHistory.TabStop = true;
            this.lnkShowLicenseHistory.Text = "Show License History";
            this.lnkShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseHistory_LinkClicked);
            // 
            // lnkShowLicenseInfo
            // 
            this.lnkShowLicenseInfo.AutoSize = true;
            this.lnkShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnkShowLicenseInfo.Location = new System.Drawing.Point(870, 74);
            this.lnkShowLicenseInfo.Name = "lnkShowLicenseInfo";
            this.lnkShowLicenseInfo.Size = new System.Drawing.Size(122, 17);
            this.lnkShowLicenseInfo.TabIndex = 130;
            this.lnkShowLicenseInfo.TabStop = true;
            this.lnkShowLicenseInfo.Text = "Show License Info";
            this.lnkShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseInfo_LinkClicked);
            // 
            // ctrlLicenseFilter2
            // 
            this.ctrlLicenseFilter2.Location = new System.Drawing.Point(109, 12);
            this.ctrlLicenseFilter2.Name = "ctrlLicenseFilter2";
            this.ctrlLicenseFilter2.Size = new System.Drawing.Size(509, 108);
            this.ctrlLicenseFilter2.TabIndex = 131;
            this.ctrlLicenseFilter2.OnSearch += new System.Action<int>(this.ctrlLicenseFilter2_OnSearch);
            // 
            // ctrlDriverLicenseInfo2
            // 
            this.ctrlDriverLicenseInfo2.Location = new System.Drawing.Point(12, 126);
            this.ctrlDriverLicenseInfo2.Name = "ctrlDriverLicenseInfo2";
            this.ctrlDriverLicenseInfo2.Size = new System.Drawing.Size(703, 390);
            this.ctrlDriverLicenseInfo2.TabIndex = 132;
            // 
            // ctrlInternationalApplicationInfo1
            // 
            this.ctrlInternationalApplicationInfo1.Location = new System.Drawing.Point(699, 171);
            this.ctrlInternationalApplicationInfo1.Name = "ctrlInternationalApplicationInfo1";
            this.ctrlInternationalApplicationInfo1.Size = new System.Drawing.Size(293, 336);
            this.ctrlInternationalApplicationInfo1.TabIndex = 133;
            // 
            // frmNewInternationalLicenseAppliction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 538);
            this.Controls.Add(this.ctrlInternationalApplicationInfo1);
            this.Controls.Add(this.ctrlDriverLicenseInfo2);
            this.Controls.Add(this.ctrlLicenseFilter2);
            this.Controls.Add(this.lnkShowLicenseInfo);
            this.Controls.Add(this.lnkShowLicenseHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmNewInternationalLicenseAppliction";
            this.Text = "frmNewInternationalLicenseAppliction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLicenseIn.ctrlLicenseFilter ctrlLicenseFilter1;
        private Licenses.ctrlLicense.ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList ilAddPerson;
        private System.Windows.Forms.LinkLabel lnkShowLicenseHistory;
        private System.Windows.Forms.LinkLabel lnkShowLicenseInfo;
        private ctrlLicenseIn.ctrlLicenseFilter ctrlLicenseFilter2;
        private Licenses.ctrlLicense.ctrlDriverLicenseInfo ctrlDriverLicenseInfo2;
        private ctrlLicenseIn.ctrlInternationalApplicationInfo ctrlInternationalApplicationInfo1;
    }
}