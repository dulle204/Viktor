using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerWebApp.EU.Models
{
    public class AddOrEditIgrac
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public int Visina { get; set; }

        public int Tezina { get; set; }

        public int KlubId { get; set; }

        public int DrzavaId { get; set; }
    }
}