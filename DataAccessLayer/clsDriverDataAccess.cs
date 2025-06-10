using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDriverDataAccess
    {
        static public bool FindDriverById(int DriverId,ref int PersonId,ref int CreatedByUserId
            ,ref DateTime CreatedDay)
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from Drivers where DriverId = @DriverId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverId", DriverId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    PersonId = (int)reader["PersonId"];
                    CreatedByUserId = (int)reader["CreatedByUserId"];
                    CreatedDay = (DateTime)reader["CreatedDay"]; 

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
        static public bool FindDriverByPersinId(ref int DriverId, int PersonId,ref int CreatedByUserId
            ,ref DateTime CreatedDay)
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from Drivers where PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    DriverId = (int)reader["DriverId"];
                    CreatedByUserId = (int)reader["CreatedByUserId"];
                    CreatedDay = (DateTime)reader["CreatedDay"];

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
        public static int AddNewDriver( int PersonId,  int CreatedByUserId
            ,  DateTime CreatedDay)
        {
            int DriverId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into Drivers (PersonId,CreatedByUserId,CreatedDay)
                            values (@PersonId,@CreatedByUserId,@CreatedDay)
                            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);
            command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);
            command.Parameters.AddWithValue("@CreatedDay", CreatedDay);
        



            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedId))
                {
                    DriverId = insertedId;
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
        public static bool DeleteDriver(int DriverId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Delete Drivers Where DriverId = @DriverId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverId", DriverId);

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
        public static bool UpdatePerson(int DriverId,int PersonId, int CreatedByUserId
            , DateTime CreatedDay)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update Drivers 

                            set PersonId = @PersonId,
                            CreatedByUserId = @CreatedByUserId,
                            CreatedDay = @CreatedDay
                            where DriverId = @DriverId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);
            command.Parameters.AddWithValue("@DriverId", DriverId);
            command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);
            command.Parameters.AddWithValue("@CreatedDay", CreatedDay);
         
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


    }
}
