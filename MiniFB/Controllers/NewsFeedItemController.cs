using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFB.Models.Contexts;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;

namespace MiniFB.Controllers
{
    public class NewsFeedItemController : Controller
    {
        private IRepository<NewsFeedItem> _newsFeedItemRepo;
        private IRepository<User> _userRepo;

        public NewsFeedItemController() 
        {
            _newsFeedItemRepo = new Repository<NewsFeedItem>();
            _userRepo = new Repository<User>();
        }

        public NewsFeedItemController(IRepository<NewsFeedItem> newsFeedItemRepo)
        {
            _newsFeedItemRepo = newsFeedItemRepo;
        }

        public ActionResult Index() 
        {
            return RedirectToAction("Create");
        }

        //
        // GET: /NewsFeedItem/Create

        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "status", Value = "status" });
            items.Add(new SelectListItem { Text = "video", Value = "video" });
            items.Add(new SelectListItem { Text = "image", Value = "image" });
            items.Add(new SelectListItem { Text = "link", Value = "link" });

            ViewBag.items = items;

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
                newsfeeditem.ID = Guid.NewGuid();
                newsfeeditem.Created = DateTime.Now;
                newsfeeditem.Modified = DateTime.Now;
                newsfeeditem.UserID = _userRepo.FindAll().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().ID;
                _newsFeedItemRepo.Add(newsfeeditem);
                return RedirectToAction("Index", "NewsFeed");
            }

            return View(newsfeeditem);
        }
    }
}