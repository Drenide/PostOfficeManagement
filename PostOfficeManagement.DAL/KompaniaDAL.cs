using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.DAL
{
    public class KompaniaDAL
    {
        public bool Insert(Kompania kompania)
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_InsertKompania", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = CommandType.StoredProcedure;

                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Emri", kompania.Emri);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Adresa", kompania.Adresa);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Qyteti", kompania.Qyteti);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@NumriKontaktues", kompania.NumriKontaktues);

                    DatabaseConfig.sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
