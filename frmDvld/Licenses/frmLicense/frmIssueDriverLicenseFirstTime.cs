using DvldBusinessLayer.BLLClasses;
using System;
using System.Windows.Forms;

namespace frmDvld.Licenses
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        private int _LocalAppID;
        private clsLocalDrivingLicenseApplication _localApp;
        private clsAppliction _app;

        public frmIssueDriverLicenseFirstTime(int localAppID)
        {
            InitializeComponent();
            _LocalAppID = localAppID;
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _localApp = clsLocalDrivingLicenseApplication.Find(_LocalAppID);

            if (_localApp == null)
            {
                MessageBox.Show("Local Application Not Found!");
                this.Close();
                return;
            }

            _app = clsAppliction.Find(_localApp.ApplicationID);

            // ✔ تصحيح اسم الكنترول
            ctrlDrivingLicenseApplictiponInfo1.LoadInfo(_LocalAppID);
            ctrlApplictionBasicInfo1.LoadInfo(_localApp.ApplicationID);

            if (_localApp.PassedTests < 3)
            {
                MessageBox.Show("You must pass all 3 tests before issuing the license.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                btnIssue.Enabled = false;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsLicense license = new clsLicense();

            license.ApplicationID = _localApp.ApplicationID;

            // ✔ تصحيح DriverID
            clsDriver driver = clsDriver.FindByPersonID(_app.ApplicantPersonID);

            if (driver == null)
            {
                driver = new clsDriver();
                driver.PersonID = _app.ApplicantPersonID;
                driver.CreatedByUserID = 1;
                driver.Save();
            }

            license.DriverID = driver.DriverID;

            license.LicenseClass = _localApp.LicenseClassID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(10);

            // ✔ txtNotes موجود وما فيه مشكلة
            license.Notes = txtNotes.Text;

            license.PaidFees = 15;
            license.IsActive = true;
            license.IssueReason = 1;
            license.CreatedByUserID = 1;

            int licenseID = license.Save();

            if (licenseID == -1)
            {
                MessageBox.Show("Error issuing license!");
                return;
            }

            // ✔ تحديث حالة الطلب
            _app.UpdateStatus(3);

            MessageBox.Show(
                $"License Issued Successfully with License ID = {licenseID}",
                "Succeeded",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
