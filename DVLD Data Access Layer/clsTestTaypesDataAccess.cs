using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsTestTaypesDataAccess
    {
        public static bool GetTestTypeByID(int ID, ref string Title, ref string Description, ref float Fees)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From TestTypes Where TestTypeID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isfound = true;
                    Title = reader["TestTypeTitle"].ToString();
                    Description = reader["TestTypeDescription"].ToString();
                    Fees = Convert.ToInt16(reader["TestTypeFees"]);
                }
                else
                {
                    isfound = false;
                    reader.Close();
                }
            }
            catch (Exception ex) { isfound = false; }
            finally { connection.Close(); }
            return isfound;
        }
        
        public static bool GetTestTypeByTitle (ref int ID, string Title, ref string Description, ref float Fees)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From TestTypes Where TestTypeTitle = @Title";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    ID = Convert.ToInt32(reader["TestTypeID"]);
                    Description = reader["TestTypeDescription"].ToString();
                    Fees = Convert.ToInt16(reader["TestTypeFees"]);
                }
                else
                {
                    isfound = false;
                    reader.Close();
                }
            }
            catch (Exception ex) { isfound = false; }
            finally { connection.Close(); }
            return isfound;
        }

        public static int AddNewTestType(string Title, string Description, float Fees)
        {
            int TestTypeID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO [dbo].[TestTypes] ([TestTypeTitle], [TestTypeDescription], [TestTypeFees]) VALUES (@Title, @Description, @Fees) Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand (query, connection);
            command.Parameters.AddWithValue("@Titel", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedId))
                {
                    TestTypeID = insertedId;
                }
                else
                    TestTypeID = -1;
            }
            catch (Exception ex )
            {
                TestTypeID = -1;
            }
            finally { connection.Close(); }
            return TestTypeID;
        }

        public static bool UpdateTestType(int ID,  string Title, string Description, float Fees)
        {
            int affectedrows = 0;
            SqlConnection connection = new SqlConnection (clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[TestTypes] SET [TestTypeTitle] = @Title, [TestTypeDescription] = @Description, [TestTypeFees] = @Fees WHERE TestTypeID = @ID";
            SqlCommand command = new SqlCommand (query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                affectedrows = command.ExecuteNonQuery();
            }
            catch (Exception ex) { affectedrows = 0; }
            finally
            { connection.Close(); }
            return affectedrows > 0;
        }

        public static DataTable GetAllTestTypes()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT [TestTypeID] as ID, [TestTypeTitle] as Title, [TestTypeDescription] as Description, [TestTypeFees] as Fees FROM [dbo].[TestTypes]";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return dataTable;
        }
    }
}
