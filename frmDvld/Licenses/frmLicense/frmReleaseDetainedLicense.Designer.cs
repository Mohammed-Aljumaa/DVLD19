namespace frmDvld.Licenses.frmLicense
{
    partial class frmReleaseDetainedLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReleaseDetainedLicense));
            this.ctrlReleaseDetainInfo1 = new frmDvld.Licenses.ctrlLicense.ctrlReleaseDetainInfo();
            this.ctrlDriverLicenseInfo1 = new frmDvld.Licenses.ctrlLicense.ctrlDriverLicenseInfo();
            this.ctrlLicenseFilter1 = new frmDvld.International_Licenses.ctrlLicenseIn.ctrlLicenseFilter();
            this.lnkShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lnkShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnRelease = new System.Windows.Forms.Button();
            this.ilAddPerson = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlReleaseDetainInfo1
            // 
            this.ctrlReleaseDetainInfo1.Location = new System.Drawing.Point(721, 184);
            this.ctrlReleaseDetainInfo1.Name = "ctrlReleaseDetainInfo1";
            this.ctrlReleaseDetainInfo1.Size = new System.Drawing.Size(335, 353);
            this.ctrlReleaseDetainInfo1.TabIndex = 0;
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(12, 152);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(703, 390);
            this.ctrlDriverLicenseInfo1.TabIndex = 1;
            // 
            // ctrlLicenseFilter1
            // 
            this.ctrlLicenseFilter1.Location = new System.Drawing.Point(114, 38);
            this.ctrlLicenseFilter1.Name = "ctrlLicenseFilter1";
            this.ctrlLicenseFilter1.Size = new System.Drawing.Size(509, 108);
            this.ctrlLicenseFilter1.TabIndex = 2;
            // 
            // lnkShowLicenseInfo
            // 
            this.lnkShowLicenseInfo.AutoSize = true;
            this.lnkShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnkShowLicenseInfo.Location = new System.Drawing.Point(920, 159);
            this.lnkShowLicenseInfo.Name = "lnkShowLicenseInfo";
            this.lnkShowLicenseInfo.Size = new System.Drawing.Size(122, 17);
            this.lnkShowLicenseInfo.TabIndex = 148;
            this.lnkShowLicenseInfo.TabStop = true;
            this.lnkShowLicenseInfo.Text = "Show License Info";
            this.lnkShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseInfo_LinkClicked_1);
            // 
            // lnkShowLicenseHistory
            // 
            this.lnkShowLicenseHistory.AutoSize = true;
            this.lnkShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnkShowLicenseHistory.Location = new System.Drawing.Point(762, 159);
            this.lnkShowLicenseHistory.Name = "lnkShowLicenseHistory";
            this.lnkShowLicenseHistory.Size = new System.Drawing.Size(143, 17);
            this.lnkShowLicenseHistory.TabIndex = 147;
            this.lnkShowLicenseHistory.TabStop = true;
            this.lnkShowLicenseHistory.Text = "Show License History";
            this.lnkShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseHistory_LinkClicked_1);
            // 
            // btnRelease
            // 
            this.btnRelease.BackColor = System.Drawing.Color.White;
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRelease.ForeColor = System.Drawing.Color.Black;
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.ImageKey = "new-product.png";
            this.btnRelease.ImageList = this.ilAddPerson;
            this.btnRelease.Location = new System.Drawing.Point(887, 91);
            this.btnRelease.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(113, 41);
            this.btnRelease.TabIndex = 146;
            this.btnRelease.Tag = "";
            this.btnRelease.Text = "         Release  ";
            this.btnRelease.UseVisualStyleBackColor = false;
            this.btnRelease.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // ilAddPerson
            // 
            this.ilAddPerson.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilAddPerson.ImageStream")));
            this.ilAddPerson.TransparentColor = System.Drawing.Color.Transparent;
            this.ilAddPerson.Images.SetKeyName(0, "user (3).png");
            this.ilAddPerson.Images.SetKeyName(1, "add.png");
            this.ilAddPerson.Images.SetKeyName(2, "licensing.png");
            this.ilAddPerson.Images.SetKeyName(3, "diploma.png");
            this.ilAddPerson.Images.SetKeyName(4, "air-conditioner.png");
            this.ilAddPerson.Images.SetKeyName(5, "new-product.png");
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::frmDvld.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(765, 91);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 41);
            this.btnClose.TabIndex = 145;
            this.btnClose.Tag = "";
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1085, 535);
            this.Controls.Add(this.lnkShowLicenseInfo);
            this.Controls.Add(this.lnkShowLicenseHistory);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLicenseFilter1);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.ctrlReleaseDetainInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmReleaseDetainedLicense";
            this.Text = "frmReleaseDetainedLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLicense.ctrlReleaseDetainInfo ctrlReleaseDetainInfo1;
        private ctrlLicense.ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private International_Licenses.ctrlLicenseIn.ctrlLicenseFilter ctrlLicenseFilter1;
        private System.Windows.Forms.LinkLabel lnkShowLicenseInfo;
        private System.Windows.Forms.LinkLabel lnkShowLicenseHistory;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList ilAddPerson;
    }
}