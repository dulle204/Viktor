//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IgraciData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Igrac
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Visina { get; set; }
        public int Tezina { get; set; }
        public int KlubID { get; set; }
        public int DrzavaID { get; set; }
    
        public virtual Drzava Drzava { get; set; }
        public virtual Klub Klub { get; set; }
    }
}