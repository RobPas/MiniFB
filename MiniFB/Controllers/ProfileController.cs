using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using MiniFB.Models.Contexts;
using MiniFB.Models.Entities;
=======
using MiniFB.Models;
using MiniFB.Models.ProfileSettings;
>>>>>>> ProfileController

namespace MiniFB.Controllers
{
    public class ProfileController : Controller
    {
        private MiniFBContext db = new MiniFBContext();


        public ActionResult Index()
        {
            return View(db.Users.First());
        }


        public ActionResult Edit()
        {
            User user = db.Users.First();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.ID = Guid.NewGuid();
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /Profile/Edit/5

        public ActionResult Edit(Guid id)
=======
        public ActionResult Edit(User user)
>>>>>>> ProfileController
        {
            SettingsValidator sv = new SettingsValidator();


            if (ModelState.IsValid && sv.isValidSex(user.Sex))
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}