namespace frmDvld
{
    partial class frmMain
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
            this.cmMain = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicensesServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rnewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementForLostDamagedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLocalDrivingLicenseApplictionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalDrivingLicenseApplictionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.detToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.manageTestTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmMain
            // 
            this.cmMain.BackColor = System.Drawing.Color.White;
            this.cmMain.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmMain.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.cmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountToolStripMenuItem});
            this.cmMain.Location = new System.Drawing.Point(0, 0);
            this.cmMain.Name = "cmMain";
            this.cmMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmMain.Size = new System.Drawing.Size(1184, 72);
            this.cmMain.TabIndex = 1;
            this.cmMain.Text = "Applications";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicensesServicesToolStripMenuItem,
            this.toolStripSeparator4,
            this.mangeToolStripMenuItem,
            this.toolStripSeparator2,
            this.detToolStripMenuItem,
            this.toolStripSeparator5,
            this.manageApplicationTypesToolStripMenuItem,
            this.toolStripSeparator6,
            this.manageTestTypeToolStripMenuItem,
            this.toolStripSeparator7});
            this.applicationsToolStripMenuItem.Image = global::frmDvld.Properties.Resources.talent;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(184, 68);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // drivingLicensesServicesToolStripMenuItem
            // 
            this.drivingLicensesServicesToolStripMenuItem.BackgroundImage = global::frmDvld.Properties.Resources.rpa;
            this.drivingLicensesServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.rnewToolStripMenuItem,
            this.replacementForLostDamagedLicenseToolStripMenuItem});
            this.drivingLicensesServicesToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.drivingLicensesServicesToolStripMenuItem.Name = "drivingLicensesServicesToolStripMenuItem";
            this.drivingLicensesServicesToolStripMenuItem.Size = new System.Drawing.Size(287, 50);
            this.drivingLicensesServicesToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(394, 28);
            this.newDrivingLicenseToolStripMenuItem.Text = " New Driving License";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.internationalLicenseToolStripMenuItem.Text = "International License";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // rnewToolStripMenuItem
            // 
            this.rnewToolStripMenuItem.Name = "rnewToolStripMenuItem";
            this.rnewToolStripMenuItem.Size = new System.Drawing.Size(394, 28);
            this.rnewToolStripMenuItem.Text = "Renew Driving License";
            this.rnewToolStripMenuItem.Click += new System.EventHandler(this.rnewToolStripMenuItem_Click);
            // 
            // replacementForLostDamagedLicenseToolStripMenuItem
            // 
            this.replacementForLostDamagedLicenseToolStripMenuItem.Name = "replacementForLostDamagedLicenseToolStripMenuItem";
            this.replacementForLostDamagedLicenseToolStripMenuItem.Size = new System.Drawing.Size(394, 28);
            this.replacementForLostDamagedLicenseToolStripMenuItem.Text = "Replacement for Lost/Damaged License";
            this.replacementForLostDamagedLicenseToolStripMenuItem.Click += new System.EventHandler(this.replacementForLostDamagedLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.SteelBlue;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(284, 6);
            // 
            // mangeToolStripMenuItem
            // 
            this.mangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLocalDrivingLicenseApplictionToolStripMenuItem,
            this.internationalDrivingLicenseApplictionToolStripMenuItem});
            this.mangeToolStripMenuItem.Name = "mangeToolStripMenuItem";
            this.mangeToolStripMenuItem.Size = new System.Drawing.Size(287, 50);
            this.mangeToolStripMenuItem.Text = "Manage Application";
            // 
            // newLocalDrivingLicenseApplictionToolStripMenuItem
            // 
            this.newLocalDrivingLicenseApplictionToolStripMenuItem.Name = "newLocalDrivingLicenseApplictionToolStripMenuItem";
            this.newLocalDrivingLicenseApplictionToolStripMenuItem.Size = new System.Drawing.Size(331, 28);
            this.newLocalDrivingLicenseApplictionToolStripMenuItem.Text = "Local Driving License Appliction";
            this.newLocalDrivingLicenseApplictionToolStripMenuItem.Click += new System.EventHandler(this.newLocalDrivingLicenseApplictionToolStripMenuItem_Click);
            // 
            // internationalDrivingLicenseApplictionToolStripMenuItem
            // 
            this.internationalDrivingLicenseApplictionToolStripMenuItem.Name = "internationalDrivingLicenseApplictionToolStripMenuItem";
            this.internationalDrivingLicenseApplictionToolStripMenuItem.Size = new System.Drawing.Size(331, 28);
            this.internationalDrivingLicenseApplictionToolStripMenuItem.Text = "International License Appliction";
            this.internationalDrivingLicenseApplictionToolStripMenuItem.Click += new System.EventHandler(this.internationalDrivingLicenseApplictionToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(284, 6);
            // 
            // detToolStripMenuItem
            // 
            this.detToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainLicensesToolStripMenuItem,
            this.detainLicensesToolStripMenuItem,
            this.relaseToolStripMenuItem});
            this.detToolStripMenuItem.Name = "detToolStripMenuItem";
            this.detToolStripMenuItem.Size = new System.Drawing.Size(287, 50);
            this.detToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageDetainLicensesToolStripMenuItem
            // 
            this.manageDetainLicensesToolStripMenuItem.Name = "manageDetainLicensesToolStripMenuItem";
            this.manageDetainLicensesToolStripMenuItem.Size = new System.Drawing.Size(272, 28);
            this.manageDetainLicensesToolStripMenuItem.Text = "Manage Detain Licenses";
            this.manageDetainLicensesToolStripMenuItem.Click += new System.EventHandler(this.manageDetainLicensesToolStripMenuItem_Click);
            // 
            // detainLicensesToolStripMenuItem
            // 
            this.detainLicensesToolStripMenuItem.Name = "detainLicensesToolStripMenuItem";
            this.detainLicensesToolStripMenuItem.Size = new System.Drawing.Size(272, 28);
            this.detainLicensesToolStripMenuItem.Text = "Detain Licenses";
            this.detainLicensesToolStripMenuItem.Click += new System.EventHandler(this.detainLicensesToolStripMenuItem_Click);
            // 
            // relaseToolStripMenuItem
            // 
            this.relaseToolStripMenuItem.Name = "relaseToolStripMenuItem";
            this.relaseToolStripMenuItem.Size = new System.Drawing.Size(272, 28);
            this.relaseToolStripMenuItem.Text = "Release Detain License";
            this.relaseToolStripMenuItem.Click += new System.EventHandler(this.relaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(284, 6);
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(287, 50);
            this.manageApplicationTypesToolStripMenuItem.Text = "Manage Application Types\n";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(284, 6);
            // 
            // manageTestTypeToolStripMenuItem
            // 
            this.manageTestTypeToolStripMenuItem.Name = "manageTestTypeToolStripMenuItem";
            this.manageTestTypeToolStripMenuItem.Size = new System.Drawing.Size(287, 50);
            this.manageTestTypeToolStripMenuItem.Text = "Manage Test Type";
            this.manageTestTypeToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypeToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(284, 6);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Image = global::frmDvld.Properties.Resources.group;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(141, 68);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = global::frmDvld.Properties.Resources.car_sharing2;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(144, 68);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = global::frmDvld.Properties.Resources.group_3__;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(131, 68);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator1,
            this.sinToolStripMenuItem});
            this.accountToolStripMenuItem.Image = global::frmDvld.Properties.Resources.account_settings;
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(218, 68);
            this.accountToolStripMenuItem.Text = "Account Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // sinToolStripMenuItem
            // 
            this.sinToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.sinToolStripMenuItem.Name = "sinToolStripMenuItem";
            this.sinToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.sinToolStripMenuItem.Text = "Sign Out";
            this.sinToolStripMenuItem.Click += new System.EventHandler(this.sinToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::frmDvld.Properties.Resources.Copilot_20260422_0817491;
            this.ClientSize = new System.Drawing.Size(1184, 749);
            this.Controls.Add(this.cmMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.cmMain;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.cmMain.ResumeLayout(false);
            this.cmMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip cmMain;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicensesServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem newLocalDrivingLicenseApplictionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalDrivingLicenseApplictionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rnewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementForLostDamagedLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}