using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.BO;
using PostOfficeManagement.DAL;

namespace PostOfficeManagement.BLL
{
    public class RegjistrimiAutomjetitBLL
    {
        private RegjistrimiAutomjetitDAL _RegjistrimiAutomjetitDAL;

        public RegjistrimiAutomjetitBLL()
        {
            _RegjistrimiAutomjetitDAL = new RegjistrimiAutomjetitDAL();
        }

        public bool Add(RegjistrimiAutomjetit ra)
        {
            return _RegjistrimiAutomjetitDAL.Insert(ra);
        }
        public DataSet GetAll()
        {
            return _RegjistrimiAutomjetitDAL.GetAll();
        }
        public bool Delete(int id)
        {
            return _RegjistrimiAutomjetitDAL.Delete(id);
        }
        public bool Update(RegjistrimiAutomjetit ra)
        {
            return _RegjistrimiAutomjetitDAL.Update(ra);
        }
    }
}
