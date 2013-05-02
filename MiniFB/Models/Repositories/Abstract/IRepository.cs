using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MiniFB.Entities.Abstract;

namespace MiniFB.Models.Repositories.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        DbContext Model { get; }

        IQueryable<T> FindAll(Func<T, bool> filter = null);
        T FindByID(Guid id);
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);

        void Commit();
    }
}