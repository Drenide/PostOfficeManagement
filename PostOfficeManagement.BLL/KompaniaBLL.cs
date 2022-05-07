using System.Data;
using PostOfficeManagement.DAL;
using PostOfficeManagement.BO;

namespace PostOfficeManagement.BLL
{
    public class KompaniaBLL
    {
        public KompaniaDAL _Kompania;

        public KompaniaBLL()
        {
            _Kompania = new KompaniaDAL();
        }

        public bool Add(Kompania kompania)
        {
            return _Kompania.Insert(kompania);
        }
    }
}
