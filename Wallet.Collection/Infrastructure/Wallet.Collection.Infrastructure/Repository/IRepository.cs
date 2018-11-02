using System;
using System.Linq;
using System.Linq.Expressions;

namespace Wallet.Collection.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        object CurrentSession();
        T GetSingle(object id);
        T Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        T Add(T instance);
        void Update(T instance);
        T AddOrUpdate(T entity);
        void Delete(T instance);
    }
}
