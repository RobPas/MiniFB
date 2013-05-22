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
        private IRepository<User> _userRepo;

        public NewsFeedController()
        {
            _newsFeedItemRepo = new Repository<NewsFeedItem>();
            _userRepo = new Repository<User>();
        }

        public NewsFeedController(IRepository<NewsFeedItem> newsFeedItemRepo) 
        {
            _newsFeedItemRepo = newsFeedItemRepo;
        }

        //
        // GET: /NewsFeed/

        public ActionResult Index(string filter = "")
        {
            int filterType;

            switch (filter)
            {
                case "status":
                    filterType = (int)NewsFeedItem.NewsFeedItemTypes.Status;
                    break;
                case "image":
                    filterType = (int)NewsFeedItem.NewsFeedItemTypes.Image;
                    break;
                case "video":
                    filterType = (int)NewsFeedItem.NewsFeedItemTypes.Video;
                    break;
                case "link":
                    filterType = (int)NewsFeedItem.NewsFeedItemTypes.Link;
                    break;
                default:
                    filterType = -1;
                    break;
            }

            ViewBag.active = filterType;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_NewsFeedItems", _newsFeedItemRepo.FindAll().Include(n => n.User).OrderByDescending(t => t.Modified).Where(n => n.ItemType == filterType).ToList());
            }
           
            if (filterType == -1)
                return View(_newsFeedItemRepo.FindAll().Include(n => n.User).OrderByDescending(t => t.Modified).ToList());
            else
                return View(_newsFeedItemRepo.FindAll().Include(n => n.User).OrderByDescending(t => t.Modified).Where(n => n.ItemType == filterType).ToList());
        }
    }
}