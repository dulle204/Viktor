using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players.ConsoleApp
{
    class Factory
    {
        public List<IIgraci> Instaces { get; set; }

        public Factory()
        {
            Instaces = new List<IIgraci>();
            Instaces.Add(new IgraciEU());
            Instaces.Add(new IgraciUS());
        }
        public IIgraci GetInstance(string par)
        {
            var instance = Instaces.FirstOrDefault(x => x.Region == par);
            return instance;
        }
    }
}
