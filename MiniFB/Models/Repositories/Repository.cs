using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Data.Entity;
using System.Data;
using MiniFB.Models;
using MiniFB.Entities.Abstract;
using MiniFB.Models.Contexts;
using MiniFB.Models.Repositories.Abstract;

namespace MiniFB.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbContext _context;
        protected DbSet<T> _dbSet;

        public Repository()
        {
            _context = new MiniFBContext();
            // This brakes E V E R Y T H I N G!
            //_context.Configuration.ProxyCreationEnabled = false;
            _dbSet = _context.Set<T>();
        }

        public DbContext Model
        {
            get { return _context;  }
        }

        public virtual IQueryable<T> FindAll(Func<T, bool> filter = null)
        {
            if (null == filter)
                return _dbSet;
            return _dbSet.Where(filter).AsQueryable();
        }

        public virtual T FindByID(Guid id)
        {
            return _dbSet.FirstOrDefault(e => e.ID == id);
        }

        public virtual void Update(T entity)
        {
            var existing = _dbSet.Where(e => e.ID == entity.ID).FirstOrDefault();
            if (existing != null)
            {
                var attachedEntry = _context.Entry(existing);
                attachedEntry.CurrentValues.SetValues(entity);
            }
            else
            {
                _context.Entry(existing).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public virtual void Add(T entity)
        {
            var existing = _dbSet.Where(e => e.ID == entity.ID).FirstOrDefault();
            if (null != existing)
                throw new Exception(string.Format("Entity {0} already exists", entity.ToString()));
            else
                _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Entry(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        /// <summary>
        /// To have any use for this method - _context.SaveChanges needs to be removed from .Save(..) and .Delete(..).
        /// After that change an entity is saved by e.g: "repo.Save(entity);repo.Commit();"
        /// 
        /// Useful in case bulk operations or more complex transactions are needed.
        /// </summary>
        public virtual void Commit()
        {
            _context.SaveChanges();
        }
    }
}