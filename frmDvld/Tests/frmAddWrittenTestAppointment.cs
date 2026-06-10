using DvldBusinessLayer.BLLClasses;
using System;
using System.Data;
using System.Windows.Forms;

namespace frmDvld.Tests
{
    public partial class frmAddWrittenTestAppointment : Form
    {
        private int _AppointmentID;
        private int _LocalAppID;
        private bool _EditMode;
        private clsLocalDrivingLicenseApplication _localApp;

        public frmAddWrittenTestAppointment(int appointmentID, clsLocalDrivingLicenseApplication localApp, bool editMode)
        {
            InitializeComponent();

            _AppointmentID = appointmentID;
            _localApp = localApp;
            _LocalAppID = localApp.LocalAppID;
            _EditMode = editMode;
        }

        // ============================================================
        // 1) هل يوجد فحص سابق Locked ؟
        // ============================================================
        public static bool HasPreviousLockedTest(int localAppID)
        {
            DataTable dt = clsTestAppointment.GetAppointmentsByLocalAppID(localAppID,2);

            foreach (DataRow row in dt.Rows)
            {
                if (row["IsLocked"] != DBNull.Value && (bool)row["IsLocked"] == true)
                    return true;
            }

            return false;
        }
        


        // ============================================================
        // 2) تحميل البيانات عند فتح الفورم
        // ============================================================

        private void frmAddWrittenTestAppointment_Load_1(object sender, EventArgs e)
        {
            var app = clsAppliction.Find(_localApp.ApplicationID);

            // وضع الإضافة
            if (_AppointmentID == -1)
            {
                lblDLAPPID.Text = _localApp.LocalAppID.ToString();
                lblDclass.Text = _localApp.ClassName;
                lblName.Text = app.ApplicantFullName;

                // عدد المحاولات
                int trialCount = clsTestAppointment.GetTrialCount(_localApp.LocalAppID,2);
                lblTrial.Text = trialCount.ToString();

                // رسوم فحص Written Test
                decimal testFees = clsTestType.GetFeesByTestTypeID(2); // ← رقم 2 للـ Written Test
                lblFees.Text = testFees.ToString();

                // منطق إعادة الفحص
                if (!HasPreviousLockedTest(_localApp.LocalAppID) && _localApp.PassedTests == 1)
                {
                    gbRetakeInfo.Enabled = true;

                    decimal retakeFees = 5;
                    lblRAppFees.Text = retakeFees.ToString();
                    lblTotalFees.Text = (testFees + retakeFees).ToString();
                }
                else
                {
                    gbRetakeInfo.Enabled = false;
                    lblRAppFees.Text = "0";
                    lblTotalFees.Text = testFees.ToString();
                }

                return;
            }

            // ============================================================
            // وضع التعديل
            // ============================================================
            var appointment = clsTestAppointment.Find(_AppointmentID);

            lblDLAPPID.Text = _localApp.LocalAppID.ToString();
            lblDclass.Text = _localApp.ClassName;
            lblName.Text = app.ApplicantFullName;

            int trialCount2 = clsTestAppointment.GetTrialCount(_LocalAppID,2);
            lblTrial.Text = trialCount2.ToString();

            dtpDate.Value = appointment.AppointmentDate;
            lblTotalFees.Text = appointment.PaidFees.ToString();

            decimal testFees2 = clsTestType.GetFeesByTestTypeID(2);
            lblFees.Text = testFees2.ToString();

            if (!HasPreviousLockedTest(_localApp.LocalAppID) && _localApp.PassedTests == 1)
            {
                gbRetakeInfo.Enabled = false;
                lblRAppFees.Text = "0";
                lblTotalFees.Text = testFees2.ToString();
            }
            else
            {
                gbRetakeInfo.Enabled = true;
                decimal retakeFees = 5;
                lblRAppFees.Text = retakeFees.ToString();
                lblTotalFees.Text = (testFees2 + retakeFees).ToString();
            }
        }
        // ============================================================
        // 3) زر الحفظ
        // ============================================================

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            clsTestAppointment appointment;

            if (_AppointmentID == -1)
            {
                // 1) إذا الشخص لم يجتز Vision → ممنوع
                if (_localApp.PassedTests < 1)
                {
                    MessageBox.Show(
                        "Not Allowed\nYou must pass the Vision Test before scheduling the Written Test.",
                        "Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

                    return;
                }

                // 2) إذا الشخص اجتاز Written → ممنوع
                if (_localApp.PassedTests >= 2)
                {
                    MessageBox.Show(
                        "Not Allowed\nThis person already passed the Written Test before.",
                        "Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

                    return;
                }

                // 3) إذا لديه موعد غير مقفل → ممنوع
                if (clsTestAppointment.HasActiveAppointment(_LocalAppID,2))
                {
                    MessageBox.Show("Cannot add a new appointment. An active one already exists.");
                    return;
                }

                // 4) إنشاء موعد جديد
                appointment = new clsTestAppointment();
                appointment.TestAppointmentID = -1;
                appointment.LocalDrivingLicenseApplicationID = _LocalAppID;
                appointment.TestTypeID = 2;

            }
            else
            {
                appointment = clsTestAppointment.Find(_AppointmentID);
            }

            appointment.AppointmentDate = dtpDate.Value;
            appointment.PaidFees = Convert.ToDecimal(lblTotalFees.Text);

            if (appointment.Save())
            {
                MessageBox.Show("The appointment has been saved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error saving appointment.");
            }

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
