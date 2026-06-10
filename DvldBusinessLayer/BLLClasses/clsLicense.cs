using DvldDataAccessLayer.DALCalsses;
using System;
using System.Data;

namespace DvldBusinessLayer.BLLClasses
{
    public class clsLicense
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public static string GetClassName(int classID)
        {
            return LicensesDB.GetClassName(classID);
        }

        public static clsLicense Find(int licenseID)
        {
            int applicationID = 0, driverID = 0, licenseClass = 0, createdBy = 0;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string notes = "";
            decimal paidFees = 0;
            bool isActive = false;
            byte issueReason = 0;

            bool found = LicensesDB.GetLicenseInfo(
                licenseID,
                ref applicationID,
                ref driverID,
                ref licenseClass,
                ref issueDate,
                ref expirationDate,
                ref notes,
                ref paidFees,
                ref isActive,
                ref issueReason,
                ref createdBy
            );

            if (!found)
                return null;

            return new clsLicense
            {
                LicenseID = licenseID,
                ApplicationID = applicationID,
                DriverID = driverID,
                LicenseClass = licenseClass,
                IssueDate = issueDate,
                ExpirationDate = expirationDate,
                Notes = notes,
                PaidFees = paidFees,
                IsActive = isActive,
                IssueReason = issueReason,
                CreatedByUserID = createdBy
            };
        }

        public int Save()
        {

            return LicensesDB.Insert(
                this.ApplicationID,
                this.DriverID,
                this.LicenseClass,
                this.IssueDate,
                this.ExpirationDate,
                this.Notes,
                this.PaidFees,
                this.IsActive,
                this.IssueReason,
                this.CreatedByUserID
            );
        }

        public bool Update()
        {
            return LicensesDB.Update(
                this.LicenseID,
                this.ApplicationID,
                this.DriverID,
                this.LicenseClass,
                this.IssueDate,
                this.ExpirationDate,
                this.Notes,
                this.PaidFees,
                this.IsActive,
                this.IssueReason,
                this.CreatedByUserID
            );
        }

        public static int GetLicenseIDByApplicationID(int applicationID)
        {
            return LicensesDB.GetLicenseIDByApplicationID(applicationID);
        }

        public static DataTable GetLocalLicensesByPersonID(int personID)
        {
            return LicensesDB.GetLocalLicensesByPersonID(personID);
        }
    }
}
