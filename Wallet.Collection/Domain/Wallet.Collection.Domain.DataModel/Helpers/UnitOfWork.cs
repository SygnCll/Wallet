using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Collection.Infrastructure.Contract;
using Wallet.Collection.Infrastructure.Repository;

namespace Wallet.Collection.Domain.DataModel.Helpers
{
    public class UnitOfWork : IIUnitOfWork
    {
        private readonly EFContext dbContext;
        private bool disposed = false;


        public UnitOfWork(EFContext dbContext)
        {
            Database.SetInitializer<EFContext>(null);

            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null.");

            this.dbContext = dbContext;

            //this.dbContext.Configuration.LazyLoadingEnabled = false;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(this.dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
                // sadece değişen alanları güncellemeyide sağlayabiliriz.
                return this.dbContext.SaveChanges();
            }
            catch
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
