namespace frmDvld.Licenses.frmLicense
{
    partial class frmDetainLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetainLicense));
            this.lnkShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lnkShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnDetain = new System.Windows.Forms.Button();
            this.ilAddPerson = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlDriverLicenseInfo1 = new frmDvld.Licenses.ctrlLicense.ctrlDriverLicenseInfo();
            this.ctrlLicenseFilter1 = new frmDvld.International_Licenses.ctrlLicenseIn.ctrlLicenseFilter();
            this.ctrlDetainInfo1 = new frmDvld.Licenses.ctrlLicense.ctrlDetainInfo();
            this.SuspendLayout();
            // 
            // lnkShowLicenseInfo
            // 
            this.lnkShowLicenseInfo.AutoSize = true;
            this.lnkShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnkShowLicenseInfo.Location = new System.Drawing.Point(899, 194);
            this.lnkShowLicenseInfo.Name = "lnkShowLicenseInfo";
            this.lnkShowLicenseInfo.Size = new System.Drawing.Size(122, 17);
            this.lnkShowLicenseInfo.TabIndex = 144;
            this.lnkShowLicenseInfo.TabStop = true;
            this.lnkShowLicenseInfo.Text = "Show License Info";
            this.lnkShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseInfo_LinkClicked);
            // 
            // lnkShowLicenseHistory
            // 
            this.lnkShowLicenseHistory.AutoSize = true;
            this.lnkShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnkShowLicenseHistory.Location = new System.Drawing.Point(741, 194);
            this.lnkShowLicenseHistory.Name = "lnkShowLicenseHistory";
            this.lnkShowLicenseHistory.Size = new System.Drawing.Size(143, 17);
            this.lnkShowLicenseHistory.TabIndex = 143;
            this.lnkShowLicenseHistory.TabStop = true;
            this.lnkShowLicenseHistory.Text = "Show License History";
            this.lnkShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicenseHistory_LinkClicked);
            // 
            // btnDetain
            // 
            this.btnDetain.BackColor = System.Drawing.Color.White;
            this.btnDetain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetain.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDetain.ForeColor = System.Drawing.Color.Black;
            this.btnDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetain.ImageKey = "air-conditioner.png";
            this.btnDetain.ImageList = this.ilAddPerson;
            this.btnDetain.Location = new System.Drawing.Point(866, 126);
            this.btnDetain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(113, 41);
            this.btnDetain.TabIndex = 142;
            this.btnDetain.Tag = "";
            this.btnDetain.Text = "           Detain  ";
            this.btnDetain.UseVisualStyleBackColor = false;
            this.btnDetain.Click += new System.EventHandler(this.btnIssueReplacment_Click);
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
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::frmDvld.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(744, 126);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 41);
            this.btnClose.TabIndex = 141;
            this.btnClose.Tag = "";
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(12, 126);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(703, 390);
            this.ctrlDriverLicenseInfo1.TabIndex = 2;
            // 
            // ctrlLicenseFilter1
            // 
            this.ctrlLicenseFilter1.Location = new System.Drawing.Point(132, 15);
            this.ctrlLicenseFilter1.Name = "ctrlLicenseFilter1";
            this.ctrlLicenseFilter1.Size = new System.Drawing.Size(509, 108);
            this.ctrlLicenseFilter1.TabIndex = 1;
            // 
            // ctrlDetainInfo1
            // 
            this.ctrlDetainInfo1.Location = new System.Drawing.Point(717, 215);
            this.ctrlDetainInfo1.Name = "ctrlDetainInfo1";
            this.ctrlDetainInfo1.Size = new System.Drawing.Size(330, 289);
            this.ctrlDetainInfo1.TabIndex = 0;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1060, 568);
            this.Controls.Add(this.lnkShowLicenseInfo);
            this.Controls.Add(this.lnkShowLicenseHistory);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.ctrlLicenseFilter1);
            this.Controls.Add(this.ctrlDetainInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDetainLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLicense.ctrlDetainInfo ctrlDetainInfo1;
        private International_Licenses.ctrlLicenseIn.ctrlLicenseFilter ctrlLicenseFilter1;
        private ctrlLicense.ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private System.Windows.Forms.LinkLabel lnkShowLicenseInfo;
        private System.Windows.Forms.LinkLabel lnkShowLicenseHistory;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList ilAddPerson;
    }
}