using MiniFB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFB.Models.Entities
{
    public class Like : IEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid NewsFeedItemID { get; set; }
    }
}