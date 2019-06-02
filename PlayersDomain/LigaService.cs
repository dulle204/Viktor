using PlayersDatav1;
using PlayersDatav1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersDomain
{
    public class LigaService : ILigaService
    {
        private readonly IUnitOfWork _uow;

        public LigaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<LigaDomianModel> GetLiga()
        {
            List<LigaDomianModel> list = new List<LigaDomianModel>();

            var lige = _uow.LigaRepository.Get();
            if (lige == null)
            {
                return new List<LigaDomianModel>();
            }
            LigaDomianModel model = null;
            foreach (var item in lige)
            {

                var drzava = _uow.DrzavaRepository.GetByID(item.DrzavaID);

                model = new LigaDomianModel()
                {
                    ID = item.ID,
                    NazivLige = item.NazivLige,
                    DrzavaID = item.DrzavaID,
                    Drzava = drzava.NazivDrzave
                };

                list.Add(model);
            }

            return list;
        }

        public LigaDomianModel GetLigaID(int id)
        {
            LigaDomianModel liga = new LigaDomianModel();

            var ligag = _uow.LigaRepository.Get(x => x.ID == id).FirstOrDefault();
            LigaDomianModel model = null;

            model = new LigaDomianModel()
            {
                ID = ligag.ID,
                NazivLige = ligag.NazivLige,
                DrzavaID = ligag.DrzavaID,
                Drzava = _uow.DrzavaRepository.GetByID(ligag.DrzavaID).NazivDrzave
            };

            return model;


        }


        public void AddLiga(LigaDomianModel liga)
        {
            Liga novaLiga = new Liga
            {
                NazivLige = liga.NazivLige,
                DrzavaID = liga.DrzavaID
            };

            if (novaLiga != null)
            {
                _uow.LigaRepository.Insert(novaLiga);
                _uow.Save();
            }
        }

        public void UpdateLiga(int id, LigaDomianModel liga)
        {
            var izmenjenaLiga = _uow.LigaRepository.Get(x => x.ID == id).FirstOrDefault();
            izmenjenaLiga.NazivLige = liga.NazivLige;
            izmenjenaLiga.DrzavaID = liga.DrzavaID;

            _uow.LigaRepository.Update(izmenjenaLiga);
            _uow.Save();
        }

        public void DeleteLiga(int id)
        {
            _uow.LigaRepository.Delete(id);
            _uow.Save();
        }
    }
}


