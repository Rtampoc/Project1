using Project1.Classes;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        Users mod = new Users();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(Users m)
        {
                   
            
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users m)
        {
            if(ModelState.IsValid == false)
            {
                return View(m);
            }
            mod.Register(m);
            return RedirectToAction("Login");
        }

        public ActionResult Users(Users m)
        {
            
            
            return View();
        }


    }
}