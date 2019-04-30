using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersDatav1.UnitOfWork;

namespace PlayersDomain
{
     public class KlubServiceEU: IKlubService
    {
        private readonly IUnitOfWork _uow;

        public KlubServiceEU(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public string Region { get; } = "EU";

        public List<KlubDomainModel> GetKlubs()
        {
            List<KlubDomainModel> list = new List<KlubDomainModel>();

            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {
                var klubovi = uow.KlubRepository.Get();
                KlubDomainModel model = null;
                foreach (var item in klubovi)
                {
                    
                    var liga = uow.LigaRepository.GetByID(item.LigaID);

                    model = new KlubDomainModel()
                    {
                        ID = item.ID,
                        NazivKluba = item.NazivKluba,
                        Liga=uow.LigaRepository.GetByID(item.LigaID).NazivLige
                   

                    };

                    list.Add(model);
                }
            }


            return list;
        }

    }
}
