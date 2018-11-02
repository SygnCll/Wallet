using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace Wallet.Collection.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext can not be null.");
            dbSet = dbContext.Set<T>();
        }

        public object CurrentSession()
        {
            throw new NotImplementedException();
        }

        public virtual T Add(T instance)
        {
            //dbSet.Add(instance);

            dbContext.Set<T>().Add(instance);
            dbContext.SaveChanges();

            return instance;
        }

        public virtual T AddOrUpdate(T instance)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T instance)
        {
            throw new NotImplementedException();
        }

        public virtual T Get(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).SingleOrDefault();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            IQueryable<T> query = dbSet;

            if (expression != null)
                query = query.Where(expression);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public virtual T GetSingle(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(T instance)
        {
            dbSet.Attach(instance);
            dbContext.Entry(instance).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
