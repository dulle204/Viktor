using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain
{
     public class KlubFactory : IKlubFactory
    {
        private List<IKlubService> Ins { get; set; }


        public KlubFactory()
        {
            Ins = new List<IKlubService>();



            Ins = new List<IKlubService>();
            Ins.Add(new KlubServiceEU());

        }

        public IKlubService GetInst(string par)
        {
            var instance = Ins.FirstOrDefault(x => x.Region == par);
            return instance;
        }
    }
}
