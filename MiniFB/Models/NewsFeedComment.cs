using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniFB.Models
{
    class NewsFeedComment
    {
        public Guid NewsFeedCommentID { get; set; }
        public Guid UserID { get; set; }
        public Guid NewsFeedItemID { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
