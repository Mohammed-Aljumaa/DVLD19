using DvldBusinessLayer.BLLClasses;
using frmDvld.LoginScreens.ClaassLoginScreen;
using System;
using System.Windows.Forms;

namespace frmDvld.Licenses.frmLicense
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();

            // ربط حدث البحث من الفلتر
            ctrlLicenseFilter1.OnSearch += ctrlLicenseFilter1_OnSearch;
        }

        // ============================================================
        // تحميل معلومات الرخصة
        // ============================================================
        private void LoadLicenseInfo(int licenseID)
        {
            if (DesignMode) return;

            clsLicense license = clsLicense.Find(licenseID);

            if (license == null)
            {
                MessageBox.Show("License not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlDriverLicenseInfo1.LoadLicenseInfo(licenseID);

            // مسح معلومات الحجز السابقة
            ctrlDetainInfo1.Clear();
        }

        // ============================================================
        // حدث البحث من ctrlLicenseFilter
        // ============================================================
        private void ctrlLicenseFilter1_OnSearch(int licenseID)
        {
            LoadLicenseInfo(licenseID);
        }


        private void btnIssueReplacment_Click(object sender, EventArgs e)
        {
            int licenseID = ctrlDriverLicenseInfo1.LicenseID;

            if (licenseID <= 0)
            {
                MessageBox.Show("Please select a license first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔥 إعادة تحميل الرخصة من قاعدة البيانات مباشرة (حل مشكلة اللوجيك)
            clsLicense license = clsLicense.Find(licenseID);

            if (!license.IsActive)
            {
                MessageBox.Show("Cannot detain an inactive license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsDetainedLicense.IsLicenseDetained(licenseID))
            {
                MessageBox.Show("This license is already detained.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal fineFees = ctrlDetainInfo1.GetFineFees();

            if (fineFees <= 0)
            {
                MessageBox.Show("Please enter valid fine fees.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int detainID = clsDetainedLicense.DetainLicense(
                licenseID,
                fineFees,
                clsGlobal.CurrentUser.UserID
            );

            if (detainID == -1)
            {
                MessageBox.Show("Failed to detain license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlDetainInfo1.LoadDetainInfo(detainID);

            MessageBox.Show("License detained successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ⭐⭐⭐ الحل الحقيقي للمشكلتين: تحديث الرخصة من DB فوراً
            ctrlDriverLicenseInfo1.LoadLicenseInfo(licenseID);

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

            if (license == null)
            {
                MessageBox.Show("License not found.");
                return;
            }
            clsDriver driver=clsDriver.Find(license.DriverID);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
