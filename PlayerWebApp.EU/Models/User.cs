namespace PlayerWebApp.EU.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string Address { get; set; }
    }
}
