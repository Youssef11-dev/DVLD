using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsInternationalLicenseDataAccess
    {

        static public bool FindInternationalLicenseById(int InternationalLicenseId,ref int ApplicationId,ref int DriverId
            ,ref int IssuedUsingLocalLicenseId,ref DateTime IssueDate,ref DateTime ExpirationDate,ref bool IsActive
            ,ref int CreatedByUserId
           )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from InternationalLicenses where InternationalLicenseId = @InternationalLicenseId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseId", InternationalLicenseId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    ApplicationId = (int)reader["ApplicationId"];
                    DriverId = (int)reader["DriverId"];
                    IssuedUsingLocalLicenseId = (int)reader["IssuedUsingLocalLicenseId"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserId = (int)reader["CreatedByUserId"];
                    

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
        public static int AddNewInternationalLicense(  int ApplicationId,  int DriverId
            ,  int IssuedUsingLocalLicenseId,  DateTime IssueDate,  DateTime ExpirationDate,  bool IsActive
            ,  int CreatedByUserId)
        {
            int InternationalLicenseId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into InternationalLicenses (ApplicationId,DriverId,IssuedUsingLocalLicenseId,IssueDate
                            ,ExpirationDate,IsActive,CreatedByUserId)
                            values (@ApplicationId,@DriverId,@ThirdIssuedUsingLocalLicenseIdName,@IssueDate
                            ,@ExpirationDate,@IsActive,@CreatedByUserId)
                            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
            command.Parameters.AddWithValue("@DriverId", DriverId);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseId", IssuedUsingLocalLicenseId);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);


          

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedId))
                {
                    InternationalLicenseId = insertedId;
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {

                connection.Close();
            }
            return InternationalLicenseId;

        }


        //Tested
        public static bool DeleteInternationalLicense(int InternationalLicenseId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Delete InternationalLicenses Where InternationalLicenseId = @InternationalLicenseId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseId", InternationalLicenseId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex) { return false; }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }


        
        public static bool UpdateInternationalLicense(int InternationalLicenseId,int ApplicationId, int DriverId
            , int IssuedUsingLocalLicenseId, DateTime IssueDate, DateTime ExpirationDate, bool IsActive
            , int CreatedByUserId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update InternationalLicenses 

                            set ApplicationId = @ApplicationId,
                            DriverId = @DriverId,
                            IssuedUsingLocalLicenseId = @IssuedUsingLocalLicenseId,
                            IssueDate = @IssueDate,
                            ExpirationDate = @ExpirationDate,
                            IsActive = @IsActive,
                            CreatedByUserId = @CreatedByUserId
                            where InternationalLicenseId = @InternationalLicenseId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
            command.Parameters.AddWithValue("@DriverId", DriverId);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseId", IssuedUsingLocalLicenseId);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@InternationalLicenseId", InternationalLicenseId);
            command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);
       
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
