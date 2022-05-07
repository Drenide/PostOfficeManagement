using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System;

namespace PostOfficeManagement.DAL
{
    public class LoginDAL
    {
        public DataSet GetAll()
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    DatabaseConfig.sqlDataAdapter = new SqlDataAdapter("usp_GetInformation", DatabaseConfig.sqlConnection);
                    DataSet ds = new DataSet();
                    DatabaseConfig.sqlDataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
