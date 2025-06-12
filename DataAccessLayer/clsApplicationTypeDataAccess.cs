using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsApplicationTypeDataAccess
    {
      public  static bool FindApplicationType(byte ApplicationTypeId,ref string ApplicationTypeName
            ,ref double ApplicationTypeFee)
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from ApplicationTypes where ApplicationTypeId = @ApplicationTypeId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeId", ApplicationTypeId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    ApplicationTypeName = (string)reader["ApplicationTypeName"];
                    ApplicationTypeFee = (double)reader["ApplicationTypeFee"];

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


    }
}
