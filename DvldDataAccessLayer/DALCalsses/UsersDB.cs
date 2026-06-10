using System;
using System.Data;
using System.Data.SqlClient;


namespace DvldDataAccessLayer.DALCalsses
{
    public class UsersDB
    {

        static public DataTable GetAllUsers()
        {

            DataTable dtUsers=new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = @"SELECT        
Users.UserID,
Users.PersonID,
CONCAT(People.FirstName, ' ', People.SecondName, ' ', People.ThirdName, ' ', People.LastName)AS FullName,
Users.UserName,
Users.IsActive
FROM Users INNER JOIN
                         People ON Users.PersonID = People.PersonID;;";

            SqlCommand command=new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader =command.ExecuteReader();
                if(reader.HasRows)
                {
                    dtUsers.Load(reader);
                }
                reader.Close();
            }catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return dtUsers;


        }

        static public int AddNewUser(int PersonID,string UserName,string Password,bool IsActive)
        {
            int userID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"
INSERT INTO Users(PersonID, UserName, Password, IsActive)
VALUES(@PersonID, @UserName, @Password, @IsActive);

SELECT SCOPE_IDENTITY();
";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                Object Result =command.ExecuteScalar();
                if (Result != null&&int.TryParse(Result.ToString(),out int InsertID))
                    { 
                    
                    userID = InsertID;
                }



            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return userID;

        }

        static public bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            int RowsAffected = 0;


            string query = @"
UPDATE Users
SET 
    UserName = @UserName,
    Password = @Password,
    IsActive = @IsActive
WHERE UserID = @UserID;
";

            SqlCommand command= new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {

                connection.Open();
                RowsAffected=command.ExecuteNonQuery();


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

        static public bool DeleteUser(int UserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            int RowsAffected = 0;


            string query = "DELETE FROM Users WHERE UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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
        static public bool FindUserByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection=new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select *FROM Users Where PersonID=@PersonID;";

            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader=command.ExecuteReader();
                if(reader.Read())
                {

                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    UserName = Convert.ToString(reader["Username"]);
                    Password = Convert.ToString(reader["Password"]);
                    UserID = Convert.ToInt32(reader["UserID"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    IsFound = true;

                }
                else
                {
                    IsFound = false;
                }
                reader.Close();

            }catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return IsFound;



        }
        public static bool FindUserByUserID( int UserID,ref string UserName,ref string Password,ref bool IsActive,ref int personID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "SELECT *FROM Users WHERE UserID=@UserID ;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    personID = Convert.ToInt32(reader["PersonID"]);

                    UserName = Convert.ToString(reader["Username"]);
                    Password = Convert.ToString(reader["Password"]);
                    UserID = Convert.ToInt32(reader["UserID"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    IsFound = true;


                }
                else
                {
                    IsFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally { connection.Close(); }
            return IsFound;




        }
        public static bool GetUserInfoByPersonID( string UserName,string Password,
            ref int UserID, ref int personID , ref bool IsActive)
        {

            bool IsFound=false;
            SqlConnection connection=new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "SELECT *FROM Users WHERE Username=@Username AND Password=@Password;";

            SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Username", UserName);
                command.Parameters.AddWithValue("@Password", Password);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {

                    personID = Convert.ToInt32(reader["PersonID"]);
                    UserName = Convert.ToString(reader["Username"]);
                    Password = Convert.ToString(reader["Password"]);
                    UserID = Convert.ToInt32(reader["UserID"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    IsFound=true;
                }
                else
                {
                    IsFound=false;
                }
                reader.Close();


            }catch (Exception ex)
            {
                IsFound = false;
            }
            finally { connection.Close(); }
            return IsFound;

        }

        static public bool IsUserNameExists(string UserName)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = "SELECT  Found=1 FROM users WHERE UserName=@UserName";


            SqlCommand command = new SqlCommand(qury, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
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
         static public bool IsPasswordExists(string Password)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = "SELECT  Found=1 FROM users WHERE Password=@Password";


            SqlCommand command = new SqlCommand(qury, connection);

            command.Parameters.AddWithValue("@Password", Password);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
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

        static public bool IsUserActives(string UserName)
        {

            bool IsActive = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = "SELECT IsActive FROM Users WHERE UserName=@UserName";


            SqlCommand command = new SqlCommand(qury, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                if(Result != null&&Result!=DBNull.Value)
                {
                    IsActive = Convert.ToBoolean(Result);
                }
            }catch (Exception ex)
            {
                IsActive=false;
            }
            finally
            {
                connection.Close() ;
            }
            return IsActive;
        }


        static public bool  checkPasssword(int UserID,string Password)
        {


            bool IsCorrect=false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString) ;

            string qury = @"SELECT Found =1 FROM users
Where UserID=@UserID AND Password =@Password";

            SqlCommand command = new SqlCommand(qury, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open() ;
                SqlDataReader Reader=command.ExecuteReader() ;
                IsCorrect = Reader.HasRows;
                Reader.Close();


            }catch (Exception ex)
            {
                IsCorrect=false;
            }
            finally
            {
                connection.Close();
            }
            return IsCorrect;

        }

    }
}
