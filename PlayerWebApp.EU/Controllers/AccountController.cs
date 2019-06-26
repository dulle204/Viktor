using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayerWebApp.EU.Models;

namespace PlayerWebApp.EU.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if(ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.UserName + "succesfully registered";

            }
            return View();
        }



        public ActionResult Login()
        {
           // if (Session["AdminIsLogedIn"] != null)
           // {
               // return RedirectToAction("index", "AdminProfile");
           // }
           // else
           // {
                return View();
          //  }
          
        }


        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.userAccount.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if (usr !=null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");

                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password is incorrect");
                }


          //      if (user.UserName == "admin" && user.Password == "admin123")
              //  {
              //      Session["AdminIsLogedIn"] = true;
//return RedirectToAction("index", "AdminProfile");
             //   }



                ViewBag.Error = "Wrong Username/Password";
            }
            return View();
        }


       


        
        



       // public ActionResult Logout()
       // {
          //  Session["AdminIsLogedIn"] = null;
           // return RedirectToAction("Login", "Account");
       // }



        public ActionResult LoggedIn()
        {
            if(Session["UserID"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


    }
}