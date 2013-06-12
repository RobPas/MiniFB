namespace MiniFB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
using MiniFB.Models.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniFB.Models.Contexts.MiniFBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MiniFB.Models.Contexts.MiniFBContext context) 
        {
            Guid ID_1 = Guid.NewGuid();
            Guid ID_2 = Guid.NewGuid();
            Guid ID_3 = Guid.NewGuid();

            string salt = DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt();
            string pw = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword("password", salt);

            User User_1 = new User { ID = ID_1, UserName = "goat", IsUsingGravatar = false, Password = pw, Salt = salt, IsAdmin = false, BirthDate = DateTime.Parse("1992-01-01"), FirstName = "Lasse", LastName = "Åberg", Email = "lasse.aberg@hotmail.com", Sex = "Man", IsConfirmed=true, UserSecretQuestion = "Vad heter din hund?", UserSecretAnswer = "Pluto" };
            User User_2 = new User { ID = ID_2, UserName = "arnold", IsUsingGravatar = true, Password = pw, Salt = salt, IsAdmin = false, BirthDate = DateTime.Parse("1990-05-04"), FirstName = "Arnold", LastName = "Olsson", Email = "arnold@live.se", Sex = "Man", IsConfirmed = true, UserSecretQuestion = "Vad heter din hund?", UserSecretAnswer = "Pluto" };
            User User_3 = new User { ID = ID_3, UserName = "urban", IsUsingGravatar = true, Password = pw, Salt = salt, IsAdmin = false, BirthDate = DateTime.Parse("1983-01-06"), FirstName = "Urban", LastName = "Explorer", Email = "No email", Sex = "Kvinna", IsConfirmed = true, UserSecretQuestion = "Vad heter din hund?", UserSecretAnswer = "Pluto" };

            context.Users.AddOrUpdate(User_1,
                User_2,
                User_3
            );
            
            context.NewsFeedItem.AddOrUpdate(
               new NewsFeedItem { ID = Guid.NewGuid(), ItemType = 1, Content = "This is my status...", Created = DateTime.Now, Modified = DateTime.Now.AddDays(1), User = User_3 },
               new NewsFeedItem { ID = Guid.NewGuid(), ItemType = 3, Content = "Video...", Created = DateTime.Now, Modified = DateTime.Now.AddDays(15), User = User_1, Data = "https://www.youtube-nocookie.com/embed/BTDib1Q_gX8" },
               new NewsFeedItem { ID = Guid.NewGuid(), ItemType = 4, Content = "The Search Engine", Created = DateTime.Now, Modified = DateTime.Now.AddDays(25), User = User_2, Data = "http://google.com" },
               new NewsFeedItem { ID = Guid.NewGuid(), ItemType = 2, Content = "En bild...", Created = DateTime.Now, Modified = DateTime.Now.AddDays(4), User = User_1, Data = "/Content/images/goat-serious.jpg" }
             );  

        }
    }
}
