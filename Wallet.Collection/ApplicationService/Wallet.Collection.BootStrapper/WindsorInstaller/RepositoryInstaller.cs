using System.Data.Entity;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Wallet.Collection.BootStrapper.WindsorInstaller
{
    using Wallet.Collection.Domain.DataModel.Helpers;
    using Wallet.Collection.Domain.Repository;
    using Wallet.Collection.Infrastructure.Repository;

    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {




            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());

            container.Register(Component.For<DbContext>().ImplementedBy<EFContext>().LifestyleTransient());

            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter("bin"))
                                                  .BasedOn(typeof(BaseEntityRepository<>))
                                                  .WithService.DefaultInterfaces()
                                                  .LifestyleTransient());

            //container.Resolve<DbContext>().Database.CreateIfNotExists();


            //container.Register(Component.For<DbContext>()
            //                            .ImplementedBy<EFContext>()
            //                            .LifeStyle.Transient
            //);
        }
    }
}