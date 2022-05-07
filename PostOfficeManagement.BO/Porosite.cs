using System;
using System.Collections.Generic;
using System.Text;

namespace PostOfficeManagement.BO
{
    public class Porosite : Base
    {
        public string Kompania { get; set; }
        public string Emri { get; set; }
        public string Qyteti { get; set; }
        public string Adresa { get; set; }
        public DateTime DataMarrjes { get; set; }
        public decimal PagesaPerKlientin { get; set; }


    }
}
