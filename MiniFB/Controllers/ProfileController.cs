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





        public ActionResult ChangePassword(Guid id)
        {
            User user = _userRepo.FindByID(id);
            if (user != null && sv.isCorrectUser(User.Identity.Name, user))
            {
                return View(user);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(Guid id, string oldpassword, string newpassword, string confirmpassword)
        {
            User user = _userRepo.FindByID(id);

            if (user != null && sv.isCorrectUser(User.Identity.Name, user))
            {
                if (sv.isPasswordConfirmed(newpassword, confirmpassword) && sv.isOldPasswordCorrect(oldpassword, user))
                {
                    user.Password = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(newpassword, user.Salt);
                    _userRepo.Update(user);
                    return RedirectToAction("Message", new { msg = "Tjoho! Du har byt lösenord. Ditt gamla lösenord gäller inte längre."});
                }
            }
            return View(user);
        }

        public ActionResult Message(string msg = null)
        {
            ViewBag.msg = msg;
            return View();
        }






    }
}
