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
        

        public DbSet<User> Users { get; set; }
        public DbSet<NewsFeed> NewsFeed { get; set; }
        public DbSet<NewsFeedItem> NewsFeedItem { get; set; }


        
    }

    public class MiniFBInitializer : DropCreateDatabaseAlways<MiniFBContext>
    {
        
        protected override void Seed(MiniFBContext context)
        {


            try
            {

                WebSecurity.CreateUserAndAccount("arnold", "password");
                WebSecurity.CreateUserAndAccount("goat", "password");
                WebSecurity.CreateUserAndAccount("urban", "password");
            }
            catch (Exception e)
            {

            }
            

            Guid ID_1 = Guid.NewGuid();
            Guid ID_2 = Guid.NewGuid();
            Guid ID_3 = Guid.NewGuid();

            context.Users.Add(new User { ID = ID_1, UserName = "goat", BirthDate = DateTime.Parse("1992-01-01"), FirstName = "Lasse", LastName = "Åberg" , Email = "lasse.aberg@hotmail.com", Sex = "Man" });
            context.Users.Add(new User { ID = ID_2, UserName = "arnold", BirthDate = DateTime.Parse("1990-05-04"), FirstName = "Arnold", LastName = "Olsson", Email = "arnold@live.se", Sex = "Man" });
            context.Users.Add(new User { ID = ID_3, UserName = "urban", BirthDate = DateTime.Parse("1983-01-06"), FirstName = "Urban", LastName = "Explorer", Email = "No email", Sex = "Kvinna" });

            try
            {
                context.NewsFeedItem.Add(new NewsFeedItem { ID = Guid.NewGuid(), Content = "This is my status...", Type = "Status", Created = DateTime.Now, Modified = DateTime.Now, UserID = ID_1 });
                context.NewsFeedItem.Add(new NewsFeedItem { ID = Guid.NewGuid(), Content = "Video...", Type = "Video", Created = DateTime.Now, Modified = DateTime.Now, UserID = ID_2 });
                context.NewsFeedItem.Add(new NewsFeedItem { ID = Guid.NewGuid(), Content = "http://google.com", Type = "Link", Created = DateTime.Now, Modified = DateTime.Now, UserID = ID_3 });
                context.NewsFeedItem.Add(new NewsFeedItem { ID = Guid.NewGuid(), Content = "/image.jpg", Type = "Image", Created = DateTime.Now, Modified = DateTime.Now, UserID = ID_3 });
            }
            catch (Exception e)
            { }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}