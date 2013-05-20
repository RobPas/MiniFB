using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MiniFB.Models.Entities;
using WebMatrix.WebData;
using System.Web.Security;


namespace MiniFB.Models.Contexts
{
    public class MiniFBContext : DbContext
    {
        public MiniFBContext()
            : base("name = MiniFBContext")
        {

        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<NewsFeed> NewsFeed { get; set; }
        public DbSet<NewsFeedItem> NewsFeedItem { get; set; }


        
    }
}