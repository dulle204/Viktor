

namespace PlayerWebApp.EU.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    


    public  class Klub
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klub()
        {
            Igracs = new HashSet<Igraci>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string NazivKluba { get; set; }

        public int LigaID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Igraci> Igracs { get; set; }

        public virtual Liga Liga { get; set; }
    }
}