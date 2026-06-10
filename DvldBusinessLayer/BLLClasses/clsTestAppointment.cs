using System;
using System.Data;
using DvldDataAccessLayer.DALCalsses;

namespace DvldBusinessLayer.BLLClasses
{
    public class clsTestAppointment
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }   // ← مهم جداً
        public int LocalDrivingLicenseApplicationID { get; set; }

        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsLocked { get; set; }

        public bool TestResult { get; set; }
        public string Notes { get; set; }

        // ============================================================
        // 1) Get Appointments By LocalAppID + TestTypeID
        // ============================================================
        public static DataTable GetAppointmentsByLocalAppID(int localAppID, int testTypeID)
        {
            return TestAppointmentDB.GetAppointmentsByLocalAppID(localAppID, testTypeID);
        }

        // ============================================================
        // 2) Check Active Appointment
        // ============================================================
        public static bool HasActiveAppointment(int localAppID, int testTypeID)
        {
            return TestAppointmentDB.HasActiveAppointment(localAppID, testTypeID);
        }

        // ============================================================
        // 3) Find Appointment
        // ============================================================
        public static clsTestAppointment Find(int appointmentID)
        {
            DataTable dt = TestAppointmentDB.GetAppointmentByID(appointmentID);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            clsTestAppointment appointment = new clsTestAppointment();

            appointment.TestAppointmentID = appointmentID;
            appointment.TestTypeID = Convert.ToInt32(row["TestTypeID"]);
            appointment.LocalDrivingLicenseApplicationID = Convert.ToInt32(row["LocalDrivingLicenseApplicationID"]);
            appointment.AppointmentDate = Convert.ToDateTime(row["AppointmentDate"]);
            appointment.PaidFees = Convert.ToDecimal(row["PaidFees"]);
            appointment.IsLocked = Convert.ToBoolean(row["IsLocked"]);

            return appointment;
        }

        // ============================================================
        // 4) Save (Add or Update)
        // ============================================================
        public bool Save()
        {
            if (TestAppointmentID == -1)
            {
                // إضافة جديدة
                return TestAppointmentDB.AddNewAppointment(
                    TestTypeID,
                    LocalDrivingLicenseApplicationID,
                    AppointmentDate,
                    PaidFees,
                    IsLocked
                );
            }
            else
            {
                // تعديل
                return TestAppointmentDB.UpdateAppointment(
                    TestAppointmentID,
                    AppointmentDate,
                    PaidFees,
                    IsLocked
                );
            }
        }

        // ============================================================
        // 5) Get Trial Count
        // ============================================================
        public static int GetTrialCount(int localAppID, int testTypeID)
        {
            DataTable dt = TestAppointmentDB.GetAppointmentsByLocalAppID(localAppID, testTypeID);

            if (dt == null)
                return 0;

            return dt.Rows.Count;
        }
    }
}
