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

            User User_1 = new User { ID = ID_1, UserName = "goat", IsUsingGravatar = false, Password = pw, Salt = salt, IsAdmin = false, BirthDate = DateTime.Parse("1992-01-01"), FirstName = "Lasse", LastName = "Åberg", Email = "lasse.aberg@hotmail.com", Sex = "Man", IsConfirmed=true };
            User User_2 = new User { ID = ID_2, UserName = "arnold", IsUsingGravatar = true, Password = pw, Salt = salt, IsAdmin = false, BirthDate = DateTime.Parse("1990-05-04"), FirstName = "Arnold", LastName = "Olsson", Email = "arnold@live.se", Sex = "Man", IsConfirmed = true };
            User User_3 = new User { ID = ID_3, UserName = "urban", IsUsingGravatar = true, Password = pw, Salt = salt, IsAdmin = false, BirthDate = DateTime.Parse("1983-01-06"), FirstName = "Urban", LastName = "Explorer", Email = "No email", Sex = "Kvinna", IsConfirmed = true };

            context.Users.AddOrUpdate(r => r.UserName,
                User_1,
                User_2,
                User_3
            );
            
            context.NewsFeedItem.AddOrUpdate(r => r.ID,
               new NewsFeedItem { ID = Guid.NewGuid(), ItemType = 1, Content = "This is my status...", Created = DateTime.Now, Modified = DateTime.Now.AddDays(1), User = User_3 },
               new NewsFeedItem { ID = Guid.NewGuid(), ItemType = 2, Content = "Video...", Created = DateTime.Now, Modified = DateTime.Now.AddDays(15), User = User_1 },
               new NewsFeedItem { ID = Guid.NewGuid(), ItemType = 3, Content = "http://google.com", Created = DateTime.Now, Modified = DateTime.Now.AddDays(25), User = User_2 },
               new NewsFeedItem { ID = Guid.NewGuid(), ItemType = 4, Content = "/image.jpg", Created = DateTime.Now, Modified = DateTime.Now.AddDays(4), User = User_1 }
             );  



        }
    }
}
