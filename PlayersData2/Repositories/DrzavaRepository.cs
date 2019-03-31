using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersData2.Repositories
{
   public class DrzavaRepository:GenericRepository<Drzava>
    {
        public DrzavaRepository(PlayersContext context) : base(context)
        {
        }
    }
}
