using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersDatav1;

namespace PlayersDatav1.Repositories
{
    public class IgracRepository : GenericRepository<Igrac>

    {

        public IgracRepository(PlayersContext context) : base(context)
        {

        }



        public List<Igrac> GetIgracByKlub(int id)
        {
            var result = (from igracs in _context.Igracs
                          from klubs in _context.Klubs
                          where igracs.KlubID == klubs.ID && klubs.ID == id
                          select igracs).ToList();

            return result;

        }

        public List<Igrac> GetIgracByKlub(string name)
        {
            var result = (
                from igracs in _context.Igracs
                from klubs in _context.Klubs
                where igracs.DrzavaID == klubs.ID && klubs.NazivKluba == name
                select igracs).ToList();

            return result;

        }

        public List<Igrac> GetIgracByDrzava(int id)
        {
            var result = (from igracs in _context.Igracs
                          from drzavas in _context.Drzavas
                          where igracs.DrzavaID == drzavas.ID && drzavas.ID == id
                          select igracs).ToList();

            return result;

        }

        public List<Igrac> GetLigaByDrzava(string name)
        {
            var result = (
                from igracs in _context.Igracs
                from drzavas in _context.Drzavas
                where igracs.DrzavaID == drzavas.ID && drzavas.NazivDrzave == name
                select igracs).ToList();

            return result;

        }


       PlayersContext playersContext = new PlayersContext();
        public List<Igrac> GetAllPlayers()
        {
            return playersContext.Igracs.ToList();
        }

        public void InsertIgrac(Igrac igrac)
        {

          //*  igrac.Ime = "Test1";
          //  igrac.Prezime = "test2";
            //igrac.Tezina = 90;
            //igrac.Visina = 192;
            //igrac.Klub.NazivKluba = "Partizan";
            //igrac.Drzava.NazivDrzave = "Srbija"; //

            playersContext.Igracs.Add(igrac);
                playersContext.SaveChanges();

            
        }

        public void UpdateIgrac(Igrac igrac)
        {

            Igrac igracUpdate = playersContext.Igracs.SingleOrDefault(x => x.ID == igrac.ID);

            igracUpdate.ID = igrac.ID;
            igracUpdate.Ime = igrac.Ime;
            igracUpdate.Prezime = igrac.Prezime;
            igracUpdate.Visina = igrac.Visina;
            igracUpdate.Tezina = igrac.Tezina;
            igracUpdate.KlubID = igrac.KlubID;
            igracUpdate.DrzavaID = igrac.DrzavaID;

            playersContext.SaveChanges();

        }

        public void DeleteIgrac(Igrac igrac)
        {
            Igrac igracToDelete = playersContext.Igracs.SingleOrDefault(x => x.ID == igrac.ID);
            playersContext.Igracs.Remove(igracToDelete);
            playersContext.SaveChanges();
        }
    }
}
