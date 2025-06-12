using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsLicenseClassDataAccess
    {
        static public bool FindLicenseClassById(int LicenseClassId, ref string ClassName, ref string ClassDescription
           , ref byte MinimumAllowedAge, ref byte ValidityLength
           , ref double ClassFees
           )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from LicenseClasses where LicenseClassId = @LicenseClassId";

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
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    ValidityLength = (byte)reader["ValidityLength"];
                    ClassFees = (double)reader["ClassFees"];

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

    
        static public bool FindLicenseClassByClassName(ref byte LicenseClassId, string ClassName, ref string ClassDescription
           , ref byte MinimumAllowedAge, ref byte ValidityLength
           , ref double ClassFees
           )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from LicenseClasses where ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    LicenseClassId = (byte)reader["LicenseClassId"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    ValidityLength = (byte)reader["ValidityLength"];
                    ClassFees = (double)reader["ClassFees"];

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
           ,  byte MinimumAllowedAge,  byte ValidityLength
           ,  double ClassFees)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update LicenseClasses 

                            set ClassName = @ClassName,
                            ClassDescription = @ClassDescription,
                            MinimumAllowedAge = @MinimumAllowedAge,
                            ValidityLength = @ValidityLength,
                            ClassFees = @ClassFees
                            where LicenseClassId = @LicenseClassId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassId", LicenseClassId);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@ValidityLength", ValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
           
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
