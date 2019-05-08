using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersDatav1;
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

        public List<KlubDomainModel> GetKlubs()
        {
            List<KlubDomainModel> list = new List<KlubDomainModel>();

           // using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            //{
        
                var klubovi = _uow.KlubRepository.Get();
                KlubDomainModel model = null;
                foreach (var item in klubovi)
                {
                    
                    var liga = _uow.LigaRepository.GetByID(item.LigaID);

                    model = new KlubDomainModel()
                    {
                        ID = item.ID,
                        NazivKluba = item.NazivKluba,
                        Liga=_uow.LigaRepository.GetByID(item.LigaID).NazivLige


                    };

                    list.Add(model);
                }

            return list;
        }

        public KlubDomainModel GetKlubByID(int id)
        {
            KlubDomainModel klub = new KlubDomainModel();

            //using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            //{
                var klubg = _uow.KlubRepository.Get(x => x.ID == id).FirstOrDefault();
            KlubDomainModel model = null;

                {
                   
                    var liga = _uow.LigaRepository.GetByID(klub.LigaID).NazivLige;

                    model = new KlubDomainModel()
                    {
                        ID = klubg.ID,
                        Liga = liga,
                        LigaID = klub.LigaID
                       
                    };

                    return model;

                }
            }
        

        public void AddKlub(KlubDomainModel klub)
        {
            //using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
            //{
                Klub noviKlub = new Klub
                {
                    NazivKluba = klub.NazivKluba,
                
                };

                if (noviKlub != null)
                {
                    _uow.KlubRepository.Insert(noviKlub);
                    _uow.Save();
                }
            
        }

        public void UpdateKlub(int id, KlubDomainModel klub)
        {
           // using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
            //{
                var izmenjenKlub = _uow.KlubRepository.Get(x => x.ID == id).FirstOrDefault();
            izmenjenKlub.NazivKluba = klub.NazivKluba;
            izmenjenKlub.LigaID = klub.LigaID;

                _uow.KlubRepository.Update(izmenjenKlub);
                _uow.Save();
            
        }

        public void DeleteKlub(int id)
        {
           // using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
            //{
                _uow.KlubRepository.Delete(id);
                _uow.Save();
            
        }
    }
}
