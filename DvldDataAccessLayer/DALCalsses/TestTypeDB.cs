using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DvldDataAccessLayer.DALCalsses
{
    public class TestTypeDB
    {

        public static decimal GetFeesByTestTypeID(int testTypeID)
        {
            string query = "SELECT TestTypeFees FROM TestTypes WHERE TestTypeID = @ID";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", testTypeID);

            decimal fees = 0;

            try
            {
                connection.Open();
                fees = (decimal)command.ExecuteScalar();
            }catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }

            return fees;
        }

        public static decimal GetRetakeFeesByTestTypeID(int testTypeID)
        {
            string query = "SELECT RetakeFees FROM TestTypes WHERE TestTypeID = @ID";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", testTypeID);

            decimal fees = 0;

            try
            {
                connection.Open();
                fees = (decimal)command.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }

            return fees;
        }


    }
}
