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
        public DbSet<NewsFeedItem> NewsFeedItem { get; set; }
    }

    public class MiniFBInitializer : DropCreateDatabaseAlways<MiniFBContext>
    {
        protected override void Seed(MiniFBContext context)
        {
            Guid UserID_1 = Guid.NewGuid();
            Guid UserID_2 = Guid.NewGuid();
            Guid UserID_3 = Guid.NewGuid();

            context.Users.Add(new User { Id = UserID_1, UserName = "Goat", BirthDate = DateTime.Now });
            context.Users.Add(new User { Id = UserID_2, UserName = "Arnold", BirthDate = DateTime.Now });
            context.Users.Add(new User { Id = UserID_3, UserName = "Urban", BirthDate = DateTime.Now });

            Guid NewsFeedID_1 = Guid.NewGuid();
            Guid NewsFeedID_2 = Guid.NewGuid();
            Guid NewsFeedID_3 = Guid.NewGuid();

            context.NewsFeed.Add(new NewsFeed { NewsFeedID = NewsFeedID_1, UserID = UserID_1 });
            context.NewsFeed.Add(new NewsFeed { NewsFeedID = NewsFeedID_2, UserID = UserID_2 });
            context.NewsFeed.Add(new NewsFeed { NewsFeedID = NewsFeedID_3, UserID = UserID_3 });

            context.NewsFeedItem.Add(new NewsFeedItem { NewsFeedItemID = Guid.NewGuid(), Content = "This is my status...", Type = "Status", UserID = UserID_1 });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}