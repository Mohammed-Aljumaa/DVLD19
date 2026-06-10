namespace frmDvld.Users.frmUsers
{
    partial class frmAddNewUser
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
            this.lblAddEditNewPerson = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tapPersonInfo = new System.Windows.Forms.TabPage();
            this.tapLoginInfo = new System.Windows.Forms.TabPage();
            this.lblUserID = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errpUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNextTap = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbLableADDandEdit = new System.Windows.Forms.PictureBox();
            this.ctrlPersonCardWithFilter1 = new frmDvld.ctrlPersonCardWithFilter();
            this.tabControl1.SuspendLayout();
            this.tapPersonInfo.SuspendLayout();
            this.tapLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errpUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLableADDandEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddEditNewPerson
            // 
            this.lblAddEditNewPerson.AutoSize = true;
            this.lblAddEditNewPerson.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEditNewPerson.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblAddEditNewPerson.Location = new System.Drawing.Point(332, 9);
            this.lblAddEditNewPerson.Name = "lblAddEditNewPerson";
            this.lblAddEditNewPerson.Size = new System.Drawing.Size(236, 45);
            this.lblAddEditNewPerson.TabIndex = 49;
            this.lblAddEditNewPerson.Text = "Add New User";
            this.lblAddEditNewPerson.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tapPersonInfo);
            this.tabControl1.Controls.Add(this.tapLoginInfo);
            this.tabControl1.Location = new System.Drawing.Point(22, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 466);
            this.tabControl1.TabIndex = 52;
            // 
            // tapPersonInfo
            // 
            this.tapPersonInfo.Controls.Add(this.btnNextTap);
            this.tapPersonInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tapPersonInfo.Location = new System.Drawing.Point(4, 22);
            this.tapPersonInfo.Name = "tapPersonInfo";
            this.tapPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tapPersonInfo.Size = new System.Drawing.Size(808, 440);
            this.tapPersonInfo.TabIndex = 0;
            this.tapPersonInfo.Text = "Person Info";
            this.tapPersonInfo.UseVisualStyleBackColor = true;
            // 
            // tapLoginInfo
            // 
            this.tapLoginInfo.Controls.Add(this.lblUserID);
            this.tapLoginInfo.Controls.Add(this.chkIsActive);
            this.tapLoginInfo.Controls.Add(this.txtConfirmPassword);
            this.tapLoginInfo.Controls.Add(this.txtPassword);
            this.tapLoginInfo.Controls.Add(this.txtUserName);
            this.tapLoginInfo.Controls.Add(this.label4);
            this.tapLoginInfo.Controls.Add(this.label3);
            this.tapLoginInfo.Controls.Add(this.label2);
            this.tapLoginInfo.Controls.Add(this.label1);
            this.tapLoginInfo.Controls.Add(this.pictureBox4);
            this.tapLoginInfo.Controls.Add(this.pictureBox3);
            this.tapLoginInfo.Controls.Add(this.pictureBox1);
            this.tapLoginInfo.Controls.Add(this.pictureBox2);
            this.tapLoginInfo.Location = new System.Drawing.Point(4, 22);
            this.tapLoginInfo.Name = "tapLoginInfo";
            this.tapLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tapLoginInfo.Size = new System.Drawing.Size(808, 440);
            this.tapLoginInfo.TabIndex = 1;
            this.tapLoginInfo.Text = "Login Info";
            this.tapLoginInfo.UseVisualStyleBackColor = true;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(258, 83);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(43, 22);
            this.lblUserID.TabIndex = 68;
            this.lblUserID.Text = "???";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(258, 255);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(68, 17);
            this.chkIsActive.TabIndex = 67;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(258, 209);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(148, 22);
            this.txtConfirmPassword.TabIndex = 66;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(258, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(148, 22);
            this.txtPassword.TabIndex = 64;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(258, 123);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(148, 22);
            this.txtUserName.TabIndex = 62;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 18);
            this.label4.TabIndex = 60;
            this.label4.Text = "Confirm Password : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 59;
            this.label3.Text = "Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 58;
            this.label2.Text = "User Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 55;
            this.label1.Text = "User ID :";
            // 
            // errpUser
            // 
            this.errpUser.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::frmDvld.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(706, 524);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 41);
            this.btnSave.TabIndex = 54;
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
            this.btnClose.Location = new System.Drawing.Point(561, 524);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 41);
            this.btnClose.TabIndex = 53;
            this.btnClose.Tag = "";
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            // pictureBox4
            // 
            this.pictureBox4.Image = global::frmDvld.Properties.Resources.lock_password;
            this.pictureBox4.Location = new System.Drawing.Point(208, 205);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(39, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 65;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::frmDvld.Properties.Resources.lock__2_;
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
            this.pictureBox2.Image = global::frmDvld.Properties.Resources.user__2_;
            this.pictureBox2.Location = new System.Drawing.Point(208, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            // 
            // pbLableADDandEdit
            // 
            this.pbLableADDandEdit.Image = global::frmDvld.Properties.Resources.add;
            this.pbLableADDandEdit.Location = new System.Drawing.Point(295, 9);
            this.pbLableADDandEdit.Name = "pbLableADDandEdit";
            this.pbLableADDandEdit.Size = new System.Drawing.Size(39, 45);
            this.pbLableADDandEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLableADDandEdit.TabIndex = 50;
            this.pbLableADDandEdit.TabStop = false;
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
            // frmAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(838, 568);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pbLableADDandEdit);
            this.Controls.Add(this.lblAddEditNewPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAddNewUser";
            this.Text = "frmAddNewUser";
            this.Load += new System.EventHandler(this.frmAddNewUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tapPersonInfo.ResumeLayout(false);
            this.tapLoginInfo.ResumeLayout(false);
            this.tapLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errpUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLableADDandEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLableADDandEdit;
        private System.Windows.Forms.Label lblAddEditNewPerson;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tapPersonInfo;
        private System.Windows.Forms.TabPage tapLoginInfo;
        private ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnNextTap;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.ErrorProvider errpUser;
    }
}