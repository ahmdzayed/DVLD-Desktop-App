using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsApplicationTypes
    {
        public int ID { get;}
        public string Title { get; set; }
        public float Fees { get; set; }

        private clsApplicationTypes(int id, string title, float fees) 
        {
            ID = id;
            Title = title;
            Fees = fees;
        }
        
        public static clsApplicationTypes Find(int ID)
        {
            string Title = string.Empty;
            float Fees = 0;
            if(clsApplicationTypesDataAccess.GetApplicationbyID(ID, ref Title, ref Fees))
                return new clsApplicationTypes(ID, Title, Fees);
            else return null;
        }

        public static clsApplicationTypes Find(string Title)
        {
            int ID = -1;
            float Fees = 0;
            if (clsApplicationTypesDataAccess.GetApplicationbyTitle(ref ID, Title, ref Fees))
                return new clsApplicationTypes(ID, Title, Fees);
            else return null;
        }
        private bool _Update()
        {
            return clsApplicationTypesDataAccess.UpdateApplicationTypeInfo(ID, Title, Fees);
        }
        
        public bool Save()
        {
            return _Update();
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();
        }
    }
}
