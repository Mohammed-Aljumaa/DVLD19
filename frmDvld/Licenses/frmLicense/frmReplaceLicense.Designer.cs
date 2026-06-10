namespace frmDvld.Licenses.frmLicense
{
    partial class frmReplaceLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplaceLicense));
            this.lnkShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lnkShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.ilAddPerson = new System.Windows.Forms.ImageList(this.components);
            this.btnIssueReplacment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlLicenseFilter1 = new frmDvld.International_Licenses.ctrlLicenseIn.ctrlLicenseFilter();
            this.ctrlDriverLicenseInfo1 = new frmDvld.Licenses.ctrlLicense.ctrlDriverLicenseInfo();
            this.ctrlApplictionInfoForLicenseReplacement1 = new frmDvld.Licenses.ctrlLicense.ctrlApplictionInfoForLicenseReplacement();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamge = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnkShowLicenseInfo
            // 
            this.lnkShowLicenseInfo.AutoSize = true;
            this.lnkShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnkShowLicenseInfo.Location = new System.Drawing.Point(874, 509);
            this.lnkShowLicenseInfo.Name = "lnkShowLicenseInfo";
            this.lnkShowLicenseInfo.Size = new System.Drawing.Size(122, 17);
            this.lnkShowLicenseInfo.TabIndex = 140;
            this.lnkShowLicenseInfo.TabStop = true;
            this.lnkShowLicenseInfo.Text = "Show License Info";
            this.lnkShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseInfo_LinkClicked);
            // 
            // lnkShowLicenseHistory
            // 
            this.lnkShowLicenseHistory.AutoSize = true;
            this.lnkShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnkShowLicenseHistory.Location = new System.Drawing.Point(716, 509);
            this.lnkShowLicenseHistory.Name = "lnkShowLicenseHistory";
            this.lnkShowLicenseHistory.Size = new System.Drawing.Size(143, 17);
            this.lnkShowLicenseHistory.TabIndex = 139;
            this.lnkShowLicenseHistory.TabStop = true;
            this.lnkShowLicenseHistory.Text = "Show License History";
            this.lnkShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseHistory_LinkClicked);
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
            // btnIssueReplacment
            // 
            this.btnIssueReplacment.BackColor = System.Drawing.Color.White;
            this.btnIssueReplacment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueReplacment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnIssueReplacment.ForeColor = System.Drawing.Color.Black;
            this.btnIssueReplacment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReplacment.ImageKey = "diploma.png";
            this.btnIssueReplacment.ImageList = this.ilAddPerson;
            this.btnIssueReplacment.Location = new System.Drawing.Point(841, 441);
            this.btnIssueReplacment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIssueReplacment.Name = "btnIssueReplacment";
            this.btnIssueReplacment.Size = new System.Drawing.Size(182, 41);
            this.btnIssueReplacment.TabIndex = 138;
            this.btnIssueReplacment.Tag = "";
            this.btnIssueReplacment.Text = "IssueReplacment";
            this.btnIssueReplacment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssueReplacment.UseVisualStyleBackColor = false;
            this.btnIssueReplacment.Click += new System.EventHandler(this.btnIssueReplacment_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::frmDvld.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(719, 441);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 41);
            this.btnClose.TabIndex = 137;
            this.btnClose.Tag = "";
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlLicenseFilter1
            // 
            this.ctrlLicenseFilter1.Location = new System.Drawing.Point(108, 2);
            this.ctrlLicenseFilter1.Name = "ctrlLicenseFilter1";
            this.ctrlLicenseFilter1.Size = new System.Drawing.Size(509, 108);
            this.ctrlLicenseFilter1.TabIndex = 136;
            this.ctrlLicenseFilter1.OnSearch += new System.Action<int>(this.ctrlLicenseFilter1_OnSearch);
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(11, 116);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(702, 390);
            this.ctrlDriverLicenseInfo1.TabIndex = 135;
            // 
            // ctrlApplictionInfoForLicenseReplacement1
            // 
            this.ctrlApplictionInfoForLicenseReplacement1.Location = new System.Drawing.Point(719, 116);
            this.ctrlApplictionInfoForLicenseReplacement1.Name = "ctrlApplictionInfoForLicenseReplacement1";
            this.ctrlApplictionInfoForLicenseReplacement1.Size = new System.Drawing.Size(397, 318);
            this.ctrlApplictionInfoForLicenseReplacement1.TabIndex = 141;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLostLicense);
            this.groupBox1.Controls.Add(this.rbDamge);
            this.groupBox1.Location = new System.Drawing.Point(719, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 142;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacment For : ";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Location = new System.Drawing.Point(16, 62);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(88, 17);
            this.rbLostLicense.TabIndex = 1;
            this.rbLostLicense.TabStop = true;
            this.rbLostLicense.Text = "Lost License ";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            // 
            // rbDamge
            // 
            this.rbDamge.AutoSize = true;
            this.rbDamge.Location = new System.Drawing.Point(16, 29);
            this.rbDamge.Name = "rbDamge";
            this.rbDamge.Size = new System.Drawing.Size(111, 17);
            this.rbDamge.TabIndex = 0;
            this.rbDamge.TabStop = true;
            this.rbDamge.Text = "Damaged License";
            this.rbDamge.UseVisualStyleBackColor = true;
            // 
            // frmReplaceLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 611);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlApplictionInfoForLicenseReplacement1);
            this.Controls.Add(this.lnkShowLicenseInfo);
            this.Controls.Add(this.lnkShowLicenseHistory);
            this.Controls.Add(this.btnIssueReplacment);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLicenseFilter1);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmReplaceLicense";
            this.Text = "frmReplaceLicense";
            this.Load += new System.EventHandler(this.frmReplaceLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkShowLicenseInfo;
        private System.Windows.Forms.LinkLabel lnkShowLicenseHistory;
        private System.Windows.Forms.Button btnIssueReplacment;
        private System.Windows.Forms.ImageList ilAddPerson;
        private System.Windows.Forms.Button btnClose;
        private International_Licenses.ctrlLicenseIn.ctrlLicenseFilter ctrlLicenseFilter1;
        private ctrlLicense.ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private ctrlLicense.ctrlApplictionInfoForLicenseReplacement ctrlApplictionInfoForLicenseReplacement1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamge;
    }
}