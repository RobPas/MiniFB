﻿using MiniFB.Models.Entities;
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
    [Authorize]
    public class ProfileController : Controller
    {
        private IRepository<User> _userRepo;

        public ProfileController()
        {
            _userRepo = new Repository<User>();
        }

        public ActionResult Index(string username = null)
        {
            /* Om inget username skickas med visas den inloggades egna profilsida */
            if (username == null)
            {
                if(User.Identity.Name != null){
                    User user = _userRepo.FindAll().Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                    if (user == null)
                    {
                        /* Skapar en ny User om ingen finns */
                        User newuser = new User { BirthDate = DateTime.Now, ID = Guid.NewGuid(), UserName = User.Identity.Name };
                        MiniFBContext db = new MiniFBContext();
                        db.Users.Add(newuser);
                        db.SaveChanges();
                        
                        return View(newuser);
                    }
                    return View(user);
                }
            }
            else
            {
                User user = _userRepo.FindAll().Where(u => u.UserName == username).FirstOrDefault();
                return View(user);
            }
            return HttpNotFound();
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