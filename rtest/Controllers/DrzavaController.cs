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
    public class DrzavaController : ApiController
    {
        private readonly IDrazavaService _drzava;

        public DrzavaController(IDrazavaService drzava)
        {
            _drzava = drzava;
            //_factory = new Factory();
        }

        public IEnumerable<DrzavaModel> Get()
        {
            List<DrzavaModel> list = new List<DrzavaModel>();
            DrzavaModel model = null;

            var data = _drzava.GetDrzavas();
            foreach (var item in data)
            {
                model = new DrzavaModel
                {
                    ID = item.ID,
                    NazivDrzave = item.NazivDrzave


                };
                list.Add(model);
            }

            return list;
        }


        public DrzavaModel GetID(int id)
        {
          

            var data = _drzava.GetDrzavaByID(id);
            DrzavaModel model = new DrzavaModel()
            {
                ID = data.ID,
                NazivDrzave = data.NazivDrzave
            };
            return model;

        }



        [ResponseType(typeof(Drzava))]
        public IHttpActionResult PostDrzave([FromBody]DrzavaModel drzava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (UnitOfWork uow = new UnitOfWork(new PlayersDatav1.PlayersContext()))
            {

                DrzavaDomenModel drzavaDomen = new DrzavaDomenModel()
                {
                    NazivDrzave = drzava.NazivDrzave
     
                };

                _drzava.AddDrzava(drzavaDomen);

                return CreatedAtRoute("DefaultApi", 0, drzava);
            }
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrzava(int id, [FromBody]DrzavaModel drzava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          
            DrzavaDomenModel drzavae = new DrzavaDomenModel
            {
                NazivDrzave = drzava.NazivDrzave
             
            };
            _drzava.UpdateDrzava(id, drzavae);

            return StatusCode(HttpStatusCode.Accepted);
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            _drzava.DeleteDrzava(id);


            return StatusCode(HttpStatusCode.Accepted);
        }
    }
}