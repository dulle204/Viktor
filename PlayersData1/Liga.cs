using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersData1
{
   public class Liga
    {
        public int ID { get; set; }
        public string NazivLige { get; set; }
        public int DrzavaID { get; set; }

        public Drzava Drzave { get; set; }

        public ICollection<Igrac> Igraci { get; set; }
    }
}
