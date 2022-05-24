using System;
using System.Collections.Generic;
using System.Text;

namespace PostOfficeManagement.BO
{
    public class Klienti
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role_Id { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public int Telefon { get; set; }
        public string Adresa { get; set; }
        public string Qyteti { get; set; }
        public string FacebookLink { get; set; }
    }
}
