using System;
using System.Collections.Generic;
using System.Text;

namespace PostOfficeManagement.BO
{
    public class Base
    {
        public int Id { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int LUN { get; set; }
        public int LUB { get; set; }
        public DateTime LUD { get; set; }
    }
}
