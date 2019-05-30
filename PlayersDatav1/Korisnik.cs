namespace PlayersDatav1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Korisnik")]
    public partial class Korisnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Ulica { get; set; }

        [Required]
        [StringLength(50)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(10)]
        public string Rola { get; set; }
    }
}
