using DvldBusinessLayer.BLLClasses;
using System;
using System.Data;
using System.Windows.Forms;

namespace frmDvld.Tests
{
    public partial class frmScheduleWrittenTest : Form
    {
        private int _LocalAppID;
        private clsLocalDrivingLicenseApplication _localApp;

        public frmScheduleWrittenTest(int loadAppID)
        {
            InitializeComponent();
            _LocalAppID = loadAppID;
        }

       

        private void LoadAppointments()
        {
            DataTable dt = clsTestAppointment.GetAppointmentsByLocalAppID(_LocalAppID,2);
            dgvAppointments.DataSource = dt;

            lblRecordCount.Text = dt.Rows.Count.ToString();
        }

   

        private void frmScheduleWrittenTest_Load_1(object sender, EventArgs e)
        { // تحميل الطلب المحلي
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

        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            // 1) إذا الشخص لم يجتز الـ Vision Test → ممنوع إضافة Written Test
            if (_localApp.PassedTests < 1)
            {
                MessageBox.Show(
                    "Not Allowed\nYou must pass the Vision Test before scheduling the Written Test.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                return;
            }

            // 2) إذا الشخص اجتاز الـ Written Test → ممنوع إضافة موعد جديد
            if (_localApp.PassedTests >= 2)
            {
                MessageBox.Show(
                    "Not Allowed\nThis person already passed the Written Test before.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                return;
            }

            // 3) إذا لديه موعد فعّال → ممنوع إضافة موعد جديد
            if (clsTestAppointment.HasActiveAppointment(_LocalAppID,2))
            {
                MessageBox.Show("Cannot add a new appointment because an active one already exists.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 4) فتح فورم إضافة الموعد
            frmAddWrittenTestAppointment frm =
                new frmAddWrittenTestAppointment(-1, _localApp, false);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAppointments();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
                return;

            int appointmentID = Convert.ToInt32(
                dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value);

            frmAddWrittenTestAppointment frm =
                new frmAddWrittenTestAppointment(appointmentID, _localApp, true);

            frm.ShowDialog();
            LoadAppointments();

        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
                return;

            int appointmentID = Convert.ToInt32(
                dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value);

            frmTakeWrittenTestAppointment frm =
                new frmTakeWrittenTestAppointment(appointmentID);

            frm.ShowDialog();
            LoadAppointments();
        }
    }
}
