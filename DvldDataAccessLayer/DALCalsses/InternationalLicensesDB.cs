using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DvldDataAccessLayer.DALCalsses
{
    public class InternationalLicensesDB
    {


        public static int AddNew(int applicationID, int driverID, int localLicenseID,
                         DateTime issueDate, DateTime expirationDate, int createdByUserID)
        {
            
                int newID = -1;

                string query = @"
        INSERT INTO InternationalLicenses
        (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
        VALUES (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
        SELECT SCOPE_IDENTITY();";

                SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                cmd.Parameters.AddWithValue("@DriverID", driverID);
                cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", localLicenseID);
                cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                cmd.Parameters.AddWithValue("@IsActive", true);
                cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        newID = Convert.ToInt32(result);
                }
                finally
                {
                    conn.Close();
                }

                return newID;
            
        }


        public static DateTime GetApplicationDate(int InternationalLicenseApplicationID)
        {
            DateTime appDate = DateTime.Now;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT ApplicationDate
                 FROM Application
                 WHERE ApplicationID = @ID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", InternationalLicenseApplicationID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    appDate = Convert.ToDateTime(result);
            }
            finally
            {
                conn.Close();
            }

            return appDate;
        }

        public static DataTable GetInternationalLicensesByPersonID(int personID)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"
        SELECT 
            InternationalLicenseID,
            ApplicationID,
            IssueDate,
            ExpirationDate,
            IsActive
        FROM InternationalLicenses
        WHERE DriverID = (SELECT DriverID FROM Drivers WHERE PersonID = @PersonID)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", personID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }


        public static DataTable GetInternationalLicensesByDriverID(int driverID)
        {
            string query = @"SELECT * FROM InternationalLicenses WHERE DriverID = @DriverID";

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@DriverID", driverID);

            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }


        public static bool GetInternationalLicenseByID(int InternationalLicenseID,
    ref int ApplicationID,
    ref int DriverID,
    ref int LocalLicenseID,
    ref DateTime IssueDate,
    ref DateTime ExpirationDate,
    ref decimal Fees,
    ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @ID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", InternationalLicenseID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Fees = 0; // إذا ما عندك عمود Fees
                    IsActive = (bool)reader["IsActive"];
                }

                reader.Close();
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }



        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dtInternational = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT 
                    InternationalLicenseID,
                    ApplicationID,
                    DriverID,
                    IssuedUsingLocalLicenseID,
                    IssueDate,
                    ExpirationDate,
                    IsActive,
                    CreatedByUserID
                 FROM InternationalLicenses
                 ORDER BY InternationalLicenseID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtInternational.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // ممكن تعمل Log للخطأ
            }
            finally
            {
                connection.Close();
            }

            return dtInternational;
        }


    }
}
