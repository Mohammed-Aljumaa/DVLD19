using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DvldDataAccessLayer;

namespace DvldDataAccessLayer.DALCalsses
{
    public class LocalDrivingLicenseApplicationDB
    {

        public static bool GetDrivingLicenseApplicationInfo(int localAppID,ref int applicationID,ref int licenseClassID,ref string className,ref int passedTests)
        {
            bool found = false;

            string query = @"
        SELECT 
            L.ApplicationID,
            L.LicenseClassID,
            LC.ClassName,
            (
                SELECT COUNT(*)
                FROM Tests T
                JOIN TestAppointments TA 
                    ON T.TestAppointmentID = TA.TestAppointmentID
                WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID
                  AND T.TestResult = 1
            ) AS PassedTests
        FROM LocalDrivingLicenseApplications L
        JOIN LicenseClasses LC ON L.LicenseClassID = LC.LicenseClassID
        WHERE L.LocalDrivingLicenseApplicationID = @LocalAppID;
    ";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalAppID", localAppID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    applicationID = (int)reader["ApplicationID"];
                    licenseClassID = (int)reader["LicenseClassID"];
                    className = (string)reader["ClassName"];
                    passedTests = (int)reader["PassedTests"];

                    found = true;
                }

                reader.Close();
            }catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return found;
        }

        public static int GetLocalAppIDByApplicationID(int applicationID)
        {
            int localAppID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT LocalDrivingLicenseApplicationID 
                     FROM LocalDrivingLicenseApplications 
                     WHERE ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    localAppID = Convert.ToInt32(result);
            }
            finally
            {
                conn.Close();
            }

            return localAppID;
        }




        public static bool Delete(int localAppID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"DELETE FROM LocalDrivingLicenseApplications 
                     WHERE LocalDrivingLicenseApplicationID = @LocalAppID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalAppID", localAppID);

            int rows = 0;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

            return (rows > 0);
        }

    }
}
