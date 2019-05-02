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
        private readonly IKlubFactory _factory;

        public KlubController(IKlubFactory factory)
        {
            _factory = factory;
            //_factory = new Factory();
        }

        public IEnumerable<KlubDomainModel> Get(string region)
        {
            IKlubService service = _factory.GetInst(region);
            var data = service.GetKlubs();

            return data;
        }
      


    }
}