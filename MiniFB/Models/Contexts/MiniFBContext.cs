using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MiniFB.Models.Entities;



namespace MiniFB.Models.Contexts
{
    public class MiniFBContext : DbContext
    {
        public MiniFBContext()
            : base("name = MiniFBContext")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<NewsFeedItem> NewsFeedItem { get; set; }

        public DbSet<Image> Images { get; set; }


        
    }
}
