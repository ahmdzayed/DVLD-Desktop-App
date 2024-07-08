using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsApplicationTypesDataAccess
    {
        public static bool GetApplicationbyID(int ID, ref string ApplicaionTitle, ref float Fees)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From ApplicationTypes Where ApplicationTypeID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    ApplicaionTitle = reader["ApplicationTypeTitle"].ToString();
                    Fees = Convert.ToSingle(reader["ApplicationFees"]);
                }
                else isfound = false;

                reader.Close();
            }
            catch (Exception ex) { isfound = false; }
            finally { connection.Close(); }
            return isfound;
        }
        
        public static bool GetApplicationbyTitle(ref int ID, string ApplicaionTitle, ref float Fees)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From ApplicationTypes Where ApplicationTypeTitle = @ApplicaionTitle;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicaionTitle", ApplicaionTitle);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    ID = Convert.ToInt32(reader["ApplicationTypeID"]);
                    Fees = Convert.ToSingle(reader["ApplicationFees"]);
                }
                else isfound = false;

                reader.Close();
            }
            catch (Exception ex) { isfound = false; }
            finally { connection.Close(); }
            return isfound;
        }

        public static bool UpdateApplicationTypeInfo(int ID, string ApplicaionTitle, float Fees)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[ApplicationTypes]
   SET [ApplicationTypeTitle] = @ApplicationTitle, [ApplicationFees] = @Fees WHERE ApplicationTypeID = @ID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@ApplicationTitle", ApplicaionTitle);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch ( Exception ex){ }
            finally { connection.Close(); }
            return AffectedRows > 0;
        }
       
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT [ApplicationTypeID] as ID ,[ApplicationTypeTitle] as Title ,[ApplicationFees] as Fees FROM [dbo].[ApplicationTypes]";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex){ }
            finally { connection.Close(); }
            return dataTable;
        }
    }
}
