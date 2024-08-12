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
               return RedirectToAction("Users", "Contact", new { uname = Session["uname"].ToString() });
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
                //Session["id"] = m.ID;
                Session["uname"] = m.uname;

                if (user.uLog(m.uname, m.pword))
                {
                                              
                    return RedirectToAction("Users", "Contact");
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

            //var emailExist = m.List().Any(x => x.email == m.email);//validation for existing emails
            if (ModelState.IsValid)
            {
                //if (emailExist)
                //{
                //    ModelState.AddModelError("Email", "Email already exist.");
                //    return View(m);
                //}
                //else { 
                mod.Register(m);
                return RedirectToAction("Login");
                //}
            }                           
            return View();
        }    
        


    }
}