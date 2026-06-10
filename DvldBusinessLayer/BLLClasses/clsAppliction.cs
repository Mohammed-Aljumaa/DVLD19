using DvldDataAccessLayer.DALCalsses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessLayer.BLLClasses
{
    public class clsAppliction
    {
       
            public int ApplicationID { get; set; }
            public int ApplicantPersonID { get; set; }
            public string ApplicantFullName { get; set; }
            public DateTime ApplicationDate { get; set; }
            public byte ApplicationStatus { get; set; }
            public int ApplicationTypeID { get; set; }
            public string ApplicationTypeTitle { get; set; }
            public DateTime LastStatusDate { get; set; }
            public decimal PaidFees { get; set; }
            public int CreatedByUserID { get; set; }
            public string CreatedByUserName { get; set; }

            public static clsAppliction Find(int applicationID)
            {
                int personID = 0, typeID = 0, createdBy = 0;
                string fullName = "", typeTitle = "", createdByName = "";
                DateTime appDate = DateTime.Now, statusDate = DateTime.Now;
                byte status = 0;
                decimal fees = 0;

                bool found = ApplicationDB.GetApplicationBasicInfo(
                    applicationID,
                    ref personID,
                    ref fullName,
                    ref appDate,
                    ref status,
                    ref typeID,
                    ref typeTitle,
                    ref statusDate,
                    ref fees,
                    ref createdBy,
                    ref createdByName
                );

                if (!found)
                    return null;

                return new clsAppliction
                {
                    ApplicationID = applicationID,
                    ApplicantPersonID = personID,
                    ApplicantFullName = fullName,
                    ApplicationDate = appDate,
                    ApplicationStatus = status,
                    ApplicationTypeID = typeID,
                    ApplicationTypeTitle = typeTitle,
                    LastStatusDate = statusDate,
                    PaidFees = fees,
                    CreatedByUserID = createdBy,
                    CreatedByUserName = createdByName
                };
            
        }

        public static decimal GetApplictionFees(int applicationTypeID)
        {
            return ApplicationDB.GetApplicationFees(applicationTypeID);
        }

        static public DataTable GetAllApplictionType()
        {
            return ApplicationDB.GetAllApplictionTypes();
        }

        public static DataTable GetAllLocalApplications()
        {
            return ApplicationDB.GetAllLocalApplications();
        }

        static public bool UpdateNameApplitionType(int ID,string Title)
        {
            return ApplicationDB.UpdateNameApplitionType(ID, Title);
        }
    static public bool UpdateFeesApplitionType(int ID,decimal Fees)
        {
            return ApplicationDB.UpdateFeesApplitionType(ID, Fees);
        }


        static public DataTable GetAllTestTypeTypes()
        {
            return ApplicationDB.GetAllTestTypes();
        }


        static public bool UpdateNameTestType(int ID, string Title)
        {
            return ApplicationDB.UpdateNameTestType(ID, Title);
        }
        static public bool UpdateFeesTestType(int ID, decimal Fees)
        {
            return ApplicationDB.UpdateFeesTestType(ID, Fees);
        }

        static public bool UpdateDescriptionTestType(int ID,string Description)
        {
            return ApplicationDB.UpdateDescriptionTestType(ID, Description);
        }

        public static int CreateInternational(int personID, decimal fees, int createdByUserID)
        {
            // ApplicationTypeID = 2 (International License)
            int applicationID = ApplicationDB.AddNewApplication(
                personID,
                2,
                fees,
                createdByUserID
            );

            return applicationID;
        }

        public static int Create(int personID, int licenseClassID, decimal fees, int createdByUserID)
        {
            // 1) إنشاء Application عام
            int applicationID = ApplicationDB.AddNewApplication(
                personID,
                1, // ApplicationTypeID = 1 (Local Driving License)
                fees,
                createdByUserID
            );

            if (applicationID <= 0)
                return -1;

            // 2) إنشاء LocalDrivingLicenseApplication
            int localID = ApplicationDB.AddNewLocal(applicationID, licenseClassID);

            return localID;
        }
        public static int CreateRenew(int personID, decimal fees, int createdByUserID)
        {
            // ApplicationTypeID = 3 (Renew Local License)
            int applicationID = ApplicationDB.AddNewApplication(
                personID,
                3,          // نوع الطلب: تجديد رخصة
                fees,
                createdByUserID
            );

            return applicationID;
        }



        public static DataTable GetAllClasses()
                {
                    return ApplicationDB.GetAll();
                }

                public static int GetFees(int classID)
                {
                    return ApplicationDB.GetFees(classID);
            
                }
            
        public static bool HasActiveOrCompletedApplication(int PersonID,int LicensClass)
        {

            return   ApplicationDB.HasActiveLocalApplication(PersonID,LicensClass);


        }

        public bool UpdateStatus(byte newStatus)
        {
            bool result = ApplicationDB.UpdateApplicationStatus(this.ApplicationID, newStatus);

            if (result)
            {
                this.ApplicationStatus = newStatus;
                this.LastStatusDate = DateTime.Now;
            }

            return result;
        }
        public int Saveint()
        {
            // طلب جديد
            if (this.ApplicationID == 0)
            {
                int newID = ApplicationDB.AddNewApplication(
                    this.ApplicantPersonID,
                    this.ApplicationTypeID,
                    this.PaidFees,
                    this.CreatedByUserID
                );

                if (newID <= 0)
                    return -1;

                this.ApplicationID = newID;
                this.ApplicationDate = DateTime.Now;
                this.LastStatusDate = DateTime.Now;
                this.ApplicationStatus = 1; // New

                return this.ApplicationID;
            }
            else
            {
                // تحديث الطلب
                bool updated = ApplicationDB.UpdateApplication(
                    this.ApplicationID,
                    this.ApplicationStatus,
                    this.LastStatusDate
                );

                return updated ? this.ApplicationID : -1;
            }
        }

        public bool Save()
        {
            // إذا كان ApplicationID = 0 → يعني طلب جديد
            if (this.ApplicationID == 0)
            {
                int newID = ApplicationDB.AddNewApplication(
                    this.ApplicantPersonID,
                    this.ApplicationTypeID,
                    this.PaidFees,
                    this.CreatedByUserID
                );

                if (newID <= 0)
                    return false;

                this.ApplicationID = newID;
                this.LastStatusDate = DateTime.Now;
                this.ApplicationStatus = 1; // New
                return true;
            }
            else
            {
                // تحديث الطلب (نادراً تحتاجه)
                return ApplicationDB.UpdateApplication(
                    this.ApplicationID,
                    this.ApplicationStatus,
                    this.LastStatusDate
                );
            }
        }


    }
}

