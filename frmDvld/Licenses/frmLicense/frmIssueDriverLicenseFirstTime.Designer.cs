namespace frmDvld.Licenses
{
    partial class frmIssueDriverLicenseFirstTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIssueDriverLicenseFirstTime));
            this.ctrlApplictionBasicInfo1 = new frmDvld.Appliction.ctrlAppliction.ctrlApplictionBasicInfo();
            this.ctrlDrivingLicenseApplictiponInfo1 = new frmDvld.Appliction.ctrlAppliction.ctrlDrivingLicenseApplictiponInfo();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.ilAddPerson = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlApplictionBasicInfo1
            // 
            this.ctrlApplictionBasicInfo1.Location = new System.Drawing.Point(1, 156);
            this.ctrlApplictionBasicInfo1.Name = "ctrlApplictionBasicInfo1";
            this.ctrlApplictionBasicInfo1.Size = new System.Drawing.Size(690, 248);
            this.ctrlApplictionBasicInfo1.TabIndex = 0;
            // 
            // ctrlDrivingLicenseApplictiponInfo1
            // 
            this.ctrlDrivingLicenseApplictiponInfo1.Location = new System.Drawing.Point(1, -10);
            this.ctrlDrivingLicenseApplictiponInfo1.Name = "ctrlDrivingLicenseApplictiponInfo1";
            this.ctrlDrivingLicenseApplictiponInfo1.Size = new System.Drawing.Size(690, 182);
            this.ctrlDrivingLicenseApplictiponInfo1.TabIndex = 1;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(134, 410);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(542, 145);
            this.txtNotes.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 21);
            this.label5.TabIndex = 123;
            this.label5.Text = "Notes : ";
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
            this.btnIssue.Location = new System.Drawing.Point(8, 495);
            this.btnIssue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(120, 41);
            this.btnIssue.TabIndex = 126;
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
            this.btnClose.Location = new System.Drawing.Point(8, 435);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 41);
            this.btnClose.TabIndex = 125;
            this.btnClose.Tag = "";
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::frmDvld.Properties.Resources.notes;
            this.pictureBox9.Location = new System.Drawing.Point(77, 407);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(39, 21);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 124;
            this.pictureBox9.TabStop = false;
            // 
            // frmIssueDriverLicenseFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(688, 567);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.ctrlDrivingLicenseApplictiponInfo1);
            this.Controls.Add(this.ctrlApplictionBasicInfo1);
            this.Name = "frmIssueDriverLicenseFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIssueDriverLicenseFirstTime";
            this.Load += new System.EventHandler(this.frmIssueDriverLicenseFirstTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Appliction.ctrlAppliction.ctrlApplictionBasicInfo ctrlApplictionBasicInfo1;
        private Appliction.ctrlAppliction.ctrlDrivingLicenseApplictiponInfo ctrlDrivingLicenseApplictiponInfo1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.ImageList ilAddPerson;
    }
}