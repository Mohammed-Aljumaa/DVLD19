using System;
using System.Data;
using System.Data.SqlClient;

namespace DvldDataAccessLayer.DALCalsses
{
    public class TestDB
    {
        public static bool AddNewTest(int appointmentID, bool result, string notes, int userID)
        {
            string query = @"
                INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                VALUES (@AppID, @Result, @Notes, @UserID)
            ";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppID", appointmentID);
            command.Parameters.AddWithValue("@Result", result);
            command.Parameters.AddWithValue("@Notes", notes);
            command.Parameters.AddWithValue("@UserID", userID);

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
