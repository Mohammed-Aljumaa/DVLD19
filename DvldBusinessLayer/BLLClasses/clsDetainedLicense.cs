using DvldDataAccessLayer.DALCalsses;
using System;
using System.Data;

namespace DvldBusinessLayer.BLLClasses
{
    public class clsDetainedLicense
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }

        public clsDetainedLicense() { }


        public static DataTable GetAllDetainedLicenses()
        {
            return DetainedLicensesDB.GetAllDetainedLicenses();
        }

        // ============================
        // 1) Find
        // ============================
        public static clsDetainedLicense Find(int detainID)
        {
            int licenseID = 0, createdBy = 0;
            decimal fineFees = 0;
            DateTime detainDate = DateTime.Now;
            bool isReleased = false;
            DateTime? releaseDate = null;
            int? releasedBy = null;

            bool found = DetainedLicensesDB.GetDetainInfo(
                detainID,
                ref licenseID,
                ref detainDate,
                ref fineFees,
                ref createdBy,
                ref isReleased,
                ref releaseDate,
                ref releasedBy
            );

            if (!found)
                return null;

            return new clsDetainedLicense
            {
                DetainID = detainID,
                LicenseID = licenseID,
                DetainDate = detainDate,
                FineFees = fineFees,
                CreatedByUserID = createdBy,
                IsReleased = isReleased,
                ReleaseDate = releaseDate,
                ReleasedByUserID = releasedBy
            };
        }

        // ============================
        // 2) Detain License
        // ============================
        public static int DetainLicense(int licenseID, decimal fineFees, int createdByUserID)
        {
            return DetainedLicensesDB.DetainLicense(licenseID, fineFees, createdByUserID);
        }

        // ============================
        // 3) Release License
        // ============================
        public static bool ReleaseLicense(int detainID, int releasedByUserID)
        {
            return DetainedLicensesDB.ReleaseLicense(detainID, releasedByUserID);
        }

        // ============================
        // 4) Check if detained
        // ============================
        public static bool IsLicenseDetained(int licenseID)
        {
            return DetainedLicensesDB.IsLicenseDetained(licenseID);
        }


        public static int GetDetainIDByLicenseID(int licenseID)
        {
            return DetainedLicensesDB.GetDetainIDByLicenseID(licenseID);
        }

    }
}
