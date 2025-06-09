using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsPersonDataAccess
    {
        //Tested
        static public bool FindPersonById(int PersonId, ref string FirstName, ref string SecondName
            , ref string ThirdName, ref string FourthName
            , ref string NationalNumber, ref char gender, ref DateTime DateOfBirth, ref int CountryId, ref string phone,
            ref string Email, ref string ImagePath, ref string Address
            )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from People where PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    FourthName = (string)reader["FourthName"];
                    Email = (string)reader["Email"];
                    phone = (string)reader["Phone"];
                    gender = (char)reader["Gender"].ToString()[0];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    NationalNumber = (string)reader["NationalNumber"];
                    ImagePath = reader["ImagePath"] as string ?? string.Empty;
                    CountryId = (int)reader["CountryId"];
                    Address = reader["Address"] as string ?? string.Empty;

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

        //Tested
        static public bool FindPersonByNationalNumber(ref int PersonId, ref string FirstName, ref string SecondName
          , ref string ThirdName, ref string FourthName
          ,  string NationalNumber, ref char gender, ref DateTime DateOfBirth, ref int CountryId, ref string phone,
          ref string Email, ref string ImagePath, ref string Address
          )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from People where NationalNumber = @NationalNumber";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    PersonId = (int)reader["PersonId"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    FourthName = (string)reader["FourthName"];
                    Email = (string)reader["Email"];
                    phone = (string)reader["Phone"];
                    gender = (char)reader["Gender"].ToString()[0];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    ImagePath = reader["ImagePath"] as string ?? string.Empty;
                    CountryId = (int)reader["CountryId"];
                    Address = reader["Address"] as string ?? string.Empty;

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


        //Tested
        public static int AddNewPerson(string FirstName, string SecondName
           , string ThirdName, string FourthName
           , string NationalNumber, char Gender, DateTime DateOfBirth, int CountryId, string Phone,
            string Email, string ImagePath, string Address)
        {
            int PersonId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into People (FirstName,SecondName,ThirdName,FourthName,NationalNumber,Gender,DateOfBirth,CountryId
                            ,Phone,Email,ImagePath,Address)
                            values (@FirstName,@SecondName,@ThirdName,@FourthName,@NationalNumber,@Gender,@DateOfBirth,@CountryId
                            ,@Phone,@Email,@ImagePath,@Address)
                            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@FourthName", FourthName);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryId", CountryId);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);


            if (Address != string.Empty)
            {
                command.Parameters.AddWithValue("@Address", Address);
            }
            else
            {

                command.Parameters.AddWithValue("@Address", System.DBNull.Value);
            }
            if (ImagePath != string.Empty)
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {

                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedId))
                {
                    PersonId = insertedId;
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {

                connection.Close();
            }
            return PersonId;

        }


        //Tested
        public static bool DeletePerson(int PersonId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Delete People Where PersonId = @PersonId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex) { return false; }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }


        //Tested
        public static bool UpdatePerson(int PersonId, string FirstName, string SecondName
             , string ThirdName, string FourthName
             , string NationalNumber, char Gender, DateTime DateOfBirth, int CountryId, string Phone,
              string Email, string ImagePath, string Address)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update People 

                            set FirstName = @FirstName,
                            SecondName = @SecondName,
                            ThirdName = @ThirdName,
                            FourthName = @FourthName,
                            NationalNumber = @NationalNumber,
                            Gender = @Gender,
                            DateOfBirth = @DateOfBirth,
                            CountryId = @CountryId,
                            Phone = @Phone,
                            Email = @Email,
                            ImagePath = @ImagePath,
                            Address = @Address
                            where PersonId = @PersonId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@FourthName", FourthName);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@CountryId", CountryId);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            if (Address != "")
            {
                command.Parameters.AddWithValue("@Address", Address);
            }
            else
            {
                command.Parameters.AddWithValue("@Address", System.DBNull.Value);
            }
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
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




        public static DataTable ListAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT        People.PersonId, People.FirstName, People.SecondName, People.ThirdName,
            People.FourthName, People.NationalNumber, People.Gender, People.DateOfBirth, Countries.CountryName,
            People.Phone, People.Email,                      People.ImagePath, People.Address FROM    
            People INNER JOIN                     Countries ON People.CountryId = Countries.CountryID";
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


        //tested
        public static bool isPersonExist(string NationalNumber)
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT Found=1 FROM People WHERE NationalNumber = @NationalNumber";

            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@NationalNumber",NationalNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExist = reader.HasRows;
                reader.Close();
            }
            catch(Exception ex) 
            {
                return false;
            }finally {

                connection.Close(); 
            }
            return isExist;


        }

        //tested
        public static bool isPersonExist(int PersonId)
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT Found=1 FROM People WHERE PersonId = @PersonId";

            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonId",PersonId);
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
    }
}

