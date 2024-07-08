using DVLD_Data_Access_Layer;
using System.Data;

namespace DVLD_Business_Layer
{
    public class clsCountries
    {
        private int _ID = -1;
        public int ID {  get { return _ID; } }
        public string Name { set; get; }

        public clsCountries()
        {
            _ID = -1;
            Name = string.Empty;
        }

        private clsCountries(int id, string name)
        {
            _ID = id;
            Name = name;
        }

        public static clsCountries Find(int ID)
        {
            string Name = string.Empty;
            if(clsCountriesDataAccess.GetCountryByID(ID, ref Name))
            {
                return new clsCountries(ID, Name);
            }
            else return null;

        }

        public static clsCountries Find(string Name)
        {
            int ID = -1;
            if (clsCountriesDataAccess.GetCountryByName(ref ID, Name))
            {
                return new clsCountries(ID, Name);
            }
            else return null;
        }
        
        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }
    }
}
