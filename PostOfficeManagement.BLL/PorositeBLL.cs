using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PostOfficeManagement.DAL;

namespace PostOfficeManagement.BLL
{
    public class PorositeBLL
    {
        private PorositeDAL _Porosite;

        public PorositeBLL()
        {
            _Porosite = new PorositeDAL();
        }

        public DataSet GetAll()
        {
            return _Porosite.GetAll();
        }
    }
}
