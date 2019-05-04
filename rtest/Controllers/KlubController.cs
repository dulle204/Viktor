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

        public IEnumerable<KlubDomainModel> Get()
        {
           
            var data = _klub.GetKlubs();

            return data;
        }
      


    }
}