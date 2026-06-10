namespace frmDvld
{
    partial class frmAddEditPersonInfo
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
            this.lblPersonID = new System.Windows.Forms.Label();
            this.Lable1 = new System.Windows.Forms.Label();
            this.lblAddEditNewPerson = new System.Windows.Forms.Label();
            this.ctrlAddNewPerson2 = new frmDvld.ctrlAddNewPerson();
            this.pbLableADDandEdit = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLableADDandEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.lblPersonID.Location = new System.Drawing.Point(153, 88);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(28, 14);
            this.lblPersonID.TabIndex = 46;
            this.lblPersonID.Text = "N/A";
            // 
            // Lable1
            // 
            this.Lable1.AutoSize = true;
            this.Lable1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lable1.Location = new System.Drawing.Point(30, 88);
            this.Lable1.Name = "Lable1";
            this.Lable1.Size = new System.Drawing.Size(74, 15);
            this.Lable1.TabIndex = 44;
            this.Lable1.Text = "PersonID :";
            // 
            // lblAddEditNewPerson
            // 
            this.lblAddEditNewPerson.AutoSize = true;
            this.lblAddEditNewPerson.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblAddEditNewPerson.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAddEditNewPerson.Location = new System.Drawing.Point(257, 21);
            this.lblAddEditNewPerson.Name = "lblAddEditNewPerson";
            this.lblAddEditNewPerson.Size = new System.Drawing.Size(229, 37);
            this.lblAddEditNewPerson.TabIndex = 43;
            this.lblAddEditNewPerson.Text = "Add New Person";
            this.lblAddEditNewPerson.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ctrlAddNewPerson2
            // 
            this.ctrlAddNewPerson2.Address = "";
            this.ctrlAddNewPerson2.BackColor = System.Drawing.Color.White;
            this.ctrlAddNewPerson2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAddNewPerson2.CountryIDInComboBox = 90;
            this.ctrlAddNewPerson2.CountryOfPerson = null;
            this.ctrlAddNewPerson2.CurrentPersonID = 0;
            this.ctrlAddNewPerson2.DateOfBirth = new System.DateTime(2007, 11, 13, 20, 56, 47, 790);
            this.ctrlAddNewPerson2.Email = "";
            this.ctrlAddNewPerson2.FirstName = "";
            this.ctrlAddNewPerson2.Gendor = ((byte)(0));
            this.ctrlAddNewPerson2.ImagePath = null;
            this.ctrlAddNewPerson2.LastName = "";
            this.ctrlAddNewPerson2.Location = new System.Drawing.Point(12, 111);
            this.ctrlAddNewPerson2.Name = "ctrlAddNewPerson2";
            this.ctrlAddNewPerson2.NationalNo = "";
            this.ctrlAddNewPerson2.Phone = "";
            this.ctrlAddNewPerson2.RemoveImage = false;
            this.ctrlAddNewPerson2.SecondName = "";
            this.ctrlAddNewPerson2.Size = new System.Drawing.Size(784, 340);
            this.ctrlAddNewPerson2.TabIndex = 47;
            this.ctrlAddNewPerson2.ThirdName = "";
            this.ctrlAddNewPerson2.OnSaveClicked += new System.Action(this.ctrlAddNewPerson2_OnSaveClicked);
            // 
            // pbLableADDandEdit
            // 
            this.pbLableADDandEdit.Image = global::frmDvld.Properties.Resources.user__3_;
            this.pbLableADDandEdit.Location = new System.Drawing.Point(226, 21);
            this.pbLableADDandEdit.Name = "pbLableADDandEdit";
            this.pbLableADDandEdit.Size = new System.Drawing.Size(33, 37);
            this.pbLableADDandEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLableADDandEdit.TabIndex = 48;
            this.pbLableADDandEdit.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::frmDvld.Properties.Resources.id_card__2_;
            this.pictureBox1.Location = new System.Drawing.Point(116, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // frmAddEditPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(808, 475);
            this.Controls.Add(this.pbLableADDandEdit);
            this.Controls.Add(this.ctrlAddNewPerson2);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Lable1);
            this.Controls.Add(this.lblAddEditNewPerson);
            this.Name = "frmAddEditPersonInfo";
            this.Text = "Add/Edit Person Info";
            this.Load += new System.EventHandler(this.frmAddEditPersonInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLableADDandEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Lable1;
        private System.Windows.Forms.Label lblAddEditNewPerson;
        private ctrlAddNewPerson ctrlAddNewPerson2;
        private System.Windows.Forms.PictureBox pbLableADDandEdit;
    }
}