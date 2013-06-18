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
    [Authorize]
    public class ProfileController : Controller
    {
        private IRepository<User> _userRepo;
        private SettingsValidator sv;

        public ProfileController()
        {
            _userRepo = new Repository<User>();
            sv = new SettingsValidator();
        }

        public ProfileController(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public ActionResult Index(string username = null)
        {
            /* Om inget username skickas med visas den inloggades egna profilsida */
            if (username == null)
            {
                if(User.Identity.Name != null)
                {
                    User user = _userRepo.FindAll(u => u.UserName == User.Identity.Name).FirstOrDefault();
                    
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

            if (user != null)
            {
                UserProfileSettings ups = new UserProfileSettings();
                ups.UserID = user.ID;
                ups.FirstName = user.FirstName;
                ups.LastName = user.LastName;
                ups.BirthDate = user.BirthDate;
                ups.Email = user.Email;
                ups.IsUsingGravatar = user.IsUsingGravatar;
                ups.Sex = user.Sex;
               
                return View(ups);
            }
            return HttpNotFound();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfileSettings userp)
        {
            User user = _userRepo.FindByID(userp.UserID);

            if (ModelState.IsValid && sv.isValidSex(userp.Sex))
            {
                user.ID = userp.UserID;
                user.FirstName = userp.FirstName;
                user.LastName = userp.LastName;
                user.BirthDate = userp.BirthDate;
                user.Email = userp.Email;
                user.IsUsingGravatar = userp.IsUsingGravatar;
                user.Sex = userp.Sex;
                _userRepo.Update(user);
                return RedirectToAction("Index");
            }
            return View(userp);
        }
        

        public ActionResult ChangePassword(Guid userID)
        {
            User user = _userRepo.FindByID(userID);
            if (user != null && sv.isCorrectUser(User.Identity.Name, user))
            {
                ChangePasswordModel cpm = new ChangePasswordModel();
                cpm.UserID = user.ID;
                
                return View(cpm);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            User user = _userRepo.FindByID(changePasswordModel.UserID);

            if (user != null && sv.isCorrectUser(User.Identity.Name, user))
            {
                if (ModelState.IsValid && sv.isOldPasswordCorrect(changePasswordModel.OldPassword, user))
                {
                    user.Password = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(changePasswordModel.NewPassword, user.Salt);
                    _userRepo.Update(user);

                    return RedirectToAction("Message", new { msg = "Tjoho! Du har byt lösenord. Ditt gamla lösenord gäller inte längre." });
                }else if (sv.isOldPasswordCorrect(changePasswordModel.OldPassword, user) == false)
                {
                    ViewBag.ErrorMessage = "Ditt gamla lösenord stämmer inte.";
                }
            }
            return View(changePasswordModel);
        }


        public ActionResult Message(string msg = null)
        {
            ViewBag.msg = msg;
            return View();
        }

    }
}
