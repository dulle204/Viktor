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

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {

            AddOrEditIgrac igrac = new AddOrEditIgrac();

           
        
            using (var client = new HttpClient())
            

                
                {
                    client.BaseAddress = new Uri("http://localhost:59466/api/");
                    //HTTP GET
                    var responseTask = await client.GetAsync("Igracs/" + id.ToString()); // promenuo u Igracs a treba PLayers  kod igracs vuce samo ime bez kluba

                    if (responseTask.IsSuccessStatusCode)
                    {
                    var IgracResponse = responseTask.Content.ReadAsStringAsync().Result;
                    igrac = JsonConvert.DeserializeObject<AddOrEditIgrac>(IgracResponse);
                 //   igrac = await responseTask.Content.ReadAsAsync<Igrac>();
                    }
            }
            return View(igrac);
        }

        [HttpPost]
        public ActionResult Edit(AddOrEditIgrac igrac)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("http://localhost:59466/api/Igracs");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<AddOrEditIgrac>("Igracs", igrac);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(igrac);
        }
    }

    //  using (var client = new HttpClient())
    //  {
    //    client.BaseAddress = new Uri(Baseurl);
    //  client.DefaultRequestHeaders.Clear();
    //     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //   HttpResponseMessage Res = await client.GetAsync("/api/players?region=EU?id=" + id.ToString());//get igraca po id


    //    if (Res.IsSuccessStatusCode)
    //  {
    //     igrac = await Res.Content.ReadAsAsync<AddOrEditIgrac>();

    //IgracInfo = JsonConvert.DeserializeObject<List<Igrac>>(IgracResponse);
}


              //  return View(igrac);
      //    //  }
      //  }

        // static async Task<AddOrEditIgrac> UpdateProductAsync(AddOrEditIgrac igrac)
        //{
        //  HttpResponseMessage response = await client.PutAsJsonAsync(
        //    $"api/products/{igrac.ID}", igrac);
        //response.EnsureSuccessStatusCode();

        // Deserialize the updated product from the response body.
        //igrac = await response.Content.ReadAsAsync<AddOrEditIgrac>();
        //return igrac;
        //}

       // public async Task<ActionResult> Edit(AddOrEditIgrac igrac)
       // {
         //   using (var client = new HttpClient())
         //   {


            //    var json = JsonConvert.SerializeObject(igrac);
             //   var content = new StringContent(json, Encoding.UTF8, "application/json");
             //   var response = await client.PutAsync("/api/players?region=EU/{ID}", content);//



             //   return View(response);

