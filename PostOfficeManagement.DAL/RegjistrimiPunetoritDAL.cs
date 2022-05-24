using System;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.DAL
{
    public class RegjistrimiPunetoritDAL
    {
        public bool Add(RegjistrimiPunetorit RegEmployee)
        {
            try
            {
                using (DatabaseConfig.sqlConnection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    DatabaseConfig.sqlConnection.Open();
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_InsertPunetori", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = CommandType.StoredProcedure;

                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Emri", RegEmployee.Emri);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Mbiemri", RegEmployee.Mbiemri);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Datelindja", RegEmployee.Datelindja);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@NumriPersonal", RegEmployee.NumriPersonal);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@DL", RegEmployee.DL);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@PatentShoferi", RegEmployee.PatentShoferi);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@KategoriaPatentes", RegEmployee.KategoriaPatentes);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@PunesuarPrej", RegEmployee.PunesuarPrej);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@DeriMe", RegEmployee.DeriMe);
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@InsertBy", RegEmployee.InsertBy);
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
                    DatabaseConfig.sqlCommand = new SqlCommand("usp_DeletePunetori", DatabaseConfig.sqlConnection);
                    DatabaseConfig.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    //Stored procedure
                    DatabaseConfig.sqlCommand.Parameters.AddWithValue("@Id_Punetori", id);

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
                    DatabaseConfig.sqlDataAdapter.SelectCommand = new SqlCommand("usp_GetAllEmployeers", DatabaseConfig.sqlConnection);
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
