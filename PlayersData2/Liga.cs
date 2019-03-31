namespace PlayersData2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Liga")]
    public partial class Liga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Liga()
        {
            Klubs = new HashSet<Klub>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string NazivLige { get; set; }

        public int DrzavaID { get; set; }

        public virtual Drzava Drzava { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Klub> Klubs { get; set; }
    }
}
