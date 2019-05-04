using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rtest.Models
{
    public class KlubModel
    {
        public int ID { get; set; }

        public string NazivKluba { get; set; }

        public int LigaID { get; set; }

        public string Liga { get; set; }

        public string Drzava { get; set; }
    }
}