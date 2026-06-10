using System;
using System.Data;
using System.Data.SqlClient;

namespace DvldDataAccessLayer.DALCalsses
{
    public class LicensesDB
    {

        public static string GetClassName(int classID)
        {
            string className = "Unknown";

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT ClassName 
                             FROM LicenseClasses 
                             WHERE LicenseClassID = @ID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", classID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    className = result.ToString();
            }
            finally
            {
                conn.Close();
            }

            return className;
        }


        // ============================================================
        // INSERT (بدون OldLicenseID)
        // ============================================================
        public static int Insert(int applicationID, int driverID, int licenseClass,
                                 DateTime issueDate, DateTime expirationDate,
                                 string notes, decimal paidFees, bool isActive,
                                 byte issueReason, int createdByUserID)
        {
            int LicenseID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"INSERT INTO Licenses
                        (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                         Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                        VALUES
                        (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate,
                         @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                        SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
            cmd.Parameters.AddWithValue("@DriverID", driverID);
            cmd.Parameters.AddWithValue("@LicenseClass", licenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", issueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            cmd.Parameters.AddWithValue("@Notes", notes ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@PaidFees", paidFees);
            cmd.Parameters.AddWithValue("@IsActive", isActive);
            cmd.Parameters.AddWithValue("@IssueReason", issueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                conn.Open();
                LicenseID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                LicenseID = -1;
            }
            finally
            {
                conn.Close();
            }
            return LicenseID;
        }


        // ============================================================
        // UPDATE (بدون OldLicenseID)
        // ============================================================
        public static bool Update(
            int licenseID,
            int applicationID,
            int driverID,
            int licenseClass,
            DateTime issueDate,
            DateTime expirationDate,
            string notes,
            decimal paidFees,
            bool isActive,
            byte issueReason,
            int createdByUserID)
        {
            string query = @"
                UPDATE Licenses
                SET 
                    ApplicationID = @ApplicationID,
                    DriverID = @DriverID,
                    LicenseClass = @LicenseClass,
                    IssueDate = @IssueDate,
                    ExpirationDate = @ExpirationDate,
                    Notes = @Notes,
                    PaidFees = @PaidFees,
                    IsActive = @IsActive,
                    IssueReason = @IssueReason,
                    CreatedByUserID = @CreatedByUserID
                WHERE LicenseID = @LicenseID";

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LicenseID", licenseID);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
            cmd.Parameters.AddWithValue("@DriverID", driverID);
            cmd.Parameters.AddWithValue("@LicenseClass", licenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", issueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            cmd.Parameters.AddWithValue("@Notes", (object)notes ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PaidFees", paidFees);
            cmd.Parameters.AddWithValue("@IsActive", isActive);
            cmd.Parameters.AddWithValue("@IssueReason", issueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return (rows > 0);
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }


        // ============================================================
        // GET LICENSE INFO (بدون OldLicenseID)
        // ============================================================
        public static bool GetLicenseInfo(
            int licenseID,
            ref int applicationID,
            ref int driverID,
            ref int licenseClass,
            ref DateTime issueDate,
            ref DateTime expirationDate,
            ref string notes,
            ref decimal paidFees,
            ref bool isActive,
            ref byte issueReason,
            ref int createdByUserID)
        {
            bool found = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenseClass = (int)reader["LicenseClass"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    notes = reader["Notes"] == DBNull.Value ? "" : (string)reader["Notes"];
                    paidFees = (decimal)reader["PaidFees"];
                    isActive = (bool)reader["IsActive"];
                    issueReason = (byte)reader["IssueReason"];
                    createdByUserID = (int)reader["CreatedByUserID"];

                    found = true;
                }

                reader.Close();
            }
            finally
            {
                conn.Close();
            }

            return found;
        }


        // ============================================================
        // باقي الدوال كما هي
        // ============================================================

        public static int GetLicenseIDByApplicationID(int applicationID)
        {
            int licenseID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT LicenseID FROM Licenses WHERE ApplicationID = @ApplicationID AND IsActive = 1";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    licenseID = Convert.ToInt32(result);
            }
            finally
            {
                conn.Close();
            }

            return licenseID;
        }


        public static DataTable GetLocalLicensesByPersonID(int personID)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"
                SELECT 
                    L.LicenseID,
                    L.ApplicationID,
                    C.ClassName,
                    L.IssueDate,
                    L.ExpirationDate,
                    L.IsActive
                FROM Licenses L
                INNER JOIN LicenseClasses C ON L.LicenseClass = C.LicenseClassID
                INNER JOIN Drivers D ON L.DriverID = D.DriverID
                WHERE D.PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", personID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

    }
}
