using Newtonsoft.Json;
using PlayerWebApp.EU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PlayerWebApp.EU.Controllers
{
    public class LigaController : Controller
    {
        // GET: Liga
     
        private const string Baseurl = "http://localhost:59466";

        public async Task<ActionResult> Index()
        {
            List<Liga> LigaInfo = new List<Liga>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/Liga");


                if (Res.IsSuccessStatusCode)
                {
                    var IgracResponse = Res.Content.ReadAsStringAsync().Result;
                    LigaInfo = JsonConvert.DeserializeObject<List<Liga>>(IgracResponse);
                }

                return View(LigaInfo);
            }
        }
        public async Task<ActionResult> Details(int id)
        {
            Liga liga = new Liga();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59466/api/");
                //HTTP GET
                var responseTask = await client.GetAsync("Liga/" + id.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    liga = await responseTask.Content.ReadAsAsync<Liga>();
                }
            }
            return View(liga);
        }


        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Liga ligaInfo = new Liga();

            return View(ligaInfo);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Liga novaLiga)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var json = JsonConvert.SerializeObject(novaLiga);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await client.PostAsync("/api/Liga", content);
                if (Res.StatusCode != HttpStatusCode.Accepted)
                {
                    return new HttpStatusCodeResult(Res.StatusCode, Res.Content.ToString());
                }
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Liga liga = new Liga();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59466/api/");
                //HTTP GET
                var responseTask = await client.GetAsync("Liga/" + id.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    // var responseTask = responseTask.Content.ReadAsStringAsync().Result;
                    // igrac = JsonConvert.DeserializeObject<AddOrEditIgrac>(IgracResponse);
                    liga = await responseTask.Content.ReadAsAsync<Liga>();
                }
                // fali Liga da bi create radio.<-------------------------------------------
            }
            return View(liga);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Liga liga)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://localhost:59466/api/Liga/");
                var json = JsonConvert.SerializeObject(liga);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //HTTP POST
                var result = await client.PutAsync(liga.ID.ToString(), content);
                if (!result.IsSuccessStatusCode)
                {
                    return new HttpStatusCodeResult(result.StatusCode, result.Content.ToString());
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liga liga = new Liga();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59466/api/");
                //HTTP GET
                var responseTask = await client.GetAsync("Liga/" + ID.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    // var responseTask = responseTask.Content.ReadAsStringAsync().Result;
                    // igrac = JsonConvert.DeserializeObject<AddOrEditIgrac>(IgracResponse);
                    liga = await responseTask.Content.ReadAsAsync<Liga>();
                }
            }

            if (liga == null)
            {
                return HttpNotFound();
            }
            return View(liga);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59466/api/");
                //HTTP GET
                var responseTask = await client.DeleteAsync("Liga/" + id.ToString());

                if (!responseTask.IsSuccessStatusCode)
                {
                    return new HttpStatusCodeResult(responseTask.StatusCode, responseTask.Content.ToString());
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
