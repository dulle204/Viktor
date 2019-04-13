using Newtonsoft.Json;

using PlayerWebApp.EU.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace PlayerWebApp.EU.Controllers
{
    public class HomeController : Controller
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


        [HttpGet]
        public async Task<ActionResult> Create()
        {
            AddOrEditIgrac igracInfo = new AddOrEditIgrac();

            return View(igracInfo);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AddOrEditIgrac noviIgrac)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var json = JsonConvert.SerializeObject(noviIgrac);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await client.PostAsync("/api/players?region=EU", content);
                if (Res.StatusCode != HttpStatusCode.Accepted)
                {
                    return new HttpStatusCodeResult(Res.StatusCode, Res.Content.ToString());
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            AddOrEditIgrac igrac= new AddOrEditIgrac();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/players?region=EU");//get igraca po id


                if (Res.IsSuccessStatusCode)
                {
                    var IgracResponse = Res.Content.ReadAsStringAsync().Result;
                    //IgracInfo = JsonConvert.DeserializeObject<List<Igrac>>(IgracResponse);
                }

                return View(igrac);
            }
        }
        public async Task<ActionResult> Edit(AddOrEditIgrac igrac)
        {
            using (var client = new HttpClient())
            {


                var json = JsonConvert.SerializeObject(igrac);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"api/players/{3}", content);//



                return View(response);
            }
        }
    }
}