using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsLicenseClasses
    {
        private int _ID = -1;
        public int ID { get { return _ID; } }

        public string ClassName { get; set; }
        public string Description { get; set; }
        public short MinAllowedAge { get; set; }
        public short DefaultValidityLength { get; set; }
        public short Fees {  get; set; }

        public clsLicenseClasses()
        {
            _ID = -1;
            ClassName = string.Empty;
            Description = string.Empty;
            MinAllowedAge = short.MinValue;
            DefaultValidityLength = short.MinValue;
            Fees = short.MinValue;
        }

        private clsLicenseClasses(int iD, string className, string description, short minAllowedAge, short defaultValidityLength, short fees)
        {
            _ID = iD;
            ClassName = className;
            Description = description;
            MinAllowedAge = minAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            Fees = fees;
        }

        public static clsLicenseClasses Find(int ID)
        {
            string className = string.Empty;
            string description = string.Empty;
            short minAllowedAge = short.MinValue; ;
            short defaultValidityLength = short.MinValue; 
            short fees = short.MinValue;
            if(clsLicenseClassesDataAccess.GetLicenseClassbyID(ID, ref className, ref description, ref minAllowedAge, ref defaultValidityLength, ref fees))
                return new clsLicenseClasses(ID, className, description, minAllowedAge, defaultValidityLength, fees);
            return null;
        }

        public static clsLicenseClasses Find(string ClassName)
        {
            int id = -1;
            string description = string.Empty;
            short minAllowedAge = short.MinValue; ;
            short defaultValidityLength = short.MinValue;
            short fees = short.MinValue;
            if (clsLicenseClassesDataAccess.GetLicenseClassbyName(ref id, ClassName, ref description, ref minAllowedAge, ref defaultValidityLength, ref fees))
                return new clsLicenseClasses(id, ClassName, description, minAllowedAge, defaultValidityLength, fees);
            return null;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesDataAccess.GetAllLicenseClasses();
        }
    }
}
