using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFB.Controllers
{
    public class ChatController : Controller
    {

        private IRepository<User> _userRepo;

        public ChatController()
        {
            _userRepo = new Repository<User>();
        }

        public ActionResult Index()
        {
            return View();
        }


    }
}
