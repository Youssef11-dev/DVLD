using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsApplicationDataAccess
    {
        static public bool FindApplicationById(int ApplicationId,ref byte ApplicationType,ref DateTime ApplicationDate,
            ref int ApplicantId,ref byte ApplicationStatus,ref double ApplicationFee,ref int CreatedByUser
            )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Select * from Applications where ApplicationId = @ApplicationId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
            

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {
                    ApplicationType = (byte)reader["ApplicationType"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicantId = (int)reader["ApplicantId"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    ApplicationFee = (double)reader["PaidFees"];
                    CreatedByUser = (int)reader["CreatedByUser"];
                    isExist = true;

                }
            }
            catch (Exception ex) { return false; }
            finally {
                connection.Close();
            }
            return isExist;

        }



        public static int AddNewApplication(byte ApplicationType,DateTime ApplicationDate,int ApplicantId, byte ApplicationStatus
            ,double PaidFees,int CreatedByUser)
        {
            int ApplicationId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into Applications (ApplicationType,ApplicationDate,ApplicantId,ApplicationStatus,PaidFees,CreatedByUser)
                            values (@ApplicationType,@ApplicationDate,@ApplicantId,@ApplicationStatus,@PaidFees,@CreatedByUser)
                            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationType", ApplicationType);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicantId", ApplicantId);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);
           


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedId))
                {
                    ApplicationId = insertedId;
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
            return ApplicationId;

        }

        public static bool DeleteApplication(int ApplicationId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Delete Applications Where ApplicationId = @ApplicationId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex) { return false; }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }
       




    }
}
