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
        private IRepository<Like> _likesRepo;
        

        public NewsFeedItemController() 
        {
            _newsFeedItemRepo = new Repository<NewsFeedItem>();
            _userRepo = new Repository<User>();
            _likesRepo = new Repository<Like>();
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

        public ActionResult Create(int ? ItemType = -1)
        {
            NewsFeedItem n = new NewsFeedItem();
            n.ItemType = (int)ItemType;

            ViewBag.type = ItemType;

            if (ItemType <= 0 || ItemType > 4)
                return RedirectToAction("Index", "NewsFeed");

            return View(n);
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
                newsfeeditem.UserID = _userRepo.FindAll(u => u.UserName == User.Identity.Name).FirstOrDefault().ID;
                _newsFeedItemRepo.Add(newsfeeditem);
                return RedirectToAction("Index", "NewsFeed");
            }

            return View(newsfeeditem);
        }
        
        public JsonResult AddComment(Guid newsfeedid, string commenttext)
        {
            var user = _userRepo.FindAll(u => u.UserName == User.Identity.Name).FirstOrDefault();
            var newsfeeditem = _newsFeedItemRepo.FindAll(u => u.ID == newsfeedid).FirstOrDefault();

            var nfc = new NewsFeedComment { ID = Guid.NewGuid(), Created = DateTime.Now, Modified = DateTime.Now, CommentWriter = User.Identity.Name, NewsFeedItemGuid = newsfeedid, Message = commenttext };

            newsfeeditem.Comments.Add(nfc);
            _newsFeedItemRepo.Update(newsfeeditem);
            return Json(new { result = "ok" });
        }

        [HttpPost]
        public JsonResult Like(Guid ID)
        {
            var userID = _userRepo.FindAll(u => u.UserName == User.Identity.Name).FirstOrDefault().ID;
            var newsfeeditem = _newsFeedItemRepo.FindAll(u => u.ID == ID).FirstOrDefault();
            var likes = _likesRepo.FindAll(u => u.NewsFeedItemID == newsfeeditem.ID).ToList();
            
            bool alreadyLiked = false;
            foreach(var item in likes)
            {
                if (item.UserID == userID)
                {
                    alreadyLiked = true;
                    break;
                }
            }

            if (!alreadyLiked)
            {

                Like like = new Like();
                like.ID = Guid.NewGuid();
                like.UserID = userID;
                like.NewsFeedItemID = ID;
                _likesRepo.Add(like);
            }

            return Json(new { result = "ok" });
        }
    }
}