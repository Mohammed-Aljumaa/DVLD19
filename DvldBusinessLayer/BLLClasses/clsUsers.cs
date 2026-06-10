using System;
using System.Data;
using DvldDataAccessLayer;
using DvldDataAccessLayer.DALCalsses;

namespace DvldBusinessLayer.BLLClasses
{
    public class clsUsers
    {
        public enum enMode {AddNew=0,Update=1};
        enMode Mode = enMode.AddNew;
        public string UserName { get; set; }
        public string Password { get; set; }
        public clsMangepeople PersonInfo;
        public bool IsActives { get; set; }
        public int PersonID { get; set; }
        public int UserID { get; set; }


     public   clsUsers(int UserID,int PersonID,string UserName,string Password,bool IsActives)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsMangepeople.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password; 
            this.IsActives = IsActives;
            Mode=enMode.Update;
        }
        public clsUsers()
        {
            this.UserName = "";
            this.Password = "";
            this.UserID=-1;
            this.PersonID=-1;
            this.IsActives=false;

            Mode = enMode.AddNew;
        }

        static public DataTable GetAllUsers()
        {

            return UsersDB.GetAllUsers();

        }
        static public clsUsers FindByUserNameAndPassword(string UserName,string Password)
        {
            int UserID = -1;
            int PersonId = -1;
            bool IsActive=false;
            bool IsFound = UsersDB.GetUserInfoByPersonID(UserName, Password, ref UserID, ref PersonId, ref IsActive);
            if (IsFound)
            {
                return new clsUsers(UserID, PersonId,UserName,Password, IsActive);
            }
            else
            {
                return null;
            }
        }


        static public clsUsers FindUserByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;
            bool isFound=UsersDB.FindUserByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive);
            if(isFound)
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }else
            {
                return null;
            }
        }
         static public clsUsers Find(int UserID)
        {
           
            int PersonId = -1;
            string UserName = "";
            string Password = "";

            bool IsActive=false;
            bool IsFound = UsersDB.FindUserByUserID(UserID,ref UserName,ref Password,ref IsActive,ref PersonId);
            if (IsFound)
            {
                return new clsUsers(UserID, PersonId,UserName,Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {
            this.UserID = UsersDB.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActives);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return UsersDB.UpdateUser(this.UserID, this.UserName,this.Password, this.IsActives);
        }
 

         public bool Save()
        {

            switch(Mode)
            {
                case enMode.AddNew:
                   if(_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                    case enMode.Update:
                    return _UpdateUser();



            }
            return false;

        }



        public static bool DeleteUser(int UserID)
        {
            return (UsersDB.DeleteUser(UserID));
        }


        static public bool IsUserNameExists(string UserName)
        {
           return (UsersDB.IsUserNameExists(UserName));
        }
         static public bool IsPasswordExists(string Password)
        {
           return (UsersDB.IsPasswordExists(Password));
        }
        static public bool IsUserActives(string UserName)
        {
           return (UsersDB.IsUserActives(UserName));
        }


        public bool ChangePassword(string newPassword)
        {
            this.Password = newPassword;
            return this.Save();   // أو this.Update() حسب نظامك
        }

        public bool CheakPassword(string Password)
        {

            return(UsersDB.checkPasssword(this.UserID, Password));

        }


    }
}
