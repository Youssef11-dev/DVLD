using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsLocalDrivingApplicationLicenseDataAccess
    {

        static public bool FindApplicationByLocalApplicationId(int LocalApplicationId,ref int ApplicationId
            ,ref byte TestPasses,ref byte LicenseClassId
           )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationId = @LocalDrivingLicenseApplicationId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationId", LocalApplicationId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    ApplicationId = (int)reader["ApplicationId"];
                    TestPasses = (byte)reader["TestPasses"];
                    LicenseClassId = (byte)reader["LicenseClassId"];

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

        
        static public bool FindLocalApplicationByApplicationId(ref int LocalApplicationId, int ApplicationId
            , ref byte TestPasses, ref byte LicenseClassId
           )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationId = @LocalDrivingLicenseApplicationId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    LocalApplicationId = (int)reader["LocalApplicationId"];
                    TestPasses = (byte)reader["TestPasses"];
                    LicenseClassId = (byte)reader["LicenseClassId"];

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


       
        public static int AddNewLocalApplication(int ApplicationId,byte TestPasses,byte LicenseClassId)
        {
            int LocalApplicationId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into LocalDrivingLicenseApplications (ApplicationId,TestPasses,LicenseClassId)
                            values (@ApplicationId,@TestPasses,@LicenseClassId)
                            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
            command.Parameters.AddWithValue("@TestPasses", TestPasses);
            command.Parameters.AddWithValue("@LicenseClassId", LicenseClassId);
            



            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedId))
                {
                    LocalApplicationId = insertedId;
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
            return LocalApplicationId;

        }


        
        public static bool DeleteLocalDrivingApplication(int LocalApplicationId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Delete LocalDrivingApplication Where LocalDrivingLicenseApplicationId = @LocalDrivingLicenseApplicationId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationId", LocalApplicationId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex) { return false; }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }

        public static bool UpdateLocalApplication(int LocalApplicationId,int ApplicationId, byte TestPasses, byte LicenseClassId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update LocalDrivingLicenseApplications 

                            set ApplicationId = @ApplicationId,
                            TestPasses = @TestPasses,
                            LicenseClassId = @LicenseClassId
                            where LocalDrivingLicenseApplicationId = @LocalDrivingLicenseApplicationId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationId", LocalApplicationId);
            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
            command.Parameters.AddWithValue("@TestPasses", TestPasses);
            command.Parameters.AddWithValue("@LicenseClassId", LicenseClassId);


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
