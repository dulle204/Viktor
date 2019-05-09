using PlayersDomain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using rtest.Models;
using PlayersDatav1;
using System.Web.Http.Description;
using PlayersDatav1.UnitOfWork;
using PlayersDomain.DomainModels;
using System.Net;

namespace rtest.Controllers
{
    public class KlubController : ApiController
    {
        private readonly IKlubService _klub;

        public KlubController(IKlubService klub)
        {
            _klub = klub;
            //_factory = new Factory();
        }

        public IEnumerable<KlubModel> Get()
        {
            List<KlubModel> list = new List<KlubModel>();
           KlubModel model = null;

            var data = _klub.GetKlubs();
            foreach (var item in data)
            {
                model = new KlubModel
                {
                    ID = item.ID,
                  NazivKluba = item.NazivKluba,
                  Liga=item.Liga,
                 
                 LigaID = item.LigaID

                };
                list.Add(model);
            }

            return list;
        }

        public KlubModel GetID(int id)
        {
            

            var data = _klub.GetKlubByID(id);
            KlubModel model = new KlubModel()
            {
                ID = data.ID,
                NazivKluba = data.NazivKluba,
                Liga = data.Liga,
                LigaID=data.LigaID
               
                

            };


            return model;

        }



        [ResponseType(typeof(Klub))]
        public IHttpActionResult PostKlub([FromBody]KlubModel klub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {
                
                KlubDomainModel klubDomain = new KlubDomainModel()
                {
                    NazivKluba = klub.NazivKluba,
                    LigaID = klub.LigaID
           
                };

                _klub.AddKlub(klubDomain);

                return CreatedAtRoute("DefaultApi", 0, klub);
            }
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutIgrac(int id, [FromBody]KlubModel klub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            KlubDomainModel klube = new KlubDomainModel
            {
                NazivKluba = klub.NazivKluba,
                LigaID = klub.LigaID
            };
            _klub.UpdateKlub(id, klube);

            return StatusCode(HttpStatusCode.Accepted);
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id)
        {
          
            _klub.DeleteKlub(id);


            return StatusCode(HttpStatusCode.Accepted);
        }
    }
}