using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerWebApp.EU.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=UserModel")
        {
        }
    }
}