using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.Data.SqlClient;

namespace DVLD_Data_Access_Layer
{
    public class clsPeopleDataAccess
    {
        public static bool GetPersonByID(int ID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
                                         ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email,
                                         ref int NationalityCountryID, ref string ImagePath)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From People Where PersonID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                isfound = true;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    NationalNo = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();

                    // ThirdName allows null in database so we should handel null value.
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = reader["ThirdName"].ToString();
                    else
                        ThirdName = "";

                    LastName = reader["LastName"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();

                    // Email allows null in database so we should handel null value.
                    if (reader["Email"] != DBNull.Value)
                        Email = reader["Email"].ToString();
                    else
                        Email = "";

                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    // ImagePath allows null in database so we should handel null value.
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = reader["ImagePath"].ToString();
                    else
                        ImagePath = "";
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
            finally
            {
                connection.Close();
            }
            return isfound;
        }
        
        public static bool GetPersonByNationalNO(ref int ID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
                                                 ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email,
                                                 ref int NationalityCountryID, ref string ImagePath)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From People Where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                isfound = true;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ID = (int)reader["PersonID"];
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();

                    // ThirdName allows null in database so we should handel null value.
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = reader["ThirdName"].ToString();
                    else
                        ThirdName = "";
                    
                    LastName = reader["LastName"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    
                    // Email allows null in database so we should handel null value.
                    if (reader["Email"] != DBNull.Value)
                        Email = reader["Email"].ToString();
                    else
                        Email = "";

                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    // ImagePath allows null in database so we should handel null value.
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = reader["ImagePath"].ToString();
                    else
                        ImagePath = "";
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
            finally
            {
                connection.Close();
            }
            return isfound;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName,
                                         string LastName,DateTime DateOfBirth,byte Gender,string Address,string Phone,string Email,
                                         int NationalityCountryID,string ImagePath)
        {
            int PersonID = -1;
            NationalNo = NationalNo.ToUpper();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[People]([NationalNo],[FirstName],[SecondName],[ThirdName],[LastName],[DateOfBirth],[Gender],[Address],[Phone],[Email],[NationalityCountryID],[ImagePath])
                               VALUES(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath) Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            
            if (ThirdName != "" && ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            
            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            
            if(ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(),out int InserstedID) )
                {
                    PersonID = InserstedID;   
                }
                else
                {
                   PersonID = -1;
                }
            }
            catch (Exception ex)
            {
                PersonID = -1;
            }
            finally
            {
                connection.Close();
            }
            return PersonID;
        }

        public static bool UpdatePerson(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName,
                                         string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email,
                                         int NationalityCountryID, string ImagePath)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[People]
                            SET [NationalNo] = @NationalNo,[FirstName] = @FirstName,[SecondName] = @SecondName,[ThirdName] = @ThirdName ,[LastName] = @LastName,[DateOfBirth] = @DateOfBirth,[Gender] = @Gender,[Address] = @Address,[Phone] = @Phone,[Email] = @Email,[NationalityCountryID] = @NationalityCountryID,[ImagePath] = @ImagePath
                            WHERE PersonID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "" && ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();
                rowsaffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsaffected = 0;
            }
            finally
            {
                connection.Close();
            }
            return rowsaffected>0;
        }
        
        public static bool DeletePerson(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM [dbo].[People] WHERE PersonID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                AffectedRows = 0;
            }
            finally
            {
                connection.Close();
            }
            return AffectedRows > 0;
        }
       
        public static bool DeletePerson(string NationalNo)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM [dbo].[People] WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                AffectedRows = 0;
            }
            finally
            {
                connection.Close();
            }
            return AffectedRows > 0;
        }

        public static bool IsPesonExist(int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select Found = 1 where from People  Where PersonID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    isFound = true;
                else isFound = false;
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool IsPesonExist(string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select Found = 1  from People  Where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    isFound = true;
                else isFound = false;
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT  R1.PersonID, R1.NationalNo, R1.FirstName, R1.SecondName, R1.ThirdName, R1.LastName, R1.Gender, R1.DateOfBirth, Countries.CountryName as Nationalty, R1.Phone, R1.Email FROM" +
                " (SELECT  PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName," +
                "Gender = CASE WHEN Gender = 0 THEN 'Male' WHEN Gender = 1 THEN 'Female' ELSE 'Unknown'  END, DateOfBirth," +
                "NationalityCountryID, Phone, Email FROM  People) as R1 " +
                "INNER JOIN Countries ON R1.NationalityCountryID = Countries.CountryID";
            SqlCommand command = new SqlCommand(query,connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
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
