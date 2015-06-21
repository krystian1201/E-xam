using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Shared.Repository
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly DbContext _dbContext;
        private readonly IDbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        #region IRepository members

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {

            foreach (var entity in entities)
            {
                _dbSet.Add(entity);
            }
        }

        public virtual void DeleteAll()
        {

            foreach (var entity in _dbSet.ToList())
            {
                Delete(entity);
            }

        }

        public virtual void Delete(T entity)
        {
            //var entry = _dbSet.Find(entity);
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(long id)
        {
            //var entry = _dbContext.Entry(entity);
            //entry.State = System.Data.EntityState.Deleted;

            var entry = _dbSet.Find(id);
            _dbSet.Remove(entry);
            _dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            //var entry = _dbContext.Entry(entity);
            //_dbSet.Attach(entity);
            //entry.State = System.Data.EntityState.Modified;

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public virtual T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        #endregion


        #region IDispose members

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _disposed = true;
        }

        #endregion
    }
}
