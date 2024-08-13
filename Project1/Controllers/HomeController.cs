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
            if (Session["uname"] != null)
            {
               return RedirectToAction("Users", "Contact", new { area = "" });
            }
            return View();
            
        }
        [HttpPost]
        public ActionResult Login(Users m)
        {
            ModelState.Clear();//clear other modelstate
            if (ModelState.IsValid)
            {
                var user = new Users();
                Session["uname"] = m.uname;

                if (user.uLog(m.uname, m.pword))
                {                                              
                    return RedirectToAction("Users", "Contact", new { area = "" });
                }                
            }
            ModelState.AddModelError("", "Incorrect Username or Password");//error message for username and password
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
        


    }
}