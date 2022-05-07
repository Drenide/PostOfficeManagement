using System;
using System.Collections.Generic;
using System.Text;

namespace PostOfficeManagement.BO
{
    public class Kompania : Base
    {
        public string Emri { get; set; }
        public string Adresa { get; set; }
        public string Qyteti { get; set; }
        public string NumriKontaktues { get; set; }
    }
}
