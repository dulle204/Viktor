using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersData1
{
  public  class Igrac
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Visina { get; set; }
        public string Tezina { get; set; }
       
        public int KlubID { get; set; }
        public int DrzavaID { get; set; }


        public Klub Klubov { get; set; }
        public Drzava Drzava { get; set; }


    }
}
