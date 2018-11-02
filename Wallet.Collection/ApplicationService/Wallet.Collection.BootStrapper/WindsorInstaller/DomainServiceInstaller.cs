using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Wallet.Collection.BootStrapper.WindsorInstaller
{
    using System.Web.Http;
    using Wallet.Collection.Domain.Services;
    using Wallet.Collection.Infrastructure;
    using Wallet.Collection.Infrastructure.Helpers;
    using Wallet.Collection.Infrastructure.Contract;
    using Castle.Core;
    using Wallet.Collection.BootStrapper.Intercepter;
    using Castle.DynamicProxy;

    public class DomainServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyContaining<UserService>().BasedOn<IDomainService>().LifestyleTransient().WithService.Self(),
                Classes.FromAssemblyContaining<AccountService>().BasedOn<IDomainService>().LifestyleTransient().WithService.Self(),
                Classes.FromAssemblyContaining<ProvisionService>().BasedOn<IDomainService>().LifestyleTransient().WithService.Self(),
                Classes.FromAssemblyContaining<TransactionService>().BasedOn<IDomainService>().LifestyleTransient().WithService.Self()
            );

            container.Register(
                Component.For<IEmailSender>().ImplementedBy<DummyEmailSender>().LifeStyle.Transient
            );

            container.Register(
                Component.For<ILogger>().ImplementedBy<NLogLogger>().LifeStyle.Transient,
                Component.For<IGateLogger>().ImplementedBy<GateLogger>().LifeStyle.Transient,
                Component.For<IJsonSerializer>().ImplementedBy<JsonSerialization>().LifeStyle.Singleton
            ); 
        }
    }
}