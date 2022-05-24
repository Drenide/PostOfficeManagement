using System;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.DAL
{
    public class RegjistrimiKlientitDAL
    {
        public bool Insert(RegjistrimiKlientit RegClient)
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_InsertKlienti", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Name", RegClient.Name);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Password", RegClient.Password);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Emri", RegClient.Emri);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Mbiemri", RegClient.Mbiemri);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Telefon", RegClient.Telefon);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Adresa", RegClient.Adresa);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Qyteti", RegClient.Qyteti);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@FacebookLink", RegClient.FacebookLink);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Role_Id", RegClient.Role_Id);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@InsertBy", RegClient.InsertBy);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@InsertDate", DateTime.Now);

                    DatabaseConfig.sqlCommand.ExecuteNonQuery();
                    
                }
                return true;

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
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_DeleteKlient", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    //Stored procedure
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Id_Klienti", id);

                    DatabaseConfig.sqlCommand.ExecuteNonQuery();

                }
                return true;

            }
            catch (Exception e)
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
                    DatabaseConfig.sqlDataAdapter.SelectCommand = new SqlCommand("usp_GetAllClients", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlDataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
        public RegjistrimiKlientit MerreKlientin(RegjistrimiKlientit MerreKlientin)
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_MerreKlientin", DatabaseConfig.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = MerreKlientin.Name;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = MerreKlientin.Password;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MerreKlientin.Role_Id = int.Parse(dt.Rows[0]["Role_Id"].ToString());
                    }
                    cmd.ExecuteNonQuery();
                    return MerreKlientin;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
