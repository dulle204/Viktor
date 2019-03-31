using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersData2;

namespace Players.ConsoleApp
{
    class IgraciUS : IIgraci
    {
        public string Region { get; } = "USA";

        public List<Igrac> Get()
        {
            List<Igrac> igraci = new List<Igrac>();
            Igrac igrac = new Igrac()
            {
                Ime = "asd",
                Prezime = "qwe",
                Tezina = (80/0.45).ToString(),
                Visina = (180*0.0328).ToString()
            };
            igraci.Add(igrac);

            return igraci;
        }
    }
}
