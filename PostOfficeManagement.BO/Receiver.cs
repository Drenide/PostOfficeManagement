using System;
using System.Collections.Generic;
using System.Text;

namespace PostOfficeManagement.BO
{
    public class Receiver : Base
    {
        public string Emri { get; set; }
        public string Adresa { get; set; }
        public string Qyteti { get; set; }
        public int NumriTelefonit { get; set; }
        public int Reference { get; set; }
        public string ShipmentType { get; set; }
        public int PeshaProduktit { get; set; }
        public string Hapja { get; set; }
        public string Exchange { get; set; }
        public string Status { get; set; }
        public string PershkrimiProduktit { get; set; }
    }
}
