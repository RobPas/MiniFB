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
        public DbSet<User> Users { get; set; }
        public DbSet<NewsFeed> NewsFeed { get; set; }
        public DbSet<NewsFeedItem> NewsFeedItem { get; set; }
    }

    public class MiniFBInitializer : DropCreateDatabaseAlways<MiniFBContext>
    {
        protected override void Seed(MiniFBContext context)
        {
            Guid ID_1 = Guid.NewGuid();
            Guid ID_2 = Guid.NewGuid();
            Guid ID_3 = Guid.NewGuid();

            context.Users.Add(new User { ID = ID_1, UserName = "Goat", BirthDate = DateTime.Parse("1992-01-01"), FirstName = "Lasse", LastName = "Åberg" , Email = "lasse.aberg@hotmail.com", Password = "pw123", Sex = "Man" });
            context.Users.Add(new User { ID = ID_2, UserName = "Arnold", BirthDate = DateTime.Parse("1990-05-04"), FirstName = "Arnold", LastName = "Olsson", Email = "arnold@live.se", Password = "123123", Sex = "Man" });
            context.Users.Add(new User { ID = ID_3, UserName = "Urban", BirthDate = DateTime.Parse("1983-01-06"), FirstName = "Urban", LastName = "Explorer", Email = "No email", Password = "noob", Sex = "Kvinna" });

            context.SaveChanges();

            Guid NFID_1 = Guid.NewGuid();
            Guid NFID_2 = Guid.NewGuid();
            Guid NFID_3 = Guid.NewGuid();

            context.NewsFeed.Add(new NewsFeed { ID = NFID_1, UserID = ID_1 });
            context.NewsFeed.Add(new NewsFeed { ID = NFID_2, UserID = ID_2 });
            context.NewsFeed.Add(new NewsFeed { ID = NFID_3, UserID = ID_3 });

            context.NewsFeedItem.Add(new NewsFeedItem { ID = Guid.NewGuid(), Content = "This is my status...", Type = "Status", UserID = ID_1, Created = DateTime.Now, Modified = DateTime.Now });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}