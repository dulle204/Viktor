using PlayersDatav1;
using PlayersDatav1.UnitOfWork;
using PlayersDomain;
using rtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace rtest.Controllers
{
    public class LigaController : ApiController
   
    {
        private readonly ILigaService _liga;

        public LigaController(ILigaService liga)
        {
            _liga = liga;
            //_factory = new Factory();
        }

        public IEnumerable<LigaModel> Get()
        {
            List<LigaModel> list = new List<LigaModel>();
            LigaModel model = null;

            var data = _liga.GetLiga();
            foreach (var item in data)
            {
                model = new LigaModel
                {
                    ID = item.ID,
                    NazivLige = item.NazivLige,
                    DrzavaID = item.DrzavaID,

                    Drzava = item.Drzava

                };
                list.Add(model);
            }

            return list;
        }

        public LigaModel GetID(int id)
        {


            var data = _liga.GetLigaID(id);
            LigaModel model = new LigaModel()
            {
                ID = data.ID,
                NazivLige = data.NazivLige,
                Drzava = data.Drzava,
                DrzavaID = data.DrzavaID



            };


            return model;

        }



        [ResponseType(typeof(Liga))]
        public IHttpActionResult PostLiga([FromBody]LigaModel liga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {

                LigaDomianModel ligaDomain = new LigaDomianModel()
                {
                    NazivLige = liga.NazivLige,
                    DrzavaID = liga.DrzavaID

                };

                _liga.AddLiga(ligaDomain);

                return CreatedAtRoute("DefaultApi", 0, liga);
            }
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutLiga(int id, [FromBody]LigaModel liga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            LigaDomianModel ligae = new LigaDomianModel
            {
                NazivLige = liga.NazivLige,
                DrzavaID = liga.DrzavaID
            };
            _liga.UpdateLiga(id, ligae);

            return StatusCode(HttpStatusCode.Accepted);
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            _liga.DeleteLiga(id);


            return StatusCode(HttpStatusCode.Accepted);
        }
    }
}