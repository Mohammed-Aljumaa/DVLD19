using System;
using System.Data;
using DvldDataAccessLayer;


namespace DvldBusinessLayer
{
    public class clsMangepeople
    {


        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int PersonID { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string SecondName { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public string ImagePath { set; get; }
        public DateTime DateOfBirth { set; get; }
        private string _ImagePath { set; get; }
        public string ThirdName { set; get; }

        public byte Gendor { set; get; }

        public string GetFullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " "+LastName;
        }
        clsCountry CountryInfo {
        set ; get; 

        }
        
        public clsMangepeople(int PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, string Address, string Phone, string Email,
           DateTime DateOfBirth, int NationalityCountryID, byte Gendor, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.DateOfBirth = DateOfBirth;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.NationalityCountryID = NationalityCountryID;
            this.Gendor = Gendor;
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);
            Mode = enMode.Update;

        }
        public clsMangepeople()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.LastName = "";
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.DateOfBirth = DateTime.Now;
            this.SecondName = "";
            this.ThirdName = "";
            this.NationalityCountryID = -1;
            this.Gendor = 0;
            this.ImagePath = "";
            Mode = enMode.AddNew;
        }

        static public DataTable GetAllPeople()
        {
            return MangePeopleDB.GetAllPeople();
        }
        public static clsMangepeople Find(int PersonID)
        {

            string NationalNo = "";
            int NationalityCountryID = -1;
            byte Gendor = 0;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            string Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;

            if (MangePeopleDB.GetPeopleInfoByID(ref PersonID, ref NationalNo, ref FirstName, ref SecondName,
                   ref ThirdName, ref LastName, ref Address, ref Phone, ref Email,
                    ref DateOfBirth, ref NationalityCountryID, ref Gendor, ref ImagePath))
            {

                return new clsMangepeople(   PersonID,  NationalNo,  FirstName,  SecondName,  ThirdName,  LastName,  Address,  
                    Phone,  Email,  DateOfBirth,  NationalityCountryID,  Gendor,  ImagePath);
            }
            else
                return null;


        }
        public static clsMangepeople Find(string NationalNo)
        {
            int PersonID = -1;
            int NationalityCountryID = -1;
            byte Gendor = 0;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            string Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;

            if (MangePeopleDB.GetPeopleInfoByNationalNo(ref NationalNo,ref PersonID, ref FirstName, ref SecondName,
                   ref ThirdName, ref LastName, ref Address, ref Phone, ref Email,
                    ref DateOfBirth, ref NationalityCountryID, ref Gendor, ref ImagePath))
            {

                return new clsMangepeople(   PersonID,  NationalNo,  FirstName,  SecondName,  ThirdName,  LastName,  Address,  
                    Phone,  Email,  DateOfBirth,  NationalityCountryID,  Gendor,  ImagePath);
            }
            else
                return null;


        }


        private bool _AddNewPerson()
        {
            this.PersonID = MangePeopleDB.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
this.Address, this.Phone, this.Email, this.DateOfBirth, this.NationalityCountryID, this.Gendor, this.ImagePath);
            return (this.PersonID!= -1);

        }
        public bool _UpdatePerson()
        {
            return MangePeopleDB.UpdatePerson(this.PersonID,this.NationalNo,this.FirstName,this.SecondName,this.ThirdName,this.LastName,
this.Address,this.Phone,this.Email,this.DateOfBirth,this.NationalityCountryID,this.Gendor,this.ImagePath);
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();

            }
            return false;
        }
public static bool DeletePerson(int PersonID)
        {
            return (MangePeopleDB.DeletePerson(PersonID));
        }

        static public bool IsPersonIDExist(int CurrentPersonID)
        {
            return (MangePeopleDB.IsPersonIDExist(CurrentPersonID));
        }

          static public bool IsNationalNoUsedByOther(string NationalNo,int CurrentPersonID)
        {
            return (MangePeopleDB.IsNationalNoUsedByOther(NationalNo, CurrentPersonID));

        }static public bool IsNationalNoExist(string NationalNo)
        {
            return (MangePeopleDB.IsNationalNoExist(NationalNo));

        }
    }
}



