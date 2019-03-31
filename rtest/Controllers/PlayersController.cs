using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using PlayersDomain;

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
    }
}
