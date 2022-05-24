using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.DAL
{
    public class ReceiverDAL
    {
        public bool Add(Receiver Regreceiver)
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_InsertReceiver", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Emri", Regreceiver.Emri);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Adresa", Regreceiver.Adresa);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Qyteti", Regreceiver.Qyteti);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@NumriTelefonit", Regreceiver.NumriTelefonit);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Reference", Regreceiver.Reference);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@ShipmentType", Regreceiver.ShipmentType);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@PeshaProduktit", Regreceiver.PeshaProduktit);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Hapja", Regreceiver.Hapja);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Exchange", Regreceiver.Exchange);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Status", Regreceiver.Status);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@PershkrimiProduktit", Regreceiver.PershkrimiProduktit);
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
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_DeleteReceiver", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    //Stored procedure
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Id_Receiver", id);

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
                    DatabaseConfig.sqlDataAdapter.SelectCommand = new SqlCommand("usp_Marresi", DatabaseConfig.sqlConnection);
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
