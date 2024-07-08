using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business_Layer
{
    public class clsUsers
    {
        private enum enMode { Update, AddNew };

        private int _ID = -1;
        public int ID { get { return _ID; } }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        //flag for Update Method to update only password
        public bool ChangPass { get; set; }

        private enMode _Mode;

        public int PersonID { get; set; }
        public clsPeople PersonInfo { get; set; }
       
        public clsUsers()
        {
            _ID = -1;
            Username = string.Empty;
            Password = string.Empty;
            IsActive = true;
            ChangPass = false;
            _Mode = enMode.AddNew;
        }

        private clsUsers(int iD,int personID, string username, string password, bool isActive)
        {
            _ID = iD;
            PersonID = personID;
            PersonInfo = clsPeople.Find(PersonID);
            Username = username;
            Password = password;
            IsActive = isActive;
            ChangPass = false;
            _Mode = enMode.Update;
        }

        public static clsUsers Find(int ID)
        {
            int PersonID = -1;
            string username = string.Empty;
            string password = string.Empty;
            bool isActive = false;
            if(clsUsersDataAccess.GetUserbyID(ID, ref PersonID, ref username, ref password, ref isActive))
                return new clsUsers(ID,PersonID, username, password, isActive);
            else return null;
        }

        public static clsUsers Find(string Username, string Password)
        {
            int id = -1;
            int ApplicantPersonID = -1;
            bool isActive = false;
            if (clsUsersDataAccess.GetUserbyUsernameAndPassword(ref id, ref ApplicantPersonID, Username, Password, ref isActive))
                return new clsUsers(id, ApplicantPersonID, Username, Password, isActive);
            else return null;
        }

        public static clsUsers FindbyPersonID(int PersonID)
        {
            int ID = -1;
            string username = string.Empty;
            string password = string.Empty;
            bool isActive = false;
            if (clsUsersDataAccess.GetUserbyPersonID(ref ID, PersonID, ref username, ref password, ref isActive))
                return new clsUsers(ID, PersonID, username, password, isActive);
            else return null;
        }

        public static bool IsExist(int ID)
        {
            return clsUsersDataAccess.IsExist(ID);
        }
        public static bool IsExist(string Username)
        {
            return clsUsersDataAccess.IsExist(Username);
        }
        
        public static bool IsExistbyPersonID(int PersonID)
        {
            return clsUsersDataAccess.IsExistbyPersonID(PersonID);
        }
        private bool _Update()
        {
            if(ChangPass)
                return clsUsersDataAccess.ChangePassword(ID, Password);
            else
                return clsUsersDataAccess.UpdateUser(ID, Username, Password, IsActive);
        }

        private bool _AddNew()
        {
            _ID = clsUsersDataAccess.AddNewUser(PersonID, Username, Password, IsActive);

            return _ID != -1;
        }

        public static bool Delete(int ID)
        {
           return clsUsersDataAccess.DeleteUser(ID);
        }

        public  bool Save()
        {
            switch(_Mode)
            {
                case enMode.Update:
                    return _Update();

                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                default: return false;
            }
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersDataAccess.GetAllUsers();
        }
    }
}
