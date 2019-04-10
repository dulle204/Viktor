using Newtonsoft.Json;

using PlayerWebApp.EU.Models;
using System;
using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace PlayerWebApp.EU.Controllers
{
    public class HomeController : Controller
    {

        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:59466";
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

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Contact()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(new Uri("http://localhost:59466/api/players?region=EU"));
                return View(response);
            }
                ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}