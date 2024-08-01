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
        [HttpPost]
        public ActionResult Index(Contacts m)
        {
            var item = mod.List(m);
            return View(item);
        }

        //CREATE
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Contacts m)
        {
            m.newCon(m);
            return RedirectToAction("Users");
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
            return RedirectToAction("Users");
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
            return RedirectToAction("Users");

        }
    }
}