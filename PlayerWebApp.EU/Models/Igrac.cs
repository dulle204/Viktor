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

        public string Visina { get; set; }

        public int Tezina { get; set; }

        public string Drzava { get; set; }

        public string Klub { get; set; }

        public string DrzavaKluba { get; set; }

        public int KlubID { get; set; }

        public int DrzavaID { get; set; }
    }
}