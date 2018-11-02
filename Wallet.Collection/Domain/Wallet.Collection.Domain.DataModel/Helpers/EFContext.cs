using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Wallet.Collection.Domain.DataModel.Helpers
{
    public class EFContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountActivities> AccountActivities { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Provision> Provision { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<User> User { get; set; }


        public EFContext() : base("EFContext")
        {
            Database.SetInitializer<EFContext>(new CreateDatabaseIfNotExists<EFContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.HasDefaultSchema("dbo");  
            base.OnModelCreating(modelBuilder);
        }
    }
}
