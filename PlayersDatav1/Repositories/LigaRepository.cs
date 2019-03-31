using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDatav1.Repositories
{
    public class LigaRepository : GenericRepository<Liga>
    {
        public LigaRepository(PlayersContext context) : base(context)
        {

        }

        public List<Liga> GetLigaByDrzava(int id)
        {
            var result = (from ligas in _context.Ligas
                          from drzavas in _context.Drzavas
                          where ligas.DrzavaID == drzavas.ID && drzavas.ID == id
                          select ligas).ToList();

            return result;

        }

        public List<Liga> GetLigaByDrzava(string name)
        {
            var result = (
                from ligas in _context.Ligas
                from drzavas in _context.Drzavas
                where ligas.DrzavaID == drzavas.ID && drzavas.NazivDrzave == name
                select ligas).ToList();

            return result;

        }

    }
}
