using PlayersDatav1;
using PlayersDatav1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain
{

    public class DrzavaService:IDrazavaService
    {


        public List<DrzavaDomenModel> GetDrzavas()
        {
            List<DrzavaDomenModel> list = new List<DrzavaDomenModel>();

            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {
                var drzave = uow.DrzavaRepository.Get();
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

        }

        public DrzavaDomenModel GetDrzavaByID(int id)
        {
            DrzavaDomenModel drzava = new DrzavaDomenModel();

            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {
                var drzavag = uow.DrzavaRepository.Get(x => x.ID == id).FirstOrDefault();
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
        }

        public void AddDrzava(DrzavaDomenModel drzava)
        {
            using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
            {
                Drzava novaDrzava = new Drzava
                {
                    NazivDrzave = drzava.NazivDrzave
    
                };

                if (novaDrzava != null)
                {
                    uow.DrzavaRepository.Insert(novaDrzava);
                    uow.Save();
                }
            }
        }

        public void UpdateDrzava(int id, DrzavaDomenModel drzava)
        {
            using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
            {
                var izmenjenaDrzava = uow.DrzavaRepository.Get(x => x.ID == id).FirstOrDefault();
                izmenjenaDrzava.NazivDrzave = drzava.NazivDrzave;
               

                uow.DrzavaRepository.Update(izmenjenaDrzava);
                uow.Save();
            }
        }

        public void DeleteDrzava(int id)
        {
            using (UnitOfWork uow = new UnitOfWork(new PlayersContext()))
            {
                uow.DrzavaRepository.Delete(id);
                uow.Save();
            }
        }
    }
}

