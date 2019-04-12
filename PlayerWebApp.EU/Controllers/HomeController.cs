using Newtonsoft.Json;

using PlayerWebApp.EU.Models;
using System;
using System.Collections.Generic;

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



        public async Task<ActionResult> Create(AddOrEditIgrac IgracInfo, bool isNewItem = false)
        {
            
            IgracInfo.Ime = "Test123";
            IgracInfo.Prezime = "Prezime";
            IgracInfo.Tezina = 100;
            IgracInfo.Visina = 200;
            IgracInfo.KlubId = 4;
            IgracInfo.DrzavaId = 3;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
              //  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(IgracInfo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

               // HttpResponseMessage Res = await client.PostAsJsonAsync("/api/Players", IgracInfo);

                if (isNewItem)
                {
                    var Res = await client.PostAsync("http://localhost:59466/api/Players", content);
                }

         

                return View(IgracInfo);
            }

        }

        



        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Edit(Igrac IgracInfo)
        {
            using (var client = new HttpClient())
            {
   

                var json = JsonConvert.SerializeObject(IgracInfo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("http://localhost:59466/api/Players", content);



                return View(response);
            }
        }
    }
}