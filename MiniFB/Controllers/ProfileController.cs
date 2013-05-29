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
        private IRepository<NewsFeedItem> _newsFeedItemRepo;
        private SettingsValidator sv;

        public ProfileController()
        {
            _userRepo = new Repository<User>();
            _newsFeedItemRepo = new Repository<NewsFeedItem>();
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
                    List<NewsFeedItem> _newsfeeditems = _newsFeedItemRepo.FindAll().Include(n => n.User).Where(n => n.User.UserName == User.Identity.Name).ToList();

                    User user = _userRepo.FindAll(u => u.UserName == User.Identity.Name).FirstOrDefault();
                    user.NewsFeedItems = _newsfeeditems;
                    
                    return View(user);
                }
            }
            else
            {
                User user = _userRepo.FindAll().Where(u => u.UserName == username).Include(u => u.NewsFeedItems).FirstOrDefault();
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
            if (ModelState.IsValid && sv.isValidSex(user.Sex))
            {
                _userRepo.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
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
