using System;
using System.Data;
using System.Data.SqlClient;

namespace DvldDataAccessLayer.DALCalsses
{
    public class DriverDB
    {
        public static int Insert(int personID, int createdByUserID)
        {
            int driverID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"INSERT INTO Drivers
                            (PersonID, CreatedByUserID, CreatedDate)
                            VALUES
                            (@PersonID, @CreatedByUserID, @CreatedDate);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            try
            {
                conn.Open();
                driverID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                driverID = -1;
            }
            finally
            {
                conn.Close();
            }

            return driverID;
        }

        public static int GetDriverIDByPersonID(int personID)
        {
            int driverID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT DriverID FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    driverID = Convert.ToInt32(result);
            }
            catch
            {
                driverID = -1;
            }
            finally
            {
                conn.Close();
            }

            return driverID;
        }

        public static DataTable GetAllDrivers()
        {
                DataTable dt = new DataTable();

                SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"
        SELECT 
            D.DriverID,
            D.PersonID,
            P.NationalNo,
            P.FirstName + ' ' + P.SecondName + ' ' + P.LastName AS FullName,
            D.CreatedDate
        FROM Drivers D
        JOIN People P ON D.PersonID = P.PersonID
        ORDER BY D.DriverID DESC;
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
                }
                finally
                {
                    con.Close();
                }

                return dt;
            }



            public static bool FindByDriverID(int driverID,
                                   ref int personID,
                                   ref DateTime createdDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = @"SELECT PersonID, CreatedDate
                     FROM Drivers
                     WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    personID = (int)reader["PersonID"];
                    createdDate = (DateTime)reader["CreatedDate"];
                }
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return isFound;
        }

    }
}
