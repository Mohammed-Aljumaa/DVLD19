using DvldBusinessLayer;
using frmDvld.Appliction.frmAppliction;
using frmDvld.Driver;
using frmDvld.International_Licenses;
using frmDvld.International_Licenses.frmLicenseIn;
using frmDvld.Licenses.frmLicense;
using frmDvld.LoginScreens;
using frmDvld.LoginScreens.ClaassLoginScreen;
using frmDvld.Users;
using frmDvld.Users.frmUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmDvld
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangePeople frm = new frmMangePeople();
            frm.MdiParent = this;
            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm  = new frmManageUsers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser);
            frm.MdiParent = this;
            frm.Show();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser);
            frm.MdiParent = this;
            frm.Show();



        }

        private void sinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
             
            frmLoginScreens frm=new frmLoginScreens();
            frm.Show();

            this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm= new frmManageApplicationTypes();
            
            frm.ShowDialog();
        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeTest frm=new frmMangeTest();
            
            frm.ShowDialog();

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseAppliction frm =new frmNewLocalDrivingLicenseAppliction();
            frm.ShowDialog();

        }

        private void newLocalDrivingLicenseApplictionToolStripMenuItem_Click(object sender, EventArgs e)
        {
          frmManageAppliction frm = new frmManageAppliction();
            frm.ShowDialog();

        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseAppliction frm = new frmNewInternationalLicenseAppliction();
            frm.ShowDialog();

        }

        private void internationalDrivingLicenseApplictionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenseAppliction frm = new frmManageInternationalLicenseAppliction();
            frm.ShowDialog();
        }

        private void rnewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication frm=new frmRenewLocalDrivingLicenseApplication();

            frm.ShowDialog();

                }

        private void replacementForLostDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLicense frm = new frmReplaceLicense();
            frm.ShowDialog();
        }

        private void detainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                frmDetainLicense frm = new frmDetainLicense();
                frm.ShowDialog();
            

        }

        private void relaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
                frm.ShowDialog();
            }

        private void manageDetainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDriver frm = new frmManageDriver();
            frm.ShowDialog();
        }
    }
}
