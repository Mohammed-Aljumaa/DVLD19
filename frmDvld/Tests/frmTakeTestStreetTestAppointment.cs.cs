using DvldBusinessLayer.BLLClasses;
using System;
using System.Data;
using System.Windows.Forms;

namespace frmDvld.Tests
{
    public partial class frmTakeTestStreetTestAppointment : Form
    {
        private int _AppointmentID;
        private clsTestAppointment _appointment;
        private clsLocalDrivingLicenseApplication _localApp;
        private clsAppliction _app;

        public frmTakeTestStreetTestAppointment(int appointmentID)
        {
            InitializeComponent();
            _AppointmentID = appointmentID;
        }

        
        private void frmTakeTestStreetTestAppointment_Load_1(object sender, EventArgs e)
        {
            // تحميل الموعد
            _appointment = clsTestAppointment.Find(_AppointmentID);

            // تحميل الطلب المحلي
            _localApp = clsLocalDrivingLicenseApplication.Find(_appointment.LocalDrivingLicenseApplicationID);

            // تحميل الطلب العام
            _app = clsAppliction.Find(_localApp.ApplicationID);

            // تعبئة البيانات
            lblDLAPPID.Text = _localApp.LocalAppID.ToString();
            lblDclass.Text = _localApp.ClassName;
            lblName.Text = _app.ApplicantFullName;

            lblTrial.Text = clsTestAppointment.GetTrialCount(_localApp.LocalAppID, 3).ToString();
            lblFees.Text = _appointment.PaidFees.ToString();
            dtpDate.Value = _appointment.AppointmentDate;
        }

      
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            bool result = rbPass.Checked;

            // 1) إنشاء Test جديد وربطه بالموعد
            clsTest test = new clsTest();
            test.TestAppointmentID = _appointment.TestAppointmentID;
            test.TestResult = result;
            test.Notes = txtNotes.Text;
            test.CreatedByUserID = 1; // ثابت حالياً

            if (!test.Save())
            {
                MessageBox.Show("Error saving test result!");
                return;
            }

            // 2) قفل الموعد
            _appointment.IsLocked = true;
            _appointment.Save();

            // 3) تحديث PassedTests إذا نجح
            if (result)
            {
                _localApp.PassedTests++;
                // إذا عندك Save() في clsLocalDrivingLicenseApplication ضيفه
            }

            MessageBox.Show("Data Saved Successfully");
            this.Close();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
