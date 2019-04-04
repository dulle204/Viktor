using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersDatav1.UnitOfWork;
using PlayersDatav1.Repositories;
using PlayersDatav1;

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

        public void PostPlayers(Igrac igrac)
        {
            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {
   

                
                igrac.Ime = "Test1";
                igrac.Prezime = "test2";
                igrac.Tezina = 90;
                igrac.Visina = 192;
                igrac.Klub.NazivKluba = "Partizan";
                igrac.Drzava.NazivDrzave = "Srbija";

                if (igrac!=null)
                {
                    uow.IgracRepository.InsertIgrac(igrac);
                }

            }
        }

       public void PutPlayers(int id,Igrac igrac)
        {

        
        }
    }
}
