using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersDatav1.UnitOfWork;

namespace PlayersDomain
{
    public class PlayerServiceEU : IPlayerService
    {
        public string Region { get; } = "EU";

        public List<IgracDomainModel> GetPlayers()
        {
            List<IgracDomainModel> list = new List<IgracDomainModel>();

            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {
                var igraci = uow.IgracRepository.Get();
                IgracDomainModel model = null;
                foreach (var item in igraci)
                {
                    var klub = uow.KlubRepository.GetByID(item.KlubID);
                    var liga = uow.LigaRepository.GetByID(klub.LigaID);

                    model = new IgracDomainModel()
                    {
                        Ime = item.Ime,
                        Drzava = uow.DrzavaRepository.GetByID(item.DrzavaID).NazivDrzave,
                        Prezime = item.Prezime,
                        Klub = klub.NazivKluba,
                        DrzavaKLuba = uow.DrzavaRepository.GetByID(liga.DrzavaID).NazivDrzave,
                        Tezina = item.Tezina,
                        Visina = item.Visina.ToString()
                    };

                    list.Add(model);
                }
            }
            
            return list;
        }
    }
}
