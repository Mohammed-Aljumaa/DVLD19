using DvldBusinessLayer.BLLClasses;
using System;
using System.Data;
using System.Windows.Forms;

namespace frmDvld.Appliction.frmAppliction
{
    public partial class frmAddVisionTestAppointment : Form
    {
        private int _AppointmentID;
        private int _LocalAppID;
        private bool _EditMode;
        private clsLocalDrivingLicenseApplication _localApp;

        public frmAddVisionTestAppointment(int appointmentID, clsLocalDrivingLicenseApplication localApp, bool editMode)
        {
            InitializeComponent();

            _AppointmentID = appointmentID;
            _localApp = localApp;                     // ← تم إصلاحه
            _LocalAppID = localApp.LocalAppID;        // ← مهم
            _EditMode = editMode;
        }

        public static bool HasPreviousLockedTest(int localAppID)
        {
            DataTable dt = clsTestAppointment.GetAppointmentsByLocalAppID(localAppID,1);

            foreach (DataRow row in dt.Rows)
            {
                if (row["IsLocked"] != DBNull.Value && (bool)row["IsLocked"] == true)
                    return true;
            }

            return false;
        }

        private void frmAddVisionTestAppointment_Load(object sender, EventArgs e)
        {
            var app = clsAppliction.Find(_localApp.ApplicationID);

            if (_AppointmentID == -1)
            {
                lblDLAPPID.Text = _localApp.LocalAppID.ToString();
                lblDclass.Text = _localApp.ClassName;
                lblName.Text = app.ApplicantFullName;

                int trialCount = clsTestAppointment.GetTrialCount(_localApp.LocalAppID,1);
                lblTrial.Text = trialCount.ToString();

                decimal testFees = clsTestType.GetFeesByTestTypeID(1);
                lblFees.Text = testFees.ToString();

                if (!HasPreviousLockedTest(_localApp.LocalAppID) && _localApp.PassedTests == 0)
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

            // وضع التعديل
            var appointment = clsTestAppointment.Find(_AppointmentID);

            lblDLAPPID.Text = _localApp.LocalAppID.ToString();
            lblDclass.Text = _localApp.ClassName;
            lblName.Text = app.ApplicantFullName;

            int trialCount2 = clsTestAppointment.GetTrialCount(_LocalAppID,1);
            lblTrial.Text = trialCount2.ToString();

            dtpDate.Value = appointment.AppointmentDate;
            lblTotalFees.Text = appointment.PaidFees.ToString();

            decimal testFees2 = clsTestType.GetFeesByTestTypeID(1);
            lblFees.Text = testFees2.ToString();

            if (!HasPreviousLockedTest(_localApp.LocalAppID) && _localApp.PassedTests == 0)
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

        private void button1_Click(object sender, EventArgs e)
        {
            clsTestAppointment appointment;

            if (_AppointmentID == -1)
            {
                // 1) إذا الشخص ناجح → ممنوع إضافة موعد جديد
                if (_localApp.PassedTests >= 1)
                {
                    MessageBox.Show(
                        "Not Allowed\nThis person already passed this test before, you can only retake failed test.",
                        "Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

                    return;
                }

                // 2) إذا عنده موعد غير مقفل → ممنوع
                if (clsTestAppointment.HasActiveAppointment(_LocalAppID,1))
                {
                    MessageBox.Show("Cannot add a new appointment. An active one already exists.");
                    return;
                }

                // 3) إنشاء موعد جديد
                appointment = new clsTestAppointment();
                appointment.TestAppointmentID = -1;
                appointment.LocalDrivingLicenseApplicationID = _LocalAppID;


                appointment.TestTypeID = 1;   // Vision Test
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
