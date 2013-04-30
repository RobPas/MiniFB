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
    }

    public class MiniFBInitializer : DropCreateDatabaseAlways<MiniFBContext>
    {
        protected override void Seed(MiniFBContext context)
        {
            context.Users.Add(new User { Id = Guid.NewGuid(), UserName = "Goat" });

            base.Seed(context);
        }
    }
}