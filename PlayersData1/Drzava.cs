using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersData1
{
  public  class Drzava
    {
        public int ID { get; set; }
        public string NazivDrzave { get; set; }

        public virtual ICollection<Igrac> Igraci { get; set; }
        public virtual ICollection<Liga> Lige { get; set; }
    }
}
