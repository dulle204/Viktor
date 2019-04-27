using Newtonsoft.Json;
using PlayerWebApp.EU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PlayerWebApp.EU.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players

        {

            //Hosted web API REST Service base url  
            private const string Baseurl = "http://localhost:59466";

            public async Task<ActionResult> Index()
            {
                List<Igrac> IgracInfo = new List<Igrac>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("/api/players?region=EU");


                    if (Res.IsSuccessStatusCode)
                    {
                        var IgracResponse = Res.Content.ReadAsStringAsync().Result;
                        IgracInfo = JsonConvert.DeserializeObject<List<Igrac>>(IgracResponse);
                    }

                    return View(IgracInfo);
                }
            }
        }
    }