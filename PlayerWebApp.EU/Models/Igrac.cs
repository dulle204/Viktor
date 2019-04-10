using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerWebApp.EU.Models
{
    public class Igrac
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public int Visina { get; set; }

        public int Tezina { get; set; }

        public int KlubID { get; set; }

        public int DrzavaID { get; set; }

     public Drzava Drzava { get; set; }

     public Klub Klub { get; set; }
    }
}