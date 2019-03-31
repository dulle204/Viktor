using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersData2.Repositories
{
  public  class IgracRepository:GenericRepository<Igrac>

    {
        public IgracRepository(PlayersContext context):base(context)
        {

        }


    }
    }
