using PlayersData2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players.ConsoleApp
{
    class IgraciEU : IIgraci
    {
        public string Region { get; } = "EU";

        public List<Igrac> Get()
        {
            List<Igrac> igraci = new List<Igrac>();
            Igrac igrac = new Igrac()
            {
                Ime = "asd",
                Prezime = "qwe",
                Tezina = 80.ToString(),
                Visina = 180.ToString()
            };
            igraci.Add(igrac);
            return igraci;
        }
    }
}
