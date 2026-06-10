using DvldBusinessLayer.BLLClasses;
using frmDvld.LoginScreens.ClaassLoginScreen;
using System;
using System.Windows.Forms;

namespace frmDvld.Licenses.frmLicense
{
    public partial class frmReleaseDetainedLicense : Form
    {
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();

            // ربط حدث البحث
            ctrlLicenseFilter1.OnSearch += ctrlLicenseFilter1_OnSearch;
        }
        
        // ============================================================
        // تحميل معلومات الرخصة
        // ============================================================
        private void LoadLicenseInfo(int licenseID)
        {
            clsLicense license = clsLicense.Find(licenseID);

            if (license == null)
            {
                MessageBox.Show("License not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlDriverLicenseInfo1.LoadLicenseInfo(licenseID);

            // إذا الرخصة غير محجوزة → لا يمكن فك الحجز
            if (!clsDetainedLicense.IsLicenseDetained(licenseID))
            {
                MessageBox.Show("This license is not detained.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrlReleaseDetainInfo1.Clear();
                return;
            }

            // جلب detainID
            int detainID = clsDetainedLicense.GetDetainIDByLicenseID(licenseID);

            if (detainID <= 0)
            {
                MessageBox.Show("Detain record not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            decimal applicationFees =clsAppliction.GetApplictionFees(6) ;

            // تعبئة الكنترول
            ctrlReleaseDetainInfo1.LoadReleaseInfo(detainID, applicationFees);
        }

        // ============================================================
        // حدث البحث من ctrlLicenseFilter
        // ============================================================
        private void ctrlLicenseFilter1_OnSearch(int licenseID)
        {
            LoadLicenseInfo(licenseID);
        }


        // ============================================================
        // زر الإغلاق
        // ============================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnDetain_Click(object sender, EventArgs e)
        {

            int licenseID = ctrlDriverLicenseInfo1.LicenseID;

            if (licenseID <= 0)
            {
                MessageBox.Show("Please select a license first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // جلب detainID
            int detainID = clsDetainedLicense.GetDetainIDByLicenseID(licenseID);

            if (detainID <= 0)
            {
                MessageBox.Show("Detain record not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // إنشاء طلب جديد (Release Detained License)
            clsAppliction app = new clsAppliction();
            app.ApplicantPersonID = ctrlDriverLicenseInfo1.PersonID;
            app.ApplicationTypeID = 6; // Release Detained License
            app.ApplicationStatus = 1; // New
            app.ApplicationDate = DateTime.Now;
            app.LastStatusDate = DateTime.Now;
            app.PaidFees = ctrlReleaseDetainInfo1.GetApplicationFees();
            app.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            int applicationID = app.Saveint();

            if (applicationID <= 0)
            {
                MessageBox.Show("Failed to create release application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // تنفيذ عملية فك الحجز
            bool released = clsDetainedLicense.ReleaseLicense(detainID, clsGlobal.CurrentUser.UserID);

            if (!released)
            {
                MessageBox.Show("Failed to release license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("License released successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // إعادة تحميل المعلومات
            LoadLicenseInfo(licenseID);

        }

        private void lnkShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void lnkShowLicenseHistory_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
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
