using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFB.Models
{
    public class NewsFeed
    {
        public Guid NewsFeedItemID { get; set; }
        public Guid UserID { get; set; }
        public virtual List<NewsFeedItem> Items { get; set; }
        public string OrderBy { get; set; }
    }
}