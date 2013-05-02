using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFB.Models.Contexts;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;

namespace MiniFB.Controllers
{
    public class GoatController : Controller
    {
        private IRepository<User> _userRepo;

        public GoatController()
        {
            _userRepo = new Repository<User>();
        }

        public GoatController(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public ActionResult Index()
        {
           return View();
        }

        public ViewResult List()
        {
            List<User> Users = _userRepo.FindAll(u => u.BirthDate > DateTime.Parse("2010-01-01")).ToList();

            return View(Users);
        }

    }
}
