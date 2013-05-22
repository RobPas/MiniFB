using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories.Abstract;
using MiniFB.Models.Repositories;

namespace MiniFB.Models.Repositories
{
    public interface IAppUserRepository : IRepository<User>
    {
        void DeleteUserByUserName(string Username);
    }

    public class AppUserRepository : Repository<User>, IAppUserRepository
    {
        public AppUserRepository() : base() { }

        public void DeleteUserByUserName(string Username)
        {
            var user = FindAll(u => u.UserName == Username).FirstOrDefault();
            Delete(user);
        }

    }
}