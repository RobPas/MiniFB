using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using MiniFB.Entities.Abstract;

namespace MiniFB.Models.Entities
{
    public class NewsFeed : IEntity
    {
        public Guid ID { get; set; }
        public User User { get; set; }
        public Guid UserID { get; set; }
        public virtual List<NewsFeedItem> Items { get; set; }
        public string OrderBy { get; set; }
    }
}