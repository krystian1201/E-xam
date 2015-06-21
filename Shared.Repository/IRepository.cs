
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Shared.Repository
{
    public interface IRepository<T> : IDisposable where T: class
    {

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        //void AddOrUpdate(T entity);

        void Delete(long id);

        void Delete(T entity);

        void DeleteAll();

        void DeleteWhere(Expression<Func<T, bool>> predicate);

        void Update(T entity);

        T GetById(long id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
