using System;
using System.Collections.Generic;
using System.Text;

namespace PostOfficeManagement.BO
{
    public class RegjistrimiPunetorit : Base
    {
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public DateTime Datelindja { get; set; }
        public int NumriPersonal { get; set; }
        public string DL { get; set; }
        public string PatentShoferi { get; set; }
        public string KategoriaPatentes { get; set; }
        public DateTime PunesuarPrej { get; set; }
        public DateTime DeriMe { get; set; }
    }
}
