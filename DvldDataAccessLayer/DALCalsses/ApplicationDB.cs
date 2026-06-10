using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldDataAccessLayer.DALCalsses
{
    public class ApplicationDB
    {

        public static DataTable GetAllApplictionTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = @"SELECT ApplicationTypeID, ApplicationTypeTitle, ApplicationFees 
                         FROM ApplicationTypes";

            SqlCommand command = new SqlCommand(qury, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;
        }
        public static DataTable GetAllLocalApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT 
    L.LocalDrivingLicenseApplicationID AS [L.D.L.AppID],
    LC.ClassName AS [Driving Class],
    P.NationalNo AS [National No],
    (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS [Full Name],
    A.ApplicationDate AS [Application Date],
    (
        SELECT COUNT(*) 
        FROM Tests T
        JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID
        WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID
          AND T.TestResult = 1
    ) AS [Passed Tests],
    CASE A.ApplicationStatus
        WHEN 1 THEN 'New'
        WHEN 2 THEN 'Completed'
        WHEN 3 THEN 'Cancelled'
    END AS [Status]
FROM LocalDrivingLicenseApplications L
JOIN Application A ON L.ApplicationID = A.ApplicationID
JOIN People P ON A.ApplicantPersonID = P.PersonID
JOIN LicenseClasses LC ON L.LicenseClassID = LC.LicenseClassID
ORDER BY L.LocalDrivingLicenseApplicationID DESC;

";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetApplicationBasicInfo(
   int applicationID,
   ref int applicantPersonID,
   ref string applicantFullName,
   ref DateTime applicationDate,
   ref byte applicationStatus,
   ref int applicationTypeID,
   ref string applicationTypeTitle,
   ref DateTime lastStatusDate,
   ref decimal paidFees,
   ref int createdByUserID,
   ref string createdByUserName)
        {
            bool found = false;

            string query = @"
        SELECT 
            A.ApplicantPersonID,
            P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName AS FullName,
            A.ApplicationDate,
            A.ApplicationStatus,
            A.ApplicationTypeID,
            AT.ApplicationTypeTitle,
            A.LastStatusDate,
            A.PaidFees,
            A.CreatedByUserID,
            U.UserName
        FROM Application A
        JOIN People P ON A.ApplicantPersonID = P.PersonID
        JOIN ApplicationTypes AT ON A.ApplicationTypeID = AT.ApplicationTypeID
        JOIN Users U ON A.CreatedByUserID = U.UserID
        WHERE A.ApplicationID = @ApplicationID;
    ";

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    applicantPersonID = (int)reader["ApplicantPersonID"];
                    applicantFullName = (string)reader["FullName"];
                    applicationDate = (DateTime)reader["ApplicationDate"];
                    applicationStatus = (byte)reader["ApplicationStatus"];
                    applicationTypeID = (int)reader["ApplicationTypeID"];
                    applicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    lastStatusDate = (DateTime)reader["LastStatusDate"];
                    paidFees = (decimal)reader["PaidFees"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    createdByUserName = (string)reader["UserName"];

                    found = true;
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return found;
        }

    

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
            }
            finally
            {
                connection.Close();
            }

            return found;
        }

        public static bool UpdateNameApplitionType(int ID, string Title)
        {
            bool isAffected = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = @"UPDATE ApplicationTypes
SET 
ApplicationTypeTitle=@Title
Where ApplicationTypeID=@ID;";

            SqlCommand command = new SqlCommand(qury, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    isAffected = true;
                }
            }
            catch
            {
                isAffected = false;
            }
            finally { connection.Close(); }
            return isAffected;


        }
        public static bool UpdateFeesApplitionType(int ID, decimal Fees)
        {
            bool isAffected = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = @"UPDATE ApplicationTypes
SET 
ApplicationFees=@Fees
Where ApplicationTypeID=@ID;";

            SqlCommand command = new SqlCommand(qury, connection);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    isAffected = true;
                }
            }
            catch
            {
                isAffected = false;
            }
            finally { connection.Close(); }
            return isAffected;


        }



        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = @"SELECT TestTypeID, TestTypeTitle, TestTypeDescription,TestTypeFees 
                         FROM TestTypes";

            SqlCommand command = new SqlCommand(qury, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;
        }

        public static bool UpdateNameTestType(int ID, string Title)
        {
            bool isAffected = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = @"UPDATE TestTypes
SET 
TestTypeTitle=@Title
Where TestTypeID=@ID;";

            SqlCommand command = new SqlCommand(qury, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    isAffected = true;
                }
            }
            catch
            {
                isAffected = false;
            }
            finally { connection.Close(); }
            return isAffected;


        }
        public static bool UpdateFeesTestType(int ID, decimal Fees)
        {
            bool isAffected = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = @"UPDATE TestTypes
SET 
TestTypeFees=@Fees
Where TestTypeID=@ID;";

            SqlCommand command = new SqlCommand(qury, connection);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    isAffected = true;
                }
            }
            catch
            {
                isAffected = false;
            }
            finally { connection.Close(); }
            return isAffected;


        }
        public static bool UpdateDescriptionTestType(int ID, string Description)
        {
            bool isAffected = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string qury = @"UPDATE TestTypes
SET 
TestTypeDescription=@Description
Where TestTypeID=@ID;";

            SqlCommand command = new SqlCommand(qury, connection);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    isAffected = true;
                }
            }
            catch
            {
                isAffected = false;
            }
            finally { connection.Close(); }
            return isAffected;


        }
        public static int AddNewApplication(int personID, int applicationTypeID, decimal fees, int createdByUserID)
        {
            int applicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"
        INSERT INTO Application
        (ApplicantPersonID, ApplicationTypeID, ApplicationDate, ApplicationStatus, PaidFees, CreatedByUserID, LastStatusDate)
        VALUES (@PersonID, @ApplicationTypeID, @ApplicationDate, @ApplicationStatus, @Fees, @CreatedByUserID, @LastStatusDate);

        SELECT SCOPE_IDENTITY();
    ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
            command.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);
            command.Parameters.AddWithValue("@ApplicationStatus", 1); // New Application
            command.Parameters.AddWithValue("@Fees", fees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

            try
            {
                connection.Open();
                applicationID = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                // يفضل تسجيل الخطأ
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return applicationID;
        }
        public static int AddNewLocal(int applicationID, int licenseClassID)
        {
            int localID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"
            INSERT INTO LocalDrivingLicenseApplications
            (ApplicationID, LicenseClassID)
            VALUES (@ApplicationID, @LicenseClassID);

            SELECT SCOPE_IDENTITY();
        ";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
            try
            {


                connection.Open();
                localID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {

            }
            finally { connection.Close(); }
            return localID;
        }


        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);


            string query = "SELECT LicenseClassID, ClassName, ClassFees FROM LicenseClasses";

            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {


                connection.Open();

                dt.Load(cmd.ExecuteReader());
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;

        }



        public static bool UpdateApplication(int applicationID, byte status, DateTime lastStatusDate)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"UPDATE Applications
                     SET ApplicationStatus = @Status,
                         LastStatusDate = @LastStatusDate
                     WHERE ApplicationID = @ID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@LastStatusDate", lastStatusDate);
            cmd.Parameters.AddWithValue("@ID", applicationID);

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


        public static decimal GetApplicationFees(int applicationTypeID)
        {
            decimal fees = 0;

            SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT ApplicationFees 
                     FROM ApplicationTypes 
                     WHERE ApplicationTypeID = @ID";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", applicationTypeID);

            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    fees = Convert.ToDecimal(result);
            }
            catch
            {
                // ممكن تضيف لوج هنا لو بدك
            }
            finally
            {
                con.Close();
            }

            return fees;
        }

        public static int GetFees(int classID)
        {
            int fees = 0;
            SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString);


            string query = "SELECT ClassFees FROM LicenseClasses WHERE LicenseClassID = @ID";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", classID);
            try
            {


                con.Open();
                fees = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return fees;
        }


        
            public static bool HasActiveLocalApplication(int personID, int licenseClassID)
            {
                bool exists = false;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"
        SELECT COUNT(*)
        FROM LocalDrivingLicenseApplications L
        JOIN Application A ON L.ApplicationID = A.ApplicationID
        WHERE A.ApplicantPersonID = @PersonID
          AND L.LicenseClassID = @LicenseClassID
          AND A.ApplicationStatus IN (1, 2); -- New or Completed
    ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", personID);
                command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                try
                {
                    connection.Open();
                    exists = (int)command.ExecuteScalar() > 0;
                }
                finally
                {
                    connection.Close();
                }

                return exists;
            }

        public static bool UpdateApplicationStatus(int applicationID, byte newStatus)
        {
            bool isUpdated = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"UPDATE Application
                     SET ApplicationStatus = @Status,
                         LastStatusDate = GETDATE()
                     WHERE ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Status", newStatus);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                conn.Open();
                isUpdated = cmd.ExecuteNonQuery() > 0;
            }
            catch
            {
                isUpdated = false;
            }
            finally
            {
                conn.Close();
            }

            return isUpdated;
        }


    }
}




        





    

