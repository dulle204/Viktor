
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PlayerWebApp.EU.Models
{



    public  class Liga
    {


        public int ID { get; set; }

        public string NazivLige { get; set; }

        public int DrzavaID { get; set; }

        public string Drzava { get; set; }

      
    }
}