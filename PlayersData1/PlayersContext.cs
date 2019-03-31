using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersData1
{
   public class PlayersContext: DbContext
    {
        public PlayersContext()
            :base("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Players;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
        
        public DbSet<Igrac> Igraci { get; set; }
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Liga> Lige { get; set; }
        public DbSet<Klub> Klubovi { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Drzava>().HasMany(x => x.Lige);

            modelBuilder.Entity<Liga>().hA
        }
    }
}
