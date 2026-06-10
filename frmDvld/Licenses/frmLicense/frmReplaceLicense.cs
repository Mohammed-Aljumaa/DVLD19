using DvldBusinessLayer.BLLClasses;
using frmDvld.LoginScreens.ClaassLoginScreen;
using System;
using System.Windows.Forms;

namespace frmDvld.Licenses.frmLicense
{
    public partial class frmReplaceLicense : Form
    {
        public frmReplaceLicense()
        {
            InitializeComponent();
        }

        private void LoadLicenseInfo(int licenseID)
        {
            clsLicense license = clsLicense.Find(licenseID);

            if (license == null)
            {
                MessageBox.Show("License Not Found!");
                return;
            }

            // تعبئة كنترول معلومات الرخصة
            ctrlDriverLicenseInfo1.LoadLicenseInfo(licenseID);
        }


        private void ctrlLicenseFilter1_OnSearch(int licenseID)
        {
            LoadLicenseInfo(licenseID);

        }

        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {
            rbDamge.Checked = true;   // الوضع الافتراضي
            ctrlApplictionInfoForLicenseReplacement1.Clear();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueReplacment_Click(object sender, EventArgs e)
        {
            // 1) نجيب الرخصة الأصلية
            int oldLicenseID = ctrlDriverLicenseInfo1.LicenseID;

            clsLicense oldLicense = clsLicense.Find(oldLicenseID);

            if (oldLicense == null)
            {
                MessageBox.Show("License Not Found!");
                return;
            }

            // 2) التحقق من أن الرخصة Active
            if (!oldLicense.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license.");
                return;
            }

            // 3) التحقق من أن الرخصة ليست محجوزة
            if (clsDetainedLicense.IsLicenseDetained(oldLicenseID))
            {
                MessageBox.Show("This license is detained. Cannot issue replacement.");
                return;
            }

            // 4) تحديد نوع الاستبدال
            int issueReason = rbDamge.Checked ? 4 : 3;
            // 3 = Lost
            // 4 = Damaged
            // (حسب نظامك، بدك تعكسهم؟ خبرني)

            // 5) إنشاء Application جديد

            clsDriver Driver = clsDriver.Find(oldLicense.DriverID);


            clsAppliction newApp = new clsAppliction();

            newApp.ApplicantPersonID = Driver.PersonID;
            newApp.ApplicationDate = DateTime.Now;
            newApp.ApplicationTypeID = issueReason;
            newApp.PaidFees = rbDamge.Checked ? 5 : 10; // حسب الصورة
            newApp.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!newApp.Save())
            {
                MessageBox.Show("Failed to create application!");
                return;
            }

            // 6) إنشاء License جديدة
            clsLicense newLicense = new clsLicense();
            newLicense.ApplicationID = newApp.ApplicationID;
            newLicense.DriverID = oldLicense.DriverID;
            newLicense.LicenseClass = oldLicense.LicenseClass;
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = oldLicense.ExpirationDate;
            newLicense.Notes = "Replacement License";
            newLicense.IssueReason = Convert.ToByte(issueReason);
            newLicense.IsActive = true;
            newLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if ((newLicense.LicenseID = newLicense.Save()) == -1)
            {
                MessageBox.Show("Failed to create new license!");
                return;
            }

            // 7) تعطيل الرخصة القديمة
            oldLicense.IsActive = false;
            oldLicense.Update();


            // 8) تعبئة كنترول معلومات الطلب
            ctrlApplictionInfoForLicenseReplacement1.LoadApplicationInfo(
                newApp.ApplicationID,
                newApp.ApplicationDate,
                newApp.PaidFees,
                oldLicense.LicenseID,
                newLicense.LicenseID,
                clsGlobal.CurrentUser.UserName
            );

            // 9) عرض الرخصة الجديدة في كنترول معلومات الرخصة
            ctrlDriverLicenseInfo1.LoadLicenseInfo(newLicense.LicenseID);

            MessageBox.Show("Replacement License Issued Successfully!");


        }

        private void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int licenseID = ctrlDriverLicenseInfo1.LicenseID;

            if (licenseID <= 0)
            {
                MessageBox.Show("No license selected.");
                return;
            }

            clsLicense license = clsLicense.Find(licenseID);
            clsDriver driver = clsDriver.Find(license.DriverID);

            if (license == null)
            {
                MessageBox.Show("License not found.");
                return;
            }

            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(driver.PersonID);
            frm.ShowDialog();


        }

        private void lnkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int licenseID = ctrlDriverLicenseInfo1.LicenseID;

            if (licenseID <= 0)
            {
                MessageBox.Show("No license selected.");
                return;
            }

            frmShowLicense frm = new frmShowLicense(licenseID);
            frm.ShowDialog();



        }
    }
}
