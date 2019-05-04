using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using PlayersDomain;
using PlayersDatav1;
using PlayersDatav1.UnitOfWork;
using System.Web.Http.Description;
using rtest.Models;
using PlayersDomain.DomainModels;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;

namespace rtest.Controllers
{
    public class PlayersController : ApiController
    {
        private readonly IFactory _factory;

        public PlayersController(IFactory factory)
        {
            _factory = factory;
            //_factory = new Factory();
        }

        public IEnumerable<PlayerModel> Get(string region)
        {
            IPlayerService service = _factory.GetInstance(region);
            List<PlayerModel> list = new List<PlayerModel>();
            PlayerModel model = null;

            var data = service.GetPlayers();
            foreach (var item in data)
            {

                model = new PlayerModel()
                {
                    ID = item.ID,
                    Ime = item.Ime,
                    Prezime = item.Prezime,
                    Tezina = item.Tezina,
                    Visina = item.Visina,
                    Drzava = item.Drzava,
                    Klub = item.Klub,
                    KlubId = item.KlubId,
                    DrzavaId = item.DrzavaId,
                    DrzavaKluba = item.DrzavaKLuba
                };
                list.Add(model);
            }

             return list;
        }

        public PlayerModel GetID(int id,string region)
        {
            IPlayerService service = _factory.GetInstance(region);
           
            var data = service.GetPlayersByID(id);
            PlayerModel model = new PlayerModel()
            {
                ID=data.ID,
                Ime=data.Ime,
                Prezime=data.Prezime,
                Tezina=data.Tezina,
                Visina=data.Visina,
                Drzava=data.Drzava,
                Klub=data.Klub,
                DrzavaKluba=data.DrzavaKLuba,
                KlubId=data.KlubId,
                DrzavaId=data.KlubId


            };


            return model;

        }



        [ResponseType(typeof(Igrac))]
        public IHttpActionResult PostIgrace([FromBody]PlayerModel igrac, [FromUri]string region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {
                IPlayerService service = _factory.GetInstance(region);
                AddPlayerModel igracDomain = new AddPlayerModel()
                {
                    Ime = igrac.Ime,
                    Prezime = igrac.Prezime,
                    Tezina = igrac.Tezina,
                    Visina = igrac.Visina,
                    DrzavaId = igrac.DrzavaId,
                    KlubId = igrac.KlubId
                };

                service.AddPlayer(igracDomain);

                return CreatedAtRoute("DefaultApi", 0, igrac);
            }
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutIgrac(int id, [FromBody]PlayerModel igrac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IPlayerService service = _factory.GetInstance("EU");
            AddPlayerModel player = new AddPlayerModel
            {
                Ime = igrac.Ime,
                KlubId = igrac.KlubId
            };
            service.UpdatePlayer(id, player);

            return StatusCode(HttpStatusCode.Accepted);
        }
        
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            IPlayerService service = _factory.GetInstance("EU");
            service.DeletePlayer(id);


            return StatusCode(HttpStatusCode.Accepted);
        }
    }
}