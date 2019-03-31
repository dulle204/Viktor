using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDatav1
{
    public interface IPlayersContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        void Dispose();

        DbSet<Igrac> Igracs { get; set; }
        DbSet<Klub> Klubs { get; set; }
        DbSet<Liga> Ligas { get; set; }
        DbSet<Drzava> Drzavas { get; set; }
    }
}
