using DvldDataAccessLayer.DALCalsses;
using System;
using System.Data;

namespace DvldBusinessLayer.BLLClasses
{
    public class clsInternationalLicense
    {
        // ============================
        // Properties
        // ============================
        public int InternationalLicenseID { get; set; }
        public int InternationalLicenseApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Fees { get; set; }
        public bool IsActive { get; set; }
        public DateTime ApplicationDate { get; set; }




        public static DataTable GetAll()
        {
            return InternationalLicensesDB.GetAllInternationalLicenses();
        }

        public static bool HasActiveInternationalLicense(int driverID)
        {
            DataTable dt = InternationalLicensesDB.GetInternationalLicensesByDriverID(driverID);

            foreach (DataRow row in dt.Rows)
            {
                DateTime expiration = (DateTime)row["ExpirationDate"];
                bool isActive = (bool)row["IsActive"];

                if (isActive && expiration > DateTime.Now)
                    return true;
            }

            return false;
        }

        public static int AddNew(int applicationID, int driverID, int localLicenseID,
                         DateTime issueDate, DateTime expirationDate, int createdByUserID)
        {
            return InternationalLicensesDB.AddNew(applicationID, driverID, localLicenseID,
                                                      issueDate, expirationDate, createdByUserID);
        }

        // ============================
        // Default Constructor
        // ============================
        public clsInternationalLicense() { }

        // ============================
        // Get All International Licenses for Person
        // ============================
        public static System.Data.DataTable GetInternationalLicensesByPersonID(int personID)
        {
            return InternationalLicensesDB.GetInternationalLicensesByPersonID(personID);
        }

        // ============================
        // Get International License By ID
        // ============================
        public static clsInternationalLicense GetInternationalLicenseByID(int InternationalLicenseID)
        {
            
                int applicationID = 0;
                int driverID = 0;
                int localLicenseID = 0;
                DateTime issueDate = DateTime.Now;
                DateTime expirationDate = DateTime.Now;
                decimal fees = 0;
                bool isActive = false;

                bool isFound = InternationalLicensesDB.GetInternationalLicenseByID(
                    InternationalLicenseID,
                    ref applicationID,
                    ref driverID,
                    ref localLicenseID,
                    ref issueDate,
                    ref expirationDate,
                    ref fees,
                    ref isActive);

                if (!isFound)
                    return null;

                DateTime applicationDate =
                    InternationalLicensesDB.GetApplicationDate(applicationID);

                return new clsInternationalLicense
                {
                    InternationalLicenseID = InternationalLicenseID,
                    InternationalLicenseApplicationID = applicationID,
                    DriverID = driverID,
                    LocalLicenseID = localLicenseID,
                    IssueDate = issueDate,
                    ExpirationDate = expirationDate,
                    Fees = fees,
                    IsActive = isActive,
                    ApplicationDate = applicationDate
                };
            }
        public static int GetActiveInternationalLicenseIDByPersonID(int personID)
        {
            DataTable dt = GetInternationalLicensesByPersonID(personID);

            foreach (DataRow row in dt.Rows)
            {
                bool isActive = (bool)row["IsActive"];
                DateTime expiration = (DateTime)row["ExpirationDate"];

                if (isActive && expiration > DateTime.Now)
                    return (int)row["InternationalLicenseID"];
            }

            return -1;
        }


    }
}
