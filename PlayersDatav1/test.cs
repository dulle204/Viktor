namespace PlayersDatav1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class test : DbContext
    {
        public test()
            : base("name=DbContextTest")
        {
        }

        public virtual DbSet<Drzava> Drzavas { get; set; }
        public virtual DbSet<Igrac> Igracs { get; set; }
        public virtual DbSet<Klub> Klubs { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }
        public virtual DbSet<Liga> Ligas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>()
                .HasMany(e => e.Igracs)
                .WithRequired(e => e.Drzava)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Drzava>()
                .HasMany(e => e.Ligas)
                .WithRequired(e => e.Drzava)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klub>()
                .HasMany(e => e.Igracs)
                .WithRequired(e => e.Klub)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Rola)
                .IsFixedLength();

            modelBuilder.Entity<Liga>()
                .HasMany(e => e.Klubs)
                .WithRequired(e => e.Liga)
                .WillCascadeOnDelete(false);
        }
    }
}
