using DvldBusinessLayer.BLLClasses;
using frmDvld.Licenses;
using frmDvld.Licenses.frmLicense;
using frmDvld.Tests;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace frmDvld.Appliction.frmAppliction
{
    public partial class frmManageAppliction : Form
    {
        public frmManageAppliction()
        {
            InitializeComponent();
        }

        // ============================================================
        // 1) دالة تجيب الـ LocalAppID من الصف المحدد
        // ============================================================
        private int GetSelectedLocalAppID()
        {
            if (dgvAllApplication.CurrentRow == null)
                return -1;

            return Convert.ToInt32(dgvAllApplication.CurrentRow.Cells["L.D.L.AppID"].Value);
        }

        // ============================================================
        // 2) دالة تجيب كائن الـ LocalApp كامل
        // ============================================================
        private clsLocalDrivingLicenseApplication GetSelectedLocalApp()
        {
            int id = GetSelectedLocalAppID();
            if (id == -1)
                return null;

            return clsLocalDrivingLicenseApplication.Find(id);
        }

        // ============================================================
        // 3) تحميل كل الطلبات
        // ============================================================
        private void _LoadLocalAppliction()
        {
            DataTable dt = clsAppliction.GetAllLocalApplications();

            dgvAllApplication.DataSource = dt;

            lblRecordCount.Text = dt.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;
        }

        private void frmManageAppliction_Load(object sender, EventArgs e)
        {
            _LoadLocalAppliction();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseAppliction frm = new frmNewLocalDrivingLicenseAppliction();
            frm.ShowDialog();
            _LoadLocalAppliction();
        }

        // ============================================================
        // 4) الفلترة
        // ============================================================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgvAllApplication.DataSource == null)
                return;

            if (cbFilterBy.Text == "None")
            {
                (dgvAllApplication.DataSource as DataTable).DefaultView.RowFilter = "";
                return;
            }

            string columnName = "";
            bool isNumericColumn = false;

            switch (cbFilterBy.Text)
            {
                case "L.D.L App":
                    columnName = "L.D.L.AppID";
                    isNumericColumn = true;
                    break;

                case "National No":
                    columnName = "National No";
                    break;

                case "Full Name":
                    columnName = "Full Name";
                    break;

                case "Status":
                    columnName = "Status";
                    break;
            }

            if (isNumericColumn)
            {
                (dgvAllApplication.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("Convert([{0}], 'System.String') LIKE '{1}%'", columnName, txtSearch.Text);
            }
            else
            {
                (dgvAllApplication.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("[{0}] LIKE '{1}%'", columnName, txtSearch.Text);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                txtSearch.Visible = false;
                txtSearch.Text = "";
                (dgvAllApplication.DataSource as DataTable).DefaultView.RowFilter = "";
            }
            else
            {
                txtSearch.Visible = true;
                txtSearch.Focus();
            }
        }

        // ============================================================
        // 5) فتح فورم Vision Test
        // ============================================================
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppID = GetSelectedLocalAppID();
            if (localAppID == -1) return;

            frmScheduleVisionTest frm = new frmScheduleVisionTest(localAppID);
            frm.ShowDialog();
        }

        // ============================================================
        // 6) فتح فورم Written Test
        // ============================================================
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppID = GetSelectedLocalAppID();
            if (localAppID == -1) return;

            
        }

        // ============================================================
        // 7) فتح فورم Street Test
        // ============================================================
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppID = GetSelectedLocalAppID();
            if (localAppID == -1) return;

            
        }

        // ============================================================
        // 8) منطق تفعيل/تعطيل الفحوصات حسب PassedTests
        // ============================================================
        private void cmsLocalDrivingLiesens_Opening(object sender, CancelEventArgs e)
        {
            var localApp = GetSelectedLocalApp();

            if (localApp == null)
            {
                e.Cancel = true;
                return;
            }

            // ==========================
            // 1) Show License
            // إذا ما خلّص 3 فحوصات → Disable
            // إذا خلّص 3 فحوصات → Enable
            // ==========================
            showLicenseToolStripMenuItem.Enabled = (localApp.PassedTests >= 3);

            // ==========================
            // 2) Issue Driving License (First Time)
            // نفس الشرط: فقط إذا خلّص 3 فحوصات
            // ==========================
            issuToolStripMenuItem.Enabled = (localApp.PassedTests >= 3);

            // ==========================
            // 3) Edit / Delete / Cancel
            // إذا خلّص 3 فحوصات → Disable
            // ==========================
            editeToolStripMenuItem.Enabled = !(localApp.PassedTests >= 3);
            deleteApplictionToolStripMenuItem.Enabled = !(localApp.PassedTests >= 3);
            cancelToolStripMenuItem.Enabled = !(localApp.PassedTests >= 3);

            // ==========================
            // كودك كما هو بدون أي تعديل
            // ==========================

            // أول شيء: نخفي أو نفعّل خيار إصدار الرخصة حسب PassedTests
            issuToolStripMenuItem.Enabled = (localApp.PassedTests >= 3);

            scheduleTestsToolStripMenuItem.Enabled = (!(localApp.PassedTests >= 3));

            // إذا خلّص 3 فحوصات → نوقف كل الفحوصات
            if (localApp.PassedTests >= 3)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                return;
            }

            // منطق الفحوصات حسب PassedTests
            if (localApp.PassedTests == 0)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = true;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if (localApp.PassedTests == 1)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if (localApp.PassedTests == 2)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
            }
        }



        private void scheduleWrittenTestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
                int localAppID = GetSelectedLocalAppID();
                if (localAppID == -1)
                    return;

                frmScheduleWrittenTest frm = new frmScheduleWrittenTest(localAppID);
                frm.ShowDialog();
            


        }

        private void scheduleStreetTestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            int localAppID = GetSelectedLocalAppID();
            if (localAppID == -1)
                return;

            frmScheduleStreetTest frm=new frmScheduleStreetTest(localAppID);
            frm.ShowDialog();

        }

        private void issuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppID = GetSelectedLocalAppID();
            if (localAppID == -1)
                return;
            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime(localAppID);
            frm.ShowDialog();

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var localApp = GetSelectedLocalApp();

            if (localApp == null)
                return;

            // نجيب LicenseID من جدول Licenses
            int licenseID = clsLicense.GetLicenseIDByApplicationID(localApp.ApplicationID);

            if (licenseID <= 0)
            {
                MessageBox.Show("This application has no issued license.");
                return;
            }

            frmShowLicense frm = new frmShowLicense(licenseID);
            frm.ShowDialog();
        }

        private void deleteApplictionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                var app = GetSelectedLocalApp();

                if (app == null)
                    return;

                if (MessageBox.Show("Are you sure you want to delete this application?",
                                    "Confirm Delete",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.No)
                    return;

                if (clsLocalDrivingLicenseApplication.Delete(app.LocalAppID))
                {
                    MessageBox.Show("Application deleted successfully.");
                       _LoadLocalAppliction(); // Refresh
                }
                else
                {
                    MessageBox.Show("Failed to delete application.");
                }
            

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                var app = GetSelectedLocalApp();
                if (app == null) return;

            var application = clsAppliction.Find(app.ApplicationID);
            int personID = application.ApplicantPersonID;

            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(personID);
                frm.ShowDialog();
        
        }

        private void showApplictionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var app = GetSelectedLocalApp();
            if (app == null) return;

            frmShowApplication frm = new frmShowApplication(app.LocalAppID);
            frm.ShowDialog();
        }
    }
}
