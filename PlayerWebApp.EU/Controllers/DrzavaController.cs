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
    public class DrzavaController : Controller
    {
        private const string Baseurl = "http://localhost:59466";

        public async Task<ActionResult> Index()
        {
            List<Drzava> DrzavaInfo = new List<Drzava>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/Drzava");


                if (Res.IsSuccessStatusCode)
                {
                    var IgracResponse = Res.Content.ReadAsStringAsync().Result;
                    DrzavaInfo = JsonConvert.DeserializeObject<List<Drzava>>(IgracResponse);
                }

                return View(DrzavaInfo);
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            Drzava igrac = new Drzava();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59466/api/");
                //HTTP GET
                var responseTask = await client.GetAsync("Drzava/" + id.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    igrac = await responseTask.Content.ReadAsAsync<Drzava>();
                }
            }
            return View(igrac);
        }


        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Drzava drzavaInfo = new Drzava();

            return View(drzavaInfo);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Drzava novaDrzava)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var json = JsonConvert.SerializeObject(novaDrzava);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await client.PostAsync("/api/Drzava", content);
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
            Drzava drzava = new Drzava();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59466/api/");
                //HTTP GET
                var responseTask = await client.GetAsync("Drzava/" + id.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    // var responseTask = responseTask.Content.ReadAsStringAsync().Result;
                    // igrac = JsonConvert.DeserializeObject<AddOrEditIgrac>(IgracResponse);
                    drzava = await responseTask.Content.ReadAsAsync<Drzava>();
                }

            }
            return View(drzava);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Drzava drzava)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://localhost:59466/api/Drzava/");
                var json = JsonConvert.SerializeObject(drzava);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //HTTP POST
                var result = await client.PutAsync(drzava.ID.ToString(), content);
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
            Drzava drzava = new Drzava();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59466/api/");
                //HTTP GET
                var responseTask = await client.GetAsync("Drzava/" + ID.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    // var responseTask = responseTask.Content.ReadAsStringAsync().Result;
                    // igrac = JsonConvert.DeserializeObject<AddOrEditIgrac>(IgracResponse);
                    drzava = await responseTask.Content.ReadAsAsync<Drzava>();
                }
            }

            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
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
                var responseTask = await client.DeleteAsync("Drzava/" + id.ToString());

                if (!responseTask.IsSuccessStatusCode)
                {
                    return new HttpStatusCodeResult(responseTask.StatusCode, responseTask.Content.ToString());
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

