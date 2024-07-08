using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data_Access_Layer
{
    public class clsLocalDrivingLicenseAppsDataAccess
    {
        public static bool GetLocalDrivingLicenseAppbyID(int ID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                else
                    isfound = false;

                reader.Close();
            }
            catch (Exception ex) { isfound = false; }
            finally { connection.Close(); }

            return isfound;
        }

        public static bool GetLocalDrivingLicenseAppbyApplicationID(ref int ID, int ApplicationID, ref int LicenseClassID)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From LocalDrivingLicenseApplications Where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    ID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                else
                    isfound = false;

                reader.Close();
            }
            catch (Exception ex) { isfound = false; }
            finally { connection.Close(); }

            return isfound;
        }

        public static int AddNewLocalDrivingLicenseApp(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseAppID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO [dbo].[LocalDrivingLicenseApplications] ([ApplicationID], [LicenseClassID]) VALUES (@ApplicationID, @LicenseClassID) Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    LocalDrivingLicenseAppID = insertedID;
                else
                    LocalDrivingLicenseAppID = -1;
            }
            catch (Exception ex) { LocalDrivingLicenseAppID = -1; }
            finally { connection.Close(); }
            return LocalDrivingLicenseAppID;
        }

        public static bool UpdateLocalDrivingLicenseApp(int ID, int ApplicationID, int LicenseClassID)
        {
            int affecterow = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[LocalDrivingLicenseApplications]
                              SET [ApplicationID] = ApplicationID
                                 ,[LicenseClassID] = LicenseClassID
                              WHERE LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                affecterow = command.ExecuteNonQuery();
            }
            catch (Exception ex) { return false; }
            finally
            {
                connection.Close();
            } 
           
            return affecterow > 0;

        }

        public static bool IsExist(int ID)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select Found = 1 From LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    isfound = true;
                else
                    isfound = false;
            }
            catch (Exception ex) { isfound = false; }
            finally { connection.Close(); }
            return isfound;
        }
        
        public static bool DeleteLocalDrivingLicenseApp(int ID)
        {
            int affectedrow = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM [dbo].[LocalDrivingLicenseApplications] Where LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
               affectedrow = command.ExecuteNonQuery();
            }
            catch (Exception ex) { return false; }
            finally { connection.Close(); }

            return affectedrow > 0;
        }

        public static DataTable GetAllLocalDrivingLicenseApps()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From LocalDrivingLicenseApplications_View;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                else
                    reader.Close();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
