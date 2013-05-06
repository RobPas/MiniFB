using System;
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

        public NewsFeedItemController() 
        {
            _newsFeedItemRepo = new Repository<NewsFeedItem>();
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
                _newsFeedItemRepo.Add(newsfeeditem);
                return RedirectToAction("Index", "NewsFeed");
            }

            return View(newsfeeditem);
        }
    }
}