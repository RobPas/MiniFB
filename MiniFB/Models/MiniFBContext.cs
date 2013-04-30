using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniFB.Models
{
    public class MiniFBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<NewsFeed> NewsFeed { get; set; }
        //public DbSet<NewsFeedItem> NewsFeedItem { get; set; }
    }

    public class MiniFBInitializer : DropCreateDatabaseAlways<MiniFBContext>
    {
        protected override void Seed(MiniFBContext context)
        {
            Guid UserID_1 = Guid.NewGuid();
            Guid UserID_2 = Guid.NewGuid();
            Guid UserID_3 = Guid.NewGuid();

            context.Users.Add(new User { Id = UserID_1, UserName = "Goat" });
            context.Users.Add(new User { Id = UserID_2, UserName = "Arnold" });
            context.Users.Add(new User { Id = UserID_3, UserName = "Urban" });

            base.Seed(context);
        }
    }
}