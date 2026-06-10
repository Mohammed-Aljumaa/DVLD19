using DvldBusinessLayer.BLLClasses;
using System;
using System.Windows.Forms;
using System.Data;
using System.IO;
using frmDvld.LoginScreens.ClaassLoginScreen;
using frmDvld.Users;

namespace frmDvld.LoginScreens
{
    public partial class frmLoginScreens : Form
    {


        
        public frmLoginScreens()
        {
            InitializeComponent();
        }
        
        private void frmLoginScreens_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if(clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked=true;
            }
            else
                chkRememberMe.Checked = false;

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            clsUsers user = clsUsers.FindByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (user != null)
            {

                if (chkRememberMe.Checked)
                {
                    //تخزين اسم المستخم والباسوورد 
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    //تخزين فارغ 
                    clsGlobal.RememberUsernameAndPassword("", "");
                }




                if (!user.IsActives)
                {
                    txtUserName.Focus();

                    MessageBox.Show(
                        "Your Account Is Not Active, Contact Admin",   // النص الأساسي
                        "Inactive Account",                            // العنوان
                        MessageBoxButtons.OK,                          // الأزرار (مثلاً OK فقط)
                        MessageBoxIcon.Warning                         // الأيقونة (تحذير)
                    );

                    return; // إيقاف التنفيذ بعد الرسالة
                }

                clsGlobal.CurrentUser = user;
                this.Hide();
                frmMain frm =new frmMain();
                frm.ShowDialog();
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid UsreName/Password.", "Worng Contact",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmManageUsers frm=new frmManageUsers();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMangePeople frm=new frmMangePeople();
            frm.ShowDialog();
        }
    }
}
