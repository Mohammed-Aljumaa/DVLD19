using System;
using System.Data;
using System.Data.SqlClient;


namespace DvldDataAccessLayer
{
    public class CountryDB
    {

        static public DataTable GetAllCountry()
        {
            DataTable dtCountry = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = "SELECT*FROM Countries";
            SqlCommand command = new SqlCommand(qury, connection);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtCountry.Load(Reader);
                }
                Reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }

            return dtCountry;

        }



        static public bool GetCountryInfoByID(ref string CountryName, int CountryID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = "SELECT * FROM Countries WHERE CountryID=@CountryID";
            SqlCommand command = new SqlCommand(qury, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);
            bool IsFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    CountryName = Convert.ToString((reader)["CountryName"]);
                    



                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        static public bool GetCountryInfoByName(string CountryName, ref int CountryID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = "SELECT * FROM Countries WHERE CountryName=@CountryName";
            SqlCommand command = new SqlCommand(qury, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);
            bool IsFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    CountryID = Convert.ToInt32((reader)["CountryID"]);
                  
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }



    }
}
