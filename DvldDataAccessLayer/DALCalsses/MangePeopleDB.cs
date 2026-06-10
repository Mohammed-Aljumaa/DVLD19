using System;
using System.Data;
using System.Data.SqlClient;

namespace DvldDataAccessLayer
{
    public class MangePeopleDB
    {


        static public DataTable GetAllPeople()
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = @"SELECT 
    People.PersonID,
People.NationalNo,
    People.FirstName,
    People.SecondName,
    People.ThirdName,
    People.LastName,
    People.DateOfBirth,
    CASE
        WHEN People.Gendor = 0 THEN 'Male'
        ELSE 'Female'
    END AS GendorCaption,
    People.Address,
    People.Phone,
    People.Email,
    Countries.CountryName AS NationalityName,
    People.ImagePath
FROM 
    People
INNER JOIN 
    Countries ON People.NationalityCountryID = Countries.CountryID
ORDER BY 
    People.FirstName;";
            SqlCommand command = new SqlCommand(qury, connection);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPeople.Load(Reader);
                }
                Reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }

            return dtPeople;

        }


        static public bool GetPeopleInfoByID(ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref string Address, ref string Phone, ref string Email,
          ref DateTime DateOfBirth, ref int NationalityCountryID, ref byte Gendor, ref string ImagePath)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = "SELECT* FROM People WHERE PersonID  = @PersonID";

            SqlCommand command = new SqlCommand(qury, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            bool IsFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    IsFound = true;

                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    NationalNo = Convert.ToString(reader["NationalNo"]);
                    FirstName = Convert.ToString(reader["FirstName"]);
                    SecondName = Convert.ToString(reader["SecondName"]);
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = Convert.ToString(reader["ThirdName"]);
                    }
                    else
                    {
                        ThirdName = "";
                    }
                    LastName = Convert.ToString(reader["LastName"]);
                    Address = Convert.ToString(reader["Address"]);
                    Phone = Convert.ToString(reader["Phone"]);
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = Convert.ToString(reader["Email"]);
                    }
                    else
                    {
                        Email = "";
                    }
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    Gendor = Convert.ToByte(reader["Gendor"]);
                    if (reader["ImagePath"] != DBNull.Value)
                    {

                        ImagePath = Convert.ToString(reader["ImagePath"]);
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    return IsFound;
                }
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

         static public bool GetPeopleInfoByNationalNo(ref string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref string Address, ref string Phone, ref string Email,
          ref DateTime DateOfBirth, ref int NationalityCountryID, ref byte Gendor, ref string ImagePath)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = "SELECT* FROM People WHERE NationalNo  = @NationalNo";

            SqlCommand command = new SqlCommand(qury, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            bool IsFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    IsFound = true;

                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    NationalNo = Convert.ToString(reader["NationalNo"]);
                    FirstName = Convert.ToString(reader["FirstName"]);
                    SecondName = Convert.ToString(reader["SecondName"]);
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = Convert.ToString(reader["ThirdName"]);
                    }
                    else
                    {
                        ThirdName = "";
                    }
                    LastName = Convert.ToString(reader["LastName"]);
                    Address = Convert.ToString(reader["Address"]);
                    Phone = Convert.ToString(reader["Phone"]);
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = Convert.ToString(reader["Email"]);
                    }
                    else
                    {
                        Email = "";
                    }
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    Gendor = Convert.ToByte(reader["Gendor"]);
                    if (reader["ImagePath"] != DBNull.Value)
                    {

                        ImagePath = Convert.ToString(reader["ImagePath"]);
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                   return IsFound;
                }
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



        static public int AddNewPerson( string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName,string Address,string Phone, string Email,
            DateTime DateOfBirth, int NationalityCountryID, byte Gendor,
    string ImagePath)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = @"INSERT INTO People (NationalNo,FirstName,SecondName,ThirdName,LastName,Address,Phone,Email,DateOfBirth,NationalityCountryID,Gendor,ImagePath)
VALUES (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@Address,@Phone,@Email,@DateOfBirth,@NationalityCountryID,@Gendor,@ImagePath)SELECT SCOPE_IDENTITY();";

            int PersonID1 = -1;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "")
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
            {

                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            }
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email != "")
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            if (ImagePath != "")
            {

                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            }

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertID))
                {
                    PersonID1 = InsertID;
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return PersonID1;
        }


        static public bool UpdatePerson(int PersonID,string NationalNo,string FirstName,string SecondName,string ThirdName,string LastName,
string Address,string Phone,string Email,DateTime DateOfBirth,int NationalityCountryID,byte Gendor,string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            int RowsAffected = 0;

            string query = @"UPDATE People
        SET 
            NationalNo = @NationalNo,
            FirstName = @FirstName,
            SecondName = @SecondName,
            ThirdName = @ThirdName,
            LastName = @LastName,
            Address = @Address,
            Phone = @Phone,
            Email = @Email,
            DateOfBirth = @DateOfBirth,
            NationalityCountryID = @NationalityCountryID,
            Gendor = @Gendor,
            ImagePath = @ImagePath
        WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@Gendor", Gendor);

            if (!string.IsNullOrWhiteSpace(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


            if (!string.IsNullOrWhiteSpace(Email))
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);



            if (!string.IsNullOrWhiteSpace(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }




        static public bool IsNationalNoExist(string NationalNo)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "SELECT Found=1 FROM People where NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);           
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();



            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
         static public bool IsNationalNoUsedByOther(string NationalNo,int CurrentPersonID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "SELECT Found=1 FROM People where NationalNo=@NationalNo AND personID<>@PersonID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@personID", CurrentPersonID);
           
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();



            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }


         static public bool IsPersonIDExist(int currentPersonID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "SELECT Found=1 FROM People where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

          
            command.Parameters.AddWithValue("@PersonID", currentPersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();



            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }




        static public bool DeletePerson(int ID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            int RowsAffected = 0;
            string query = @"Delete From People where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }


    }
}



            
            


