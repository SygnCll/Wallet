using System;
using Wallet.Collection.Infrastructure.Repository;

namespace Wallet.Collection.Infrastructure.Contract
{
    public interface IIUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();

        void Begin();
        void Commit();
    }
}
