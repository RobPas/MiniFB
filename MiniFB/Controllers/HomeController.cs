using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /* Redirect if logged in */

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Newsfeed");
            }

            return View();
        }
    }
}
