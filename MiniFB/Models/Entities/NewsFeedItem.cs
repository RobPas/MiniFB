using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MiniFB.Entities.Abstract;

namespace MiniFB.Models.Entities
{
    public class NewsFeedItem : IEntity
    {
        private string _itemType;

        public ArrayList types = new ArrayList()
        {
            "status",
            "image",
            "video",
            "link"
        };

        public NewsFeedItem()
        {
        }

        public Guid ID { get; set; }
        public User User { get; set; }
        //public Guid UserID { get; set; }

        [DisplayFormat()]
        public string Type {
            get
            {
                return this._itemType;
            }
 
            set 
            {
                if (value == null)
                    throw new Exception("Type cannot be null");

                string str = value.ToString().ToLower();

                int l = types.Count;
                ArrayList results = new ArrayList();

                foreach (string type in types)
                {
                    if (str == type)
                    {
                        results.Add(str);
                    }
                }

                if (results.Count > 0)
                {
                    this._itemType = value;
                }
                else 
                {
                    throw new Exception("That is not a valid type value!");
                }
            } 
        }
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        [DataType(DataType.Date)]
        public DateTime Modified { get; set; }

        public virtual List<NewsFeedComment> Comments { get; set; }
    }
}
