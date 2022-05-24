using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PostOfficeManagement.DAL
{
    public class PorositeDAL
    {
        public DataSet GetAll()
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    DataSet ds = new DataSet();
                    DatabaseConfig.sqlDataAdapter = new SqlDataAdapter();
                    DatabaseConfig.sqlDataAdapter.SelectCommand = new SqlCommand("usp_GetAllReceivers", DatabaseConfig.sqlConnection);
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
