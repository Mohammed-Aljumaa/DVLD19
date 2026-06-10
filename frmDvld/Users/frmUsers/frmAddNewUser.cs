using DvldBusinessLayer;
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
    public partial class frmAddNewUser : Form
    {
        public enum enMode { AddNew = 0, UpDate = 1 };
        private enMode _Mode;
        int _UserID;
        int _PersonID;

        clsUsers _user;
        public frmAddNewUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddNewUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.UpDate;
            _user = new clsUsers();//عند التعديل
            _UserID = UserID;
        }
        public frmAddNewUser(int UserID,int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.UpDate;
            _user = new clsUsers();//عند التعديل
            _UserID = UserID;
            _PersonID = PersonID;
            
        }
        private void _ResetDefualtValues()
        {

            if (_Mode == enMode.AddNew)
            {
                lblAddEditNewPerson.Text = "Add New User";
                pbLableADDandEdit.Image = Properties.Resources.add;
                _user = new clsUsers();//عند الاضافة 
            }
            else
            {
                lblAddEditNewPerson.Text = "Update User";
                pbLableADDandEdit.Image = Properties.Resources.update;


            }
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtConfirmPassword.Text = "";
            lblUserID.Text = "???";
            chkIsActive.Checked = false;




        }

        private void _LoadData()
        {

            if (_PersonID >0)
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
            }
            _user = clsUsers.Find(_UserID);

            if (_user == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblUserID.Text = _user.UserID.ToString();
            txtUserName.Text = _user.UserName;
            txtPassword.Text = _user.Password;
            txtConfirmPassword.Text = _user.Password;
            chkIsActive.Checked = _user.IsActives;




        }
        private void _FillUserObject()
        {
            _user.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _user.UserName = txtUserName.Text.Trim();
            _user.Password = txtPassword.Text.Trim();
            _user.IsActives = chkIsActive.Checked;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                if (!this.ValidateChildren())
                {
                    MessageBox.Show("Some fields are not valid! Put the mouse over the red icon(s) to see the error.",
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // رجّع التركيز لأول حقل فاضي
                    if (string.IsNullOrWhiteSpace(txtUserName.Text))
                        txtUserName.Focus();
                    else if (string.IsNullOrWhiteSpace(txtPassword.Text))
                        txtPassword.Focus();
                    else if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                        txtConfirmPassword.Focus();

                    return;
                }

                _FillUserObject();

                if (_user.Save())
                {
                    lblAddEditNewPerson.Text = "Update User";
                    lblUserID.Text = _user.UserID.ToString();
                pbLableADDandEdit.Image = Properties.Resources.update;

                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        


        private void btnNextTap_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ctrlPersonCardWithFilter1.SearchText))//SearchText==txtserach
            { 

                ctrlPersonCardWithFilter1.ClearSearch();
            }
            if(ctrlPersonCardWithFilter1.PersonID==-1)
            {
                MessageBox.Show("Please Select a person first! ","Validation",MessageBoxButtons.OK, MessageBoxIcon.Warning);

                
                return;
            }

            int PersonID = ctrlPersonCardWithFilter1.PersonID;


            clsMangepeople selectedPerson = clsMangepeople.Find(ctrlPersonCardWithFilter1.PersonID);
            if (selectedPerson == null)
            {
                MessageBox.Show("The selected person does not exist in the system!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);

               
                return;
            }


            clsUsers existingUser =clsUsers.FindUserByPersonID(PersonID);

            if(existingUser != null)
            {
                MessageBox.Show("The person has already has a user account! ","Duplicate user",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }





            tabControl1.SelectedIndex = 1;
        }



        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            string input = txtUserName.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                e.Cancel = true;
                errpUser.SetError(txtUserName, "UserName cannot be blank.");
                return;
            }

            // إذا كل شيء تمام، امسح رسالة الخطأ
            errpUser.SetError(txtUserName, "");


        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            string input = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
               e.Cancel = true;
                errpUser.SetError(txtPassword, "Password cannot be blank.");
                return;
            }

            // إذا كل شيء تمام، امسح رسالة الخطأ
            errpUser.SetError(txtPassword, "");

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            string input = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                e.Cancel = true;
                errpUser.SetError(txtConfirmPassword, "Confirm Password cannot be blank.");
                return;
            }

            // تحقق من التطابق مع كلمة المرور
            if (txtPassword.Text.Trim() != input)
            {

                e.Cancel = true;
                errpUser.SetError(txtConfirmPassword, "Password confirmation does not match password!");
                return;
            }

            // إذا كل شيء تمام، امسح رسالة الخطأ
            errpUser.SetError(txtConfirmPassword, "");

        }

        private void _ClearValidationErrors()
        {
            errpUser.SetError(txtUserName, "");
            errpUser.SetError(txtPassword, "");
            errpUser.SetError(txtConfirmPassword, "");

        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.UpDate)
            {
                _LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _ClearValidationErrors();
            this.Close();
        }
    }
}


