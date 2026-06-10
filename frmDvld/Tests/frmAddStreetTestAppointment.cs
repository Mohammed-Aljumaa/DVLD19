using DvldBusinessLayer.BLLClasses;
using System;
using System.Data;
using System.Windows.Forms;

namespace frmDvld.Tests
{
    public partial class frmAddStreetTestAppointment : Form
    {
        private int _AppointmentID;
        private int _LocalAppID;
        private bool _EditMode;
        private clsLocalDrivingLicenseApplication _localApp;

        public frmAddStreetTestAppointment(int appointmentID, clsLocalDrivingLicenseApplication localApp, bool editMode)
        {
            InitializeComponent();

            _AppointmentID = appointmentID;
            _localApp = localApp;
            _LocalAppID = localApp.LocalAppID;
            _EditMode = editMode;
        }

        public static bool HasPreviousLockedTest(int localAppID)
        {
            DataTable dt = clsTestAppointment.GetAppointmentsByLocalAppID(localAppID, 3);

            foreach (DataRow row in dt.Rows)
            {
                if (row["IsLocked"] != DBNull.Value && (bool)row["IsLocked"])
                    return true;
            }

            return false;
        }

       
        


        private void frmAddStreetTestAppointment_Load_1(object sender, EventArgs e)
        {
            var app = clsAppliction.Find(_localApp.ApplicationID);

            if (_AppointmentID == -1)
            {
                lblDLAPPID.Text = _localApp.LocalAppID.ToString();
                lblDclass.Text = _localApp.ClassName;
                lblName.Text = app.ApplicantFullName;

                int trialCount = clsTestAppointment.GetTrialCount(_localApp.LocalAppID, 3);
                lblTrial.Text = trialCount.ToString();

                decimal testFees = clsTestType.GetFeesByTestTypeID(3);
                lblFees.Text = testFees.ToString();

                if (!HasPreviousLockedTest(_localApp.LocalAppID) && _localApp.PassedTests == 2)
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

            var appointment = clsTestAppointment.Find(_AppointmentID);

            lblDLAPPID.Text = _localApp.LocalAppID.ToString();
            lblDclass.Text = _localApp.ClassName;
            lblName.Text = app.ApplicantFullName;

            int trialCount2 = clsTestAppointment.GetTrialCount(_LocalAppID, 3);
            lblTrial.Text = trialCount2.ToString();

            dtpDate.Value = appointment.AppointmentDate;
            lblTotalFees.Text = appointment.PaidFees.ToString();

            decimal testFees2 = clsTestType.GetFeesByTestTypeID(3);
            lblFees.Text = testFees2.ToString();

            if (!HasPreviousLockedTest(_localApp.LocalAppID) && _localApp.PassedTests == 2)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTestAppointment appointment;

            if (_AppointmentID == -1)
            {
                if (_localApp.PassedTests < 2)
                {
                    MessageBox.Show(
                        "Not Allowed\nYou must pass Vision and Written tests before scheduling the Street Test.",
                        "Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    return;
                }

                if (_localApp.PassedTests >= 3)
                {
                    MessageBox.Show(
                        "Not Allowed\nThis person already passed the Street Test before.",
                        "Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    return;
                }

                if (clsTestAppointment.HasActiveAppointment(_LocalAppID, 3))
                {
                    MessageBox.Show("Cannot add a new appointment. An active one already exists.");
                    return;
                }

                appointment = new clsTestAppointment();
                appointment.TestAppointmentID = -1;
                appointment.LocalDrivingLicenseApplicationID = _LocalAppID;

                appointment.TestTypeID = 3;   // Street Test
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
