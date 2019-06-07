namespace PlayerWebApp.EU.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UsersModel : DbContext
    {
        public UsersModel()
            : base("name=UsersModel")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
