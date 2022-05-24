using System;
using System.Collections.Generic;
using System.Text;

namespace PostOfficeManagement.BO
{
    public class RegjistrimiAutomjetit : Base
    {
        public string Prodhuesi { get; set; }
        public string Modeli { get; set; }
        public DateTime Viti_Prodhimit { get; set; }
        public int Motorri { get; set; }
        public int Pesha { get; set; }
        public string LlojiKarburantit { get; set; }
        public int PeshaMaksimale { get; set; }
    }
}
