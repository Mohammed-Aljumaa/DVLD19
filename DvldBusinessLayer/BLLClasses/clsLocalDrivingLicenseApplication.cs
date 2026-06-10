using DvldDataAccessLayer.DALCalsses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessLayer.BLLClasses
{
    public class clsLocalDrivingLicenseApplication
    {

            public int LocalAppID { get; set; }
            public int ApplicationID { get; set; }
            public int LicenseClassID { get; set; }
            public string ClassName { get; set; }
            public int PassedTests { get; set; }

            public static clsLocalDrivingLicenseApplication Find(int localAppID)
            {
                int appID = 0, classID = 0, passed = 0;
                string className = "";

                bool found = LocalDrivingLicenseApplicationDB.GetDrivingLicenseApplicationInfo(
                    localAppID, ref appID, ref classID, ref className, ref passed);

                if (!found)
                    return null;

                return new clsLocalDrivingLicenseApplication
                {
                    LocalAppID = localAppID,
                    ApplicationID = appID,
                    LicenseClassID = classID,
                    ClassName = className,
                    PassedTests = passed
                };
            }



        public static clsLocalDrivingLicenseApplication FindByApplicationID(int applicationID)
        {
            int localAppID = LocalDrivingLicenseApplicationDB.GetLocalAppIDByApplicationID(applicationID);

            if (localAppID <= 0)
                return null;

            return clsLocalDrivingLicenseApplication.Find(localAppID);
        }



        public static bool Delete(int localAppID)
        {
            return LocalDrivingLicenseApplicationDB.Delete(localAppID);
        }



    }

}

