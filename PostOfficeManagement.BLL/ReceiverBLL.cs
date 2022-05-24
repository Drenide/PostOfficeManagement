using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.DAL;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.BLL
{
    public class ReceiverBLL
    {
        private ReceiverDAL _ReceiverDAL;

        public ReceiverBLL()
        {
            _ReceiverDAL = new ReceiverDAL();
        }
        public bool Delete(int id)
        {
            return _ReceiverDAL.Delete(id);
        }
        public bool Add(Receiver ra)
        {
            return _ReceiverDAL.Add(ra);
        }
        public DataSet GetAll()
        {
            return _ReceiverDAL.GetAll();
        }
    }
}
