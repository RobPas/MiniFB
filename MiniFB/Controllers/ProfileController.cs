using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFB.Models;
using MiniFB.Models.ProfileSettings;

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
        public ActionResult Edit(User user)
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