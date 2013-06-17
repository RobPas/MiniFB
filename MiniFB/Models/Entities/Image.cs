using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniFB.Entities.Abstract;

namespace MiniFB.Models.Entities
{
    public class Image : IEntity
    {
        public Guid ID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

        public virtual Guid UserID { get; set; }
        public virtual User User { get; set; }
    }
}