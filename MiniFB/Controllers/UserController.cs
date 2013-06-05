using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFB.Controllers
{
    public class UserController : Controller
    {
        private IRepository<User> _userRepo;

        public UserController()
        {
            _userRepo = new Repository<User>();
        }

        public UserController(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        //
        // GET: /User/

        public ViewResult Search(string q)
        {
            var results = _userRepo.FindAll(u => u.UserName.Contains(q)).ToList();
            return View(results);
        }

    }
}
