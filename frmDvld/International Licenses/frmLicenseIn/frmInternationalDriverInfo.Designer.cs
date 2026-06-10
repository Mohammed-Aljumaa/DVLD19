namespace frmDvld.International_Licenses.frmLicenseIn
{
    partial class frmInternationalDriverInfo
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
            this.lblAddEditNewPerson = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlDriverLicenseInternationalInfo1 = new frmDvld.International_Licenses.ctrlLicenseIn.ctrlDriverLicenseInternationalInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddEditNewPerson
            // 
            this.lblAddEditNewPerson.AutoSize = true;
            this.lblAddEditNewPerson.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblAddEditNewPerson.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblAddEditNewPerson.Location = new System.Drawing.Point(187, 88);
            this.lblAddEditNewPerson.Name = "lblAddEditNewPerson";
            this.lblAddEditNewPerson.Size = new System.Drawing.Size(431, 37);
            this.lblAddEditNewPerson.TabIndex = 104;
            this.lblAddEditNewPerson.Text = "Driver International License Info";
            this.lblAddEditNewPerson.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::frmDvld.Properties.Resources.degree;
            this.pictureBox1.Location = new System.Drawing.Point(351, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::frmDvld.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(658, 425);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 41);
            this.btnClose.TabIndex = 107;
            this.btnClose.Tag = "";
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlDriverLicenseInternationalInfo1
            // 
            this.ctrlDriverLicenseInternationalInfo1.Location = new System.Drawing.Point(12, 138);
            this.ctrlDriverLicenseInternationalInfo1.Name = "ctrlDriverLicenseInternationalInfo1";
            this.ctrlDriverLicenseInternationalInfo1.Size = new System.Drawing.Size(781, 281);
            this.ctrlDriverLicenseInternationalInfo1.TabIndex = 105;
            // 
            // frmInternationalDriverInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(783, 469);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlDriverLicenseInternationalInfo1);
            this.Controls.Add(this.lblAddEditNewPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmInternationalDriverInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmInternationalDriverInfo";
            this.Load += new System.EventHandler(this.frmInternationalDriverInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddEditNewPerson;
        private ctrlLicenseIn.ctrlDriverLicenseInternationalInfo ctrlDriverLicenseInternationalInfo1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
    }
}