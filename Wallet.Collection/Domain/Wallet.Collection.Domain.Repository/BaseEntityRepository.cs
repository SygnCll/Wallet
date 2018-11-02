using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Collection.Infrastructure.Repository;

namespace Wallet.Collection.Domain.Repository
{
    public abstract class BaseEntityRepository<T> where T : class
    {
        protected IRepository<T> Repository { get; }

        protected BaseEntityRepository(IRepository<T> repository)
        {
            Repository = repository;
        }


        public T Add(T instance)
        {
            return Repository.Add(instance);
        }

        public T AddOrUpdate(T instance)
        {
            return Repository.AddOrUpdate(instance);
        }
        public void Update(T instance)
        {
            Repository.Update(instance);
        }

        public T GetSingle(object id)
        {
            return Repository.GetSingle(id);
        }

    }
}
