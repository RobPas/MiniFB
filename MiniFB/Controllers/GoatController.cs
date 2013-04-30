using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFB.Models;

namespace MiniFB.Controllers
{
    public class GoatController : Controller
    {
        //
        // GET: /Goat/

        private MiniFBContext db = new MiniFBContext();

        public ActionResult Index()
        {
           return View();
        }

        public ActionResult List()
        {
            List<User> Users = db.Users.ToList();

            return View(Users);
        }

    }
}
