using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Wallet.Collection.BootStrapper.Intercepter;

namespace Wallet.Collection.BootStrapper.WindsorInstaller
{
    public class InterceptorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<LogInterceptor>().LifeStyle.Transient,
                Component.For<ExceptionInterceptor>().LifeStyle.Transient
            );
        }
    }
}
