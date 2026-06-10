using System;
using System.Windows.Forms;
using DvldBusinessLayer.BLLClasses;
using frmDvld.LoginScreens.ClaassLoginScreen;
using frmDvld.Licenses.frmLicense;

namespace frmDvld.Licenses.frmLicense
{
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        private clsLicense _oldLicense;
        private clsAppliction _application;
        private clsDriver _driver;
        private int _newLicenseID = -1;

        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            btnRenew.Enabled = false;
            lnkShowLicenseInfo.Enabled = false;
            lnkShowLicenseHistory.Enabled = false;
        }

        private void ctrlLicenseFilter1_OnSearch_1(int licenseID)
        {

            // تفريغ الكنترولات
            ctrlRenewLocalDrivingLicense1.ResetControl();

            btnRenew.Enabled = false;
            lnkShowLicenseInfo.Enabled = false;
            _newLicenseID = -1;

            // جلب الرخصة القديمة
            _oldLicense = clsLicense.Find(licenseID);
            if (_oldLicense == null)
            {
                MessageBox.Show("License not found.");
                return;
            }

            // جلب الطلب القديم
            _application = clsAppliction.Find(_oldLicense.ApplicationID);
            if (_application == null)
            {
                MessageBox.Show("Application not found.");
                return;
            }

            // جلب السائق
            _driver = clsDriver.FindByPersonID(_application.ApplicantPersonID);
            if (_driver == null)
            {
                MessageBox.Show("Driver not found.");
                return;
            }

            // تحميل معلومات الرخصة القديمة
            ctrlDriverLicenseInfo1.LoadLicenseInfo(licenseID);

            // تحميل معلومات الطلب القديم
            ctrlRenewLocalDrivingLicense1.LoadApplicationInfo(_application.ApplicationID);

            // تحميل معلومات الرخصة القديمة داخل الكنترول
            ctrlRenewLocalDrivingLicense1.LoadOldLicenseInfo(licenseID);

            // تفعيل عرض التاريخ
            lnkShowLicenseHistory.Enabled = true;

            // الشروط
            if (!_oldLicense.IsActive)
            {
                MessageBox.Show("License is not active.");
                return;
            }

            if (_oldLicense.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show("License is not expired yet.");
                return;
            }

            if (clsDetainedLicense.IsLicenseDetained(licenseID))
            {
                MessageBox.Show("License is detained.");
                return;
            }

            // إذا وصلنا لهون → كل الشروط صحيحة
            btnRenew.Enabled = true;

        }

        private void btnRenew_Click_1(object sender, EventArgs e)
        {
            // 1) إنشاء طلب تجديد جديد
            decimal appFees = clsAppliction.GetFees(3); // 3 = Renewal
            int newAppID = clsAppliction.CreateRenew(
                _driver.PersonID,
                appFees,
                clsGlobal.CurrentUser.UserID);

            if (newAppID <= 0)
            {
                MessageBox.Show("Failed to create renewal application.");
                return;
            }

            // 2) إنشاء رخصة جديدة
            clsLicense newLicense = new clsLicense();
            newLicense.ApplicationID = newAppID;
            newLicense.DriverID = _oldLicense.DriverID;
            newLicense.LicenseClass = _oldLicense.LicenseClass;
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = DateTime.Now.AddYears(10);
            newLicense.PaidFees = _oldLicense.PaidFees;
            newLicense.IsActive = true;
            newLicense.IssueReason = 2; // Renew
            newLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            newLicense.Notes = ctrlRenewLocalDrivingLicense1.GetNotes().ToString();

            _newLicenseID = newLicense.Save();

            if (_newLicenseID <= 0)
            {
                MessageBox.Show("Failed to issue renewed license.");
                return;
            }

            // 3) تعطيل الرخصة القديمة
            _oldLicense.IsActive = false;
            _oldLicense.Update();

            // 4) تحميل معلومات الرخصة الجديدة داخل الكنترول
            ctrlRenewLocalDrivingLicense1.LoadRenewedLicenseInfo(_newLicenseID);

            lnkShowLicenseInfo.Enabled = true;

            MessageBox.Show("License renewed successfully.");
            btnRenew.Enabled = false;
            if (_oldLicense.IssueReason == 2)
            {
                MessageBox.Show("This license is already renewed before.");
                return;
            }


        }

        private void lnkShowLicenseHistory_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frm =
            new frmPersonLicenseHistory(_application.ApplicantPersonID);

            frm.ShowDialog();

        }

        private void lnkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (_newLicenseID <= 0)
            {
                MessageBox.Show("No renewed license to show.");
                return;
            }

            frmShowLicense frm = new frmShowLicense(_newLicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
