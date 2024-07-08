using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsUsersDataAccess
    {
        public static bool GetUserbyID(int ID, ref int PersonID, ref string Username, ref string Password, ref bool IsActive)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Users Where UserID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    Username = Convert.ToString(reader["Username"]);
                    Password = Convert.ToString(reader["Password"]);
                    IsActive = (bool)reader["IsActive"];
                    isfound = true;
                }
                else
                {
                    isfound = false;
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                isfound = false;
            }
            finally { connection.Close(); }

            return isfound;
        }
       
        public static bool GetUserbyUsernameAndPassword(ref int ID, ref int PersonID, string Username, string Password, ref bool IsActive)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Users Where Username = @Username AND Password = @Password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ID = Convert.ToInt32(reader["UserID"]);
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    IsActive = (bool)reader["IsActive"];
                    isfound = true;
                }
                else
                {
                    isfound = false;
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                isfound = false;
            }
            finally { connection.Close(); }

            return isfound;
        }

        public static bool GetUserbyPersonID(ref int ID, int PersonID, ref string Username, ref string Password, ref bool IsActive)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Users Where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ID = Convert.ToInt32(reader["UserID"]);
                    Username = Convert.ToString(reader["Username"]);
                    Password = Convert.ToString(reader["Password"]);
                    IsActive = (bool)reader["IsActive"];
                    isfound = true;
                }
                else
                {
                    isfound = false;
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                isfound = false;
            }
            finally { connection.Close(); }

            return isfound;
        }
       
        public static int AddNewUser(int PersonID, string Username, string Password, bool IsActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Users (PersonID, Username, Password, IsActive) VALUES ( @PersonID, @UserName, @Password, @IsActive) Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InserstedID))
                {
                    UserID = InserstedID;
                }
                else UserID = -1;
            }
            catch (Exception ex)
            {
                UserID = -1;
            }
            finally { connection.Close(); }

            return UserID;

        }

        public static bool UpdateUser(int UserID, string Username, string Password, bool IsActive)
        {
            int affectedrows = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Users SET [Username] = @Username, [Password] = @Password, [IsActive] = @IsActive WHERE UserID = @UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                affectedrows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                affectedrows = 0;
            }
            finally { connection.Close(); }
            return affectedrows > 0;
        }
        
        public static bool DeleteUser(int UserID)
        {
            int affecterows = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete From Users Where UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                affecterows = command.ExecuteNonQuery();
            }
            catch (Exception ex) { affecterows = 0; }
            finally { connection.Close(); }
            return affecterows > 0;
        }

        public static bool IsExist(int UserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select Found = 1 from Users Where UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) { isFound = true; }
                else { isFound = false; }
            }
            catch (Exception ex) { isFound = false; }
            finally { connection.Close(); }
            return isFound;

        }

        public static bool IsExist(string Username)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select Found = 1 from Users Where Username = @Username";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) { isFound = true; }
                else { isFound = false; }
            }
            catch (Exception ex) { isFound = false; }
            finally { connection.Close(); }
            return isFound;

        }

        public static bool IsExistbyPersonID(int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select Found = 1 from Users Where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) { isFound = true; }
                else { isFound = false; }
            }
            catch (Exception ex) { isFound = false; }
            finally { connection.Close(); }
            return isFound;

        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int affectedrows = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Users SET  [Password] = @NewPassword WHERE UserID = @UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NewPassword", NewPassword);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                affectedrows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                affectedrows = 0;
            }
            finally { connection.Close(); }
            return affectedrows > 0;
        }

        public static DataTable GetAllUsers()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection( clsDataAccessSettings.ConnectionString);
            string query = "SELECT  Users.UserID, Users.PersonID, FullName =(People.FirstName + ' ' + People.SecondName + ' ' + ISNULL( People.ThirdName,'') + ' ' + People.LastName), Users.Username, Users.IsActive FROM  Users INNER JOIN People ON Users.PersonID = People.PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return table;
        }
    }
}
