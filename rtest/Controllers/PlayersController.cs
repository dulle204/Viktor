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


namespace rtest.Controllers
{
    public class PlayersController : ApiController
    {
        public IEnumerable<IgracDomainModel> Get(string region)
        {
            Factory factory = new Factory();
            IPlayerService service = factory.GetInstance(region);
            var data = service.GetPlayers();

            return data;
        }


        [ResponseType(typeof(Igrac))]
        public IHttpActionResult PostIgrace([FromBody] Igrac igrac)
        {
            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {

                uow.IgracRepository.InsertIgrac(igrac);
                uow.Save();
                return CreatedAtRoute("DefaultApi", new { id = igrac.ID }, igrac);

            }
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutIgrac(int id, Igrac igrac)
        {


            if (id != igrac.ID)
            {
                return BadRequest();
            }

            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {

                uow.IgracRepository.UpdateIgrac(igrac);
                uow.Save();


                return StatusCode(HttpStatusCode.NoContent);
            }

        }

    }
}