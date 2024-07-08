using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsTestTypes
    {
        public enum enMode { Update, AddNew };
        public enMode Mode;

        public enum enTestType { VisionTest  = 1,  writtenTest = 2, StreetTest = 3};

        public enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }


        public clsTestTypes()
        {
            ID = enTestType.VisionTest;
            Title = "";
            Description = "";
            Fees = 0;
            Mode = enMode.AddNew;
        }
        private clsTestTypes(enTestType id, string title, string description, float fees)
        {
            ID = id;
            Title = title;
            Description = description;
            Fees = fees;
            Mode = enMode.Update;
        }

        public static clsTestTypes Find(enTestType ID)
        {
            string Title = string.Empty;
            string Description = string.Empty;
            float Fees = 0;
            if (clsTestTaypesDataAccess.GetTestTypeByID((int)ID, ref Title, ref Description, ref Fees))
            {
                return new clsTestTypes(ID, Title, Description, Fees);
            }
            return null;
        }
        public static clsTestTypes Find(string Title)
        {
            int ID = -1;
            string Description = string.Empty;
            float Fees = 0;
            if (clsTestTaypesDataAccess.GetTestTypeByTitle(ref ID, Title, ref Description, ref Fees))
            {
                return new clsTestTypes((enTestType)ID, Title, Description, Fees);
            }
            return null;
        }

        private bool _Update()
        {
            return clsTestTaypesDataAccess.UpdateTestType((int)ID, Title, Description, Fees);
        }

        private bool _AddNew()
        {
            ID = (enTestType)clsTestTaypesDataAccess.AddNewTestType(Title, Description, Fees);

            return this.Title != "";
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTaypesDataAccess.GetAllTestTypes();
        }
    }
}
