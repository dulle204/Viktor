using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayerWebApp.EU.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PlayerWebApp.EU.Controllers
{
    public class KlubController : Controller
    {
        // GET: Klub
        private const string Baseurl = "http://localhost:59466";

        public async Task<ActionResult> Index()
        {
            List<Klub> KlubInfo = new List<Klub>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/Klub?region=EU");


                if (Res.IsSuccessStatusCode)
                {
                    var IgracResponse = Res.Content.ReadAsStringAsync().Result;
                    KlubInfo = JsonConvert.DeserializeObject<List<Klub>>(IgracResponse);
                }

                return View(KlubInfo);
            }
        }
    }
}