using DvldBusinessLayer.BLLClasses;
using System;
using System.Data;
using System.Windows.Forms;

namespace frmDvld.Appliction.frmAppliction
{
    public partial class frmScheduleVisionTest : Form
    {
        private int _LocalAppID;
        private clsLocalDrivingLicenseApplication _localApp;   // ← أضفنا هذا

        public frmScheduleVisionTest(int loadAppID)
        {
            InitializeComponent();
            _LocalAppID = loadAppID;
        }

        private void frmScheduleVisionTest_Load(object sender, EventArgs e)
        {
            // تحميل الطلب المحلي وتخزينه في المتغيّر العام
            _localApp = clsLocalDrivingLicenseApplication.Find(_LocalAppID);

            if (_localApp == null)
            {
                MessageBox.Show("لم يتم العثور على الطلب المحلي");
                this.Close();
                return;
            }

            // تحميل معلومات الطلب
            ctrlDrivingLicenseApplictiponInfo1.LoadInfo(_LocalAppID);
            ctrlApplictionBasicInfo1.LoadInfo(_localApp.ApplicationID);

            LoadAppointments();
        }

        private void LoadAppointments()
        {
            DataTable dt = clsTestAppointment.GetAppointmentsByLocalAppID(_LocalAppID,1);
            dgvAppointments.DataSource = dt;

            lblRecordCount.Text = dt.Rows.Count.ToString();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            // 1) إذا الشخص اجتاز الفحص → ممنوع إضافة موعد جديد
            if (_localApp.PassedTests >= 1)
            {
                MessageBox.Show(
                    "Not Allowed\nThis person already passed this test before, you can only retake failed test.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                return;
            }

            // 2) إذا لديه موعد فعّال → ممنوع إضافة موعد جديد
            if (clsTestAppointment.HasActiveAppointment(_LocalAppID,1))
            {
                MessageBox.Show("Cannot add a new appointment because an active one already exists.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 3) فتح فورم إضافة الموعد
            frmAddVisionTestAppointment frm =
                new frmAddVisionTestAppointment(-1, _localApp, false);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAppointments();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
                return;

            int appointmentID = Convert.ToInt32(
                dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value);

            frmAddVisionTestAppointment frm =
                new frmAddVisionTestAppointment(appointmentID, _localApp, true);

            frm.ShowDialog();
            LoadAppointments();
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
                return;

            int appointmentID = Convert.ToInt32(
                dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value);

            frmTakeTestVisionTestAppointment frm =
                new frmTakeTestVisionTestAppointment(appointmentID);

            frm.ShowDialog();
            LoadAppointments();
        }
    }
}
