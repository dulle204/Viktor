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
using System.Net;
using System.Text;

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
                HttpResponseMessage Res = await client.GetAsync("/api/Klub");


                if (Res.IsSuccessStatusCode)
                {
                    var IgracResponse = Res.Content.ReadAsStringAsync().Result;
                    KlubInfo = JsonConvert.DeserializeObject<List<Klub>>(IgracResponse);
                }

                return View(KlubInfo);
            }
        }
        public async Task<ActionResult> Details(int id)
        {
            Klub klub = new Klub();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59466/api/");
                //HTTP GET
                var responseTask = await client.GetAsync("Klub/" + id.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    klub = await responseTask.Content.ReadAsAsync<Klub>();
                }
            }
            return View(klub);
        }


        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Klub klubInfo = new Klub();

            return View(klubInfo);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Klub noviKlub)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var json = JsonConvert.SerializeObject(noviKlub);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await client.PostAsync("/api/Klub", content);
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
            Klub klub = new Klub();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59466/api/");
                //HTTP GET
                var responseTask = await client.GetAsync("Klub/" + id.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    // var responseTask = responseTask.Content.ReadAsStringAsync().Result;
                    // igrac = JsonConvert.DeserializeObject<AddOrEditIgrac>(IgracResponse);
                    klub = await responseTask.Content.ReadAsAsync<Klub>();
                }
                // fali Liga da bi create radio.<-------------------------------------------
            }
            return View(klub);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Klub klub)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://localhost:59466/api/Klub/");
                var json = JsonConvert.SerializeObject(klub);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //HTTP POST
                var result = await client.PutAsync(klub.ID.ToString(), content);
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
            Klub klub = new Klub();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59466/api/");
                //HTTP GET
                var responseTask = await client.GetAsync("Klub/" + ID.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    // var responseTask = responseTask.Content.ReadAsStringAsync().Result;
                    // igrac = JsonConvert.DeserializeObject<AddOrEditIgrac>(IgracResponse);
                    klub = await responseTask.Content.ReadAsAsync<Klub>();
                }
            }

            if (klub == null)
            {
                return HttpNotFound();
            }
            return View(klub);
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
                var responseTask = await client.DeleteAsync("Klub/" + id.ToString());

                if (!responseTask.IsSuccessStatusCode)
                {
                    return new HttpStatusCodeResult(responseTask.StatusCode, responseTask.Content.ToString());
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
