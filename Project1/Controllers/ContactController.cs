using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class ContactController : Controller
    {
        Contacts mod = new Contacts();

        // GET: Contact

        public ActionResult index()
        {
            return View();
        }        

        //CREATE
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Contacts m)
        {
            if (ModelState.IsValid)
            {
                if (mod.newCon(m) == true)
                {
                    return RedirectToAction("Users", "Contact", new { area = "" });
                }
                else
                {
                    ModelState.AddModelError("Contact", "Contact number already exist.");
                    return View(m);
                }

            }
            return View(m);

        }

        //EDIT
        public ActionResult Edit(int ID)
        {
            var item = mod.Find(ID);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Contacts m)
        {
            
            mod.Update(m);
            return RedirectToAction("Users", "Contact", new { area = "" });
        }

        //DELETE
        public ActionResult Delete(int ID)
        {
            var item = mod.Find(ID);
            return View(item);
        }

        [HttpPost]
        public ActionResult Delete(Contacts m)
        {
            mod.Delete(m);
            return RedirectToAction("Users", "Contact", new { area = "" });
        }

        //Contact List
        [HttpGet]   
        public ActionResult Users()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            return View(mod.List());
        }

        //PARTIAL VIEW "DATA"
        public PartialViewResult data(string Search)
        {
            var item = mod.List(Search);
            return PartialView(item);
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Home", new { area = "" });
        }



    }
}