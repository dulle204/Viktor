using PlayersDomain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using rtest.Models;

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
                  Drzava=item.Drzava,
                 LigaID = item.LigaID

                };
                list.Add(model);
            }

            return list;
        }
      


    }
}