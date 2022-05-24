using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PostOfficeManagement.DAL;
using PostOfficeManagement.BO;


namespace PostOfficeManagement.BLL
{
    public class RegjistrimiKlientitBLL
    {
        private RegjistrimiKlientitDAL _RegjistrimiKlientitDAL;
          
        public RegjistrimiKlientitBLL()
        {
            _RegjistrimiKlientitDAL = new RegjistrimiKlientitDAL();
        }

        public RegjistrimiKlientit MerreKlientin(RegjistrimiKlientit useri)
        {
            return _RegjistrimiKlientitDAL.MerreKlientin(useri);
        }
        public bool Add(RegjistrimiKlientit rk)
        {
            return _RegjistrimiKlientitDAL.Insert(rk);
        }
        public DataSet GetAll()
        {
            return _RegjistrimiKlientitDAL.GetAll();
        }
        public bool Delete(int id)
        {
            return _RegjistrimiKlientitDAL.Delete(id);
        }
    }
}
