using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static  class clsTestDataAccess
    {
        static public bool FindTestById(int TestId,ref byte TestTypeId,ref int ApplicationId,ref bool TestResult,
            ref decimal PaidFees,ref string Notes,ref DateTime TestDate,ref int CreatedByUser,
            ref bool IsLocked
       )
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from Tests where TestId = @TestId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestId", TestId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isExist = true;
                    TestTypeId = (byte)reader["TestTypeId"];
                    ApplicationId = (int)reader["ApplicationId"];
                    TestResult = (bool)reader["TestResult"];
                    PaidFees = (decimal)reader["PaidFees"];
                    TestDate = (DateTime)reader["TestDate"];
                    CreatedByUser = (int)reader["CreatedByUser"];
                    IsLocked = (bool)reader["IsLocked"];
                    Notes = reader["Notes"] as string?? string.Empty;
                    

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
      


        //Tested
        public static int AddNewTest(  byte TestTypeId,  int ApplicationId,  bool TestResult,
             decimal PaidFees,  string Notes,  DateTime TestDate,  int CreatedByUser,
             bool IsLocked)
        {
            int TestId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into Tests (TestTypeId,ApplicationId,TestResult,PaidFees,Notes,TestDate,CreatedByUser,IsLocked)
                            values (@TestTypeId,@ApplicationId,@TestResult,@PaidFees,@Notes,@TestDate,@CreatedByUser,@IsLocked)
                            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeId", TestTypeId);
            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@TestDate", TestDate);
            command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);


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
                    TestId = insertedId;
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {

                connection.Close();
            }
            return TestId;

        }


        //Tested
        public static bool DeleteTest(int TestId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Delete Tests Where TestId = @TestId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestId", TestId);

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
        public static bool UpdateTest(int TestId,byte TestTypeId, int ApplicationId, bool TestResult,
             decimal PaidFees, string Notes, DateTime TestDate, int CreatedByUser,
             bool IsLocked)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update Tests 

                            set TestTypeId = @TestTypeId,
                            ApplicationId = @ApplicationId,
                            TestResult = @TestResult,
                            PaidFees = @PaidFees,
                            TestDate = @TestDate,
                            CreatedByUser = @CreatedByUser,
                            IsLocked = @IsLocked
                            where TestId = @TestId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeId", TestTypeId);
            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@TestDate", TestDate);
            command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@TestId", TestId);


            if (Notes != "")
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
