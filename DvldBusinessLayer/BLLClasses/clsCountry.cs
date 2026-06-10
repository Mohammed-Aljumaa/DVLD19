using System;
using System.Data;
using DvldDataAccessLayer;

namespace DvldBusinessLayer
{
    public class clsCountry
    {
        public enum enMode { AddNew=0, Update=1}
        private enMode _Mode=enMode.AddNew;
        
        public string CountryName { get; set; }
        public int CountryID { get; set; }


        private clsCountry(string CountryName,int CountryID)
        {

            this.CountryName = CountryName;
            this.CountryID = CountryID;

            _Mode = enMode.AddNew;

        }
        public clsCountry()
        {
            CountryName = "";
            CountryID = -1;
            _Mode=enMode.Update;
        }



        static public DataTable GetAllCountries()
        {
            return CountryDB.GetAllCountry();

        }

        static public clsCountry Find(int ID)
        {
            string CountryName = "";
            if (CountryDB.GetCountryInfoByID(ref CountryName, ID))
            {
                return new clsCountry(CountryName, ID);
            }
            else
            {
                return null;
            }
        }

             static public clsCountry Find(string CountryName)
        { 
        
            int ID = -1;
            if(CountryDB.GetCountryInfoByID(ref CountryName,ID))
            {
                return new clsCountry(CountryName, ID);
            }
            else
            {
                return null;
            }


        }

    }
}
