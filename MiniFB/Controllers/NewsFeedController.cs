using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFB.Models;

namespace MiniFB.Controllers
{
    public class NewsFeedController : Controller
    {
        private MiniFBContext db = new MiniFBContext();

        //
        // GET: /NewsFeed/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Items()
        {
            return View(db.NewsFeedItem.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}