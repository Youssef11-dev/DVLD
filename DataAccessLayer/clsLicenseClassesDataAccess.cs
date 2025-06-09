using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsLicenseClassesDataAccess
    {
        static public bool FindLicenseClassById(int LicenseClassId, ref string ClassName, ref string ClassDescription
           , ref byte MinimunAllowedAge, ref byte ValidityLength
           , ref float ClassFee
           )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from People where LicenseClassId = @LicenseClassId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassId", LicenseClassId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimunAllowedAge = (byte)reader["MinimunAllowedAge"];
                    ValidityLength = (byte)reader["ValidityLength"];
                    ClassFee = (float)reader["ClassFee"];

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

    
        static public bool FindLicenseClassByClassName(ref int LicenseClassId, string ClassName, ref string ClassDescription
           , ref byte MinimunAllowedAge, ref byte ValidityLength
           , ref float ClassFee
           )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from People where ClassName = @LicenseCClassNamelassId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    LicenseClassId = (int)reader["LicenseClassId"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimunAllowedAge = (byte)reader["MinimunAllowedAge"];
                    ValidityLength = (byte)reader["ValidityLength"];
                    ClassFee = (float)reader["ClassFee"];

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


    


        public static bool UpdateLicenseClass( int LicenseClassId, string ClassName,  string ClassDescription
           ,  byte MinimunAllowedAge,  byte ValidityLength
           ,  float ClassFee)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update LicenseClasses 

                            set ClassName = @ClassName,
                            ClassDescription = @ClassDescription,
                            MinimunAllowedAge = @MinimunAllowedAge,
                            ValidityLength = @ValidityLength,
                            ClassFee = @ClassFee
                            where LicenseClassId = @LicenseClassId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassId", LicenseClassId);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimunAllowedAge", MinimunAllowedAge);
            command.Parameters.AddWithValue("@ValidityLength", ValidityLength);
            command.Parameters.AddWithValue("@ClassFee", ClassFee);
           
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
