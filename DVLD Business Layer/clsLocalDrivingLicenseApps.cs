using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsLocalDrivingLicenseApps : clsApplications
    {
        private enum enMode { AddNew, Update};
        private enMode _Mode;

        private int _ID = -1;
        public int ID { get { return _ID; } }
        public int LicenseClassID { get; set; }
        public clsLicenseClasses LicenseClassInfo { get; set; }

        public string PersonFullName
        {
            get
            {
               return base.ApplicantPersonInfo.FullName;
            }
        }

        public clsLocalDrivingLicenseApps()
        {
            _ID = -1;
            LicenseClassID = -1;
            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApps(int ID, int applicationID, int licenseClassID, int applicantPersonID,
            DateTime applicationDate, int applicationtypeID, enApplicationStatus status, DateTime lastDateStatus, float paidFees, int userID)
        {
            _ID = ID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
            LicenseClassInfo = clsLicenseClasses.Find(LicenseClassID);
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

        public static clsLocalDrivingLicenseApps FindByLocalDrivingAppLicenseID(int ID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;
            bool isfound = clsLocalDrivingLicenseAppsDataAccess.GetLocalDrivingLicenseAppbyID(ID, ref ApplicationID, ref LicenseClassID);
             
            if(isfound)
            {
                clsApplications application = clsApplications.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApps(ID, ApplicationID, LicenseClassID, application.ApplicantPersonID, 
                    application.ApplicationDate, application.ApplicationID, (enApplicationStatus)application.Status, application.LastDateStatus,
                    application.PaidFees, application.UserID);
            }
            return null;
        }

        public static clsLocalDrivingLicenseApps FindByApplicationID(int ApplicationID)
        {
            int ID = -1;
            int LicenseClassID = -1;
            bool isfound = clsLocalDrivingLicenseAppsDataAccess.GetLocalDrivingLicenseAppbyApplicationID(ref ID, ApplicationID, ref LicenseClassID);

            if (isfound)
            {
                clsApplications application = clsApplications.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApps(ID, ApplicationID, LicenseClassID, application.ApplicantPersonID,
                    application.ApplicationDate, application.ApplicationID, application.Status, application.LastDateStatus,
                    application.PaidFees, application.UserID);
            }
            return null;
        }

        private bool _AddNewLocalDrivingLicenseApp()
        {
            _ID = clsLocalDrivingLicenseAppsDataAccess.AddNewLocalDrivingLicenseApp(ApplicationID, LicenseClassID);
            return _ID != -1;
        }

        private bool _UpdateLovalDrivingLicenseApp()
        {
            return clsLocalDrivingLicenseAppsDataAccess.UpdateLocalDrivingLicenseApp(ID, ApplicationID, LicenseClassID);
        }

        public  bool Delete()
        {
            bool isLocalDrivingLicenseAppDeleted = false;
            bool isBaseApplicationDeleted = false;

            //First we delete the Local Driving License Application
            isLocalDrivingLicenseAppDeleted = clsLocalDrivingLicenseAppsDataAccess.DeleteLocalDrivingLicenseApp(ID);

            if (!isLocalDrivingLicenseAppDeleted)
                return false;

            //Then we delete the base Application
            isBaseApplicationDeleted = base.Delete();
            return isBaseApplicationDeleted;
        }

        public bool IsExist(int ID)
        {
            return clsLocalDrivingLicenseAppsDataAccess.IsExist(ID);
        }
        public bool Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base._Mode = (clsApplications.enMode) this._Mode;
            if(!base.Save())
                return false;

            //After we save the main application now we save the sub application.
            switch (_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLocalDrivingLicenseApp())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else return false; 
                case enMode.Update:
                    return _UpdateLovalDrivingLicenseApp();

                default:
                    return false;
            }
        }

        public static DataTable GetAllLocalDrivingLicenseApps()
        {
            return clsLocalDrivingLicenseAppsDataAccess.GetAllLocalDrivingLicenseApps();
        }

    }
}
