using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerWebApp.EU.Models
{
    public class AddOrEditIgrac
    {
        public int ID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public int Visina { get; set; }

        public int Tezina { get; set; }

        //[JsonProperty("klub_id")]
        public int KlubId { get; set; }

        [JsonProperty("drzava_id")]
        public int DrzavaId { get; set; }

        public string Klub { get; set; }
    }
}