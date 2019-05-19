﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace rtest.Models
{
    public class PlayerModel
    {
       // [JsonProperty("id")]
        [JsonRequired]
        public int ID { get; set; }
       // [JsonProperty("ime")]
        //[JsonRequired]
        [StringLength(50)]
        public string  Ime{ get; set; }

       // [JsonProperty("prezime")]
        public string Prezime { get; set; }

       // [JsonProperty("visina")]
        public int Visina { get; set; }

       // [JsonProperty("tezina")]
        public int  Tezina{ get; set; }

        //[JsonProperty("klub_id")]
        public int KlubId { get; set; }

        //[JsonProperty("drzava_id")]
        public int DrzavaId { get; set; }

        public string Klub { get; set; }

        public string Drzava { get; set; }

        public string DrzavaKluba { get; set; }
    }
}