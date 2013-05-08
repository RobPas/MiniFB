using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories.Abstract;


namespace MiniFB.Models.Repositories
{
    public interface IAppUserRepository : IRepository<User>
    {
        User GetUserNameByEmail(string email);
        void RegisterUser(User user);
        void DeleteUserByUserName(string username);
    }

    public class AppUserRepository : Repository<User>, IAppUserRepository
    {
        public AppUserRepository() : base() { }

        public User GetUserNameByEmail(string email)
        {
            return FindAll(u => u.Email == email).FirstOrDefault();
        }
        public void RegisterUser(User user)
        {
            user.ID = Guid.NewGuid();
            _dbSet.Add(user);
            _context.SaveChanges();
        }
        public void DeleteUserByUserName(string username)
        {
            var user = FindAll(u => u.UserName == username).FirstOrDefault();
            _dbSet.Remove(user);
            _context.SaveChanges();
        }
    }
}