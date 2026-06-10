namespace frmDvld.Appliction.frmAppliction
{
    partial class frmShowApplication
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
            this.ctrlDrivingLicenseApplictiponInfo1 = new frmDvld.Appliction.ctrlAppliction.ctrlDrivingLicenseApplictiponInfo();
            this.ctrlPersonDetails1 = new frmDvld.ctrlPersonDetails();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenseApplictiponInfo1
            // 
            this.ctrlDrivingLicenseApplictiponInfo1.Location = new System.Drawing.Point(52, 308);
            this.ctrlDrivingLicenseApplictiponInfo1.Name = "ctrlDrivingLicenseApplictiponInfo1";
            this.ctrlDrivingLicenseApplictiponInfo1.Size = new System.Drawing.Size(690, 182);
            this.ctrlDrivingLicenseApplictiponInfo1.TabIndex = 0;
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(12, 12);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(770, 290);
            this.ctrlPersonDetails1.TabIndex = 1;
            // 
            // frmShowApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 588);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Controls.Add(this.ctrlDrivingLicenseApplictiponInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmShowApplication";
            this.Text = "frmShowApplication";
            this.Load += new System.EventHandler(this.frmShowApplication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlAppliction.ctrlDrivingLicenseApplictiponInfo ctrlDrivingLicenseApplictiponInfo1;
        private ctrlPersonDetails ctrlPersonDetails1;
    }
}