namespace PlayersData2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Igrac")]
    public partial class Igrac
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Ime { get; set; }

        [Required]
        [StringLength(60)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(20)]
        public string Visina { get; set; }

        [Required]
        [StringLength(20)]
        public string Tezina { get; set; }

        public int KlubID { get; set; }

        public int DrzavaID { get; set; }

        public virtual Drzava Drzava { get; set; }

        public virtual Klub Klub { get; set; }
    }
}
