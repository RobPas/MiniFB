namespace MiniFB.Migrations
{
    using MiniFB.Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniFB.Models.Contexts.MiniFBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MiniFB.Models.Contexts.MiniFBContext context) 
        {
            Guid ID_1 = Guid.NewGuid();
            Guid ID_2 = Guid.NewGuid();
            Guid ID_3 = Guid.NewGuid();

            string salt = DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt();
            string pw = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword("password", salt); 

            context.Users.AddOrUpdate(r => r.UserName,
                new User { ID = ID_1, UserName = "goat", Password=pw, Salt=salt, IsAdmin=false, BirthDate = DateTime.Parse("1992-01-01"), FirstName = "Lasse", LastName = "Åberg", Email = "lasse.aberg@hotmail.com", Sex = "Man" },
                new User { ID = ID_2, UserName = "arnold", Password = pw, Salt = salt, IsAdmin = false, BirthDate = DateTime.Parse("1990-05-04"), FirstName = "Arnold", LastName = "Olsson", Email = "arnold@live.se", Sex = "Man" },
                new User { ID = ID_3, UserName = "urban", Password = pw, Salt = salt, IsAdmin = false, BirthDate = DateTime.Parse("1983-01-06"), FirstName = "Urban", LastName = "Explorer", Email = "No email", Sex = "Kvinna" }
                );



            context.NewsFeedItem.AddOrUpdate(r => r.ID,
               new NewsFeedItem { ID = Guid.NewGuid(), Content = "This is my status...", Type = "Status", Created = DateTime.Now, Modified = DateTime.Now.AddDays(1), UserID = ID_1 },
               new NewsFeedItem { ID = Guid.NewGuid(), Content = "Video...", Type = "Video", Created = DateTime.Now, Modified = DateTime.Now.AddDays(15), UserID = ID_2 },
               new NewsFeedItem { ID = Guid.NewGuid(), Content = "http://google.com", Type = "Link", Created = DateTime.Now, Modified = DateTime.Now.AddDays(25), UserID = ID_3 },
               new NewsFeedItem { ID = Guid.NewGuid(), Content = "/image.jpg", Type = "Image", Created = DateTime.Now, Modified = DateTime.Now.AddDays(4), UserID = ID_3 }
               );  

        }
    }
}
