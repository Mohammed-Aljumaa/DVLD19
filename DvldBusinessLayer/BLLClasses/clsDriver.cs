using System;
using System.Data;
using DvldDataAccessLayer.DALCalsses;

namespace DvldBusinessLayer.BLLClasses
{
    public class clsDriver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }



        public clsDriver()
        {
            DriverID = -1;
            CreatedDate = DateTime.Now;
        }


        public static DataTable GetAllDrivers()
        {
            return DriverDB.GetAllDrivers();
        }


        public static clsDriver Find(int driverID)
        {
            int personID = 0;
            DateTime createdDate = DateTime.Now;

            bool isFound = DriverDB.FindByDriverID(driverID,
                                                   ref personID,
                                                   ref createdDate);

            if (!isFound)
                return null;

            return new clsDriver
            {
                DriverID = driverID,
                PersonID = personID,
                CreatedDate = createdDate
            };
        }


        public bool Save()
        {
            if (DriverID == -1)
            {
                DriverID = DriverDB.Insert(PersonID, CreatedByUserID);
                return DriverID != -1;
            }

            return false; // لا يوجد Update في هذا النظام
        }

        public static clsDriver FindByPersonID(int personID)
        {
            int driverID = DriverDB.GetDriverIDByPersonID(personID);

            if (driverID == -1)
                return null;

            return new clsDriver
            {
                DriverID = driverID,
                PersonID = personID
            };
        }
    }
}
