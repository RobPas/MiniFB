using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;
using Newtonsoft.Json;

namespace MiniFB.Controllers
{
    public class FeedItemController : ApiController
    {
        private IRepository<NewsFeedItem> _newsFeedItemRepo;

        public FeedItemController()
        {
            _newsFeedItemRepo = new Repository<NewsFeedItem>();
        }

        // Get All Items
        public IEnumerable<NewsFeedItem> GetAllItems()
        {
            var feeditems = _newsFeedItemRepo.FindAll().ToList();
            return feeditems;
        }

        // Get Item
        public NewsFeedItem GetItemWithID(Guid id)
        {
            var item = _newsFeedItemRepo.FindByID(id);
            return item;
        }

        // Post Item

        // Put Item

        // Delete Item
    }
}
