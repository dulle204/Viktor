using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDatav1.Repositories
{
     public class DrzavaRepository : GenericRepository<Drzava> ,IDrzavaRepository
    {
        public DrzavaRepository(PlayersContext context) : base(context)
        {
        }
    }
}
