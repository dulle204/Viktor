using PlayersDatav1;
using PlayersDatav1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain
{

    public class DrzavaService: IDrazavaService
    {
        private readonly IUnitOfWork _uow;

        public DrzavaService(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public List<DrzavaDomenModel> GetDrzavas()
        {
            List<DrzavaDomenModel> list = new List<DrzavaDomenModel>();

            //using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            //{
                var drzave = _uow.DrzavaRepository.Get();
                DrzavaDomenModel model = null;
                foreach (var item in drzave)
                {



                    model = new DrzavaDomenModel()
                    {
                        ID = item.ID,
                        NazivDrzave = item.NazivDrzave



                    };

                    list.Add(model);
                }

                return list;
            }

        

        public DrzavaDomenModel GetDrzavaByID(int id)
        {
            DrzavaDomenModel drzava = new DrzavaDomenModel();

           // using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            //{
                var drzavag = _uow.DrzavaRepository.Get(x => x.ID == id).FirstOrDefault();
                DrzavaDomenModel model = null;

                {
                    

                    model = new DrzavaDomenModel()
                    {
                        ID = drzavag.ID,
                        NazivDrzave = drzavag.NazivDrzave

                    };

                    return model;

                
            }
        }

        public void AddDrzava(DrzavaDomenModel drzava)
        {
            //using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
            //{
                Drzava novaDrzava = new Drzava
                {
                    NazivDrzave = drzava.NazivDrzave
    
                };

                if (novaDrzava != null)
                {
                    _uow.DrzavaRepository.Insert(novaDrzava);
                    _uow.Save();
                }
         }
        

        public void UpdateDrzava(int id, DrzavaDomenModel drzava)
        {
            //using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
            //{
                var izmenjenaDrzava = _uow.DrzavaRepository.Get(x => x.ID == id).FirstOrDefault();
                izmenjenaDrzava.NazivDrzave = drzava.NazivDrzave;
               

                _uow.DrzavaRepository.Update(izmenjenaDrzava);
                _uow.Save();
            
        }

        public void DeleteDrzava(int id)
        {
            //using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
           // {
                _uow.DrzavaRepository.Delete(id);
                _uow.Save();
            
        }
    }
}

