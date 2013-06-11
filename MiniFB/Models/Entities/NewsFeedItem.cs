using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using MiniFB.Entities.Abstract;

namespace MiniFB.Models.Entities
{
    public class NewsFeedItem : IEntity
    {
        private int _itemType;
        private string _dataStr;

        public enum NewsFeedItemTypes
        {
            Status = 1,
            Image = 2,
            Video = 3,
            Link = 4
        }

        public Guid ID { get; set; }

        public virtual User User { get; set; }
        public virtual Guid UserID { get; set; }

        [Required]
        public int ItemType 
        {
            get 
            {
                return this._itemType;
            }
            set
            {
                int max = Enum.GetNames(typeof(NewsFeedItemTypes)).Length;

                if (value <= 0 || value > max)
                {
                    throw new Exception("There is no type associated with that number");
                }
                else
                {
                    this._itemType = value;
                }
            }
        }

        public string GetItemTypeStr 
        {
            get 
            { 
                string _itemTypeStr;

                switch (this.ItemType)
                {
                    case 1:
                        _itemTypeStr = "Status";
                        break;
                    case 2:
                        _itemTypeStr = "Bild";
                        break;
                    case 3:
                        _itemTypeStr = "Video";
                        break;
                    case 4:
                        _itemTypeStr = "Länk";
                        break;
                    default:
                        _itemTypeStr = "";
                        break;
                }

                return _itemTypeStr;
            }
        }

        //public NewsFeedItemData Data { get; set; }
        public string Data { get; set; }

        //public string Data { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        [Display(Name="Beskrivning")]
        [Required]
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        [DataType(DataType.Date)]
        [Display(Name="Skapad")]
        public DateTime Created { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        [DataType(DataType.Date)]
        [Display(Name="Modifierad")]
        public DateTime Modified { get; set; }

        public virtual List<NewsFeedComment> Comments { get; set; }
    }

    public class YouTubeVideo
    {
        public string ID { get; set; }
    }

    public class NewsFeedItemData
    {
        private string _dataStr;
        private int _itemType;

        public virtual NewsFeedItem NewsFeedItem { get; set; }
        public virtual Guid NewsFeedItemID { get; set; }

        public NewsFeedItemData(string dataStr, int itemType) 
        {
            if (dataStr == null) 
            {
                throw new Exception("You have to provide a value");
            }

            _dataStr = dataStr;
            _itemType = itemType;
        }

        public string DataStr
        {
            get
            {
                return _dataStr;
            }
            set 
            {
                this.DataStr = value;
            }
        }
    }
}
