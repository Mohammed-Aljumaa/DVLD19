using System;
using System.Data;
using System.Data.SqlClient;

namespace DvldDataAccessLayer.DALCalsses
{
    public class DetainedLicensesDB
    {

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"
        SELECT 
            DL.DetainID,
            DL.LicenseID,
            DL.DetainDate,
            DL.IsReleased,
            DL.FineFees,
            DL.ReleaseDate,
            P.NationalNo,
            P.FirstName + ' ' + P.SecondName + ' ' + P.LastName AS FullName,
            DL.ReleaseApplicationID
        FROM DetainedLicenses DL
        JOIN Licenses L ON DL.LicenseID = L.LicenseID
        JOIN Drivers D ON L.DriverID = D.DriverID
        JOIN People P ON D.PersonID = P.PersonID
        ORDER BY DL.DetainID DESC;
    ";

            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                // ممكن تضيف لوج هنا لو بدك
            }
            finally
            {
                con.Close();
            }

            return dt;
        }




        // ============================================================
        // 1) Check if license is detained
        // ============================================================
        public static bool IsLicenseDetained(int licenseID)
        {
            bool isDetained = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT IsReleased 
                             FROM DetainedLicenses 
                             WHERE LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    bool isReleased = Convert.ToBoolean(result);
                    isDetained = !isReleased; // إذا ما تم الإفراج → محجوز
                }
            }
            finally
            {
                conn.Close();
            }

            return isDetained;
        }


        // ============================================================
        // 2) Detain License (Insert)
        // ============================================================
        public static int DetainLicense(int licenseID, decimal fineFees, int createdByUserID)
        {
            int detainID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses
                            (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                             VALUES
                            (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LicenseID", licenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@FineFees", fineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                conn.Open();
                detainID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                detainID = -1;
            }
            finally
            {
                conn.Close();
            }

            return detainID;
        }


        // ============================================================
        // 3) Release License (Update)
        // ============================================================
        public static bool ReleaseLicense(int detainID, int releasedByUserID)
        {
            bool result = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"UPDATE DetainedLicenses
                             SET IsReleased = 1,
                                 ReleaseDate = @ReleaseDate,
                                 ReleasedByUserID = @ReleasedByUserID
                             WHERE DetainID = @DetainID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@DetainID", detainID);
            cmd.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }


        // ============================================================
        // 4) Get Detain Info (Find)
        // ============================================================
        public static bool GetDetainInfo(
            int detainID,
            ref int licenseID,
            ref DateTime detainDate,
            ref decimal fineFees,
            ref int createdByUserID,
            ref bool isReleased,
            ref DateTime? releaseDate,
            ref int? releasedByUserID)
        {
            bool found = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DetainID", detainID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    licenseID = (int)reader["LicenseID"];
                    detainDate = (DateTime)reader["DetainDate"];
                    fineFees = (decimal)reader["FineFees"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isReleased = (bool)reader["IsReleased"];

                    releaseDate = reader["ReleaseDate"] == DBNull.Value ? null : (DateTime?)reader["ReleaseDate"];
                    releasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? null : (int?)reader["ReleasedByUserID"];

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
        public static int GetDetainIDByLicenseID(int licenseID)
        {
            int detainID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT DetainID 
                     FROM DetainedLicenses 
                     WHERE LicenseID = @LicenseID AND IsReleased = 0";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    detainID = Convert.ToInt32(result);
            }
            finally
            {
                conn.Close();
            }

            return detainID;
        }

    }
}
