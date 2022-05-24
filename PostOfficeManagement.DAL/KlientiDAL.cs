using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.DAL
{
    public class KlientiDAL
    {
        public Klienti MerreKlientin(Klienti MerreKlientin)
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_MerrKlientin", DatabaseConfig.sqlConnection);
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
