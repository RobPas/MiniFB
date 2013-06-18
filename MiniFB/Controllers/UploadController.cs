using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;

namespace MiniFB.Controllers
{
    public class UploadController : Controller
    {
        private IRepository<Image> _imageRepo;
        private IRepository<User> _userRepo;

        public UploadController() 
        {
            _imageRepo = new Repository<Image>();
            _userRepo = new Repository<User>();
        }

        public UploadController(IRepository<Image> imageRepo)
        {
            _imageRepo = imageRepo;
        }


        public ViewResult Index()
        {
            User user = _userRepo.FindAll(u => u.UserName == User.Identity.Name).FirstOrDefault();

            return View(user);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                string path = @"~\Images\Uploads\";

                if (photo.ContentLength > 204800)
                {
                    ModelState.AddModelError("photo", "The size of the file should not exceed 200 KB");
                    return RedirectToAction("Index");
                }

                var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };
                var fileExt = System.IO.Path.GetExtension(photo.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png, gif) are supported.");
                    return RedirectToAction("Index");
                }

                Image image = new Image();
                image.ID = Guid.NewGuid();
                image.FileType = "image/" + fileExt;
                image.FileName = photo.FileName;
                image.UserID = _userRepo.FindAll(u => u.UserName == User.Identity.Name).FirstOrDefault().ID;
                _imageRepo.Add(image);

                var serverPath = Server.MapPath(path + photo.FileName);

                photo.SaveAs(serverPath);
            }

            return RedirectToAction("Index", "Gallery");
        }
    }
}
