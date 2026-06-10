using System;
using System.Windows.Forms;
using DvldBusinessLayer.BLLClasses;
using frmDvld.International_Licenses.frmLicenseIn;
using frmDvld.Licenses.frmLicense;
using frmDvld.LoginScreens.ClaassLoginScreen;

namespace frmDvld.International_Licenses
{
    public partial class frmNewInternationalLicenseAppliction : Form
    {
        private clsLicense _localLicense;
        private clsDriver _driver;
        private clsInternationalLicense _issuedInternationalLicense;
        private clsAppliction _appliction;
        int _InternationalLicenseID = -1;
        public frmNewInternationalLicenseAppliction()
        {
            InitializeComponent();

            btnIssue.Enabled = false;
            lnkShowLicenseHistory.Enabled = false;
            lnkShowLicenseInfo.Enabled = false;

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            // 1) جلب الرسوم من قاعدة البيانات
            decimal fees = clsAppliction.GetFees(_appliction.ApplicationTypeID);

            // 2) إنشاء طلب رخصة دولية (Application)
            int newAppID = clsAppliction.CreateInternational(
     _driver.PersonID,
     fees,
     clsGlobal.CurrentUser.UserID);



            // 3) إنشاء الرخصة الدولية نفسها
            int newLicenseID = clsInternationalLicense.AddNew(
                newAppID,
                _driver.DriverID,
                _localLicense.LicenseID,
                DateTime.Now,
                DateTime.Now.AddYears(1),
                clsGlobal.CurrentUser.UserID);

            _InternationalLicenseID = newLicenseID;
            lnkShowLicenseInfo.Enabled = true;

            if (newLicenseID <= 0)
            {
                MessageBox.Show("Failed to issue international license.");
                return;
            }

            // جلب الرخصة الدولية
            _issuedInternationalLicense = clsInternationalLicense.GetInternationalLicenseByID(newLicenseID);

            // تحميل الكونترول الثاني بالبيانات النهائية
            ctrlInternationalApplicationInfo1.LoadFinalInfo(newLicenseID);

            // تفعيل زر عرض الرخصة
            lnkShowLicenseInfo.Enabled = true;

            MessageBox.Show("International license issued successfully.");

        }

        private void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmPersonLicenseHistory frm =
                new frmPersonLicenseHistory(_appliction.ApplicantPersonID);

            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlLicenseFilter2_OnSearch(int licenseID)
        {

            // تفريغ الكونترولز
            ctrlInternationalApplicationInfo1.Clear();
            btnIssue.Enabled = false;
            lnkShowLicenseInfo.Enabled = false;
            _issuedInternationalLicense = null;

            // جلب الرخصة المحلية
            _localLicense = clsLicense.Find(licenseID);
            if (_localLicense == null)
            {
                MessageBox.Show("Local license not found.");
                return;
            }

            // جلب طلب الرخصة الدولية (Application)
            _appliction = clsAppliction.Find(_localLicense.ApplicationID);
            if (_appliction == null)
            {
                MessageBox.Show("No international license application found.");
                return;
            }

            // تحميل الكونترول الأول
            ctrlDriverLicenseInfo2.LoadLicenseInfo(licenseID);

            // تحميل الكونترول الثاني (معلومات أولية)
            ctrlInternationalApplicationInfo1.LoadInitialInfo(licenseID);
            // تفعيل التاريخ
            lnkShowLicenseHistory.Enabled = true;

            // جلب السائق عبر ApplicantPersonID
            _driver = clsDriver.FindByPersonID(_appliction.ApplicantPersonID);
            if (_driver == null)
            {
                MessageBox.Show("Driver not found.");
                return;
            }

            // الشروط
            if (!_localLicense.IsActive)
            {
                MessageBox.Show("Local license is not active.");
                return;
            }

            if (_localLicense.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("Local license is expired.");
                return;
            }

            if (_localLicense.LicenseClass < 3)
            {
                MessageBox.Show("Only Class 3 or higher local licenses can be used.");
                return;
            }

            if (clsInternationalLicense.HasActiveInternationalLicense(_driver.DriverID))
            {
                MessageBox.Show("Driver already has an active international license.");

                _InternationalLicenseID =
                    clsInternationalLicense.GetActiveInternationalLicenseIDByPersonID(_driver.PersonID);

                // حمّل الكونترول الثاني بالمعلومات النهائية
                ctrlInternationalApplicationInfo1.LoadFinalInfo(_InternationalLicenseID);

                lnkShowLicenseInfo.Enabled = true;
                return;
            }

            // إذا وصلنا لهون → كل الشروط صحيحة
            btnIssue.Enabled = true;

        }

        private void lnkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            if (_InternationalLicenseID <= 0)
            {
                MessageBox.Show("No international license to show.");
                return;
            }

            frmInternationalDriverInfo frm = new frmInternationalDriverInfo(_InternationalLicenseID);
            frm.ShowDialog();
        


    }
    }
}
