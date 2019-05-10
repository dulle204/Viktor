using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rtest.Models
{
    public class LigaModel
    {
        public int ID { get; set; }

        public string NazivLige { get; set; }

        public string Drzava { get; set; }

        public int DrzavaID { get; set; }
    }
}