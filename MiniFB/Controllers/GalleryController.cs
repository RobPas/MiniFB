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
    public class GalleryController : Controller
    {
        private IRepository<Image> _imageRepo;
        private IRepository<User> _userRepo;

        public GalleryController() 
        {
            _imageRepo = new Repository<Image>();
            _userRepo = new Repository<User>();
        }

        public GalleryController(IRepository<Image> imageRepo)
        {
            _imageRepo = imageRepo;
        }

        public ViewResult Index()
        {
            Guid UserID = _userRepo.FindAll(u => u.UserName == User.Identity.Name).FirstOrDefault().ID;

            return View(_imageRepo.FindAll(i => i.UserID == UserID));
        }

        public FileResult View(Guid ID)
        {
            Image image = _imageRepo.FindByID(ID);

            return File(@"~\Images\Uploads\" + image.FileName, image.FileType);
        
        }

        public ViewResult Delete(Guid ID)
        {
            Image image = _imageRepo.FindByID(ID);

            return View(image);
        }

        [HttpPost]
        public ActionResult Delete(Image image) 
        {
            System.IO.File.Delete(@"~\Images\Uploads\" + image);
            return View();
        }
    }
}
