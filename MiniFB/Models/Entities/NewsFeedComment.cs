using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniFB.Entities.Abstract;

namespace MiniFB.Models.Entities
{
    public class NewsFeedComment : IEntity
    {
        public Guid ID { get; set; }
        public User User { get; set; }
        public Guid UserID { get; set; }
        public NewsFeedItem NewsFeedItem { get; set; }
        public Guid NewsFeedItemID { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
