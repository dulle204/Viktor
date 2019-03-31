using PlayersData2;
using PlayersData2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersData2.Repositories
{
  public  class KlubRepository:GenericRepository<Klub>
    {
        public KlubRepository(PlayersContext context):base(context)
        {

        }

        public List<Klub> GetKlubaByLiga(int id)
        {
            var result = (from klubs in _context.Klubs
                          from ligas in _context.Ligas
                          where klubs.LigaID == ligas.ID && ligas.ID == id
                          select klubs).ToList();

            return result;

        }

        public List<Klub> GetKlubaByLiga(string name)
        {
            var result = (
                            from klubs in _context.Klubs
                            from ligas in _context.Ligas
                            where klubs.LigaID == ligas.ID && ligas.NazivLige == name
                            select klubs).ToList();

            return result;

        }
    }
}
