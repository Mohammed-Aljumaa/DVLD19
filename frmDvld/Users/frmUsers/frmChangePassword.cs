using DvldBusinessLayer.BLLClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmDvld.Users.frmUsers
{
    public partial class frmChangePassword : Form
    {

        int _UserID;
        clsUsers _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        public frmChangePassword(clsUsers  user)
        {
            InitializeComponent();
            _User = user;
            _UserID = user.UserID;
        }
        private void _LoadData()
        {

            _User = clsUsers.Find(_UserID);

            if( _User == null )
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPersonDetails1.LoadPersonDetails(_User.PersonID);
            ctrlLogInfo1.LoadUserLogInfo(_UserID);
        }

        
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
        _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

                if (!ValidateChildren())   // يفحص كل الـ Validating events
                    return;

                if (_User.ChangePassword(txtNewPassword.Text))
                {
                    MessageBox.Show("Password changed successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to change password!");
                }
            


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

                errorProvider1.SetError(txtCurrentPassword, "");

                if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
                {
                    errorProvider1.SetError(txtCurrentPassword, "Please enter current password");
                    e.Cancel = true;
                    return;
                }

                if (!_User.CheakPassword(txtCurrentPassword.Text))
                {
                    errorProvider1.SetError(txtCurrentPassword, "Current password is incorrect");
                    e.Cancel = true;
                    return;
                }
            



        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {

                errorProvider1.SetError(txtNewPassword, "");

                if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    errorProvider1.SetError(txtNewPassword, "Please enter a new password");
                    e.Cancel = true;
                    return;
                }

                // ممنوع تكون نفس القديمة
                if (txtNewPassword.Text == txtCurrentPassword.Text)
                {
                    errorProvider1.SetError(txtNewPassword, "New password cannot be the same as current password");
                    e.Cancel = true;
                    return;
                }
            

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

                errorProvider1.SetError(txtConfirmPassword, "");

                if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    errorProvider1.SetError(txtConfirmPassword, "Please confirm the new password");
                    e.Cancel = true;
                    return;
                }

                if (txtConfirmPassword.Text != txtNewPassword.Text)
                {
                    errorProvider1.SetError(txtConfirmPassword, "Passwords do not match");
                    e.Cancel = true;
                    return;
                }
            

        }
    }
}
