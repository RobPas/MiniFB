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
    }

    public class MiniFBInitializer : DropCreateDatabaseAlways<MiniFBContext>
    {
        protected override void Seed(MiniFBContext context)
        {
            Guid UserID_1 = Guid.NewGuid();
            Guid UserID_2 = Guid.NewGuid();

            context.Users.Add(new User { Id = UserID_1, UserName = "Goat" });
            context.Users.Add(new User { Id = UserID_2, UserName = "Arnold" });
            context.Users.Add(new User { Id = Guid.NewGuid(), UserName = "Urban" });

            NewsFeedComment 

            context.NewsFeedItem.Add(new NewsFeedItem { NewsFeedItemID = Guid.NewGuid(), Content = "Min Status", UserID = UserID_1, Created = DateTime.Now, Modified = DateTime.Now, Type = "Status", Comments = NewsFeedComments_1 });

            base.Seed(context);
        }
    }
}