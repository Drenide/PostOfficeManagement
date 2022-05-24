using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.DAL
{
    public class UsersDAL
    {
        public Users GetUsers(Users useri)
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_GetAllUsers", DatabaseConfig.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = useri.Name;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = useri.Password;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count > 0)
                    {
                        useri.Role_Id = int.Parse(dt.Rows[0]["Role_Id"].ToString());
                    }
                    cmd.ExecuteNonQuery();
                    return useri;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
