using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsLicenseDataAccess
    {

        static public bool FindLicenseById(int licenseId,ref int ApplicationId,ref int DriverId,ref byte LicenseClass,
         ref  DateTime IssueDate,ref DateTime ExpirationDate,ref string Notes,ref decimal PaidFees,ref bool IsActive
            ,ref byte IssueReason,ref int CreatedByUserId)

        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from Licenses where licenseId = @licenseId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@licenseId", licenseId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    ApplicationId = (int)reader["ApplicationId"];
                    DriverId = (int)reader["DriverId"];
                    LicenseClass = (byte)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["EmExpirationDateail"];
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserId = (int)reader["CreatedByUserId"];
                    Notes = reader["Notes"] as string ?? string.Empty;
                   

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
        public static int AddNewLicense(  int ApplicationId,  int DriverId,  byte LicenseClass,
          DateTime IssueDate,  DateTime ExpirationDate,  string Notes,  decimal PaidFees,  bool IsActive
            ,  byte IssueReason,  int CreatedByUserId)
        {
            int LicenseId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into Licenses (ApplicationId,DriverId,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive
                            ,IssueReason,CreatedByUserId)
                            values (@ApplicationId,@DriverId,@LicenseClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive
                            ,@IssueReason,@CreatedByUserId)
                            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
            command.Parameters.AddWithValue("@DriverId", DriverId);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);


            if (Notes != string.Empty)
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            else
            {

                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
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
        public static bool DeletePerson(int LicenseId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Delete Licenses Where LicenseId = @LicenseId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseId", LicenseId);

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
        public static bool UpdatePerson(int LicenseId,int ApplicationId, int DriverId, byte LicenseClass,
          DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive
            , byte IssueReason, int CreatedByUserId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update People 

                            set ApplicationId = @ApplicationId,
                            DriverId = @DriverId,
                            LicenseClass = @LicenseClass,
                            IssueDate = @IssueDate,
                            ExpirationDate = @ExpirationDate,
                            Notes = @Notes,
                            PaidFees = @PaidFees,
                            IsActive = @IsActive,
                            IssueReason = @IssueReason,
                            CreatedByUserId = @CreatedByUserId
                            where LicenseId = @LicenseId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
            command.Parameters.AddWithValue("@DriverId", DriverId);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserId", CreatedByUserId);


            if (Notes != string.Empty)
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            else
            {

                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
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
