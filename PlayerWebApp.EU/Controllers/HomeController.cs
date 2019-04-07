﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PlayerWebApp.EU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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