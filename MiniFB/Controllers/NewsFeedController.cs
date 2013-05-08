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
    public class NewsFeedController : Controller
    {
        private IRepository<NewsFeedItem> _newsFeedItemRepo;

        public NewsFeedController()
        {
            _newsFeedItemRepo = new Repository<NewsFeedItem>();
        }

        public NewsFeedController(IRepository<NewsFeedItem> newsFeedItemRepo) 
        {
            _newsFeedItemRepo = newsFeedItemRepo;
        }

        //
        // GET: /NewsFeed/

        public ViewResult Index()
        {
            return View(_newsFeedItemRepo.FindAll().ToList());
        }

        public ActionResult Items()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_NewsFeedItems", _newsFeedItemRepo.FindAll().ToList());
            }

            return View("_NewsFeedItems", _newsFeedItemRepo.FindAll().ToList());
        }
    }
}