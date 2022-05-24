using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.DAL;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.BLL
{
    public class RegjistrimiPunetoritBLL
    {
        private RegjistrimiPunetoritDAL _RegjistrimiPunetoritDAL;

        public RegjistrimiPunetoritBLL()
        {
            _RegjistrimiPunetoritDAL = new RegjistrimiPunetoritDAL();
        }
        public DataSet GetAll()
        {
            return _RegjistrimiPunetoritDAL.GetAll();
        }
        public bool Add(RegjistrimiPunetorit rk)
        {
            return _RegjistrimiPunetoritDAL.Add(rk);
        }

        public bool Delete(int id)
        {
            return _RegjistrimiPunetoritDAL.Delete(id);
        }
        

    }
}
