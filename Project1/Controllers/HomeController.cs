using Project1.Classes;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        Users mod = new Users();
                
        /*public ActionResult Index()
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
        }*/

        //LOGIN
        public ActionResult Login()            
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users m)
        {
            ModelState.Clear();//clear other modelstate
            if (ModelState.IsValid)
            {
                var user = new Users();
                if (user.uLog(m.uname, m.pword))
                {                   
                    return RedirectToAction("Users");
                }                
            }
            ModelState.AddModelError("", "Incorrect Username or Password");
            return View(m);
        }


        //REGISTER
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users m)
        {
            if (ModelState.IsValid)
            {
                mod.Register(m);
                return RedirectToAction("Login");
            }                           
            return View();
        }

        //CONTACT LIST
        [HttpGet]
        public ActionResult Users()
        {                        
            return View(mod.List());
        }

        //PARTIAL VIEW "DATA"
        public PartialViewResult data(string Search)
        {
            var item = mod2.List(Search);
            return PartialView(item);
        }


        


    }
}