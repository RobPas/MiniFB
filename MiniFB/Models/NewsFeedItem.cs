using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniFB.Models
{
    public class NewsFeedItem
    {
        public Guid NewsFeedItemID { get; set; }
        public Guid UserID { get; set; }
        public Guid NewsFeedID { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public virtual List<NewsFeedComment> Comments { get; set; }
    }
}
