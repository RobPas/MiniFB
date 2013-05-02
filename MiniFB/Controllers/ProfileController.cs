using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFB.Models.Contexts;

namespace MiniFB.Controllers
{
    public class ProfileController : Controller
    {
        private IRepository<User> _userRepo;

        public ProfileController()
        {
            _userRepo = new Repository<User>();
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Edit()
        {
            //User user = db.Users.First();
            /*if (user == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            //SettingsValidator sv = new SettingsValidator();&& sv.isValidSex(user.Sex)


            /*if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/
            return View();
        }
    }
}