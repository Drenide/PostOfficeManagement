using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.DAL;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.BLL
{
    public class SenderBLL
    {
        private SenderDAL _SenderDAL;

        public SenderBLL()
        {
            _SenderDAL = new SenderDAL();
        }
        public bool Delete(int id)
        {
            return _SenderDAL.Delete(id);
        }
        public bool Add(Sender ra)
        {
            return _SenderDAL.Add(ra);
        }
        public DataSet GetAll()
        {
            return _SenderDAL.GetAll();
        }
    }
}
