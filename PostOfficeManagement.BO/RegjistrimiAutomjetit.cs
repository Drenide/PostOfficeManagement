using System;
using System.Collections.Generic;
using System.Text;

namespace PostOfficeManagement.BO
{
    public class RegjistrimiAutomjetit : Base
    {
        public string Prodhuesi { get; set; }
        public string Modeli { get; set; }
        public string Viti_Prodhimit { get; set; }
        public int Motorri { get; set; }
        public string Pesha { get; set; }
        public string LlojiKarburantit { get; set; }
        public string PeshaMaksimale { get; set; }
    }
}
