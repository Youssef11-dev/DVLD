using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsTestTypeDataAccess
    {
        static public bool FindTestTypeById(byte TestTypeId,ref string TestTypeTitle,ref float TestTypeFee,ref string TestTypeDescription
        )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from People where TestTypeId = @TestTypeId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeId", TestTypeId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeFee = (float)reader["TestTypeFee"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
               
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


        static public bool FindTestTypeByTestTypeTitle(ref byte TestTypeId, string 
            TestTypeTitle, ref float TestTypeFee, ref string TestTypeDescription
        )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from People where TestTypeTitle = @TestTypeTitle";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeId", TestTypeId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    TestTypeId = (byte)reader["TestTypeId"];
                    TestTypeFee = (float)reader["TestTypeFee"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];

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





        public static bool UpdateLicenseClass( byte TestTypeId, string
            TestTypeTitle,  float TestTypeFee,  string TestTypeDescription)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update TestTypes 

                            set TestTypeTitle = @TestTypeTitle,
                            TestTypeFee = @TestTypeFee,
                            TestTypeDescription = @TestTypeDescription
                            where TestTypeId = @TestTypeId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeId", TestTypeId);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeFee", TestTypeFee);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
           

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
