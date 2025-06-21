using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    static public class clsUserDataAccess
    {

        
        static public bool FindUserById(int UserId,ref int PersonId,ref string UserName,ref string Password
            ,ref bool IsActive
            )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from Users where UserId = @UserId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", UserId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    PersonId = (int)reader["PersonId"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

                }
                else
                {
                    isExist = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }


        static public bool FindUserByUserName(ref int UserId, ref int PersonId, string UserName, ref string Password
                , ref bool IsActive
                )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from Users where UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    UserId = (int)reader["UserId"];
                    PersonId = (int)reader["PersonId"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

                }
                else
                {
                    isExist = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }
        static public bool FindUserByUserNameAndPassword(ref int UserId, ref int PersonId, string UserName, string Password
              , ref bool IsActive
              )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT * FROM Users 
                        WHERE UserName = @UserName AND Password = @Password;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    UserId = (int)reader["UserId"];
                    PersonId = (int)reader["PersonId"];
                    IsActive = (bool)reader["IsActive"];

                }
                else
                {
                    isExist = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }



        public static int AddNewUser(int PersonId, string UserName,  string Password
                ,  bool IsActive)
        {
            int UserId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into Users (PersonId,UserName,Password,IsActive)
                            values (@PersonId,@UserName,@Password,@IsActive)
                            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId",PersonId);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedId))
                {
                    UserId = insertedId;
                }

            }
            catch (Exception ex)
            {
                return -1;

            }
            finally
            {

                connection.Close();
            }
            return UserId;

        }


        
        public static bool DeleteUser(int UserId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Delete People Where UserId = @UserId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", UserId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex) { return false; }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }


        
        public static bool UpdateUser(int UserId,int PersonId,string UserName,string Password,bool IsActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update People 

                            set PersonId = @PersonId,
                            UserName = @UserName,
                            Password = @Password,
                            IsActive = @IsActive,   
                            where UserId = @UserId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@PersonId", PersonId);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;

        }




        public static DataTable ListAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT * from Users";
            SqlCommand command = new SqlCommand(query, connection);

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
            finally { connection.Close(); }
            return dt;

        }


        
/*        public static bool isPersonUser(string NationalNumber)
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT Found=1 FROM People WHERE NationalNumber = @NationalNumber";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExist = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                connection.Close();
            }
            return isExist;


        }

        
        public static bool isPersonExist(int PersonId)
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT Found=1 FROM People WHERE PersonId = @PersonId";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExist = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                connection.Close();
            }
            return isExist;


        }*/


    }
}
