using System;
using System.Collections.Generic;
using System.Text;
using PostOfficeManagement.DAL;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.BLL
{
    public class KlientiBLL
    {
        private KlientiDAL _KlientiDAL;
        public KlientiBLL()
        {
            _KlientiDAL = new KlientiDAL();
        }
        public Klienti MerreKlientin(Klienti useri)
        {
            return _KlientiDAL.MerreKlientin(useri);
        }
    }
}
