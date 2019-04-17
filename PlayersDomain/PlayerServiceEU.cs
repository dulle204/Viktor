using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersDatav1.UnitOfWork;
using PlayersDatav1.Repositories;
using PlayersDatav1;
using PlayersDomain.DomainModels;

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
                        ID = item.ID,
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



        public IgracDomainModel GetPlayersByID(int id)
        {
            IgracDomainModel igrac = new IgracDomainModel();

            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {
                var igracg = uow.IgracRepository.Get(x => x.ID == id).FirstOrDefault();
                IgracDomainModel model = null;

                {
                    var klub = uow.KlubRepository.GetByID(igracg.KlubID);
                    var liga = uow.LigaRepository.GetByID(klub.LigaID);

                    model = new IgracDomainModel()
                    {
                        ID = igracg.ID,
                        Ime = igracg.Ime,
                        Drzava = uow.DrzavaRepository.GetByID(igracg.DrzavaID).NazivDrzave,
                        Prezime = igracg.Prezime,
                        Klub = klub.NazivKluba,
                        DrzavaKLuba = uow.DrzavaRepository.GetByID(liga.DrzavaID).NazivDrzave,
                        Tezina = igracg.Tezina,
                        Visina = igracg.Visina.ToString()
                    };


                }
            }


            return igrac;
        }





        public void AddPlayer(AddPlayerModel igrac)
        {
            using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
            {
                Igrac noviIgrac = new Igrac
                {
                    Ime = igrac.Ime,
                    Prezime = igrac.Prezime,
                    Tezina = igrac.Tezina,
                    Visina = igrac.Visina,
                    KlubID = igrac.KlubId,
                    DrzavaID = igrac.DrzavaId
                };

                if (noviIgrac != null)
                {
                    uow.IgracRepository.Insert(noviIgrac);
                    uow.Save();
                }
            }
        }

        public void UpdatePlayer(int id, AddPlayerModel igrac)
        {
            using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
            {
                var izmenjenIgrac = uow.IgracRepository.Get(x => x.ID == id).FirstOrDefault();
                izmenjenIgrac.Ime = igrac.Ime;
                izmenjenIgrac.KlubID = igrac.KlubId;

                uow.IgracRepository.Update(izmenjenIgrac);
                uow.Save();
            }
        }
    }
}
