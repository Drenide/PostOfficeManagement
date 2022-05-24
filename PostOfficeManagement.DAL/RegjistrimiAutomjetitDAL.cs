using System;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.DAL
{
    public class RegjistrimiAutomjetitDAL
    {
        public bool Insert(RegjistrimiAutomjetit RegVehicle)
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_InsertAutomjeti", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Prodhuesi", RegVehicle.Prodhuesi);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Modeli", RegVehicle.Modeli);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Viti_Prodhimit", RegVehicle.Viti_Prodhimit);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Motorri", RegVehicle.Motorri);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Pesha", RegVehicle.Pesha);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@LlojiKarburantit", RegVehicle.LlojiKarburantit);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@PeshaMaksimale", RegVehicle.PeshaMaksimale);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@InsertBy", 1);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@InsertDate", DateTime.Now);

                    DatabaseConfig.sqlCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch 
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
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_DeleteAutomjet", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    //Stored procedure
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Id_Automjeti", id);

                    DatabaseConfig.sqlCommand.ExecuteNonQuery();

                }
                return true;

            }
            catch 
            {
                return false;
            }
        }
        public bool Update(RegjistrimiAutomjetit ra)
        {
            if (ra.Id > 0)
            {
                try
                {
                    using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                    {
                        DatabaseConfig.sqlConnection.Open();
                        DatabaseConfig.sqlCommand = new SqlCommand("usp_UpdateAutomjet", DatabaseConfig.sqlConnection);
                        DatabaseConfig.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Id_Automjeti", ra.Id);
                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Prodhuesi", ra.Prodhuesi);
                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Motorri", ra.Motorri);
                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Viti_Prodhimit", ra.Viti_Prodhimit);
                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Motorri", ra.Motorri);
                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Pesha", ra.Pesha);
                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@LlojiKarburantit", ra.LlojiKarburantit);
                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@PeshaMaksimale", ra.PeshaMaksimale);
                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@LUD", DateTime.Now);
                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@LUN", 1);
                        DatabaseConfig.sqlCommand.Parameters.AddWithValue("@LUB", 1);

                        DatabaseConfig.sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
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
                    DatabaseConfig.sqlDataAdapter.SelectCommand = new SqlCommand("usp_GetAllVehicles", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlDataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch
            {

                return null;
            }
        }
    }

}
