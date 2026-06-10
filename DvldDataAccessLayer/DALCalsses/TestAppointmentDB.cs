using System;
using System.Data;
using System.Data.SqlClient;

namespace DvldDataAccessLayer.DALCalsses
{
    public class TestAppointmentDB
    {
        // ============================================================
        // 1) Get Appointments By LocalAppID + TestTypeID
        // ============================================================
        public static DataTable GetAppointmentsByLocalAppID(int localAppID, int testTypeID)
        {
            string query = @"
                SELECT 
                    TestAppointmentID,
                    AppointmentDate,
                    PaidFees,
                    IsLocked
                FROM TestAppointments
                WHERE LocalDrivingLicenseApplicationID = @LocalAppID
                  AND TestTypeID = @TestTypeID
                ORDER BY AppointmentDate DESC;
            ";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalAppID", localAppID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);

            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                dt.Load(command.ExecuteReader());
            }
            catch (Exception)
            {
                // تجاهل الخطأ أو سجّله إذا بدك
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        // ============================================================
        // 2) Check Active Appointment (حسب نوع الفحص)
        // ============================================================
        public static bool HasActiveAppointment(int localAppID, int testTypeID)
        {
            string query = @"
                SELECT COUNT(*)
                FROM TestAppointments
                WHERE LocalDrivingLicenseApplicationID = @LocalAppID
                  AND TestTypeID = @TestTypeID
                  AND IsLocked = 0;
            ";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalAppID", localAppID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);

            int count = 0;

            try
            {
                connection.Open();
                count = (int)command.ExecuteScalar();
            }
            catch (Exception)
            {
                // تجاهل الخطأ
            }
            finally
            {
                connection.Close();
            }

            return count > 0;
        }

        // ============================================================
        // 3) Add New Appointment (مع TestTypeID الصحيح)
        // ============================================================
        public static bool AddNewAppointment(
            int testTypeID,
            int localAppID,
            DateTime date,
            decimal fees,
            bool isLocked
        )
        {
            string query = @"
                INSERT INTO TestAppointments
                (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
                VALUES (@TestTypeID, @LocalAppID, @Date, @Fees, @UserID, @IsLocked)
            ";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            int userID = 1; // ثابت حالياً

            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@LocalAppID", localAppID);
            command.Parameters.AddWithValue("@Date", date);
            command.Parameters.AddWithValue("@Fees", fees);
            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            try
            {
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            finally
            {
                connection.Close();
            }
        }

        // ============================================================
        // 4) Get Appointment By ID
        // ============================================================
        public static DataTable GetAppointmentByID(int appointmentID)
        {
            string query = @"SELECT * FROM TestAppointments WHERE TestAppointmentID = @AppointmentID";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentID", appointmentID);

            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                dt.Load(command.ExecuteReader());
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        // ============================================================
        // 5) Update Appointment
        // ============================================================
        public static bool UpdateAppointment(
            int testAppointmentID,
            DateTime date,
            decimal fees,
            bool isLocked
        )
        {
            string query = @"
                UPDATE TestAppointments
                SET AppointmentDate = @Date,
                    PaidFees = @Fees,
                    IsLocked = @IsLocked
                WHERE TestAppointmentID = @TestAppointmentID;
            ";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            command.Parameters.AddWithValue("@Date", date);
            command.Parameters.AddWithValue("@Fees", fees);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            try
            {
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
