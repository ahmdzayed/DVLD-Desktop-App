using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsLicenseClassesDataAccess
    {
        public static bool GetLicenseClassbyID(int ID, ref string ClassName, ref string Description, ref short MinAllowedAge, ref short DefaultValiditylength, ref short Fees)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From LicenseClasses Where LicenseClassID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    ClassName = reader["ClassName"].ToString();
                    Description = reader["ClassDescription"].ToString();
                    MinAllowedAge = Convert.ToInt16(reader["MinimumAllowedAge"]);
                    DefaultValiditylength = Convert.ToInt16(reader["DefaultValiditylength"]);
                    Fees = Convert.ToInt16(reader["ClassFees"]);
                }
                else
                {
                    isfound=false;
                }
                    reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isfound;
        }

        public static bool GetLicenseClassbyName(ref int ID, string ClassName, ref string Description, ref short MinAllowedAge, ref short DefaultValiditylength, ref short Fees)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From LicenseClasses Where ClassName = @ClassName;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    ID = (int)reader["LicenseClassID"];
                    Description = reader["ClassDescription"].ToString();
                    MinAllowedAge = Convert.ToInt16(reader["MinimumAllowedAge"]);
                    DefaultValiditylength = Convert.ToInt16(reader["DefaultValiditylength"]);
                    Fees = Convert.ToInt16(reader["ClassFees"]);
                }
                else
                {
                    isfound = false;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isfound;
        }

        public static DataTable GetAllLicenseClasses()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From LicenseClasses;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return table;
        }
    }
}
