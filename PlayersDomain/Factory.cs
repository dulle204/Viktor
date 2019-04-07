using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain
{
    public class Factory : IFactory
    {
        private List<IPlayerService> Instaces { get; set; }

        public Factory()
        {
            Instaces = new List<IPlayerService>();
            Instaces.Add(new PlayerServiceEU());
            Instaces.Add(new PlayerServiceUS());
        }
        public IPlayerService GetInstance(string par)
        {
            var instance = Instaces.FirstOrDefault(x => x.Region == par);
            return instance;
        }
    }
}
