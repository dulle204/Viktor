using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersData1
{
   public class Klub
    {
        public int ID { get; set; }
        public string NazivKluba { get; set; }
        public int LigaID { get; set; }

        public Liga Lige { get; set; }
        public ICollection<Igrac> Igraci { get; set; }
    }
}
