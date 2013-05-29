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
        private IRepository<Image> _imageRepo;
        private SettingsValidator sv;

        public ProfileController()
        {
            _userRepo = new Repository<User>();
            _imageRepo = new Repository<Image>();
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
                    return RedirectToAction("Message", new { msg = "Tjoho! Du har byt lösenord. Ditt gamla lösenord gäller inte längre." });
                }
                else
                {
                    ViewBag.msg = "Ditt gamla lösenord stämmer inte. Eller så matchar inte det nya varandra.";
                }
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                string path = @"C:\images\";

                if (photo.ContentLength > 102400)
                {
                    ModelState.AddModelError("photo", "The size of the file should not exceed 10 KB");
                    return RedirectToAction("Index");
                }

                var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };
                var fileExt = System.IO.Path.GetExtension(photo.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
                    return RedirectToAction("Index");
                }

                Image image = new Image();
                image.ID = Guid.NewGuid();
                image.FileType = "image/" + fileExt;
                image.FileName = photo.FileName;
                _imageRepo.Add(image);

                photo.SaveAs(path + photo.FileName);
                
            }

            return RedirectToAction("Index");
        }

        public FileResult ImageDisplayTest(Guid ID)
        {
            Image image = _imageRepo.FindByID(ID);

            return File(@"c:\images\" + image.FileName, image.FileType);            
        }

        public ActionResult Message(string msg = null)
        {
            ViewBag.msg = msg;
            return View();
        }

    }
}
