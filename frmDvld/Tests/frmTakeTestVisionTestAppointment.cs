using DvldBusinessLayer.BLLClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmDvld.Appliction.frmAppliction
{
    public partial class frmTakeTestVisionTestAppointment : Form
    {

        private int _AppointmentID;
        private clsTestAppointment _appointment;
        private clsLocalDrivingLicenseApplication _localApp;
        private clsAppliction _app;

        public frmTakeTestVisionTestAppointment(int appointmentID)
        {
            InitializeComponent();
            _AppointmentID = appointmentID;
        }

        private void frmTakeTestVisionTestAppointment_Load(object sender, EventArgs e)
        {
            _appointment = clsTestAppointment.Find(_AppointmentID);

            _localApp = clsLocalDrivingLicenseApplication.Find(_appointment.LocalDrivingLicenseApplicationID);
            _app = clsAppliction.Find(_localApp.ApplicationID);

            lblDLAPPID.Text = _localApp.LocalAppID.ToString();
            lblDclass.Text = _localApp.ClassName;
            lblName.Text = _app.ApplicantFullName;

            lblTrial.Text = clsTestAppointment.GetTrialCount(_localApp.LocalAppID,1).ToString();
            lblFees.Text = _appointment.PaidFees.ToString();
            dtpDate.Value = _appointment.AppointmentDate;

            

        }

        private void btnSave_Click(object sender, EventArgs e)
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

            // 3) (اختياري) إذا عندك Save في clsLocalDrivingLicenseApplication
            // إذا ما عندك، خليه بس يزيد العدد بدون Save
            if (result)
            {
                _localApp.PassedTests++;
                // إذا ما عندك _localApp.Save() لا تكتبها
            }

            MessageBox.Show("Data Saved Successfully");
            this.Close();
        }
    }

}
    


