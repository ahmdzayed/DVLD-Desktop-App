using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsApplications
    {
        protected enum enMode { AddNew, Update };

        public enum enApplicationTypes
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public int ApplicationID { get; set; }
        
        public int ApplicantPersonID { get; set; }
        public clsPeople ApplicantPersonInfo { get; set; }
        
        public DateTime ApplicationDate { get; set; }
        
        public int ApplicatoinTypeID { get; set; }
        public clsApplicationTypes ApplicationTypeInfo { get; set; }

        public enApplicationStatus Status { get; set; }

        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknow";
                }
            }
        }

        public DateTime LastDateStatus { get; set; }
        public float PaidFees { get; set; }
        
        public int UserID { get; set; }
        public clsUsers CreatedByUserInfo { get; set; }

        protected enMode _Mode;

        public clsApplications()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicatoinTypeID = -1;
            Status = enApplicationStatus.New;
            LastDateStatus = DateTime.Now;
            PaidFees = 0;
            UserID = -1;
            _Mode = enMode.AddNew;
        }

        private clsApplications(int id, int applicantPersonID, DateTime applicationDate, int applicationtypeID, enApplicationStatus status, DateTime lastDateStatus, float paidFees, int userID)
        {
            ApplicationID = id;
            ApplicantPersonID = applicantPersonID;
            ApplicantPersonInfo = clsPeople.Find(ApplicantPersonID);
            ApplicationDate = applicationDate;
            ApplicatoinTypeID = applicationtypeID;
            ApplicationTypeInfo = clsApplicationTypes.Find(ApplicatoinTypeID);
            Status = status;
            LastDateStatus = lastDateStatus;
            PaidFees = paidFees;
            UserID = userID;
            CreatedByUserInfo = clsUsers.Find(UserID);
            _Mode = enMode.Update;
        }

        public static clsApplications FindBaseApplication(int ID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;
            byte Status = 0;
            DateTime LastDateStatus = DateTime.Now;
            float PaidFees = 0;
            int UserID = -1;
            if(clsApplicationsDataAccess.GetApplicationbyID(ID, ref ApplicantPersonID, ref ApplicationDate,ref ApplicationTypeID, ref Status, ref LastDateStatus, ref PaidFees, ref UserID))
                return new clsApplications(ID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, (enApplicationStatus) Status, LastDateStatus, PaidFees, UserID);
            else 
                return null;
        }

        private bool _Update()
        {
            return clsApplicationsDataAccess.UpdateApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicatoinTypeID, (byte)Status, LastDateStatus, PaidFees, UserID);
        }

        private bool _AddNew()
        {
            ApplicationID = clsApplicationsDataAccess.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicatoinTypeID, (byte)Status, LastDateStatus, PaidFees, UserID);
            return ApplicationID != -1;
        }

        public bool Cancel()
        {
            return clsApplicationsDataAccess.UpdateApplicationStatus(ApplicationID, 2);
        }

        public bool SetComplete()
        {
            return clsApplicationsDataAccess.UpdateApplicationStatus(ApplicationID, 3);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else { return false; }
                case enMode.Update:
                    return _Update();
                default: return false;
            }
        }

        public static bool Delete(int ID)
        {
            return clsApplicationsDataAccess.DeleteApplication(ID);
        }

        public bool Delete()
        {
            return clsApplicationsDataAccess.DeleteApplication(this.ApplicationID);
        }
        public static bool IsExist(int ID)
        {
            return clsApplicationsDataAccess.IsExist(ID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationsDataAccess.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, enApplicationTypes ApplicationTypeID)
        {
            return clsApplicationsDataAccess.GetActiveApplicationID(PersonID, (int) ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, enApplicationTypes applicationTypeID, int LicenseClassID)
        {
            return clsApplicationsDataAccess.GetActiveApplicationIDForLicenseClass(PersonID, (int) applicationTypeID, LicenseClassID);
        }

        public int GetActiveApplicationID(enApplicationTypes applicationTypeID)
        {
           return GetActiveApplicationID(this.ApplicantPersonID, applicationTypeID);
        }
    }
}
