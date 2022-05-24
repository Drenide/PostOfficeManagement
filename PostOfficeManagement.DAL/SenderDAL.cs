using System;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.DAL
{
    public class SenderDAL
    {
        public bool Add(Sender sender)
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_InsertSender", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Emri", sender.Emri);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Adresa", sender.Adresa);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Qyteti", sender.Qyteti);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@NumriKontaktues", sender.NumriKontaktues);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@InsertBy", 1);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@InsertDate", DateTime.Now);

                    DatabaseConfig.sqlCommand.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_DeleteSender", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    //Stored procedure
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Id_Sender", id);

                    DatabaseConfig.sqlCommand.ExecuteNonQuery();

                }
                return true;

            }
            catch
            {
                return false;
            }
        }
        public DataSet GetAll()
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    DataSet ds = new DataSet();
                    DatabaseConfig.sqlDataAdapter = new SqlDataAdapter();
                    DatabaseConfig.sqlDataAdapter.SelectCommand = new SqlCommand("usp_GetAllSenders", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlDataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
