using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDetainedLicenseDataAccess
    {
        static public bool FindDetainedLicenseById(int DetainedId,ref int LicenseId,ref DateTime DetainDate,ref decimal FineFees,
            ref int CreatedByUserId,ref bool IsReleased,ref DateTime ReleaseDate,ref int ReleasedByUserId,ref int ReleaseApplicationId
           )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from DetainedLicenses where DetainedId = @DetainedId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainedId", DetainedId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    LicenseId = (int)reader["LicenseId"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserId = (int)reader["CreatedByUserId"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleaseDate = reader["ReleaseDate"] as DateTime? ?? DateTime.MinValue;
                    ReleasedByUserId = reader["ReleasedByUserId"] as int? ?? -1;
                    ReleaseApplicationId = reader["ReleaseApplicationId"] as int? ?? -1;
                    

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
        static public bool FindDetainedLicenseByLicenseId(ref int DetainedId, int LicenseId, ref DateTime DetainDate, ref decimal FineFees,
           ref int CreatedByUserId, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserId, ref int ReleaseApplicationId
          )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from DetainedLicenses where LicenseId = @LicenseId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseId", LicenseId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    DetainedId = (int)reader["DetainedId"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserId = (int)reader["CreatedByUserId"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleaseDate = reader["ReleaseDate"] as DateTime? ?? DateTime.MinValue;
                    ReleasedByUserId = reader["ReleasedByUserId"] as int? ?? -1;
                    ReleaseApplicationId = reader["ReleaseApplicationId"] as int? ?? -1;


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





        public static int AddNewDetainedLicense( int LicenseId,  DateTime DetainDate,  decimal FineFees,
            int CreatedByUserId,  bool IsReleased,  DateTime ReleaseDate,  int ReleasedByUserId,  int ReleaseApplicationId)
        {
            int DetainedId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into DetainedLicenses (LicenseId,DetainDate,FineFees,CreatedByUserId,IsReleased,ReleaseDate
                        ,ReleasedByUserId,ReleaseApplicationId)
                            values (@LicenseId,@DetainDate,@FineFees,@CreatedByUserId,@IsReleased,@ReleaseDate
                            ,@ReleasedByUserId,@ReleaseApplicationId)
                            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseId", LicenseId);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
         


            if (ReleaseDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            }
            else
            {

                command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
            }
            if (ReleasedByUserId != -1)
            {
                command.Parameters.AddWithValue("@ReleasedByUserId", ReleasedByUserId);
            }
            else
            {

                command.Parameters.AddWithValue("@ReleasedByUserId", System.DBNull.Value);
            }
            if (ReleaseApplicationId != -1)
            {
                command.Parameters.AddWithValue("@ReleaseApplicationId", ReleaseApplicationId);
            }
            else
            {

                command.Parameters.AddWithValue("@ReleaseApplicationId", System.DBNull.Value);
            }


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedId))
                {
                    LicenseId = insertedId;
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {

                connection.Close();
            }
            return LicenseId;

        }


        //Tested
        public static bool DeleteDetainedLicense(int DetainedId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Delete DetainedLicenses Where DetainedId = @DetainedId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainedId", DetainedId);

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
        public static bool UpdateDetainedLicense(int DetainedId,int LicenseId, DateTime DetainDate, decimal FineFees,
            int CreatedByUserId, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserId, int ReleaseApplicationId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update DetainedLicenses 

                            set LicenseId = @LicenseId,
                            DetainDate = @DetainDate,
                            FineFees = @FineFees,
                            CreatedByUserId = @CreatedByUserId,
                            IsReleased = @IsReleased,
                            ReleaseDate = @ReleaseDate,
                            ReleasedByUserId = @ReleasedByUserId,
                            ReleaseApplicationId = @ReleaseApplicationId
                            where DetainedId = @DetainedId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainedId", DetainedId);
            command.Parameters.AddWithValue("@LicenseId", LicenseId);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);


            if (ReleaseDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            }
            else
            {

                command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
            }
            if (ReleasedByUserId != -1)
            {
                command.Parameters.AddWithValue("@ReleasedByUserId", ReleasedByUserId);
            }
            else
            {

                command.Parameters.AddWithValue("@ReleasedByUserId", System.DBNull.Value);
            }
            if (ReleaseApplicationId != -1)
            {
                command.Parameters.AddWithValue("@ReleaseApplicationId", ReleaseApplicationId);
            }
            else
            {

                command.Parameters.AddWithValue("@ReleaseApplicationId", System.DBNull.Value);
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


    }
}
