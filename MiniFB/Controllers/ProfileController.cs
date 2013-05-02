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
using MiniFB.Models.ProfileSettings;

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
            User user = _userRepo.FindAll().Where(u => u.UserName == "Goat").FirstOrDefault();
            return View(user);
        }

        public ActionResult Edit(Guid id)
        {
            User user = _userRepo.FindByID(id);
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
                _userRepo.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}