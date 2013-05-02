using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFB.Models.Contexts;
using MiniFB.Models.Entities;

namespace MiniFB.Controllers
{
    public class NewsFeedItemController : Controller
    {
        private MiniFBContext db = new MiniFBContext();

        public ActionResult Index() 
        {
            return RedirectToAction("Create");
        }

        //
        // GET: /NewsFeedItem/List

        public ActionResult List()
        {
            return View(db.NewsFeedItem.ToList());
        }

        //
        // GET: /NewsFeedItem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NewsFeedItem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsFeedItem newsfeeditem)
        {
            if (ModelState.IsValid)
            {
                //newsfeeditem.UserID = Session['UserID'];
                newsfeeditem.ID = Guid.NewGuid();
                //newsfeeditem.NewsFeedID = Session["NewsFeedID"];
                newsfeeditem.Created = DateTime.Now;
                newsfeeditem.Modified = DateTime.Now;
                db.NewsFeedItem.Add(newsfeeditem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsfeeditem);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}