using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MiniFB.Entities.Abstract;

namespace MiniFB.Models.Entities
{
    public class NewsFeedItem : IEntity
    {
        public Guid ID { get; set; }
        public RegisterUser User { get; set; }
        public Guid UserID { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        [DataType(DataType.Date)]
        public DateTime Modified { get; set; }

        public virtual List<NewsFeedComment> Comments { get; set; }

        protected static string[] GetNewsFeedItemTypes()
        {
            string[] types = new string[4]
            {
                "status",
                "photo",
                "video",
                "link"
            };

            return types;
        }
    }
}
