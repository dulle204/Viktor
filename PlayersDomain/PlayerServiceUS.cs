using PlayersDatav1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain
{
    public class PlayerServiceUS : IPlayerService
    {
        public string Region { get; } = "US";

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
                    double feet = (item.Visina / 2.54) / 12;
                    double inches = (item.Visina / 2.54) - ((int)feet * 12);

                    model = new IgracDomainModel()
                    {
                        Ime = item.Ime,
                        Drzava = uow.DrzavaRepository.GetByID(item.DrzavaID).NazivDrzave,
                        Prezime = item.Prezime,
                        Klub = klub.NazivKluba,
                        DrzavaKLuba = uow.DrzavaRepository.GetByID(liga.DrzavaID).NazivDrzave,
                        Tezina = Convert.ToInt32(item.Tezina / 0.45),
                        Visina = $"{feet}' {inches}\""
                    };

                    list.Add(model);
                }
            }

            return list;
        }
    }
}
